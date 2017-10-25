VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Object = "{19B7F2A2-1610-11D3-BF30-1AF820524153}#1.2#0"; "ccrpftv6.ocx"
Begin VB.Form frmMain 
   AutoRedraw      =   -1  'True
   Caption         =   "Virtual Xbox CD Ripper (Build INFO)"
   ClientHeight    =   6570
   ClientLeft      =   165
   ClientTop       =   855
   ClientWidth     =   10095
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   438
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   673
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   255
      Left            =   6000
      TabIndex        =   9
      Top             =   3360
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.Timer tmrResize 
      Interval        =   250
      Left            =   9000
      Top             =   720
   End
   Begin MSWinsockLib.Winsock sockCDDB 
      Left            =   9480
      Top             =   720
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
      LocalPort       =   8880
   End
   Begin MSComctlLib.Toolbar tlbTransfer 
      Height          =   330
      Left            =   6480
      TabIndex        =   8
      Top             =   3360
      Width           =   3450
      _ExtentX        =   6085
      _ExtentY        =   582
      ButtonWidth     =   1958
      ButtonHeight    =   582
      AllowCustomize  =   0   'False
      Wrappable       =   0   'False
      Style           =   1
      TextAlignment   =   1
      ImageList       =   "imgList1"
      DisabledImageList=   "imgList1"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   4
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Upload"
            Key             =   "Upload"
            ImageIndex      =   15
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Download"
            Key             =   "Download"
            ImageIndex      =   16
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Delete"
            Key             =   "Delete"
            ImageIndex      =   19
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.Toolbar tlbPlayer 
      Height          =   330
      Left            =   4245
      TabIndex        =   7
      Top             =   3360
      Width           =   1650
      _ExtentX        =   2910
      _ExtentY        =   582
      ButtonWidth     =   1296
      ButtonHeight    =   582
      AllowCustomize  =   0   'False
      Wrappable       =   0   'False
      Style           =   1
      TextAlignment   =   1
      ImageList       =   "imgList1"
      DisabledImageList=   "imgList1"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   2
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Play"
            Key             =   "Play"
            ImageIndex      =   7
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Stop"
            Key             =   "Stop"
            ImageIndex      =   12
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ProgressBar stbp 
      Height          =   255
      Left            =   1560
      TabIndex        =   6
      Top             =   6360
      Width           =   1335
      _ExtentX        =   2355
      _ExtentY        =   450
      _Version        =   393216
      Appearance      =   0
      Scrolling       =   1
   End
   Begin CCRPFolderTV6.FolderTreeview ftvPC 
      Height          =   2535
      Left            =   120
      TabIndex        =   5
      Top             =   3720
      Width           =   4095
      _ExtentX        =   7223
      _ExtentY        =   4471
      IntegralHeight  =   0   'False
   End
   Begin MSComctlLib.StatusBar stbMain 
      Align           =   2  'Align Bottom
      Height          =   285
      Left            =   0
      TabIndex        =   1
      Top             =   6285
      Width           =   10095
      _ExtentX        =   17806
      _ExtentY        =   503
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   5
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Text            =   "Status"
            TextSave        =   "Status"
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Text            =   "Disconnected"
            TextSave        =   "Disconnected"
         EndProperty
         BeginProperty Panel4 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   6
            TextSave        =   "10/19/2004"
         EndProperty
         BeginProperty Panel5 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Style           =   5
            TextSave        =   "6:49 PM"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList imgList1 
      Left            =   0
      Top             =   0
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   20
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":472A
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":4AC4
            Key             =   ""
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":4E5E
            Key             =   ""
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":51F8
            Key             =   ""
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":7B4A
            Key             =   ""
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":7EE4
            Key             =   ""
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":827E
            Key             =   ""
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":8618
            Key             =   ""
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":89B2
            Key             =   ""
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":91C4
            Key             =   ""
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":955E
            Key             =   ""
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":98F8
            Key             =   ""
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":9C92
            Key             =   ""
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":A02C
            Key             =   ""
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":A3C6
            Key             =   ""
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":A760
            Key             =   ""
         EndProperty
         BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":AAFA
            Key             =   ""
         EndProperty
         BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":AE94
            Key             =   ""
         EndProperty
         BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":B22E
            Key             =   ""
         EndProperty
         BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":B5C8
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ListView lvPC 
      Height          =   2535
      Left            =   4245
      TabIndex        =   2
      Top             =   3720
      Width           =   5730
      _ExtentX        =   10107
      _ExtentY        =   4471
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      Checkboxes      =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      SmallIcons      =   "imgList1"
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   3
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Name"
         Object.Width           =   4304
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Status/Bitrate"
         Object.Width           =   2381
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "Size"
         Object.Width           =   2540
      EndProperty
   End
   Begin MSComctlLib.ListView lvXbox 
      Height          =   2625
      Left            =   4245
      TabIndex        =   3
      Top             =   705
      Width           =   5730
      _ExtentX        =   10107
      _ExtentY        =   4630
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      Checkboxes      =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   4
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Name"
         Object.Width           =   265
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Time"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "Path"
         Object.Width           =   0
      EndProperty
      BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   3
         Text            =   "ID"
         Object.Width           =   0
      EndProperty
   End
   Begin MSComctlLib.TreeView tvXbox 
      Height          =   2985
      Left            =   120
      TabIndex        =   4
      Top             =   705
      Width           =   4095
      _ExtentX        =   7223
      _ExtentY        =   5265
      _Version        =   393217
      Indentation     =   550
      LabelEdit       =   1
      Style           =   7
      ImageList       =   "imgList1"
      Appearance      =   1
   End
   Begin MSComctlLib.Toolbar tbMain 
      Align           =   1  'Align Top
      Height          =   570
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10095
      _ExtentX        =   17806
      _ExtentY        =   1005
      ButtonWidth     =   1244
      ButtonHeight    =   953
      Appearance      =   1
      Style           =   1
      ImageList       =   "imgList1"
      DisabledImageList=   "imgList1"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   11
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Connect"
            Key             =   "Connect"
            ImageIndex      =   2
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Close"
            Key             =   "Close"
            ImageIndex      =   3
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            ImageIndex      =   5
            Style           =   3
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Add"
            Key             =   "Add"
            ImageIndex      =   20
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Caption         =   "Remove"
            Key             =   "Remove"
            ImageIndex      =   19
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Search"
            Key             =   "Search"
            ImageIndex      =   11
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "Options"
            Key             =   "Options"
            ImageIndex      =   5
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button11 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Caption         =   "About"
            Key             =   "About"
            ImageIndex      =   6
         EndProperty
      EndProperty
   End
   Begin VB.Menu tlbXBOX 
      Caption         =   "mnuXbox"
      Begin VB.Menu mnuPatch 
         Caption         =   "Game Patcher"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnusp7 
         Caption         =   "-"
      End
      Begin VB.Menu mnuEDrive 
         Caption         =   "E Drive (Normal)"
         Checked         =   -1  'True
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuFDrive 
         Caption         =   "F Drive (Extend)"
         Enabled         =   0   'False
      End
   End
   Begin VB.Menu mnuLVPC 
      Caption         =   "lvPCMenu"
      Begin VB.Menu mnuPCSelAll 
         Caption         =   "Select All"
      End
      Begin VB.Menu mnuPCUnSelALL 
         Caption         =   "UnSelect All"
      End
   End
   Begin VB.Menu mnuSongList 
      Caption         =   "SongListMNU"
      Begin VB.Menu mnuSelAll 
         Caption         =   "Select All"
      End
      Begin VB.Menu mnuUnSel 
         Caption         =   "UnSelect All"
      End
      Begin VB.Menu sp12321 
         Caption         =   "-"
      End
      Begin VB.Menu mnuSLDelete 
         Caption         =   "Delete"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuSLRename 
         Caption         =   "Rename"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnusp3 
         Caption         =   "-"
      End
      Begin VB.Menu mnuSLIDTag 
         Caption         =   "Edit ID Tag"
         Enabled         =   0   'False
      End
   End
   Begin VB.Menu mnuSoundTrack 
      Caption         =   "SoundTrackMNU"
      Begin VB.Menu mnuAddSST 
         Caption         =   "Add"
      End
      Begin VB.Menu mnuRemoveST 
         Caption         =   "Remove"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnusp1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuRenameST 
         Caption         =   "Rename"
         Enabled         =   0   'False
      End
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuRConnect 
         Caption         =   "Connect"
      End
      Begin VB.Menu mnuDisconnect 
         Caption         =   "Disconnect"
      End
      Begin VB.Menu mnusp2 
         Caption         =   "-"
      End
      Begin VB.Menu mnuConnect 
         Caption         =   "Connect (Invisiable, For Connection)"
         Visible         =   0   'False
      End
      Begin VB.Menu mnuExit 
         Caption         =   "Exit"
      End
   End
   Begin VB.Menu mnuRSoundTracks 
      Caption         =   "&SoundTracks"
      Begin VB.Menu mnuRSTAdd 
         Caption         =   "Add"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuRSTRemove 
         Caption         =   "Remove"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuRSTRename 
         Caption         =   "Rename"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnusp5 
         Caption         =   "-"
      End
      Begin VB.Menu mnuImportST 
         Caption         =   "Import Folder as SoundTrack"
         Enabled         =   0   'False
      End
   End
   Begin VB.Menu mnuSongS 
      Caption         =   "S&ongs"
      Begin VB.Menu mnuAddSongs 
         Caption         =   "Add Song(s)"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnuSelFolder 
         Caption         =   "Import Folder"
         Enabled         =   0   'False
      End
      Begin VB.Menu mnusp6 
         Caption         =   "-"
      End
      Begin VB.Menu mnuSongSearch 
         Caption         =   "Search"
      End
   End
   Begin VB.Menu mnuHelp 
      Caption         =   "&Help"
      Begin VB.Menu mnuAbout 
         Caption         =   "About"
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public WithEvents mFTP As cFTP
Attribute mFTP.VB_VarHelpID = -1

