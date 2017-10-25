Attribute VB_Name = "modCDDB"
'---------------------------------------
'Description:   Allows CDDB Access
'Created by:    BlueCELL
'Date:          March 21, 2004
'Started:       March 21, 2004 4.10 PM EST
'Finished:      NA
'---------------------------------------

'CD Structure (Used for Generating CD-ID)
Public Type TableOfContent
    lngMin As Long
    lngSec As Long
    lngFram As Long
    lngOffSet As Long
End Type

'Declares Memory Variables
Global CDToc() As TableOfContent
Global intTotalR As Integer
Global strA As String * 40

'Libary Calls (MCI - "Multimedia Control Interface")
Public Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Long, ByVal lpstrBuffer As String, ByVal uLength As Long) As Long
Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

'Returns Errors from MCI
Public Function SendMCIString(cmd As String, fShowError As Boolean) As Boolean

    'Declares Static Varibles
    Static lngRC As Long
    Static strError As String * 200
    
    'Grabs MCI Handle
    lngRC = mciSendString(cmd, 0, 0, hWnd)
    
    'Checks for MCI Errors
    If (fShowError And lngRC <> 0) Then
    
        'Reads Error String
        mciGetErrorString lngRC, strError, Len(strError)
        
        'Displays Error(s) Message
        MsgBox strError
    End If
    
    'Returns 0
    SendMCIString = (lngRC = 0)

End Function

'Reads CD Table Of Content (TOC)
Public Function ReadCDToc() As Integer
   
    'Requests Track Count
    mciSendString "status cd69 number of tracks wait", strA, Len(strA), 0
    
    'Gets Total Number into Memory
    intTotalR = CInt(Mid$(strA, 1, 2))
    
    'Resizes CDToc to SoundTrack Count
    ReDim CDToc(intTotalR + 1) As TableOfContent
    
    'Requests Output Format
    mciSendString "set cd69 time format msf", 0, 0, 0
    
    'Loops through Each Track
    For i = 1 To intTotalR
    
        'Returns Status of CD
        cmd = "status cd69 position track " & i
        mciSendString cmd, strA, Len(strA), 0
        
        'Places Data into Memory Structor
        CDToc(i - 1).lngMin = CInt(Mid$(strA, 1, 2))
        CDToc(i - 1).lngSec = CInt(Mid$(strA, 4, 2))
        CDToc(i - 1).lngFram = CInt(Mid$(strA, 7, 2))
        CDToc(i - 1).lngOffSet = (CDToc(i - 1).lngMin * 60 * 75) + (CDToc(i - 1).lngSec * 75) + CDToc(i - 1).lngFram
    Next

End Function

'This Code Gets The CD ID.
Public Function CDDBDiscId() As String

    'Declares Memory Units
    Dim lngA As Long
    Dim lngB As Long
    Dim lngC As Long
    Dim lngD As Long
    Dim lngTrackC As Long
    
    'Gets Number of Tracks
    ReadCDToc
    lngTrackC = intTotalR
    
    'Closes ALL CD Drives
    mciSendString "close all", 0, 0, 0
    
    'Checks for Error
    If (SendMCIString("open cdaudio alias cd69 wait shareable", True) = False) Then
        
        'Returns 0 for Error
        CDDBDiscId = 0
        Exit Function
    End If
    
    'Loops Through Track Count
    For lngC = 0 To lngTrackC - 1
        
        'Converts Length into Key
        lngB = ((CDToc(lngC).lngMin * 60) + CDToc(lngC).lngSec)
        
        'Sums up Key
        Do While lngB > 0
            lngA = lngA + (lngB Mod 10)
            lngB = lngB \ 10
        Loop
    Next
    
    'Requests Length
    mciSendString "status cd69 length wait", strA, Len(strA), 0
    lngD = (CInt(Mid$(strA, 1, 2)) * 60) + CInt(Mid$(strA, 4, 2))
    
    'Returns CD ID
    CDDBDiscId = LCase$(Zeros(Hex$(lngA Mod &HFF), 2) & Zeros(Hex$(lngD), 4) & Zeros(Hex$(lngTrackC), 2))

End Function

'Adds Zero(s) to Sent String
Private Function Zeros(strInput As String, intNumber As Integer) As String

    If Len(strInput) < intNumber Then
        Zeros = String$(intNumber - Len(strInput), "0") & strInput
    Else
        Zeros = strInput
    End If

End Function

