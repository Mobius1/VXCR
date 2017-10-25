Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSearch
	Inherits System.Windows.Forms.Form
	Dim Folders As Integer
	Dim Files As Integer
	Dim Found As Integer
	Dim TSize As Double
	Dim blnCancel As Boolean
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		
		'Declares Memory Units
		Dim lngA As Integer
		Dim strFilePath As String
		
		'Clears PC listview
		frmMain.lvPC.Items.Clear()
		
		'Loops Through All Listview Items
		For lngA = 1 To LVF.Items.Count
			System.Windows.Forms.Application.DoEvents()
			
			'Updates File Path Varible
			'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_ISSUE: MSComctlLib.ListItem property LVF.ListItems.ToolTipText was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			strFilePath = LVF.Items.Item(lngA).ToolTipText & LVF.Items.Item(lngA).Text
			
			'Checks if LV item is checked
			'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If LVF.Items.Item(lngA).Checked = True Then
				
				'Adds Files to listview GrabMP3Title
				If VXCRSettings.blnLvpcIDTag = True Then
					
					'Checks if ID Tag is MP3 Stream CheckVaildID
					If CheckVaildID(GetId3(strFilePath)) = True Then
						'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
						frmMain.lvPC.Items.Add(GetId3(strFilePath), 9)
					Else
						'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
						frmMain.lvPC.Items.Add(LVF.Items.Item(lngA).Text, 9)
					End If
					
				Else
					'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
					frmMain.lvPC.Items.Add(LVF.Items.Item(lngA).Text, 9)
				End If
				
				'Gets File Size and Converts to KB etc
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems(frmMain.lvPC.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object DoConv(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If frmMain.lvPC.Items.Item(frmMain.lvPC.Items.Count).SubItems.Count > 2 Then
					frmMain.lvPC.Items.Item(frmMain.lvPC.Items.Count).SubItems(2).Text = DoConv(CStr(FileLen(strFilePath)))
				Else
					frmMain.lvPC.Items.Item(frmMain.lvPC.Items.Count).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, DoConv(CStr(FileLen(strFilePath)))))
				End If
				'UPGRADE_WARNING: Lower bound of collection frmMain.lvPC.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				frmMain.lvPC.Items.Item(frmMain.lvPC.Items.Count).Tag = strFilePath
				
			End If
		Next 
		
		Me.Close()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		
		'Cancels Operations
		blnCancel = True
		
		cmdCancel.Enabled = False
		cmdSeach.Enabled = True
	End Sub
	
	Private Sub cmdPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath.Click
		
		'Declares Memory Units
		Dim strFolder As String
		
		'Selects Folder & Returns Item
		'UPGRADE_WARNING: Couldn't resolve default property of object SelectFolder(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strFolder = SelectFolder(Me.Handle.ToInt32)
		txtPath.Text = strFolder
		
	End Sub
	
	Private Sub cmdSeach_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSeach.Click
		
		'Clears listview
		LVF.Items.Clear()
		
		'Enables Stop Button
		cmdAdd.Enabled = True
		cmdCancel.Enabled = True
		cmdSeach.Enabled = False
		
		'Sets Default Varible Values
		Folders = 0
		Files = 0
		Found = 0
		TSize = 0
		
		'Sets Canceled to False
		blnCancel = False
		
		'Scans for Drives to Scan
		Dim sV() As String
		sV = Split(txtPath.Text, ",")
		
		Dim i As Integer
		For i = 0 To UBound(sV)
			
			'Checks if Canceld
			If blnCancel = True Then
				blnCancel = False
				
				Exit For
			End If
			
			DirSize(sV(i))
		Next 
	End Sub
	
	Sub DirSize(ByVal path As String)
		'On Error Resume Next
		
		'Declares Memory Units
		Dim MyName As String
		Dim MyDirNr As Integer
		Dim MyDir() As String
		Dim a As Integer
		Dim chklen() As String
		
		Folders = Folders + 1
		path = IIf(VB.Right(path, 1) = "\", path, path & "\")
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		MyName = Dir(path & "*.*", FileAttribute.Directory + FileAttribute.Archive + FileAttribute.ReadOnly)
		chklen = Split(path, "\")
		
		System.Windows.Forms.Application.DoEvents()
		
		Dim sizeX As Integer
		Do While (MyName <> "")
			System.Windows.Forms.Application.DoEvents()
			
			'Checks if Canceld
			If blnCancel = True Then
				
				Exit Do
			End If
			
			If MyName <> "." And MyName <> ".." Then
				If (GetAttr(path & MyName) And FileAttribute.Directory) <> FileAttribute.Directory Then
					sizeX = FileLen(path & MyName)
					
					If sizeX < 1 Then GoTo ToSmall
					Files = Files + 1
					
					If InStr(LCase(MyName), LCase(txtSearch.Text)) Then
						
						Found = Found + 1
						TSize = TSize + sizeX
						
						'UPGRADE_WARNING: Lower bound of collection LVF.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
						LVF.Items.Add(MyName, 1)
						'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection LVF.ListItems.Item(LVF.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object DoConv(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If LVF.Items.Item(LVF.Items.Count).SubItems.Count > 1 Then
							LVF.Items.Item(LVF.Items.Count).SubItems(1).Text = DoConv(CStr(sizeX))
						Else
							LVF.Items.Item(LVF.Items.Count).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, DoConv(CStr(sizeX))))
						End If
						'UPGRADE_WARNING: Lower bound of collection LVF.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_ISSUE: MSComctlLib.ListItem property LVF.ListItems.Item.ToolTipText was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						LVF.Items.Item(LVF.Items.Count).ToolTipText = path
					End If
ToSmall: 
					
				Else
					ReDim Preserve MyDir(MyDirNr + 1)
					MyDirNr = MyDirNr + 1
					MyDir(MyDirNr) = MyName
				End If
			End If
			
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			MyName = CStr(Dir())
			
		Loop 
		
		For a = 1 To MyDirNr
			UpdateStatus()
			DirSize(path & MyDir(a) & "\")
		Next 
		
	End Sub
	
	Sub UpdateStatus()
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection S1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		S1.Items.Item(1).Text = "Found : " & Found
		'UPGRADE_WARNING: Couldn't resolve default property of object DoConv(CStr(TSize)). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Lower bound of collection S1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		S1.Items.Item(2).Text = "Total Size : " & DoConv(CStr(TSize))
		'UPGRADE_WARNING: Lower bound of collection S1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		S1.Items.Item(3).Text = "Folders Searched : " & Folders
		'UPGRADE_WARNING: Lower bound of collection S1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		S1.Items.Item(4).Text = "Files Searched : " & Files
	End Sub
	
	Private Sub frmSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'Resizes LVF tabs
		ReSizeLV(Me.LVF, 1)
		'UPGRADE_WARNING: Lower bound of collection LVF.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		LVF.Columns.Item(1).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(LVF.Columns.Item(1).Width) - 50)
	End Sub
End Class