'FTP Login Information
Public strFTPUser As String
Public strFTPPass As String

'FTP Progress (Tells Us what We are Doing)
Public intDo As Integer

'Music Handle
Public chan As Long

'Random FileName
Public strSTDBLoc As String 'ST.DB File
Public strXAFile As String  'Xbox SoundTrack Preview
Public strXTrans As String  'File Used to Transfer Files (XBox->PC)
Public strXTNames As String 'strXTrans Orginal File Name

'Stores the Which Listview was click on last (Preview Button)
Public intSelectedLV As Integer

'Settings Used in App
Public strDriveLetter As String

Private Sub Command1_Click()
MsgBox FindFreeSongGroup
End Sub

Private Sub Form_Load()
    
    'Resizes Column Headers/Status bar
    ReSizeLV lvPC, 1
    ReSizeLV lvXbox, 1
    ResizeStatusBar Me.stbMain, 1
        
    'Loads Settings
    LoadVXCRSettings
       
    'Lists CD Drives
    ListCDDrives stbMain
    
    'Adds First Node to TreeView
    Me.tvXbox.Nodes.Add , , "XB", "Xbox Sound Tracks", 14
    tvXbox.Nodes("XB").Expanded = True
    
    'Sets Doing Variable
    intDo = 0
    stbp.value = 0
    
    strDriveLetter = "/e"
    
    'Unloads Not Nessary Menu Items
    mnuSongList.Visible = False
    mnuSoundTrack.Visible = False
    mnuLVPC.Visible = False
    tlbXBOX.Visible = False
           
    'Sets Up FTP
    Set mFTP = New cFTP
    mFTP.SetModeActive
    mFTP.SetTransferBinary
    
    'Checks if Temp Folder Exists
    If modFileSystem.fFolderExists(VXCRSettings.strTempFld) <> True Or VXCRSettings.strTempFld = "" Then
        
        'Notifies User that Temp Folder Doesnt Exists
        MsgBox "The Selected Temporary Folder doesnt Exists:" & vbCrLf & vbclr & _
                VXCRSettings.strTempFld & vbCrLf & vbCrLf & _
                "Please Select a New Temporary Folder Now.", vbOKOnly + vbExclamation
        
        'Shows Option Dialog
        frmOptions.Show
        
        'Presses Browse Button
        frmOptions.cmdSelFld_Click
                
    End If
    
    'Updates Status Bar
    stbMain.Panels(1).text = "Ready"
    Me.Caption = "Virtual Xbox CD Ripper (Build 101904)"
    
    '-----------------------
    'BUILD INFO
    '-----------------------
    Exit Sub
    
    Dim intBuild As Integer
    Open App.path & "\build.ini" For Input As #11
    Input #11, intBuild
    Close #11
    intBuild = intBuild + 1
    Open App.path & "\build.ini" For Output As #11
    Print #11, intBuild
    Close #11
    Me.Caption = "Virtual Xbox CD Ripper (Build A404-" & intBuild & ")"
    
