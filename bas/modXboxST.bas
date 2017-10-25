Attribute VB_Name = "modXboxST"
'---------------------------------------------------
'Xbox Sound Track Editor Module 1.00 (CONFIDUENTUAL)
'
'Created by: BlueCELL & XBOX War3z
'Date: Feb 25, 2004 10:31AM
'---------------------------------------------------

'Magic Values
Const SOUNDTRACK_MAGIC = 136049
Const SONGGROUP_MAGIC = 200819

'Max Constants
Const MAX_SOUNDTRACK_COUNT = 100
Const MAX_SOUNDTRACK_NAME = 32 * 2 'Unicode
Const MAX_SONG_NAME = 32 * 2 'Unicode

'Definition of each soundtrack
Private Type SoundTrack
    lngMagic As Long 'always check for SOUNDTRACK_MAGIC
    lngID As Long
    lngSongCount As Long
    lngGroupId(0 To 83) As Long 'total of max 84*6 = 504 songs
    lngTotalTime As Long
    strName As String * MAX_SOUNDTRACK_NAME
    bytFiller(0 To 95) As Byte
End Type

'Definition of the header
Private Type SoundTrack_Header
    lngUnknown As Long 'always 1
    lngCount As Long
    lngNextId As Long
    lngID(0 To MAX_SOUNDTRACK_COUNT - 1) As Long
    lngNextSongId As Long
    bytFiller(0 To 95) As Byte
    stSoundtracks(0 To MAX_SOUNDTRACK_COUNT - 1) As SoundTrack
End Type

Private Type SongGroup
    lngMagic As Long 'always SONGGROUP_MAGIC
    lngSoundtrackId As Long
    lngGroupId As Long
    lngUnknown As Long 'always 1
    lngFileName(0 To 5) As Long 'use sprintf(somechar, "%08X.wma", filename[x]);
    lngSongTime(0 To 5) As Long
    strSongName(0 To 5) As String * MAX_SONG_NAME
    bytFiller(0 To 63) As Byte
End Type

Private ff As Integer 'File pointer for st.db file
Private Header As SoundTrack_Header
Private SongGroups() As SongGroup
Private SongGroupNo(100) As Integer
Private blnIni As Boolean

Public Function Initialize(STFileLoc As String) As Boolean
    
    'Declares Memory Varibles
    Dim lngA As Long
    Dim lngB As Long
    
    'On Error GoTo ErrHandler
    
    ff = FreeFile
    Initialize = True
    ReDim SongGroups(0)
    
    'Opens ST.DB File
    Open frmMain.strSTDBLoc For Binary Access Read As #ff
    Get #ff, 1, Header
    
    'Read first songgroup
    Get #ff, , SongGroups(0)
    
    'Read all the other songgroups
    While Not EOF(ff)
    
        'Add one element to the array
        ReDim Preserve SongGroups(UBound(SongGroups) + 1)
        Get #ff, , SongGroups(UBound(SongGroups))
    Wend
    
    'Closes Open File
    Close #ff
    
    lngB = 0
    
    'Writes SongGroupNo Table (0 - 5)
    For lngA = 1 To 100
        DoEvents
        
        SongGroupNo(lngA) = lngB
        lngB = lngB + 1
        
        If lngB = 6 Then lngB = 0
        
    Next lngA
    
    'Tells other functions that We Loaded File
    blnIni = True
        
    Exit Function
    
ErrHandler:
    Debug.Print Err.Description
    Initialize = False
    
End Function

Public Function SaveST() As Boolean
    'On Error GoTo ErrHnd
    
    'Declares Memory Varibles
    Dim intFF As Integer
    Dim lngA As Long
    
    intFF = FreeFile
    
    'Opens Local ST.DB File (Diffrent File Name)
    Open frmMain.strSTDBLoc For Binary As #intFF
    
    'Writes Header to file
    Put #intFF, , Header
    
    For lngA = 0 To UBound(SongGroups)
        DoEvents
        
        'Writes Data to file
        Put #intFF, , SongGroups(lngA)
    Next
    
    'Closes Open File
    Close #intFF
    
    Exit Function
    
End Function

