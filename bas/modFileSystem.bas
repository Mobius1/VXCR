Attribute VB_Name = "modFileSystem"
Dim fso As New FileSystemObject
Public strLoc As String
Public CancelReadPath As Boolean

'Reads Folder
Public Function ReadPath(strPath As String, lvItem As ListView, stbMain As StatusBar, Optional Search As String)
    'On Error Resume Next
    
    'Declares Memory Values
    Dim objFiles As file
    Dim objFolders As Folder
    Dim objSubFolder As Folder
    Dim strFormat() As String
    Dim intA As Integer
      
    'Checks for Vaild Path
    If strPath = "" Or InStr(strPath, "::") <> 0 Then Exit Function
    
    Set objFolders = fso.GetFolder(strPath)
    
    'Clears Current Listview
    lvItem.ListItems.Clear
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Listing Directory, Please Wait..."
      
    'Writes New File Information to Listview
    For Each objFiles In objFolders.Files
        DoEvents
        
        'Checks if File Format is Supported
        strFormat = Split(VXCRSettings.strSFormats, ",")
        
        'Loops Through Each format
        For intA = 0 To UBound(strFormat)
            DoEvents
                  
            'Checks if Commands Canceled
            If CancelReadPath = True Then
                CancelReadPath = False
                Exit Function
            End If
            
            'If Format Found then Add
            If LCase(Right(objFiles.Name, 3)) = LCase(strFormat(intA)) Then
                                    
                 'Adds Files to listview GrabMP3Title
                 If VXCRSettings.intIDStuff <> 1 Then
                    
                    'Checks if ID Tag is MP3 Stream CheckVaildID
                    If CheckVaildID(GetId3(strPath & "\" & objFiles.Name)) = True Then
                        lvItem.ListItems.Add , , GetId3(strPath & "\" & objFiles.Name), , 9
                       Else
                        lvItem.ListItems.Add , , "E" & objFiles.Name, , 9
                    End If
                    
                   Else
                    lvItem.ListItems.Add , , objFiles.Name, , 9
                 End If
                 
                 'Checks if User Wants us to Show BitRate
                 If VXCRSettings.blnShwLBitRate = True Then
                 
                    'Checks if File Exists
                    If FileExists(strPath & "\" & objFiles.Name) = False Then Exit Function
        
                    'Sets Up Audio Drivers
                    Dim InitBass As Boolean
                    InitBass = BASS_Init(1, 44100, 0, frmMain.hWnd, 0)
    
                    'Frees Stream Channels
                    BASS_StreamFree chan
                    BASS_MusicFree chan
         
                    'Loads File and Plays but first checks format
                    If UCase(Right(strPath & "\" & objFiles.Name, Len(strPath & "\" & objFiles.Name) - InStr(1, strPath & "\" & objFiles.Name, "."))) <> "WMA" Then
                        
                        'Launches Regular Player
                        chan = BASS_StreamCreateFile(BASSFALSE, CStr(strPath & "\" & objFiles.Name), 0, 0, BASS_STREAM_AUTOFREE)
                        
                      Else
                          
                        'Launches WMA Player
                        chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(strPath & "\" & objFiles.Name), 0, 0, BASS_STREAM_AUTOFREE)
                        
                    End If
                    
                    'Adds BitRate
                    lvItem.ListItems(lvItem.ListItems.Count).SubItems(1) = Round((objFiles.Size / BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))) / 125) & "kbps"
                    
                 End If
                                              
                 'Gets File Size and Converts to KB etc
                 lvItem.ListItems(lvItem.ListItems.Count).SubItems(2) = DoConv(objFiles.Size)
                 lvItem.ListItems(lvItem.ListItems.Count).TaG = strPath & "\" & objFiles.Name
                                  
                 Exit For
            End If
        Next
    Next
    
    strLoc = strPath
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Ready"
    
End Function

Public Function CopyFile(strOrgFile As String, strDstFile As String)
                
    'Gets FreeFiles
    Dim intFF1, intFF2 As Integer
    intFF1 = FreeFile
    intFF2 = (intFF1 + 1)
                  
    'Declares Memory Units
    Dim strBuffer As String
    Dim lngFileLength As Long
                                                
    'Opens Orginal & New Data location
    Open strOrgFile For Binary As intFF1
    Open strDstFile For Binary As intFF2
                
    'Gets Orginal File Size
    lngFileLength = LOF(intFF1)
                
    'Sets New ProgessBar information
    frmMain.stbp.value = 0
                                
    'Reads Until (End of File)
    Do Until EOF(intFF1)
        DoEvents
                    
        'Updates ProgessBar
        frmMain.stbp.value = ((Loc(intFF1) / lngFileLength) * 100)
                    
        'Checks if Next Sectors will be last (1MB/grab)
        If (Loc(intFF1) + 10240) >= lngFileLength Then
            strBuffer = Space$(Int(lngFileLength - Loc(intFF1) + 1))
        Else
            strBuffer = Space$(10240)
        End If
                    
        'Reads then Writes Info
        Get #intFF1, , strBuffer
        Put #intFF2, , strBuffer
                                      
    Loop
                     
    'Closes Opened Files
    Close intFF1
    Close intFF2
    
End Function

Public Sub ThrowError(ByVal Message As String, Optional ByVal ErrorNum As Long = -1)
    
    'Display error dialogues
    If ErrorNum <> -1 Then
        Message = Message & vbCrLf & vbCrLf & "Error Code : " & ErrorNum
    End If
    
    MsgBox Message, vbOKOnly Or vbCritical, "Error"
End Sub

'Converts Bytes to KB, etc
Public Function DoConv(ByVal DC As String)
    On Error GoTo Errors:
    
    'Declares Memory Values
    Dim NType As Integer
    Dim CType() As String
    
    'Loads Size Array
    CType = Split("B,KB,MB,GB,TB,PB,EB,ZB,YB", ",")
    
    'Finds Proper Format
    Do Until DC < 1024
        
        DC = DC / 1024
        NType = NType + 1
    Loop
    
    'European Size Issue Fix
    If InStr(DC, ".") Then DC = Format(DC, "#.0#")
    If InStr(DC, ",") Then DC = Format(DC, "#.0#")
    
    'Returns Values
    DoConv = DC & " " & CType(NType)
    
    Exit Function
Errors:
    DoConv = DC  'Error Set to origional num
End Function


Public Function RPP(ByVal fp As String) As String
    RPP = IIf(Mid(fp, Len(fp), 1) <> "\", fp & "\", fp)
End Function

'Checks If File Exists
Public Function FileExists(ByVal Filename As String) As Boolean
    On Local Error Resume Next
    
    'Checks if file Exists
    FileExists = (Dir$(Filename) <> "")
    
End Function

'Checks if Folder Exisits
Public Function fFolderExists(ByVal FolderLoc As String) As Boolean
    fFolderExists = (Dir(FolderLoc, vbDirectory) <> "")
End Function

'Creates A Random File
Public Function RandomFile() As String
    
    'Declares Memory Units
    Dim strFile As String
    Dim intLength As Integer
    Dim intA As Integer
    Dim intRandom As Integer
    
    'Randomize Engine
    Randomize
    
    'Creates Random File Name (1 - 25 Letters Long)
    intLength = Int(Rnd * 24) + 1
    
    For intA = 1 To intLength
        DoEvents
        
        'Randomize Engine
        Randomize
        
        Do Until intRandom >= 65 Or intRandom >= 90
        
            'Creates Random File
            intRandom = Int(Rnd * 90) + 1
            
            DoEvents
        Loop
        
        'Creates RandomName
        strFile = strFile & Chr(intRandom)
        
        intRandom = 0
        
    Next intA
    
    'Sets File Extension
    strFile = strFile & ".VXCR"
        RandomFile = strFile
    
End Function


