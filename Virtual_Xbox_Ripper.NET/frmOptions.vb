Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmOptions
	Inherits System.Windows.Forms.Form
	'UPGRADE_WARNING: Structure ITEMIDLIST may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHGetSpecialFolderLocation Lib "Shell32.dll" (ByVal hWndOwner As Integer, ByVal nFolder As Integer, ByRef pidl As ITEMIDLIST) As Integer
	Private Declare Function SHGetPathFromIDList Lib "Shell32.dll"  Alias "SHGetPathFromIDListA"(ByVal pidl As Integer, ByVal pszPath As String) As Integer
	Private Declare Function PathFileExists Lib "shlwapi.dll"  Alias "PathFileExistsA"(ByVal pszPath As String) As Integer
	
	Private Const BIF_RETURNONLYFSDIRS As Short = 1
	Private Const BIF_DONTGOBELOWDOMAIN As Short = 2
	Private Const MAX_PATH As Short = 260
	
	'UPGRADE_WARNING: Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHBrowseForFolder Lib "shell32" (ByRef lpbi As BrowseInfo) As Integer
	Private Declare Function lstrcat Lib "kernel32"  Alias "lstrcatA"(ByVal lpString1 As String, ByVal lpString2 As String) As Integer
	
	Private Structure SH_ITEMID
		Dim cb As Integer
		Dim abID As Byte
	End Structure
	
	Private Structure ITEMIDLIST
		Dim mkid As SH_ITEMID
	End Structure
	
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
	
	Private Sub cmdDone_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDone.Click
		Dim blnFirst As Object
		
		'Declares Memory Varibles
		Dim lngA As Integer
		
		'Sets Format Memory to NULL
		VXCRSettings.strSFormats = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object blnFirst. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		blnFirst = True
		
		'Saves Audio Format
		If chkMP3.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp3,"
		End If
		If chkMp2.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp2,"
		End If
		If chkMp1.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp1,"
		End If
		If chkOGG.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "ogg,"
		End If
		If chkWMA.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "wma,"
		End If
		If chkWAV.CheckState = 1 Then
			VXCRSettings.strSFormats = VXCRSettings.strSFormats & "wav,"
		End If
		If VB.Right(VXCRSettings.strSFormats, 1) = "," Then
			VXCRSettings.strSFormats = VB.Left(VXCRSettings.strSFormats, Len(VXCRSettings.strSFormats) - 1)
		End If
		
		'Saves Auto Connect Settings
		If Me.chkAutoConnect.CheckState = 1 Then
			VXCRSettings.strAutoCIP = Me.txtIP.Text
		Else
			VXCRSettings.strAutoCIP = CStr(0)
		End If
		
		'Saves IDTag Stuff
		If Me.optFileName.Checked = True Then
			VXCRSettings.intIDStuff = 1 'Show FileName
		End If
		If Me.optIDstuff(0).Checked = True Then
			VXCRSettings.intIDStuff = 2 'Title from IDTag Only
		End If
		If Me.optIDstuff(1).Checked = True Then
			VXCRSettings.intIDStuff = 3 'Artist - Title from IDTag
		End If
		
		'Saves Manual Edit ID Tag
		If Me.chkManualName.CheckState = 1 Then
			VXCRSettings.blnManuIDTag = True
		Else
			VXCRSettings.blnManuIDTag = False
		End If
		
		'Saves Temp Folder Setting
		If modFileSystem.fFolderExists(txtTempFld.Text) = True Then
			
			'Saves Setting
			VXCRSettings.strTempFld = txtTempFld.Text
			
		Else
			
			'Messages User
			MsgBox("Please Select Another Temporary Folder!", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation)
			
		End If
		
		'Saves (enabled BitRate)
		If Me.chkShowLocalBitrate.CheckState = 1 Then
			VXCRSettings.blnShwLBitRate = True
		Else
			VXCRSettings.blnShwLBitRate = False
		End If
		
		'Saves WMA BitRate Conversion
		If opt128.Checked = True Then
			VXCRSettings.lngWmaBitRate = 128000
		End If
		If opt160.Checked = True Then
			VXCRSettings.lngWmaBitRate = 160000
		End If
		If opt192.Checked = True Then
			VXCRSettings.lngWmaBitRate = 192000
		End If
		If opt256.Checked = True Then
			VXCRSettings.lngWmaBitRate = 256000
		End If
		If optSmart.Checked = True Then
			VXCRSettings.lngWmaBitRate = 0
		End If
		
		'Saves Settings to HDD
		SaveVXCRSettings()
		
		'Unloads Option Dialog
		Me.Close()
	End Sub
	
	Private Sub cmdSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectAll.Click
		
		'Selects All items
		Me.chkMp1.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkMp2.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkMP3.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkOGG.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkWAV.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkWMA.CheckState = System.Windows.Forms.CheckState.Checked
		
	End Sub
	
	Public Sub cmdSelFld_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelFld.Click
		
		'Shows the Folder Dialog
		txtTempFld.Text = SelectFolder
		
	End Sub
	
	Private Sub cmdUnselect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnselect.Click
		
		'UnSelects All items
		Me.chkMp1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMp2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMP3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOGG.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkWAV.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkWMA.CheckState = System.Windows.Forms.CheckState.Unchecked
		
	End Sub
	
	Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		
		'Loads Option List
		lvOptions.Items.Add("  General")
		lvOptions.Items.Add("  Formats")
		lvOptions.Items.Add("  Virtual Drive")
		lvOptions.Items.Add("  CD Ripper")
		lvOptions.Items.Add("  ID Tags")
		
		'Declares Memory Varibles
		Dim lngA As Integer
		Dim strPhase() As String
		
		'Loads Formats (x,x,x) into Array
		strPhase = Split(VXCRSettings.strSFormats, ",")
		
		'Loops Through each Format
		For lngA = 0 To UBound(strPhase)
			System.Windows.Forms.Application.DoEvents()
			
			'Enables Formats if Found
			Select Case strPhase(lngA)
				Case "mp3"
					chkMP3.CheckState = System.Windows.Forms.CheckState.Checked
				Case "mp2"
					chkMp2.CheckState = System.Windows.Forms.CheckState.Checked
				Case "mp1"
					chkMp1.CheckState = System.Windows.Forms.CheckState.Checked
				Case "ogg"
					chkOGG.CheckState = System.Windows.Forms.CheckState.Checked
				Case "wma"
					chkWMA.CheckState = System.Windows.Forms.CheckState.Checked
				Case "wav"
					chkWAV.CheckState = System.Windows.Forms.CheckState.Checked
					
			End Select
		Next lngA
		
		'Loads Auto Connect Stuff
		If CDbl(VXCRSettings.strAutoCIP) <> 0 Then
			Me.chkAutoConnect.CheckState = System.Windows.Forms.CheckState.Checked
			Me.txtIP.Text = VXCRSettings.strAutoCIP
		End If
		
		'Loads IDTag Stuff
		Select Case VXCRSettings.intIDStuff
			Case 1
				Me.optFileName.Checked = True 'Show FileName
			Case 2
				Me.optIDstuff(0).Checked = True 'Title from IDTag Only
			Case 3
				Me.optIDstuff(1).Checked = True 'Artist - Title from IDTag
		End Select
		
		'Loads Manually Enter IDtag
		If VXCRSettings.blnManuIDTag = True Then
			Me.chkManualName.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			Me.chkManualName.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		
		'Loads Temp Folder Settings
		txtTempFld.Text = VXCRSettings.strTempFld
		
		'Loads (enabled BitRate)
		If VXCRSettings.blnShwLBitRate = True Then
			Me.chkShowLocalBitrate.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			Me.chkShowLocalBitrate.CheckState = System.Windows.Forms.CheckState.Indeterminate
		End If
		
		'Loads WMA BitRate
		Select Case VXCRSettings.lngWmaBitRate
			Case 128000
				opt128.Checked = True
			Case 160000
				opt160.Checked = True
			Case 192000
				opt192.Checked = True
			Case 256000
				opt256.Checked = True
			Case 0
				optSmart.Checked = True
		End Select
		
	End Sub
	
	Private Sub lvOptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvOptions.Click
		
		'Selects Which Button was pressed
		Select Case Trim(lvOptions.FocusedItem.Text)
			
			Case "General"
				SSTab.SelectedIndex = 0
				
			Case "Formats"
				SSTab.SelectedIndex = 1
				
			Case "Virtual Drive"
				SSTab.SelectedIndex = 2
				
			Case "CD Ripper"
				SSTab.SelectedIndex = 3
				
			Case "ID Tags"
				SSTab.SelectedIndex = 4
				
		End Select
	End Sub
	
	Public Function fGetSpecialFolder(ByRef CSIDL As Integer) As String
		
		'Declares Memory Varibles
		Dim sPath As String
		Dim IDL As ITEMIDLIST
		
		fGetSpecialFolder = ""
		If SHGetSpecialFolderLocation(frmMain.Handle.ToInt32, CSIDL, IDL) = 0 Then
			
			sPath = Space(MAX_PATH)
			If SHGetPathFromIDList(IDL.mkid.cb, sPath) Then
				fGetSpecialFolder = VB.Left(sPath, InStr(sPath, vbNullChar) - 1) & "\"
			End If
		End If
		
	End Function
	
	Public Function SelectFolder() As Object
		
		'Declares Memory Varibles
		Dim lpIDList As Integer
		Dim sBuffer As String
		Dim szTitle As String
		Dim tBrowseInfo As BrowseInfo
		
		szTitle = "Select Folder"
		With tBrowseInfo
			.hWndOwner = Me.Handle.ToInt32
			.lpszTitle = lstrcat(szTitle, "")
			.ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN
		End With
		
		lpIDList = SHBrowseForFolder(tBrowseInfo)
		
		If (lpIDList) Then
			sBuffer = Space(MAX_PATH)
			SHGetPathFromIDList(lpIDList, sBuffer)
			sBuffer = VB.Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
			'UPGRADE_WARNING: Couldn't resolve default property of object SelectFolder. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SelectFolder = sBuffer & "\"
		End If
		
	End Function
End Class