Option Strict Off
Option Explicit On
Module modBASSEncoder
	' BASSenc 2.0 Visual Basic API Header File
	' Requires BASS.DLL & BASS.BAS - available @ www.un4seen.com
	
	' See the BASSENC.CHM file for more complete documentation
	
	
	' BASS_Encode_Start flags
	Public Const BASS_ENCODE_NOHEAD As Short = 1 'do NOT send a WAV header to the encoder
	Public Const BASS_ENCODE_FP_8BIT As Short = 2 'convert floating-point sample data to 8-bit integer
	Public Const BASS_ENCODE_FP_16BIT As Short = 4 'convert floating-point sample data to 16-bit integer
	Public Const BASS_ENCODE_FP_24BIT As Short = 6 'convert floating-point sample data to 24-bit integer
	
	
	Declare Function BASS_Encode_Start Lib "bassenc.dll" (ByVal chan As Integer, ByVal cmdline As String, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Function BASS_Encode_IsActive Lib "bassenc.dll" (ByVal chan As Integer) As Integer
	Declare Function BASS_Encode_Stop Lib "bassenc.dll" (ByVal chan As Integer) As Integer
	Declare Function BASS_Encode_SetPaused Lib "bassenc.dll" (ByVal chan As Integer, ByVal paused As Integer) As Integer
	
	Public buf() As Byte
	
	Sub ENCODEPROC(ByVal channel As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		' Encoding callback function.
		' channel: The channel handle
		' buffer : Buffer containing the encoded data
		' length : Number of bytes
		' user   : The 'user' parameter value given when calling BASS_EncodeStart
		
	End Sub
	
	'Converts Any format to WMA (Xbox Type)
	Public Function ConvertToWMA(ByRef strOrginalFile As String, ByRef strOutputfile As String, ByRef lngBitRate As Integer) As Object
		Dim chan As Object
		On Error Resume Next
		
		'Declares Memory Units
		Dim lngWMAEncodeHandle As Integer
		Dim lngFileMax As Integer
		
		Dim flags As Integer
		Dim pos As Integer
		'Dim lngWMAEncodeHandle  As Long
		Dim strOutputFilename As String
		Dim lngReturn As Integer
		Dim i As Integer
		
		'Reinitizlizes Decoding (BASS) engine
		'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BASS_ChannelStop(chan)
		BASS_StreamFree((chan))
		BASS_Free()
		
		BASS_Init(1, 44100, 0, frmMain.Handle.ToInt32, 0)
		
		'Checks format then Loads Audio File
		If UCase(Right(strOrginalFile, Len(strOrginalFile) - InStr(1, strOrginalFile, "."))) <> "WMA" Then
			
			'Uses Regular Player
			'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			chan = BASS_StreamCreateFile(BASSFALSE, strOrginalFile, 0, 0, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
			
		Else
			'Uses WMA Player
			'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			chan = BASS_WMA_StreamCreateFile(BASSFALSE, strOrginalFile, 0, 0, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
		End If
		
		'Checks if Smart Detector is Enabled
		If lngBitRate = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lngBitRate = CInt(System.Math.Round((FileLen(strOrginalFile) / BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))) / 125) & "000")
			
		End If
		
		'Loads Encoding Engine
		lngWMAEncodeHandle = BASS_WMA_EncodeOpenFile(44100, BASS_WMA_ENCODE_TAGS, lngBitRate, strOutputfile) '128Kb/s
		
		'Checks for Error
		If lngWMAEncodeHandle = 0 Then
			MsgBox("Encoding Engine failed to initilized, Please contact BlueCELL")
			Exit Function
		End If
		
		'Gets Length of Song (For Progress Display)
		'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngFileMax = BASS_StreamGetLength(chan)
		
		'Sets Tag to Nothing
		Call BASS_WMA_EncodeSetTag(lngWMAEncodeHandle, "", "")
		ReDim buf(262144) '262144
		
		'Starts Encoding Data Stream
		'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do While BASS_ChannelIsActive(chan)
			
			'Sizes/Encodes DataStream
			'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ReDim Preserve buf(BASS_ChannelGetData(chan, buf(0), 262144) - 1)
			'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			lngReturn = BASS_WMA_EncodeWrite(lngWMAEncodeHandle, VarPtr(buf(0)), UBound(buf) + 1)
			
			'Checks for Error
			If lngReturn = 0 Then
				Exit Do
			End If
			
			System.Windows.Forms.Application.DoEvents()
			
			'Finds Progress
			'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmMain.stbp.Value = (BASS_ChannelGetPosition(chan) / lngFileMax) * 100
			
		Loop 
		
		'Closes Encoder
		Call BASS_WMA_EncodeClose(lngWMAEncodeHandle)
		
		'Releases Memory
		Erase buf
		
	End Function
End Module