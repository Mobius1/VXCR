VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmSearch 
   Caption         =   "Search"
   ClientHeight    =   4380
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8235
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "frmSearch.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   4380
   ScaleWidth      =   8235
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdAdd 
      Caption         =   "Add"
      Enabled         =   0   'False
      Height          =   405
      Left            =   6480
      TabIndex        =   9
      Top             =   3600
      Width           =   1575
   End
   Begin VB.CommandButton cmdSeach 
      Caption         =   "Search"
      Height          =   405
      Left            =   1440
      TabIndex        =   4
      Top             =   3600
      Width           =   1335
   End
   Begin MSComctlLib.ImageList imglIcons 
      Left            =   7440
      Top             =   2760
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   1
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSearch.frx":472A
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   405
      Left            =   120
      TabIndex        =   8
      Top             =   3600
      Width           =   1335
   End
   Begin VB.TextBox txtPath 
      Height          =   285
      Left            =   1080
      TabIndex        =   3
      Text            =   "C:\"
      Top             =   120
      Width           =   6615
   End
   Begin VB.CommandButton cmdPath 
      Caption         =   "..."
      Height          =   285
      Left            =   7800
      TabIndex        =   2
      Top             =   120
      Width           =   255
   End
   Begin VB.TextBox txtSearch 
      Height          =   285
      Left            =   1080
      TabIndex        =   1
      Text            =   ".mp3"
      Top             =   480
      Width           =   6975
   End
   Begin MSComctlLib.StatusBar S1 
      Align           =   2  'Align Bottom
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   4125
      Width           =   8235
      _ExtentX        =   14526
      _ExtentY        =   450
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   4
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   3466
            Text            =   "Found : 0"
            TextSave        =   "Found : 0"
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   3466
            Text            =   "Total Size : 0"
            TextSave        =   "Total Size : 0"
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   3466
            Text            =   "Folders Searched : 0"
            TextSave        =   "Folders Searched : 0"
         EndProperty
         BeginProperty Panel4 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            AutoSize        =   1
            Object.Width           =   3466
            Text            =   "Files Searched : 0"
            TextSave        =   "Files Searched : 0"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ListView LVF 
      Height          =   2655
      Left            =   120
      TabIndex        =   5
      Top             =   840
      Width           =   7935
      _ExtentX        =   13996
      _ExtentY        =   4683
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      Checkboxes      =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      SmallIcons      =   "imglIcons"
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   2
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "FileName"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Size"
         Object.Width           =   2540
      EndProperty
   End
   Begin VB.Label lblInfo 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Search For:"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   7
      Top             =   480
      Width           =   855
   End
   Begin VB.Label lblInfo 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Caption         =   "Search In:"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   6
      Top             =   120
      Width           =   855
   End
End
Attribute VB_Name = "frmSearch"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim Folders As Long
Dim Files As Long
Dim Found As Long
Dim TSize As Double
Dim blnCancel As Boolean

Private Sub cmdAdd_Click()
    
    'Declares Memory Units
    Dim lngA As Long
    Dim strFilePath As String
    
    'Clears PC listview
    frmMain.lvPC.ListItems.Clear
    
    'Loops Through All Listview Items
    For lngA = 1 To LVF.ListItems.Count
        DoEvents
        
        'Updates File Path Varible
        strFilePath = LVF.ListItems(lngA).ToolTipText & LVF.ListItems(lngA).text
        
        'Checks if LV item is checked
        If LVF.ListItems(lngA).Checked = True Then
            
            'Adds Files to listview GrabMP3Title
            If VXCRSettings.blnLvpcIDTag = True Then
                    
                'Checks if ID Tag is MP3 Stream CheckVaildID
                If CheckVaildID(GetId3(strFilePath)) = True Then
                    frmMain.lvPC.ListItems.Add , , GetId3(strFilePath), , 9
                   Else
                    frmMain.lvPC.ListItems.Add , , LVF.ListItems(lngA).text, , 9
                End If
                    
               Else
                frmMain.lvPC.ListItems.Add , , LVF.ListItems(lngA).text, , 9
            End If
                                              
            'Gets File Size and Converts to KB etc
            frmMain.lvPC.ListItems(frmMain.lvPC.ListItems.Count).SubItems(2) = DoConv(FileLen(strFilePath))
            frmMain.lvPC.ListItems(frmMain.lvPC.ListItems.Count).TaG = strFilePath
           
        End If
    Next
    
    Unload Me
