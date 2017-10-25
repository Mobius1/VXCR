VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.UserControl usrDir 
   Alignable       =   -1  'True
   ClientHeight    =   5295
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3060
   ScaleHeight     =   5295
   ScaleWidth      =   3060
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   3240
      Top             =   2280
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   10
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":0000
            Key             =   "unkown"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":039A
            Key             =   "fixed"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":0734
            Key             =   "ram"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":0ACE
            Key             =   "remove"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":0E68
            Key             =   "cd"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":1202
            Key             =   "folder"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":159C
            Key             =   "open"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":1936
            Key             =   "remote"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":1CD0
            Key             =   "MyComputer"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":206A
            Key             =   "Desktop"
         EndProperty
      EndProperty
   End
   Begin MSComctlLib.ImageList img1 
      Left            =   3240
      Top             =   1680
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   10
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":2404
            Key             =   "unkown"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":2858
            Key             =   "fixed"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":2CAC
            Key             =   "ram"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":5460
            Key             =   "remove"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":7C14
            Key             =   "cd"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":A3C8
            Key             =   "folder"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":CB7C
            Key             =   "open"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":F330
            Key             =   "remote"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":11AE4
            Key             =   "MyComputer"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "usrDir.ctx":1207E
            Key             =   "Desktop"
         EndProperty
      EndProperty
   End
   Begin VB.ListBox List1 
      Height          =   1425
      Left            =   3240
      Sorted          =   -1  'True
      TabIndex        =   0
      Top             =   120
      Visible         =   0   'False
      Width           =   1935
   End
   Begin MSComctlLib.TreeView DirTree 
      Height          =   5295
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   3045
      _ExtentX        =   5371
      _ExtentY        =   9340
      _Version        =   393217
      Indentation     =   2
      LabelEdit       =   1
      LineStyle       =   1
      Style           =   7
      ImageList       =   "ImageList1"
      Appearance      =   1
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
End
Attribute VB_Name = "usrDir"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
' ================================================================
' Project Name: Directoy Folder
' Author Name: Pawel Pastuszak
' Date: May 19 2000  <- Creastion on the Project
' Update Date: March 5, 2002
' Discription:
'   User Control for Directory Tree Listing as Windows Explorer.
'   This control works with windows 9x or any Windows NT based platform.
'   You can use this control in any program you wish but if you modife this code you
'   must send me a copy of the modifed code.
'
'   You many not sale this code as you own. You can only use it in your applications
'   The application that you create with my OCX File you must send me the EXE file of it
'   if you are going to be posting it on the internet or selling the application for profit.
'   You must send me a copy of the application.
'
'   You must follow those rules.
'
'   Thank you
'
' Author's E-Mail: pastuszak@rogers.com
' Copyright By: Pawel Pastuszak (c) 2002 & Twisted Production
' Home Page: http://twistedproductions.hypermart.net/
'=====================================================================

Private nNode As Node
Private Declare Function GetDriveType Lib "kernel32" Alias "GetDriveTypeA" (ByVal nDrive As String) As Long
Public Path As String

Public Event Click()
'##ED Occurs when the user presses and then releases a mouse button over a Toolbar control
Public Event DblClick()
Public Event MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
Public Event MouseMove(Button As Integer, Shift As Integer, x As Single, y As Single)
Public Event MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
Public Event KeyDown(KeyCode As Integer, Shift As Integer)
Public Event KeyPress(KeyAscii As Integer)
Public Event KeyUp(KeyCode As Integer, Shift As Integer)
Public Event NodeClick(ByVal Node As MSComctlLib.Node)
'This is going to the the current folders path
Private Declare Function SHGetSpecialFolderLocation Lib "shell32" (ByVal hwnd As Long, ByVal nFolder As Long, Pidl As Long) As Long
Private Declare Function SHGetPathFromIDList Lib "shell32" (Pidl As Long, ByVal FolderPath As String) As Long
    
    Const CSIDL_DESKTOP = 0
    Const CSIDL_PERSONAL = 5        'My Documents
    Const CSIDL_BITBUCKET = 10
    Const CSIDL_DESKTOPDIRECTORY = 16 'Destop Directory
    Const CSIDL_NETWORK = 18
    Const CSIDL_COMMON_STARTUP = 24
    Const CSIDL_COMMON_DESKTOPDIRECTORY = 25
    Const CSIDL_HISTORY = 34
    Const MAX_PATH = 260
    
    
