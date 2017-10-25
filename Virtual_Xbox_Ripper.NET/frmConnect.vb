Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmConnect
	Inherits System.Windows.Forms.Form
	Public FTPExists As Boolean 'Ghetto Timeout Function :D
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConnect.Click
		
		'Stores UserName/Pass
		frmMain.strFTPUser = txtUserName.Text
		frmMain.strFTPPass = txtPass.Text
		
		'Declares Memory Units
		Dim lngStart As Integer
		Dim lngEnd As Integer
		Dim lngCur As Integer
		Dim intA As Short
		Dim strA As String
		
		'Checks if we need to Save Info
		If Me.chkSaveInfo.CheckState = 1 Then
			
			'Puts Pass into ASCII (Weak Hiding, I know)
			For intA = 1 To Len(Me.txtPass.Text)
				strA = strA & Asc(Mid(txtPass.Text, intA, 1)) & " "
			Next intA
			
			'Saves Settings
			VXCRSettings.strFTPUser = Me.txtUserName.Text
			VXCRSettings.strFTPPass = strA
			
			'Saves Settings to HHD
			SaveVXCRSettings()
			
		Else
			
			'Stores Nothing
			VXCRSettings.strFTPPass = "0"
			VXCRSettings.strFTPUser = "0"
			
		End If
		
		'Saves Recent Connected List
		VXCRSettings.strRConnect(0) = cmbIP.Text
		VXCRSettings.strRConnect(9) = VXCRSettings.strRConnect(8)
		VXCRSettings.strRConnect(8) = VXCRSettings.strRConnect(7)
		VXCRSettings.strRConnect(7) = VXCRSettings.strRConnect(6)
		VXCRSettings.strRConnect(6) = VXCRSettings.strRConnect(5)
		VXCRSettings.strRConnect(5) = VXCRSettings.strRConnect(4)
		VXCRSettings.strRConnect(4) = VXCRSettings.strRConnect(3)
		VXCRSettings.strRConnect(3) = VXCRSettings.strRConnect(2)
		VXCRSettings.strRConnect(2) = VXCRSettings.strRConnect(1)
		VXCRSettings.strRConnect(1) = VXCRSettings.strRConnect(0)
		
		'For some reason if we try to connect to the FTP
		'Server w/ the Wininet.dll and the IP Address doesnt
		'Exists or doesnt respond the APP will hang for a few
		'secs (30 i think), So this is the work around
		GoTo SKIPP
		
		'Sets initial Time
		lngStart = VB.Timer() '(Time past Midnight)
		
		'Connects to FTP
		tmrFireSocketCon.Enabled = True
		
		'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Do Until lngCur >= 2 Or Socket.CtlState = 7
			
			'Caculates Time that pasted since Start
			lngCur = VB.Timer() - lngStart
			
			'So we dont hog Sys Resources
			System.Windows.Forms.Application.DoEvents()
		Loop 
		
		'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		If Socket.CtlState <> 7 Then
			
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			MsgBox("Connection failed!, TODO: Proper Err Handle" & Socket.CtlState)
			Exit Sub
		End If
		
		'Socket.Close
		
		'END OF WORKAROUND ^^
		
SKIPP: 
		
		tmrWorkAround.Enabled = True
		
	End Sub
	
	Private Sub frmConnect_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim strB As Object
		
		'Declares Memory Varibles
		Dim intA As Short
		Dim strA As String
		Dim intB() As Short
		
		'Loads Recent IP Address
		cmbIP.Text = VXCRSettings.strRConnect(0)
		
		'Loads Other IP's in history
		For intA = 1 To 9
			cmbIP.Items.Add(VXCRSettings.strRConnect(intA))
		Next intA
		
		'Checks if we Stored Username & Password
		If VXCRSettings.strFTPPass <> "0" And VXCRSettings.strFTPUser <> "0" Then
			
			'Checks Option
			chkSaveInfo.CheckState = System.Windows.Forms.CheckState.Checked
			
			'Loads Password into Array
			'UPGRADE_WARNING: Couldn't resolve default property of object strB. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strB = Split(VXCRSettings.strFTPPass, " ")
			
			'Disscrambles All ASCII
			For intA = 0 To UBound(strB) - 1
				'UPGRADE_WARNING: Couldn't resolve default property of object strB(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strA = strA & Chr(strB(intA))
			Next intA
			
			'Loads Varibles
			Me.txtUserName.Text = VXCRSettings.strFTPUser
			Me.txtPass.Text = strA
			
		End If
		
	End Sub
	
	Public Function ConnectViaFTP() As Object
		
		'Connects to FTP
		If frmMain.mFTP.OpenConnection((cmbIP.Text), (frmMain.strFTPUser), (frmMain.strFTPPass)) Then
			
			Me.Hide()
			
			'Updates StatusBar
			'UPGRADE_WARNING: Lower bound of collection frmMain.stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			frmMain.stbMain.Items.Item(3).Text = "Connected"
			
			'Set FTP Settings
			frmMain.mFTP.SetTransferBinary()
			frmMain.mFTP.SetModeActive()
			
			'Connects To Server
			frmMain.mnuConnect_Click(Nothing, New System.EventArgs())
			
			'Unloads This window from Memory
			Me.Close()
			
		End If
		
	End Function
	
	Private Sub tmrFireSocketCon_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrFireSocketCon.Tick
		Socket.Close()
		Socket.connect(cmbIP.Text, "21")
		
		tmrFireSocketCon.Enabled = False
	End Sub
	
	Private Sub tmrWorkAround_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrWorkAround.Tick
		
		'Connects to FTP then Disables Timer
		ConnectViaFTP()
		
		'Disables Timer
		tmrWorkAround.Enabled = False
	End Sub
End Class