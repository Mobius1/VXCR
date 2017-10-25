Option Strict Off
Option Explicit On
Module modSettings
	'Setting Data Structor
	Private Structure VXCR_Settings
		Dim blnLvpcIDTag As Boolean 'Show Filename or IDTag
		Dim strAutoCIP As String 'Auto Connect IP
		Dim intXbToPC As Short 'Xbox->PC Audio Format Convers
		<VBFixedArray(9)> Dim strRConnect() As String 'Recently Connected IPs
		Dim strSFormats As String 'Which Audio Formats To List
		Dim intIDStuff As Short 'Weather to Read IDTag/FileName/etc
		Dim blnManuIDTag As Boolean 'Manually Enter ID Tag before Upload
		Dim strTempFld As String 'Location for Temp files
		Dim strFTPPass As String 'FTP Pass
		Dim strFTPUser As String 'FTP UserName
		Dim blnShwLBitRate As Boolean 'Weather to Show BitRate or Not (Local Files Only)
		Dim lngWmaBitRate As Integer 'Which BitRates WMA's are converted too
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim strRConnect(9)
		End Sub
	End Structure
	
	'Declares Setting Varible
	'UPGRADE_WARNING: Arrays in structure VXCRSettings may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public VXCRSettings As VXCR_Settings
	
	Public Function LoadVXCRSettings() As Boolean
		On Error GoTo ErrHnd
		
		Dim intFF As Short
		intFF = FreeFile
		
		'Opens Setting File
		FileOpen(intFF, My.Application.Info.DirectoryPath & "\Settings.ini", OpenMode.Binary)
		
		'Reads Setting File
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(intFF, VXCRSettings)
		FileClose(intFF)
		
		'Returns Successfull Info
		LoadVXCRSettings = True
		
		Exit Function
ErrHnd: 
		
		LoadVXCRSettings = False
	End Function
	
	Public Function SaveVXCRSettings() As Boolean
		On Error GoTo ErrHnd
		
		Dim intFF As Short
		intFF = FreeFile
		
		'Opens Setting File
		FileOpen(intFF, My.Application.Info.DirectoryPath & "\Settings.ini", OpenMode.Binary)
		
		'Reads Setting File
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(intFF, VXCRSettings)
		FileClose(intFF)
		
		'Returns Successfull Info
		SaveVXCRSettings = True
		
		Exit Function
ErrHnd: 
		
		SaveVXCRSettings = False
	End Function
End Module