Public Function TerminateST()  'strSTDBLoc
    
    'Declares Memory Varibles
    Dim intFF As Integer
    Dim lngA As Long
    
    intFF = FreeFile
    
    'Opens Local ST.DB File (Diffrent File Name)
    Open frmMain.strSTDBLoc For Binary As #intFF
    
    'Writes Header to file
    Put #intFF, , Header
    
    For lngA = 0 To UBound(SongGroups)
        DoEvents
        
        'Writes Data to file
        Put #intFF, , SongGroups(lngA)
    Next
    
    'Closes Open File
    Close #intFF
    
    'Tells Us that we terminated ST Manager
    blnIni = False
    
End Function

Public Function AddSong(strSongTitle As String, strPath As String, strTimeSeconds As String, lngSoundTrack As Long) As String
     
    'Declares Memory Varibles
    Dim strOutputfile As String         'Audio File Xbox will use
    Dim lngSoundGroup As Long           'Which SongGroup to Write Song Too
    Dim lngSoundGroupArray As Long      'Keeps SongGroup(X) << X = (0 - 83)
    Dim lngStCount As Long              'Keeps SoundTrack Count (from header)
            
    'Finds Xbox FileName (first 4 Characters is Folder Name)
    strOutputfile = Right(Format("0000" & Hex(lngSoundTrack), "0000"), 4) & Right(Format("0000" & Hex(Header.lngNextSongId), "0000"), 4)
       
    'Increases NextSongID Varible
    Header.lngNextSongId = (Header.lngNextSongId + 1)
        
    'Finds SoundTrack Song Count
    lngStCount = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount
       
    'Checks if we need to create new SongGroup
    If InStr(1, (lngStCount / 6), ".") Or (lngStCount / 6) = 0 Then

        'Sets Storing Location
        lngSoundGroup = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngGroupId(RndUp_Dec(lngStCount / 6))
        lngSoundGroupArray = SongGroupNo(lngStCount + 1)
     
      Else
        
        'Declares More Variables
        Dim lngFreeSongGroup As Long
        
        'Finds Free SongGroup
        lngFreeSongGroup = FindFreeSongGroup
        
        'Need to Create New SongGroup
        lngSoundGroup = (lngStCount / 6)            'GROUPID, for Header
        
        'Sets up Header for utilizing new SongGroup
        Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngGroupId(lngSoundGroup) = lngFreeSongGroup
        
        'Sets up new SongGroup
        SongGroups(lngFreeSongGroup).lngSoundtrackId = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngID
        SongGroups(lngFreeSongGroup).lngMagic = SONGGROUP_MAGIC
        SongGroups(lngFreeSongGroup).lngUnknown = 1
        SongGroups(lngFreeSongGroup).lngGroupId = lngSoundGroup
            
        'Sets Additional Information
        lngSoundGroup = lngFreeSongGroup
        lngSoundGroupArray = SongGroupNo(lngStCount + 1)
        
    End If
    
    'Returns Output File
    AddSong = strOutputfile
        
    'Checks if 500(max) songs are used
    If lngStCount >= 500 Then
        
        AddSong = "ERR: MAXED OUT"
        Exit Function
    End If
          
    'Checks Name Length (No Bigger than 32)
    If Len(strSongTitle) > 32 Then
        strSongTitle = Left(strSongTitle, 32)
    End If
    
    'Writes Data
    SongGroups(lngSoundGroup).lngFileName(lngSoundGroupArray) = Val("&H" & strOutputfile)
    SongGroups(lngSoundGroup).lngSongTime(lngSoundGroupArray) = (strTimeSeconds * 1000)
    SongGroups(lngSoundGroup).strSongName(lngSoundGroupArray) = StrConv(strSongTitle, vbUnicode) & String(MAX_SOUNDTRACK_NAME - Len(StrConv(strSongTitle, vbUnicode)), Chr(0))

    'Increases SoundTrack Count
    Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount = (Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount + 1)
                   
    'Increases Header Total Time
    Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngTotalTime = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngTotalTime + (strTimeSeconds * 1000)
    
End Function