End Sub

Private Sub Form_Resize()
       
    'Resizes Controls
    lvXbox.Width = Me.ScaleWidth - (lvXbox.Left + 8)
    lvPC.Width = Me.ScaleWidth - (lvPC.Left + 8)
    tlbTransfer.Left = (lvXbox.Width + lvXbox.Left) - tlbTransfer.Width
    tvXbox.Height = ((Me.ScaleHeight / 2) - (tbMain.Height - 5) + tlbPlayer.Height) - 9
    ftvPC.top = (tvXbox.Height + lvXbox.top) + 2
    ftvPC.Height = (Me.ScaleHeight - ftvPC.top) - 21
    lvPC.top = ftvPC.top
    lvPC.Height = ftvPC.Height
    lvXbox.Height = (tvXbox.Height - tlbPlayer.Height) - 2
    tlbPlayer.top = (lvXbox.top + lvXbox.Height) + 2
    tlbTransfer.top = tlbPlayer.top
    
    'Resizes Listview
    ReSizeLV lvPC, 1
    ReSizeLV lvXbox, 1
    
    'Resizes Status Bar
    ResizeStatusBar stbMain, 1
    
    'Sets Progressbar in StatusBar
    stbp.Width = stbMain.Panels(2).Width - 4
    stbp.Height = stbMain.Height - 5
    stbp.Left = stbMain.Panels(2).Left + 3
    stbp.top = stbMain.top + 4
    
End Sub

Private Sub Form_Unload(Cancel As Integer)
    On Error Resume Next
    
    'Terminates FTP
    mFTP.CloseConnection
    
    'Unloads Audio
    BASS_Stop
    BASS_Free
    
    'Deletes Files
    Kill strSTDBLoc
    Kill strXAFile
    
    'Saves Settings
    SaveVXCRSettings
    
