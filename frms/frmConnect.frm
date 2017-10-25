VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmConnect 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Virtual Xbox CD Ripper"
   ClientHeight    =   3360
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   5325
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmConnect.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3360
   ScaleWidth      =   5325
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer tmrFireSocketCon 
      Enabled         =   0   'False
      Interval        =   200
      Left            =   960
      Top             =   0
   End
   Begin VB.Timer tmrWorkAround 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   480
      Top             =   0
   End
   Begin VB.CheckBox chkSaveInfo 
      Caption         =   "Save Username && Password"
      Height          =   255
      Left            =   1320
      TabIndex        =   8
      Top             =   2400
      Width           =   3735
   End
   Begin MSWinsockLib.Winsock Socket 
      Left            =   0
      Top             =   0
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
      LocalPort       =   21
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   1320
      TabIndex        =   7
      Top             =   2760
      Width           =   1455
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "Connect"
      Default         =   -1  'True
      Height          =   375
      Left            =   3600
      TabIndex        =   3
      Top             =   2760
      Width           =   1455
   End
   Begin VB.TextBox txtUserName 
      Height          =   315
      Left            =   1320
      TabIndex        =   1
      Top             =   1680
      Width           =   3735
   End
   Begin VB.TextBox txtPass 
      Height          =   315
      Left            =   1320
      TabIndex        =   2
      Top             =   2040
      Width           =   3735
   End
   Begin VB.ComboBox cmbIP 
      Height          =   330
      ItemData        =   "frmConnect.frx":472A
      Left            =   1320
      List            =   "frmConnect.frx":472C
      TabIndex        =   0
      Text            =   "192.168.0.109"
      Top             =   1080
      Width           =   3735
   End
   Begin VB.Label lblStuff 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Password:"
      Height          =   255
      Index           =   2
      Left            =   120
      TabIndex        =   6
      Top             =   2040
      Width           =   1095
   End
   Begin VB.Label lblStuff 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "User Name:"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   5
      Top             =   1680
      Width           =   1095
   End
   Begin VB.Label lblStuff 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Xbox's IP:"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   4
      Top             =   1080
      Width           =   1095
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00808080&
      BorderStyle     =   6  'Inside Solid
      Index           =   1
      X1              =   0
      X2              =   5564
      Y1              =   795
      Y2              =   795
   End
   Begin VB.Image imgTop 
      Height          =   795
      Left            =   0
      Picture         =   "frmConnect.frx":472E
      Top             =   0
      Width           =   5370
   End
End
Attribute VB_Name = "frmConnect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public FTPExists As Boolean 'Ghetto Timeout Function :D

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdConnect_Click()
    
    'Stores UserName/Pass
    frmMain.strFTPUser = txtUserName.text
    frmMain.strFTPPass = txtPass.text
    
    'Declares Memory Units
    Dim lngStart As Long
    Dim lngEnd As Long
    Dim lngCur As Long
    Dim intA As Integer
    Dim strA As String
    
    'Checks if we need to Save Info
    If Me.chkSaveInfo.value = 1 Then
        
        'Puts Pass into ASCII (Weak Hiding, I know)
        For intA = 1 To Len(Me.txtPass)
            strA = strA & Asc(Mid(txtPass.text, intA, 1)) & " "
        Next intA
        
        'Saves Settings
        VXCRSettings.strFTPUser = Me.txtUserName
        VXCRSettings.strFTPPass = strA
        
        'Saves Settings to HHD
        SaveVXCRSettings
        
      Else
        
        'Stores Nothing
        VXCRSettings.strFTPPass = "0"
        VXCRSettings.strFTPUser = "0"
        
    End If
    
    'Saves Recent Connected List
    VXCRSettings.strRConnect(0) = cmbIP.text
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
    lngStart = Timer '(Time past Midnight)
    
    'Connects to FTP
    tmrFireSocketCon.Enabled = True
    
    Do Until lngCur >= 2 Or Socket.State = 7
        
        'Caculates Time that pasted since Start
        lngCur = Timer - lngStart
                    
        'So we dont hog Sys Resources
        DoEvents
    Loop
    
    If Socket.State <> 7 Then
        
        MsgBox "Connection failed!, TODO: Proper Err Handle" & Socket.State
        Exit Sub
    End If
    
    'Socket.Close
    
    'END OF WORKAROUND ^^
    
SKIPP:

    tmrWorkAround.Enabled = True

End Sub

Private Sub Form_Load()
    
    'Declares Memory Varibles
    Dim intA As Integer
    Dim strA As String
    Dim intB() As Integer
    
    'Loads Recent IP Address
    cmbIP.text = VXCRSettings.strRConnect(0)
    
    'Loads Other IP's in history
    For intA = 1 To 9
        cmbIP.AddItem VXCRSettings.strRConnect(intA)
    Next intA
    
    'Checks if we Stored Username & Password
    If VXCRSettings.strFTPPass <> "0" And VXCRSettings.strFTPUser <> "0" Then
        
        'Checks Option
        chkSaveInfo.value = 1
        
        'Loads Password into Array
        strB = Split(VXCRSettings.strFTPPass, " ")
        
        'Disscrambles All ASCII
        For intA = 0 To UBound(strB) - 1
            strA = strA & Chr(strB(intA))
        Next intA
        
        'Loads Varibles
        Me.txtUserName.text = VXCRSettings.strFTPUser
        Me.txtPass.text = strA
        
    End If
    
End Sub

Public Function ConnectViaFTP()
    
    'Connects to FTP
    If frmMain.mFTP.OpenConnection(cmbIP.text, frmMain.strFTPUser, frmMain.strFTPPass) Then
        
        Me.Hide
        
        'Updates StatusBar
        frmMain.stbMain.Panels(3).text = "Connected"
        
        'Set FTP Settings
        frmMain.mFTP.SetTransferBinary
        frmMain.mFTP.SetModeActive
                
        'Connects To Server
        frmMain.mnuConnect_Click
                
        'Unloads This window from Memory
        Unload Me
        
    End If
    
End Function

Private Sub tmrFireSocketCon_Timer()
    Socket.Close
    Socket.connect cmbIP.text, "21"
    
    tmrFireSocketCon.Enabled = False
End Sub

Private Sub tmrWorkAround_Timer()
    
    'Connects to FTP then Disables Timer
    ConnectViaFTP
    
    'Disables Timer
    tmrWorkAround.Enabled = False
End Sub