Public MyDocuments As String    'Set the path for my documents folder
Public DesktopPath As String    'Set the Path for Desktop on Windows 9x or NT based
Public AutoExpend As Boolean    'Auto Expend for the list defualt is FALSE

'We are going to set some name for the defualt name
'of the drive if they are empty with no label
Private Const nFloppy As String = "3½ Floppy"
Private Const nLocalDrive As String = "Local Drive"
Private Const nCDRomDrive As String = "Compact Disk"


    
Private Function DirFolderPath(lFolder As Long) As String
    Dim lpStartupPath As String * MAX_PATH
    Dim Pidl As Long
    Dim hResult As Long
    
    hResult = SHGetSpecialFolderLocation(0, lFolder, Pidl)
    If hResult = 0 Then
        hResult = SHGetPathFromIDList(ByVal Pidl, lpStartupPath)


        If hResult = 1 Then
            lpStartupPath = Left(lpStartupPath, InStr(lpStartupPath, Chr(0)) - 1)
            DirFolderPath = lpStartupPath
        End If
    End If
End Function
Public Property Get FileName() As String
    FileName = Path 'Set the path as filename
End Property

Public Property Get Drive() As String
    Drive = Left(Path, 1) 'Get the drive
End Property
Public Property Get DriveName() As String
    Dim fsoDrive As Drive
    Set fs = New FileSystemObject
    Set fsoDrive = fs.GetDrive(Drive)
    If fsoDrive.DriveType = Fixed Then
        If fsoDrive.VolumeName <> "" Then
            DriveName = fsoDrive.VolumeName
        Else
            DriveName = "Hard Drive"
        End If
    Else
        DriveName = fsoDrive.VolumeName
    End If
    
End Property

Public Property Get DriveSpace() As String
    Dim x As Double
    
    'Send the drive in drvDrive to the function and
    'assign the result to x
    x = DiskSpaceInBytes(Drive)
    
    'If the function failed
    If x = -1 Then
        'Alert the user
        MsgBox "Function failed!", vbCritical, "Error"
        Exit Sub
    Else
        'Otherwise display the free space
        DriveSpace = Format(x, "###,###") & " bytes"
    End If
End Property

Private Sub DirTree_Click()
'MsgBox DirTree.SelectedItem.Key
End Sub

Private Sub DirTree_Expand(ByVal Node As MSComctlLib.Node)
Dim j As Integer
If AutoExpend = True Then
    For j = Node.Child.FirstSibling.Index To Node.Child.LastSibling.Index
         DirTree_NodeClick DirTree.Nodes(j)
    Next j

    DirTree_NodeClick Node
End If
'Node.Selected = True
End Sub

Private Sub DirTree_KeyDown(KeyCode As Integer, Shift As Integer)
RaiseEvent KeyDown(KeyCode, Shift)
End Sub

Private Sub DirTree_KeyPress(KeyAscii As Integer)
    RaiseEvent KeyPress(KeyAscii)
End Sub

Private Sub DirTree_KeyUp(KeyCode As Integer, Shift As Integer)
    RaiseEvent KeyUp(KeyCode, Shift)
End Sub

Private Sub DirTree_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
    If KeyCode = vbKeyF5 Then DirTree.Nodes.Clear: LoadTreeView
    RaiseEvent MouseDown(Button, Shift, x, y)
End Sub

Private Sub DirTree_MouseMove(Button As Integer, Shift As Integer, x As Single, y As Single)
    RaiseEvent MouseMove(Button, Shift, x, y)
End Sub

Private Sub DirTree_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
RaiseEvent MouseUp(Button, Shift, x, y)
End Sub

