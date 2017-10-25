Attribute VB_Name = "modCDRipper"
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByRef Destination As Any, ByRef Source As Any, ByVal length As Long)
Public Declare Function lstrlen Lib "kernel32" Alias "lstrlenA" (ByVal lpString As Long) As Long

Public lngCDID As Long
Public strCDDrives As String

'Grabs List of CD Drives
Public Function ListCDDrives(stbMain As StatusBar)

    'Declares Memory Units
    Dim intA As Integer
    Dim strCDDrive As String
    Dim strDriveLetter As String
            
    'Sets Variable to First Possible CD Drive
    intA = 0
    
    'Clears Memory Drives
    strCDDrives = ""
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Search for CD Drives, Please Wait..."
    
    'Gets Drive Information
    strCDDrive = BASS_CD_GetDriveDescription(intA)
    
    'Loops Until No Drive is Detected
    Do Until strCDDrive = 0
        DoEvents
        
        'Get Drive Letter
        strDriveLetter = Chr(65 + BASS_CD_GetDriveLetter(intA))
                
        strCDDrives = strCDDrives & strDriveLetter
        
        'Get Next Drive
        intA = intA + 1
        strCDDrive = BASS_CD_GetDriveDescription(intA)
        
    Loop
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Ready"
        
End Function

Public Sub LoadTrackList(lvItem As ListView, stbMain As StatusBar)
    
    Dim lngA As Long
    Dim lngTrackCount As Long
    Dim lngTrackLength As Long
    Dim lngCDTextPtr As Long

    'Clear ListView
    lvItem.ListItems.Clear
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Loading CD Track List, Please Wait..."
    
    'Load Track List
    If BASS_CD_IsReady(lngCDID) Then
        
        'Get number of tracks
        lngTrackCount = BASS_CD_GetTracks(lngCDID)
        
        'Make sure there wasn't an error
        If lngTrackCount = -1 Then
            
            'Error
            MsgBox "Error retreiving number of tracks."
            
        Else
        
            'Get the CD-Text data from the CD
            lngCDTextPtr = BASS_CD_GetID(lngCDID, BASS_CDID_TEXT)
            
            'See if the CD has and CD-Text
            If lngCDTextPtr <> 0 Then
                
                'Use the CD-Text data to display a better track list
                Call LoadTrackListFromCDText(lngCDTextPtr, lngTrackCount)
                
            Else
                
                'Set the Artist / Album names
               ' txtCDArtist.text = "Unknown Artist"
               ' txtCDAlbum.text = "Unknown Album"
                
                'Populate list
                For lngA = 0 To lngTrackCount - 1
                    
                    'Get the length of the track in blocks
                    lngTrackLength = BASS_CD_GetTrackLength(lngCDID, lngA)
                    
                    'Make sure it's valid
                    If lngTrackLength > 0 Then
                        
                        'Convert to seconds
                        lngTrackLength = lngTrackLength / 176400
                        
                        'Add to track list
                        lvItem.ListItems.Add , , "Track " & CStr(lngA + 1), , 13
                        'lvitem.ListItems(lvitem.ListItems.Count).SubItems(1) = "Track " & CStr(lngA + 1)
                        lvItem.ListItems(lvItem.ListItems.Count).SubItems(2) = Seconds2HMS(lngTrackLength)
                        
                    Else
                        Call ThrowError("There was an error.", BASS_ErrorGetCode)
                    End If
                Next lngA
                
                
                'Grabs CD-ID
                frmMain.Caption = CDDBDiscId
                
                
            End If
            
        End If
        
    Else
    
    End If
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Ready"
End Sub

