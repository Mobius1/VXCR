Attribute VB_Name = "modBASSEncoder"
' BASSenc 2.0 Visual Basic API Header File
' Requires BASS.DLL & BASS.BAS - available @ www.un4seen.com

' See the BASSENC.CHM file for more complete documentation


' BASS_Encode_Start flags
Global Const BASS_ENCODE_NOHEAD = 1        'do NOT send a WAV header to the encoder
Global Const BASS_ENCODE_FP_8BIT = 2   'convert floating-point sample data to 8-bit integer
Global Const BASS_ENCODE_FP_16BIT = 4  'convert floating-point sample data to 16-bit integer
Global Const BASS_ENCODE_FP_24BIT = 6  'convert floating-point sample data to 24-bit integer


Declare Function BASS_Encode_Start Lib "bassenc.dll" (ByVal chan As Long, ByVal cmdline As String, ByVal flags As Long, ByVal proc As Long, ByVal user As Long) As Long
Declare Function BASS_Encode_IsActive Lib "bassenc.dll" (ByVal chan As Long) As Long
Declare Function BASS_Encode_Stop Lib "bassenc.dll" (ByVal chan As Long) As Long
Declare Function BASS_Encode_SetPaused Lib "bassenc.dll" (ByVal chan As Long, ByVal paused As Long) As Long

Global buf() As Byte

Sub ENCODEPROC(ByVal channel As Long, ByVal buffer As Long, ByVal length As Long, ByVal user As Long)
    
    'CALLBACK FUNCTION !!!

    ' Encoding callback function.
    ' channel: The channel handle
    ' buffer : Buffer containing the encoded data
    ' length : Number of bytes
    ' user   : The 'user' parameter value given when calling BASS_EncodeStart
    
End Sub

'Converts Any format to WMA (Xbox Type)
Public Function ConvertToWMA(strOrginalFile As String, strOutputfile As String, lngBitRate As Long)
    On Error Resume Next
       
    'Declares Memory Units
    Dim lngWMAEncodeHandle As Long
    Dim lngFileMax As Long
    
    Dim flags               As Long
    Dim pos                 As Long
    'Dim lngWMAEncodeHandle  As Long
    Dim strOutputFilename   As String
    Dim lngReturn           As Long
    Dim i                   As Long
    
    'Reinitizlizes Decoding (BASS) engine
    BASS_ChannelStop (chan)
    BASS_StreamFree (chan)
    BASS_Free
    
    BASS_Init 1, 44100, 0, frmMain.hWnd, 0

    'Checks format then Loads Audio File
    If UCase(Right(strOrginalFile, Len(strOrginalFile) - InStr(1, strOrginalFile, "."))) <> "WMA" Then
                        
        'Uses Regular Player
        chan = BASS_StreamCreateFile(BASSFALSE, strOrginalFile, 0, 0, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
        
    Else
        'Uses WMA Player
        chan = BASS_WMA_StreamCreateFile(BASSFALSE, strOrginalFile, 0, 0, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
    End If
    
    'Checks if Smart Detector is Enabled
    If lngBitRate = 0 Then
        lngBitRate = Round((FileLen(strOrginalFile) / BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))) / 125) & "000"
        
    End If
    
    'Loads Encoding Engine
    lngWMAEncodeHandle = BASS_WMA_EncodeOpenFile(44100, BASS_WMA_ENCODE_TAGS, lngBitRate, strOutputfile)   '128Kb/s
    
    'Checks for Error
    If lngWMAEncodeHandle = 0 Then
        MsgBox "Encoding Engine failed to initilized, Please contact BlueCELL"
        Exit Function
    End If
    
    'Gets Length of Song (For Progress Display)
    lngFileMax = BASS_StreamGetLength(chan)
    
    'Sets Tag to Nothing
    Call BASS_WMA_EncodeSetTag(lngWMAEncodeHandle, "", "")
    ReDim buf(262144) As Byte '262144
    
    'Starts Encoding Data Stream
    Do While BASS_ChannelIsActive(chan)
    
        'Sizes/Encodes DataStream
        ReDim Preserve buf(BASS_ChannelGetData(chan, buf(0), 262144) - 1) As Byte
        lngReturn = BASS_WMA_EncodeWrite(lngWMAEncodeHandle, VarPtr(buf(0)), UBound(buf()) + 1)
        
        'Checks for Error
        If lngReturn = 0 Then
            Exit Do
        End If
        
        DoEvents
        
        'Finds Progress
        frmMain.stbp.value = (BASS_ChannelGetPosition(chan) / lngFileMax) * 100
            
    Loop
    
    'Closes Encoder
    Call BASS_WMA_EncodeClose(lngWMAEncodeHandle)
    
    'Releases Memory
    Erase buf()
    
End Function

