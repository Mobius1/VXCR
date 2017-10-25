Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmMain
	Inherits System.Windows.Forms.Form
	Public WithEvents mFTP As cFTP
	
	'FTP Login Information
	Public strFTPUser As String
	Public strFTPPass As String
	
	'FTP Progress (Tells Us what We are Doing)
	Public intDo As Short
	
	'Music Handle
	Public chan As Integer
	
	'Random FileName
	Public strSTDBLoc As String 'ST.DB File
	Public strXAFile As String 'Xbox SoundTrack Preview
	Public strXTrans As String 'File Used to Transfer Files (XBox->PC)
	Public strXTNames As String 'strXTrans Orginal File Name
	
	'Stores the Which Listview was click on last (Preview Button)
	Public intSelectedLV As Short
	
	'Settings Used in App
	Public strDriveLetter As String
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		MsgBox(FindFreeSongGroup)
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim vbclr As Object
		
		'Resizes Column Headers/Status bar
		ReSizeLV(lvPC, 1)
		ReSizeLV(lvXbox, 1)
		ResizeStatusBar((Me.stbMain), 1)
		
		'Loads Settings
		LoadVXCRSettings()
		
		'Lists CD Drives
		ListCDDrives(stbMain)
		
		'Adds First Node to TreeView
		Me.tvXbox.Nodes.Add("XB", "Xbox Sound Tracks", 14)
		tvXbox.Nodes.Item("XB").Expand()
		
		'Sets Doing Variable
		intDo = 0
		stbp.Value = 0
		
		strDriveLetter = "/e"
		
		'Unloads Not Nessary Menu Items
		mnuSongList.Visible = False
		mnuSoundTrack.Visible = False
		mnuLVPC.Visible = False
		tlbXBOX.Visible = False
		
		'Sets Up FTP
		mFTP = New cFTP
		mFTP.SetModeActive()
		mFTP.SetTransferBinary()
		
		'Checks if Temp Folder Exists
		If modFileSystem.fFolderExists(VXCRSettings.strTempFld) <> True Or VXCRSettings.strTempFld = "" Then
			
			'Notifies User that Temp Folder Doesnt Exists
			'UPGRADE_WARNING: Couldn't resolve default property of object vbclr. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MsgBox("The Selected Temporary Folder doesnt Exists:" & vbCrLf & vbclr & VXCRSettings.strTempFld & vbCrLf & vbCrLf & "Please Select a New Temporary Folder Now.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation)
			
			'Shows Option Dialog
			frmOptions.Show()
			
			'Presses Browse Button
			frmOptions.cmdSelFld_Click(Nothing, New System.EventArgs())
			
		End If
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Ready"
		Me.Text = "Virtual Xbox CD Ripper (Build 101904)"
		
		'-----------------------
		'BUILD INFO
		'-----------------------
		Exit Sub
		
		Dim intBuild As Short
		FileOpen(11, My.Application.Info.DirectoryPath & "\build.ini", OpenMode.Input)
		Input(11, intBuild)
		FileClose(11)
		intBuild = intBuild + 1
		FileOpen(11, My.Application.Info.DirectoryPath & "\build.ini", OpenMode.Output)
		PrintLine(11, intBuild)
		FileClose(11)
		Me.Text = "Virtual Xbox CD Ripper (Build A404-" & intBuild & ")"
		
	End Sub
	
	'UPGRADE_WARNING: Event frmMain.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		'Resizes Controls
		lvXbox.Width = Me.ClientRectangle.Width - (lvXbox.Left + 8)
		lvPC.Width = Me.ClientRectangle.Width - (lvPC.Left + 8)
		tlbTransfer.Left = (lvXbox.Width + lvXbox.Left) - tlbTransfer.Width
		tvXbox.Height = ((Me.ClientRectangle.Height / 2) - (tbMain.Height - 5) + tlbPlayer.Height) - 9
		ftvPC.Top = (tvXbox.Height + lvXbox.Top) + 2
		ftvPC.Height = (Me.ClientRectangle.Height - ftvPC.Top) - 21
		lvPC.Top = ftvPC.Top
		lvPC.Height = ftvPC.Height
		lvXbox.Height = (tvXbox.Height - tlbPlayer.Height) - 2
		tlbPlayer.Top = (lvXbox.Top + lvXbox.Height) + 2
		tlbTransfer.Top = tlbPlayer.Top
		
		'Resizes Listview
		ReSizeLV(lvPC, 1)
		ReSizeLV(lvXbox, 1)
		
		'Resizes Status Bar
		ResizeStatusBar(stbMain, 1)
		
		'Sets Progressbar in StatusBar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbp.Width = stbMain.Items.Item(2).Width - 4
		stbp.Height = stbMain.Height - 5
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_ISSUE: MSComctlLib.IPanel property stbMain.Panels.Left was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		stbp.Left = stbMain.Items.Item(2).Left + 3
		stbp.Top = stbMain.Top + 4
		
	End Sub
	
	Private Sub frmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		On Error Resume Next
		
		'Terminates FTP
		mFTP.CloseConnection()
		
		'Unloads Audio
		BASS_Stop()
		BASS_Free()
		
		'Deletes Files
		Kill(strSTDBLoc)
		Kill(strXAFile)
		
		'Saves Settings
		SaveVXCRSettings()
		
	End Sub
	
	Private Sub ftvPC_FolderClick(ByVal eventSender As System.Object, ByVal eventArgs As AxCCRPFolderTV6.__FolderTreeview_FolderClickEvent) Handles ftvPC.FolderClick
		'CancelReadPath = True
		
		'Looks For Possible CD Drive
		If Len(eventArgs.Folder.FullPath) = 3 Then
			
			'Checks if CD Drive
			If InStr(1, strCDDrives, VB.Left(eventArgs.Folder.FullPath, 1)) Then
				
				'Sets LvPC to work w/ CD Ripper
				ListviewPCCDRipper(lvPC)
				
				'Reads Track List from CD
				LoadTrackList(lvPC, stbMain)
				
				Exit Sub
			End If
		End If
		
		'Sets LvPC to work w/ File Viewing
		ListviewPCFileView(lvPC)
		
		'Checks if Last List is canceld
		
		
		'Reads Folder Path
		ReadPath((eventArgs.Folder.FullPath), lvPC, stbMain)
		
	End Sub
	
	Private Sub Socket_DataArrival(ByVal bytesTotal As Integer)
		Dim Socket As Object
		
		Dim strInput As String
		'UPGRADE_WARNING: Couldn't resolve default property of object Socket.GetData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Socket.GetData(strInput)
		
	End Sub
	
	Private Sub lvPC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvPC.Click
		
		'Stores This LV has Focus
		intSelectedLV = 0
		
	End Sub
	
	Private Sub lvXbox_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvXbox.Click
		
		'Stores This LV has Focus
		intSelectedLV = 1
		
	End Sub
	
	Private Sub lvXbox_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lvXbox.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		'Checks for Right Click
		If Button = 2 Then
			
			'Shows the Popup Menu
			'UPGRADE_ISSUE: Form method frmMain.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PopupMenu(mnuSongList)
			
		End If
		
	End Sub
	
	Private Sub mFTP_FileTransferProgress(ByRef lCurrentBytes As Integer, ByRef lTotalBytes As Integer) Handles mFTP.FileTransferProgress
		
		'Declares Memory Values
		Dim InitBass As Boolean
		Dim intProgress As Short
		
		intProgress = CShort(VB6.Format(lCurrentBytes / lTotalBytes * 100, "00.00"))
		
		'Updates Status for whatever is happening
		Select Case intDo
			
			'Download ST.DB File
			Case 1000
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Downloading Database..."
				stbp.Value = intProgress
				
				'Checks if Download Is Done
				If intProgress = 100 Then
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Reading Database..."
					stbp.Value = 0
					
					'Reads ST.DB file
					Initialize(strSTDBLoc)
					
					'Lists SoundTracks
					ReadSoundTracks(tvXbox)
					
					'Dont know but if you dont call this on initlial it aint working
					FindFreeSongGroup()
					FindFreeSongGroup()
					FindFreeSongGroup()
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Ready"
					
					'Sets Nothing
					intDo = 9999
					
				End If
				
				'Xbox SoundTrack Preview (File Progress)
			Case 1001
				
				'Disables Play/Stop Button
				'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tlbPlayer.Items.Item(1).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tlbPlayer.Items.Item(2).Enabled = False
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Downloading Xbox Preview Track..."
				stbp.Value = intProgress
				
				'Checks if Download Is Done
				If intProgress = 100 Then
					
					
					'Sets Up Audio Drivers
					InitBass = BASS_Init(1, 44100, 0, Me.Handle.ToInt32, 0)
					
					'Frees Stream Channels
					BASS_StreamFree(chan)
					BASS_MusicFree(chan)
					
					Call BASS_ChannelSetAttributes(chan, 0, 100, 0)
					
					'Loads File and Plays
					chan = BASS_WMA_StreamCreateFile(BASSFALSE, strXAFile, 0, 0, BASS_STREAM_AUTOFREE Or BASS_STREAM_AUTOFREE)
					
					BASS_StreamPlay(chan, 0, 0)
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Ready"
					stbp.Value = 0
					
					'Enables Play/Stop Button
					'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					tlbPlayer.Items.Item(1).Enabled = True
					'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					tlbPlayer.Items.Item(2).Enabled = True
					
					'Sets Nothing
					intDo = 9999
					
				End If
				
				'File Transfer (XBOX->PC)
			Case 1002
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Downloading Xbox Track..."
				stbp.Value = intProgress
				
				'Checks if Download Is Done
				If intProgress = 100 Then
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Local Copying..."
					
					'Copies File to final Destination
					CopyFile(strXTrans, strLoc & "\" & strXTNames & ".wma")
					
					'Reads Folder Path
					ReadPath(strLoc & "\", lvPC, stbMain)
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Ready"
					Me.stbp.Value = 0
					
					'Sets Nothing
					intDo = 9999
					
				End If
				
				'File Transfer (PC->XBOX)
			Case 1003
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Sending to Xbox, Please Wait..."
				stbp.Value = intProgress
				
				'Checks if Download Is Done
				If intProgress = 100 Then
					
					'Updates StatusBar
					'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					stbMain.Items.Item(1).Text = "Ready"
					Me.stbp.Value = 0
					
					'Sets Nothing
					intDo = 9999
					
				End If
		End Select
		
	End Sub
	
	Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
		
		'Shows About Dialog
		frmAbout.Show()
		
	End Sub
	
	Public Sub mnuAddSST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAddSST.Click
		'Adds New SoundTrack
		AddSoundTrack(InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox)
		UploadST()
		
	End Sub
	
	Public Sub mnuConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuConnect.Click
		Dim a As Object
		
		'Sets Downloading Variable
		Me.intDo = 1000
		
		strSTDBLoc = VXCRSettings.strTempFld & RandomFile
		
		'Disables/Enables Buttons
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(1).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(2).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(4).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(5).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(1).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(2).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(3).Enabled = True
		
		DetectFTP()
		
		'Set folder to music folder
		'UPGRADE_WARNING: Couldn't resolve default property of object frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & tdata/fffe0000/music). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music") Then
			
			'Downloads ST.DB File from FTP Server (Xbox)
			'UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			a = Me.mFTP.FTPDownloadFile(strSTDBLoc, "st.db")
			
		Else
			
			MsgBox("Error Connecting to FTP Folder")
			
		End If
		
	End Sub
	
	Public Sub mnuDisconnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDisconnect.Click
		Dim a As Object
		
		'Closes ST.DB Manager
		TerminateST()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & tdata/fffe0000/music). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music") Then
			
			'Downloads ST.DB File from FTP Server (Xbox)
			'UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			a = Me.mFTP.SimpleFTPPutFile(strSTDBLoc, "st.db")
			
		Else
			MsgBox("Error Uploading Database")
		End If
		
		'Disconnects from ALL FTP Servers
		mFTP.CloseConnection()
		
		'Deletes Temp ST.DB File
		Kill(strSTDBLoc)
		
		'Disables/Enables Buttons
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(1).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(2).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(4).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(5).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(1).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(2).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbTransfer.Items.Item(3).Enabled = False
		
		'Resets Xbox Treeview
		tvXbox.Nodes.Clear()
		tvXbox.Nodes.Add("XB", "Xbox Sound Tracks", 14)
		tvXbox.Nodes.Item("XB").Expand()
		
		'Reset Soundtrack Listview
		lvXbox.Items.Clear()
		
	End Sub
	
	Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
		End
	End Sub
	
	Public Sub mnuPatch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPatch.Click
		Dim frmGamePatcher As Object
		
		'Shows Patching Dialog
		'UPGRADE_WARNING: Couldn't resolve default property of object frmGamePatcher.Show. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmGamePatcher.Show()
		
	End Sub
	
	Public Sub mnuPCSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPCSelAll.Click
		
		'Checks lvXbox's Count
		If lvPC.Items.Count = 0 Then Exit Sub
		
		'Delcare Memory Varibles
		Dim lngA As Integer
		For lngA = 1 To lvPC.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks lvXbox Item
			'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvPC.Items.Item(lngA).Checked = True
		Next lngA
	End Sub
	
	Public Sub mnuPCUnSelALL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPCUnSelALL.Click
		
		'Checks lvXbox's Count
		If lvPC.Items.Count = 0 Then Exit Sub
		
		'Delcare Memory Varibles
		Dim lngA As Integer
		For lngA = 1 To lvPC.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks lvXbox Item
			'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvPC.Items.Item(lngA).Checked = False
		Next lngA
		
	End Sub
	
	Public Sub mnuRConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRConnect.Click
		
		'Shows Connect Dialog
		frmConnect.Show()
		
	End Sub
	
	Public Sub mnuRSTAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRSTAdd.Click
		
		'Adds New SoundTrack
		AddSoundTrack(InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox)
		
	End Sub
	
	Public Sub mnuSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSelAll.Click
		
		'Checks lvXbox's Count
		If lvXbox.Items.Count = 0 Then Exit Sub
		
		'Delcare Memory Varibles
		Dim lngA As Integer
		For lngA = 1 To lvXbox.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks lvXbox Item
			'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvXbox.Items.Item(lngA).Checked = True
		Next lngA
		
	End Sub
	
	Public Sub mnuSongSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSongSearch.Click
		
		'Shows Search Window
		frmSearch.Show()
	End Sub
	
	Public Sub mnuUnSel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuUnSel.Click
		
		'Checks lvXbox's Count
		If lvXbox.Items.Count = 0 Then Exit Sub
		
		'Delcare Memory Varibles
		Dim lngA As Integer
		For lngA = 1 To lvXbox.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks lvXbox Item
			'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvXbox.Items.Item(lngA).Checked = False
		Next lngA
		
	End Sub
	
	Private Sub sockCDDB_ConnectEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sockCDDB.ConnectEvent
		Dim CurrentMachineName As Object
		Dim Winsock1 As Object
		
		'Handshake
		'UPGRADE_WARNING: Couldn't resolve default property of object CurrentMachineName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Winsock1.SendData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Winsock1.SendData("cddb hello " & CurrentMachineName & " " & sockCDDB.LocalIP & " Virtual_Xbox_CD_Ripper" & vbCrLf)
		
	End Sub
	
	Private Sub tbMain_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbMain_Button1.Click, _tbMain_Button2.Click, _tbMain_Button3.Click, _tbMain_Button4.Click, _tbMain_Button5.Click, _tbMain_Button6.Click, _tbMain_Button7.Click, _tbMain_Button8.Click, _tbMain_Button9.Click, _tbMain_Button10.Click, _tbMain_Button11.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		
		'Selects Which Button is Pressed
		Select Case Button.Name
			
			'Connect Button
			Case "Connect"
				
				'Shows Connect Dialog
				frmConnect.Show()
				
				'Close Button
			Case "Close"
				
				If UploadST = False Then
					MsgBox("Virtual Xbox CD Ripper has failed to upload the SoundTrack Database!" & vbCrLf & "Please Reconnect now.")
					
					Exit Sub
				End If
				
				'Disconnects from ALL FTP Servers
				mFTP.CloseConnection()
				
				'Deletes Temp ST.DB File
				Kill(strSTDBLoc)
				
				'Disables/Enables Buttons
				'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tbMain.Items.Item(1).Enabled = True
				'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tbMain.Items.Item(2).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tbMain.Items.Item(4).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tbMain.Items.Item(5).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tlbTransfer.Items.Item(1).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tlbTransfer.Items.Item(2).Enabled = False
				'UPGRADE_WARNING: Lower bound of collection tlbTransfer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				tlbTransfer.Items.Item(3).Enabled = False
				
				'Resets Xbox Treeview
				tvXbox.Nodes.Clear()
				tvXbox.Nodes.Add("XB", "Xbox Sound Tracks", 14)
				tvXbox.Nodes.Item("XB").Expand()
				
				'Reset Soundtrack Listview
				lvXbox.Items.Clear()
				
			Case "Add"
				AddSoundTrack(InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox)
				UploadST()
				
			Case "Remove"
				
				'Checks if a SoundTrack is selected
				If SoundTrackSelected = False Then
					
					'Displays Err Message
					MsgBox("Please Select a Soundtrack.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Virtual Xbox CD Ripper")
					Exit Sub
					
				End If
				
				DeleteSoundTrack(CInt(Replace(tvXbox.SelectedNode.Name, "#", "")))
				ReadSoundTracks(tvXbox)
				
			Case "Xbox"
				'UPGRADE_ISSUE: Form method frmMain.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				PopupMenu(tlbXBOX)
				
			Case "Options"
				
				'Shows Option Dialog
				frmOptions.Show()
				
			Case "Search"
				
				'Presses Songs|Search
				mnuSongSearch_Click(mnuSongSearch, New System.EventArgs())
				
				
			Case "About"
				
				'Shows About Dialog
				frmAbout.Show()
				
		End Select
	End Sub
	
	Private Sub tlbPlayer_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tlbPlayer_Button1.Click, _tlbPlayer_Button2.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		Dim blna As Object
		'On Error Resume Next
		
		'Determines Weather PLAY/STOP was pressed
		Dim InitBass As Boolean
		Dim strFFile As String
		Select Case Button.Name
			Case "Play"
				
				Select Case intSelectedLV
					
					'Play LVPC File (Local HDD)
					Case 0
						
						'Checks if File Exists
						If FileExists(CStr(lvPC.FocusedItem.Tag)) = False Then Exit Sub
						
						'Sets Up Audio Drivers
						InitBass = BASS_Init(1, 44100, 0, Me.Handle.ToInt32, 0)
						
						'Frees Stream Channels
						BASS_StreamFree(chan)
						BASS_MusicFree(chan)
						
						'Loads File and Plays but first checks format
						If UCase(VB.Right(lvPC.FocusedItem.Tag, Len(lvPC.FocusedItem.Tag) - InStr(1, lvPC.FocusedItem.Tag, "."))) <> "WMA" Then
							
							'Launches Regular Player
							chan = BASS_StreamCreateFile(BASSFALSE, CStr(lvPC.FocusedItem.Tag), 0, 0, BASS_STREAM_AUTOFREE)
							
						Else
							
							'Launches WMA Player
							chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(lvPC.FocusedItem.Tag), 0, 0, BASS_STREAM_AUTOFREE)
							
						End If
						
						'Plays Stream
						BASS_StreamPlay(chan, 0, 0)
						
						
						'Xbox Sound Track (Remote)
					Case 1
						
						'Checks if Old Preview Track Exists
						If FileExists(strXAFile) = True Then
							
							'If Theres a File
							If strXAFile <> "" Then
								Kill(strXAFile)
							End If
						End If
						
						'Creates Random File Name
						strXAFile = VXCRSettings.strTempFld & RandomFile
						
						'Sets FTP Operation
						intDo = 1001
						
						'Change folder
						'UPGRADE_WARNING: Lower bound of collection lvXbox.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music/" & Mid(lvXbox.FocusedItem.SubItems(2).Text, 1, 4) & "/")
						
						'UPGRADE_WARNING: Lower bound of collection lvXbox.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						strFFile = VB.Right(lvXbox.FocusedItem.SubItems(2).Text, Len(lvXbox.FocusedItem.SubItems(2).Text) - InStr(1, lvXbox.FocusedItem.SubItems(2).Text, "/"))
						
						'Downloads ST.DB File from FTP Server (Xbox) SimpleFTPGetFile FTPDownloadFile
						'UPGRADE_WARNING: Couldn't resolve default property of object blna. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						blna = Me.mFTP.FTPDownloadFile(strXAFile, strFFile)
						
				End Select
				
			Case "Stop"
				
				'Checks if Old Preview Track Exists
				If FileExists(strXAFile) = True Then
					
					'If Theres a File
					If strXAFile <> "" Then
						Kill(strXAFile)
					End If
				End If
				
				'Stops Playback
				BASS_ChannelStop(chan)
				BASS_StreamFree(chan)
				BASS_Free()
				
		End Select
	End Sub
	
	Private Sub tlbTransfer_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tlbTransfer_Button1.Click, _tlbTransfer_Button2.Click, _tlbTransfer_Button3.Click, _tlbTransfer_Button4.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		Dim blna As Object
		
		'On Error GoTo ErrHD
		
		'Declares Memory Units
		Dim lngA As Integer
		Dim lngB As Integer
		Dim strA As String
		Dim strOutputfile As String 'Tells us Xbox filename to use
		
		'Selects Transfer Button
		Dim strFFile As String
		Select Case Button.Name
			
			Case "Download"
				
				For lngA = 1 To lvXbox.Items.Count
					
					'Checks if item is Checked
					'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvXbox.Items.Item(lngA).Checked = True Then
						
						'Deletes Temparory File (LastTime)
						If strXTrans <> "" Then
							Kill(strXTrans)
						End If
						
						'Creates Random File Name
						strXTrans = VXCRSettings.strTempFld & RandomFile
						
						'Writes Orginal File Info
						'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						strXTNames = lvXbox.Items.Item(lngA).Text
						
						'Sets FTP Operation
						intDo = 1002
						
						'Change folder
						'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music/" & Mid(lvXbox.Items.Item(lngA).SubItems(2).Text, 1, 4))
						
						'Gets Real FileName
						'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvXbox.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						strFFile = VB.Right(lvXbox.Items.Item(lngA).SubItems(2).Text, Len(lvXbox.Items.Item(lngA).SubItems(2).Text) - InStr(1, lvXbox.Items.Item(lngA).SubItems(2).Text, "/"))
						
						'Downloads Music File from Xbox
						'UPGRADE_WARNING: Couldn't resolve default property of object blna. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						blna = Me.mFTP.FTPDownloadFile(strXTrans, strFFile)
					End If
					
				Next lngA
				
				'------------------------------
				'Upload Section
				'------------------------------
			Case "Upload"
				
				'Checks if a SoundTrack is selected
				If SoundTrackSelected = False Then
					
					'Displays Err Message
					MsgBox("Please Select a Soundtrack.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Virtual Xbox CD Ripper")
					Exit Sub
				End If
				
				'Checks if User wants to Edit Title before upload
				If VXCRSettings.blnManuIDTag = True Then
					
					'Shows Edit Dialog
					frmEditTitle.Show()
					
					Exit Sub
				End If
				
				'Converts/Uploads Selected Songs
				UploadSongs()
				
			Case "Delete"
				MsgBox("This Feature doesnt work yet!")
		End Select
		
		Exit Sub