Public Sub LoadTrackListFromCDText(ByVal lngTagPtr As Long, ByVal lTrackCount As Long)
    On Error GoTo Err_Init

    'Declares Memory Values
    Dim strTag As String
    Dim i As Long
    Dim aryTitle() As String
    Dim aryPerformers() As String
    Dim lIndx As Long
    Dim lTrackLength As Long
    
    'To hold the track titles / artists
    ReDim aryTitle(lTrackCount) As String
    ReDim aryPerformers(lTrackCount) As String
    
    'Get First Tag
    strTag = VBStrFromAnsiPtr(lngTagPtr)
    
    'The last TAG will be a null CHR(0)
    While (strTag <> Chr(0)) And (strTag <> "")
        
        'Determine what to do with the text
        If UCase$(Left$(strTag, 5)) = "TITLE" Then
        
            'Updates Variables
            lIndx = CLng(Mid$(strTag, 6, InStr(strTag, "=") - 6))
            aryTitle(lIndx) = Mid$(strTag, InStr(strTag, "=") + 1)
            
        ElseIf UCase$(Left$(strTag, 9)) = "PERFORMER" Then
            
            'Updates Variables
            lIndx = CLng(Mid$(strTag, 10, InStr(strTag, "=") - 10))
            aryPerformers(lIndx) = Mid$(strTag, InStr(strTag, "=") + 1)
        
        End If
        
        'Move Pointer
        lngTagPtr = lngTagPtr + Len(strTag) + 1
        
        'Get Next Tag
        strTag = VBStrFromAnsiPtr(lngTagPtr)
    Wend
    
    'Set the CD Artist / Album names. Index 0 applies to the entire CD.
    txtCDArtist.text = aryPerformers(0)
    txtCDAlbum.text = aryTitle(0)
    
    'Now that we got all the usable tags. Lets display it in the Listbox
    For i = 0 To lTrackCount - 1
    
        'Get the length of the track in blocks
        lTrackLength = BASS_CD_GetTrackLength(lngCDID, i)
        
        'Make sure it's valid
        If lTrackLength > 0 Then
        
            'Convert to seconds
            lTrackLength = lTrackLength / 176400
            
            'Add to listbox formatted as [##] Performer / Title          [00:00]
            lstTracks.AddItem Format$(i + 1, "0#") & vbTab & aryPerformers(i + 1) & " / " & aryTitle(i + 1) & vbTab & "[" & Seconds2HMS(lTrackLength) & "]"
        End If
    Next
    
No_Err:

ExitRoutine:

    'Clean Up
    Erase aryTitle()
    Erase aryPerformers()
    
    Exit Sub

Err_Init:
    'HandleError strCurrentModule, "LoadTrackListFromCDText", Err.Number, Err.Description
    GoTo ExitRoutine:
End Sub

Public Function VBStrFromAnsiPtr(ByVal lpStr As Long) As String
    On Error Resume Next
    
    'Declares Memory Units
    Dim bytStr() As Byte
    Dim lngChars As Long

    'Get the number of characters in the buffer
    lngChars = lstrlen(lpStr)

    'Resize the byte array
    ReDim bytStr(0 To lngChars - 1) As Byte

    'Grab the ANSI buffer
    Call CopyMemory(bytStr(0), ByVal lpStr, lngChars)

    'Now convert to a VB Unicode string
    VBStrFromAnsiPtr = StrConv(bytStr, vbUnicode)
    
End Function

'Quick and Dirty routine to convert a value of seconds into a formatted hh:mm:ss string
Public Function Seconds2HMS(ByVal lngSeconds As Long) As String
    
    'Declares Memory Values
    Dim CurrentHSecs As Double
    Dim Hours As Double
    Dim Mins As Double
    Dim Secs As Double
    Dim HSecs As Double
    
    'Converts #s
    CurrentHSecs = Int((lngSeconds) + 0.5)
    Hours = Int(CurrentHSecs \ 3600)
    CurrentHSecs = CurrentHSecs - (Hours * 3600)
    Mins = Int(CurrentHSecs \ 60)
    CurrentHSecs = CurrentHSecs - (Mins * 60)
    Secs = CInt(CurrentHSecs)
    
    'Outputs Proper Format
    If Hours > 0 Then
        Seconds2HMS = Right("00" & Hours, 2) & ":" & Right("00" & Mins, 2) & ":" & Right("00" & Secs, 2)
    Else
        Seconds2HMS = Right("00" & Mins, 2) & ":" & Right("00" & Secs, 2) ' & "." & Right("00" & HSecs, 2)
    End If

End Function
