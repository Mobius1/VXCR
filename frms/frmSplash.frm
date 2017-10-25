VERSION 5.00
Begin VB.Form frmSplash 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   2280
   ClientLeft      =   15
   ClientTop       =   15
   ClientWidth     =   5745
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2280
   ScaleWidth      =   5745
   ShowInTaskbar   =   0   'False
   Begin VB.Timer tmrUpdate 
      Interval        =   2000
      Left            =   0
      Top             =   120
   End
   Begin VB.Image Image1 
      Height          =   2280
      Left            =   0
      Picture         =   "frmSplash.frx":0000
      Top             =   0
      Width           =   5685
   End
End
Attribute VB_Name = "frmSplash"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    'Sets Splash in Center Screer of Screen lill Higher
    Me.top = (Screen.Height * 0.65) / 2 - Me.Height / 25 ',85
    Me.Left = Screen.Width / 2 - Me.Width / 2

End Sub

Private Sub tmrUpdate_Timer()
    
    'Loads Main Window
    frmMain.Show
    Unload Me
End Sub