End Sub

Private Sub ftvPC_FolderClick(Folder As CCRPFolderTV6.Folder, Location As CCRPFolderTV6.ftvHitTestConstants)
    'CancelReadPath = True
    
    'Looks For Possible CD Drive
    If Len(Folder.FullPath) = 3 Then
   
        'Checks if CD Drive
        If InStr(1, strCDDrives, Left(Folder.FullPath, 1)) Then
            
            'Sets LvPC to work w/ CD Ripper
            ListviewPCCDRipper lvPC
            
            'Reads Track List from CD
            LoadTrackList lvPC, stbMain
            
            Exit Sub
        End If
    End If
        
    'Sets LvPC to work w/ File Viewing
    ListviewPCFileView lvPC
    
    'Checks if Last List is canceld
    
        
        'Reads Folder Path
        ReadPath Folder.FullPath, lvPC, stbMain

End Sub

Private Sub Socket_DataArrival(ByVal bytesTotal As Long)
    
    Dim strInput As String
    Socket.GetData strInput
    
End Sub

Private Sub lvPC_Click()
    
    'Stores This LV has Focus
    intSelectedLV = 0
     
End Sub

Private Sub lvXbox_Click()

    'Stores This LV has Focus
    intSelectedLV = 1
    
End Sub

Private Sub lvXbox_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    
    'Checks for Right Click
    If Button = 2 Then
    
        'Shows the Popup Menu
        PopupMenu mnuSongList
        
    End If
    
End Sub

Private Sub mFTP_FileTransferProgress(lCurrentBytes As Long, lTotalBytes As Long)
    
    'Declares Memory Values
    Dim InitBass As Boolean
    Dim intProgress As Integer
    
    intProgress = Format(lCurrentBytes / lTotalBytes * 100, "00.00")
    
    'Updates Status for whatever is happening
    Select Case intDo
    
        'Download ST.DB File
        Case 1000
            
            'Updates Status Bar
            stbMain.Panels(1).text = "Downloading Database..."
            stbp.value = intProgress
            
            'Checks if Download Is Done
            If intProgress = 100 Then
            
                'Updates StatusBar
                stbMain.Panels(1).text = "Reading Database..."
                stbp.value = 0
                
                'Reads ST.DB file
                Initialize strSTDBLoc
                
                'Lists SoundTracks
                ReadSoundTracks tvXbox
                
                'Dont know but if you dont call this on initlial it aint working
                FindFreeSongGroup
                FindFreeSongGroup
                FindFreeSongGroup
                
                'Updates StatusBar
                stbMain.Panels(1).text = "Ready"
                
                'Sets Nothing
                intDo = 9999
                
            End If
            
        'Xbox SoundTrack Preview (File Progress)
        Case 1001
            
            'Disables Play/Stop Button
            tlbPlayer.Buttons(1).Enabled = False
            tlbPlayer.Buttons(2).Enabled = False
    
            'Updates Status Bar
            stbMain.Panels(1).text = "Downloading Xbox Preview Track..."
            stbp.value = intProgress
            
            'Checks if Download Is Done
            If intProgress = 100 Then
                   
                                
                'Sets Up Audio Drivers
                InitBass = BASS_Init(1, 44100, 0, Me.hWnd, 0)
    
                'Frees Stream Channels
                BASS_StreamFree chan
                BASS_MusicFree chan
                
                Call BASS_ChannelSetAttributes(chan, 0, 100, 0)
                
                'Loads File and Plays
                chan = BASS_WMA_StreamCreateFile(BASSFALSE, strXAFile, 0, 0, BASS_STREAM_AUTOFREE Or BASS_STREAM_AUTOFREE)
                
                BASS_StreamPlay chan, 0, 0
                              
                'Updates StatusBar
                stbMain.Panels(1).text = "Ready"
                stbp.value = 0
                
                'Enables Play/Stop Button
                tlbPlayer.Buttons(1).Enabled = True
                tlbPlayer.Buttons(2).Enabled = True
            
                'Sets Nothing
                intDo = 9999
                
            End If
            
        'File Transfer (XBOX->PC)
        Case 1002
            
            'Updates Status Bar
            stbMain.Panels(1).text = "Downloading Xbox Track..."
            stbp.value = intProgress
            
            'Checks if Download Is Done
            If intProgress = 100 Then
                                
                'Updates StatusBar
                stbMain.Panels(1).text = "Local Copying..."
                
                'Copies File to final Destination
                CopyFile strXTrans, strLoc & "\" & strXTNames & ".wma"
                                
                'Reads Folder Path
                ReadPath strLoc & "\", lvPC, stbMain
   
                'Updates StatusBar
                stbMain.Panels(1).text = "Ready"
                Me.stbp.value = 0
                                
                'Sets Nothing
                intDo = 9999
                
            End If
            
        'File Transfer (PC->XBOX)
        Case 1003
        
            'Updates Status Bar
            stbMain.Panels(1).text = "Sending to Xbox, Please Wait..."
            stbp.value = intProgress
            
            'Checks if Download Is Done
            If intProgress = 100 Then
                                
                'Updates StatusBar
                stbMain.Panels(1).text = "Ready"
                Me.stbp.value = 0
                                
                'Sets Nothing
                intDo = 9999
                
            End If
    End Select
    
