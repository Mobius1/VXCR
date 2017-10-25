Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module modBassWMA
	
	' BASSWMA 2.0 Visual Basic API Header File
	' Requires BASS.DLL & BASS.BAS 2.0 - available @ www.un4seen.com
	' --------------------------------------------------------------
	' See the BASSWMA.CHM file for more complete documentation
	
	' Additional error codes returned by BASS_ErrorGetCode
	Public Const BASS_ERROR_WMA_LICENSE As Short = 1000 ' the file is protected
	Public Const BASS_ERROR_WMA_WM9 As Short = 1001 ' WM9 is required
	Public Const BASS_ERROR_WMA_DENIED As Short = 1002 ' access denied (user/pass is invalid)
	Public Const BASS_ERROR_WMA_CODEC As Short = 1003 ' no appropriate codec is installed
	
	' Additional flags for use with BASS_WMA_EncodeOpenFile/Network
	Public Const BASS_WMA_ENCODE_TAGS As Integer = &H10000 ' set tags in the WMA encoding
	Public Const BASS_WMA_ENCODE_SCRIPT As Integer = &H20000 ' set script (mid-stream tags) in the WMA encoding
	
	' Additional flag for use with BASS_WMA_EncodeGetRates
	Public Const BASS_WMA_ENCODE_RATES_VBR As Integer = &H10000 ' get available VBR quality settings
	
	' WMENCODEPROC "type" values
	Public Const BASS_WMA_ENCODE_HEAD As Short = 0
	Public Const BASS_WMA_ENCODE_DATA As Short = 1
	Public Const BASS_WMA_ENCODE_DONE As Short = 2
	
	' BASS_CHANNELINFO type
	Public Const BASS_CTYPE_STREAM_WMA As Integer = &H10300
	
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_WMA_StreamCreateFile Lib "basswma.dll" (ByVal mem As Integer, ByVal file As Any, ByVal offset As Integer, ByVal length As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_WMA_GetIWMReader Lib "basswma.dll" (ByVal handle As Integer) As Integer
	
	Declare Function BASS_WMA_EncodeGetRates Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_WMA_EncodeOpen Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Function BASS_WMA_EncodeOpenFile Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal file As String) As Integer
	Declare Function BASS_WMA_EncodeOpenNetwork Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal port As Integer, ByVal clients As Integer) As Integer
	Declare Function BASS_WMA_EncodeOpenPublish Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal url As String, ByVal user As String, ByVal pass As String) As Integer
	Declare Function BASS_WMA_EncodeGetPort Lib "basswma.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_WMA_EncodeSetNotify Lib "basswma.dll" (ByVal handle As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Function BASS_WMA_EncodeGetClients Lib "basswma.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_WMA_EncodeSetTag Lib "basswma.dll" (ByVal handle As Integer, ByVal tag As String, ByVal text As String) As Integer
	Declare Function BASS_WMA_EncodeWrite Lib "basswma.dll" (ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer) As Integer
	Declare Sub BASS_WMA_EncodeClose Lib "basswma.dll" (ByVal handle As Integer)
	
	
	Sub CLIENTCONNECTPROC(ByVal handle As Integer, ByVal connect As Integer, ByVal ip As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		' Client connection notification callback function.
		' handle : The encoder
		' connect: TRUE=client is connecting, FALSE=disconnecting
		' ip     : The client's IP (xxx.xxx.xxx.xxx:port)
		' user   : The 'user' parameter value given when calling BASS_EncodeSetNotify
		
	End Sub
	
	Sub WMENCODEPROC(ByVal handle As Integer, ByVal dtype As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		' Encoder callback function.
		' handle : The encoder handle
		' dtype  : The type of data, one of BASS_WMA_ENCODE_xxx values
		' buffer : The encoded data
		' length : Length of the data
		' user   : The 'user' parameter value given when calling BASS_WMA_EncodeOpen
		
	End Sub
	Public Sub LoadWMAEncoderRates(ByRef cmbBitRate As System.Windows.Forms.ComboBox)
		On Error GoTo Err_Init
		
		Dim ratesPTR As Integer 'a pointer to a memory location where rates array is stored
		Dim aryEncRates(0) As Integer
		Dim strEncodeRate As String
		
		'Grabs BitRate From Memory
		ratesPTR = BASS_WMA_EncodeGetRates(44100, 0)
		
		'Make sure we got a Pointer.
		If (ratesPTR = 0) Then
			Call ThrowError("Error: Can't find a codec", BASS_ErrorGetCode)
			Exit Sub
		Else
			'Move Pointer into Buffer
			'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			Call CopyMemory(aryEncRates(0), ratesPTR, LenB(ratesPTR))
			
			'Make sure we have a valid bitrate.
			While aryEncRates(0) <> 0
				
				'Add to List
				cmbBitRate.Items.Add(New VB6.ListBoxItem(VB6.Format(CInt(aryEncRates(0) / 1000), "###,##0 Kbps"), CInt(aryEncRates(0))))
				
				'INCR to find next bitrate
				'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				ratesPTR = ratesPTR + LenB(ratesPTR)
				
				'Move Pointer into Buffer
				'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				Call CopyMemory(aryEncRates(0), ratesPTR, LenB(ratesPTR))
				
			End While
			
		End If
		
No_Err: 
		'Select the first item.
		If cmbBitRate.Items.Count > 0 Then cmbBitRate.SelectedIndex = 0
		
ExitRoutine: 
		Exit Sub
		
Err_Init: 
		'HandleError strCurrentModule, "LoadWMAEncoderRates", Err.Number, Err.Description
		GoTo ExitRoutine
	End Sub
	
	Private Sub ExtractAudioTrackToWMA(ByRef lTrack As Integer, ByRef lngBitrate As Integer)
		Dim chkWMAFileTags As Object
		Dim lCDTrackHandle As Object
		Dim lDriveID As Object
		On Error GoTo Err_Init
		
		Dim flags As Integer
		Dim pos As Integer
		Dim lngWMAEncodeHandle As Integer
		Dim strOutputFilename As String
		Dim lngReturn As Integer
		Dim i As Integer
		Dim lngTimer As Integer
		
		'See how long it took
		lngTimer = VB.Timer()
		
		'Lock Drive
		'UPGRADE_WARNING: Couldn't resolve default property of object lDriveID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call BASS_CD_Door(lDriveID, BASS_CD_DOOR_LOCK)
		
		'Crate Stream for decoding
		'UPGRADE_WARNING: Couldn't resolve default property of object lDriveID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lCDTrackHandle = BASS_CD_StreamCreate(lDriveID, lTrack, BASS_STREAM_DECODE Or BASS_STREAM_AUTOFREE)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If lCDTrackHandle = 0 Then
			
			'Something went wrong
			Call ThrowError("Unable to Create CD Stream!", BASS_ErrorGetCode)
			GoTo ExitRoutine
		End If
		
		'Keep user from pressing any buttons
		'NOT the best way. Just Quick & Dirty.
		'Me.Enabled = False
		
		'Create the output filename
		strOutputFilename = RPP(My.Application.Info.DirectoryPath) & "TRACK" & CStr(lTrack + 1) & ".WMA"
		
		'Open Output File
		'We Know the Freq will be 44100.
		lngWMAEncodeHandle = BASS_WMA_EncodeOpenFile(44100, BASS_WMA_ENCODE_TAGS, lngBitrate, strOutputFilename)
		
		'Exit if there was an error opening/creating the file
		If lngWMAEncodeHandle = 0 Then
			
			'Error
			Call ThrowError("An error occured while opening output file.", BASS_ErrorGetCode)
			Exit Sub
			
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object chkWMAFileTags.value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If chkWMAFileTags.value = System.Windows.Forms.CheckState.Checked Then
			
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
		ReDim buf(19999)
		
		'Loop and read all the data
		'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do While BASS_ChannelIsActive(lCDTrackHandle)
			
			'Get Some Data
			'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ReDim Preserve buf(BASS_ChannelGetData(lCDTrackHandle, buf(0), 20000) - 1)
			
			'Send Data to be Encoded
			'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			lngReturn = BASS_WMA_EncodeWrite(lngWMAEncodeHandle, VarPtr(buf(0)), UBound(buf) + 1)
			
			'Error ??
			If lngReturn = 0 Then
				
				'Error
				Call ThrowError("An error occured while encoding WMA data.", BASS_ErrorGetCode)
				Exit Do
				
			End If
			
			'Don't want to hog ALL the CPU :)
			System.Windows.Forms.Application.DoEvents()
			
		Loop 
		
		'Close the Encoding Handle
		Call BASS_WMA_EncodeClose(lngWMAEncodeHandle)
		
		'MsgBox "WMA File Encoded. Encoding took " & Format$(Timer - lngTimer, "###.#") & " seconds.", vbOKOnly, "WMA Encoding"
		
		
ExitRoutine: 
		'CleanUp
		Erase buf
		
		'UnLock Drive
		'UPGRADE_WARNING: Couldn't resolve default property of object lDriveID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call BASS_CD_Door(lDriveID, BASS_CD_DOOR_UNLOCK)
		
		'Stop / Free the Decoding stream
		'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If lCDTrackHandle Then Call BASS_ChannelStop(lCDTrackHandle)
		'UPGRADE_WARNING: Couldn't resolve default property of object lCDTrackHandle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If lCDTrackHandle Then Call BASS_StreamFree(lCDTrackHandle)
		
		'Stop / Free the Encoding stream
		If lngWMAEncodeHandle Then Call BASS_ChannelStop(lngWMAEncodeHandle)
		If lngWMAEncodeHandle Then Call BASS_StreamFree(lngWMAEncodeHandle)
		
		'Enable Form
		'Me.Enabled = True
		Exit Sub
		
Err_Init: 
		'HandleError strCurrentModule, "ExtractAudioTrackToWMA", Err.Number, Err.Description
		GoTo ExitRoutine
		
	End Sub
End Module