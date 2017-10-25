VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmGamePatcher 
   Caption         =   "Virtual Xbox CD Ripper - Game Patcher"
   ClientHeight    =   6750
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8820
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   6750
   ScaleWidth      =   8820
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdSearch 
      Caption         =   "Search"
      Height          =   375
      Left            =   4200
      TabIndex        =   2
      Top             =   6000
      Width           =   855
   End
   Begin VB.CommandButton cmdPatch 
      Caption         =   "Patch Selected Games"
      Height          =   615
      Left            =   6480
      TabIndex        =   1
      Top             =   5880
      Width           =   1695
   End
   Begin MSComctlLib.ListView lvGames 
      Height          =   5055
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   7095
      _ExtentX        =   12515
      _ExtentY        =   8916
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   3
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Object.Width           =   2540
      EndProperty
   End
End
Attribute VB_Name = "frmGamePatcher"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdSearch_Click()
    Dim Item As cDirItem
    Dim lstX As ListItem
    Dim lngA As Long
    Dim strPath As String
    
    strPath = "/E/"
    
    frmMain.mFTP.SetFTPDirectory "/E/"
    frmMain.mFTP.GetDirectoryListing "*.*"
    
   For lngA = 1 To frmMain.mFTP.Directory.Count
        DoEvents
        
        lvGames.ListItems.Add , , frmMain.mFTP.Directory.Item(lngA).Filename
        lvGames.ListItems(lvGames.ListItems.Count).SubItems(1) = strPath
        lvGames.ListItems(lvGames.ListItems.Count).SubItems(2) = frmMain.mFTP.Directory.Item(lngA).Directory
        
        
    Next
    
End Sub
