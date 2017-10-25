Option Strict Off
Option Explicit On
Module modXboxST
	'---------------------------------------------------
	'Xbox Sound Track Editor Module 1.00 (CONFIDUENTUAL)
	'
	'Created by: BlueCELL & XBOX War3z
	'Date: Feb 25, 2004 10:31AM
	'---------------------------------------------------
	
	'Magic Values
	Const SOUNDTRACK_MAGIC As Integer = 136049
	Const SONGGROUP_MAGIC As Integer = 200819
	
	'Max Constants
	Const MAX_SOUNDTRACK_COUNT As Short = 100
	Const MAX_SOUNDTRACK_NAME As Short = 32 * 2 'Unicode
	Const MAX_SONG_NAME As Short = 32 * 2 'Unicode
	
	'Definition of each soundtrack
	Private Structure SoundTrack
		Dim lngMagic As Integer 'always check for SOUNDTRACK_MAGIC
		Dim lngID As Integer
		Dim lngSongCount As Integer
		<VBFixedArray(83)> Dim lngGroupId() As Integer 'total of max 84*6 = 504 songs
		Dim lngTotalTime As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_SOUNDTRACK_NAME),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_SOUNDTRACK_NAME)> Public strName() As Char
		<VBFixedArray(95)> Dim bytFiller() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim lngGroupId(83)
			ReDim bytFiller(95)
		End Sub
	End Structure
	
	'Definition of the header
	Private Structure SoundTrack_Header
		Dim lngUnknown As Integer 'always 1
		Dim lngCount As Integer
		Dim lngNextId As Integer
		<VBFixedArray(MAX_SOUNDTRACK_COUNT - 1)> Dim lngID() As Integer
		Dim lngNextSongId As Integer
		<VBFixedArray(95)> Dim bytFiller() As Byte
		'UPGRADE_WARNING: Array stSoundtracks may need to have individual elements initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B97B714D-9338-48AC-B03F-345B617E2B02"'
		<VBFixedArray(MAX_SOUNDTRACK_COUNT - 1)> Dim stSoundtracks() As SoundTrack
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim lngID(MAX_SOUNDTRACK_COUNT - 1)
			ReDim bytFiller(95)
			ReDim stSoundtracks(MAX_SOUNDTRACK_COUNT - 1)
		End Sub
	End Structure
	
	Private Structure SongGroup
		Dim lngMagic As Integer 'always SONGGROUP_MAGIC
		Dim lngSoundtrackId As Integer
		Dim lngGroupId As Integer
		Dim lngUnknown As Integer 'always 1
		<VBFixedArray(5)> Dim lngFileName() As Integer 'use sprintf(somechar, "%08X.wma", filename[x]);
		<VBFixedArray(5)> Dim lngSongTime() As Integer
		'UPGRADE_ISSUE: Declaration type not supported: Array of fixed-length strings. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"'
		Dim strSongName(5) As String*MAX_SONG_NAME
		<VBFixedArray(63)> Dim bytFiller() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim lngFileName(5)
			ReDim lngSongTime(5)
			ReDim bytFiller(63)
		End Sub
	End Structure
	
	Private ff As Short 'File pointer for st.db file
	'UPGRADE_WARNING: Arrays in structure Header may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Private Header As SoundTrack_Header
	Private SongGroups() As SongGroup
	Private SongGroupNo(100) As Short
	Private blnIni As Boolean
	
	Public Function Initialize(ByRef STFileLoc As String) As Boolean
		
		'Declares Memory Varibles
		Dim lngA As Integer
		Dim lngB As Integer
		
		'On Error GoTo ErrHandler
		
		ff = FreeFile
		Initialize = True
		ReDim SongGroups(0)
		
		'Opens ST.DB File
		FileOpen(ff, frmMain.strSTDBLoc, OpenMode.Binary, OpenAccess.Read)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(ff, Header, 1)
		
		'Read first songgroup
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(ff, SongGroups(0))
		
		'Read all the other songgroups
		While Not EOF(ff)
			
			'Add one element to the array
			ReDim Preserve SongGroups(UBound(SongGroups) + 1)
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(ff, SongGroups(UBound(SongGroups)))
		End While
		
		'Closes Open File
		FileClose(ff)
		
		lngB = 0
		
		'Writes SongGroupNo Table (0 - 5)
		For lngA = 1 To 100
			System.Windows.Forms.Application.DoEvents()
			
			SongGroupNo(lngA) = lngB
			lngB = lngB + 1
			
			If lngB = 6 Then lngB = 0
			
		Next lngA
		
		'Tells other functions that We Loaded File
		blnIni = True
		
		Exit Function
		
