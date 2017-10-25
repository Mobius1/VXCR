Option Strict Off
Option Explicit On
Friend Class cFTP
	
	' ------------------------------------------------------------------------------------------------------------------------------
	' This class is based on the SimpleFTP VB example by Microsoft.
	' It was extended by Michael Glaser to be class based and support buffer
	' based uploads and downloads with a progress event.
	'
	' If you found this code useful and would like to support the author, please
	' visit the eD.I.Y. Software website at http://www.ediy.co.nz to see if the
	' products we have available would be useful to you or your customers.
	'
	' Please credit me if you use this code in your applications.
	'
	' If you have any questions or possible improvements to this code, email me: mike@ediy.co.nz
	'
	' For help on any of the class API functions, an excellent reference is available here:
	' http://msdn.microsoft.com/library/default.asp?url=/workshop/networking/wininet/reference/win32_ref_entry.asp
	' ------------------------------------------------------------------------------------------------------------------------------
	
	
	Private Const MAX_PATH As Short = 260
	Private Const INTERNET_FLAG_RELOAD As Integer = &H80000000
	Private Const NO_ERROR As Short = 0
	Private Const FILE_ATTRIBUTE_READONLY As Short = &H1s
	Private Const FILE_ATTRIBUTE_HIDDEN As Short = &H2s
	Private Const FILE_ATTRIBUTE_SYSTEM As Short = &H4s
	Private Const FILE_ATTRIBUTE_DIRECTORY As Short = &H10s
	Private Const FILE_ATTRIBUTE_ARCHIVE As Short = &H20s
	Private Const FILE_ATTRIBUTE_NORMAL As Short = &H80s
	Private Const FILE_ATTRIBUTE_TEMPORARY As Short = &H100s
	Private Const FILE_ATTRIBUTE_COMPRESSED As Short = &H800s
	Private Const FILE_ATTRIBUTE_OFFLINE As Short = &H1000s
	Private Const INTERNET_FLAG_PASSIVE As Integer = &H8000000
	Private Const FORMAT_MESSAGE_FROM_HMODULE As Short = &H800s
	Private Const GENERIC_READ As Integer = &H80000000
	Private Const GENERIC_WRITE As Integer = &H40000000
	
	Private Const ERROR_NO_MORE_FILES As Short = 18
	Private Const INTERNET_AUTODIAL_FORCE_ONLINE As Short = 1
	Private Const INTERNET_OPEN_TYPE_PRECONFIG As Short = 0
	Private Const INTERNET_INVALID_PORT_NUMBER As Short = 0
	Private Const INTERNET_SERVICE_FTP As Short = 1
	Private Const FTP_TRANSFER_TYPE_BINARY As Short = &H2s
	Private Const FTP_TRANSFER_TYPE_ASCII As Short = &H1s
	
	Private Const rDayZeroBias As Double = 109205# ' Abs(CDbl(#01-01-1601#))
	Private Const rMillisecondPerDay As Double = 10000000# * 60# * 60# * 24# / 10000#
	
	Private Const BUFFERSIZE As Short = 4096
	'Public BUFFERSIZE As Integer
	
	Private Structure WIN32_FIND_DATA
		Dim dwFileAttributes As Integer
		Dim ftCreationTime As Decimal
		Dim ftLastAccessTime As Decimal
		Dim ftLastWriteTime As Decimal
		Dim nFileSizeHigh As Integer
		Dim nFileSizeLow As Integer
		Dim dwReserved0 As Integer
		Dim dwReserved1 As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public cFileName() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(14),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=14)> Public cAlternate() As Char
	End Structure
	
	' -- private functions
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Function FileTimeToLocalFileTime Lib "kernel32" (ByRef lpFileTime As Any, ByRef lpLocalFileTime As Any) As Integer
	Private Declare Function FormatMessage Lib "kernel32"  Alias "FormatMessageA"(ByVal dwFlags As Integer, ByVal lpSource As Integer, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByVal lpBuffer As String, ByVal nSize As Integer, ByRef Arguments As Integer) As Integer
	Private Declare Function FTPGetFile Lib "wininet.dll"  Alias "FtpGetFileA"(ByVal hFtpSession As Integer, ByVal lpszRemoteFile As String, ByVal lpszNewFile As String, ByVal fFailIfExists As Boolean, ByVal dwFlagsAndAttributes As Integer, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
	Private Declare Function FtpRenameFile Lib "wininet.dll"  Alias "FtpRenameFileA"(ByVal hFtpSession As Integer, ByVal lpszOldName As String, ByVal lpszNewName As String) As Boolean
	Private Declare Function FtpCreateDirectory Lib "wininet.dll"  Alias "FtpCreateDirectoryA"(ByVal hFtpSession As Integer, ByVal lpszName As String) As Boolean
	Private Declare Function FtpRemoveDirectory Lib "wininet.dll"  Alias "FtpRemoveDirectoryA"(ByVal hFtpSession As Integer, ByVal lpszName As String) As Boolean
	
	Private Declare Function FtpDeleteFile Lib "wininet.dll"  Alias "FtpDeleteFileA"(ByVal hFtpSession As Integer, ByVal lpszFileName As String) As Boolean
	Private Declare Function FtpOpenFile Lib "wininet.dll"  Alias "FtpOpenFileA"(ByVal hFtpSession As Integer, ByVal sBuff As String, ByVal Access As Integer, ByVal flags As Integer, ByVal Context As Integer) As Integer
	Private Declare Function FTPPutFile Lib "wininet.dll"  Alias "FtpPutFileA"(ByVal hFtpSession As Integer, ByVal lpszLocalFile As String, ByVal lpszRemoteFile As String, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
	Private Declare Function FtpSetCurrentDirectory Lib "wininet.dll"  Alias "FtpSetCurrentDirectoryA"(ByVal hFtpSession As Integer, ByVal lpszDirectory As String) As Boolean
	Private Declare Function FtpGetCurrentDirectory Lib "wininet.dll"  Alias "FtpGetCurrentDirectoryA"(ByVal hFtpSession As Integer, ByVal lpszCurrentDirectory As String, ByRef lpdwCurrentDirectory As Integer) As Boolean
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function FtpFindFirstFile Lib "wininet.dll"  Alias "FtpFindFirstFileA"(ByVal hFtpSession As Integer, ByVal lpszSearchFile As String, ByRef lpFindFileData As WIN32_FIND_DATA, ByVal dwFlags As Integer, ByVal dwContent As Integer) As Integer
	
	Private Declare Function GetModuleHandle Lib "kernel32"  Alias "GetModuleHandleA"(ByVal lpLibFileName As String) As Integer
	
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function InternetFindNextFile Lib "wininet.dll"  Alias "InternetFindNextFileA"(ByVal hFind As Integer, ByRef lpvFindData As WIN32_FIND_DATA) As Integer
	Private Declare Function InternetWriteFile Lib "wininet.dll" (ByVal hFile As Integer, ByRef sBuffer As Byte, ByVal lNumBytesToWrite As Integer, ByRef dwNumberOfBytesWritten As Integer) As Short
	Private Declare Function InternetReadFile Lib "wininet.dll" (ByVal hFile As Integer, ByRef sBuffer As Byte, ByVal lNumBytesToRead As Integer, ByRef dwNumberOfBytesRead As Integer) As Short
	Private Declare Function InternetCloseHandle Lib "wininet.dll" (ByVal hInet As Integer) As Integer
	Private Declare Function InternetOpen Lib "wininet.dll"  Alias "InternetOpenA"(ByVal sAgent As String, ByVal lAccessType As Integer, ByVal sProxyName As String, ByVal sProxyBypass As String, ByVal lFlags As Integer) As Integer
	Private Declare Function InternetConnect Lib "wininet.dll"  Alias "InternetConnectA"(ByVal hInternetSession As Integer, ByVal sServerName As String, ByVal nServerPort As Short, ByVal sUsername As String, ByVal sPassword As String, ByVal lService As Integer, ByVal lFlags As Integer, ByVal lContext As Integer) As Integer
	Private Declare Function InternetGetLastResponseInfo Lib "wininet.dll"  Alias "InternetGetLastResponseInfoA"(ByRef lpdwError As Integer, ByVal lpszErrorBuffer As String, ByRef lpdwErrorBufferLength As Integer) As Boolean
	Private Declare Function InternetAutodial Lib "wininet.dll" (ByVal dwFlags As Integer, ByVal dwReserved As Integer) As Integer
	
	
	
	' -- Private Variables
	
	Private hOpen As Integer
	Private hConnection As Integer
	Private hFile As Integer
	Private dwType As Integer
	Private dwSeman As Integer
	
	Private szErrorMessage As String
	
	Private mDirCol As New cDirList
	
	
	Public Event FileTransferProgress(ByRef lCurrentBytes As Integer, ByRef lTotalBytes As Integer)
	
	
	ReadOnly Property Directory() As cDirList
		Get
			Directory = mDirCol
		End Get
	End Property
	
	
	ReadOnly Property GetLastErrorMessage() As String
		Get
			GetLastErrorMessage = szErrorMessage
		End Get
	End Property
	
	Public Function OpenConnection(ByRef sServer As String, ByRef sUser As String, ByRef sPassword As String) As Boolean
		If hConnection <> 0 Then
			InternetCloseHandle(hConnection)
		End If
		
		If CBool(InternetAutodial(INTERNET_AUTODIAL_FORCE_ONLINE, 0)) Then
			hOpen = InternetOpen("eDIY FTP Client", INTERNET_OPEN_TYPE_PRECONFIG, vbNullString, vbNullString, 0)
			If hOpen = 0 Then
				ErrorOut(Err.LastDllError, "InternetOpen")
			End If
			'InternetSetStatusCallback hOpen, AddressOf FTPCallBack
			
			hConnection = InternetConnect(hOpen, sServer, INTERNET_INVALID_PORT_NUMBER, sUser, sPassword, INTERNET_SERVICE_FTP, dwSeman, 0)
			If hConnection = 0 Then
				ErrorOut(Err.LastDllError, "InternetConnect")
				OpenConnection = False
				Exit Function
			Else
				'InternetSetStatusCallback hConnection, AddressOf FTPCallBack
				OpenConnection = True
			End If
		Else
			OpenConnection = False
		End If
	End Function
	
	
	Public Sub CloseConnection()
		If hConnection <> 0 Then
			InternetCloseHandle(hConnection)
		End If
		hConnection = 0
		InternetCloseHandle(hOpen)
		hOpen = 0
		
	End Sub
	
	Public Function SimpleFTPPutFile(ByRef sLocal As String, ByRef sRemote As String) As Boolean
		If (FTPPutFile(hConnection, sLocal, sRemote, dwType, 0) = False) Then
			ErrorOut(Err.LastDllError, "SimpleFtpPutFile")
			SimpleFTPPutFile = False
			Exit Function
		Else
			SimpleFTPPutFile = True
		End If
	End Function
	
	Public Function RenameFTPFile(ByRef sExisting As String, ByRef sNewName As String) As Boolean
		If (FtpRenameFile(hConnection, sExisting, sNewName) = False) Then
			ErrorOut(Err.LastDllError, "RenameFTPFile")
			RenameFTPFile = False
			Exit Function
		Else
			RenameFTPFile = True
		End If
	End Function
	
	Public Function CreateFTPDirectory(ByRef sDirectory As String) As Boolean
		If (FtpCreateDirectory(hConnection, sDirectory) = False) Then
			ErrorOut(Err.LastDllError, "CreateFTPDirectory")
			CreateFTPDirectory = False
			Exit Function
		Else
			CreateFTPDirectory = True
		End If
	End Function
	
	Public Function RemoveFTPDirectory(ByRef sDirectory As String) As Boolean
		If (FtpRemoveDirectory(hConnection, sDirectory) = False) Then
			ErrorOut(Err.LastDllError, "RemoveFTPDirectory")
			RemoveFTPDirectory = False
			Exit Function
		Else
			RemoveFTPDirectory = True
		End If
	End Function
	
	Public Function DeleteFTPFile(ByRef sRemote As String) As Boolean
		If (FtpDeleteFile(hConnection, sRemote) = False) Then
			ErrorOut(Err.LastDllError, "DeleteFTPFile")
			DeleteFTPFile = False
			Exit Function
		Else
			DeleteFTPFile = True
		End If
	End Function
	
	Public Function FTPUploadFile(ByRef sLocal As String, ByRef sRemote As String) As Boolean
		Dim Data(BUFFERSIZE - 1) As Byte
		Dim Written As Integer
		Dim Size As Integer
		Dim Sum As Integer
		Dim lBlock As Integer
		
		Sum = 0
		lBlock = 0
		sLocal = Trim(sLocal)
		sRemote = Trim(sRemote)
		
		If sLocal <> "" And sRemote <> "" Then
			hFile = FtpOpenFile(hConnection, sRemote, GENERIC_WRITE, dwType, 0)
			If hFile = 0 Then
				ErrorOut(Err.LastDllError, "FtpOpenFile:PutFile")
				FTPUploadFile = False
				Exit Function
			End If
			
			FileOpen(1, sLocal, OpenMode.Binary, OpenAccess.Read)
			Size = LOF(1)
			For lBlock = 1 To Size \ BUFFERSIZE
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, Data)
				If (InternetWriteFile(hFile, Data(0), BUFFERSIZE, Written) = 0) Then
					FTPUploadFile = False
					ErrorOut(Err.LastDllError, "InternetWriteFile")
					Exit Function
				End If
				System.Windows.Forms.Application.DoEvents()
				Sum = Sum + BUFFERSIZE
				
				RaiseEvent FileTransferProgress(Sum, Size)
			Next lBlock
			
			'check for leftovers
			If Size Mod BUFFERSIZE <> 0 Then
				'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileGet(1, Data)
				If (InternetWriteFile(hFile, Data(0), Size Mod BUFFERSIZE, Written) = 0) Then
					FTPUploadFile = False
					ErrorOut(Err.LastDllError, "InternetWriteFile2")
					Exit Function
				End If
			End If
			
			Sum = Size
			FileClose(1)
			RaiseEvent FileTransferProgress(Sum, Size)
			InternetCloseHandle(hFile)
			FTPUploadFile = True
		End If
	End Function
	
	Public Function FTPDownloadFile(ByRef sLocal As String, ByRef sRemote As String) As Boolean
		Dim Data(BUFFERSIZE - 1) As Byte ' array of 100 elements 0 to 99
		Dim Written As Integer
		Dim Size As Integer
		Dim Sum As Integer
		Dim lBlock As Integer
		FTPDownloadFile = False
		
		Sum = 0
		lBlock = 0
		
		sLocal = Trim(sLocal)
		sRemote = Trim(sRemote)
		
		If sLocal <> "" And sRemote <> "" Then
			Size = GetFTPFileSize(sRemote)
			
			If Size > 0 Then
				hFile = FtpOpenFile(hConnection, sRemote, GENERIC_READ, dwType, 0)
				If hFile = 0 Then
					ErrorOut(Err.LastDllError, "FtpOpenFile:GetFile")
					Exit Function
				End If
				
				FileOpen(1, sLocal, OpenMode.Binary, OpenAccess.Write)
				Seek(1, 1)
				Sum = 1
				For lBlock = 1 To Size \ BUFFERSIZE
					If (InternetReadFile(hFile, Data(0), BUFFERSIZE, Written) = 0) Then
						ErrorOut(Err.LastDllError, "InternetReadFile")
						FileClose(1)
						Exit Function
					End If
					'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FilePut(1, Data)
					System.Windows.Forms.Application.DoEvents()
					Sum = Sum + BUFFERSIZE
					RaiseEvent FileTransferProgress(Sum, Size)
				Next lBlock
				
				'Check for leftovers
				If Size Mod BUFFERSIZE <> 0 Then
					Dim Data2((Size Mod BUFFERSIZE) - 1) As Byte
					If (InternetReadFile(hFile, Data2(0), Size Mod BUFFERSIZE, Written) = 0) Then
						ErrorOut(Err.LastDllError, "InternetReadFile2")
						FileClose(1)
						Exit Function
					End If
				End If
				
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(1, Data2)
				FileClose(1)
				
				Sum = Size
				RaiseEvent FileTransferProgress(Sum, Size)
				InternetCloseHandle(hFile)
				FTPDownloadFile = True
			End If
		End If
	End Function
	
	Public Function SimpleFTPGetFile(ByRef sLocal As String, ByRef sRemote As String) As Boolean
		' add INTERNET_FLAG_NO_CACHE_WRITE to avoid local caching 0x04000000 (hex)
		If (FTPGetFile(hConnection, sRemote, sLocal, False, FILE_ATTRIBUTE_NORMAL, dwType Or INTERNET_FLAG_RELOAD, 0) = False) Then
			ErrorOut(Err.LastDllError, "SimpleFtpGetFile")
			SimpleFTPGetFile = False
			Exit Function
		Else
			SimpleFTPGetFile = True
		End If
	End Function
	
	Public Function GetFTPDirectory() As String
		Dim szDir As String
		szDir = New String(Chr(0), 1024)
		If (FtpGetCurrentDirectory(hConnection, szDir, 1024) = False) Then
			ErrorOut(Err.LastDllError, "FtpGetCurrentDirectory")
			Exit Function
		Else
			GetFTPDirectory = Left(szDir, InStr(1, szDir, New String(Chr(0), 1), CompareMethod.Binary) - 1)
		End If
	End Function
	
	Public Function SetFTPDirectory(ByRef sDir As String) As Object
		If (FtpSetCurrentDirectory(hConnection, sDir) = False) Then
			ErrorOut(Err.LastDllError, "FtpSetCurrentDirectory")
			'UPGRADE_WARNING: Couldn't resolve default property of object SetFTPDirectory. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetFTPDirectory = False
			Exit Function
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object SetFTPDirectory. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetFTPDirectory = True
		End If
	End Function
	
	Public Function GetFTPFileSize(ByRef sFile As String) As Integer
		Dim szDir As String
		Dim hFind As Integer
		Dim nLastError As Integer
		Dim pData As WIN32_FIND_DATA
		
		hFind = FtpFindFirstFile(hConnection, "*.*", pData, 0, 0)
		nLastError = Err.LastDllError
		If hFind = 0 Then
			If (nLastError = ERROR_NO_MORE_FILES) Then
				GetFTPFileSize = -1 ' File not found
				
			Else
				GetFTPFileSize = -2 ' Other error
				ErrorOut(Err.LastDllError, "FtpFindFirstFile")
				
			End If
			Exit Function
		End If
		
		Do 
			
			'Get current file
			szDir = Mid(pData.cFileName, 1, InStr(pData.cFileName, Chr(0)) - 1)
			
			'Check wether its the file we want
			If LCase(szDir) = LCase(sFile) Then
				Exit Do
			End If
			
			
			'Check for next file
		Loop While InternetFindNextFile(hFind, pData)
		
		GetFTPFileSize = pData.nFileSizeLow
		
		InternetCloseHandle(hFind)
	End Function
	
	Public Function GetDirectoryListing(ByRef sFilter As String) As cDirList
		Dim szDir As String
		Dim hFind As Integer
		Dim nLastError As Integer
		Dim dError As Integer
		Dim ptr As Integer
		Dim pData As WIN32_FIND_DATA
		Dim sFilename As String
		
		'UPGRADE_NOTE: Object mDirCol may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mDirCol = Nothing
		hFind = FtpFindFirstFile(hConnection, sFilter, pData, 0, 0)
		nLastError = Err.LastDllError
		If hFind = 0 Then
			If (nLastError <> ERROR_NO_MORE_FILES) Then
				ErrorOut(Err.LastDllError, "FtpFindFirstFile")
			End If
			Exit Function
		End If
		
		dError = NO_ERROR
		Dim bRet As Boolean
		
		sFilename = Left(pData.cFileName, InStr(1, pData.cFileName, New String(Chr(0), 1), CompareMethod.Binary) - 1)
		mDirCol.Add(pData.dwFileAttributes, Win32ToVbTime(pData.ftCreationTime), Win32ToVbTime(pData.ftLastAccessTime), Win32ToVbTime(pData.ftLastWriteTime), pData.nFileSizeLow, sFilename)
		Do 
			pData.cFileName = New String(Chr(0), MAX_PATH)
			bRet = InternetFindNextFile(hFind, pData)
			If Not bRet Then
				dError = Err.LastDllError
				If dError = ERROR_NO_MORE_FILES Then
					Exit Do
				Else
					ErrorOut(Err.LastDllError, "InternetFindNextFile")
					InternetCloseHandle(hFind)
					Exit Function
				End If
			Else
				sFilename = Left(pData.cFileName, InStr(1, pData.cFileName, New String(Chr(0), 1), CompareMethod.Binary) - 1)
				mDirCol.Add(pData.dwFileAttributes, Win32ToVbTime(pData.ftCreationTime), Win32ToVbTime(pData.ftLastAccessTime), Win32ToVbTime(pData.ftLastWriteTime), pData.nFileSizeLow, sFilename)
			End If
		Loop 
		
		GetDirectoryListing = mDirCol
		InternetCloseHandle(hFind)
	End Function
	
	Public Sub SetTransferASCII()
		dwType = FTP_TRANSFER_TYPE_ASCII
	End Sub
	
	Public Sub SetTransferBinary()
		dwType = FTP_TRANSFER_TYPE_BINARY
	End Sub
	
	Public Sub SetModeActive()
		dwSeman = 0
	End Sub
	
	Public Sub SetModePassive()
		dwSeman = INTERNET_FLAG_PASSIVE
	End Sub
	
	' -- Private Functions
	
	Private Sub ErrorOut(ByVal dwError As Integer, ByRef szFunc As String)
		Dim dwRet As Integer
		Dim dwTemp As Integer
		Dim szString As New VB6.FixedLengthString(2048)
		dwRet = FormatMessage(FORMAT_MESSAGE_FROM_HMODULE, GetModuleHandle("wininet.dll"), dwError, 0, szString.Value, 256, 0)
		szErrorMessage = szFunc & " error code: " & dwError & " Message: " & szString.Value
		
		If (dwError = 12003) Then
			' Extended error information was returned
			dwRet = InternetGetLastResponseInfo(dwTemp, szString.Value, 2048)
			szErrorMessage = szString.Value
		End If
		
		'Debug.Print szErrorMessage
	End Sub
	
	Private Function Win32ToVbTime(ByRef ft As Decimal) As Date
		Dim ftl As Decimal
		' Call API to convert from UTC time to local time
		If FileTimeToLocalFileTime(ft, ftl) Then
			' Local time is nanoseconds since 01-01-1601
			' In Currency that comes out as milliseconds
			' Divide by milliseconds per day to get days since 1601
			' Subtract days from 1601 to 1899 to get VB Date equivalent
			Win32ToVbTime = System.Date.FromOADate((ftl / rMillisecondPerDay) - rDayZeroBias)
		Else
			MsgBox(Err.LastDllError)
		End If
	End Function
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'BUFFERSIZE = 10240
		dwType = FTP_TRANSFER_TYPE_ASCII
		dwSeman = 0
		hConnection = 0
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	
	
	
	
	' -- If anyone can get the wininet.dll to call the FTPCallback function for
	' -- status updates (in a public module), please email mike@ediy.co.nz.
	
	'Public Declare Function InternetSetStatusCallback Lib "wininet.dll" (ByVal hInternetSession As Long, ByVal lpfnCallBack As Long) As Long
	'
	'Public Function FTPCallBack(ByVal hInternet As Long, ByVal dwContext As Long, ByVal dwInternetStatus As Long, ByVal lpvStatusInformation As Long, ByVal dwStatusInformationLength As Long) As Long
	'   Debug.Print "Status: " & dwInternetStatus
	'End Function
	'
	'Public Const INTERNET_STATUS_RESOLVING_NAME = 10
	'Public Const INTERNET_STATUS_NAME_RESOLVED = 11
	'Public Const INTERNET_STATUS_CONNECTING_TO_SERVER = 20
	'Public Const INTERNET_STATUS_CONNECTED_TO_SERVER = 21
	'Public Const INTERNET_STATUS_SENDING_REQUEST = 30
	'Public Const INTERNET_STATUS_REQUEST_SENT = 31
	'Public Const INTERNET_STATUS_RECEIVING_RESPONSE = 40
	'Public Const INTERNET_STATUS_RESPONSE_RECEIVED = 41
	'Public Const INTERNET_STATUS_CTL_RESPONSE_RECEIVED = 42
	'Public Const INTERNET_STATUS_PREFETCH = 43
	'Public Const INTERNET_STATUS_CLOSING_CONNECTION = 50
	'Public Const INTERNET_STATUS_CONNECTION_CLOSED = 51
	'Public Const INTERNET_STATUS_HANDLE_CREATED = 60
	'Public Const INTERNET_STATUS_HANDLE_CLOSING = 70
	'Public Const INTERNET_STATUS_REQUEST_COMPLETE = 100
	'Public Const INTERNET_STATUS_REDIRECT = 110
	'Public Const INTERNET_STATUS_INTERMEDIATE_RESPONSE = 120
	'Public Const INTERNET_STATUS_STATE_CHANGE = 200
End Class