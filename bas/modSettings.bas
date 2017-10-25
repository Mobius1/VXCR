Attribute VB_Name = "modSettings"
'Setting Data Structor
Private Type VXCR_Settings
    blnLvpcIDTag As Boolean     'Show Filename or IDTag
    strAutoCIP As String        'Auto Connect IP
    intXbToPC As Integer        'Xbox->PC Audio Format Convers
    strRConnect(9) As String    'Recently Connected IPs
    strSFormats As String       'Which Audio Formats To List
    intIDStuff As Integer       'Weather to Read IDTag/FileName/etc
    blnManuIDTag As Boolean     'Manually Enter ID Tag before Upload
    strTempFld As String        'Location for Temp files
    strFTPPass As String        'FTP Pass
    strFTPUser As String        'FTP UserName
    blnShwLBitRate As Boolean   'Weather to Show BitRate or Not (Local Files Only)
    lngWmaBitRate As Long       'Which BitRates WMA's are converted too
End Type

'Declares Setting Varible
Public VXCRSettings As VXCR_Settings

Public Function LoadVXCRSettings() As Boolean
    On Error GoTo ErrHnd
    
    Dim intFF As Integer
    intFF = FreeFile
    
    'Opens Setting File
    Open App.path & "\Settings.ini" For Binary As #intFF
    
    'Reads Setting File
    Get #intFF, , VXCRSettings
    Close #intFF
    
    'Returns Successfull Info
    LoadVXCRSettings = True
    
    Exit Function
ErrHnd:
    
    LoadVXCRSettings = False
End Function

Public Function SaveVXCRSettings() As Boolean
    On Error GoTo ErrHnd
    
    Dim intFF As Integer
    intFF = FreeFile
    
    'Opens Setting File
    Open App.path & "\Settings.ini" For Binary As #intFF
    
    'Reads Setting File
    Put #intFF, , VXCRSettings
    Close #intFF
    
    'Returns Successfull Info
    SaveVXCRSettings = True
    
    Exit Function
ErrHnd:
    
    SaveVXCRSettings = False
End Function
