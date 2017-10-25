Attribute VB_Name = "modUI"
Declare Function SHGetPathFromIDList Lib "Shell32.dll" Alias "SHGetPathFromIDListA" (ByVal pidl As Long, ByVal pszPath As String) As Long
Private Const BIF_RETURNONLYFSDIRS = 1
Private Const BIF_DONTGOBELOWDOMAIN = 2
Private Const MAX_PATH = 260

Private Declare Function SHBrowseForFolder Lib "shell32" (lpbi As BrowseInfo) As Long
Private Declare Function lstrcat Lib "kernel32" Alias "lstrcatA" (ByVal lpString1 As String, ByVal lpString2 As String) As Long

Private Type BrowseInfo
    hWndOwner      As Long
    pIDLRoot       As Long
    pszDisplayName As Long
    lpszTitle      As Long
    ulFlags        As Long
    lpfnCallback   As Long
    lParam         As Long
    iImage         As Long
End Type

'Displays the Treeview w/ Directories in Computer
Public Function SelectFolder(coosh As Long)
    
    'Declares Variable Objects
    Dim lpIDList As Long
    Dim sBuffer As String
    Dim szTitle As String
    Dim tBrowseInfo As BrowseInfo
    
    'Updates Caption Bar
    szTitle = "Select Folder"
    
    'Sets Properties
    With tBrowseInfo
        .hWndOwner = coosh
        .lpszTitle = lstrcat(szTitle, "")
        .ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN
    End With

    'Shows Folder w/ Applied Settings
    lpIDList = SHBrowseForFolder(tBrowseInfo)

    'Gets Returned Data
    If (lpIDList) Then
        sBuffer = Space(MAX_PATH)
        SHGetPathFromIDList lpIDList, sBuffer
        sBuffer = Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
        SelectFolder = sBuffer
    End If
         
End Function

'Changes LVPC So it Compiles with CD Ripper
Public Function ListviewPCCDRipper(lvItem As ListView)
    
    'Hides the DATE Colume
    'lvitem.ColumnHeaders(2).Width = 0
    
    'Resizes Listitem
    ReSizeLV lvItem, 1
      
End Function

'Changes LVPC So it Compiles with FileViewer
Public Function ListviewPCFileView(lvItem As ListView)
    
    'Shows the DATE Colume
    ''lvitem.ColumnHeaders(2).Width = 1440
    
    'Resizes Listitem
    ReSizeLV lvItem, 1
    
End Function

'Resizes A Listview Tab
Public Function ReSizeLV(ByVal L As MSComctlLib.ListView, Index As Integer)
    On Error Resume Next
    
    'Declares Memory Values
    Dim i As Integer
    Dim Hei As Long
    Dim Ad As Long
    
    'Loops Through Each Header
    For i = 1 To L.ColumnHeaders.Count
        Hei = Hei + L.ColumnHeaders.Item(i).Width
    Next
                
    Ad = L.Width - Hei
    
    'Fixes Sizes
    If L.ColumnHeaders.Item(Index).Width + Ad - 8 > 96 Then
        L.ColumnHeaders.Item(Index).Width = L.ColumnHeaders.Item(Index).Width + Ad - 8
    Else
        L.ColumnHeaders.Item(Index).Width = 96
    End If
    
End Function

Public Function ResizeStatusBar(s As StatusBar, Index As Integer)
    On Error Resume Next
    
    'Declares Memory Units
    Dim i As Integer
    Dim Hei As Long
    Dim Ad As Long
    
    'Gets Width of All Tabs
    For i = 1 To s.Panels.Count
        Hei = Hei + s.Panels(i).Width
    Next
    
    Ad = s.Width - Hei
    
    'Fixes Space
    If s.Panels(Index).Width + Ad - 13 > 96 Then
        s.Panels(Index).Width = s.Panels(Index).Width + Ad - 13
    Else
        s.Panels(Index).Width = 96
    End If
End Function




