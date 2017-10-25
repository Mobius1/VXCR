Option Strict Off
Option Explicit On
Module modCDRipper
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Public Declare Sub CopyMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal length As Integer)
	Public Declare Function lstrlen Lib "kernel32"  Alias "lstrlenA"(ByVal lpString As Integer) As Integer
	
	Public lngCDID As Integer
	Public strCDDrives As String
	
	'Grabs List of CD Drives
	Public Function ListCDDrives(ByRef stbMain As System.Windows.Forms.StatusStrip) As Object
		
		'Declares Memory Units
		Dim intA As Short
		Dim strCDDrive As String
		Dim strDriveLetter As String
		
		'Sets Variable to First Possible CD Drive
		intA = 0
		
		'Clears Memory Drives
		strCDDrives = ""
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Search for CD Drives, Please Wait..."
		
		'Gets Drive Information
		strCDDrive = CStr(BASS_CD_GetDriveDescription(intA))
		
		'Loops Until No Drive is Detected
		Do Until CDbl(strCDDrive) = 0
			System.Windows.Forms.Application.DoEvents()
			
			'Get Drive Letter
			strDriveLetter = Chr(65 + BASS_CD_GetDriveLetter(intA))
			
			strCDDrives = strCDDrives & strDriveLetter
			
			'Get Next Drive
			intA = intA + 1
			strCDDrive = CStr(BASS_CD_GetDriveDescription(intA))
			
		Loop 
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Ready"
		
	End Function
	
	Public Sub LoadTrackList(ByRef lvItem As System.Windows.Forms.ListView, ByRef stbMain As System.Windows.Forms.StatusStrip)
		
		Dim lngA As Integer
		Dim lngTrackCount As Integer
		Dim lngTrackLength As Integer
		Dim lngCDTextPtr As Integer
		
		'Clear ListView
		lvItem.Items.Clear()
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Loading CD Track List, Please Wait..."
		
		'Load Track List
		If BASS_CD_IsReady(lngCDID) Then
			
			'Get number of tracks
			lngTrackCount = BASS_CD_GetTracks(lngCDID)
			
			'Make sure there wasn't an error
			If lngTrackCount = -1 Then
				
				'Error
				MsgBox("Error retreiving number of tracks.")
				
			Else
				
				'Get the CD-Text data from the CD
				lngCDTextPtr = BASS_CD_GetID(lngCDID, BASS_CDID_TEXT)
				
				'See if the CD has and CD-Text
				If lngCDTextPtr <> 0 Then
					
					'Use the CD-Text data to display a better track list
					Call LoadTrackListFromCDText(lngCDTextPtr, lngTrackCount)
					
				Else
					
					'Set the Artist / Album names
					' txtCDArtist.text = "Unknown Artist"
					' txtCDAlbum.text = "Unknown Album"
					
					'Populate list
					For lngA = 0 To lngTrackCount - 1
						
						'Get the length of the track in blocks
						lngTrackLength = BASS_CD_GetTrackLength(lngCDID, lngA)
						
						'Make sure it's valid
						If lngTrackLength > 0 Then
							
							'Convert to seconds
							lngTrackLength = lngTrackLength / 176400
							
							'Add to track list
							'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Image property was not upgraded Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D94970AE-02E7-43BF-93EF-DCFCD10D27B5"'
							lvItem.Items.Add("Track " & CStr(lngA + 1), 13)
							'lvitem.ListItems(lvitem.ListItems.Count).SubItems(1) = "Track " & CStr(lngA + 1)
							'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems(lvItem.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If lvItem.Items.Item(lvItem.Items.Count).SubItems.Count > 2 Then
								lvItem.Items.Item(lvItem.Items.Count).SubItems(2).Text = Seconds2HMS(lngTrackLength)
							Else
								lvItem.Items.Item(lvItem.Items.Count).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Seconds2HMS(lngTrackLength)))
							End If
							
						Else
							Call ThrowError("There was an error.", BASS_ErrorGetCode)
						End If
					Next lngA
					
					
					'Grabs CD-ID
					frmMain.Text = CDDBDiscId
					
					
				End If
				
			End If
			
		Else
			
		End If
		
		'Updates Status Bar
		'UPGRADE_WARNING: Lower bound of collection stbMain.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		stbMain.Items.Item(1).Text = "Ready"
	End Sub
	
	Public Sub LoadTrackListFromCDText(ByVal lngTagPtr As Integer, ByVal lTrackCount As Integer)
		Dim lstTracks As Object
		Dim txtCDAlbum As Object
		Dim txtCDArtist As Object
		On Error GoTo Err_Init
		
		'Declares Memory Values
		Dim strTag As String
		Dim i As Integer
		Dim aryTitle() As String
		Dim aryPerformers() As String
		Dim lIndx As Integer
		Dim lTrackLength As Integer
		
		'To hold the track titles / artists
		ReDim aryTitle(lTrackCount)
		ReDim aryPerformers(lTrackCount)
		
		'Get First Tag
		strTag = VBStrFromAnsiPtr(lngTagPtr)
		
		'The last TAG will be a null CHR(0)
		While (strTag <> Chr(0)) And (strTag <> "")
			
			'Determine what to do with the text
			If UCase(Left(strTag, 5)) = "TITLE" Then
				
				'Updates Variables
				lIndx = CInt(Mid(strTag, 6, InStr(strTag, "=") - 6))
				aryTitle(lIndx) = Mid(strTag, InStr(strTag, "=") + 1)
				
			ElseIf UCase(Left(strTag, 9)) = "PERFORMER" Then 
				
				'Updates Variables
				lIndx = CInt(Mid(strTag, 10, InStr(strTag, "=") - 10))
				aryPerformers(lIndx) = Mid(strTag, InStr(strTag, "=") + 1)
				
			End If
			
			'Move Pointer
			lngTagPtr = lngTagPtr + Len(strTag) + 1
			
			'Get Next Tag
			strTag = VBStrFromAnsiPtr(lngTagPtr)
		End While
		
		'Set the CD Artist / Album names. Index 0 applies to the entire CD.
		'UPGRADE_WARNING: Couldn't resolve default property of object txtCDArtist.text. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtCDArtist.text = aryPerformers(0)
		'UPGRADE_WARNING: Couldn't resolve default property of object txtCDAlbum.text. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtCDAlbum.text = aryTitle(0)
		
		'Now that we got all the usable tags. Lets display it in the Listbox
		For i = 0 To lTrackCount - 1
			
			'Get the length of the track in blocks
			lTrackLength = BASS_CD_GetTrackLength(lngCDID, i)
			
			'Make sure it's valid
			If lTrackLength > 0 Then
				
				'Convert to seconds
				lTrackLength = lTrackLength / 176400
				
				'Add to listbox formatted as [##] Performer / Title          [00:00]
				'UPGRADE_WARNING: Couldn't resolve default property of object lstTracks.AddItem. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lstTracks.AddItem(VB6.Format(i + 1, "0#") & vbTab & aryPerformers(i + 1) & " / " & aryTitle(i + 1) & vbTab & "[" & Seconds2HMS(lTrackLength) & "]")
			End If
		Next 
		
