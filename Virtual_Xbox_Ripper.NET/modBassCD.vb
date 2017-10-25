Option Strict Off
Option Explicit On
Module modBassCD
	
	' BASSCD 2.0 Visual Basic API Header File
	' Requires BASS.DLL & BASS.BAS 2.0 - available @ www.un4seen.com
	' --------------------------------------------------------------
	' See the BASSCD.CHM file for more complete documentation
	
	' Additional error codes returned by BASS_ErrorGetCode
	Public Const BASS_ERROR_NOCD As Short = 12 ' no CD in drive
	Public Const BASS_ERROR_CDTRACK As Short = 13 ' invalid track number
	Public Const BASS_ERROR_NOTAUDIO As Short = 17 ' not an audio track
	
	Structure BASS_CD_INFO
		Dim size As Integer 'size of this struct (set this before calling the function)
		Dim rwflags As Integer 'read/write capability flags
		Dim canopen As Integer 'BASS_CD_DOOR_OPEN/CLOSE is supported?
		Dim canlock As Integer 'BASS_CD_DOOR_LOCK/UNLOCK is supported?
		Dim maxspeed As Integer 'max read speed (KB/s)
		Dim cache As Integer 'cache size (KB)
	End Structure
	
	' "rwflag" read capability flags
	Public Const BASS_CD_RWFLAG_READCDR As Short = 1
	Public Const BASS_CD_RWFLAG_READCDRW As Short = 2
	Public Const BASS_CD_RWFLAG_READCDRW2 As Short = 4
	Public Const BASS_CD_RWFLAG_READDVD As Short = 8
	Public Const BASS_CD_RWFLAG_READDVDR As Short = 16
	Public Const BASS_CD_RWFLAG_READDVDRAM As Short = 32
	Public Const BASS_CD_RWFLAG_READANALOG As Integer = &H10000
	Public Const BASS_CD_RWFLAG_READM2F1 As Integer = &H100000
	Public Const BASS_CD_RWFLAG_READM2F2 As Integer = &H200000
	Public Const BASS_CD_RWFLAG_READMULTI As Integer = &H400000
	Public Const BASS_CD_RWFLAG_READCDDA As Integer = &H1000000
	Public Const BASS_CD_RWFLAG_READCDDASIA As Integer = &H2000000
	Public Const BASS_CD_RWFLAG_READSUBCHAN As Integer = &H4000000
	Public Const BASS_CD_RWFLAG_READSUBCHANDI As Integer = &H8000000
	Public Const BASS_CD_RWFLAG_READUPC As Integer = &H40000000
	
	Public Const BASS_CD_FREEOLD As Integer = &H10000
	Public Const BASS_CD_SUBCHANNEL As Integer = &H20000
	
	' additional CD sync type
	Public Const BASS_SYNC_CD_ERROR As Short = 1000
	
	' BASS_CD_Door actions
	Public Const BASS_CD_DOOR_CLOSE As Short = 0
	Public Const BASS_CD_DOOR_OPEN As Short = 1
	Public Const BASS_CD_DOOR_LOCK As Short = 2
	Public Const BASS_CD_DOOR_UNLOCK As Short = 3
	
	' BASS_CD_GetID flags
	Public Const BASS_CDID_UPC As Short = 1
	Public Const BASS_CDID_CDDB As Short = 2
	Public Const BASS_CDID_CDDB2 As Short = 3
	Public Const BASS_CDID_TEXT As Short = 4
	Public Const BASS_CDID_CDPLAYER As Short = 5
	
	' BASS_CHANNELINFO type
	Public Const BASS_CHANNEL_STREAM_CD As Integer = &H10200
	
	
	Declare Function BASS_CD_GetDriveDescription Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_GetDriveLetter Lib "basscd.dll" (ByVal drive As Integer) As Integer
	'UPGRADE_WARNING: Structure BASS_CD_INFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_CD_GetInfo Lib "basscd.dll" (ByVal drive As Integer, ByRef info As BASS_CD_INFO) As Integer
	Declare Function BASS_CD_Door Lib "basscd.dll" (ByVal drive As Integer, ByVal action As Integer) As Integer
	Declare Function BASS_CD_DoorIsLocked Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_DoorIsOpen Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_IsReady Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_GetTracks Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_GetTrackLength Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer) As Integer
	Declare Function BASS_CD_GetID Lib "basscd.dll" (ByVal drive As Integer, ByVal id As Integer) As Integer
	Declare Function BASS_CD_Release Lib "basscd.dll" (ByVal drive As Integer) As Integer
	
	Declare Function BASS_CD_StreamCreate Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_CD_StreamCreateFile Lib "basscd.dll" (ByVal f As String, ByVal flags As Integer) As Integer
	Declare Function BASS_CD_StreamGetTrack Lib "basscd.dll" (ByVal handle As Integer) As Integer
	
	Declare Function BASS_CD_Analog_Play Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer, ByVal pos As Integer) As Integer
	Declare Function BASS_CD_Analog_PlayFile Lib "basscd.dll" (ByVal f As String, ByVal pos As Integer) As Integer
	Declare Function BASS_CD_Analog_Stop Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_Analog_IsActive Lib "basscd.dll" (ByVal drive As Integer) As Integer
	Declare Function BASS_CD_Analog_GetPosition Lib "basscd.dll" (ByVal drive As Integer) As Integer
End Module