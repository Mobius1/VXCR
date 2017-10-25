VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmEditTitle 
   Caption         =   "Edit Name"
   ClientHeight    =   3930
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6285
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmEditTitle.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   3930
   ScaleWidth      =   6285
   StartUpPosition =   3  'Windows Default
   Begin VB.CheckBox chkStop 
      Caption         =   "Never Ask Again!"
      Height          =   255
      Left            =   120
      TabIndex        =   2
      Top             =   3600
      Width           =   1935
   End
   Begin VB.CommandButton cmdApply 
      Caption         =   "Apply"
      Height          =   375
      Left            =   4440
      TabIndex        =   1
      Top             =   3480
      Width           =   1695
   End
   Begin MSComctlLib.ListView lvName 
      Height          =   3255
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   6015
      _ExtentX        =   10610
      _ExtentY        =   5741
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   2
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Name"
         Object.Width           =   2893
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Bitrate"
         Object.Width           =   2540
      EndProperty
   End
   Begin VB.CommandButton cmdEdit 
      Caption         =   "Edit"
      Height          =   375
      Left            =   2760
      TabIndex        =   3
      Top             =   3480
      Width           =   1695
   End
End
Attribute VB_Name = "frmEditTitle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdApply_Click()
    
    'Declares Memory Varibles
    Dim lngA As Long
    
    'Changes Names
    For lngA = 1 To lvName.ListItems.Count
        DoEvents
        
        'Updates Item
        frmMain.lvPC.ListItems(Int(Replace(lvName.ListItems(lngA).TaG, "#", ""))).text = lvName.ListItems(lngA).text
                
    Next lngA
    
    'Saves Settings
    If Me.chkStop.value = 1 Then
        VXCRSettings.blnManuIDTag = False
      Else
        VXCRSettings.blnManuIDTag = True
    End If
    
    'Hides Me
    Me.Hide
    
    'Sets Focus to Main Window
    frmMain.SetFocus
    
    'Starts the Upload/Convert Process
    frmMain.UploadSongs
    
    Unload Me
End Sub

Private Sub cmdEdit_Click()
    
    'Sets Focus and Edits
    lvName.SetFocus
    lvName.StartLabelEdit
    
End Sub

Private Sub Form_Load()

    'Declares Memory Varibles
    Dim lngA As Long
    
    'Loads Selected Items to Local Listview
    For lngA = 1 To frmMain.lvPC.ListItems.Count
        DoEvents
        
        'Checks if Item is Checked
        If frmMain.lvPC.ListItems(lngA).Checked = True Then
            
            'Adds New Item
            Me.lvName.ListItems.Add , , frmMain.lvPC.ListItems(lngA).text
            Me.lvName.ListItems(lvName.ListItems.Count).SubItems(1) = frmMain.lvPC.ListItems(lngA).SubItems(1)
            Me.lvName.ListItems(lvName.ListItems.Count).TaG = "#" & lngA
            
        End If
    Next lngA
    
    'Checked Item
    Me.chkStop.value = 0
    
    'Resizes LV
    ReSizeLV Me.lvName, 1
    
    
End Sub

