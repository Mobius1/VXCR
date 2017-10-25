Attribute VB_Name = "modBassWMA"

' BASSWMA 2.0 Visual Basic API Header File
' Requires BASS.DLL & BASS.BAS 2.0 - available @ www.un4seen.com
' --------------------------------------------------------------
' See the BASSWMA.CHM file for more complete documentation

' Additional error codes returned by BASS_ErrorGetCode
Global Const BASS_ERROR_WMA_LICENSE = 1000     ' the file is protected
Global Const BASS_ERROR_WMA_WM9 = 1001         ' WM9 is required
Global Const BASS_ERROR_WMA_DENIED = 1002      ' access denied (user/pass is invalid)
Global Const BASS_ERROR_WMA_CODEC = 1003       ' no appropriate codec is installed

' Additional flags for use with BASS_WMA_EncodeOpenFile/Network
Global Const BASS_WMA_ENCODE_TAGS = &H10000    ' set tags in the WMA encoding
Global Const BASS_WMA_ENCODE_SCRIPT = &H20000  ' set script (mid-stream tags) in the WMA encoding

' Additional flag for use with BASS_WMA_EncodeGetRates
Global Const BASS_WMA_ENCODE_RATES_VBR = &H10000 ' get available VBR quality settings

' WMENCODEPROC "type" values
Global Const BASS_WMA_ENCODE_HEAD = 0
Global Const BASS_WMA_ENCODE_DATA = 1
Global Const BASS_WMA_ENCODE_DONE = 2

' BASS_CHANNELINFO type
Global Const BASS_CTYPE_STREAM_WMA = &H10300


Declare Function BASS_WMA_StreamCreateFile Lib "basswma.dll" (ByVal mem As Long, ByVal file As Any, ByVal offset As Long, ByVal length As Long, ByVal flags As Long) As Long
Declare Function BASS_WMA_GetIWMReader Lib "basswma.dll" (ByVal handle As Long) As Long

Declare Function BASS_WMA_EncodeGetRates Lib "basswma.dll" (ByVal freq As Long, ByVal flags As Long) As Long
Declare Function BASS_WMA_EncodeOpen Lib "basswma.dll" (ByVal freq As Long, ByVal flags As Long, ByVal bitrate As Long, ByVal proc As Long, ByVal user As Long) As Long
Declare Function BASS_WMA_EncodeOpenFile Lib "basswma.dll" (ByVal freq As Long, ByVal flags As Long, ByVal bitrate As Long, ByVal file As String) As Long
Declare Function BASS_WMA_EncodeOpenNetwork Lib "basswma.dll" (ByVal freq As Long, ByVal flags As Long, ByVal bitrate As Long, ByVal port As Long, ByVal clients As Long) As Long
Declare Function BASS_WMA_EncodeOpenPublish Lib "basswma.dll" (ByVal freq As Long, ByVal flags As Long, ByVal bitrate As Long, ByVal url As String, ByVal user As String, ByVal pass As String) As Long
Declare Function BASS_WMA_EncodeGetPort Lib "basswma.dll" (ByVal handle As Long) As Long
Declare Function BASS_WMA_EncodeSetNotify Lib "basswma.dll" (ByVal handle As Long, ByVal proc As Long, ByVal user As Long) As Long
Declare Function BASS_WMA_EncodeGetClients Lib "basswma.dll" (ByVal handle As Long) As Long
Declare Function BASS_WMA_EncodeSetTag Lib "basswma.dll" (ByVal handle As Long, ByVal tag As String, ByVal text As String) As Long
Declare Function BASS_WMA_EncodeWrite Lib "basswma.dll" (ByVal handle As Long, ByVal buffer As Long, ByVal length As Long) As Long
Declare Sub BASS_WMA_EncodeClose Lib "basswma.dll" (ByVal handle As Long)


Sub CLIENTCONNECTPROC(ByVal handle As Long, ByVal connect As Long, ByVal ip As Long, ByVal user As Long)

    'CALLBACK FUNCTION !!!

    ' Client connection notification callback function.
    ' handle : The encoder
    ' connect: TRUE=client is connecting, FALSE=disconnecting
    ' ip     : The client's IP (xxx.xxx.xxx.xxx:port)
    ' user   : The 'user' parameter value given when calling BASS_EncodeSetNotify

End Sub

Sub WMENCODEPROC(ByVal handle As Long, ByVal dtype As Long, ByVal buffer As Long, ByVal length As Long, ByVal user As Long)

    'CALLBACK FUNCTION !!!

    ' Encoder callback function.
    ' handle : The encoder handle
    ' dtype  : The type of data, one of BASS_WMA_ENCODE_xxx values
    ' buffer : The encoded data
    ' length : Length of the data
    ' user   : The 'user' parameter value given when calling BASS_WMA_EncodeOpen

