<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEditTitle
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
	Public WithEvents chkStop As System.Windows.Forms.CheckBox
	Public WithEvents cmdApply As System.Windows.Forms.Button
	Public WithEvents _lvName_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvName_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvName As System.Windows.Forms.ListView
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEditTitle))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chkStop = New System.Windows.Forms.CheckBox
		Me.cmdApply = New System.Windows.Forms.Button
		Me.lvName = New System.Windows.Forms.ListView
		Me._lvName_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvName_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.lvName.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Edit Name"
		Me.ClientSize = New System.Drawing.Size(419, 262)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("frmEditTitle.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmEditTitle"
		Me.chkStop.Text = "Never Ask Again!"
		Me.chkStop.Size = New System.Drawing.Size(129, 17)
		Me.chkStop.Location = New System.Drawing.Point(8, 240)
		Me.chkStop.TabIndex = 2
		Me.chkStop.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkStop.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkStop.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkStop.BackColor = System.Drawing.SystemColors.Control
		Me.chkStop.CausesValidation = True
		Me.chkStop.Enabled = True
		Me.chkStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkStop.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkStop.TabStop = True
		Me.chkStop.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkStop.Visible = True
		Me.chkStop.Name = "chkStop"
		Me.cmdApply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdApply.Text = "Apply"
		Me.cmdApply.Size = New System.Drawing.Size(113, 25)
		Me.cmdApply.Location = New System.Drawing.Point(296, 232)
		Me.cmdApply.TabIndex = 1
		Me.cmdApply.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdApply.BackColor = System.Drawing.SystemColors.Control
		Me.cmdApply.CausesValidation = True
		Me.cmdApply.Enabled = True
		Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdApply.TabStop = True
		Me.cmdApply.Name = "cmdApply"
		Me.lvName.Size = New System.Drawing.Size(401, 217)
		Me.lvName.Location = New System.Drawing.Point(8, 8)
		Me.lvName.TabIndex = 0
		Me.lvName.View = System.Windows.Forms.View.Details
		Me.lvName.LabelWrap = True
		Me.lvName.HideSelection = True
		Me.lvName.FullRowSelect = True
		Me.lvName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvName.BackColor = System.Drawing.SystemColors.Window
		Me.lvName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lvName.LabelEdit = True
		Me.lvName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lvName.Name = "lvName"
		Me._lvName_ColumnHeader_1.Text = "Name"
		Me._lvName_ColumnHeader_1.Width = 193
		Me._lvName_ColumnHeader_2.Text = "Bitrate"
		Me._lvName_ColumnHeader_2.Width = 170
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "Edit"
		Me.cmdEdit.Size = New System.Drawing.Size(113, 25)
		Me.cmdEdit.Location = New System.Drawing.Point(184, 232)
		Me.cmdEdit.TabIndex = 3
		Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.TabStop = True
		Me.cmdEdit.Name = "cmdEdit"
		Me.Controls.Add(chkStop)
		Me.Controls.Add(cmdApply)
		Me.Controls.Add(lvName)
		Me.Controls.Add(cmdEdit)
		Me.lvName.Columns.Add(_lvName_ColumnHeader_1)
		Me.lvName.Columns.Add(_lvName_ColumnHeader_2)
		Me.lvName.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class