End Sub

Private Sub cmdCancel_Click()
    
    'Cancels Operations
    blnCancel = True
    
    cmdCancel.Enabled = False
    cmdSeach.Enabled = True
End Sub

Private Sub cmdPath_Click()
    
    'Declares Memory Units
    Dim strFolder As String
    
    'Selects Folder & Returns Item
    strFolder = SelectFolder(Me.hWnd)
    txtPath.text = strFolder
    
End Sub

Private Sub cmdSeach_Click()
        
    'Clears listview
    LVF.ListItems.Clear
    
    'Enables Stop Button
    cmdAdd.Enabled = True
    cmdCancel.Enabled = True
    cmdSeach.Enabled = False
    
    'Sets Default Varible Values
    Folders = 0
    Files = 0
    Found = 0
    TSize = 0
    
    'Sets Canceled to False
    blnCancel = False
    
    'Scans for Drives to Scan
    Dim sV() As String
    sV = Split(txtPath, ",")
    
    Dim i As Long
    For i = 0 To UBound(sV)
        
        'Checks if Canceld
        If blnCancel = True Then
            blnCancel = False
            
            Exit For
        End If
        
        DirSize sV(i)
    Next
End Sub

Sub DirSize(ByVal path As String)
    'On Error Resume Next
    
    'Declares Memory Units
    Dim MyName  As String
    Dim MyDirNr As Long
    Dim MyDir() As String
    Dim a As Long
    Dim chklen() As String
    
    Folders = Folders + 1
    path = IIf(Right$(path, 1) = "\", path, path + "\")
    MyName = Dir$(path + "*.*", vbDirectory + vbArchive + vbReadOnly)
    chklen = Split(path, "\")
    
    DoEvents
    
    Do While (MyName <> "")
        DoEvents
        
        'Checks if Canceld
        If blnCancel = True Then
                       
            Exit Do
        End If
        
        If MyName <> "." And MyName <> ".." Then
            If (GetAttr(path & MyName) And vbDirectory) <> vbDirectory Then
                Dim sizeX As Long
                sizeX = FileLen(path & MyName)
            
                If sizeX < 1 Then GoTo ToSmall
                Files = Files + 1
             
                If InStr(LCase(MyName), LCase(txtSearch.text)) Then
        
                    Found = Found + 1
                    TSize = TSize + sizeX
                    
                    LVF.ListItems.Add , , MyName, , 1
                    LVF.ListItems.Item(LVF.ListItems.Count).SubItems(1) = DoConv(CStr(sizeX))
                    LVF.ListItems.Item(LVF.ListItems.Count).ToolTipText = path
                End If
ToSmall:

            Else
                ReDim Preserve MyDir(MyDirNr + 1)
                MyDirNr = MyDirNr + 1
                MyDir(MyDirNr) = MyName
            End If
        End If
        
        MyName = CStr(Dir)
        
    Loop
    
    For a = 1 To MyDirNr
        UpdateStatus
        DirSize path + MyDir(a) + "\"
    Next
    
 End Sub

Sub UpdateStatus()

    'Updates Status Bar
    S1.Panels.Item(1).text = "Found : " & Found
    S1.Panels.Item(2).text = "Total Size : " & DoConv(CStr(TSize))
    S1.Panels.Item(3).text = "Folders Searched : " & Folders
    S1.Panels.Item(4).text = "Files Searched : " & Files
End Sub

Private Sub Form_Load()
    
    'Resizes LVF tabs
    ReSizeLV Me.LVF, 1
    LVF.ColumnHeaders(1).Width = LVF.ColumnHeaders(1).Width - 50
End Sub
