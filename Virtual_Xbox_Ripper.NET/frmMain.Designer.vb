<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents tmrResize As System.Windows.Forms.Timer
	Public WithEvents sockCDDB As AxMSWinsockLib.AxWinsock
	Public WithEvents _tlbTransfer_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbTransfer_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbTransfer_Button3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tlbTransfer_Button4 As System.Windows.Forms.ToolStripButton
	Public WithEvents tlbTransfer As System.Windows.Forms.ToolStrip
	Public WithEvents _tlbPlayer_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tlbPlayer_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents tlbPlayer As System.Windows.Forms.ToolStrip
	Public WithEvents stbp As System.Windows.Forms.ProgressBar
	Public WithEvents ftvPC As AxCCRPFolderTV6.AxFolderTreeview
	Public WithEvents _stbMain_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _stbMain_Panel2 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _stbMain_Panel3 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _stbMain_Panel4 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _stbMain_Panel5 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents stbMain As System.Windows.Forms.StatusStrip
	Public WithEvents imgList1 As System.Windows.Forms.ImageList
	Public WithEvents _lvPC_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPC_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvPC_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvPC As System.Windows.Forms.ListView
	Public WithEvents _lvXbox_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvXbox_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvXbox_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvXbox_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvXbox As System.Windows.Forms.ListView
	Public WithEvents tvXbox As System.Windows.Forms.TreeView
	Public WithEvents _tbMain_Button1 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button2 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbMain_Button4 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button5 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbMain_Button7 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button8 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbMain_Button9 As System.Windows.Forms.ToolStripButton
	Public WithEvents _tbMain_Button10 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents _tbMain_Button11 As System.Windows.Forms.ToolStripButton
	Public WithEvents tbMain As System.Windows.Forms.ToolStrip
	Public WithEvents mnuPatch As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp7 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuEDrive As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFDrive As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents tlbXBOX As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPCSelAll As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuPCUnSelALL As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuLVPC As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSelAll As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuUnSel As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents sp12321 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuSLDelete As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSLRename As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuSLIDTag As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSongList As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAddSST As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRemoveST As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp1 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuRenameST As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSoundTrack As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRConnect As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDisconnect As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuConnect As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRSTAdd As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRSTRemove As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRSTRename As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuImportST As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRSoundTracks As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAddSongs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSelFolder As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnusp6 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents mnuSongSearch As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSongS As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.tmrResize = New System.Windows.Forms.Timer(components)
		Me.sockCDDB = New AxMSWinsockLib.AxWinsock
		Me.tlbTransfer = New System.Windows.Forms.ToolStrip
		Me._tlbTransfer_Button1 = New System.Windows.Forms.ToolStripButton
		Me._tlbTransfer_Button2 = New System.Windows.Forms.ToolStripButton
		Me._tlbTransfer_Button3 = New System.Windows.Forms.ToolStripSeparator
		Me._tlbTransfer_Button4 = New System.Windows.Forms.ToolStripButton
		Me.tlbPlayer = New System.Windows.Forms.ToolStrip
		Me._tlbPlayer_Button1 = New System.Windows.Forms.ToolStripButton
		Me._tlbPlayer_Button2 = New System.Windows.Forms.ToolStripButton
		Me.stbp = New System.Windows.Forms.ProgressBar
		Me.ftvPC = New AxCCRPFolderTV6.AxFolderTreeview
		Me.stbMain = New System.Windows.Forms.StatusStrip
		Me._stbMain_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me._stbMain_Panel2 = New System.Windows.Forms.ToolStripStatusLabel
		Me._stbMain_Panel3 = New System.Windows.Forms.ToolStripStatusLabel
		Me._stbMain_Panel4 = New System.Windows.Forms.ToolStripStatusLabel
		Me._stbMain_Panel5 = New System.Windows.Forms.ToolStripStatusLabel
		Me.imgList1 = New System.Windows.Forms.ImageList
		Me.lvPC = New System.Windows.Forms.ListView
		Me._lvPC_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvPC_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvPC_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.lvXbox = New System.Windows.Forms.ListView
		Me._lvXbox_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvXbox_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvXbox_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvXbox_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me.tvXbox = New System.Windows.Forms.TreeView
		Me.tbMain = New System.Windows.Forms.ToolStrip
		Me._tbMain_Button1 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button2 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button3 = New System.Windows.Forms.ToolStripSeparator
		Me._tbMain_Button4 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button5 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button6 = New System.Windows.Forms.ToolStripSeparator
		Me._tbMain_Button7 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button8 = New System.Windows.Forms.ToolStripSeparator
		Me._tbMain_Button9 = New System.Windows.Forms.ToolStripButton
		Me._tbMain_Button10 = New System.Windows.Forms.ToolStripSeparator
		Me._tbMain_Button11 = New System.Windows.Forms.ToolStripButton
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.tlbXBOX = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuPatch = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp7 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuEDrive = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFDrive = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuLVPC = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuPCSelAll = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuPCUnSelALL = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSongList = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSelAll = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuUnSel = New System.Windows.Forms.ToolStripMenuItem
		Me.sp12321 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuSLDelete = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSLRename = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp3 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuSLIDTag = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSoundTrack = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAddSST = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRemoveST = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp1 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuRenameST = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRConnect = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuDisconnect = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp2 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuConnect = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRSoundTracks = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRSTAdd = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRSTRemove = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuRSTRename = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp5 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuImportST = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSongS = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAddSongs = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSelFolder = New System.Windows.Forms.ToolStripMenuItem
		Me.mnusp6 = New System.Windows.Forms.ToolStripSeparator
		Me.mnuSongSearch = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
		Me.tlbTransfer.SuspendLayout()
		Me.tlbPlayer.SuspendLayout()
		Me.stbMain.SuspendLayout()
		Me.lvPC.SuspendLayout()
		Me.lvXbox.SuspendLayout()
		Me.tbMain.SuspendLayout()
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.sockCDDB, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ftvPC, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Virtual Xbox CD Ripper (Build INFO)"
		Me.ClientSize = New System.Drawing.Size(673, 438)
		Me.Location = New System.Drawing.Point(11, 57)
		Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("frmMain.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Command1"
		Me.Command1.Size = New System.Drawing.Size(17, 17)
		Me.Command1.Location = New System.Drawing.Point(400, 224)
		Me.Command1.TabIndex = 9
		Me.Command1.Visible = False
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.tmrResize.Interval = 250
		Me.tmrResize.Enabled = True
		sockCDDB.OcxState = CType(resources.GetObject("sockCDDB.OcxState"), System.Windows.Forms.AxHost.State)
		Me.sockCDDB.Location = New System.Drawing.Point(632, 48)
		Me.sockCDDB.Name = "sockCDDB"
		Me.tlbTransfer.ShowItemToolTips = True
		Me.tlbTransfer.Size = New System.Drawing.Size(230, 22)
		Me.tlbTransfer.Location = New System.Drawing.Point(432, 224)
		Me.tlbTransfer.TabIndex = 8
		Me.tlbTransfer.CanOverflow = False
		Me.tlbTransfer.ImageList = imgList1
		Me.tlbTransfer.Name = "tlbTransfer"
		Me._tlbTransfer_Button1.Size = New System.Drawing.Size(75, 22)
		Me._tlbTransfer_Button1.AutoSize = False
		Me._tlbTransfer_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbTransfer_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbTransfer_Button1.CheckOnClick = False
		Me._tlbTransfer_Button1.Enabled = 0
		Me._tlbTransfer_Button1.Text = "Upload"
		Me._tlbTransfer_Button1.Name = "Upload"
		Me._tlbTransfer_Button1.ImageIndex = 14
		Me._tlbTransfer_Button2.Size = New System.Drawing.Size(75, 22)
		Me._tlbTransfer_Button2.AutoSize = False
		Me._tlbTransfer_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbTransfer_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbTransfer_Button2.CheckOnClick = False
		Me._tlbTransfer_Button2.Enabled = 0
		Me._tlbTransfer_Button2.Text = "Download"
		Me._tlbTransfer_Button2.Name = "Download"
		Me._tlbTransfer_Button2.ImageIndex = 15
		Me._tlbTransfer_Button3.Size = New System.Drawing.Size(75, 22)
		Me._tlbTransfer_Button3.AutoSize = False
		Me._tlbTransfer_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbTransfer_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbTransfer_Button3.CheckOnClick = False
		Me._tlbTransfer_Button4.Size = New System.Drawing.Size(75, 22)
		Me._tlbTransfer_Button4.AutoSize = False
		Me._tlbTransfer_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbTransfer_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbTransfer_Button4.CheckOnClick = False
		Me._tlbTransfer_Button4.Enabled = 0
		Me._tlbTransfer_Button4.Text = "Delete"
		Me._tlbTransfer_Button4.Name = "Delete"
		Me._tlbTransfer_Button4.ImageIndex = 18
		Me.tlbPlayer.ShowItemToolTips = True
		Me.tlbPlayer.Size = New System.Drawing.Size(110, 22)
		Me.tlbPlayer.Location = New System.Drawing.Point(283, 224)
		Me.tlbPlayer.TabIndex = 7
		Me.tlbPlayer.CanOverflow = False
		Me.tlbPlayer.ImageList = imgList1
		Me.tlbPlayer.Name = "tlbPlayer"
		Me._tlbPlayer_Button1.Size = New System.Drawing.Size(50, 22)
		Me._tlbPlayer_Button1.AutoSize = False
		Me._tlbPlayer_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbPlayer_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbPlayer_Button1.CheckOnClick = False
		Me._tlbPlayer_Button1.Text = "Play"
		Me._tlbPlayer_Button1.Name = "Play"
		Me._tlbPlayer_Button1.ImageIndex = 6
		Me._tlbPlayer_Button2.Size = New System.Drawing.Size(50, 22)
		Me._tlbPlayer_Button2.AutoSize = False
		Me._tlbPlayer_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tlbPlayer_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tlbPlayer_Button2.CheckOnClick = False
		Me._tlbPlayer_Button2.Text = "Stop"
		Me._tlbPlayer_Button2.Name = "Stop"
		Me._tlbPlayer_Button2.ImageIndex = 11
		Me.stbp.Size = New System.Drawing.Size(89, 17)
		Me.stbp.Location = New System.Drawing.Point(104, 424)
		Me.stbp.TabIndex = 6
		Me.stbp.Name = "stbp"
		ftvPC.OcxState = CType(resources.GetObject("ftvPC.OcxState"), System.Windows.Forms.AxHost.State)
		Me.ftvPC.Size = New System.Drawing.Size(273, 169)
		Me.ftvPC.Location = New System.Drawing.Point(8, 248)
		Me.ftvPC.TabIndex = 5
		Me.ftvPC.Name = "ftvPC"
		Me.stbMain.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.stbMain.Size = New System.Drawing.Size(673, 19)
		Me.stbMain.Location = New System.Drawing.Point(0, 419)
		Me.stbMain.TabIndex = 1
		Me.stbMain.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.stbMain.Name = "stbMain"
		Me._stbMain_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._stbMain_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._stbMain_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._stbMain_Panel1.Text = "Status"
		Me._stbMain_Panel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._stbMain_Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me._stbMain_Panel1.Size = New System.Drawing.Size(96, 19)
		Me._stbMain_Panel1.AutoSize = False
		Me._stbMain_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._stbMain_Panel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._stbMain_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._stbMain_Panel2.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._stbMain_Panel2.Margin = New System.Windows.Forms.Padding(0)
		Me._stbMain_Panel2.Size = New System.Drawing.Size(96, 19)
		Me._stbMain_Panel2.AutoSize = False
		Me._stbMain_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._stbMain_Panel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._stbMain_Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._stbMain_Panel3.Text = "Disconnected"
		Me._stbMain_Panel3.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._stbMain_Panel3.Margin = New System.Windows.Forms.Padding(0)
		Me._stbMain_Panel3.Size = New System.Drawing.Size(96, 19)
		Me._stbMain_Panel3.AutoSize = False
		Me._stbMain_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._stbMain_Panel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._stbMain_Panel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._stbMain_Panel4.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._stbMain_Panel4.Margin = New System.Windows.Forms.Padding(0)
		Me._stbMain_Panel4.Size = New System.Drawing.Size(96, 19)
		Me._stbMain_Panel4.AutoSize = False
		Me._stbMain_Panel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._stbMain_Panel5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._stbMain_Panel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._stbMain_Panel5.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._stbMain_Panel5.Margin = New System.Windows.Forms.Padding(0)
		Me._stbMain_Panel5.Size = New System.Drawing.Size(96, 19)
		Me._stbMain_Panel5.AutoSize = False
		Me.imgList1.ImageSize = New System.Drawing.Size(16, 16)
		Me.imgList1.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.imgList1.ImageStream = CType(resources.GetObject("imgList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgList1.Images.SetKeyName(0, "")
		Me.imgList1.Images.SetKeyName(1, "")
		Me.imgList1.Images.SetKeyName(2, "")
		Me.imgList1.Images.SetKeyName(3, "")
		Me.imgList1.Images.SetKeyName(4, "")
		Me.imgList1.Images.SetKeyName(5, "")
		Me.imgList1.Images.SetKeyName(6, "")
		Me.imgList1.Images.SetKeyName(7, "")
		Me.imgList1.Images.SetKeyName(8, "")
		Me.imgList1.Images.SetKeyName(9, "")
		Me.imgList1.Images.SetKeyName(10, "")
		Me.imgList1.Images.SetKeyName(11, "")
		Me.imgList1.Images.SetKeyName(12, "")
		Me.imgList1.Images.SetKeyName(13, "")
		Me.imgList1.Images.SetKeyName(14, "")
		Me.imgList1.Images.SetKeyName(15, "")
		Me.imgList1.Images.SetKeyName(16, "")
		Me.imgList1.Images.SetKeyName(17, "")
		Me.imgList1.Images.SetKeyName(18, "")
		Me.imgList1.Images.SetKeyName(19, "")
		Me.lvPC.Size = New System.Drawing.Size(382, 169)
		Me.lvPC.Location = New System.Drawing.Point(283, 248)
		Me.lvPC.TabIndex = 2
		Me.lvPC.View = System.Windows.Forms.View.Details
		Me.lvPC.LabelEdit = False
		Me.lvPC.LabelWrap = True
		Me.lvPC.HideSelection = True
		Me.lvPC.Checkboxes = True
		Me.lvPC.FullRowSelect = True
		Me.lvPC.SmallImageList = imgList1
		Me.lvPC.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvPC.BackColor = System.Drawing.SystemColors.Window
		Me.lvPC.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lvPC.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lvPC.Name = "lvPC"
		Me._lvPC_ColumnHeader_1.Text = "Name"
		Me._lvPC_ColumnHeader_1.Width = 287
		Me._lvPC_ColumnHeader_2.Text = "Status/Bitrate"
		Me._lvPC_ColumnHeader_2.Width = 159
		Me._lvPC_ColumnHeader_3.Text = "Size"
		Me._lvPC_ColumnHeader_3.Width = 170
		Me.lvXbox.Size = New System.Drawing.Size(382, 175)
		Me.lvXbox.Location = New System.Drawing.Point(283, 47)
		Me.lvXbox.TabIndex = 3
		Me.lvXbox.View = System.Windows.Forms.View.Details
		Me.lvXbox.LabelEdit = False
		Me.lvXbox.LabelWrap = True
		Me.lvXbox.HideSelection = True
		Me.lvXbox.Checkboxes = True
		Me.lvXbox.FullRowSelect = True
		Me.lvXbox.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvXbox.BackColor = System.Drawing.SystemColors.Window
		Me.lvXbox.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lvXbox.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lvXbox.Name = "lvXbox"
		Me._lvXbox_ColumnHeader_1.Text = "Name"
		Me._lvXbox_ColumnHeader_1.Width = 18
		Me._lvXbox_ColumnHeader_2.Text = "Time"
		Me._lvXbox_ColumnHeader_2.Width = 170
		Me._lvXbox_ColumnHeader_3.Text = "Path"
		Me._lvXbox_ColumnHeader_3.Width = 0
		Me._lvXbox_ColumnHeader_4.Text = "ID"
		Me._lvXbox_ColumnHeader_4.Width = 0
		Me.tvXbox.CausesValidation = True
		Me.tvXbox.Size = New System.Drawing.Size(273, 199)
		Me.tvXbox.Location = New System.Drawing.Point(8, 47)
		Me.tvXbox.TabIndex = 4
		Me.tvXbox.Indent = 37
		Me.tvXbox.LabelEdit = False
		Me.tvXbox.ImageList = imgList1
		Me.tvXbox.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tvXbox.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.tvXbox.Name = "tvXbox"
		Me.tbMain.ShowItemToolTips = True
		Me.tbMain.Dock = System.Windows.Forms.DockStyle.Top
		Me.tbMain.Size = New System.Drawing.Size(673, 38)
		Me.tbMain.Location = New System.Drawing.Point(0, 0)
		Me.tbMain.TabIndex = 0
		Me.tbMain.ImageList = imgList1
		Me.tbMain.Name = "tbMain"
		Me._tbMain_Button1.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button1.AutoSize = False
		Me._tbMain_Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button1.CheckOnClick = False
		Me._tbMain_Button1.Text = "Connect"
		Me._tbMain_Button1.Name = "Connect"
		Me._tbMain_Button1.ImageIndex = 1
		Me._tbMain_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button2.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button2.AutoSize = False
		Me._tbMain_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button2.CheckOnClick = False
		Me._tbMain_Button2.Enabled = 0
		Me._tbMain_Button2.Text = "Close"
		Me._tbMain_Button2.Name = "Close"
		Me._tbMain_Button2.ImageIndex = 2
		Me._tbMain_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button3.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button3.AutoSize = False
		Me._tbMain_Button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button3.CheckOnClick = False
		Me._tbMain_Button3.ImageIndex = 4
		Me._tbMain_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button4.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button4.AutoSize = False
		Me._tbMain_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button4.CheckOnClick = False
		Me._tbMain_Button4.Enabled = 0
		Me._tbMain_Button4.Text = "Add"
		Me._tbMain_Button4.Name = "Add"
		Me._tbMain_Button4.ImageIndex = 19
		Me._tbMain_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button5.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button5.AutoSize = False
		Me._tbMain_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button5.CheckOnClick = False
		Me._tbMain_Button5.Enabled = 0
		Me._tbMain_Button5.Text = "Remove"
		Me._tbMain_Button5.Name = "Remove"
		Me._tbMain_Button5.ImageIndex = 18
		Me._tbMain_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button6.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button6.AutoSize = False
		Me._tbMain_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button6.CheckOnClick = False
		Me._tbMain_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button7.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button7.AutoSize = False
		Me._tbMain_Button7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button7.CheckOnClick = False
		Me._tbMain_Button7.Text = "Search"
		Me._tbMain_Button7.Name = "Search"
		Me._tbMain_Button7.ImageIndex = 10
		Me._tbMain_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button8.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button8.AutoSize = False
		Me._tbMain_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button8.CheckOnClick = False
		Me._tbMain_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button9.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button9.AutoSize = False
		Me._tbMain_Button9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button9.CheckOnClick = False
		Me._tbMain_Button9.Text = "Options"
		Me._tbMain_Button9.Name = "Options"
		Me._tbMain_Button9.ImageIndex = 4
		Me._tbMain_Button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button10.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button10.AutoSize = False
		Me._tbMain_Button10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button10.CheckOnClick = False
		Me._tbMain_Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me._tbMain_Button11.Size = New System.Drawing.Size(48, 37)
		Me._tbMain_Button11.AutoSize = False
		Me._tbMain_Button11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._tbMain_Button11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._tbMain_Button11.CheckOnClick = False
		Me._tbMain_Button11.Text = "About"
		Me._tbMain_Button11.Name = "About"
		Me._tbMain_Button11.ImageIndex = 5
		Me._tbMain_Button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.tlbXBOX.Name = "tlbXBOX"
		Me.tlbXBOX.Text = "mnuXbox"
		Me.tlbXBOX.Checked = False
		Me.tlbXBOX.Enabled = True
		Me.tlbXBOX.Visible = True
		Me.mnuPatch.Name = "mnuPatch"
		Me.mnuPatch.Text = "Game Patcher"
		Me.mnuPatch.Enabled = False
		Me.mnuPatch.Checked = False
		Me.mnuPatch.Visible = True
		Me.mnusp7.Enabled = True
		Me.mnusp7.Visible = True
		Me.mnusp7.Name = "mnusp7"
		Me.mnuEDrive.Name = "mnuEDrive"
		Me.mnuEDrive.Text = "E Drive (Normal)"
		Me.mnuEDrive.Checked = True
		Me.mnuEDrive.Enabled = False
		Me.mnuEDrive.Visible = True
		Me.mnuFDrive.Name = "mnuFDrive"
		Me.mnuFDrive.Text = "F Drive (Extend)"
		Me.mnuFDrive.Enabled = False
		Me.mnuFDrive.Checked = False
		Me.mnuFDrive.Visible = True
		Me.mnuLVPC.Name = "mnuLVPC"
		Me.mnuLVPC.Text = "lvPCMenu"
		Me.mnuLVPC.Checked = False
		Me.mnuLVPC.Enabled = True
		Me.mnuLVPC.Visible = True
		Me.mnuPCSelAll.Name = "mnuPCSelAll"
		Me.mnuPCSelAll.Text = "Select All"
		Me.mnuPCSelAll.Checked = False
		Me.mnuPCSelAll.Enabled = True
		Me.mnuPCSelAll.Visible = True
		Me.mnuPCUnSelALL.Name = "mnuPCUnSelALL"
		Me.mnuPCUnSelALL.Text = "UnSelect All"
		Me.mnuPCUnSelALL.Checked = False
		Me.mnuPCUnSelALL.Enabled = True
		Me.mnuPCUnSelALL.Visible = True
		Me.mnuSongList.Name = "mnuSongList"
		Me.mnuSongList.Text = "SongListMNU"
		Me.mnuSongList.Checked = False
		Me.mnuSongList.Enabled = True
		Me.mnuSongList.Visible = True
		Me.mnuSelAll.Name = "mnuSelAll"
		Me.mnuSelAll.Text = "Select All"
		Me.mnuSelAll.Checked = False
		Me.mnuSelAll.Enabled = True
		Me.mnuSelAll.Visible = True
		Me.mnuUnSel.Name = "mnuUnSel"
		Me.mnuUnSel.Text = "UnSelect All"
		Me.mnuUnSel.Checked = False
		Me.mnuUnSel.Enabled = True
		Me.mnuUnSel.Visible = True
		Me.sp12321.Enabled = True
		Me.sp12321.Visible = True
		Me.sp12321.Name = "sp12321"
		Me.mnuSLDelete.Name = "mnuSLDelete"
		Me.mnuSLDelete.Text = "Delete"
		Me.mnuSLDelete.Enabled = False
		Me.mnuSLDelete.Checked = False
		Me.mnuSLDelete.Visible = True
		Me.mnuSLRename.Name = "mnuSLRename"
		Me.mnuSLRename.Text = "Rename"
		Me.mnuSLRename.Enabled = False
		Me.mnuSLRename.Checked = False
		Me.mnuSLRename.Visible = True
		Me.mnusp3.Enabled = True
		Me.mnusp3.Visible = True
		Me.mnusp3.Name = "mnusp3"
		Me.mnuSLIDTag.Name = "mnuSLIDTag"
		Me.mnuSLIDTag.Text = "Edit ID Tag"
		Me.mnuSLIDTag.Enabled = False
		Me.mnuSLIDTag.Checked = False
		Me.mnuSLIDTag.Visible = True
		Me.mnuSoundTrack.Name = "mnuSoundTrack"
		Me.mnuSoundTrack.Text = "SoundTrackMNU"
		Me.mnuSoundTrack.Checked = False
		Me.mnuSoundTrack.Enabled = True
		Me.mnuSoundTrack.Visible = True
		Me.mnuAddSST.Name = "mnuAddSST"
		Me.mnuAddSST.Text = "Add"
		Me.mnuAddSST.Checked = False
		Me.mnuAddSST.Enabled = True
		Me.mnuAddSST.Visible = True
		Me.mnuRemoveST.Name = "mnuRemoveST"
		Me.mnuRemoveST.Text = "Remove"
		Me.mnuRemoveST.Enabled = False
		Me.mnuRemoveST.Checked = False
		Me.mnuRemoveST.Visible = True
		Me.mnusp1.Enabled = True
		Me.mnusp1.Visible = True
		Me.mnusp1.Name = "mnusp1"
		Me.mnuRenameST.Name = "mnuRenameST"
		Me.mnuRenameST.Text = "Rename"
		Me.mnuRenameST.Enabled = False
		Me.mnuRenameST.Checked = False
		Me.mnuRenameST.Visible = True
		Me.mnuFile.Name = "mnuFile"
		Me.mnuFile.Text = "&File"
		Me.mnuFile.Checked = False
		Me.mnuFile.Enabled = True
		Me.mnuFile.Visible = True
		Me.mnuRConnect.Name = "mnuRConnect"
		Me.mnuRConnect.Text = "Connect"
		Me.mnuRConnect.Checked = False
		Me.mnuRConnect.Enabled = True
		Me.mnuRConnect.Visible = True
		Me.mnuDisconnect.Name = "mnuDisconnect"
		Me.mnuDisconnect.Text = "Disconnect"
		Me.mnuDisconnect.Checked = False
		Me.mnuDisconnect.Enabled = True
		Me.mnuDisconnect.Visible = True
		Me.mnusp2.Enabled = True
		Me.mnusp2.Visible = True
		Me.mnusp2.Name = "mnusp2"
		Me.mnuConnect.Name = "mnuConnect"
		Me.mnuConnect.Text = "Connect (Invisiable, For Connection)"
		Me.mnuConnect.Visible = False
		Me.mnuConnect.Checked = False
		Me.mnuConnect.Enabled = True
		Me.mnuExit.Name = "mnuExit"
		Me.mnuExit.Text = "Exit"
		Me.mnuExit.Checked = False
		Me.mnuExit.Enabled = True
		Me.mnuExit.Visible = True
		Me.mnuRSoundTracks.Name = "mnuRSoundTracks"
		Me.mnuRSoundTracks.Text = "&SoundTracks"
		Me.mnuRSoundTracks.Checked = False
		Me.mnuRSoundTracks.Enabled = True
		Me.mnuRSoundTracks.Visible = True
		Me.mnuRSTAdd.Name = "mnuRSTAdd"
		Me.mnuRSTAdd.Text = "Add"
		Me.mnuRSTAdd.Enabled = False
		Me.mnuRSTAdd.Checked = False
		Me.mnuRSTAdd.Visible = True
		Me.mnuRSTRemove.Name = "mnuRSTRemove"
		Me.mnuRSTRemove.Text = "Remove"
		Me.mnuRSTRemove.Enabled = False
		Me.mnuRSTRemove.Checked = False
		Me.mnuRSTRemove.Visible = True
		Me.mnuRSTRename.Name = "mnuRSTRename"
		Me.mnuRSTRename.Text = "Rename"
		Me.mnuRSTRename.Enabled = False
		Me.mnuRSTRename.Checked = False
		Me.mnuRSTRename.Visible = True
		Me.mnusp5.Enabled = True
		Me.mnusp5.Visible = True
		Me.mnusp5.Name = "mnusp5"
		Me.mnuImportST.Name = "mnuImportST"
		Me.mnuImportST.Text = "Import Folder as SoundTrack"
		Me.mnuImportST.Enabled = False
		Me.mnuImportST.Checked = False
		Me.mnuImportST.Visible = True
		Me.mnuSongS.Name = "mnuSongS"
		Me.mnuSongS.Text = "S&ongs"
		Me.mnuSongS.Checked = False
		Me.mnuSongS.Enabled = True
		Me.mnuSongS.Visible = True
		Me.mnuAddSongs.Name = "mnuAddSongs"
		Me.mnuAddSongs.Text = "Add Song(s)"
		Me.mnuAddSongs.Enabled = False
		Me.mnuAddSongs.Checked = False
		Me.mnuAddSongs.Visible = True
		Me.mnuSelFolder.Name = "mnuSelFolder"
		Me.mnuSelFolder.Text = "Import Folder"
		Me.mnuSelFolder.Enabled = False
		Me.mnuSelFolder.Checked = False
		Me.mnuSelFolder.Visible = True
		Me.mnusp6.Enabled = True
		Me.mnusp6.Visible = True
		Me.mnusp6.Name = "mnusp6"
		Me.mnuSongSearch.Name = "mnuSongSearch"
		Me.mnuSongSearch.Text = "Search"
		Me.mnuSongSearch.Checked = False
		Me.mnuSongSearch.Enabled = True
		Me.mnuSongSearch.Visible = True
		Me.mnuHelp.Name = "mnuHelp"
		Me.mnuHelp.Text = "&Help"
		Me.mnuHelp.Checked = False
		Me.mnuHelp.Enabled = True
		Me.mnuHelp.Visible = True
		Me.mnuAbout.Name = "mnuAbout"
		Me.mnuAbout.Text = "About"
		Me.mnuAbout.Checked = False
		Me.mnuAbout.Enabled = True
		Me.mnuAbout.Visible = True
		Me.Controls.Add(Command1)
		Me.Controls.Add(sockCDDB)
		Me.Controls.Add(tlbTransfer)
		Me.Controls.Add(tlbPlayer)
		Me.Controls.Add(stbp)
		Me.Controls.Add(ftvPC)
		Me.Controls.Add(stbMain)
		Me.Controls.Add(lvPC)
		Me.Controls.Add(lvXbox)
		Me.Controls.Add(tvXbox)
		Me.Controls.Add(tbMain)
		Me.tlbTransfer.Items.Add(_tlbTransfer_Button1)
		Me.tlbTransfer.Items.Add(_tlbTransfer_Button2)
		Me.tlbTransfer.Items.Add(_tlbTransfer_Button3)
		Me.tlbTransfer.Items.Add(_tlbTransfer_Button4)
		Me.tlbPlayer.Items.Add(_tlbPlayer_Button1)
		Me.tlbPlayer.Items.Add(_tlbPlayer_Button2)
		Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._stbMain_Panel1})
		Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._stbMain_Panel2})
		Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._stbMain_Panel3})
		Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._stbMain_Panel4})
		Me.stbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._stbMain_Panel5})
		Me.lvPC.Columns.Add(_lvPC_ColumnHeader_1)
		Me.lvPC.Columns.Add(_lvPC_ColumnHeader_2)
		Me.lvPC.Columns.Add(_lvPC_ColumnHeader_3)
		Me.lvXbox.Columns.Add(_lvXbox_ColumnHeader_1)
		Me.lvXbox.Columns.Add(_lvXbox_ColumnHeader_2)
		Me.lvXbox.Columns.Add(_lvXbox_ColumnHeader_3)
		Me.lvXbox.Columns.Add(_lvXbox_ColumnHeader_4)
		Me.tbMain.Items.Add(_tbMain_Button1)
		Me.tbMain.Items.Add(_tbMain_Button2)
		Me.tbMain.Items.Add(_tbMain_Button3)
		Me.tbMain.Items.Add(_tbMain_Button4)
		Me.tbMain.Items.Add(_tbMain_Button5)
		Me.tbMain.Items.Add(_tbMain_Button6)
		Me.tbMain.Items.Add(_tbMain_Button7)
		Me.tbMain.Items.Add(_tbMain_Button8)
		Me.tbMain.Items.Add(_tbMain_Button9)
		Me.tbMain.Items.Add(_tbMain_Button10)
		Me.tbMain.Items.Add(_tbMain_Button11)
		CType(Me.ftvPC, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.sockCDDB, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.tlbXBOX, Me.mnuLVPC, Me.mnuSongList, Me.mnuSoundTrack, Me.mnuFile, Me.mnuRSoundTracks, Me.mnuSongS, Me.mnuHelp})
		tlbXBOX.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuPatch, Me.mnusp7, Me.mnuEDrive, Me.mnuFDrive})
		mnuLVPC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuPCSelAll, Me.mnuPCUnSelALL})
		mnuSongList.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuSelAll, Me.mnuUnSel, Me.sp12321, Me.mnuSLDelete, Me.mnuSLRename, Me.mnusp3, Me.mnuSLIDTag})
		mnuSoundTrack.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuAddSST, Me.mnuRemoveST, Me.mnusp1, Me.mnuRenameST})
		mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuRConnect, Me.mnuDisconnect, Me.mnusp2, Me.mnuConnect, Me.mnuExit})
		mnuRSoundTracks.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuRSTAdd, Me.mnuRSTRemove, Me.mnuRSTRename, Me.mnusp5, Me.mnuImportST})
		mnuSongS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuAddSongs, Me.mnuSelFolder, Me.mnusp6, Me.mnuSongSearch})
		mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuAbout})
		Me.Controls.Add(MainMenu1)
		Me.tlbTransfer.ResumeLayout(False)
		Me.tlbPlayer.ResumeLayout(False)
		Me.stbMain.ResumeLayout(False)
		Me.lvPC.ResumeLayout(False)
		Me.lvXbox.ResumeLayout(False)
		Me.tbMain.ResumeLayout(False)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class