End Sub

Private Sub mnuAbout_Click()

    'Shows About Dialog
    frmAbout.Show
    
End Sub

Private Sub mnuAddSST_Click()
    'Adds New SoundTrack
    AddSoundTrack InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox
    UploadST
    
End Sub

Public Sub mnuConnect_Click()
        
        'Sets Downloading Variable
        frmMain.intDo = 1000
        
        strSTDBLoc = VXCRSettings.strTempFld & RandomFile
        
        'Disables/Enables Buttons
        tbMain.Buttons(1).Enabled = False
        tbMain.Buttons(2).Enabled = True
        tbMain.Buttons(4).Enabled = True
        tbMain.Buttons(5).Enabled = True
        tlbTransfer.Buttons(1).Enabled = True
        tlbTransfer.Buttons(2).Enabled = True
        tlbTransfer.Buttons(3).Enabled = True
        
        DetectFTP
        
        'Set folder to music folder
        If frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & "tdata/fffe0000/music") Then
         
            'Downloads ST.DB File from FTP Server (Xbox)
            a = frmMain.mFTP.FTPDownloadFile(strSTDBLoc, "st.db")
                       
        Else
            
            MsgBox "Error Connecting to FTP Folder"
            
        End If
        
End Sub

Private Sub mnuDisconnect_Click()
            
    'Closes ST.DB Manager
    TerminateST
            
    If frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & "tdata/fffe0000/music") Then
         
        'Downloads ST.DB File from FTP Server (Xbox)
        a = frmMain.mFTP.SimpleFTPPutFile(strSTDBLoc, "st.db")
                       
        Else
        MsgBox "Error Uploading Database"
    End If
            
    'Disconnects from ALL FTP Servers
    mFTP.CloseConnection
            
    'Deletes Temp ST.DB File
    Kill strSTDBLoc
            
    'Disables/Enables Buttons
    tbMain.Buttons(1).Enabled = True
    tbMain.Buttons(2).Enabled = False
    tbMain.Buttons(4).Enabled = False
    tbMain.Buttons(5).Enabled = False
    tlbTransfer.Buttons(1).Enabled = False
    tlbTransfer.Buttons(2).Enabled = False
    tlbTransfer.Buttons(3).Enabled = False
            
    'Resets Xbox Treeview
    tvXbox.Nodes.Clear
    tvXbox.Nodes.Add , , "XB", "Xbox Sound Tracks", 14
    tvXbox.Nodes("XB").Expanded = True
            
    'Reset Soundtrack Listview
    lvXbox.ListItems.Clear
            
End Sub

Private Sub mnuExit_Click()
    End
End Sub

Private Sub mnuPatch_Click()
    
    'Shows Patching Dialog
    frmGamePatcher.Show
    
End Sub

Private Sub mnuPCSelAll_Click()
    
    'Checks lvXbox's Count
    If lvPC.ListItems.Count = 0 Then Exit Sub
    
    'Delcare Memory Varibles
    Dim lngA As Long
    For lngA = 1 To lvPC.ListItems.Count
        DoEvents
        
        'Checks lvXbox Item
        lvPC.ListItems(lngA).Checked = True
    Next lngA
End Sub

Private Sub mnuPCUnSelALL_Click()
    
    'Checks lvXbox's Count
    If lvPC.ListItems.Count = 0 Then Exit Sub
    
    'Delcare Memory Varibles
    Dim lngA As Long
    For lngA = 1 To lvPC.ListItems.Count
        DoEvents
        
        'Checks lvXbox Item
        lvPC.ListItems(lngA).Checked = False
    Next lngA
    
End Sub

Private Sub mnuRConnect_Click()

    'Shows Connect Dialog
    frmConnect.Show
    
End Sub

Private Sub mnuRSTAdd_Click()
    
    'Adds New SoundTrack
    AddSoundTrack InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox
    
End Sub

Private Sub mnuSelAll_Click()
    
    'Checks lvXbox's Count
    If lvXbox.ListItems.Count = 0 Then Exit Sub
    
    'Delcare Memory Varibles
    Dim lngA As Long
    For lngA = 1 To lvXbox.ListItems.Count
        DoEvents
        
        'Checks lvXbox Item
        lvXbox.ListItems(lngA).Checked = True
    Next lngA
    
End Sub

Private Sub mnuSongSearch_Click()
    
    'Shows Search Window
    frmSearch.Show
End Sub

Private Sub mnuUnSel_Click()
    
    'Checks lvXbox's Count
    If lvXbox.ListItems.Count = 0 Then Exit Sub
    
    'Delcare Memory Varibles
    Dim lngA As Long
    For lngA = 1 To lvXbox.ListItems.Count
        DoEvents
        
        'Checks lvXbox Item
        lvXbox.ListItems(lngA).Checked = False
    Next lngA
    