Private Sub UserControl_Initialize()
LoadTreeView
End Sub
Private Sub LoadTreeView()
Dim DriveNum As String
Dim DriveType As Long
Dim nVolume As String
DriveNum = 64
On Error Resume Next

'Get the My Documents Path
MyDocuments = Trim(DirFolderPath(CSIDL_PERSONAL))
'Add Desktop as the main roots.
Set nNode = DirTree.Nodes.Add(, , "Desktop", "Desktop", "Desktop")
'Add My Documents
Set nNode = DirTree.Nodes.Add("Desktop", tvwChild, "d" + MyDocuments, "My Documents", "folder")

If MyDocuments = "" Then MyDocuments = "C:\Documents\"
DisplayDir MyDocuments, "d" + MyDocuments

Set nNode = DirTree.Nodes.Add("Desktop", tvwChild, "mycomputer", "My Computer", "MyComputer")
Do
    DriveNum = DriveNum + 1
    DriveType = GetDriveType(Chr$(DriveNum) & ":\")
    If DriveNum > 90 Then Exit Do
    'Get the volume name
    nVolume = Dir(Chr$(DriveNum) & ":", vbVolume)
    Select Case DriveType
        Case 0:
                
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(Dir(Chr$(DriveNum) & ":", vbVolume), vbProperCase) & " (" & Chr$(DriveNum) & ":)", "unknown")
                DisplayDir Mid(DirTree.Nodes("root" & DriveNum).Text, Len(DirTree.Nodes("root" & DriveNum).Text) - 2, 2), "root" & DriveNum
        Case 2:
                'Floppy Drive
                If nVolume = "" Then nVolume = nFloppy
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(nVolume, vbProperCase) + " (" & Chr$(DriveNum) & ":)", "remove")
        Case 3:
                'Local Drive
                If nVolume = "" Then nVolume = nLocalDrive
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(nVolume, vbProperCase) & " (" & Chr$(DriveNum) & ":)", "fixed")
                DisplayDir Mid(DirTree.Nodes("root" & DriveNum).Text, Len(DirTree.Nodes("root" & DriveNum).Text) - 2, 2), "root" & DriveNum
        Case 4:
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(Dir(Chr$(DriveNum) & ":", vbVolume), vbProperCase) & " (" & Chr$(DriveNum) & ":)", "remote")
                DisplayDir Mid(DirTree.Nodes("root" & DriveNum).Text, Len(DirTree.Nodes("root" & DriveNum).Text) - 2, 2), "root" & DriveNum
        Case 5:
                'Compact Disk
                If nVolume = "" Then nVolume = nCDRomDrive
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(nVolume, vbProperCase) & " (" & Chr$(DriveNum) & ":)", "cd")
                DisplayDir Mid(DirTree.Nodes("root" & DriveNum).Text, Len(DirTree.Nodes("root" & DriveNum).Text) - 2, 2), "root" & DriveNum
                
        Case 6:
                Set nNode = DirTree.Nodes.Add("mycomputer", tvwChild, "root" & DriveNum, StrConv(Dir(Chr$(DriveNum) & ":", vbVolume), vbProperCase) & " (" & Chr$(DriveNum) & ":)", "ram")
                DisplayDir Mid(DirTree.Nodes("root" & DriveNum).Text, Len(DirTree.Nodes("root" & DriveNum).Text) - 2, 2), "root" & DriveNum
    End Select
Loop
nNode.EnsureVisible

'Get the Desktop Directory
DesktopPath = Trim(DirFolderPath(CSIDL_DESKTOPDIRECTORY))
DisplayDir DesktopPath, "Desktop"
nNode.EnsureVisible

'nNode.EnsureVisible
End Sub
Sub DisplayDir(Pth, Parent)
Dim j As Integer
    On Error Resume Next
    Pth = Pth & "\"
    tmp = Dir(Pth, vbDirectory)
    Do Until tmp = ""
        If tmp <> "." And tmp <> ".." Then
            If GetAttr(Pth & tmp) And vbDirectory Then
                'I use ListBox with property Sorted=True to
                'alphabetize directories. Easy eh? ;-)
                List1.AddItem StrConv(tmp, vbProperCase)
                'StrConv function convert for example
                '"WINDOWS" to "Windows"
            End If
        End If
        tmp = Dir
    Loop
    'Add sorted directory names to TreeView
    For j = 1 To List1.ListCount
        Set nNode = DirTree.Nodes.Add(Parent, tvwChild, Pth + List1.List(j - 1), List1.List(j - 1), "folder")
        nNode.ExpandedImage = "open"
    Next j
    List1.Clear