ErrHandler: 
		Debug.Print(Err.Description)
		Initialize = False
		
	End Function
	
	Public Function SaveST() As Boolean
		'On Error GoTo ErrHnd
		
		'Declares Memory Varibles
		Dim intFF As Short
		Dim lngA As Integer
		
		intFF = FreeFile
		
		'Opens Local ST.DB File (Diffrent File Name)
		FileOpen(intFF, frmMain.strSTDBLoc, OpenMode.Binary)
		
		'Writes Header to file
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(intFF, Header)
		
		For lngA = 0 To UBound(SongGroups)
			System.Windows.Forms.Application.DoEvents()
			
			'Writes Data to file
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(intFF, SongGroups(lngA))
		Next 
		
		'Closes Open File
		FileClose(intFF)
		
		Exit Function
		
	End Function
	
	Public Function TerminateST() As Object 'strSTDBLoc
		
		'Declares Memory Varibles
		Dim intFF As Short
		Dim lngA As Integer
		
		intFF = FreeFile
		
		'Opens Local ST.DB File (Diffrent File Name)
		FileOpen(intFF, frmMain.strSTDBLoc, OpenMode.Binary)
		
		'Writes Header to file
		'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FilePut(intFF, Header)
		
		For lngA = 0 To UBound(SongGroups)
			System.Windows.Forms.Application.DoEvents()
			
			'Writes Data to file
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(intFF, SongGroups(lngA))
		Next 
		
		'Closes Open File
		FileClose(intFF)
		
		'Tells Us that we terminated ST Manager
		blnIni = False
		
	End Function
	
	Public Function AddSong(ByRef strSongTitle As String, ByRef strPath As String, ByRef strTimeSeconds As String, ByRef lngSoundTrack As Integer) As String
		
		'Declares Memory Varibles
		Dim strOutputfile As String 'Audio File Xbox will use
		Dim lngSoundGroup As Integer 'Which SongGroup to Write Song Too
		Dim lngSoundGroupArray As Integer 'Keeps SongGroup(X) << X = (0 - 83)
		Dim lngStCount As Integer 'Keeps SoundTrack Count (from header)
		
		'Finds Xbox FileName (first 4 Characters is Folder Name)
		strOutputfile = Right(VB6.Format("0000" & Hex(lngSoundTrack), "0000"), 4) & Right(VB6.Format("0000" & Hex(Header.lngNextSongId), "0000"), 4)
		
		'Increases NextSongID Varible
		Header.lngNextSongId = (Header.lngNextSongId + 1)
		
		'Finds SoundTrack Song Count
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngStCount = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount
		
		'Checks if we need to create new SongGroup
		Dim lngFreeSongGroup As Integer
		If InStr(1, CStr(lngStCount / 6), ".") Or (lngStCount / 6) = 0 Then
			
			'Sets Storing Location
			'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lngSoundGroup = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngGroupId(RndUp_Dec(CStr(lngStCount / 6)))
			lngSoundGroupArray = SongGroupNo(lngStCount + 1)
			
		Else
			
			'Declares More Variables
			
			'Finds Free SongGroup
			lngFreeSongGroup = FindFreeSongGroup
			
			'Need to Create New SongGroup
			lngSoundGroup = (lngStCount / 6) 'GROUPID, for Header
			
			'Sets up Header for utilizing new SongGroup
			'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngGroupId(lngSoundGroup) = lngFreeSongGroup
			
			'Sets up new SongGroup
			'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SongGroups(lngFreeSongGroup).lngSoundtrackId = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngID
			SongGroups(lngFreeSongGroup).lngMagic = SONGGROUP_MAGIC
			SongGroups(lngFreeSongGroup).lngUnknown = 1
			SongGroups(lngFreeSongGroup).lngGroupId = lngSoundGroup
			
			'Sets Additional Information
			lngSoundGroup = lngFreeSongGroup
			lngSoundGroupArray = SongGroupNo(lngStCount + 1)
			
		End If
		
		'Returns Output File
		AddSong = strOutputfile
		
		'Checks if 500(max) songs are used
		If lngStCount >= 500 Then
			
			AddSong = "ERR: MAXED OUT"
			Exit Function
		End If
		
		'Checks Name Length (No Bigger than 32)
		If Len(strSongTitle) > 32 Then
			strSongTitle = Left(strSongTitle, 32)
		End If
		
		'Writes Data
		SongGroups(lngSoundGroup).lngFileName(lngSoundGroupArray) = Val("&H" & strOutputfile)
		SongGroups(lngSoundGroup).lngSongTime(lngSoundGroupArray) = (CDbl(strTimeSeconds) * 1000)
		'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		SongGroups(lngSoundGroup).strSongName(lngSoundGroupArray) = StrConv(strSongTitle, vbUnicode) & New String(Chr(0), MAX_SOUNDTRACK_NAME - Len(StrConv(strSongTitle, vbUnicode)))
		
		'Increases SoundTrack Count
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount = (Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngSongCount + 1)
		
		'Increases Header Total Time
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngTotalTime = Header.stSoundtracks(FindHeaderfromID(lngSoundTrack)).lngTotalTime + (CDbl(strTimeSeconds) * 1000)
		
	End Function
	
	
	Public Function AddSoundTrack(ByRef strSoundTrackName As String, Optional ByRef tvSoundTracks As System.Windows.Forms.TreeView = Nothing) As Object
		'On Error Resume Next
		
		'Declares Memory Variables
		Dim lngFreeSG As Integer
		
		'Finds Free SongGroup
		lngFreeSG = FindFreeSongGroup
		
		'Checks if theres a SoundTrackName
		If strSoundTrackName = "" Then Exit Function
		
		'Increases Nessarcy Data Types
		Header.lngCount = Header.lngCount + 1 'Track Count (0-99)
		Header.lngNextId = Header.lngNextId + 1 'Next SoundTrack ID
		
		'Adds New SoundTrack to Database
		'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		Header.stSoundtracks(Header.lngCount - 1).strName = StrConv(strSoundTrackName, vbUnicode) & New String(Chr(0), MAX_SOUNDTRACK_NAME - Len(StrConv(strSoundTrackName, vbUnicode)))
		Header.stSoundtracks(Header.lngCount - 1).lngID = (Header.lngNextId - 1)
		Header.stSoundtracks(Header.lngCount - 1).lngSongCount = 0
		Header.stSoundtracks(Header.lngCount - 1).lngTotalTime = 0
		Header.stSoundtracks(Header.lngCount - 1).lngMagic = SOUNDTRACK_MAGIC
		Header.stSoundtracks(Header.lngCount - 1).lngGroupId(0) = lngFreeSG
		
		'Checks if we need to create another Array Element
		If UBound(SongGroups) < Header.lngNextId Then
			
			'Create New Array Element
			ReDim Preserve SongGroups(UBound(SongGroups) + 1)
			
		End If
		
		'Adds Header lngID
		Header.lngID(Header.lngCount - 1) = (Header.lngNextId - 1)
		
		'ORGINAL
		SongGroups(lngFreeSG).lngGroupId = 0 'Header.stSoundtracks(Header.lngCount - 1).lngGroupId(0)
		SongGroups(lngFreeSG).lngMagic = SONGGROUP_MAGIC
		SongGroups(lngFreeSG).lngUnknown = 1
		SongGroups(lngFreeSG).lngSoundtrackId = (Header.lngNextId - 1)
		
		'Fixes Header
		Header.lngID(Header.lngCount - 1) = (Header.lngNextId - 1)
		
		'Adds Item to Listview
		'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
		tvSoundTracks.Nodes.Find("XB", True)(0).Nodes.Add("#" & (Header.lngNextId - 1), strSoundTrackName, 4)
		
		'Selects Created SoundTrack
		'UPGRADE_WARNING: Lower bound of collection tvSoundTracks.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_ISSUE: MSComctlLib.Node property Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		tvSoundTracks.Nodes.Item(tvSoundTracks.Nodes.Count).Selected = True
		
	End Function
	
	Public Function ReadSoundTracks(ByRef tvSoundTracks As System.Windows.Forms.TreeView) As Object
		'    On Error Resume Next
		
		'Declares Memory Units
		Dim strName As String
		Dim lngA As Integer
		
		'Resets Xbox Treeview
		tvSoundTracks.Nodes.Clear()
		tvSoundTracks.Nodes.Add("XB", "Xbox Sound Tracks", 14)
		tvSoundTracks.Nodes.Item("XB").Expand()
		
		'Loops Through ALL SoundTracks
		For lngA = 0 To Header.lngCount - 1
			
			'Grabs SoundTrackNames & Removes NULLs
			strName = FixName(Header.stSoundtracks(lngA).strName)
			
			'Adds Item to Treeview
			'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
			tvSoundTracks.Nodes.Find("XB", True)(0).Nodes.Add("#" & Header.stSoundtracks(lngA).lngID, strName, 4)
			
		Next lngA
		
	End Function
	
	Public Function SoundTrackDetail(ByRef SoundTrack As Integer, ByRef lvItem As System.Windows.Forms.ListView) As Object
		Dim i As Object
		
		'Declares Memory Varibles
		Dim lngB As Integer
		Dim lngStCount As Integer
		Dim lngTotalAdded As Integer
		
		'Default Values
		lngTotalAdded = 0
		
		'Clears Listview Up
		lvItem.Items.Clear()
		
		'Finds SoundTrack Song Count
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngStCount = Header.stSoundtracks(FindHeaderfromID(SoundTrack)).lngSongCount
		
		'Loops through Each SongGroups
		For lngB = 0 To UBound(SongGroups)
			
			'Checks SoundTrack ID
			If SoundTrack = SongGroups(lngB).lngSoundtrackId Then
				
				'Loops through each Group
				For i = 0 To 5
					
					'Checks if we added all REAL info
					If lngTotalAdded = lngStCount Then
						Exit For
					End If
					
					'Increases Counter (That Way We Dont Read Old Info)
					lngTotalAdded = lngTotalAdded + 1
					
					'Checks for String in SongName
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Len(FixName(SongGroups(lngB).strSongName(i))) > 0 Then
						
						'Lists Data on Listview
						'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lvItem.Items.Add(FixName(SongGroups(lngB).strSongName(i)))
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems(lvItem.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If lvItem.Items.Item(lvItem.Items.Count).SubItems.Count > 2 Then
							lvItem.Items.Item(lvItem.Items.Count).SubItems(2).Text = VB6.Format("000" & Hex(SongGroups(lngB).lngFileName(i)), "00000000") & ".wma"
						Else
							lvItem.Items.Item(lvItem.Items.Count).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, VB6.Format("000" & Hex(SongGroups(lngB).lngFileName(i)), "00000000") & ".wma"))
						End If
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvItem.ListItems(lvItem.ListItems.Count) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If lvItem.Items.Item(lvItem.Items.Count).SubItems.Count > 1 Then
							lvItem.Items.Item(lvItem.Items.Count).SubItems(1).Text = ConvertMillisecondsToTime(SongGroups(lngB).lngSongTime(i))
						Else
							lvItem.Items.Item(lvItem.Items.Count).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ConvertMillisecondsToTime(SongGroups(lngB).lngSongTime(i))))
						End If
						
					End If
					
				Next 
			End If
		Next 
		
	End Function
	
	Public Function DeleteSoundTrack(ByRef HeaderID As Integer) As Object
		
		'Declares Memory Varibles
		Dim lngA As Integer
		Dim lngDeleteArray As Integer
		Dim lngLastUsedArray As Integer
		
		'Finds Header Item which Needs to be Deleted
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngDeleteArray = FindHeaderfromID(HeaderID)
		lngLastUsedArray = Header.lngCount - 1
		
		'Decreases SoundTrack Counts
		Header.lngCount = Header.lngCount - 1
		
		'Shifts Last item to Deleted Position
		
		'Filler
		For lngA = 0 To 95
			Header.stSoundtracks(lngDeleteArray).bytFiller(lngA) = Header.stSoundtracks(lngLastUsedArray).bytFiller(lngA)
		Next lngA
		
		'GroupID
		For lngA = 0 To 83
			Header.stSoundtracks(lngDeleteArray).lngGroupId(lngA) = Header.stSoundtracks(lngLastUsedArray).lngGroupId(lngA)
		Next lngA
		
		'lngID
		Header.stSoundtracks(lngDeleteArray).lngID = Header.stSoundtracks(lngLastUsedArray).lngID
		
		'Magic
		Header.stSoundtracks(lngDeleteArray).lngMagic = Header.stSoundtracks(lngLastUsedArray).lngMagic
		
		'SongCount
		Header.stSoundtracks(lngDeleteArray).lngSongCount = Header.stSoundtracks(lngLastUsedArray).lngSongCount
		
		'Total Time
		Header.stSoundtracks(lngDeleteArray).lngTotalTime = Header.stSoundtracks(lngLastUsedArray).lngTotalTime
		
		'SoundTrack Name (Unicode)
		Header.stSoundtracks(lngDeleteArray).strName = Header.stSoundtracks(lngLastUsedArray).strName
		
		'Updates LngID
		Header.lngID(lngDeleteArray) = Header.lngID(lngLastUsedArray)
		
	End Function
	Public Function FindHeaderfromID(ByRef lngID As Integer) As Object
		
		'Declares Memory Varibles
		Dim lngB As Integer
		
		'Sets None Value
		'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FindHeaderfromID = 9999
		
		'Finds SoundTrack Song Count
		For lngB = 0 To Header.lngCount - 1
			System.Windows.Forms.Application.DoEvents()
			
			'If Similiar ID's found
			If Header.stSoundtracks(lngB).lngID = lngID Then
				
				'Writes HeaderST to Memory
				'UPGRADE_WARNING: Couldn't resolve default property of object FindHeaderfromID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FindHeaderfromID = lngB
				
				Exit For
			End If
			
		Next lngB
	End Function
	Public Function FindFreeSongGroup() As Short
		
		'Checks if We initilized ST Manager
		'If blnIni <> True Then Exit Function
		
		'Declares Memory Variables
		Dim lngA As Integer 'Loops through SOUNDTRACKS
		Dim lngB As Integer 'Loops through GROUPID
		Dim strUsed As String 'Holds Used SongGroups
		Dim strA() As String
		Dim blnFound As Boolean
		
		'Loops Though each SoundTrack
		For lngA = 0 To (Header.lngCount - 1)
			For lngB = 0 To RndUp_Dec(CStr(Header.stSoundtracks(lngA).lngSongCount / 6))
				
				'Adds Used SongGroups
				strUsed = strUsed & " " & Header.stSoundtracks(lngA).lngGroupId(lngB)
				
			Next lngB
		Next lngA
		
		'Delimits Data
		strA = Split(strUsed, " ")
		
		'Scans for Free Song Group
		For lngA = 0 To UBound(SongGroups)
			
			For lngB = 1 To UBound(strA)
				
				'Checks if SongGroup (LngA) is used
				If lngA = CInt(strA(lngB)) Then
					
					'Items Found, So we cant use it
					GoTo NextItem
					
				End If
			Next lngB
			
			'Items not used, so use it
			FindFreeSongGroup = lngA
			Exit Function
			