End Sub
Public Sub LoadWMAEncoderRates(cmbBitRate As ComboBox)
    On Error GoTo Err_Init

    Dim ratesPTR        As Long    'a pointer to a memory location where rates array is stored
    Dim aryEncRates(0)  As Long
    Dim strEncodeRate   As String

    'Grabs BitRate From Memory
    ratesPTR = BASS_WMA_EncodeGetRates(44100, 0&)

    'Make sure we got a Pointer.
    If (ratesPTR = 0) Then
        Call ThrowError("Error: Can't find a codec", BASS_ErrorGetCode)
        Exit Sub
    Else
        'Move Pointer into Buffer
        Call CopyMemory(aryEncRates(0), ByVal ratesPTR, LenB(ratesPTR))
        
        'Make sure we have a valid bitrate.
        While aryEncRates(0) <> 0
            
            'Add to List
            cmbBitRate.AddItem Format(CLng(aryEncRates(0) / 1000), "###,##0 Kbps")
            cmbBitRate.ItemData(cmbBitRate.NewIndex) = CLng(aryEncRates(0))
            
            'INCR to find next bitrate
            ratesPTR = ratesPTR + LenB(ratesPTR)
            
            'Move Pointer into Buffer
            Call CopyMemory(aryEncRates(0), ByVal ratesPTR, LenB(ratesPTR))
            
        Wend
    
    End If
    
No_Err:
    'Select the first item.
    If cmbBitRate.ListCount > 0 Then cmbBitRate.ListIndex = 0

ExitRoutine:
    Exit Sub

Err_Init:
    'HandleError strCurrentModule, "LoadWMAEncoderRates", Err.Number, Err.Description
    GoTo ExitRoutine:
End Sub

Private Sub ExtractAudioTrackToWMA(lTrack As Long, lngBitrate As Long)
    On Error GoTo Err_Init

    Dim flags As Long
    Dim pos As Long
    Dim lngWMAEncodeHandle As Long
    Dim strOutputFilename As String
    Dim lngReturn As Long
    Dim i As Long
    Dim lngTimer As Long

    'See how long it took
    lngTimer = Timer
    
    'Lock Drive
    Call BASS_CD_Door(lDriveID, BASS_CD_DOOR_LOCK)
    
    'Crate Stream for decoding
    lCDTrackHandle = BASS_CD_StreamCreate(lDriveID, lTrack, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
    
    If lCDTrackHandle = 0 Then
    
        'Something went wrong
        Call ThrowError("Unable to Create CD Stream!", BASS_ErrorGetCode)
        GoTo ExitRoutine
    End If
    
    'Keep user from pressing any buttons
    'NOT the best way. Just Quick & Dirty.
    'Me.Enabled = False

    'Create the output filename
    strOutputFilename = RPP(App.Path) & "TRACK" & CStr(lTrack + 1) & ".WMA"

    'Open Output File
    'We Know the Freq will be 44100.
    lngWMAEncodeHandle = BASS_WMA_EncodeOpenFile(44100, BASS_WMA_ENCODE_TAGS, lngBitrate, strOutputFilename)
    
    'Exit if there was an error opening/creating the file
    If lngWMAEncodeHandle = 0 Then
    
        'Error
        Call ThrowError("An error occured while opening output file.", BASS_ErrorGetCode)
        Exit Sub
        
    End If
    
    If chkWMAFileTags.value = vbChecked Then
        
        'Populate Tags
        'For i = 0 To 7
        '    If txtWMATags(i) <> "" Then
        '        Call BASS_WMA_EncodeSetTag(lngWMAEncodeHandle, mvarWMATagNames(i), txtWMATags(i).text)
        '    End If
        'Next i
    End If
    
    'Close Tags
    'DO NOT REMOVE : Routine must be called even if there are NO Tags because we are using the BASS_WMA_ENCODE_TAGS flag
    Call BASS_WMA_EncodeSetTag(lngWMAEncodeHandle, "", "")
    
    'Buffer to hold data
    ReDim buf(19999) As Byte

    'Loop and read all the data
    Do While BASS_ChannelIsActive(lCDTrackHandle)
    
        'Get Some Data
        ReDim Preserve buf(BASS_ChannelGetData(lCDTrackHandle, buf(0), 20000) - 1) As Byte
        
        'Send Data to be Encoded
        lngReturn = BASS_WMA_EncodeWrite(lngWMAEncodeHandle, VarPtr(buf(0)), UBound(buf()) + 1)

        'Error ??
        If lngReturn = 0 Then
        
            'Error
            Call ThrowError("An error occured while encoding WMA data.", BASS_ErrorGetCode)
            Exit Do
            
        End If

        'Don't want to hog ALL the CPU :)
        DoEvents
        
    Loop

    'Close the Encoding Handle
    Call BASS_WMA_EncodeClose(lngWMAEncodeHandle)
    
    'MsgBox "WMA File Encoded. Encoding took " & Format$(Timer - lngTimer, "###.#") & " seconds.", vbOKOnly, "WMA Encoding"
    

ExitRoutine:
    'CleanUp
    Erase buf()
    
    'UnLock Drive
    Call BASS_CD_Door(lDriveID, BASS_CD_DOOR_UNLOCK)
    
    'Stop / Free the Decoding stream
    If lCDTrackHandle Then Call BASS_ChannelStop(lCDTrackHandle)
    If lCDTrackHandle Then Call BASS_StreamFree(lCDTrackHandle)
    
    'Stop / Free the Encoding stream
    If lngWMAEncodeHandle Then Call BASS_ChannelStop(lngWMAEncodeHandle)
    If lngWMAEncodeHandle Then Call BASS_StreamFree(lngWMAEncodeHandle)
    
    'Enable Form
    'Me.Enabled = True
    Exit Sub

Err_Init:
    'HandleError strCurrentModule, "ExtractAudioTrackToWMA", Err.Number, Err.Description
    GoTo ExitRoutine:

End Sub
