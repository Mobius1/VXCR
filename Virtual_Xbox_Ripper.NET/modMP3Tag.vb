Option Strict Off
Option Explicit On
Module modMP3Tag
	'MP3 Tag File Structor
	Public Structure Id3 'This type is standard for
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public Title() As Char 'Id3 Tags
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public Artist() As Char 'Although later versions
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public Album() As Char 'use comments for 28 bytes
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(4),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=4)> Public sYear() As Char 'and they use the 2 remaining  bytes for "TrackNumber"!
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public Comments() As Char
		Dim Genre As Byte
	End Structure
	
	Public id3Info As Id3 'Declare a variable as the id3 type
	Public GenreArray() As String 'we use this array to fill all the Genre's ( look in form load)
	
	Public Const sGenreMatrix As String = "Blues|Classic Rock|Country|Dance|Disco|Funk|Grunge|" & "Hip-Hop|Jazz|Metal|New Age|Oldies|Other|Pop|R&B|Rap|Reggae|Rock|Techno|" & "Industrial|Alternative|Ska|Death Metal|Pranks|Soundtrack|Euro-Techno|" & "Ambient|Trip Hop|Vocal|Jazz+Funk|Fusion|Trance|Classical|Instrumental|Acid|" & "House|Game|Sound Clip|Gospel|Noise|Alt. Rock|Bass|Soul|Punk|Space|Meditative|" & "Instrumental Pop|Instrumental Rock|Ethnic|Gothic|Darkwave|Techno-Industrial|Electronic|" & "Pop-Folk|Eurodance|Dream|Southern Rock|Comedy|Cult|Gangsta Rap|Top 40|Christian Rap|" & "Pop/Punk|Jungle|Native American|Cabaret|New Wave|Phychedelic|Rave|Showtunes|Trailer|" & "Lo-Fi|Tribal|Acid Punk|Acid Jazz|Polka|Retro|Musical|Rock & Roll|Hard Rock|Folk|" & "Folk/Rock|National Folk|Swing|Fast-Fusion|Bebob|Latin|Revival|Celtic|Blue Grass|" & "Avantegarde|Gothic Rock|Progressive Rock|Psychedelic Rock|Symphonic Rock|Slow Rock|" & "Big Band|Chorus|Easy Listening|Acoustic|Humour|Speech|Chanson|Opera|Chamber Music|" & "Sonata|Symphony|Booty Bass|Primus|Porn Groove|Satire|Slow Jam|Club|Tango|Samba|Folklore|" & "Ballad|power Ballad|Rhythmic Soul|Freestyle|Duet|Punk Rock|Drum Solo|A Capella|Euro-House|" & "Dance Hall|Goa|Drum & Bass|Club-House|Hardcore|Terror|indie|Brit Pop|Negerpunk|Polsk Punk|" & "Beat|Christian Gangsta Rap|Heavy Metal|Black Metal|Crossover|Comteporary Christian|" & "Christian Rock|Merengue|Salsa|Trash Metal|Anime|JPop|Synth Pop"
	
	Public Function GetId3(ByRef Filename As String) As String
		On Error GoTo ErrHnd
		
		'Declares Memory Values
		Dim TaG As New VB6.FixedLengthString(3)
		
		'Removes Double \
		Filename = Replace(Filename, "\\", "\")
		
		'Opens File
		FileOpen(111, Filename, OpenMode.Binary)
		
		'Reads File
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(111, TaG.Value, FileLen(Filename) - 127)
		
		If TaG.Value = "TAG" Then
			
			'Reads File
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(111, id3Info, FileLen(Filename) - 124)
		Else
			
			GetId3 = "ERROR"
			
			'Closes File
			FileClose(1)
			
			Exit Function
			
		End If
		
ErrHnd: 
		
		'Closes File
		FileClose(111)
		
		Select Case VXCRSettings.intIDStuff
			
			'Title (from IDTag)
			Case 2
				GetId3 = RemoveLeftChrs(Trim(id3Info.Title), 0)
				
				'Artist - Title (from IDTag)
			Case 3
				GetId3 = RemoveLeftChrs(Trim(id3Info.Artist), 0) & " - " & RemoveLeftChrs(Trim(id3Info.Title), 0)
				
		End Select
		
		
		
		'GetId3 = Replace(Trim(id3Info.Artist) & " - " & Trim(id3Info.Title), Chr(32), "")
		'Debug.Print RemoveLeftChrs(Trim(id3Info.Artist), 0) & " - " & RemoveLeftChrs(Trim(id3Info.Title), 0)
	End Function
	
	Public Function SaveId3(ByRef Filename As String, ByRef Mp3Info As Id3) As Object
		Dim TaG As New VB6.FixedLengthString(3) ' We use this variable to make sure the file has an ID3TAG
		FileOpen(1, Filename, OpenMode.Binary) ' we open the file as binary for total control (we need it for the Genre part)
		'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		FileGet(1, TaG.Value, FileLen(Filename) - 127) ' Id3 tags are at the end of the mp3 file(and as the type shows it is 128 bytes)
		If TaG.Value = "TAG" Then ' "TAG" is put at position filesize-127 to show that this file indeed contains an Id3
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, Mp3Info, FileLen(Filename) - 124) ' if the file has a tag, we put our new information in the file
		Else
			'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FilePut(1, "TAG", FileLen(Filename) - 127) ' else we put the "TAG" there first,
			FileClose(1)
			Call SaveId3(Filename, Mp3Info) ' then we call this function again so we fill the info this time
		End If
		FileClose(1) ' close the file
		' Remember when filling the Mp3info variable
		' set the genre part to the number corresponding to the Genre
		' it will save it as 1 byte
	End Function
	
	Public Function CheckVaildID(ByRef strInput As String) As Boolean
		
		'Declares Memory Varibles
		Dim intA As Short
		Dim intB As Short
		
		'Default Value
		CheckVaildID = True
		
		For intA = 1 To Len(strInput)
			
			'Reads 1 Byte from String (Output ASCII)
			intB = Asc(Mid(strInput, intA, 1))
			
			'Checks if Only String
			If intB <= 32 And intB >= 126 Then
				
				'Returns this is a Bad Name
				CheckVaildID = False
			End If
			
		Next intA
		
	End Function
	
	Public Function RemoveLeftChrs(ByRef strInput As String, ByRef ASCII As Short) As String
		On Error GoTo ErrHnd
		
		Dim strB As String
		
		strB = Trim(strInput)
		
		Do Until Asc(Right(strB, 1)) <> ASCII
			System.Windows.Forms.Application.DoEvents()
			
			strB = Left(strB, Len(strB) - 1)
		Loop 
		
ErrHnd: 
		RemoveLeftChrs = Replace(strB, vbCrLf, "")
		
	End Function
End Module