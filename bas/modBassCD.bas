Attribute VB_Name = "modBassCD"

' BASSCD 2.0 Visual Basic API Header File
' Requires BASS.DLL & BASS.BAS 2.0 - available @ www.un4seen.com
' --------------------------------------------------------------
' See the BASSCD.CHM file for more complete documentation

' Additional error codes returned by BASS_ErrorGetCode
Global Const BASS_ERROR_NOCD = 12      ' no CD in drive
Global Const BASS_ERROR_CDTRACK = 13   ' invalid track number
Global Const BASS_ERROR_NOTAUDIO = 17  ' not an audio track

Type BASS_CD_INFO
    size As Long          'size of this struct (set this before calling the function)
    rwflags As Long       'read/write capability flags
    canopen As Long       'BASS_CD_DOOR_OPEN/CLOSE is supported?
    canlock As Long       'BASS_CD_DOOR_LOCK/UNLOCK is supported?
    maxspeed As Long      'max read speed (KB/s)
    cache As Long         'cache size (KB)
End Type

' "rwflag" read capability flags
Global Const BASS_CD_RWFLAG_READCDR = 1
Global Const BASS_CD_RWFLAG_READCDRW = 2
Global Const BASS_CD_RWFLAG_READCDRW2 = 4
Global Const BASS_CD_RWFLAG_READDVD = 8
Global Const BASS_CD_RWFLAG_READDVDR = 16
Global Const BASS_CD_RWFLAG_READDVDRAM = 32
Global Const BASS_CD_RWFLAG_READANALOG = &H10000
Global Const BASS_CD_RWFLAG_READM2F1 = &H100000
Global Const BASS_CD_RWFLAG_READM2F2 = &H200000
Global Const BASS_CD_RWFLAG_READMULTI = &H400000
Global Const BASS_CD_RWFLAG_READCDDA = &H1000000
Global Const BASS_CD_RWFLAG_READCDDASIA = &H2000000
Global Const BASS_CD_RWFLAG_READSUBCHAN = &H4000000
Global Const BASS_CD_RWFLAG_READSUBCHANDI = &H8000000
Global Const BASS_CD_RWFLAG_READUPC = &H40000000

Global Const BASS_CD_FREEOLD = &H10000
Global Const BASS_CD_SUBCHANNEL = &H20000

' additional CD sync type
Global Const BASS_SYNC_CD_ERROR = 1000

' BASS_CD_Door actions
Global Const BASS_CD_DOOR_CLOSE = 0
Global Const BASS_CD_DOOR_OPEN = 1
Global Const BASS_CD_DOOR_LOCK = 2
Global Const BASS_CD_DOOR_UNLOCK = 3

' BASS_CD_GetID flags
Global Const BASS_CDID_UPC = 1
Global Const BASS_CDID_CDDB = 2
Global Const BASS_CDID_CDDB2 = 3
Global Const BASS_CDID_TEXT = 4
Global Const BASS_CDID_CDPLAYER = 5

' BASS_CHANNELINFO type
Global Const BASS_CHANNEL_STREAM_CD = &H10200


Declare Function BASS_CD_GetDriveDescription Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_GetDriveLetter Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_GetInfo Lib "basscd.dll" (ByVal drive As Long, ByRef info As BASS_CD_INFO) As Long
Declare Function BASS_CD_Door Lib "basscd.dll" (ByVal drive As Long, ByVal action As Long) As Long
Declare Function BASS_CD_DoorIsLocked Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_DoorIsOpen Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_IsReady Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_GetTracks Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_GetTrackLength Lib "basscd.dll" (ByVal drive As Long, ByVal track As Long) As Long
Declare Function BASS_CD_GetID Lib "basscd.dll" (ByVal drive As Long, ByVal id As Long) As Long
Declare Function BASS_CD_Release Lib "basscd.dll" (ByVal drive As Long) As Long

Declare Function BASS_CD_StreamCreate Lib "basscd.dll" (ByVal drive As Long, ByVal track As Long, ByVal flags As Long) As Long
Declare Function BASS_CD_StreamCreateFile Lib "basscd.dll" (ByVal f As String, ByVal flags As Long) As Long
Declare Function BASS_CD_StreamGetTrack Lib "basscd.dll" (ByVal handle As Long) As Long

Declare Function BASS_CD_Analog_Play Lib "basscd.dll" (ByVal drive As Long, ByVal track As Long, ByVal pos As Long) As Long
Declare Function BASS_CD_Analog_PlayFile Lib "basscd.dll" (ByVal f As String, ByVal pos As Long) As Long
Declare Function BASS_CD_Analog_Stop Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_Analog_IsActive Lib "basscd.dll" (ByVal drive As Long) As Long
Declare Function BASS_CD_Analog_GetPosition Lib "basscd.dll" (ByVal drive As Long) As Long