ErrHD: 
		MsgBox("Please Select a SoundTrack, Might be possible bugs not sure")
	End Sub
	
	Private Sub tmrResize_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrResize.Tick
		If stbp.Top <> (stbMain.Top + 4) Then
			frmMain_Resize(Me, New System.EventArgs())
		End If
	End Sub
	
	Private Sub tvXbox_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles tvXbox.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		'Checks for Right Click
		If Button = 2 Then
			
			'Shows the Popup Menu
			'UPGRADE_ISSUE: Form method frmMain.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			PopupMenu(mnuSoundTrack)
			
		End If
		
	End Sub
	
	Private Sub tvXbox_NodeClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvXbox.NodeMouseClick
		Dim Node As System.Windows.Forms.TreeNode = eventArgs.Node
		
		If Node.Name <> "XB" Then
			SoundTrackDetail(CInt(Replace(Node.Name, "#", "")), (Me.lvXbox))
			
		End If
	End Sub
	
	Public Function SoundTrackSelected() As Boolean
		On Error GoTo ErrHnd
		
		SoundTrackSelected = True
		
		'Checks if tvXbox has an Item Selected
		If tvXbox.SelectedNode.Name = "XB" Then GoTo ErrHnd
		
		
		Exit Function
ErrHnd: 
		SoundTrackSelected = False
	End Function
	
	Public Function UploadSongs() As Object
		Dim strOutputfile As Object
		Dim lngA As Object
		'On Error Resume Next
		
		'Disables UI Controls
		ftvPC.Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbPlayer.Items.Item(1).Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbPlayer.Items.Item(2).Enabled = False
		mnuSongSearch.Enabled = False
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(7).Enabled = False
		
		Dim strA As String
		
		Dim InitBass As Boolean
		For lngA = 1 To lvPC.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks if Item is checked
			'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvPC.Items.Item(lngA).Checked = True Then
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Converting to WMA, Please Wait..."
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvPC.Items.Item(lngA).SubItems.Count > 1 Then
					lvPC.Items.Item(lngA).SubItems(1).Text = "Converting..."
				Else
					lvPC.Items.Item(lngA).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Converting..."))
				End If
				
				'Changes Focus Area
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvPC.Items.Item(lngA).Selected = True
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: MSComctlLib.IListItem method lvPC.ListItems.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				lvPC.Items.Item(lngA).EnsureVisible()
				'lvPC.SetFocus
				
				'Generates Temp Name
				strA = VXCRSettings.strTempFld & RandomFile
				'strA = App.path & "\temp\KIOTZYBLJWZZKUFCDDQP.VXCR"
				
				'Converts Stuff to WMA
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				ConvertToWMA(CStr(lvPC.Items.Item(lngA).Tag), strA, VXCRSettings.lngWmaBitRate)
				
				'Intilizes BASS_STREAM (For Grabbing TrackCount)
				
				'Checks if File Exists
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If FileExists(CStr(lvPC.Items.Item(lngA).Tag)) = False Then Exit Function
				
				'Sets Up Audio Drivers
				InitBass = BASS_Init(1, 44100, 0, Me.Handle.ToInt32, 0)
				
				'Frees Stream Channels
				BASS_StreamFree(chan)
				BASS_MusicFree(chan)
				
				'Loads File and Plays but first checks format
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If UCase(VB.Right(lvPC.Items.Item(lngA).Tag, Len(lvPC.Items.Item(lngA).Tag) - InStr(1, lvPC.Items.Item(lngA).Tag, "."))) <> "WMA" Then
					
					'Launches Regular Player
					'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					chan = BASS_StreamCreateFile(BASSFALSE, CStr(lvPC.Items.Item(lngA).Tag), 0, 0, BASS_STREAM_AUTOFREE)
					
				Else
					
					'Launches WMA Player
					'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(lvPC.Items.Item(lngA).Tag), 0, 0, BASS_STREAM_AUTOFREE)
					
				End If
				
				'Adds Song to ST.DB File
				'strOutputfile = AddSong(modMP3Tag.GetId3(CStr(lvPC.ListItems(lngA).TaG)), strA, BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan)), Replace(tvXbox.SelectedItem.Key, "#", ""))
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object strOutputfile. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strOutputfile = AddSong((lvPC.Items.Item(lngA).Text), strA, CStr(BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan))), CInt(Replace(tvXbox.SelectedNode.Name, "#", "")))
				
				'Stops Playback
				BASS_ChannelStop(chan)
				BASS_StreamFree(chan)
				BASS_Free()
				
				'Updates Status Bar
				'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				stbMain.Items.Item(1).Text = "Sending to Xbox, Please Wait..."
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvPC.Items.Item(lngA).SubItems.Count > 1 Then
					lvPC.Items.Item(lngA).SubItems(1).Text = "Transfering..."
				Else
					lvPC.Items.Item(lngA).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Transfering..."))
				End If
				
				'Change folder
				Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music/")
				'UPGRADE_WARNING: Couldn't resolve default property of object strOutputfile. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.mFTP.CreateFTPDirectory(VB.Left(strOutputfile, 4))
				'UPGRADE_WARNING: Couldn't resolve default property of object strOutputfile. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music/" & VB.Left(strOutputfile, 4) & "/")
				
				'Sets FTP Operation
				intDo = 1003
				
				'Uploads Data
				'UPGRADE_WARNING: Couldn't resolve default property of object strOutputfile. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mFTP.FTPUploadFile(strA, strOutputfile & ".wma")
				
				'Deletes Temp File
				'Kill strA
				
				'Unchecks Item
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvPC.Items.Item(lngA).Checked = False
				
				'Updates Status
				'UPGRADE_WARNING: Couldn't resolve default property of object lngA. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvPC.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvPC.Items.Item(lngA).SubItems.Count > 1 Then
					lvPC.Items.Item(lngA).SubItems(1).Text = "Complete"
				Else
					lvPC.Items.Item(lngA).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Complete"))
				End If
				
				'Refreshes Xbox Listview
				SoundTrackDetail(CInt(Replace(tvXbox.SelectedNode.Name, "#", "")), (Me.lvXbox))
				
			End If
			
		Next lngA
		
		'Disables UI Controls
		ftvPC.Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbPlayer.Items.Item(1).Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tlbPlayer.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tlbPlayer.Items.Item(2).Enabled = True
		mnuSongSearch.Enabled = True
		'UPGRADE_WARNING: Lower bound of collection tbMain.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		tbMain.Items.Item(7).Enabled = True
		
		'Uploads New ST.DB File to Xbox
		UploadST()
		
	End Function
	
	Public Function UploadST() As Boolean
		Dim a As Object
		
		'Saves ST.DB File
		TerminateST()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & tdata/fffe0000/music). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "tdata/fffe0000/music") Then
			
			'Downloads ST.DB File from FTP Server (Xbox)
			'UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			a = Me.mFTP.SimpleFTPPutFile(strSTDBLoc, "st.db")
			UploadST = True
			
		Else
			MsgBox("Error Uploading Database (Function: UploadSongs)")
			UploadST = False
		End If
	End Function
	
	Public Function DetectFTP() As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & ). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Me.mFTP.SetFTPDirectory(Me.strDriveLetter & "") Then
			Debug.Print("/e/")
			strDriveLetter = "/e/"
		Else
			Debug.Print("/e:/")
			strDriveLetter = "/e:/"
		End If
	End Function
End Class