Public Function AddSoundTrack(strSoundTrackName As String, Optional tvSoundTracks As TreeView)
    'On Error Resume Next
    
    'Declares Memory Variables
    Dim lngFreeSG As Long
    
    'Finds Free SongGroup
    lngFreeSG = FindFreeSongGroup
    
    'Checks if theres a SoundTrackName
    If strSoundTrackName = "" Then Exit Function
    
    'Increases Nessarcy Data Types
    Header.lngCount = Header.lngCount + 1   'Track Count (0-99)
    Header.lngNextId = Header.lngNextId + 1 'Next SoundTrack ID
    
    'Adds New SoundTrack to Database
    Header.stSoundtracks(Header.lngCount - 1).strName = StrConv(strSoundTrackName, vbUnicode) & String(MAX_SOUNDTRACK_NAME - Len(StrConv(strSoundTrackName, vbUnicode)), Chr(0))
    Header.stSoundtracks(Header.lngCount - 1).lngID = (Header.lngNextId - 1)
    Header.stSoundtracks(Header.lngCount - 1).lngSongCount = 0
    Header.stSoundtracks(Header.lngCount - 1).lngTotalTime = 0
    Header.stSoundtracks(Header.lngCount - 1).lngMagic = SOUNDTRACK_MAGIC
    Header.stSoundtracks(Header.lngCount - 1).lngGroupId(0) = lngFreeSG
    
    'Checks if we need to create another Array Element
    If UBound(SongGroups) < Header.lngNextId Then
                
        'Create New Array Element
        ReDim Preserve SongGroups(UBound(SongGroups) + 1)
                
    End If
            
    'Adds Header lngID
    Header.lngID(Header.lngCount - 1) = (Header.lngNextId - 1)
   
    'ORGINAL
    SongGroups(lngFreeSG).lngGroupId = 0 'Header.stSoundtracks(Header.lngCount - 1).lngGroupId(0)
    SongGroups(lngFreeSG).lngMagic = SONGGROUP_MAGIC
    SongGroups(lngFreeSG).lngUnknown = 1
    SongGroups(lngFreeSG).lngSoundtrackId = (Header.lngNextId - 1)

    'Fixes Header
    Header.lngID(Header.lngCount - 1) = (Header.lngNextId - 1)
    
    'Adds Item to Listview
    tvSoundTracks.Nodes.Add "XB", tvwChild, "#" & (Header.lngNextId - 1), strSoundTrackName, 4
    
    'Selects Created SoundTrack
    tvSoundTracks.Nodes(tvSoundTracks.Nodes.Count).Selected = True
    
End Function

Public Function ReadSoundTracks(tvSoundTracks As TreeView)
'    On Error Resume Next
    
    'Declares Memory Units
    Dim strName As String
    Dim lngA As Long
       
    'Resets Xbox Treeview
    tvSoundTracks.Nodes.Clear
    tvSoundTracks.Nodes.Add , , "XB", "Xbox Sound Tracks", 14
    tvSoundTracks.Nodes("XB").Expanded = True

    'Loops Through ALL SoundTracks
    For lngA = 0 To Header.lngCount - 1
    
        'Grabs SoundTrackNames & Removes NULLs
        strName = FixName(Header.stSoundtracks(lngA).strName)
        
        'Adds Item to Treeview
        tvSoundTracks.Nodes.Add "XB", tvwChild, "#" & Header.stSoundtracks(lngA).lngID, strName, 4
               
    Next lngA
        
End Function

Public Function SoundTrackDetail(SoundTrack As Long, lvItem As ListView)
    
    'Declares Memory Varibles
    Dim lngB As Long
    Dim lngStCount As Long
    Dim lngTotalAdded As Long
    
    'Default Values
    lngTotalAdded = 0
    
    'Clears Listview Up
    lvItem.ListItems.Clear
    
    'Finds SoundTrack Song Count
    lngStCount = Header.stSoundtracks(FindHeaderfromID(SoundTrack)).lngSongCount
            
    'Loops through Each SongGroups
    For lngB = 0 To UBound(SongGroups)
    
        'Checks SoundTrack ID
        If SoundTrack = SongGroups(lngB).lngSoundtrackId Then
                    
            'Loops through each Group
            For i = 0 To 5
                
                'Checks if we added all REAL info
                If lngTotalAdded = lngStCount Then
                    Exit For
                End If
                
                'Increases Counter (That Way We Dont Read Old Info)
                lngTotalAdded = lngTotalAdded + 1
                
                'Checks for String in SongName
                If Len(FixName(SongGroups(lngB).strSongName(i))) > 0 Then
                              
                    'Lists Data on Listview
                    lvItem.ListItems.Add , , FixName(SongGroups(lngB).strSongName(i))
                    lvItem.ListItems(lvItem.ListItems.Count).SubItems(2) = Format("000" & Hex(SongGroups(lngB).lngFileName(i)), "00000000") & ".wma"
                    lvItem.ListItems(lvItem.ListItems.Count).SubItems(1) = ConvertMillisecondsToTime(SongGroups(lngB).lngSongTime(i))
                                       
                End If
                                
            Next
        End If
    Next
    
