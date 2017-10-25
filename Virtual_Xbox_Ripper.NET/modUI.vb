Option Strict Off
Option Explicit On
Module modUI
	Declare Function SHGetPathFromIDList Lib "Shell32.dll"  Alias "SHGetPathFromIDListA"(ByVal pidl As Integer, ByVal pszPath As String) As Integer
	Private Const BIF_RETURNONLYFSDIRS As Short = 1
	Private Const BIF_DONTGOBELOWDOMAIN As Short = 2
	Private Const MAX_PATH As Short = 260
	
	'UPGRADE_WARNING: Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHBrowseForFolder Lib "shell32" (ByRef lpbi As BrowseInfo) As Integer
	Private Declare Function lstrcat Lib "kernel32"  Alias "lstrcatA"(ByVal lpString1 As String, ByVal lpString2 As String) As Integer
	
	Private Structure BrowseInfo
		Dim hWndOwner As Integer
		Dim pIDLRoot As Integer
		Dim pszDisplayName As Integer
		Dim lpszTitle As Integer
		Dim ulFlags As Integer
		Dim lpfnCallback As Integer
		Dim lParam As Integer
		Dim iImage As Integer
	End Structure
	
	'Displays the Treeview w/ Directories in Computer
	Public Function SelectFolder(ByRef coosh As Integer) As Object
		
		'Declares Variable Objects
		Dim lpIDList As Integer
		Dim sBuffer As String
		Dim szTitle As String
		Dim tBrowseInfo As BrowseInfo
		
		'Updates Caption Bar
		szTitle = "Select Folder"
		
		'Sets Properties
		With tBrowseInfo
			.hWndOwner = coosh
			.lpszTitle = lstrcat(szTitle, "")
			.ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN
		End With
		
		'Shows Folder w/ Applied Settings
		lpIDList = SHBrowseForFolder(tBrowseInfo)
		
		'Gets Returned Data
		If (lpIDList) Then
			sBuffer = Space(MAX_PATH)
			SHGetPathFromIDList(lpIDList, sBuffer)
			sBuffer = Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
			'UPGRADE_WARNING: Couldn't resolve default property of object SelectFolder. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SelectFolder = sBuffer
		End If
		
	End Function
	
	'Changes LVPC So it Compiles with CD Ripper
	Public Function ListviewPCCDRipper(ByRef lvItem As System.Windows.Forms.ListView) As Object
		
		'Hides the DATE Colume
		'lvitem.ColumnHeaders(2).Width = 0
		
		'Resizes Listitem
		ReSizeLV(lvItem, 1)
		
	End Function
	
	'Changes LVPC So it Compiles with FileViewer
	Public Function ListviewPCFileView(ByRef lvItem As System.Windows.Forms.ListView) As Object
		
		'Shows the DATE Colume
		''lvitem.ColumnHeaders(2).Width = 1440
		
		'Resizes Listitem
		ReSizeLV(lvItem, 1)
		
	End Function
	
	'Resizes A Listview Tab
	Public Function ReSizeLV(ByVal L As System.Windows.Forms.ListView, ByRef Index As Short) As Object
		On Error Resume Next
		
		'Declares Memory Values
		Dim i As Short
		Dim Hei As Integer
		Dim Ad As Integer
		
		'Loops Through Each Header
		For i = 1 To L.Columns.Count
			'UPGRADE_WARNING: Lower bound of collection L.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Hei = Hei + VB6.PixelsToTwipsX(L.Columns.Item(i).Width)
		Next 
		
		Ad = VB6.PixelsToTwipsX(L.Width) - Hei
		
		'Fixes Sizes
		'UPGRADE_WARNING: Lower bound of collection L.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If VB6.PixelsToTwipsX(L.Columns.Item(Index).Width) + Ad - 8 > 96 Then
			'UPGRADE_WARNING: Lower bound of collection L.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			L.Columns.Item(Index).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(L.Columns.Item(Index).Width) + Ad - 8)
		Else
			'UPGRADE_WARNING: Lower bound of collection L.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			L.Columns.Item(Index).Width = VB6.TwipsToPixelsX(96)
		End If
		
	End Function
	
	Public Function ResizeStatusBar(ByRef s As System.Windows.Forms.StatusStrip, ByRef Index As Short) As Object
		On Error Resume Next
		
		'Declares Memory Units
		Dim i As Short
		Dim Hei As Integer
		Dim Ad As Integer
		
		'Gets Width of All Tabs
		For i = 1 To s.Items.Count
			'UPGRADE_WARNING: Lower bound of collection s.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Hei = Hei + VB6.PixelsToTwipsX(s.Items.Item(i).Width)
		Next 
		
		Ad = VB6.PixelsToTwipsX(s.Width) - Hei
		
		'Fixes Space
		'UPGRADE_WARNING: Lower bound of collection s.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If VB6.PixelsToTwipsX(s.Items.Item(Index).Width) + Ad - 13 > 96 Then
			'UPGRADE_WARNING: Lower bound of collection s.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			s.Items.Item(Index).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(s.Items.Item(Index).Width) + Ad - 13)
		Else
			'UPGRADE_WARNING: Lower bound of collection s.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			s.Items.Item(Index).Width = VB6.TwipsToPixelsX(96)
		End If
	End Function
End Module