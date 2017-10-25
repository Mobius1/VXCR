Option Strict Off
Option Explicit On
Module modFileSystem
	Dim fso As New Scripting.FileSystemObject
	Public strLoc As String
	Public CancelReadPath As Boolean
	
	'Reads Folder
	Public Function ReadPath(ByRef strPath As String, ByRef lvItem As System.Windows.Forms.ListView, ByRef stbMain As System.Windows.Forms.StatusStrip, Optional ByRef Search As String = "") As Object
		Dim chan As Object
		'On Error Resume Next
		
		'Declares Memory Values
		Dim objFiles As Scripting.File
		Dim objFolders As Scripting.Folder
		Dim objSubFolder As Scripting.Folder
		Dim strFormat() As String
		Dim intA As Short
		
		'Checks for Vaild Path
		If strPath = "" Or InStr(strPath, "::") <> 0 Then Exit Function
		
		objFolders = fso.GetFolder(strPath)
		
		'Clears Current Listview
		lvItem.Items.Clear()
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Listing Directory, Please Wait..."
		
		'Writes New File Information to Listview
		Dim InitBass As Boolean
		For	Each objFiles In objFolders.Files
			System.Windows.Forms.Application.DoEvents()
			
			'Checks if File Format is Supported
			strFormat = Split(VXCRSettings.strSFormats, ",")
			
			'Loops Through Each format
			For intA = 0 To UBound(strFormat)
				System.Windows.Forms.Application.DoEvents()
				
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
							'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
							lvItem.Items.Add(GetId3(strPath & "\" & objFiles.Name), 9)
						Else
							'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
							lvItem.Items.Add("E" & objFiles.Name, 9)
						End If
						
					Else
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
						lvItem.Items.Add(objFiles.Name, 9)
					End If
					
					'Checks if User Wants us to Show BitRate
					If VXCRSettings.blnShwLBitRate = True Then
						
						'Checks if File Exists
						If FileExists(strPath & "\" & objFiles.Name) = False Then Exit Function
						
						'Sets Up Audio Drivers
						InitBass = BASS_Init(1, 44100, 0, frmMain.Handle.ToInt32, 0)
						
						'Frees Stream Channels
						'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BASS_StreamFree(chan)
						'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BASS_MusicFree(chan)
						
						'Loads File and Plays but first checks format
						If UCase(Right(strPath & "\" & objFiles.Name, Len(strPath & "\" & objFiles.Name) - InStr(1, strPath & "\" & objFiles.Name, "."))) <> "WMA" Then
							
							'Launches Regular Player
							'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							chan = BASS_StreamCreateFile(BASSFALSE, CStr(strPath & "\" & objFiles.Name), 0, 0, BASS_STREAM_AUTOFREE)
							
						Else
							
							'Launches WMA Player
							'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(strPath & "\" & objFiles.Name), 0, 0, BASS_STREAM_AUTOFREE)
							
						End If
						
						'Adds BitRate
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems(lvItem.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object chan. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If lvItem.Items.Item(lvItem.Items.Count).SubItems.Count > 1 Then
							lvItem.Items.Item(lvItem.Items.Count).SubItems(1).Text = System.Math.Round((objFiles.Size / BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))) / 125) & "kbps"
						Else
							lvItem.Items.Item(lvItem.Items.Count).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, System.Math.Round((objFiles.Size / BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))) / 125) & "kbps"))
						End If
						
					End If
					
					'Gets File Size and Converts to KB etc
					'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems(lvItem.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Couldn't resolve default property of object DoConv(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If lvItem.Items.Item(lvItem.Items.Count).SubItems.Count > 2 Then
						lvItem.Items.Item(lvItem.Items.Count).SubItems(2).Text = DoConv(objFiles.Size)
					Else
						lvItem.Items.Item(lvItem.Items.Count).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, DoConv(objFiles.Size)))
					End If
					'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvItem.Items.Item(lvItem.Items.Count).Tag = strPath & "\" & objFiles.Name
					
					Exit For
				End If
			Next 
		Next objFiles
		
		strLoc = strPath
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Ready"
		
	End Function
	
	Public Function CopyFile(ByRef strOrgFile As String, ByRef strDstFile As String) As Object
		
		'Gets FreeFiles
		Dim intFF1 As Object
		Dim intFF2 As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		intFF1 = FreeFile
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		intFF2 = (intFF1 + 1)
		
		'Declares Memory Units
		Dim strBuffer As String
		Dim lngFileLength As Integer
		
		'Opens Orginal & New Data location
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FileOpen(intFF1, strOrgFile, OpenMode.Binary)
		FileOpen(intFF2, strDstFile, OpenMode.Binary)
		
		'Gets Orginal File Size
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngFileLength = LOF(intFF1)
		
		'Sets New ProgessBar information
		frmMain.stbp.Value = 0
		
		'Reads Until (End of File)
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do Until EOF(intFF1)
			System.Windows.Forms.Application.DoEvents()
			
			'Updates ProgessBar
			'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmMain.stbp.Value = ((Loc(intFF1) / lngFileLength) * 100)
			
			'Checks if Next Sectors will be last (1MB/grab)
			'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (Loc(intFF1) + 10240) >= lngFileLength Then
				'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strBuffer = Space(Int(lngFileLength - Loc(intFF1) + 1))
			Else
				strBuffer = Space(10240)
			End If
			
			'Reads then Writes Info
			'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(intFF1, strBuffer)
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(intFF2, strBuffer)
			
		Loop 
		
		'Closes Opened Files
		'UPGRADE_WARNING: Couldn't resolve default property of object intFF1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FileClose(intFF1)
		FileClose(intFF2)
		
	End Function
	
	Public Sub ThrowError(ByVal Message As String, Optional ByVal ErrorNum As Integer = -1)
		
		'Display error dialogues
		If ErrorNum <> -1 Then
			Message = Message & vbCrLf & vbCrLf & "Error Code : " & ErrorNum
		End If
		
		MsgBox(Message, MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error")
	End Sub
	
	'Converts Bytes to KB, etc
	Public Function DoConv(ByVal DC As String) As Object
		On Error GoTo Errors
		
		'Declares Memory Values
		Dim NType As Short
		'UPGRADE_NOTE: CType was upgraded to CType_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim CType_Renamed() As String
		
		'Loads Size Array
		CType_Renamed = Split("B,KB,MB,GB,TB,PB,EB,ZB,YB", ",")
		
		'Finds Proper Format
		Do Until CDbl(DC) < 1024
			
			DC = CStr(CDbl(DC) / 1024)
			NType = NType + 1
		Loop 
		
		'European Size Issue Fix
		If InStr(DC, ".") Then DC = VB6.Format(DC, "#.0#")
		If InStr(DC, ",") Then DC = VB6.Format(DC, "#.0#")
		
		'Returns Values
		'UPGRADE_WARNING: Couldn't resolve default property of object DoConv. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DoConv = DC & " " & CType_Renamed(NType)
		
		Exit Function
Errors: 
		'UPGRADE_WARNING: Couldn't resolve default property of object DoConv. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DoConv = DC 'Error Set to origional num
	End Function
	
	
	Public Function RPP(ByVal fp As String) As String
		RPP = IIf(Mid(fp, Len(fp), 1) <> "\", fp & "\", fp)
	End Function
	
	'Checks If File Exists
	Public Function FileExists(ByVal Filename As String) As Boolean
		On Error Resume Next
		
		'Checks if file Exists
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileExists = (Dir(Filename) <> "")
		
	End Function
	
	'Checks if Folder Exisits
	Public Function fFolderExists(ByVal FolderLoc As String) As Boolean
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		fFolderExists = (Dir(FolderLoc, FileAttribute.Directory) <> "")
	End Function
	
	'Creates A Random File
	Public Function RandomFile() As String
		
		'Declares Memory Units
		Dim strFile As String
		Dim intLength As Short
		Dim intA As Short
		Dim intRandom As Short
		
		'Randomize Engine
		Randomize()
		
		'Creates Random File Name (1 - 25 Letters Long)
		intLength = Int(Rnd() * 24) + 1
		
		For intA = 1 To intLength
			System.Windows.Forms.Application.DoEvents()
			
			'Randomize Engine
			Randomize()
			
			Do Until intRandom >= 65 Or intRandom >= 90
				
				'Creates Random File
				intRandom = Int(Rnd() * 90) + 1
				
				System.Windows.Forms.Application.DoEvents()
			Loop 
			
			'Creates RandomName
			strFile = strFile & Chr(intRandom)
			
			intRandom = 0
			
		Next intA
		
		'Sets File Extension
		strFile = strFile & ".VXCR"
		RandomFile = strFile
		
	End Function
End Module