End Function

Public Function DeleteSoundTrack(HeaderID As Long)

    'Declares Memory Varibles
    Dim lngA As Long
    Dim lngDeleteArray As Long
    Dim lngLastUsedArray As Long
    
    'Finds Header Item which Needs to be Deleted
    lngDeleteArray = FindHeaderfromID(HeaderID)
    lngLastUsedArray = Header.lngCount - 1
    
    'Decreases SoundTrack Counts
    Header.lngCount = Header.lngCount - 1
    
    'Shifts Last item to Deleted Position
    
    'Filler
    For lngA = 0 To 95
        Header.stSoundtracks(lngDeleteArray).bytFiller(lngA) = Header.stSoundtracks(lngLastUsedArray).bytFiller(lngA)
    Next lngA
    
    'GroupID
    For lngA = 0 To 83
        Header.stSoundtracks(lngDeleteArray).lngGroupId(lngA) = Header.stSoundtracks(lngLastUsedArray).lngGroupId(lngA)
    Next lngA
        
    'lngID
    Header.stSoundtracks(lngDeleteArray).lngID = Header.stSoundtracks(lngLastUsedArray).lngID
    
    'Magic
    Header.stSoundtracks(lngDeleteArray).lngMagic = Header.stSoundtracks(lngLastUsedArray).lngMagic
    
    'SongCount
    Header.stSoundtracks(lngDeleteArray).lngSongCount = Header.stSoundtracks(lngLastUsedArray).lngSongCount
    
    'Total Time
    Header.stSoundtracks(lngDeleteArray).lngTotalTime = Header.stSoundtracks(lngLastUsedArray).lngTotalTime
    
    'SoundTrack Name (Unicode)
    Header.stSoundtracks(lngDeleteArray).strName = Header.stSoundtracks(lngLastUsedArray).strName
    
    'Updates LngID
    Header.lngID(lngDeleteArray) = Header.lngID(lngLastUsedArray)
    
End Function
Public Function FindHeaderfromID(lngID As Long)
    
    'Declares Memory Varibles
    Dim lngB As Long
        
    'Sets None Value
    FindHeaderfromID = 9999
    
    'Finds SoundTrack Song Count
    For lngB = 0 To Header.lngCount - 1
        DoEvents
        
        'If Similiar ID's found
        If Header.stSoundtracks(lngB).lngID = lngID Then
            
            'Writes HeaderST to Memory
            FindHeaderfromID = lngB
            
            Exit For
        End If
      
    Next lngB
End Function
Public Function FindFreeSongGroup() As Integer
    
    'Checks if We initilized ST Manager
    'If blnIni <> True Then Exit Function
    
    'Declares Memory Variables
    Dim lngA As Long                'Loops through SOUNDTRACKS
    Dim lngB As Long                'Loops through GROUPID
    Dim strUsed As String           'Holds Used SongGroups
    Dim strA() As String
    Dim blnFound As Boolean
    
    'Loops Though each SoundTrack
    For lngA = 0 To (Header.lngCount - 1)
        For lngB = 0 To RndUp_Dec(Header.stSoundtracks(lngA).lngSongCount / 6)
            
            'Adds Used SongGroups
            strUsed = strUsed & " " & Header.stSoundtracks(lngA).lngGroupId(lngB)
            
        Next lngB
    Next lngA
    
    'Delimits Data
    strA = Split(strUsed, " ")
    
    'Scans for Free Song Group
    For lngA = 0 To UBound(SongGroups)
        
        For lngB = 1 To UBound(strA)
            
            'Checks if SongGroup (LngA) is used
            If lngA = CLng(strA(lngB)) Then
                
                'Items Found, So we cant use it
                GoTo NextItem
                
            End If
        Next lngB
        
        'Items not used, so use it
        FindFreeSongGroup = lngA
        Exit Function
        