End Sub
Private Sub DirTree_NodeClick(ByVal Node As MSComctlLib.Node)
    If InStr(1, Node.FullPath, ":") >= 1 Then
        sLetter$ = (Mid(Node.FullPath, InStr(1, Node.FullPath, ":") - 1, 2) & Mid(Node.FullPath, InStr(1, Node.FullPath, ":") + 2))
    End If
    If sLetter$ <> "" And Len(sLetter$) = 2 Then
        If CheckIfCDROMDrive(sLetter) = True Then
            Node.Text = StrConv(HDName(sLetter$), vbProperCase) + " (" + sLetter + ")"
        End If
    End If
    'Dim Path As String
    If Left(Node.Key, 4) = "root" Then
        On Error Resume Next
        If Node.Children > 0 Then GoTo Skok
        DisplayDir Mid(Node.Text, Len(Node.Text) - 2, 2), Node.Key
    End If

    
    If Node.Text = "My Computer" Then
        Path = "My Computer"
    ElseIf Node.Text = "Desktop" Then
        Path = "C:\Windows\Desktop"
    ElseIf Node.Text = "My Documents" Then
        Path = Node.Key
    ElseIf Left(Node.Key, 2) = "dC" Then
        Path = Right(Node.Key, Len(Node.Key) - 1)
    ElseIf Left(Node.FullPath, Len("My Documents\")) = "My Documents\" Then
        Path = MyDocuments + Right(Node.FullPath, (Len(Node.FullPath) - Len("My Computer\")))
    
    'ElseIf Left(Node.FullPath, Len("Desktop\")) = "Desktop\" And InStr(1, Node.FullPath, "(") = 0 Then
    '    Path = "C:\Windows\" + Node.FullPath
    Else
    
        Path = Node.Key
        'Mid(Node.FullPath, InStr(1, Node.FullPath, ":") - 1, 2) & Mid(Node.FullPath, InStr(1, Node.FullPath, ":") + 2)
    End If
    If Node.Children > 0 Then GoTo Skok
    DisplayDir Path, Node.Index
    RaiseEvent NodeClick(Node)
Skok:
    If Node.Text <> "My Computer" Then
        If Left(Node.FullPath, Len("My Computer\")) = "My Computer\" And InStr(1, Node.FullPath, "(") = 0 Then
            Path = Node.Key '+ Right(Node.FullPath, (Len(Node.FullPath) - Len("My Computer\")))
        
        ElseIf Node.Text = "My Documents" Then
            Path = Node.Key
        ElseIf Node.Text = "Desktop" Then
            Path = "C:\Windows\Desktop"
        ElseIf Left(Node.Key, 2) = "dC" Then
            Path = Right(Node.Key, Len(Node.Key) - 1)
        ElseIf Left(Node.FullPath, Len("My Documents\")) = "My Documents\" Then
            Path = MyDocuments + Right(Node.FullPath, (Len(Node.FullPath) - Len("My Computer\")))
        ElseIf Left(Node.FullPath, Len("Desktop\")) = "Desktop\" And InStr(1, Node.FullPath, "(") = 0 Then
            Path = "C:\Windows\" + Node.FullPath
        Else
            Path = Mid(Node.FullPath, InStr(1, Node.FullPath, ":") - 1, 2) & Mid(Node.FullPath, InStr(1, Node.FullPath, ":") + 2)
        End If
        If Right(Path, 1) <> "\" Then Path = Path & "\"
    End If
    'FileName = Path
    'Text1 = Path
    RaiseEvent Click
End Sub


Private Sub UserControl_Resize()
DirTree.Width = UserControl.Width
DirTree.Height = UserControl.Height
End Sub

