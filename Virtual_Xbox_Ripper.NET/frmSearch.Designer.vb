<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSearch
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
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents cmdSeach As System.Windows.Forms.Button
	Public WithEvents imglIcons As System.Windows.Forms.ImageList
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtPath As System.Windows.Forms.TextBox
	Public WithEvents cmdPath As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents _S1_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _S1_Panel2 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _S1_Panel3 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _S1_Panel4 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents S1 As System.Windows.Forms.StatusStrip
	Public WithEvents _LVF_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _LVF_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents LVF As System.Windows.Forms.ListView
	Public WithEvents _lblInfo_1 As System.Windows.Forms.Label
	Public WithEvents _lblInfo_0 As System.Windows.Forms.Label
	Public WithEvents lblInfo As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.cmdSeach = New System.Windows.Forms.Button
		Me.imglIcons = New System.Windows.Forms.ImageList
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.txtPath = New System.Windows.Forms.TextBox
		Me.cmdPath = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.S1 = New System.Windows.Forms.StatusStrip
		Me._S1_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me._S1_Panel2 = New System.Windows.Forms.ToolStripStatusLabel
		Me._S1_Panel3 = New System.Windows.Forms.ToolStripStatusLabel
		Me._S1_Panel4 = New System.Windows.Forms.ToolStripStatusLabel
		Me.LVF = New System.Windows.Forms.ListView
		Me._LVF_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._LVF_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lblInfo_1 = New System.Windows.Forms.Label
		Me._lblInfo_0 = New System.Windows.Forms.Label
		Me.lblInfo = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.S1.SuspendLayout()
		Me.LVF.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Search"
		Me.ClientSize = New System.Drawing.Size(549, 292)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("frmSearch.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmSearch"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "Add"
		Me.cmdAdd.Enabled = False
		Me.cmdAdd.Size = New System.Drawing.Size(105, 27)
		Me.cmdAdd.Location = New System.Drawing.Point(432, 240)
		Me.cmdAdd.TabIndex = 9
		Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdSeach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSeach.Text = "Search"
		Me.cmdSeach.Size = New System.Drawing.Size(89, 27)
		Me.cmdSeach.Location = New System.Drawing.Point(96, 240)
		Me.cmdSeach.TabIndex = 4
		Me.cmdSeach.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSeach.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSeach.CausesValidation = True
		Me.cmdSeach.Enabled = True
		Me.cmdSeach.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSeach.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSeach.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSeach.TabStop = True
		Me.cmdSeach.Name = "cmdSeach"
		Me.imglIcons.ImageSize = New System.Drawing.Size(16, 16)
		Me.imglIcons.TransparentColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.imglIcons.ImageStream = CType(resources.GetObject("imglIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imglIcons.Images.SetKeyName(0, "")
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Stop"
		Me.cmdCancel.Enabled = False
		Me.cmdCancel.Size = New System.Drawing.Size(89, 27)
		Me.cmdCancel.Location = New System.Drawing.Point(8, 240)
		Me.cmdCancel.TabIndex = 8
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.txtPath.AutoSize = False
		Me.txtPath.Size = New System.Drawing.Size(441, 19)
		Me.txtPath.Location = New System.Drawing.Point(72, 8)
		Me.txtPath.TabIndex = 3
		Me.txtPath.Text = "C:\"
		Me.txtPath.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPath.AcceptsReturn = True
		Me.txtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPath.BackColor = System.Drawing.SystemColors.Window
		Me.txtPath.CausesValidation = True
		Me.txtPath.Enabled = True
		Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPath.HideSelection = True
		Me.txtPath.ReadOnly = False
		Me.txtPath.Maxlength = 0
		Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPath.MultiLine = False
		Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPath.TabStop = True
		Me.txtPath.Visible = True
		Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPath.Name = "txtPath"
		Me.cmdPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPath.Text = "..."
		Me.cmdPath.Size = New System.Drawing.Size(17, 19)
		Me.cmdPath.Location = New System.Drawing.Point(520, 8)
		Me.cmdPath.TabIndex = 2
		Me.cmdPath.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPath.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPath.CausesValidation = True
		Me.cmdPath.Enabled = True
		Me.cmdPath.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPath.TabStop = True
		Me.cmdPath.Name = "cmdPath"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(465, 19)
		Me.txtSearch.Location = New System.Drawing.Point(72, 32)
		Me.txtSearch.TabIndex = 1
		Me.txtSearch.Text = ".mp3"
		Me.txtSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSearch.AcceptsReturn = True
		Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch.CausesValidation = True
		Me.txtSearch.Enabled = True
		Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch.HideSelection = True
		Me.txtSearch.ReadOnly = False
		Me.txtSearch.Maxlength = 0
		Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch.MultiLine = False
		Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch.TabStop = True
		Me.txtSearch.Visible = True
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch.Name = "txtSearch"
		Me.S1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.S1.Size = New System.Drawing.Size(549, 17)
		Me.S1.Location = New System.Drawing.Point(0, 275)
		Me.S1.TabIndex = 0
		Me.S1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.S1.Name = "S1"
		Me._S1_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._S1_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._S1_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._S1_Panel1.Size = New System.Drawing.Size(132, 17)
		Me._S1_Panel1.Text = "Found : 0"
		Me._S1_Panel1.Spring = True
		Me._S1_Panel1.AutoSize = True
		Me._S1_Panel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._S1_Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me._S1_Panel1.AutoSize = False
		Me._S1_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._S1_Panel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._S1_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._S1_Panel2.Size = New System.Drawing.Size(132, 17)
		Me._S1_Panel2.Text = "Total Size : 0"
		Me._S1_Panel2.Spring = True
		Me._S1_Panel2.AutoSize = True
		Me._S1_Panel2.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._S1_Panel2.Margin = New System.Windows.Forms.Padding(0)
		Me._S1_Panel2.AutoSize = False
		Me._S1_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._S1_Panel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._S1_Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._S1_Panel3.Size = New System.Drawing.Size(132, 17)
		Me._S1_Panel3.Text = "Folders Searched : 0"
		Me._S1_Panel3.Spring = True
		Me._S1_Panel3.AutoSize = True
		Me._S1_Panel3.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._S1_Panel3.Margin = New System.Windows.Forms.Padding(0)
		Me._S1_Panel3.AutoSize = False
		Me._S1_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._S1_Panel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._S1_Panel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._S1_Panel4.Size = New System.Drawing.Size(132, 17)
		Me._S1_Panel4.Text = "Files Searched : 0"
		Me._S1_Panel4.Spring = True
		Me._S1_Panel4.AutoSize = True
		Me._S1_Panel4.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._S1_Panel4.Margin = New System.Windows.Forms.Padding(0)
		Me._S1_Panel4.AutoSize = False
		Me.LVF.Size = New System.Drawing.Size(529, 177)
		Me.LVF.Location = New System.Drawing.Point(8, 56)
		Me.LVF.TabIndex = 5
		Me.LVF.View = System.Windows.Forms.View.Details
		Me.LVF.LabelEdit = False
		Me.LVF.LabelWrap = True
		Me.LVF.HideSelection = True
		Me.LVF.Checkboxes = True
		Me.LVF.FullRowSelect = True
		Me.LVF.SmallImageList = imglIcons
		Me.LVF.ForeColor = System.Drawing.SystemColors.WindowText
		Me.LVF.BackColor = System.Drawing.SystemColors.Window
		Me.LVF.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LVF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LVF.Name = "LVF"
		Me._LVF_ColumnHeader_1.Text = "FileName"
		Me._LVF_ColumnHeader_1.Width = 170
		Me._LVF_ColumnHeader_2.Text = "Size"
		Me._LVF_ColumnHeader_2.Width = 170
		Me._lblInfo_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblInfo_1.Text = "Search For:"
		Me._lblInfo_1.Size = New System.Drawing.Size(57, 17)
		Me._lblInfo_1.Location = New System.Drawing.Point(8, 32)
		Me._lblInfo_1.TabIndex = 7
		Me._lblInfo_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me._lblInfo_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._lblInfo_0.Text = "Search In:"
		Me._lblInfo_0.Size = New System.Drawing.Size(57, 17)
		Me._lblInfo_0.Location = New System.Drawing.Point(8, 8)
		Me._lblInfo_0.TabIndex = 6
		Me._lblInfo_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblInfo_0.BackColor = System.Drawing.Color.Transparent
		Me._lblInfo_0.Enabled = True
		Me._lblInfo_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblInfo_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblInfo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblInfo_0.UseMnemonic = True
		Me._lblInfo_0.Visible = True
		Me._lblInfo_0.AutoSize = False
		Me._lblInfo_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblInfo_0.Name = "_lblInfo_0"
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(cmdSeach)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(txtPath)
		Me.Controls.Add(cmdPath)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(S1)
		Me.Controls.Add(LVF)
		Me.Controls.Add(_lblInfo_1)
		Me.Controls.Add(_lblInfo_0)
		Me.S1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._S1_Panel1})
		Me.S1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._S1_Panel2})
		Me.S1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._S1_Panel3})
		Me.S1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._S1_Panel4})
		Me.LVF.Columns.Add(_LVF_ColumnHeader_1)
		Me.LVF.Columns.Add(_LVF_ColumnHeader_2)
		Me.lblInfo.SetIndex(_lblInfo_1, CType(1, Short))
		Me.lblInfo.SetIndex(_lblInfo_0, CType(0, Short))
		CType(Me.lblInfo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.S1.ResumeLayout(False)
		Me.LVF.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class