NextItem:
        
    Next lngA
    
    'Resizes Array
    ReDim Preserve SongGroups(UBound(SongGroups) + 1)
    
    'Returns New Array
    FindFreeSongGroup = UBound(SongGroups)
    
End Function

Public Function ConvertMillisecondsToTime(Milliseconds As Long) As String
    
    'Declares Memory Varibles
    Dim CurrentHSecs As Double
    Dim HSecs As Long
    Dim Mins As Long
    Dim Secs As Long
    Dim Hours As Double
    
    CurrentHSecs = Int((Milliseconds / 10) + 0.5)

    'Converts Stuff
    Mins = Int(CurrentHSecs / 6000)
    CurrentHSecs = CurrentHSecs - (Mins * 6000)
    Secs = Int((CurrentHSecs) / 100)
    CurrentHSecs = CurrentHSecs - (Secs * 100)
    HSecs = CurrentHSecs
    
    'Returns Information
    ConvertMillisecondsToTime = Format(Mins, "00") & ":" & Format(Secs, "00")


End Function

Public Function ConvertTimeToMilliseconds(TimeString As String, Optional IncludeHours As Boolean) As Long
        
    'Declares Varibles
    Dim i As Integer
    Dim Mins As Long
    Dim Secs As Long
    Dim HSecs As Long
    Dim Hours As Long
    Dim CurrentString As String
    Dim CurrentChar As String
    
    'Checks if theres Vaild String
    If TimeString = vbNullString Then Exit Function
    
    'Sets Default Values
    Hours = -1
    Mins = -1
    Secs = -1
    HSecs = -1
    
    'Sets Storage to NULL (Nothing)
    CurrentString = vbNullString

    'Loops through Time String
    For i = 1 To Len(TimeString)
    
        'Grabs One Character
        CurrentChar = Mid$(TimeString, i, 1)

        'Checks if : or Nothing
        If CurrentChar <> ":" And CurrentChar <> vbNullChar Then
            CurrentString = CurrentString & CurrentChar
        End If

        If CurrentChar = ":" Or CurrentChar = vbNullChar Or i = Len(TimeString) Then

            If IncludeHours And Hours = -1 Then
                Hours = CLng(Val(CurrentString))
                CurrentString = vbNullString
            ElseIf Mins = -1 Then
                Mins = CLng(Val(CurrentString))
                CurrentString = vbNullString
            ElseIf Secs = -1 Then
                Secs = CLng(Val(CurrentString))
                CurrentString = vbNullString
            ElseIf HSecs = -1 Then
                HSecs = CLng(Val(CurrentString))
                Exit For
            End If
        End If
        
    Next i
    
    'Returns Info
    ConvertTimeToMilliseconds = (HSecs * 10) + (Secs * 1000) + (Mins * 60000) + (Hours * 3600000)
End Function

Public Function FixName(ByVal StrUnicode As String) As String

    'Declare variables
    Dim lngA As Long
    
    'Find double 00 character
    lngA = InStr(StrUnicode, Chr(0) & Chr(0))
    
    If lngA > 0 Then
        StrUnicode = Mid(StrUnicode, 1, lngA - 1)
    End If
    
    'Remove other 00 chracters
    StrUnicode = Replace(StrUnicode, Chr(0), "")
    
    'Return the found string
    FixName = StrUnicode
    
End Function

Public Function chk4Decimal(strInput As String) As Integer
    
    'Checks for Decimals
    If InStr(1, strInput, ".") Then
        
        'Returns 1
        chk4Decimal = 1
      Else
        
        'Returns 0
        chk4Decimal = 0
    End If
    
End Function

Public Function RndUp_Dec(strInput As String) As Integer

    'Declares Memory Variables
    Dim intOut As Integer
    Dim strA() As String
    
    'Sets Default Value
    intOut = CInt(strInput)
    
    'Checks if Decimal Found
    If InStr(1, strInput, ".") Then
        
        'Sets Output Value w/ Dec Droped
        strA = Split(strInput, ".")
        
        intOut = (Int(strA(0)))
    End If
    
    'Returns Item
    RndUp_Dec = intOut
End Function
