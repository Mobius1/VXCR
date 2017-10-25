Attribute VB_Name = "modMP3Tag"
'MP3 Tag File Structor
Public Type Id3                     'This type is standard for
    Title As String * 30            'Id3 Tags
    Artist As String * 30           'Although later versions
    Album As String * 30            'use comments for 28 bytes
    sYear  As String * 4            'and they use the 2 remaining  bytes for "TrackNumber"!
    Comments As String * 30
    Genre As Byte
End Type

Public id3Info As Id3                 'Declare a variable as the id3 type
Public GenreArray() As String         'we use this array to fill all the Genre's ( look in form load)

Public Const sGenreMatrix = "Blues|Classic Rock|Country|Dance|Disco|Funk|Grunge|" + _
    "Hip-Hop|Jazz|Metal|New Age|Oldies|Other|Pop|R&B|Rap|Reggae|Rock|Techno|" + _
    "Industrial|Alternative|Ska|Death Metal|Pranks|Soundtrack|Euro-Techno|" + _
    "Ambient|Trip Hop|Vocal|Jazz+Funk|Fusion|Trance|Classical|Instrumental|Acid|" + _
    "House|Game|Sound Clip|Gospel|Noise|Alt. Rock|Bass|Soul|Punk|Space|Meditative|" + _
    "Instrumental Pop|Instrumental Rock|Ethnic|Gothic|Darkwave|Techno-Industrial|Electronic|" + _
    "Pop-Folk|Eurodance|Dream|Southern Rock|Comedy|Cult|Gangsta Rap|Top 40|Christian Rap|" + _
    "Pop/Punk|Jungle|Native American|Cabaret|New Wave|Phychedelic|Rave|Showtunes|Trailer|" + _
    "Lo-Fi|Tribal|Acid Punk|Acid Jazz|Polka|Retro|Musical|Rock & Roll|Hard Rock|Folk|" + _
    "Folk/Rock|National Folk|Swing|Fast-Fusion|Bebob|Latin|Revival|Celtic|Blue Grass|" + _
    "Avantegarde|Gothic Rock|Progressive Rock|Psychedelic Rock|Symphonic Rock|Slow Rock|" + _
    "Big Band|Chorus|Easy Listening|Acoustic|Humour|Speech|Chanson|Opera|Chamber Music|" + _
    "Sonata|Symphony|Booty Bass|Primus|Porn Groove|Satire|Slow Jam|Club|Tango|Samba|Folklore|" + _
    "Ballad|power Ballad|Rhythmic Soul|Freestyle|Duet|Punk Rock|Drum Solo|A Capella|Euro-House|" + _
    "Dance Hall|Goa|Drum & Bass|Club-House|Hardcore|Terror|indie|Brit Pop|Negerpunk|Polsk Punk|" + _
    "Beat|Christian Gangsta Rap|Heavy Metal|Black Metal|Crossover|Comteporary Christian|" + _
    "Christian Rock|Merengue|Salsa|Trash Metal|Anime|JPop|Synth Pop"

Public Function GetId3(Filename As String) As String
    On Error GoTo ErrHnd:
    
    'Declares Memory Values
    Dim TaG As String * 3
    
    'Removes Double \
    Filename = Replace(Filename, "\\", "\")
    
    'Opens File
    Open Filename For Binary As #111
    
    'Reads File
    Get #111, FileLen(Filename) - 127, TaG
    
    If TaG = "TAG" Then
        
        'Reads File
        Get #111, FileLen(Filename) - 124, id3Info
      Else
      
        GetId3 = "ERROR"
        
        'Closes File
        Close #1
    
        Exit Function
 
    End If
    
ErrHnd:

    'Closes File
    Close #111
    
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

Public Function SaveId3(Filename As String, Mp3Info As Id3)
Dim TaG As String * 3               ' We use this variable to make sure the file has an ID3TAG
Open Filename For Binary As #1      ' we open the file as binary for total control (we need it for the Genre part)
Get #1, FileLen(Filename) - 127, TaG    ' Id3 tags are at the end of the mp3 file(and as the type shows it is 128 bytes)
If TaG = "TAG" Then                     ' "TAG" is put at position filesize-127 to show that this file indeed contains an Id3
Put #1, FileLen(Filename) - 124, Mp3Info    ' if the file has a tag, we put our new information in the file
Else
Put #1, FileLen(Filename) - 127, "TAG"      ' else we put the "TAG" there first,
Close #1
Call SaveId3(Filename, Mp3Info)                               ' then we call this function again so we fill the info this time
End If
Close #1                                            ' close the file
' Remember when filling the Mp3info variable
' set the genre part to the number corresponding to the Genre
' it will save it as 1 byte
End Function

Public Function CheckVaildID(strInput As String) As Boolean
    
    'Declares Memory Varibles
    Dim intA As Integer
    Dim intB As Integer
    
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

Public Function RemoveLeftChrs(strInput As String, ASCII As Integer) As String
    On Error GoTo ErrHnd
    
    Dim strB As String
    
    strB = Trim(strInput)
    
    Do Until Asc(Right(strB, 1)) <> ASCII
        DoEvents
        
        strB = Left(strB, Len(strB) - 1)
    Loop
        
ErrHnd:
    RemoveLeftChrs = Replace(strB, vbCrLf, "")
    
End Function
