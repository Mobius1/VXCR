<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
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
	Public WithEvents cmdDone As System.Windows.Forms.Button
	Public WithEvents _Line1_5 As System.Windows.Forms.Label
	Public WithEvents _Line1_4 As System.Windows.Forms.Label
	Public WithEvents picnob As System.Windows.Forms.Panel
	Public WithEvents lvOptions As System.Windows.Forms.ListView
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents _Line1_0 As System.Windows.Forms.Label
	Public WithEvents _Line1_1 As System.Windows.Forms.Label
	Public WithEvents lblAuoConnect As System.Windows.Forms.Label
	Public WithEvents lblTempFld As System.Windows.Forms.Label
	Public WithEvents lblDst As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents chkAutoConnect As System.Windows.Forms.CheckBox
	Public WithEvents txtIP As System.Windows.Forms.TextBox
	Public WithEvents txtTempFld As System.Windows.Forms.TextBox
	Public WithEvents cmdSelFld As System.Windows.Forms.Button
	Public WithEvents _SSTab_TabPage0 As System.Windows.Forms.TabPage
	Public WithEvents _Line1_10 As System.Windows.Forms.Label
	Public WithEvents _Line1_9 As System.Windows.Forms.Label
	Public WithEvents lblFileType As System.Windows.Forms.Label
	Public WithEvents lblBitRates As System.Windows.Forms.Label
	Public WithEvents cmdUnselect As System.Windows.Forms.Button
	Public WithEvents chkMP3 As System.Windows.Forms.CheckBox
	Public WithEvents chkMp2 As System.Windows.Forms.CheckBox
	Public WithEvents chkMp1 As System.Windows.Forms.CheckBox
	Public WithEvents chkWMA As System.Windows.Forms.CheckBox
	Public WithEvents chkOGG As System.Windows.Forms.CheckBox
	Public WithEvents chkWAV As System.Windows.Forms.CheckBox
	Public WithEvents cmdSelectAll As System.Windows.Forms.Button
	Public WithEvents opt128 As System.Windows.Forms.RadioButton
	Public WithEvents opt160 As System.Windows.Forms.RadioButton
	Public WithEvents opt192 As System.Windows.Forms.RadioButton
	Public WithEvents opt256 As System.Windows.Forms.RadioButton
	Public WithEvents optSmart As System.Windows.Forms.RadioButton
	Public WithEvents _SSTab_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents lblinfo As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents chkVDrive As System.Windows.Forms.CheckBox
	Public WithEvents _SSTab_TabPage2 As System.Windows.Forms.TabPage
	Public WithEvents chkAutoCDDB As System.Windows.Forms.CheckBox
	Public WithEvents _SSTab_TabPage3 As System.Windows.Forms.TabPage
	Public WithEvents _Line1_8 As System.Windows.Forms.Label
	Public WithEvents lblIdTags As System.Windows.Forms.Label
	Public WithEvents imgRB As System.Windows.Forms.PictureBox
	Public WithEvents _Line1_7 As System.Windows.Forms.Label
	Public WithEvents chkManualName As System.Windows.Forms.CheckBox
	Public WithEvents chkShowLocalBitrate As System.Windows.Forms.CheckBox
	Public WithEvents optFileName As System.Windows.Forms.RadioButton
	Public WithEvents _optIDstuff_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optIDstuff_1 As System.Windows.Forms.RadioButton
	Public WithEvents Picture2 As System.Windows.Forms.Panel
	Public WithEvents _SSTab_TabPage4 As System.Windows.Forms.TabPage
	Public WithEvents SSTab As System.Windows.Forms.TabControl
	Public WithEvents _Line1_6 As System.Windows.Forms.Label
	Public WithEvents _Line1_3 As System.Windows.Forms.Label
	Public WithEvents _Line1_2 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents optIDstuff As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptions))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdDone = New System.Windows.Forms.Button
		Me.picnob = New System.Windows.Forms.Panel
		Me._Line1_5 = New System.Windows.Forms.Label
		Me._Line1_4 = New System.Windows.Forms.Label
		Me.lvOptions = New System.Windows.Forms.ListView
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.SSTab = New System.Windows.Forms.TabControl
		Me._SSTab_TabPage0 = New System.Windows.Forms.TabPage
		Me._Line1_0 = New System.Windows.Forms.Label
		Me._Line1_1 = New System.Windows.Forms.Label
		Me.lblAuoConnect = New System.Windows.Forms.Label
		Me.lblTempFld = New System.Windows.Forms.Label
		Me.lblDst = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.chkAutoConnect = New System.Windows.Forms.CheckBox
		Me.txtIP = New System.Windows.Forms.TextBox
		Me.txtTempFld = New System.Windows.Forms.TextBox
		Me.cmdSelFld = New System.Windows.Forms.Button
		Me._SSTab_TabPage1 = New System.Windows.Forms.TabPage
		Me._Line1_10 = New System.Windows.Forms.Label
		Me._Line1_9 = New System.Windows.Forms.Label
		Me.lblFileType = New System.Windows.Forms.Label
		Me.lblBitRates = New System.Windows.Forms.Label
		Me.cmdUnselect = New System.Windows.Forms.Button
		Me.chkMP3 = New System.Windows.Forms.CheckBox
		Me.chkMp2 = New System.Windows.Forms.CheckBox
		Me.chkMp1 = New System.Windows.Forms.CheckBox
		Me.chkWMA = New System.Windows.Forms.CheckBox
		Me.chkOGG = New System.Windows.Forms.CheckBox
		Me.chkWAV = New System.Windows.Forms.CheckBox
		Me.cmdSelectAll = New System.Windows.Forms.Button
		Me.opt128 = New System.Windows.Forms.RadioButton
		Me.opt160 = New System.Windows.Forms.RadioButton
		Me.opt192 = New System.Windows.Forms.RadioButton
		Me.opt256 = New System.Windows.Forms.RadioButton
		Me.optSmart = New System.Windows.Forms.RadioButton
		Me._SSTab_TabPage2 = New System.Windows.Forms.TabPage
		Me.lblinfo = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.chkVDrive = New System.Windows.Forms.CheckBox
		Me._SSTab_TabPage3 = New System.Windows.Forms.TabPage
		Me.chkAutoCDDB = New System.Windows.Forms.CheckBox
		Me._SSTab_TabPage4 = New System.Windows.Forms.TabPage
		Me._Line1_8 = New System.Windows.Forms.Label
		Me.lblIdTags = New System.Windows.Forms.Label
		Me.imgRB = New System.Windows.Forms.PictureBox
		Me._Line1_7 = New System.Windows.Forms.Label
		Me.chkManualName = New System.Windows.Forms.CheckBox
		Me.chkShowLocalBitrate = New System.Windows.Forms.CheckBox
		Me.Picture2 = New System.Windows.Forms.Panel
		Me.optFileName = New System.Windows.Forms.RadioButton
		Me._optIDstuff_0 = New System.Windows.Forms.RadioButton
		Me._optIDstuff_1 = New System.Windows.Forms.RadioButton
		Me._Line1_6 = New System.Windows.Forms.Label
		Me._Line1_3 = New System.Windows.Forms.Label
		Me._Line1_2 = New System.Windows.Forms.Label
		Me.Line1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.optIDstuff = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.picnob.SuspendLayout()
		Me.SSTab.SuspendLayout()
		Me._SSTab_TabPage0.SuspendLayout()
		Me._SSTab_TabPage1.SuspendLayout()
		Me._SSTab_TabPage2.SuspendLayout()
		Me._SSTab_TabPage3.SuspendLayout()
		Me._SSTab_TabPage4.SuspendLayout()
		Me.Picture2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optIDstuff, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Virtual Xbox CD Ripper - Options"
		Me.ClientSize = New System.Drawing.Size(547, 403)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmOptions.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmOptions"
		Me.cmdDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDone.Text = "Done"
		Me.cmdDone.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDone.Size = New System.Drawing.Size(97, 25)
		Me.cmdDone.Location = New System.Drawing.Point(440, 368)
		Me.cmdDone.TabIndex = 21
		Me.cmdDone.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDone.CausesValidation = True
		Me.cmdDone.Enabled = True
		Me.cmdDone.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDone.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDone.TabStop = True
		Me.cmdDone.Name = "cmdDone"
		Me.picnob.Size = New System.Drawing.Size(385, 17)
		Me.picnob.Location = New System.Drawing.Point(162, 344)
		Me.picnob.TabIndex = 20
		Me.picnob.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.picnob.Dock = System.Windows.Forms.DockStyle.None
		Me.picnob.BackColor = System.Drawing.SystemColors.Control
		Me.picnob.CausesValidation = True
		Me.picnob.Enabled = True
		Me.picnob.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picnob.Cursor = System.Windows.Forms.Cursors.Default
		Me.picnob.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picnob.TabStop = True
		Me.picnob.Visible = True
		Me.picnob.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picnob.Name = "picnob"
		Me._Line1_5.BackColor = System.Drawing.Color.White
		Me._Line1_5.Visible = True
		Me._Line1_5.Location = New System.Drawing.Point(0, 11)
		Me._Line1_5.Size = New System.Drawing.Size(384, 1)
		Me._Line1_5.Name = "_Line1_5"
		Me._Line1_4.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_4.Visible = True
		Me._Line1_4.Location = New System.Drawing.Point(0, 10)
		Me._Line1_4.Size = New System.Drawing.Size(384, 1)
		Me._Line1_4.Name = "_Line1_4"
		Me.lvOptions.Size = New System.Drawing.Size(161, 297)
		Me.lvOptions.Location = New System.Drawing.Point(0, 58)
		Me.lvOptions.TabIndex = 7
		Me.lvOptions.View = System.Windows.Forms.View.List
		Me.lvOptions.LabelWrap = True
		Me.lvOptions.HideSelection = True
		Me.lvOptions.FullRowSelect = True
		Me.lvOptions.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvOptions.BackColor = System.Drawing.SystemColors.Window
		Me.lvOptions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lvOptions.LabelEdit = True
		Me.lvOptions.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lvOptions.Name = "lvOptions"
		Me.Picture1.Size = New System.Drawing.Size(552, 56)
		Me.Picture1.Location = New System.Drawing.Point(0, 0)
		Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
		Me.Picture1.TabIndex = 8
		Me.Picture1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.BackColor = System.Drawing.SystemColors.Control
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture1.Name = "Picture1"
		Me.SSTab.Size = New System.Drawing.Size(409, 296)
		Me.SSTab.Location = New System.Drawing.Point(160, 57)
		Me.SSTab.TabIndex = 0
		Me.SSTab.TabStop = False
		Me.SSTab.Alignment = System.Windows.Forms.TabAlignment.Right
		Me.SSTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
		Me.SSTab.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SSTab.Name = "SSTab"
		Me._SSTab_TabPage0.Text = "General"
		Me._Line1_0.BackColor = System.Drawing.Color.White
		Me._Line1_0.Visible = True
		Me._Line1_0.Location = New System.Drawing.Point(8, 106)
		Me._Line1_0.Size = New System.Drawing.Size(360, 1)
		Me._Line1_0.Name = "_Line1_0"
		Me._Line1_1.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_1.Visible = True
		Me._Line1_1.Location = New System.Drawing.Point(8, 106)
		Me._Line1_1.Size = New System.Drawing.Size(360, 1)
		Me._Line1_1.Name = "_Line1_1"
		Me.lblAuoConnect.Text = "If you would like VXCR to attempt to connect to an Xbox during the load, please enter the information below. (Doesnt work yet)"
		Me.lblAuoConnect.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAuoConnect.Size = New System.Drawing.Size(361, 33)
		Me.lblAuoConnect.Location = New System.Drawing.Point(16, 8)
		Me.lblAuoConnect.TabIndex = 1
		Me.lblAuoConnect.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAuoConnect.BackColor = System.Drawing.Color.Transparent
		Me.lblAuoConnect.Enabled = True
		Me.lblAuoConnect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAuoConnect.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAuoConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAuoConnect.UseMnemonic = True
		Me.lblAuoConnect.Visible = True
		Me.lblAuoConnect.AutoSize = False
		Me.lblAuoConnect.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAuoConnect.Name = "lblAuoConnect"
		Me.lblTempFld.Text = "Please Select where you would like VXCR to store Temporary Files."
		Me.lblTempFld.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTempFld.Size = New System.Drawing.Size(329, 25)
		Me.lblTempFld.Location = New System.Drawing.Point(16, 112)
		Me.lblTempFld.TabIndex = 22
		Me.lblTempFld.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTempFld.BackColor = System.Drawing.Color.Transparent
		Me.lblTempFld.Enabled = True
		Me.lblTempFld.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTempFld.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTempFld.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTempFld.UseMnemonic = True
		Me.lblTempFld.Visible = True
		Me.lblTempFld.AutoSize = False
		Me.lblTempFld.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTempFld.Name = "lblTempFld"
		Me.lblDst.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDst.Text = "Folder:"
		Me.lblDst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDst.Size = New System.Drawing.Size(49, 17)
		Me.lblDst.Location = New System.Drawing.Point(16, 138)
		Me.lblDst.TabIndex = 24
		Me.lblDst.BackColor = System.Drawing.SystemColors.Control
		Me.lblDst.Enabled = True
		Me.lblDst.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDst.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDst.UseMnemonic = True
		Me.lblDst.Visible = True
		Me.lblDst.AutoSize = False
		Me.lblDst.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDst.Name = "lblDst"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = "IP:"
		Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Size = New System.Drawing.Size(49, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 72)
		Me.Label2.TabIndex = 33
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.chkAutoConnect.Text = "Attempt To Connect to Xbox During Load"
		Me.chkAutoConnect.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkAutoConnect.Size = New System.Drawing.Size(289, 17)
		Me.chkAutoConnect.Location = New System.Drawing.Point(72, 48)
		Me.chkAutoConnect.TabIndex = 2
		Me.chkAutoConnect.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAutoConnect.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAutoConnect.BackColor = System.Drawing.SystemColors.Control
		Me.chkAutoConnect.CausesValidation = True
		Me.chkAutoConnect.Enabled = True
		Me.chkAutoConnect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkAutoConnect.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAutoConnect.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAutoConnect.TabStop = True
		Me.chkAutoConnect.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAutoConnect.Visible = True
		Me.chkAutoConnect.Name = "chkAutoConnect"
		Me.txtIP.AutoSize = False
		Me.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtIP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtIP.Size = New System.Drawing.Size(249, 21)
		Me.txtIP.Location = New System.Drawing.Point(72, 72)
		Me.txtIP.TabIndex = 3
		Me.txtIP.Text = "127.0.0.1"
		Me.txtIP.AcceptsReturn = True
		Me.txtIP.BackColor = System.Drawing.SystemColors.Window
		Me.txtIP.CausesValidation = True
		Me.txtIP.Enabled = True
		Me.txtIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtIP.HideSelection = True
		Me.txtIP.ReadOnly = False
		Me.txtIP.Maxlength = 0
		Me.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtIP.MultiLine = False
		Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtIP.TabStop = True
		Me.txtIP.Visible = True
		Me.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtIP.Name = "txtIP"
		Me.txtTempFld.AutoSize = False
		Me.txtTempFld.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTempFld.Size = New System.Drawing.Size(249, 21)
		Me.txtTempFld.Location = New System.Drawing.Point(72, 136)
		Me.txtTempFld.TabIndex = 23
		Me.txtTempFld.AcceptsReturn = True
		Me.txtTempFld.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTempFld.BackColor = System.Drawing.SystemColors.Window
		Me.txtTempFld.CausesValidation = True
		Me.txtTempFld.Enabled = True
		Me.txtTempFld.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTempFld.HideSelection = True
		Me.txtTempFld.ReadOnly = False
		Me.txtTempFld.Maxlength = 0
		Me.txtTempFld.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTempFld.MultiLine = False
		Me.txtTempFld.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTempFld.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTempFld.TabStop = True
		Me.txtTempFld.Visible = True
		Me.txtTempFld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTempFld.Name = "txtTempFld"
		Me.cmdSelFld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelFld.Text = "..."
		Me.cmdSelFld.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSelFld.Size = New System.Drawing.Size(17, 19)
		Me.cmdSelFld.Location = New System.Drawing.Point(328, 136)
		Me.cmdSelFld.TabIndex = 25
		Me.cmdSelFld.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelFld.CausesValidation = True
		Me.cmdSelFld.Enabled = True
		Me.cmdSelFld.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelFld.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelFld.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelFld.TabStop = True
		Me.cmdSelFld.Name = "cmdSelFld"
		Me._SSTab_TabPage1.Text = "Formats"
		Me._Line1_10.Visible = True
		Me._Line1_10.BackColor = System.Drawing.Color.Red
		Me._Line1_10.ForeColor = System.Drawing.Color.Black
		Me._Line1_10.Location = New System.Drawing.Point(-4984, 160)
		Me._Line1_10.Size = New System.Drawing.Size(352, 1)
		Me._Line1_10.Text = "_Line1_10"
		Me._Line1_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me._Line1_10.Name = "_Line1_10"
		Me._Line1_9.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_9.Visible = True
		Me._Line1_9.Location = New System.Drawing.Point(-4984, 160)
		Me._Line1_9.Size = New System.Drawing.Size(352, 1)
		Me._Line1_9.Name = "_Line1_9"
		Me.lblFileType.Text = "Please select which files you would like Virtual Xbox CD Ripper to list when you select a Root directory."
		Me.lblFileType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFileType.Size = New System.Drawing.Size(361, 33)
		Me.lblFileType.Location = New System.Drawing.Point(8, 8)
		Me.lblFileType.TabIndex = 9
		Me.lblFileType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFileType.BackColor = System.Drawing.Color.Transparent
		Me.lblFileType.Enabled = True
		Me.lblFileType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFileType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFileType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFileType.UseMnemonic = True
		Me.lblFileType.Visible = True
		Me.lblFileType.AutoSize = False
		Me.lblFileType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFileType.Name = "lblFileType"
		Me.lblBitRates.Text = "Virtual Xbox CD Ripper automaticly converts Audio files to WMA format.  Please Select at which BitRate you would like to have your WMA files."
		Me.lblBitRates.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblBitRates.Size = New System.Drawing.Size(353, 33)
		Me.lblBitRates.Location = New System.Drawing.Point(16, 168)
		Me.lblBitRates.TabIndex = 27
		Me.lblBitRates.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblBitRates.BackColor = System.Drawing.Color.Transparent
		Me.lblBitRates.Enabled = True
		Me.lblBitRates.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblBitRates.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblBitRates.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblBitRates.UseMnemonic = True
		Me.lblBitRates.Visible = True
		Me.lblBitRates.AutoSize = False
		Me.lblBitRates.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblBitRates.Name = "lblBitRates"
		Me.cmdUnselect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUnselect.Text = "UnSelect All"
		Me.cmdUnselect.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUnselect.Size = New System.Drawing.Size(89, 25)
		Me.cmdUnselect.Location = New System.Drawing.Point(264, 56)
		Me.cmdUnselect.TabIndex = 17
		Me.cmdUnselect.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUnselect.CausesValidation = True
		Me.cmdUnselect.Enabled = True
		Me.cmdUnselect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUnselect.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUnselect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUnselect.TabStop = True
		Me.cmdUnselect.Name = "cmdUnselect"
		Me.chkMP3.Text = "MP3"
		Me.chkMP3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkMP3.Size = New System.Drawing.Size(73, 17)
		Me.chkMP3.Location = New System.Drawing.Point(48, 56)
		Me.chkMP3.TabIndex = 10
		Me.chkMP3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMP3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMP3.BackColor = System.Drawing.SystemColors.Control
		Me.chkMP3.CausesValidation = True
		Me.chkMP3.Enabled = True
		Me.chkMP3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkMP3.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMP3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMP3.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMP3.TabStop = True
		Me.chkMP3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMP3.Visible = True
		Me.chkMP3.Name = "chkMP3"
		Me.chkMp2.Text = "MP2"
		Me.chkMp2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkMp2.Size = New System.Drawing.Size(81, 17)
		Me.chkMp2.Location = New System.Drawing.Point(96, 56)
		Me.chkMp2.TabIndex = 11
		Me.chkMp2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMp2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMp2.BackColor = System.Drawing.SystemColors.Control
		Me.chkMp2.CausesValidation = True
		Me.chkMp2.Enabled = True
		Me.chkMp2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkMp2.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMp2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMp2.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMp2.TabStop = True
		Me.chkMp2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMp2.Visible = True
		Me.chkMp2.Name = "chkMp2"
		Me.chkMp1.Text = "MP1"
		Me.chkMp1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkMp1.Size = New System.Drawing.Size(65, 17)
		Me.chkMp1.Location = New System.Drawing.Point(152, 56)
		Me.chkMp1.TabIndex = 12
		Me.chkMp1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMp1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMp1.BackColor = System.Drawing.SystemColors.Control
		Me.chkMp1.CausesValidation = True
		Me.chkMp1.Enabled = True
		Me.chkMp1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkMp1.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMp1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMp1.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMp1.TabStop = True
		Me.chkMp1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMp1.Visible = True
		Me.chkMp1.Name = "chkMp1"
		Me.chkWMA.Text = "WMA (Windows Media Audio)"
		Me.chkWMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkWMA.Size = New System.Drawing.Size(177, 17)
		Me.chkWMA.Location = New System.Drawing.Point(48, 80)
		Me.chkWMA.TabIndex = 13
		Me.chkWMA.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkWMA.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkWMA.BackColor = System.Drawing.SystemColors.Control
		Me.chkWMA.CausesValidation = True
		Me.chkWMA.Enabled = True
		Me.chkWMA.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkWMA.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkWMA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkWMA.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkWMA.TabStop = True
		Me.chkWMA.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkWMA.Visible = True
		Me.chkWMA.Name = "chkWMA"
		Me.chkOGG.Text = "Ogg (Vorbis's Format)"
		Me.chkOGG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkOGG.Size = New System.Drawing.Size(177, 17)
		Me.chkOGG.Location = New System.Drawing.Point(48, 104)
		Me.chkOGG.TabIndex = 14
		Me.chkOGG.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOGG.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOGG.BackColor = System.Drawing.SystemColors.Control
		Me.chkOGG.CausesValidation = True
		Me.chkOGG.Enabled = True
		Me.chkOGG.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOGG.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOGG.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOGG.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOGG.TabStop = True
		Me.chkOGG.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOGG.Visible = True
		Me.chkOGG.Name = "chkOGG"
		Me.chkWAV.Text = "WAV (Uncompressed Audio)"
		Me.chkWAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkWAV.Size = New System.Drawing.Size(177, 17)
		Me.chkWAV.Location = New System.Drawing.Point(48, 128)
		Me.chkWAV.TabIndex = 15
		Me.chkWAV.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkWAV.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkWAV.BackColor = System.Drawing.SystemColors.Control
		Me.chkWAV.CausesValidation = True
		Me.chkWAV.Enabled = True
		Me.chkWAV.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkWAV.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkWAV.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkWAV.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkWAV.TabStop = True
		Me.chkWAV.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkWAV.Visible = True
		Me.chkWAV.Name = "chkWAV"
		Me.cmdSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelectAll.Text = "Select All"
		Me.cmdSelectAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSelectAll.Size = New System.Drawing.Size(89, 25)
		Me.cmdSelectAll.Location = New System.Drawing.Point(264, 80)
		Me.cmdSelectAll.TabIndex = 16
		Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelectAll.CausesValidation = True
		Me.cmdSelectAll.Enabled = True
		Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelectAll.TabStop = True
		Me.cmdSelectAll.Name = "cmdSelectAll"
		Me.opt128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt128.Text = "128 Kbps"
		Me.opt128.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.opt128.Size = New System.Drawing.Size(81, 14)
		Me.opt128.Location = New System.Drawing.Point(48, 200)
		Me.opt128.TabIndex = 28
		Me.opt128.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt128.BackColor = System.Drawing.SystemColors.Control
		Me.opt128.CausesValidation = True
		Me.opt128.Enabled = True
		Me.opt128.ForeColor = System.Drawing.SystemColors.ControlText
		Me.opt128.Cursor = System.Windows.Forms.Cursors.Default
		Me.opt128.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.opt128.Appearance = System.Windows.Forms.Appearance.Normal
		Me.opt128.TabStop = True
		Me.opt128.Checked = False
		Me.opt128.Visible = True
		Me.opt128.Name = "opt128"
		Me.opt160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt160.Text = "160 Kbps"
		Me.opt160.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.opt160.Size = New System.Drawing.Size(81, 14)
		Me.opt160.Location = New System.Drawing.Point(48, 216)
		Me.opt160.TabIndex = 29
		Me.opt160.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt160.BackColor = System.Drawing.SystemColors.Control
		Me.opt160.CausesValidation = True
		Me.opt160.Enabled = True
		Me.opt160.ForeColor = System.Drawing.SystemColors.ControlText
		Me.opt160.Cursor = System.Windows.Forms.Cursors.Default
		Me.opt160.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.opt160.Appearance = System.Windows.Forms.Appearance.Normal
		Me.opt160.TabStop = True
		Me.opt160.Checked = False
		Me.opt160.Visible = True
		Me.opt160.Name = "opt160"
		Me.opt192.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt192.Text = "192 Kbps"
		Me.opt192.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.opt192.Size = New System.Drawing.Size(81, 14)
		Me.opt192.Location = New System.Drawing.Point(48, 232)
		Me.opt192.TabIndex = 30
		Me.opt192.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt192.BackColor = System.Drawing.SystemColors.Control
		Me.opt192.CausesValidation = True
		Me.opt192.Enabled = True
		Me.opt192.ForeColor = System.Drawing.SystemColors.ControlText
		Me.opt192.Cursor = System.Windows.Forms.Cursors.Default
		Me.opt192.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.opt192.Appearance = System.Windows.Forms.Appearance.Normal
		Me.opt192.TabStop = True
		Me.opt192.Checked = False
		Me.opt192.Visible = True
		Me.opt192.Name = "opt192"
		Me.opt256.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt256.Text = "256 Kbps"
		Me.opt256.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.opt256.Size = New System.Drawing.Size(81, 14)
		Me.opt256.Location = New System.Drawing.Point(48, 248)
		Me.opt256.TabIndex = 31
		Me.opt256.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.opt256.BackColor = System.Drawing.SystemColors.Control
		Me.opt256.CausesValidation = True
		Me.opt256.Enabled = True
		Me.opt256.ForeColor = System.Drawing.SystemColors.ControlText
		Me.opt256.Cursor = System.Windows.Forms.Cursors.Default
		Me.opt256.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.opt256.Appearance = System.Windows.Forms.Appearance.Normal
		Me.opt256.TabStop = True
		Me.opt256.Checked = False
		Me.opt256.Visible = True
		Me.opt256.Name = "opt256"
		Me.optSmart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSmart.Text = "Smart Detection (Recommend)"
		Me.optSmart.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optSmart.Size = New System.Drawing.Size(209, 17)
		Me.optSmart.Location = New System.Drawing.Point(136, 200)
		Me.optSmart.TabIndex = 32
		Me.optSmart.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSmart.BackColor = System.Drawing.SystemColors.Control
		Me.optSmart.CausesValidation = True
		Me.optSmart.Enabled = True
		Me.optSmart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optSmart.Cursor = System.Windows.Forms.Cursors.Default
		Me.optSmart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optSmart.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optSmart.TabStop = True
		Me.optSmart.Checked = False
		Me.optSmart.Visible = True
		Me.optSmart.Name = "optSmart"
		Me._SSTab_TabPage2.Text = "Virtual Drive"
		Me.lblinfo.Text = "Virtual Drive will Emulate a new Hard Drive which will represent your Xbox's Sound Track Database. This feature will allow you to Drag 'n Drop Audio files from Internet Explorer to the Xbox!"
		Me.lblinfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblinfo.Size = New System.Drawing.Size(361, 49)
		Me.lblinfo.Location = New System.Drawing.Point(8, 10)
		Me.lblinfo.TabIndex = 4
		Me.lblinfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblinfo.BackColor = System.Drawing.Color.Transparent
		Me.lblinfo.Enabled = True
		Me.lblinfo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblinfo.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblinfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblinfo.UseMnemonic = True
		Me.lblinfo.Visible = True
		Me.lblinfo.AutoSize = False
		Me.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblinfo.Name = "lblinfo"
		Me.Label1.Text = "Doesnt work yet!"
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(257, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 88)
		Me.Label1.TabIndex = 38
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.chkVDrive.Text = "Enable Virtual Drive"
		Me.chkVDrive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkVDrive.Size = New System.Drawing.Size(161, 17)
		Me.chkVDrive.Location = New System.Drawing.Point(16, 66)
		Me.chkVDrive.TabIndex = 5
		Me.chkVDrive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkVDrive.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkVDrive.BackColor = System.Drawing.SystemColors.Control
		Me.chkVDrive.CausesValidation = True
		Me.chkVDrive.Enabled = True
		Me.chkVDrive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkVDrive.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkVDrive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkVDrive.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkVDrive.TabStop = True
		Me.chkVDrive.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkVDrive.Visible = True
		Me.chkVDrive.Name = "chkVDrive"
		Me._SSTab_TabPage3.Text = "CD Ripper"
		Me.chkAutoCDDB.Text = "Automaticly Check for CDDB"
		Me.chkAutoCDDB.Enabled = False
		Me.chkAutoCDDB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkAutoCDDB.Size = New System.Drawing.Size(225, 17)
		Me.chkAutoCDDB.Location = New System.Drawing.Point(16, 18)
		Me.chkAutoCDDB.TabIndex = 6
		Me.chkAutoCDDB.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAutoCDDB.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAutoCDDB.BackColor = System.Drawing.SystemColors.Control
		Me.chkAutoCDDB.CausesValidation = True
		Me.chkAutoCDDB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkAutoCDDB.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAutoCDDB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAutoCDDB.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAutoCDDB.TabStop = True
		Me.chkAutoCDDB.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAutoCDDB.Visible = True
		Me.chkAutoCDDB.Name = "chkAutoCDDB"
		Me._SSTab_TabPage4.Text = "ID Tags"
		Me._Line1_8.BackColor = System.Drawing.Color.White
		Me._Line1_8.Visible = True
		Me._Line1_8.Location = New System.Drawing.Point(-4992, 153)
		Me._Line1_8.Size = New System.Drawing.Size(360, 1)
		Me._Line1_8.Name = "_Line1_8"
		Me.lblIdTags.Text = "When Virtual Xbox CD Ripper Transfers files to the Xbox how would you like to name these files in the Xbox SoundTrack Database?"
		Me.lblIdTags.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblIdTags.Size = New System.Drawing.Size(361, 33)
		Me.lblIdTags.Location = New System.Drawing.Point(8, 8)
		Me.lblIdTags.TabIndex = 18
		Me.lblIdTags.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblIdTags.BackColor = System.Drawing.SystemColors.Control
		Me.lblIdTags.Enabled = True
		Me.lblIdTags.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblIdTags.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblIdTags.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblIdTags.UseMnemonic = True
		Me.lblIdTags.Visible = True
		Me.lblIdTags.AutoSize = False
		Me.lblIdTags.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblIdTags.Name = "lblIdTags"
		Me.imgRB.Size = New System.Drawing.Size(91, 66)
		Me.imgRB.Location = New System.Drawing.Point(32, 56)
		Me.imgRB.Image = CType(resources.GetObject("imgRB.Image"), System.Drawing.Image)
		Me.imgRB.Enabled = True
		Me.imgRB.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgRB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgRB.Visible = True
		Me.imgRB.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgRB.Name = "imgRB"
		Me._Line1_7.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_7.Visible = True
		Me._Line1_7.Location = New System.Drawing.Point(-4992, 152)
		Me._Line1_7.Size = New System.Drawing.Size(360, 1)
		Me._Line1_7.Name = "_Line1_7"
		Me.chkManualName.Text = "Allow me to Manually Enter Names before Upload"
		Me.chkManualName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkManualName.Size = New System.Drawing.Size(329, 17)
		Me.chkManualName.Location = New System.Drawing.Point(24, 160)
		Me.chkManualName.TabIndex = 19
		Me.chkManualName.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkManualName.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkManualName.BackColor = System.Drawing.SystemColors.Control
		Me.chkManualName.CausesValidation = True
		Me.chkManualName.Enabled = True
		Me.chkManualName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkManualName.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkManualName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkManualName.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkManualName.TabStop = True
		Me.chkManualName.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkManualName.Visible = True
		Me.chkManualName.Name = "chkManualName"
		Me.chkShowLocalBitrate.Text = "Show Local Music Files BitRate"
		Me.chkShowLocalBitrate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkShowLocalBitrate.Size = New System.Drawing.Size(337, 17)
		Me.chkShowLocalBitrate.Location = New System.Drawing.Point(24, 176)
		Me.chkShowLocalBitrate.TabIndex = 26
		Me.chkShowLocalBitrate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkShowLocalBitrate.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkShowLocalBitrate.BackColor = System.Drawing.SystemColors.Control
		Me.chkShowLocalBitrate.CausesValidation = True
		Me.chkShowLocalBitrate.Enabled = True
		Me.chkShowLocalBitrate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkShowLocalBitrate.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkShowLocalBitrate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkShowLocalBitrate.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkShowLocalBitrate.TabStop = True
		Me.chkShowLocalBitrate.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkShowLocalBitrate.Visible = True
		Me.chkShowLocalBitrate.Name = "chkShowLocalBitrate"
		Me.Picture2.Size = New System.Drawing.Size(225, 73)
		Me.Picture2.Location = New System.Drawing.Point(136, 56)
		Me.Picture2.TabIndex = 34
		Me.Picture2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Picture2.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture2.BackColor = System.Drawing.SystemColors.Control
		Me.Picture2.CausesValidation = True
		Me.Picture2.Enabled = True
		Me.Picture2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture2.TabStop = True
		Me.Picture2.Visible = True
		Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture2.Name = "Picture2"
		Me.optFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optFileName.Text = "Show File Name"
		Me.optFileName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optFileName.Size = New System.Drawing.Size(113, 17)
		Me.optFileName.Location = New System.Drawing.Point(8, 0)
		Me.optFileName.TabIndex = 37
		Me.optFileName.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optFileName.BackColor = System.Drawing.SystemColors.Control
		Me.optFileName.CausesValidation = True
		Me.optFileName.Enabled = True
		Me.optFileName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optFileName.Cursor = System.Windows.Forms.Cursors.Default
		Me.optFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optFileName.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optFileName.TabStop = True
		Me.optFileName.Checked = False
		Me.optFileName.Visible = True
		Me.optFileName.Name = "optFileName"
		Me._optIDstuff_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optIDstuff_0.Text = "ID Tag (Title Only)"
		Me._optIDstuff_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._optIDstuff_0.Size = New System.Drawing.Size(113, 17)
		Me._optIDstuff_0.Location = New System.Drawing.Point(8, 48)
		Me._optIDstuff_0.TabIndex = 36
		Me._optIDstuff_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optIDstuff_0.BackColor = System.Drawing.SystemColors.Control
		Me._optIDstuff_0.CausesValidation = True
		Me._optIDstuff_0.Enabled = True
		Me._optIDstuff_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optIDstuff_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optIDstuff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optIDstuff_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optIDstuff_0.TabStop = True
		Me._optIDstuff_0.Checked = False
		Me._optIDstuff_0.Visible = True
		Me._optIDstuff_0.Name = "_optIDstuff_0"
		Me._optIDstuff_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optIDstuff_1.Text = "ID Tag (Artist - Title)"
		Me._optIDstuff_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._optIDstuff_1.Size = New System.Drawing.Size(145, 17)
		Me._optIDstuff_1.Location = New System.Drawing.Point(8, 24)
		Me._optIDstuff_1.TabIndex = 35
		Me._optIDstuff_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optIDstuff_1.BackColor = System.Drawing.SystemColors.Control
		Me._optIDstuff_1.CausesValidation = True
		Me._optIDstuff_1.Enabled = True
		Me._optIDstuff_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optIDstuff_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optIDstuff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optIDstuff_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optIDstuff_1.TabStop = True
		Me._optIDstuff_1.Checked = False
		Me._optIDstuff_1.Visible = True
		Me._optIDstuff_1.Name = "_optIDstuff_1"
		Me._Line1_6.BackColor = System.Drawing.Color.White
		Me._Line1_6.Visible = True
		Me._Line1_6.Location = New System.Drawing.Point(0, 355)
		Me._Line1_6.Size = New System.Drawing.Size(320, 1)
		Me._Line1_6.Name = "_Line1_6"
		Me._Line1_3.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_3.Visible = True
		Me._Line1_3.Location = New System.Drawing.Point(0, 354)
		Me._Line1_3.Size = New System.Drawing.Size(176, 1)
		Me._Line1_3.Name = "_Line1_3"
		Me._Line1_2.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_2.Visible = True
		Me._Line1_2.Location = New System.Drawing.Point(0, 56)
		Me._Line1_2.Size = New System.Drawing.Size(568, 1)
		Me._Line1_2.Name = "_Line1_2"
		Me.Controls.Add(cmdDone)
		Me.Controls.Add(picnob)
		Me.Controls.Add(lvOptions)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(SSTab)
		Me.Controls.Add(_Line1_6)
		Me.Controls.Add(_Line1_3)
		Me.Controls.Add(_Line1_2)
		Me.picnob.Controls.Add(_Line1_5)
		Me.picnob.Controls.Add(_Line1_4)
		Me.SSTab.Controls.Add(_SSTab_TabPage0)
		Me.SSTab.Controls.Add(_SSTab_TabPage1)
		Me.SSTab.Controls.Add(_SSTab_TabPage2)
		Me.SSTab.Controls.Add(_SSTab_TabPage3)
		Me.SSTab.Controls.Add(_SSTab_TabPage4)
		Me._SSTab_TabPage0.Controls.Add(_Line1_0)
		Me._SSTab_TabPage0.Controls.Add(_Line1_1)
		Me._SSTab_TabPage0.Controls.Add(lblAuoConnect)
		Me._SSTab_TabPage0.Controls.Add(lblTempFld)
		Me._SSTab_TabPage0.Controls.Add(lblDst)
		Me._SSTab_TabPage0.Controls.Add(Label2)
		Me._SSTab_TabPage0.Controls.Add(chkAutoConnect)
		Me._SSTab_TabPage0.Controls.Add(txtIP)
		Me._SSTab_TabPage0.Controls.Add(txtTempFld)
		Me._SSTab_TabPage0.Controls.Add(cmdSelFld)
		Me._SSTab_TabPage1.Controls.Add(_Line1_10)
		Me._SSTab_TabPage1.Controls.Add(_Line1_9)
		Me._SSTab_TabPage1.Controls.Add(lblFileType)
		Me._SSTab_TabPage1.Controls.Add(lblBitRates)
		Me._SSTab_TabPage1.Controls.Add(cmdUnselect)
		Me._SSTab_TabPage1.Controls.Add(chkMP3)
		Me._SSTab_TabPage1.Controls.Add(chkMp2)
		Me._SSTab_TabPage1.Controls.Add(chkMp1)
		Me._SSTab_TabPage1.Controls.Add(chkWMA)
		Me._SSTab_TabPage1.Controls.Add(chkOGG)
		Me._SSTab_TabPage1.Controls.Add(chkWAV)
		Me._SSTab_TabPage1.Controls.Add(cmdSelectAll)
		Me._SSTab_TabPage1.Controls.Add(opt128)
		Me._SSTab_TabPage1.Controls.Add(opt160)
		Me._SSTab_TabPage1.Controls.Add(opt192)
		Me._SSTab_TabPage1.Controls.Add(opt256)
		Me._SSTab_TabPage1.Controls.Add(optSmart)
		Me._SSTab_TabPage2.Controls.Add(lblinfo)
		Me._SSTab_TabPage2.Controls.Add(Label1)
		Me._SSTab_TabPage2.Controls.Add(chkVDrive)
		Me._SSTab_TabPage3.Controls.Add(chkAutoCDDB)
		Me._SSTab_TabPage4.Controls.Add(_Line1_8)
		Me._SSTab_TabPage4.Controls.Add(lblIdTags)
		Me._SSTab_TabPage4.Controls.Add(imgRB)
		Me._SSTab_TabPage4.Controls.Add(_Line1_7)
		Me._SSTab_TabPage4.Controls.Add(chkManualName)
		Me._SSTab_TabPage4.Controls.Add(chkShowLocalBitrate)
		Me._SSTab_TabPage4.Controls.Add(Picture2)
		Me.Picture2.Controls.Add(optFileName)
		Me.Picture2.Controls.Add(_optIDstuff_0)
		Me.Picture2.Controls.Add(_optIDstuff_1)
		Me.Line1.SetIndex(_Line1_5, CType(5, Short))
		Me.Line1.SetIndex(_Line1_4, CType(4, Short))
		Me.Line1.SetIndex(_Line1_7, CType(7, Short))
		Me.Line1.SetIndex(_Line1_1, CType(1, Short))
		Me.Line1.SetIndex(_Line1_0, CType(0, Short))
		Me.Line1.SetIndex(_Line1_8, CType(8, Short))
		Me.Line1.SetIndex(_Line1_9, CType(9, Short))
		Me.Line1.SetIndex(_Line1_10, CType(10, Short))
		Me.Line1.SetIndex(_Line1_6, CType(6, Short))
		Me.Line1.SetIndex(_Line1_3, CType(3, Short))
		Me.Line1.SetIndex(_Line1_2, CType(2, Short))
		Me.optIDstuff.SetIndex(_optIDstuff_0, CType(0, Short))
		Me.optIDstuff.SetIndex(_optIDstuff_1, CType(1, Short))
		CType(Me.optIDstuff, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picnob.ResumeLayout(False)
		Me.SSTab.ResumeLayout(False)
		Me._SSTab_TabPage0.ResumeLayout(False)
		Me._SSTab_TabPage1.ResumeLayout(False)
		Me._SSTab_TabPage2.ResumeLayout(False)
		Me._SSTab_TabPage3.ResumeLayout(False)
		Me._SSTab_TabPage4.ResumeLayout(False)
		Me.Picture2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class