NextItem: 
			
		Next lngA
		
		'Resizes Array
		ReDim Preserve SongGroups(UBound(SongGroups) + 1)
		
		'Returns New Array
		FindFreeSongGroup = UBound(SongGroups)
		
	End Function
	
	Public Function ConvertMillisecondsToTime(ByRef Milliseconds As Integer) As String
		
		'Declares Memory Varibles
		Dim CurrentHSecs As Double
		Dim HSecs As Integer
		Dim Mins As Integer
		Dim Secs As Integer
		Dim Hours As Double
		
		CurrentHSecs = Int((Milliseconds / 10) + 0.5)
		
		'Converts Stuff
		Mins = Int(CurrentHSecs / 6000)
		CurrentHSecs = CurrentHSecs - (Mins * 6000)
		Secs = Int((CurrentHSecs) / 100)
		CurrentHSecs = CurrentHSecs - (Secs * 100)
		HSecs = CurrentHSecs
		
		'Returns Information
		ConvertMillisecondsToTime = VB6.Format(Mins, "00") & ":" & VB6.Format(Secs, "00")
		
		
	End Function
	
	'UPGRADE_NOTE: TimeString was upgraded to TimeString_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Function ConvertTimeToMilliseconds(ByRef TimeString_Renamed As String, Optional ByRef IncludeHours As Boolean = False) As Integer
		
		'Declares Varibles
		Dim i As Short
		Dim Mins As Integer
		Dim Secs As Integer
		Dim HSecs As Integer
		Dim Hours As Integer
		Dim CurrentString As String
		Dim CurrentChar As String
		
		'Checks if theres Vaild String
		If TimeString_Renamed = vbNullString Then Exit Function
		
		'Sets Default Values
		Hours = -1
		Mins = -1
		Secs = -1
		HSecs = -1
		
		'Sets Storage to NULL (Nothing)
		CurrentString = vbNullString
		
		'Loops through Time String
		For i = 1 To Len(TimeString_Renamed)
			
			'Grabs One Character
			CurrentChar = Mid(TimeString_Renamed, i, 1)
			
			'Checks if : or Nothing
			If CurrentChar <> ":" And CurrentChar <> vbNullChar Then
				CurrentString = CurrentString & CurrentChar
			End If
			
			If CurrentChar = ":" Or CurrentChar = vbNullChar Or i = Len(TimeString_Renamed) Then
				
				If IncludeHours And Hours = -1 Then
					Hours = CInt(Val(CurrentString))
					CurrentString = vbNullString
				ElseIf Mins = -1 Then 
					Mins = CInt(Val(CurrentString))
					CurrentString = vbNullString
				ElseIf Secs = -1 Then 
					Secs = CInt(Val(CurrentString))
					CurrentString = vbNullString
				ElseIf HSecs = -1 Then 
					HSecs = CInt(Val(CurrentString))
					Exit For
				End If
			End If
			
		Next i
		
		'Returns Info
		ConvertTimeToMilliseconds = (HSecs * 10) + (Secs * 1000) + (Mins * 60000) + (Hours * 3600000)
	End Function
	
	Public Function FixName(ByVal StrUnicode As String) As String
		
		'Declare variables
		Dim lngA As Integer
		
		'Find double 00 character
		lngA = InStr(StrUnicode, Chr(0) & Chr(0))
		
		If lngA > 0 Then
			StrUnicode = Mid(StrUnicode, 1, lngA - 1)
		End If
		
		'Remove other 00 chracters
		StrUnicode = Replace(StrUnicode, Chr(0), "")
		
		'Return the found string
		FixName = StrUnicode
		
	End Function
	
	Public Function chk4Decimal(ByRef strInput As String) As Short
		
		'Checks for Decimals
		If InStr(1, strInput, ".") Then
			
			'Returns 1
			chk4Decimal = 1
		Else
			
			'Returns 0
			chk4Decimal = 0
		End If
		
	End Function
	
	Public Function RndUp_Dec(ByRef strInput As String) As Short
		
		'Declares Memory Variables
		Dim intOut As Short
		Dim strA() As String
		
		'Sets Default Value
		intOut = CShort(strInput)
		
		'Checks if Decimal Found
		If InStr(1, strInput, ".") Then
			
			'Sets Output Value w/ Dec Droped
			strA = Split(strInput, ".")
			
			intOut = (Int(CDbl(strA(0))))
		End If
		
		'Returns Item
		RndUp_Dec = intOut
	End Function
End Module