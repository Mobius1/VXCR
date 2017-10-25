Option Strict Off
Option Explicit On
Friend Class frmEditTitle
	Inherits System.Windows.Forms.Form
	Private Sub cmdApply_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApply.Click
		
		'Declares Memory Varibles
		Dim lngA As Integer
		
		'Changes Names
		For lngA = 1 To lvName.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Updates Item
			'UPGRADE_WARNING: Lower bound of collection lvName.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			frmMain.lvPC.Items.Item(Int(CDbl(Replace(lvName.Items.Item(lngA).Tag, "#", "")))).Text = lvName.Items.Item(lngA).Text
			
		Next lngA
		
		'Saves Settings
		If Me.chkStop.CheckState = 1 Then
			VXCRSettings.blnManuIDTag = False
		Else
			VXCRSettings.blnManuIDTag = True
		End If
		
		'Hides Me
		Me.Hide()
		
		'Sets Focus to Main Window
		frmMain.Activate()
		
		'Starts the Upload/Convert Process
		frmMain.UploadSongs()
		
		Me.Close()
	End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		
		'Sets Focus and Edits
		lvName.Focus()
		lvName.FocusedItem.BeginEdit()
		
	End Sub
	
	Private Sub frmEditTitle_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'Declares Memory Varibles
		Dim lngA As Integer
		
		'Loads Selected Items to Local Listview
		For lngA = 1 To frmMain.lvPC.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Checks if Item is Checked
			'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If frmMain.lvPC.Items.Item(lngA).Checked = True Then
				
				'Adds New Item
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Me.lvName.Items.Add(frmMain.lvPC.Items.Item(lngA).Text)
				'UPGRADE_WARNING: Lower bound of collection Me.lvName.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection Me.lvName.ListItems(lvName.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If Me.lvName.Items.Item(lvName.Items.Count).SubItems.Count > 1 Then
					Me.lvName.Items.Item(lvName.Items.Count).SubItems(1).Text = frmMain.lvPC.Items.Item(lngA).SubItems(1).Text
				Else
					Me.lvName.Items.Item(lvName.Items.Count).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, frmMain.lvPC.Items.Item(lngA).SubItems(1).Text))
				End If
				'UPGRADE_WARNING: Lower bound of collection Me.lvName.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Me.lvName.Items.Item(lvName.Items.Count).Tag = "#" & lngA
				
			End If
		Next lngA
		
		'Checked Item
		Me.chkStop.CheckState = System.Windows.Forms.CheckState.Unchecked
		
		'Resizes LV
		ReSizeLV(Me.lvName, 1)
		
		
	End Sub
End Class