End Sub

Private Sub sockCDDB_Connect()
    
    'Handshake
    Winsock1.SendData "cddb hello " & CurrentMachineName & " " & sockCDDB.LocalIP & " Virtual_Xbox_CD_Ripper" & vbCrLf
    
End Sub

Private Sub tbMain_ButtonClick(ByVal Button As MSComctlLib.Button)
    
    'Selects Which Button is Pressed
    Select Case Button.Key
    
        'Connect Button
        Case "Connect"
                        
            'Shows Connect Dialog
            frmConnect.Show
            
        'Close Button
        Case "Close"
            
            If UploadST = False Then
                MsgBox "Virtual Xbox CD Ripper has failed to upload the SoundTrack Database!" & vbCrLf & _
                    "Please Reconnect now."
                
                Exit Sub
            End If
            
            'Disconnects from ALL FTP Servers
            mFTP.CloseConnection
            
            'Deletes Temp ST.DB File
            Kill strSTDBLoc
            
            'Disables/Enables Buttons
            tbMain.Buttons(1).Enabled = True
            tbMain.Buttons(2).Enabled = False
            tbMain.Buttons(4).Enabled = False
            tbMain.Buttons(5).Enabled = False
            tlbTransfer.Buttons(1).Enabled = False
            tlbTransfer.Buttons(2).Enabled = False
            tlbTransfer.Buttons(3).Enabled = False
            
            'Resets Xbox Treeview
            tvXbox.Nodes.Clear
            tvXbox.Nodes.Add , , "XB", "Xbox Sound Tracks", 14
            tvXbox.Nodes("XB").Expanded = True
            
            'Reset Soundtrack Listview
            lvXbox.ListItems.Clear
            
        Case "Add"
            AddSoundTrack InputBox("Please Enter New SoundTrack Name.", "Virtual Xbox CD Ripper"), tvXbox
            UploadST
            
        Case "Remove"
        
            'Checks if a SoundTrack is selected
            If SoundTrackSelected = False Then
                
                'Displays Err Message
                MsgBox "Please Select a Soundtrack.", vbOKOnly + vbExclamation, "Virtual Xbox CD Ripper"
                Exit Sub
                
            End If
            
            DeleteSoundTrack Replace(tvXbox.SelectedItem.Key, "#", "")
            ReadSoundTracks tvXbox
            
        Case "Xbox"
            PopupMenu tlbXBOX
        
        Case "Options"
            
            'Shows Option Dialog
            frmOptions.Show
            
        Case "Search"
        
            'Presses Songs|Search
            mnuSongSearch_Click
            
       
        Case "About"
        
            'Shows About Dialog
            frmAbout.Show
            
    End Select
End Sub

Private Sub tlbPlayer_ButtonClick(ByVal Button As MSComctlLib.Button)
    'On Error Resume Next
    
    'Determines Weather PLAY/STOP was pressed
    Select Case Button.Key
        Case "Play"
            
            Select Case intSelectedLV
            
                'Play LVPC File (Local HDD)
                Case 0
                
                    'Checks if File Exists
                    If FileExists(CStr(lvPC.SelectedItem.TaG)) = False Then Exit Sub
        
                    'Sets Up Audio Drivers
                    Dim InitBass As Boolean
                    InitBass = BASS_Init(1, 44100, 0, Me.hWnd, 0)
    
                    'Frees Stream Channels
                    BASS_StreamFree chan
                    BASS_MusicFree chan
         
                    'Loads File and Plays but first checks format
                    If UCase(Right(lvPC.SelectedItem.TaG, Len(lvPC.SelectedItem.TaG) - InStr(1, lvPC.SelectedItem.TaG, "."))) <> "WMA" Then
                        
                        'Launches Regular Player
                        chan = BASS_StreamCreateFile(BASSFALSE, CStr(lvPC.SelectedItem.TaG), 0, 0, BASS_STREAM_AUTOFREE)
                        
                      Else
                          
                        'Launches WMA Player
                        chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(lvPC.SelectedItem.TaG), 0, 0, BASS_STREAM_AUTOFREE)
                        
                    End If
                    
                    'Plays Stream
                    BASS_StreamPlay chan, 0, 0

                    
                'Xbox Sound Track (Remote)
                Case 1
                    
                    'Checks if Old Preview Track Exists
                    If FileExists(strXAFile) = True Then
                    
                        'If Theres a File
                        If strXAFile <> "" Then
                            Kill strXAFile
                        End If
                    End If
                    
                    'Creates Random File Name
                    strXAFile = VXCRSettings.strTempFld & RandomFile
                    
                    'Sets FTP Operation
                    intDo = 1001
                  
                    'Change folder
                    frmMain.mFTP.SetFTPDirectory (frmMain.strDriveLetter & "tdata/fffe0000/music/" & Mid(lvXbox.SelectedItem.SubItems(2), 1, 4) & "/")
                   
                    Dim strFFile As String
                    strFFile = Right(lvXbox.SelectedItem.SubItems(2), Len(lvXbox.SelectedItem.SubItems(2)) - InStr(1, lvXbox.SelectedItem.SubItems(2), "/"))
                   
                    'Downloads ST.DB File from FTP Server (Xbox) SimpleFTPGetFile FTPDownloadFile
                    blna = frmMain.mFTP.FTPDownloadFile(strXAFile, strFFile)
                   
            End Select
            
        Case "Stop"
            
            'Checks if Old Preview Track Exists
            If FileExists(strXAFile) = True Then
                               
                'If Theres a File
                If strXAFile <> "" Then
                    Kill strXAFile
                End If
            End If
                    
            'Stops Playback
            BASS_ChannelStop chan
            BASS_StreamFree chan
            BASS_Free
            
    End Select
