VERSION 5.00
Begin VB.Form frmAbout 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "About"
   ClientHeight    =   3855
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   5685
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmAbout.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3855
   ScaleWidth      =   5685
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdOK 
      Caption         =   "OK"
      Height          =   375
      Left            =   3600
      TabIndex        =   0
      Top             =   3360
      Width           =   1815
   End
   Begin VB.Label lblInfo 
      BackStyle       =   0  'Transparent
      Caption         =   "Special Thanks To:[GS]EqUaTe, Furious Styles, Rahszhul, YuYu.  Anyone that I missed Contact me :)."
      Height          =   570
      Index           =   1
      Left            =   240
      TabIndex        =   2
      Top             =   2760
      Width           =   4680
   End
   Begin VB.Label lblInfo 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Designed And Developed By:  BlueCELL && Xbox War3z"
      Height          =   210
      Index           =   0
      Left            =   240
      TabIndex        =   1
      Top             =   2400
      Width           =   3990
   End
   Begin VB.Image imgAbout 
      Height          =   2280
      Left            =   0
      Picture         =   "frmAbout.frx":472A
      Top             =   0
      Width           =   5685
   End
End
Attribute VB_Name = "frmAbout"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdOK_Click()
    
    'Terminates This Window
    Unload Me
    
End Sub

Private Sub Form_Load()
    
    'Transfers Picture from frmSplash
    'Me.imgAbout.Picture = frmSplash.Image1.Picture
    Unload frmSplash
    
End Sub

