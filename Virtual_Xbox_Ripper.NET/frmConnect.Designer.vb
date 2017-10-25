<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmConnect
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
	Public WithEvents tmrFireSocketCon As System.Windows.Forms.Timer
	Public WithEvents tmrWorkAround As System.Windows.Forms.Timer
	Public WithEvents chkSaveInfo As System.Windows.Forms.CheckBox
	Public WithEvents Socket As AxMSWinsockLib.AxWinsock
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdConnect As System.Windows.Forms.Button
	Public WithEvents txtUserName As System.Windows.Forms.TextBox
	Public WithEvents txtPass As System.Windows.Forms.TextBox
	Public WithEvents cmbIP As System.Windows.Forms.ComboBox
	Public WithEvents _lblStuff_2 As System.Windows.Forms.Label
	Public WithEvents _lblStuff_1 As System.Windows.Forms.Label
	Public WithEvents _lblStuff_0 As System.Windows.Forms.Label
	Public WithEvents _Line1_1 As System.Windows.Forms.Label
	Public WithEvents imgTop As System.Windows.Forms.PictureBox
	Public WithEvents Line1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblStuff As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConnect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.tmrFireSocketCon = New System.Windows.Forms.Timer(components)
		Me.tmrWorkAround = New System.Windows.Forms.Timer(components)
		Me.chkSaveInfo = New System.Windows.Forms.CheckBox
		Me.Socket = New AxMSWinsockLib.AxWinsock
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdConnect = New System.Windows.Forms.Button
		Me.txtUserName = New System.Windows.Forms.TextBox
		Me.txtPass = New System.Windows.Forms.TextBox
		Me.cmbIP = New System.Windows.Forms.ComboBox
		Me._lblStuff_2 = New System.Windows.Forms.Label
		Me._lblStuff_1 = New System.Windows.Forms.Label
		Me._lblStuff_0 = New System.Windows.Forms.Label
		Me._Line1_1 = New System.Windows.Forms.Label
		Me.imgTop = New System.Windows.Forms.PictureBox
		Me.Line1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lblStuff = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Socket, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblStuff, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Virtual Xbox CD Ripper"
		Me.ClientSize = New System.Drawing.Size(355, 224)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("frmConnect.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmConnect"
		Me.tmrFireSocketCon.Enabled = False
		Me.tmrFireSocketCon.Interval = 200
		Me.tmrWorkAround.Enabled = False
		Me.tmrWorkAround.Interval = 1000
		Me.chkSaveInfo.Text = "Save Username && Password"
		Me.chkSaveInfo.Size = New System.Drawing.Size(249, 17)
		Me.chkSaveInfo.Location = New System.Drawing.Point(88, 160)
		Me.chkSaveInfo.TabIndex = 8
		Me.chkSaveInfo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSaveInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSaveInfo.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSaveInfo.BackColor = System.Drawing.SystemColors.Control
		Me.chkSaveInfo.CausesValidation = True
		Me.chkSaveInfo.Enabled = True
		Me.chkSaveInfo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkSaveInfo.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSaveInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSaveInfo.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSaveInfo.TabStop = True
		Me.chkSaveInfo.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSaveInfo.Visible = True
		Me.chkSaveInfo.Name = "chkSaveInfo"
		Socket.OcxState = CType(resources.GetObject("Socket.OcxState"), System.Windows.Forms.AxHost.State)
		Me.Socket.Location = New System.Drawing.Point(0, 0)
		Me.Socket.Name = "Socket"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(97, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(88, 184)
		Me.cmdCancel.TabIndex = 7
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdConnect.Text = "Connect"
		Me.AcceptButton = Me.cmdConnect
		Me.cmdConnect.Size = New System.Drawing.Size(97, 25)
		Me.cmdConnect.Location = New System.Drawing.Point(240, 184)
		Me.cmdConnect.TabIndex = 3
		Me.cmdConnect.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdConnect.BackColor = System.Drawing.SystemColors.Control
		Me.cmdConnect.CausesValidation = True
		Me.cmdConnect.Enabled = True
		Me.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdConnect.TabStop = True
		Me.cmdConnect.Name = "cmdConnect"
		Me.txtUserName.AutoSize = False
		Me.txtUserName.Size = New System.Drawing.Size(249, 21)
		Me.txtUserName.Location = New System.Drawing.Point(88, 112)
		Me.txtUserName.TabIndex = 1
		Me.txtUserName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtUserName.AcceptsReturn = True
		Me.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtUserName.BackColor = System.Drawing.SystemColors.Window
		Me.txtUserName.CausesValidation = True
		Me.txtUserName.Enabled = True
		Me.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtUserName.HideSelection = True
		Me.txtUserName.ReadOnly = False
		Me.txtUserName.Maxlength = 0
		Me.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUserName.MultiLine = False
		Me.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUserName.TabStop = True
		Me.txtUserName.Visible = True
		Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtUserName.Name = "txtUserName"
		Me.txtPass.AutoSize = False
		Me.txtPass.Size = New System.Drawing.Size(249, 21)
		Me.txtPass.Location = New System.Drawing.Point(88, 136)
		Me.txtPass.TabIndex = 2
		Me.txtPass.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPass.AcceptsReturn = True
		Me.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPass.BackColor = System.Drawing.SystemColors.Window
		Me.txtPass.CausesValidation = True
		Me.txtPass.Enabled = True
		Me.txtPass.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPass.HideSelection = True
		Me.txtPass.ReadOnly = False
		Me.txtPass.Maxlength = 0
		Me.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPass.MultiLine = False
		Me.txtPass.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPass.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPass.TabStop = True
		Me.txtPass.Visible = True
		Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPass.Name = "txtPass"
		Me.cmbIP.Size = New System.Drawing.Size(249, 22)
		Me.cmbIP.Location = New System.Drawing.Point(88, 72)
		Me.cmbIP.TabIndex = 0
		Me.cmbIP.Text = "192.168.0.109"
		Me.cmbIP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbIP.BackColor = System.Drawing.SystemColors.Window
		Me.cmbIP.CausesValidation = True
		Me.cmbIP.Enabled = True
		Me.cmbIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbIP.IntegralHeight = True
		Me.cmbIP.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbIP.Sorted = False
		Me.cmbIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbIP.TabStop = True
		Me.cmbIP.Visible = True
		Me.cmbIP.Name = "cmbIP"
		Me._lblStuff_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblStuff_2.Text = "Password:"
		Me._lblStuff_2.Size = New System.Drawing.Size(73, 17)
		Me._lblStuff_2.Location = New System.Drawing.Point(8, 136)
		Me._lblStuff_2.TabIndex = 6
		Me._lblStuff_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStuff_2.BackColor = System.Drawing.Color.Transparent
		Me._lblStuff_2.Enabled = True
		Me._lblStuff_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStuff_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStuff_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStuff_2.UseMnemonic = True
		Me._lblStuff_2.Visible = True
		Me._lblStuff_2.AutoSize = False
		Me._lblStuff_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStuff_2.Name = "_lblStuff_2"
		Me._lblStuff_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblStuff_1.Text = "User Name:"
		Me._lblStuff_1.Size = New System.Drawing.Size(73, 17)
		Me._lblStuff_1.Location = New System.Drawing.Point(8, 112)
		Me._lblStuff_1.TabIndex = 5
		Me._lblStuff_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStuff_1.BackColor = System.Drawing.Color.Transparent
		Me._lblStuff_1.Enabled = True
		Me._lblStuff_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStuff_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStuff_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStuff_1.UseMnemonic = True
		Me._lblStuff_1.Visible = True
		Me._lblStuff_1.AutoSize = False
		Me._lblStuff_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStuff_1.Name = "_lblStuff_1"
		Me._lblStuff_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblStuff_0.Text = "Xbox's IP:"
		Me._lblStuff_0.Size = New System.Drawing.Size(73, 17)
		Me._lblStuff_0.Location = New System.Drawing.Point(8, 72)
		Me._lblStuff_0.TabIndex = 4
		Me._lblStuff_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblStuff_0.BackColor = System.Drawing.Color.Transparent
		Me._lblStuff_0.Enabled = True
		Me._lblStuff_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblStuff_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblStuff_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblStuff_0.UseMnemonic = True
		Me._lblStuff_0.Visible = True
		Me._lblStuff_0.AutoSize = False
		Me._lblStuff_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblStuff_0.Name = "_lblStuff_0"
		Me._Line1_1.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me._Line1_1.Visible = True
		Me._Line1_1.Location = New System.Drawing.Point(0, 53)
		Me._Line1_1.Size = New System.Drawing.Size(371, 1)
		Me._Line1_1.Name = "_Line1_1"
		Me.imgTop.Size = New System.Drawing.Size(358, 53)
		Me.imgTop.Location = New System.Drawing.Point(0, 0)
		Me.imgTop.Image = CType(resources.GetObject("imgTop.Image"), System.Drawing.Image)
		Me.imgTop.Enabled = True
		Me.imgTop.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgTop.Visible = True
		Me.imgTop.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgTop.Name = "imgTop"
		Me.Controls.Add(chkSaveInfo)
		Me.Controls.Add(Socket)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdConnect)
		Me.Controls.Add(txtUserName)
		Me.Controls.Add(txtPass)
		Me.Controls.Add(cmbIP)
		Me.Controls.Add(_lblStuff_2)
		Me.Controls.Add(_lblStuff_1)
		Me.Controls.Add(_lblStuff_0)
		Me.Controls.Add(_Line1_1)
		Me.Controls.Add(imgTop)
		Me.Line1.SetIndex(_Line1_1, CType(1, Short))
		Me.lblStuff.SetIndex(_lblStuff_2, CType(2, Short))
		Me.lblStuff.SetIndex(_lblStuff_1, CType(1, Short))
		Me.lblStuff.SetIndex(_lblStuff_0, CType(0, Short))
		CType(Me.lblStuff, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Line1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Socket, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class