End Sub

Private Sub tlbTransfer_ButtonClick(ByVal Button As MSComctlLib.Button)
    
    'On Error GoTo ErrHD
    
    'Declares Memory Units
    Dim lngA As Long
    Dim lngB As Long
    Dim strA As String
    Dim strOutputfile As String 'Tells us Xbox filename to use
       
    'Selects Transfer Button
    Select Case Button.Key
    
        Case "Download"
                       
            For lngA = 1 To lvXbox.ListItems.Count
                
                'Checks if item is Checked
                If lvXbox.ListItems(lngA).Checked = True Then
                    
                    'Deletes Temparory File (LastTime)
                    If strXTrans <> "" Then
                        Kill strXTrans
                    End If
                
                    'Creates Random File Name
                    strXTrans = VXCRSettings.strTempFld & RandomFile
            
                    'Writes Orginal File Info
                    strXTNames = lvXbox.ListItems(lngA).text
            
                    'Sets FTP Operation
                    intDo = 1002
                                                
                    'Change folder
                    frmMain.mFTP.SetFTPDirectory (frmMain.strDriveLetter & "tdata/fffe0000/music/" & Mid(lvXbox.ListItems(lngA).SubItems(2), 1, 4))
                    
                    'Gets Real FileName
                    Dim strFFile As String
                    strFFile = Right(lvXbox.ListItems(lngA).SubItems(2), Len(lvXbox.ListItems(lngA).SubItems(2)) - InStr(1, lvXbox.ListItems(lngA).SubItems(2), "/"))
                    
                    'Downloads Music File from Xbox
                    blna = frmMain.mFTP.FTPDownloadFile(strXTrans, strFFile)
                End If
                
            Next lngA
            
        '------------------------------
        'Upload Section
        '------------------------------
        Case "Upload"
            
            'Checks if a SoundTrack is selected
            If SoundTrackSelected = False Then
                
                'Displays Err Message
                MsgBox "Please Select a Soundtrack.", vbOKOnly + vbExclamation, "Virtual Xbox CD Ripper"
                Exit Sub
            End If
            
            'Checks if User wants to Edit Title before upload
            If VXCRSettings.blnManuIDTag = True Then
                
                'Shows Edit Dialog
                frmEditTitle.Show
                
                Exit Sub
            End If
            
            'Converts/Uploads Selected Songs
            UploadSongs
        
        Case "Delete"
            MsgBox "This Feature doesnt work yet!"
    End Select
    
    Exit Sub
ErrHD:
    MsgBox "Please Select a SoundTrack, Might be possible bugs not sure"
End Sub

Private Sub tmrResize_Timer()
    If stbp.top <> (stbMain.top + 4) Then
        Form_Resize
    End If
End Sub

Private Sub tvXbox_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    
    'Checks for Right Click
    If Button = 2 Then
    
        'Shows the Popup Menu
        PopupMenu mnuSoundTrack
        
    End If
    
End Sub

Private Sub tvXbox_NodeClick(ByVal Node As MSComctlLib.Node)

    If Node.Key <> "XB" Then
        SoundTrackDetail CLng(Replace(Node.Key, "#", "")), Me.lvXbox
        
    End If
End Sub

Public Function SoundTrackSelected() As Boolean
    On Error GoTo ErrHnd
    
    SoundTrackSelected = True
    
    'Checks if tvXbox has an Item Selected
    If tvXbox.SelectedItem.Key = "XB" Then GoTo ErrHnd
    
    
    Exit Function
ErrHnd:
    SoundTrackSelected = False
End Function

