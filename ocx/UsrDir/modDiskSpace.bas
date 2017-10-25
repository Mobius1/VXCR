Attribute VB_Name = "modDiskSpace"
Option Explicit
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

Declare Function GetDiskFreeSpace Lib "kernel32" Alias "GetDiskFreeSpaceA" (ByVal lpRootPathName As String, lpSectorsPerCluster As Long, lpBytesPerSector As Long, lpNumberOfFreeClusters As Long, lpTtoalNumberOfClusters As Long) As Long

Public Function DiskSpaceInBytes(drvPath As String) As Double
    Dim Drive As String
    Dim BytesPerSector As Long
    Dim SectorsPerCluster As Long
    Dim NumberOfFreeClusters As Long
    Dim TotalNumberOfClusters As Long
        
    'Make sure that our drive is in drive format
    Drive = Left(drvPath, 1) & ":\"
    
    'Only try to work out the free space if Drive is a real drive
    If GetDiskFreeSpace(Drive, BytesPerSector, SectorsPerCluster, NumberOfFreeClusters, TotalNumberOfClusters) <> 0 Then
        'Work out the free space
        DiskSpaceInBytes = (BytesPerSector * SectorsPerCluster * NumberOfFreeClusters)
    Else
        DiskSpaceInBytes = -1
    End If
End Function
Function HDName(sDrive As String) As String
Dim fso As New FileSystemObject
Dim fsoDrives As Drives
Dim fsoDrive As Drive

Dim sDriveSpec As String
Dim sSelDrive As String '

Set fsoDrive = fso.GetDrive(sDrive)

With fsoDrive
   If .IsReady = True Then
         HDName = .VolumeName
    End If
End With

Set fsoDrive = Nothing

End Function
Function CheckIfCDROMDrive(Letter As String) As Boolean
Dim fso As New FileSystemObject
Dim fsoDrives As Drives
Dim fsoDrive As Drive

Dim sDriveSpec As String
Dim sSelDrive As String '

Set fsoDrive = fso.GetDrive(Letter)

With fsoDrive
   If .IsReady = True Then
      If .DriveType = CDRom Then CheckIfCDROMDrive = True Else: CheckIfCDROMDrive = False
   Else
      CheckIfCDROMDrive = False
   End If
End With '

Set fsoDrive = Nothing

End Function
