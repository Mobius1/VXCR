Attribute VB_Name = "modListviewProgessbar"
Option Explicit
' The column index to draw the progressbar in
Private Const ProgressBarColumn = 2
Private Const ProgressBarColor = &HFF0000
' Windows API Types
Private Type RECT
        Left As Long
        Top As Long
        Right As Long
        Bottom As Long
End Type
' Windows API Functions
Private Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Long, ByVal hWnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long
Private Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Long, ByVal x As Long, ByVal y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal hSrcDC As Long, ByVal xSrc As Long, ByVal ySrc As Long, ByVal dwRop As Long) As Long
Private Declare Function GetDC Lib "user32" (ByVal hWnd As Long) As Long
Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Any) As Long
' Windows API Constants
Private Const WM_PAINT = &HF
Private Const GWL_WNDPROC = (-4)
Private Const SRCCOPY = &HCC0020
Private Const NOTSRCCOPY = &H330008
Private Const LVM_FIRST As Long = &H1000
Private Const LVM_GETITEMRECT = (LVM_FIRST + 14)
Private Const LVIR_BOUNDS = 0
' Private Variables
Private OldListViewProc As Long ' Old WndProc function for default function calling
Private m_Progress() As Integer ' Array of know progress values
Private lvListView As ListView  ' Reference to control

Public Sub InitPBinLV(Control As ListView)
    ' Set the global reference so the user doesn't have to send it anymore
    Set lvListView = Control
    ' Set our own custom WndProc function and save the address of the old one
    OldListViewProc = SetWindowLong(lvListView.hWnd, GWL_WNDPROC, AddressOf WindowProc)
End Sub

Private Sub UpdateProgress(pb As Control, Percent As Integer, Selected As Boolean)
    Dim intPercentWidth As Integer
    
    ' Set all the needed properties
    pb.AutoRedraw = True
    pb.DrawMode = vbCopyPen
    ' Size the control to the size of the columnheader used for the progressbar
    pb.Height = lvListView.ListItems(1).Height - 2
    pb.Width = pb.Parent.lvPC.ColumnHeaders(ProgressBarColumn).Width - 9
    ' Clear the picture
    pb.Cls
    ' Determine the width of the bar in pixels based of the percentage
    intPercentWidth = (Percent / 100) * pb.Width
    ' Draw main bar
    pb.Line (0, 0)-(intPercentWidth, pb.Height - 1), ProgressBarColor, BF
    If Selected = True Then
        pb.Line (intPercentWidth, 0)-(pb.Width - 1, pb.Height - 1), vbHighlight, BF
    End If
    ' Draw border
    pb.Line (0, 0)-(pb.Width - 1, pb.Height - 1), , B
    ' Update picture
    pb.Refresh
End Sub

Public Sub SetProgress(Index As Integer, ByVal Progress As Integer)
    ' Resize progress array to reflect the nuber of items in the listview
    ReDim Preserve m_Progress(lvListView.ListItems.Count)
    ' Check for a valid progress
    If Progress >= 100 Then
        m_Progress(Index) = 100
    ElseIf Progress <= 0 Then
        m_Progress(Index) = 0
    Else
        m_Progress(Index) = Progress
    End If
    ' Draw the changes
    DrawProgress Index, m_Progress(Index)
End Sub

Public Function GetProgress(Index As Integer) As Long
    ReDim Preserve m_Progress(lvListView.ListItems.Count)
    GetProgress = m_Progress(Index)
End Function

Private Sub DrawProgress(Index As Integer, ByVal Progress As Integer)
    Dim intI As Long
    Dim tmpRect As RECT
    Dim lngOffset As Long
    
    If lvListView.ColumnHeaders(ProgressBarColumn).Width > 15 Then
        ' Get item rect
        tmpRect.Left = LVIR_BOUNDS
        SendMessage lvListView.hWnd, LVM_GETITEMRECT, Index - 1, tmpRect
        ' Update the temparary picture
        If lvListView.SelectedItem.Index = Index Then
            UpdateProgress lvListView.Parent.picLVPrg, m_Progress(Index), True
        Else
            UpdateProgress lvListView.Parent.picLVPrg, m_Progress(Index), False
        End If
        ' Find the left side offset for column 'ProgressSubitem'
        For intI = 1 To ProgressBarColumn - 1
            lngOffset = lngOffset + lvListView.ColumnHeaders(intI).Width
        Next
        lngOffset = lngOffset + 4
        ' BitBlt the picture on the listview
        BitBlt GetDC(lvListView.hWnd), lngOffset, tmpRect.Top + 1, lvListView.ColumnHeaders(ProgressBarColumn).Width + 1, tmpRect.Bottom - tmpRect.Top, lvListView.Parent.picLVPrg.hDC, 0, 0, SRCCOPY
    End If
End Sub

Public Sub Redraw()
    On Error Resume Next
    Dim intI As Integer
    
    ' Resize progress array to reflect the nuber of items in the listview
    ReDim Preserve m_Progress(lvListView.ListItems.Count)
    For intI = lvListView.GetFirstVisible.Index To lvListView.GetFirstVisible.Index + (lvListView.Height / lvListView.ListItems(1).Height)
        SetProgress intI, m_Progress(intI)
    Next
End Sub

Private Function WindowProc(ByVal hWnd As Long, ByVal uMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Select Case uMsg
        ' Paint message received
        Case WM_PAINT
            ' Do the normal painting function for the listview
            WindowProc = CallWindowProc(OldListViewProc, hWnd, uMsg, wParam, lParam)
            ' Now do the custom painting function over top of the normal one
            Redraw
        Case Else
            ' We only want to handle the paint message to just do the default processing
            WindowProc = CallWindowProc(OldListViewProc, hWnd, uMsg, wParam, lParam)
    End Select
End Function