Public Function UploadSongs()
    'On Error Resume Next
    
    'Disables UI Controls
    ftvPC.Enabled = False
    tlbPlayer.Buttons(1).Enabled = False
    tlbPlayer.Buttons(2).Enabled = False
    mnuSongSearch.Enabled = False
    tbMain.Buttons(7).Enabled = False
    
    Dim strA As String
    
    For lngA = 1 To lvPC.ListItems.Count
        DoEvents
                
        'Checks if Item is checked
        If lvPC.ListItems(lngA).Checked = True Then
                                    
            'Updates Status Bar
            stbMain.Panels(1).text = "Converting to WMA, Please Wait..."
            lvPC.ListItems(lngA).SubItems(1) = "Converting..."
                    
            'Changes Focus Area
            lvPC.ListItems(lngA).Selected = True
            lvPC.ListItems(lngA).EnsureVisible
            'lvPC.SetFocus
                    
            'Generates Temp Name
            strA = VXCRSettings.strTempFld & RandomFile
            'strA = App.path & "\temp\KIOTZYBLJWZZKUFCDDQP.VXCR"
            
            'Converts Stuff to WMA
            ConvertToWMA CStr(lvPC.ListItems(lngA).TaG), strA, VXCRSettings.lngWmaBitRate
                                        
            'Intilizes BASS_STREAM (For Grabbing TrackCount)
                    
            'Checks if File Exists
            If FileExists(CStr(lvPC.ListItems(lngA).TaG)) = False Then Exit Function
        
            'Sets Up Audio Drivers
            Dim InitBass As Boolean
            InitBass = BASS_Init(1, 44100, 0, Me.hWnd, 0)
    
            'Frees Stream Channels
            BASS_StreamFree chan
            BASS_MusicFree chan
         
            'Loads File and Plays but first checks format
            If UCase(Right(lvPC.ListItems(lngA).TaG, Len(lvPC.ListItems(lngA).TaG) - InStr(1, lvPC.ListItems(lngA).TaG, "."))) <> "WMA" Then
                        
                'Launches Regular Player
                chan = BASS_StreamCreateFile(BASSFALSE, CStr(lvPC.ListItems(lngA).TaG), 0, 0, BASS_STREAM_AUTOFREE)
                        
                Else
                          
                'Launches WMA Player
                chan = BASS_WMA_StreamCreateFile(BASSFALSE, CStr(lvPC.ListItems(lngA).TaG), 0, 0, BASS_STREAM_AUTOFREE)
                        
            End If
                       
            'Adds Song to ST.DB File
            'strOutputfile = AddSong(modMP3Tag.GetId3(CStr(lvPC.ListItems(lngA).TaG)), strA, BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan)), Replace(tvXbox.SelectedItem.Key, "#", ""))
            strOutputfile = AddSong(lvPC.ListItems(lngA).text, strA, BASS_ChannelBytes2Seconds(chan, BASS_StreamGetLength(chan)), Replace(tvXbox.SelectedItem.Key, "#", ""))
                    
            'Stops Playback
            BASS_ChannelStop chan
            BASS_StreamFree chan
            BASS_Free
            
            'Updates Status Bar
            stbMain.Panels(1).text = "Sending to Xbox, Please Wait..."
            lvPC.ListItems(lngA).SubItems(1) = "Transfering..."
                    
            'Change folder
            frmMain.mFTP.SetFTPDirectory (frmMain.strDriveLetter & "tdata/fffe0000/music/")
            frmMain.mFTP.CreateFTPDirectory (Left(strOutputfile, 4))
            frmMain.mFTP.SetFTPDirectory (frmMain.strDriveLetter & "tdata/fffe0000/music/" & Left(strOutputfile, 4) & "/")
                    
            'Sets FTP Operation
            intDo = 1003
                    
            'Uploads Data
            mFTP.FTPUploadFile strA, strOutputfile & ".wma"
                    
            'Deletes Temp File
            'Kill strA
                    
            'Unchecks Item
            lvPC.ListItems(lngA).Checked = False
                    
            'Updates Status
            lvPC.ListItems(lngA).SubItems(1) = "Complete"
                    
            'Refreshes Xbox Listview
            SoundTrackDetail CLng(Replace(tvXbox.SelectedItem.Key, "#", "")), Me.lvXbox
                    
        End If
                
    Next lngA
    
    'Disables UI Controls
    ftvPC.Enabled = True
    tlbPlayer.Buttons(1).Enabled = True
    tlbPlayer.Buttons(2).Enabled = True
    mnuSongSearch.Enabled = True
    tbMain.Buttons(7).Enabled = True
    
    'Uploads New ST.DB File to Xbox
    UploadST
    
End Function

Public Function UploadST() As Boolean
    
    'Saves ST.DB File
    TerminateST
            
    If frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & "tdata/fffe0000/music") Then
         
        'Downloads ST.DB File from FTP Server (Xbox)
        a = frmMain.mFTP.SimpleFTPPutFile(strSTDBLoc, "st.db")
        UploadST = True
        
      Else
        MsgBox "Error Uploading Database (Function: UploadSongs)"
        UploadST = False
    End If
End Function

Public Function DetectFTP()
    If frmMain.mFTP.SetFTPDirectory(frmMain.strDriveLetter & "") Then
        Debug.Print "/e/"
        strDriveLetter = "/e/"
       Else
        Debug.Print "/e:/"
        strDriveLetter = "/e:/"
    End If
End Function