No_Err: 
		
ExitRoutine: 
		
		'Clean Up
		Erase aryTitle
		Erase aryPerformers
		
		Exit Sub
		
Err_Init: 
		'HandleError strCurrentModule, "LoadTrackListFromCDText", Err.Number, Err.Description
		GoTo ExitRoutine
	End Sub
	
	Public Function VBStrFromAnsiPtr(ByVal lpStr As Integer) As String
		On Error Resume Next
		
		'Declares Memory Units
		Dim bytStr() As Byte
		Dim lngChars As Integer
		
		'Get the number of characters in the buffer
		lngChars = lstrlen(lpStr)
		
		'Resize the byte array
		ReDim bytStr(lngChars - 1)
		
		'Grab the ANSI buffer
		Call CopyMemory(bytStr(0), lpStr, lngChars)
		
		'Now convert to a VB Unicode string
		'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		VBStrFromAnsiPtr = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(bytStr), vbUnicode)
		
	End Function
	
	'Quick and Dirty routine to convert a value of seconds into a formatted hh:mm:ss string
	Public Function Seconds2HMS(ByVal lngSeconds As Integer) As String
		
		'Declares Memory Values
		Dim CurrentHSecs As Double
		Dim Hours As Double
		Dim Mins As Double
		Dim Secs As Double
		Dim HSecs As Double
		
		'Converts #s
		CurrentHSecs = Int((lngSeconds) + 0.5)
		Hours = Int(CurrentHSecs \ 3600)
		CurrentHSecs = CurrentHSecs - (Hours * 3600)
		Mins = Int(CurrentHSecs \ 60)
		CurrentHSecs = CurrentHSecs - (Mins * 60)
		Secs = CShort(CurrentHSecs)
		
		'Outputs Proper Format
		If Hours > 0 Then
			Seconds2HMS = Right("00" & Hours, 2) & ":" & Right("00" & Mins, 2) & ":" & Right("00" & Secs, 2)
		Else
			Seconds2HMS = Right("00" & Mins, 2) & ":" & Right("00" & Secs, 2) ' & "." & Right("00" & HSecs, 2)
		End If
		
	End Function
End Module