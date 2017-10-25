<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAbout
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
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents _lblInfo_1 As System.Windows.Forms.Label
	Public WithEvents _lblInfo_0 As System.Windows.Forms.Label
	Public WithEvents imgAbout As System.Windows.Forms.PictureBox
	Public WithEvents lblInfo As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbout))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOK = New System.Windows.Forms.Button
		Me._lblInfo_1 = New System.Windows.Forms.Label
		Me._lblInfo_0 = New System.Windows.Forms.Label
		Me.imgAbout = New System.Windows.Forms.PictureBox
		Me.lblInfo = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.White
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "About"
		Me.ClientSize = New System.Drawing.Size(379, 257)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("frmAbout.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAbout"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(121, 25)
		Me.cmdOK.Location = New System.Drawing.Point(240, 224)
		Me.cmdOK.TabIndex = 0
		Me.cmdOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me._lblInfo_1.Text = "Special Thanks To:[GS]EqUaTe, Furious Styles, Rahszhul, YuYu.  Anyone that I missed Contact me :)."
		Me._lblInfo_1.Size = New System.Drawing.Size(312, 38)
		Me._lblInfo_1.Location = New System.Drawing.Point(16, 184)
		Me._lblInfo_1.TabIndex = 2
		Me._lblInfo_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblInfo_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblInfo_1.BackColor = System.Drawing.Color.Transparent
		Me._lblInfo_1.Enabled = True
		Me._lblInfo_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblInfo_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblInfo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblInfo_1.UseMnemonic = True
		Me._lblInfo_1.Visible = True
		Me._lblInfo_1.AutoSize = False
		Me._lblInfo_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblInfo_1.Name = "_lblInfo_1"
		Me._lblInfo_0.Text = "Designed And Developed By:  BlueCELL && Xbox War3z"
		Me._lblInfo_0.Size = New System.Drawing.Size(266, 14)
		Me._lblInfo_0.Location = New System.Drawing.Point(16, 160)
		Me._lblInfo_0.TabIndex = 1
		Me._lblInfo_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblInfo_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblInfo_0.BackColor = System.Drawing.Color.Transparent
		Me._lblInfo_0.Enabled = True
		Me._lblInfo_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblInfo_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblInfo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblInfo_0.UseMnemonic = True
		Me._lblInfo_0.Visible = True
		Me._lblInfo_0.AutoSize = True
		Me._lblInfo_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblInfo_0.Name = "_lblInfo_0"
		Me.imgAbout.Size = New System.Drawing.Size(379, 152)
		Me.imgAbout.Location = New System.Drawing.Point(0, 0)
		Me.imgAbout.Image = CType(resources.GetObject("imgAbout.Image"), System.Drawing.Image)
		Me.imgAbout.Enabled = True
		Me.imgAbout.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.imgAbout.Visible = True
		Me.imgAbout.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgAbout.Name = "imgAbout"
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(_lblInfo_1)
		Me.Controls.Add(_lblInfo_0)
		Me.Controls.Add(imgAbout)
		Me.lblInfo.SetIndex(_lblInfo_1, CType(1, Short))
		Me.lblInfo.SetIndex(_lblInfo_0, CType(0, Short))
		CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class