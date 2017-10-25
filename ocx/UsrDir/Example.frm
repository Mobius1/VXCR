VERSION 5.00
Object = "{15AD080C-2DA2-11D4-88AD-0080C6F9B4ED}#22.0#0"; "Dir Folder.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   8250
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8295
   LinkTopic       =   "Form1"
   ScaleHeight     =   8250
   ScaleWidth      =   8295
   StartUpPosition =   3  'Windows Default
   Begin DirFolder.usrDir usrDir1 
      Height          =   7575
      Left            =   240
      TabIndex        =   0
      Top             =   120
      Width           =   7695
      _ExtentX        =   13573
      _ExtentY        =   13361
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
usrDir1.AutoExpend = True 'Auto Expend all the File
End Sub

Private Sub usrDir1_Click()
Me.Caption = usrDir1.Path
End Sub
