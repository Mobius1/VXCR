Option Strict Off
Option Explicit On
Module modBass
	'BASS 2.0 Multimedia Library
	'----------------------------
	'(c) 1999-2003 Ian Luck.
	'Please report bugs/suggestions/etc... to bass@un4seen.com
	
	'See the BASS.CHM file for detailed documentation
	
	'NOTE: VB does not support 64-bit integers, so VB users only have access
	'      to the low 32-bits of 64-bit return values. 64-bit parameters can
	'      be specified though, using the "64" version of the function.
	
	'NOTE: Use the VBStrFromAnsiPtr function to convert "char *" to VB "String".
	
	Public Const BASSTRUE As Integer = 1 'Use this instead of VB Booleans
	Public Const BASSFALSE As Integer = 0 'Use this instead of VB Booleans
	
	'***********************************************
	'* Error codes returned by BASS_ErrorGetCode() *
	'***********************************************
	Public Const BASS_OK As Short = 0 'all is OK
	Public Const BASS_ERROR_MEM As Short = 1 'memory error
	Public Const BASS_ERROR_FILEOPEN As Short = 2 'can't open the file
	Public Const BASS_ERROR_DRIVER As Short = 3 'can't find a free sound driver
	Public Const BASS_ERROR_BUFLOST As Short = 4 'the sample buffer was lost
	Public Const BASS_ERROR_HANDLE As Short = 5 'invalid handle
	Public Const BASS_ERROR_FORMAT As Short = 6 'unsupported sample format
	Public Const BASS_ERROR_POSITION As Short = 7 'invalid playback position
	Public Const BASS_ERROR_INIT As Short = 8 'BASS_Init has not been successfully called
	Public Const BASS_ERROR_START As Short = 9 'BASS_Start has not been successfully called
	Public Const BASS_ERROR_ALREADY As Short = 14 'already initialized
	Public Const BASS_ERROR_NOPAUSE As Short = 16 'not paused
	Public Const BASS_ERROR_NOTAUDIO As Short = 17 'not an audio track
	Public Const BASS_ERROR_NOCHAN As Short = 18 'can't get a free channel
	Public Const BASS_ERROR_ILLTYPE As Short = 19 'an illegal type was specified
	Public Const BASS_ERROR_ILLPARAM As Short = 20 'an illegal parameter was specified
	Public Const BASS_ERROR_NO3D As Short = 21 'no 3D support
	Public Const BASS_ERROR_NOEAX As Short = 22 'no EAX support
	Public Const BASS_ERROR_DEVICE As Short = 23 'illegal device number
	Public Const BASS_ERROR_NOPLAY As Short = 24 'not playing
	Public Const BASS_ERROR_FREQ As Short = 25 'illegal sample rate
	Public Const BASS_ERROR_NOTFILE As Short = 27 'the stream is not a file stream
	Public Const BASS_ERROR_NOHW As Short = 29 'no hardware voices available
	Public Const BASS_ERROR_EMPTY As Short = 31 'the MOD music has no sequence data
	Public Const BASS_ERROR_NONET As Short = 32 'no internet connection could be opened
	Public Const BASS_ERROR_CREATE As Short = 33 'couldn't create the file
	Public Const BASS_ERROR_NOFX As Short = 34 'effects are not available
	Public Const BASS_ERROR_PLAYING As Short = 35 'the channel is playing
	Public Const BASS_ERROR_NOTAVAIL As Short = 37 'requested data is not available
	Public Const BASS_ERROR_DECODE As Short = 38 'the channel is a "decoding channel"
	Public Const BASS_ERROR_DX As Short = 39 'a sufficient DirectX version is not installed
	Public Const BASS_ERROR_TIMEOUT As Short = 40 'connection timedout
	Public Const BASS_ERROR_FILEFORM As Short = 41 'unsupported file format
	Public Const BASS_ERROR_SPEAKER As Short = 42 'unavailable speaker
	Public Const BASS_ERROR_UNKNOWN As Short = -1 'some other mystery error
	
	'************************
	'* Initialization flags *
	'************************
	Public Const BASS_DEVICE_8BITS As Short = 1 'use 8 bit resolution, else 16 bit
	Public Const BASS_DEVICE_MONO As Short = 2 'use mono, else stereo
	Public Const BASS_DEVICE_3D As Short = 4 'enable 3D functionality
	' If the BASS_DEVICE_3D flag is not specified when initilizing BASS,
	' then the 3D flags (BASS_SAMPLE_3D and BASS_MUSIC_3D) are ignored when
	' loading/creating a sample/stream/music.
	Public Const BASS_DEVICE_LATENCY As Short = 256 'calculate device latency (BASS_INFO struct)
	Public Const BASS_DEVICE_SPEAKERS As Short = 2048 'force enabling of speaker assignment
	
	'***********************************
	'* BASS_INFO flags (from DSOUND.H) *
	'***********************************
	Public Const DSCAPS_CONTINUOUSRATE As Short = 16
	' supports all sample rates between min/maxrate
	Public Const DSCAPS_EMULDRIVER As Short = 32
	' device does NOT have hardware DirectSound support
	Public Const DSCAPS_CERTIFIED As Short = 64
	' device driver has been certified by Microsoft
	' The following flags tell what type of samples are supported by HARDWARE
	' mixing, all these formats are supported by SOFTWARE mixing
	Public Const DSCAPS_SECONDARYMONO As Short = 256 ' mono
	Public Const DSCAPS_SECONDARYSTEREO As Short = 512 ' stereo
	Public Const DSCAPS_SECONDARY8BIT As Short = 1024 ' 8 bit
	Public Const DSCAPS_SECONDARY16BIT As Short = 2048 ' 16 bit
	
	'*****************************************
	'* BASS_RECORDINFO flags (from DSOUND.H) *
	'*****************************************
	Public Const DSCCAPS_EMULDRIVER As Short = DSCAPS_EMULDRIVER
	' device does NOT have hardware DirectSound recording support
	Public Const DSCCAPS_CERTIFIED As Short = DSCAPS_CERTIFIED
	' device driver has been certified by Microsoft
	
	'******************************************************************
	'* defines for formats field of BASS_RECORDINFO (from MMSYSTEM.H) *
	'******************************************************************
	Public Const WAVE_FORMAT_1M08 As Short = &H1s ' 11.025 kHz, Mono,   8-bit
	Public Const WAVE_FORMAT_1S08 As Short = &H2s ' 11.025 kHz, Stereo, 8-bit
	Public Const WAVE_FORMAT_1M16 As Short = &H4s ' 11.025 kHz, Mono,   16-bit
	Public Const WAVE_FORMAT_1S16 As Short = &H8s ' 11.025 kHz, Stereo, 16-bit
	Public Const WAVE_FORMAT_2M08 As Short = &H10s ' 22.05  kHz, Mono,   8-bit
	Public Const WAVE_FORMAT_2S08 As Short = &H20s ' 22.05  kHz, Stereo, 8-bit
	Public Const WAVE_FORMAT_2M16 As Short = &H40s ' 22.05  kHz, Mono,   16-bit
	Public Const WAVE_FORMAT_2S16 As Short = &H80s ' 22.05  kHz, Stereo, 16-bit
	Public Const WAVE_FORMAT_4M08 As Short = &H100s ' 44.1   kHz, Mono,   8-bit
	Public Const WAVE_FORMAT_4S08 As Short = &H200s ' 44.1   kHz, Stereo, 8-bit
	Public Const WAVE_FORMAT_4M16 As Short = &H400s ' 44.1   kHz, Mono,   16-bit
	Public Const WAVE_FORMAT_4S16 As Short = &H800s ' 44.1   kHz, Stereo, 16-bit
	
	'*********************
	'* Sample info flags *
	'*********************
	Public Const BASS_SAMPLE_8BITS As Short = 1 ' 8 bit
	Public Const BASS_SAMPLE_FLOAT As Short = 256 ' 32-bit floating-point
	Public Const BASS_SAMPLE_MONO As Short = 2 ' mono, else stereo
	Public Const BASS_SAMPLE_LOOP As Short = 4 ' looped
	Public Const BASS_SAMPLE_3D As Short = 8 ' 3D functionality enabled
	Public Const BASS_SAMPLE_SOFTWARE As Short = 16 ' it's NOT using hardware mixing
	Public Const BASS_SAMPLE_MUTEMAX As Short = 32 ' muted at max distance (3D only)
	Public Const BASS_SAMPLE_VAM As Short = 64 ' uses the DX7 voice allocation & management
	Public Const BASS_SAMPLE_FX As Short = 128 ' old implementation of DX8 effects are enabled
	Public Const BASS_SAMPLE_OVER_VOL As Integer = 65536 ' override lowest volume
	Public Const BASS_SAMPLE_OVER_POS As Integer = 131072 ' override longest playing
	Public Const BASS_SAMPLE_OVER_DIST As Integer = 196608 ' override furthest from listener (3D only)
	
	Public Const BASS_MP3_SETPOS As Integer = 131072 ' enable pin-point seeking on the MP3/MP2/MP1
	
	Public Const BASS_STREAM_AUTOFREE As Integer = 262144 ' automatically free the stream when it stop/ends
	Public Const BASS_STREAM_RESTRATE As Integer = 524288 ' restrict the download rate of internet file streams
	Public Const BASS_STREAM_BLOCK As Integer = 1048576 ' download/play internet file stream (MPx/OGG) in small blocks
	Public Const BASS_STREAM_DECODE As Integer = &H200000 ' don't play the stream, only decode (BASS_ChannelGetData)
	Public Const BASS_STREAM_META As Integer = &H400000 ' request metadata from a Shoutcast stream
	Public Const BASS_STREAM_FILEPROC As Integer = &H800000 ' use a STREAMFILEPROC callback
	
	Public Const BASS_MUSIC_FLOAT As Short = BASS_SAMPLE_FLOAT ' 32-bit floating-point
	Public Const BASS_MUSIC_MONO As Short = BASS_SAMPLE_MONO ' force mono mixing (less CPU usage)
	Public Const BASS_MUSIC_LOOP As Short = BASS_SAMPLE_LOOP ' loop music
	Public Const BASS_MUSIC_3D As Short = BASS_SAMPLE_3D ' enable 3D functionality
	Public Const BASS_MUSIC_FX As Short = BASS_SAMPLE_FX ' enable old implementation of DX8 effects
	Public Const BASS_MUSIC_AUTOFREE As Integer = BASS_STREAM_AUTOFREE ' automatically free the music when it stop/ends
	Public Const BASS_MUSIC_DECODE As Integer = BASS_STREAM_DECODE ' don't play the music, only decode (BASS_ChannelGetData)
	Public Const BASS_MUSIC_RAMP As Short = &H200s ' normal ramping
	Public Const BASS_MUSIC_RAMPS As Short = &H400s ' sensitive ramping
	Public Const BASS_MUSIC_SURROUND As Short = &H800s ' surround sound
	Public Const BASS_MUSIC_SURROUND2 As Short = &H1000s ' surround sound (mode 2)
	Public Const BASS_MUSIC_FT2MOD As Short = &H2000s ' play .MOD as FastTracker 2 does
	Public Const BASS_MUSIC_PT1MOD As Short = &H4000s ' play .MOD as ProTracker 1 does
	Public Const BASS_MUSIC_CALCLEN As Integer = 32768 ' calculate playback length
	Public Const BASS_MUSIC_NONINTER As Integer = &H10000 ' non-interpolated mixing
	Public Const BASS_MUSIC_POSRESET As Integer = &H20000 ' stop all notes when moving position
	Public Const BASS_MUSIC_STOPBACK As Integer = &H80000 ' stop the music on a backwards jump effect
	Public Const BASS_MUSIC_NOSAMPLE As Integer = &H100000 ' don't load the samples
	
	' Speaker assignment flags
	Public Const BASS_SPEAKER_FRONT As Integer = &H1000000 ' front speakers
	Public Const BASS_SPEAKER_REAR As Integer = &H2000000 ' rear/side speakers
	Public Const BASS_SPEAKER_CENLFE As Integer = &H3000000 ' center & LFE speakers (5.1)
	Public Const BASS_SPEAKER_REAR2 As Integer = &H4000000 ' rear center speakers (7.1)
	Public Const BASS_SPEAKER_LEFT As Integer = &H10000000 ' modifier: left
	Public Const BASS_SPEAKER_RIGHT As Integer = &H20000000 ' modifier: right
	Public Const BASS_SPEAKER_FRONTLEFT As Boolean = BASS_SPEAKER_FRONT Or BASS_SPEAKER_LEFT
	Public Const BASS_SPEAKER_FRONTRIGHT As Boolean = BASS_SPEAKER_FRONT Or BASS_SPEAKER_RIGHT
	Public Const BASS_SPEAKER_REARLEFT As Boolean = BASS_SPEAKER_REAR Or BASS_SPEAKER_LEFT
	Public Const BASS_SPEAKER_REARRIGHT As Boolean = BASS_SPEAKER_REAR Or BASS_SPEAKER_RIGHT
	Public Const BASS_SPEAKER_CENTER As Boolean = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_LEFT
	Public Const BASS_SPEAKER_LFE As Boolean = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_RIGHT
	Public Const BASS_SPEAKER_REAR2LEFT As Boolean = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_LEFT
	Public Const BASS_SPEAKER_REAR2RIGHT As Boolean = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_RIGHT
	
	Public Const BASS_UNICODE As Integer = &H80000000
	
	Public Const BASS_RECORD_PAUSE As Integer = 32768 ' start recording paused
	
	'**********************************************
	'* BASS_StreamGetTags flags : what's returned *
	'**********************************************
	Public Const BASS_TAG_ID3 As Short = 0 'ID3v1 tags : 128 byte block
	Public Const BASS_TAG_ID3V2 As Short = 1 'ID3v2 tags : variable length block
	Public Const BASS_TAG_OGG As Short = 2 'OGG comments : array of null-terminated strings
	Public Const BASS_TAG_HTTP As Short = 3 'HTTP headers : array of null-terminated strings
	Public Const BASS_TAG_ICY As Short = 4 'ICY headers : array of null-terminated strings
	Public Const BASS_TAG_META As Short = 5 'ICY metadata : null-terminated string
	
	'********************
	'* 3D channel modes *
	'********************
	Public Const BASS_3DMODE_NORMAL As Short = 0
	' normal 3D processing
	Public Const BASS_3DMODE_RELATIVE As Short = 1
	' The channel's 3D position (position/velocity/orientation) are relative to
	' the listener. When the listener's position/velocity/orientation is changed
	' with BASS_Set3DPosition, the channel's position relative to the listener does
	' not change.
	Public Const BASS_3DMODE_OFF As Short = 2
	' Turn off 3D processing on the channel, the sound will be played
	' in the center.
	
	'****************************************************
	'* EAX environments, use with BASS_SetEAXParameters *
	'****************************************************
	Public Const EAX_ENVIRONMENT_GENERIC As Short = 0
	Public Const EAX_ENVIRONMENT_PADDEDCELL As Short = 1
	Public Const EAX_ENVIRONMENT_ROOM As Short = 2
	Public Const EAX_ENVIRONMENT_BATHROOM As Short = 3
	Public Const EAX_ENVIRONMENT_LIVINGROOM As Short = 4
	Public Const EAX_ENVIRONMENT_STONEROOM As Short = 5
	Public Const EAX_ENVIRONMENT_AUDITORIUM As Short = 6
	Public Const EAX_ENVIRONMENT_CONCERTHALL As Short = 7
	Public Const EAX_ENVIRONMENT_CAVE As Short = 8
	Public Const EAX_ENVIRONMENT_ARENA As Short = 9
	Public Const EAX_ENVIRONMENT_HANGAR As Short = 10
	Public Const EAX_ENVIRONMENT_CARPETEDHALLWAY As Short = 11
	Public Const EAX_ENVIRONMENT_HALLWAY As Short = 12
	Public Const EAX_ENVIRONMENT_STONECORRIDOR As Short = 13
	Public Const EAX_ENVIRONMENT_ALLEY As Short = 14
	Public Const EAX_ENVIRONMENT_FOREST As Short = 15
	Public Const EAX_ENVIRONMENT_CITY As Short = 16
	Public Const EAX_ENVIRONMENT_MOUNTAINS As Short = 17
	Public Const EAX_ENVIRONMENT_QUARRY As Short = 18
	Public Const EAX_ENVIRONMENT_PLAIN As Short = 19
	Public Const EAX_ENVIRONMENT_PARKINGLOT As Short = 20
	Public Const EAX_ENVIRONMENT_SEWERPIPE As Short = 21
	Public Const EAX_ENVIRONMENT_UNDERWATER As Short = 22
	Public Const EAX_ENVIRONMENT_DRUGGED As Short = 23
	Public Const EAX_ENVIRONMENT_DIZZY As Short = 24
	Public Const EAX_ENVIRONMENT_PSYCHOTIC As Short = 25
	' total number of environments
	Public Const EAX_ENVIRONMENT_COUNT As Short = 26
	
	'**********************************************************************
	'* Sync types (with BASS_ChannelSetSync() "param" and SYNCPROC "data" *
	'* definitions) & flags.                                              *
	'**********************************************************************
	' Sync when a music or stream reaches a position.
	' if HMUSIC...
	' param: LOWORD=order (0=first, -1=all) HIWORD=row (0=first, -1=all)
	' data : LOWORD=order HIWORD=row
	' if HSTREAM...
	' param: position in bytes
	' data : not used
	Public Const BASS_SYNC_POS As Short = 0
	Public Const BASS_SYNC_MUSICPOS As Short = 0
	' Sync when an instrument (sample for the non-instrument based formats)
	' is played in a music (not including retrigs).
	' param: LOWORD=instrument (1=first) HIWORD=note (0=c0...119=b9, -1=all)
	' data : LOWORD=note HIWORD=volume (0-64)
	Public Const BASS_SYNC_MUSICINST As Short = 1
	' Sync when a music or file stream reaches the end.
	' param: not used
	' data : not used
	Public Const BASS_SYNC_END As Short = 2
	' Sync when the "sync" effect (XM/MTM/MOD: E8x/Wxx, IT/S3M: S2x) is used.
	' param: 0:data=pos, 1:data="x" value
	' data : param=0: LOWORD=order HIWORD=row, param=1: "x" value
	Public Const BASS_SYNC_MUSICFX As Short = 3
	' FLAG: post a Windows message (instead of callback)
	' When using a window message "callback", the message to post is given in the "proc"
	' parameter of BASS_ChannelSetSync, and is posted to the window specified in the BASS_Init
	' call. The message parameters are: WPARAM = data, LPARAM = user.
	Public Const BASS_SYNC_META As Short = 4
	' Sync when metadata is received in a Shoutcast stream.
	' param: not used
	' data : pointer to the metadata
	Public Const BASS_SYNC_SLIDE As Short = 5
	' Sync when an attribute slide is completed.
	' param: not used
	' data : the type of slide completed (one of the BASS_SLIDE_xxx values)
	Public Const BASS_SYNC_STALL As Short = 6
	' Sync when playback has stalled.
	' param: not used
	' data : 0=stalled, 1=resumed
	Public Const BASS_SYNC_DOWNLOAD As Short = 7
	' Sync when downloading of an internet (or "buffered" user file) stream has ended.
	' param: not used
	' data : not used
	Public Const BASS_SYNC_MESSAGE As Integer = &H20000000
	'FLAG: sync at mixtime, else at playtime
	Public Const BASS_SYNC_MIXTIME As Integer = &H40000000
	' FLAG: sync only once, else continuously
	Public Const BASS_SYNC_ONETIME As Integer = &H80000000
	
	' BASS_ChannelIsActive return values
	Public Const BASS_ACTIVE_STOPPED As Short = 0
	Public Const BASS_ACTIVE_PLAYING As Short = 1
	Public Const BASS_ACTIVE_STALLED As Short = 2
	Public Const BASS_ACTIVE_PAUSED As Short = 3
	
	' BASS_ChannelIsSliding return flags
	Public Const BASS_SLIDE_FREQ As Short = 1
	Public Const BASS_SLIDE_VOL As Short = 2
	Public Const BASS_SLIDE_PAN As Short = 4
	
	' BASS_ChannelGetData flags
	Public Const BASS_DATA_AVAILABLE As Short = 0 ' query how much data is buffered
	Public Const BASS_DATA_FFT512 As Integer = &H80000000 ' 512 sample FFT
	Public Const BASS_DATA_FFT1024 As Integer = &H80000001 ' 1024 FFT
	Public Const BASS_DATA_FFT2048 As Integer = &H80000002 ' 2048 FFT
	Public Const BASS_DATA_FFT4096 As Integer = &H80000003 ' 4096 FFT
	Public Const BASS_DATA_FFT512S As Integer = &H80000010 ' stereo 512 sample FFT
	Public Const BASS_DATA_FFT1024S As Integer = &H80000011 ' stereo 1024 FFT
	Public Const BASS_DATA_FFT2048S As Integer = &H80000012 ' stereo 2048 FFT
	Public Const BASS_DATA_FFT4096S As Integer = &H80000013 ' stereo 4096 FFT
	Public Const BASS_DATA_FFT_NOWINDOW As Short = &H20s ' FFT flag: no Hanning window
	
	' BASS_RecordSetInput flags
	Public Const BASS_INPUT_OFF As Integer = &H10000
	Public Const BASS_INPUT_ON As Integer = &H20000
	Public Const BASS_INPUT_LEVEL As Integer = &H40000
	
	Public Const BASS_INPUT_TYPE_MASK As Integer = &HFF000000
	Public Const BASS_INPUT_TYPE_UNDEF As Short = &H0s
	Public Const BASS_INPUT_TYPE_DIGITAL As Integer = &H1000000
	Public Const BASS_INPUT_TYPE_LINE As Integer = &H2000000
	Public Const BASS_INPUT_TYPE_MIC As Integer = &H3000000
	Public Const BASS_INPUT_TYPE_SYNTH As Integer = &H4000000
	Public Const BASS_INPUT_TYPE_CD As Integer = &H5000000
	Public Const BASS_INPUT_TYPE_PHONE As Integer = &H6000000
	Public Const BASS_INPUT_TYPE_SPEAKER As Integer = &H7000000
	Public Const BASS_INPUT_TYPE_WAVE As Integer = &H8000000
	Public Const BASS_INPUT_TYPE_AUX As Integer = &H9000000
	Public Const BASS_INPUT_TYPE_ANALOG As Integer = &HA000000
	
	' BASS_Set/GetConfig options
	Public Const BASS_CONFIG_BUFFER As Short = 0
	Public Const BASS_CONFIG_UPDATEPERIOD As Short = 1
	Public Const BASS_CONFIG_MAXVOL As Short = 3
	Public Const BASS_CONFIG_GVOL_SAMPLE As Short = 4
	Public Const BASS_CONFIG_GVOL_STREAM As Short = 5
	Public Const BASS_CONFIG_GVOL_MUSIC As Short = 6
	Public Const BASS_CONFIG_CURVE_VOL As Short = 7
	Public Const BASS_CONFIG_CURVE_PAN As Short = 8
	Public Const BASS_CONFIG_FLOATDSP As Short = 9
	Public Const BASS_CONFIG_3DALGORITHM As Short = 10
	Public Const BASS_CONFIG_NET_TIMEOUT As Short = 11
	Public Const BASS_CONFIG_NET_BUFFER As Short = 12
	
	' BASS_StreamGetFilePosition modes
	Public Const BASS_FILEPOS_DECODE As Short = 0
	Public Const BASS_FILEPOS_DOWNLOAD As Short = 1
	Public Const BASS_FILEPOS_END As Short = 2
	
	' STREAMFILEPROC actions
	Public Const BASS_FILE_CLOSE As Short = 0
	Public Const BASS_FILE_READ As Short = 1
	Public Const BASS_FILE_QUERY As Short = 2
	Public Const BASS_FILE_LEN As Short = 3
	
	Public Const BASS_STREAMPROC_END As Integer = &H80000000 ' end of user stream flag
	
	'**************************************************************
	'* DirectSound interfaces (for use with BASS_GetDSoundObject) *
	'**************************************************************
	Public Const BASS_OBJECT_DS As Short = 1 ' DirectSound
	Public Const BASS_OBJECT_DS3DL As Short = 2 'IDirectSound3DListener
	
	'******************************
	'* DX7 voice allocation flags *
	'******************************
	' Play the sample in hardware. If no hardware voices are available then
	' the "play" call will fail
	Public Const BASS_VAM_HARDWARE As Short = 1
	' Play the sample in software (ie. non-accelerated). No other VAM flags
	'may be used together with this flag.
	Public Const BASS_VAM_SOFTWARE As Short = 2
	
	'******************************
	'* DX7 voice management flags *
	'******************************
	' These flags enable hardware resource stealing... if the hardware has no
	' available voices, a currently playing buffer will be stopped to make room for
	' the new buffer. NOTE: only samples loaded/created with the BASS_SAMPLE_VAM
	' flag are considered for termination by the DX7 voice management.
	
	' If there are no free hardware voices, the buffer to be terminated will be
	' the one with the least time left to play.
	Public Const BASS_VAM_TERM_TIME As Short = 4
	' If there are no free hardware voices, the buffer to be terminated will be
	' one that was loaded/created with the BASS_SAMPLE_MUTEMAX flag and is beyond
	' it 's max distance. If there are no buffers that match this criteria, then the
	' "play" call will fail.
	Public Const BASS_VAM_TERM_DIST As Short = 8
	' If there are no free hardware voices, the buffer to be terminated will be
	' the one with the lowest priority.
	Public Const BASS_VAM_TERM_PRIO As Short = 16
	
	'**********************************************************************
	'* software 3D mixing algorithm modes (used with BASS_Set3DAlgorithm) *
	'**********************************************************************
	' default algorithm (currently translates to BASS_3DALG_OFF)
	Public Const BASS_3DALG_DEFAULT As Short = 0
	' Uses normal left and right panning. The vertical axis is ignored except for
	'scaling of volume due to distance. Doppler shift and volume scaling are still
	'applied, but the 3D filtering is not performed. This is the most CPU efficient
	'software implementation, but provides no virtual 3D audio effect. Head Related
	'Transfer Function processing will not be done. Since only normal stereo panning
	'is used, a channel using this algorithm may be accelerated by a 2D hardware
	'voice if no free 3D hardware voices are available.
	Public Const BASS_3DALG_OFF As Short = 1
	' This algorithm gives the highest quality 3D audio effect, but uses more CPU.
	' Requires Windows 98 2nd Edition or Windows 2000 that uses WDM drivers, if this
	' mode is not available then BASS_3DALG_OFF will be used instead.
	Public Const BASS_3DALG_FULL As Short = 2
	' This algorithm gives a good 3D audio effect, and uses less CPU than the FULL
	' mode. Requires Windows 98 2nd Edition or Windows 2000 that uses WDM drivers, if
	' this mode is not available then BASS_3DALG_OFF will be used instead.
	Public Const BASS_3DALG_LIGHT As Short = 3
	
	Structure BASS_INFO
		Dim size As Integer ' size of this struct (set this before calling the function)
		Dim flags As Integer ' device capabilities (DSCAPS_xxx flags)
		Dim hwsize As Integer ' size of total device hardware memory
		Dim hwfree As Integer ' size of free device hardware memory
		Dim freesam As Integer ' number of free sample slots in the hardware
		Dim free3d As Integer ' number of free 3D sample slots in the hardware
		Dim minrate As Integer ' min sample rate supported by the hardware
		Dim maxrate As Integer ' max sample rate supported by the hardware
		Dim eax As Integer ' device supports EAX? (always BASSFALSE if BASS_DEVICE_3D was not used)
		Dim minbuf As Integer ' recommended minimum buffer length in ms (requires BASS_DEVICE_LATENCY)
		Dim dsver As Integer ' DirectSound version
		Dim latency As Integer ' delay (in ms) before start of playback (requires BASS_DEVICE_LATENCY)
		Dim initflags As Integer ' "flags" parameter of BASS_Init call
		Dim speakers As Integer ' number of speakers available
		Dim driver As Integer ' driver
	End Structure
	
	Structure BASS_RECORDINFO
		Dim size As Integer ' size of this struct (set this before calling the function)
		Dim flags As Integer ' device capabilities (DSCCAPS_xxx flags)
		Dim formats As Integer ' supported standard formats (WAVE_FORMAT_xxx flags)
		Dim inputs As Integer ' number of inputs
		Dim singlein As Integer ' BASSTRUE = only 1 input can be set at a time
		Dim driver As Integer ' driver
	End Structure
	
	Structure BASS_SAMPLE
		Dim freq As Integer ' default playback rate
		Dim volume As Integer ' default volume (0-100)
		Dim pan As Integer ' default pan (-100=left, 0=middle, 100=right)
		Dim flags As Integer ' BASS_SAMPLE_xxx flags
		Dim length As Integer ' length (in samples, not bytes)
		Dim max As Integer ' maximum simultaneous playbacks
		' The following are the sample's default 3D attributes (if the sample
		' is 3D, BASS_SAMPLE_3D is in flags) see BASS_ChannelSet3DAttributes
		Dim mode3d As Integer ' BASS_3DMODE_xxx mode
		Dim mindist As Single ' minimum distance
		Dim MAXDIST As Single ' maximum distance
		Dim iangle As Integer ' angle of inside projection cone
		Dim oangle As Integer ' angle of outside projection cone
		Dim outvol As Integer ' delta-volume outside the projection cone
		' The following are the defaults used if the sample uses the DirectX 7
		' voice allocation/management features.
		Dim vam As Integer ' voice allocation/management flags (BASS_VAM_xxx)
		Dim priority As Integer ' priority (0=lowest, &Hffffffff=highest)
	End Structure
	
	Structure BASS_CHANNELINFO
		Dim freq As Integer ' default playback rate
		Dim chans As Integer ' channels
		Dim flags As Integer ' BASS_SAMPLE/STREAM/MUSIC/SPEAKER flags
		'UPGRADE_NOTE: ctype was upgraded to ctype_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim ctype_Renamed As Integer ' type of channel
	End Structure
	
	' BASS_CHANNELINFO types
	Public Const BASS_CTYPE_SAMPLE As Short = 1
	Public Const BASS_CTYPE_RECORD As Short = 2
	Public Const BASS_CTYPE_STREAM As Integer = &H10000
	Public Const BASS_CTYPE_STREAM_WAV As Integer = &H10001
	Public Const BASS_CTYPE_STREAM_OGG As Integer = &H10002
	Public Const BASS_CTYPE_STREAM_MP1 As Integer = &H10003
	Public Const BASS_CTYPE_STREAM_MP2 As Integer = &H10004
	Public Const BASS_CTYPE_STREAM_MP3 As Integer = &H10005
	Public Const BASS_CTYPE_MUSIC_MOD As Integer = &H20000
	Public Const BASS_CTYPE_MUSIC_MTM As Integer = &H20001
	Public Const BASS_CTYPE_MUSIC_S3M As Integer = &H20002
	Public Const BASS_CTYPE_MUSIC_XM As Integer = &H20003
	Public Const BASS_CTYPE_MUSIC_IT As Integer = &H20004
	Public Const BASS_CTYPE_MUSIC_MO3 As Short = &H100s ' mo3 flag
	
	'********************************************************
	'* 3D vector (for 3D positions/velocities/orientations) *
	'********************************************************
	Structure BASS_3DVECTOR
		Dim X As Single ' +=right, -=left
		Dim Y As Single ' +=up, -=down
		Dim z As Single ' +=front, -=behind
	End Structure
	
	' DX8 effect types, use with BASS_ChannelSetFX
	Public Const BASS_FX_CHORUS As Short = 0 ' GUID_DSFX_STANDARD_CHORUS
	Public Const BASS_FX_COMPRESSOR As Short = 1 ' GUID_DSFX_STANDARD_COMPRESSOR
	Public Const BASS_FX_DISTORTION As Short = 2 ' GUID_DSFX_STANDARD_DISTORTION
	Public Const BASS_FX_ECHO As Short = 3 ' GUID_DSFX_STANDARD_ECHO
	Public Const BASS_FX_FLANGER As Short = 4 ' GUID_DSFX_STANDARD_FLANGER
	Public Const BASS_FX_GARGLE As Short = 5 ' GUID_DSFX_STANDARD_GARGLE
	Public Const BASS_FX_I3DL2REVERB As Short = 6 ' GUID_DSFX_STANDARD_I3DL2REVERB
	Public Const BASS_FX_PARAMEQ As Short = 7 ' GUID_DSFX_STANDARD_PARAMEQ
	Public Const BASS_FX_REVERB As Short = 8 ' GUID_DSFX_WAVES_REVERB
	
	Structure BASS_FXCHORUS ' DSFXChorus
		Dim fWetDryMix As Single
		Dim fDepth As Single
		Dim fFeedback As Single
		Dim fFrequency As Single
		Dim lWaveform As Integer ' 0=triangle, 1=sine
		Dim fDelay As Single
		Dim lPhase As Integer ' BASS_FX_PHASE_xxx
	End Structure
	
	Structure BASS_FXCOMPRESSOR ' DSFXCompressor
		Dim fGain As Single
		Dim fAttack As Single
		Dim fRelease As Single
		Dim fThreshold As Single
		Dim fRatio As Single
		Dim fPredelay As Single
	End Structure
	
	Structure BASS_FXDISTORTION ' DSFXDistortion
		Dim fGain As Single
		Dim fEdge As Single
		Dim fPostEQCenterFrequency As Single
		Dim fPostEQBandwidth As Single
		Dim fPreLowpassCutoff As Single
	End Structure
	
	Structure BASS_FXECHO ' DSFXEcho
		Dim fWetDryMix As Single
		Dim fFeedback As Single
		Dim fLeftDelay As Single
		Dim fRightDelay As Single
		Dim lPanDelay As Integer
	End Structure
	
	Structure BASS_FXFLANGER ' DSFXFlanger
		Dim fWetDryMix As Single
		Dim fDepth As Single
		Dim fFeedback As Single
		Dim fFrequency As Single
		Dim lWaveform As Integer ' 0=triangle, 1=sine
		Dim fDelay As Single
		Dim lPhase As Integer ' BASS_FX_PHASE_xxx
	End Structure
	
	Structure BASS_FXGARGLE ' DSFXGargle
		Dim dwRateHz As Integer ' Rate of modulation in hz
		Dim dwWaveShape As Integer ' 0=triangle, 1=square
	End Structure
	
	Structure BASS_FXI3DL2REVERB ' DSFXI3DL2Reverb
		Dim lRoom As Integer ' [-10000, 0]      default: -1000 mB
		Dim lRoomHF As Integer ' [-10000, 0]      default: 0 mB
		Dim flRoomRolloffFactor As Single ' [0.0, 10.0]      default: 0.0
		Dim flDecayTime As Single ' [0.1, 20.0]      default: 1.49s
		Dim flDecayHFRatio As Single ' [0.1, 2.0]       default: 0.83
		Dim lReflections As Integer ' [-10000, 1000]   default: -2602 mB
		Dim flReflectionsDelay As Single ' [0.0, 0.3]       default: 0.007 s
		Dim lReverb As Integer ' [-10000, 2000]   default: 200 mB
		Dim flReverbDelay As Single ' [0.0, 0.1]       default: 0.011 s
		Dim flDiffusion As Single ' [0.0, 100.0]     default: 100.0 %
		Dim flDensity As Single ' [0.0, 100.0]     default: 100.0 %
		Dim flHFReference As Single ' [20.0, 20000.0]  default: 5000.0 Hz
	End Structure
	
	Structure BASS_FXPARAMEQ ' DSFXParamEq
		Dim fCenter As Single
		Dim fBandwidth As Single
		Dim fGain As Single
	End Structure
	
	Structure BASS_FXREVERB ' DSFXWavesReverb
		Dim fInGain As Single ' [-96.0,0.0]            default: 0.0 dB
		Dim fReverbMix As Single ' [-96.0,0.0]            default: 0.0 db
		Dim fReverbTime As Single ' [0.001,3000.0]         default: 1000.0 ms
		Dim fHighFreqRTRatio As Single ' [0.001,0.999]          default: 0.001
	End Structure
	
	Public Const BASS_FX_PHASE_NEG_180 As Short = 0
	Public Const BASS_FX_PHASE_NEG_90 As Short = 1
	Public Const BASS_FX_PHASE_ZERO As Short = 2
	Public Const BASS_FX_PHASE_90 As Short = 3
	Public Const BASS_FX_PHASE_180 As Short = 4
	
	Structure GUID ' used with BASS_Init - use VarPtr(guid) in clsid parameter
		Dim Data1 As Integer
		Dim Data2 As Short
		Dim Data3 As Short
		<VBFixedArray(7)> Dim Data4() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim Data4(7)
		End Sub
	End Structure
	
	
	Declare Function BASS_SetConfig Lib "bass.dll" (ByVal opt As Integer, ByVal value As Integer) As Integer
	Declare Function BASS_GetConfig Lib "bass.dll" (ByVal opt As Integer) As Integer
	Declare Function BASS_GetVersion Lib "bass.dll" () As Integer
	Declare Function BASS_GetDeviceDescription Lib "bass.dll" (ByVal device As Integer) As Integer
	Declare Function BASS_ErrorGetCode Lib "bass.dll" () As Integer
	Declare Function BASS_Init Lib "bass.dll" (ByVal device As Integer, ByVal freq As Integer, ByVal flags As Integer, ByVal win As Integer, ByVal clsid As Integer) As Integer
	Declare Function BASS_SetDevice Lib "bass.dll" (ByVal device As Integer) As Integer
	Declare Function BASS_GetDevice Lib "bass.dll" () As Integer
	Declare Function BASS_Free Lib "bass.dll" () As Integer
	'UPGRADE_NOTE: object was upgraded to object_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Declare Function BASS_GetDSoundObject Lib "bass.dll" (ByVal object_Renamed As Integer) As Integer
	'UPGRADE_WARNING: Structure BASS_INFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_GetInfo Lib "bass.dll" (ByRef info As BASS_INFO) As Integer
	Declare Function BASS_Update Lib "bass.dll" () As Integer
	Declare Function BASS_GetCPU Lib "bass.dll" () As Single
	Declare Function BASS_Start Lib "bass.dll" () As Integer
	Declare Function BASS_Stop Lib "bass.dll" () As Integer
	Declare Function BASS_Pause Lib "bass.dll" () As Integer
	Declare Function BASS_SetVolume Lib "bass.dll" (ByVal volume As Integer) As Integer
	Declare Function BASS_GetVolume Lib "bass.dll" () As Integer
	
	Declare Function BASS_Set3DFactors Lib "bass.dll" (ByVal distf As Single, ByVal rollf As Single, ByVal doppf As Single) As Integer
	Declare Function BASS_Get3DFactors Lib "bass.dll" (ByRef distf As Single, ByRef rollf As Single, ByRef doppf As Single) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_Set3DPosition Lib "bass.dll" (ByRef pos As Any, ByRef vel As Any, ByRef front As Any, ByRef top As Any) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_Get3DPosition Lib "bass.dll" (ByRef pos As Any, ByRef vel As Any, ByRef front As Any, ByRef top As Any) As Integer
	Declare Function BASS_Apply3D Lib "bass.dll" () As Integer
	Declare Function BASS_SetEAXParameters Lib "bass.dll" (ByVal env As Integer, ByVal vol As Single, ByVal decay As Single, ByVal damp As Single) As Integer
	Declare Function BASS_GetEAXParameters Lib "bass.dll" (ByRef env As Integer, ByRef vol As Single, ByRef decay As Single, ByRef damp As Single) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_MusicLoad Lib "bass.dll" (ByVal mem As Integer, ByVal f As Any, ByVal offset As Integer, ByVal length As Integer, ByVal flags As Integer, ByVal freq As Integer) As Integer
	Declare Sub BASS_MusicFree Lib "bass.dll" (ByVal handle As Integer)
	Declare Function BASS_MusicGetName Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_MusicGetLength Lib "bass.dll" (ByVal handle As Integer, ByVal playlen As Integer) As Integer
	Declare Function BASS_MusicPreBuf Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_MusicPlay Lib "bass.dll" (ByVal handle As Integer) As Integer
	'UPGRADE_NOTE: reset was upgraded to reset_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Declare Function BASS_MusicPlayEx Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Integer, ByVal flags As Integer, ByVal reset_Renamed As Integer) As Integer
	Declare Function BASS_MusicSetAmplify Lib "bass.dll" (ByVal handle As Integer, ByRef amp As Integer) As Integer
	Declare Function BASS_MusicSetPanSep Lib "bass.dll" (ByVal handle As Integer, ByRef pan As Integer) As Integer
	Declare Function BASS_MusicSetPositionScaler Lib "bass.dll" (ByVal handle As Integer, ByVal pscale As Integer) As Integer
	Declare Function BASS_MusicSetVolume Lib "bass.dll" (ByVal handle As Integer, ByVal chanins As Integer, ByVal volume As Integer) As Integer
	Declare Function BASS_MusicGetVolume Lib "bass.dll" (ByVal handle As Integer, ByVal chanins As Integer) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_SampleLoad Lib "bass.dll" (ByVal mem As Integer, ByVal f As Any, ByVal offset As Integer, ByVal length As Integer, ByVal max As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_SampleCreate Lib "bass.dll" (ByVal length As Integer, ByVal freq As Integer, ByVal max As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_SampleCreateDone Lib "bass.dll" () As Integer
	Declare Sub BASS_SampleFree Lib "bass.dll" (ByVal handle As Integer)
	'UPGRADE_WARNING: Structure BASS_SAMPLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_SampleGetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_SAMPLE) As Integer
	'UPGRADE_WARNING: Structure BASS_SAMPLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_SampleSetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_SAMPLE) As Integer
	Declare Function BASS_SamplePlay Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_SamplePlayEx Lib "bass.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer, ByVal pLoop As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_SamplePlay3D Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Any, ByRef orient As Any, ByRef vel As Any) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_SamplePlay3DEx Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Any, ByRef orient As Any, ByRef vel As Any, ByVal start As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pLoop As Integer) As Integer
	Declare Function BASS_SampleStop Lib "bass.dll" (ByVal handle As Integer) As Integer
	
	Declare Function BASS_StreamCreate Lib "bass.dll" (ByVal freq As Integer, ByVal chans As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_StreamCreateFile Lib "bass.dll" (ByVal mem As Integer, ByVal f As Any, ByVal offset As Integer, ByVal length As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_StreamCreateURL Lib "bass.dll" (ByVal url As String, ByVal offset As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Function BASS_StreamCreateFileUser Lib "bass.dll" (ByVal buffered As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Sub BASS_StreamFree Lib "bass.dll" (ByVal handle As Integer)
	Declare Function BASS_StreamGetLength Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_StreamGetTags Lib "bass.dll" (ByVal handle As Integer, ByVal tags As Integer) As Integer
	Declare Function BASS_StreamPreBuf Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_StreamPlay Lib "bass.dll" (ByVal handle As Integer, ByVal flush As Integer, ByVal flags As Integer) As Integer
	Declare Function BASS_StreamGetFilePosition Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer) As Integer
	
	Declare Function BASS_RecordGetDeviceDescription Lib "bass.dll" (ByVal device As Integer) As Integer
	Declare Function BASS_RecordInit Lib "bass.dll" (ByVal device As Integer) As Integer
	Declare Function BASS_RecordSetDevice Lib "bass.dll" (ByVal device As Integer) As Integer
	Declare Function BASS_RecordGetDevice Lib "bass.dll" () As Integer
	Declare Function BASS_RecordFree Lib "bass.dll" () As Integer
	'UPGRADE_WARNING: Structure BASS_RECORDINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_RecordGetInfo Lib "bass.dll" (ByRef info As BASS_RECORDINFO) As Integer
	Declare Function BASS_RecordGetInputName Lib "bass.dll" (ByVal inputn As Integer) As Integer
	Declare Function BASS_RecordSetInput Lib "bass.dll" (ByVal inputn As Integer, ByVal setting As Integer) As Integer
	Declare Function BASS_RecordGetInput Lib "bass.dll" (ByVal inputn As Integer) As Integer
	Declare Function BASS_RecordStart Lib "bass.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	
	Private Declare Function BASS_ChannelBytes2Seconds64 Lib "bass.dll"  Alias "BASS_ChannelBytes2Seconds"(ByVal handle As Integer, ByVal pos As Integer, ByVal poshigh As Integer) As Single
	Declare Function BASS_ChannelSeconds2Bytes Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Single) As Integer
	Declare Function BASS_ChannelGetDevice Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelIsActive Lib "bass.dll" (ByVal handle As Integer) As Integer
	'UPGRADE_WARNING: Structure BASS_CHANNELINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function BASS_ChannelGetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_CHANNELINFO) As Integer
	Declare Function BASS_ChannelStop Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelPause Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelResume Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelSetAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer) As Integer
	Declare Function BASS_ChannelGetAttributes Lib "bass.dll" (ByVal handle As Integer, ByRef freq As Integer, ByRef volume As Integer, ByRef pan As Integer) As Integer
	Declare Function BASS_ChannelSlideAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer, ByVal time As Integer) As Integer
	Declare Function BASS_ChannelIsSliding Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelSet3DAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer, ByVal min As Single, ByVal max As Single, ByVal iangle As Integer, ByVal oangle As Integer, ByVal outvol As Integer) As Integer
	Declare Function BASS_ChannelGet3DAttributes Lib "bass.dll" (ByVal handle As Integer, ByRef mode As Integer, ByRef min As Single, ByRef max As Single, ByRef iangle As Integer, ByRef oangle As Integer, ByRef outvol As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_ChannelSet3DPosition Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Any, ByRef orient As Any, ByRef vel As Any) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_ChannelGet3DPosition Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Any, ByRef orient As Any, ByRef vel As Any) As Integer
	Private Declare Function BASS_ChannelSetPosition64 Lib "bass.dll"  Alias "BASS_ChannelSetPosition"(ByVal handle As Integer, ByVal pos As Integer, ByVal poshigh As Integer) As Integer
	Declare Function BASS_ChannelGetPosition Lib "bass.dll" (ByVal handle As Integer) As Integer
	Declare Function BASS_ChannelGetLevel Lib "bass.dll" (ByVal handle As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_ChannelGetData Lib "bass.dll" (ByVal handle As Integer, ByRef buffer As Any, ByVal length As Integer) As Integer
	Private Declare Function BASS_ChannelSetSync64 Lib "bass.dll"  Alias "BASS_ChannelSetSync"(ByVal handle As Integer, ByVal atype As Integer, ByVal param As Integer, ByVal paramhigh As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
	Declare Function BASS_ChannelRemoveSync Lib "bass.dll" (ByVal handle As Integer, ByVal sync As Integer) As Integer
	Declare Function BASS_ChannelSetDSP Lib "bass.dll" (ByVal handle As Integer, ByVal proc As Integer, ByVal user As Integer, ByVal priority As Integer) As Integer
	Declare Function BASS_ChannelRemoveDSP Lib "bass.dll" (ByVal handle As Integer, ByVal dsp As Integer) As Integer
	Declare Function BASS_ChannelSetEAXMix Lib "bass.dll" (ByVal handle As Integer, ByVal mix As Single) As Integer
	Declare Function BASS_ChannelGetEAXMix Lib "bass.dll" (ByVal handle As Integer, ByRef mix As Single) As Integer
	Declare Function BASS_ChannelSetLink Lib "bass.dll" (ByVal handle As Integer, ByVal chan As Integer) As Integer
	Declare Function BASS_ChannelRemoveLink Lib "bass.dll" (ByVal handle As Integer, ByVal chan As Integer) As Integer
	Declare Function BASS_ChannelSetFX Lib "bass.dll" (ByVal handle As Integer, ByVal atype As Integer) As Integer
	Declare Function BASS_ChannelRemoveFX Lib "bass.dll" (ByVal handle As Integer, ByVal fx As Integer) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As Any) As Integer
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As Any) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	Private Declare Sub CopyMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal length As Integer)
	Private Declare Function lstrlen Lib "kernel32"  Alias "lstrlenA"(ByVal lpString As Integer) As Integer
	
	'*******************************************
	' 32-bit wrappers for 64-bit BASS functions
	'*******************************************
	Function BASS_ChannelBytes2Seconds(ByVal handle As Integer, ByVal pos As Integer) As Single
		BASS_ChannelBytes2Seconds = BASS_ChannelBytes2Seconds64(handle, pos, 0)
	End Function
	
	Function BASS_ChannelSetPosition(ByVal handle As Integer, ByVal pos As Integer) As Integer
		BASS_ChannelSetPosition = BASS_ChannelSetPosition64(handle, pos, 0)
	End Function
	
	Function BASS_ChannelSetSync(ByVal handle As Integer, ByVal atype As Integer, ByVal param As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
		BASS_ChannelSetSync = BASS_ChannelSetSync64(handle, atype, param, 0, proc, user)
	End Function
	
	
	Function STREAMPROC(ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer
		
		'CALLBACK FUNCTION !!!
		
		' User stream callback function
		' NOTE: A stream function should obviously be as quick
		' as possible, other streams (and MOD musics) can't be mixed until it's finished.
		' handle : The stream that needs writing
		' buffer : Buffer to write the samples in
		' length : Number of bytes to write
		' user   : The 'user' parameter value given when calling BASS_StreamCreate
		' RETURN : Number of bytes written. Set the BASS_STREAMPROC_END flag to end
		'          the stream.
		
	End Function
	
	Function STREAMFILEPROC(ByVal action As Integer, ByVal param1 As Integer, ByVal param2 As Integer, ByVal user As Integer) As Integer
		
		'CALLBACK FUNCTION !!!
		
		' User file stream callback function.
		' action : The action to perform, one of BASS_FILE_xxx values.
		' param1 : Depends on "action"
		' param2 : Depends on "action"
		' user   : The 'user' parameter value given when calling BASS_StreamCreate
		' RETURN : Depends on "action"
		
	End Function
	
	Sub DOWNLOADPROC(ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		' Internet stream download callback function.
		' buffer : Buffer containing the downloaded data... NULL=end of download
		' length : Number of bytes in the buffer
		' user   : The 'user' parameter given when calling BASS_StreamCreateURL
		
	End Sub
	
	Sub SYNCPROC(ByVal handle As Integer, ByVal channel As Integer, ByVal data As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		'Similarly in here, write what to do when sync function
		'is called, i.e screen flash etc.
		
		' NOTE: a sync callback function should be very quick as other
		' syncs cannot be processed until it has finished.
		' handle : The sync that has occured
		' channel: Channel that the sync occured in
		' data   : Additional data associated with the sync's occurance
		' user   : The 'user' parameter given when calling BASS_ChannelSetSync */
		
	End Sub
	
	Sub DSPPROC(ByVal handle As Integer, ByVal channel As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)
		
		'CALLBACK FUNCTION !!!
		
		' VB doesn't support pointers, so you should copy the buffer into an array,
		' process it, and then copy it back into the buffer.
		
		' DSP callback function. NOTE: A DSP function should obviously be as quick as
		' possible... other DSP functions, streams and MOD musics can not be processed
		' until it's finished.
		' handle : The DSP handle
		' channel: Channel that the DSP is being applied to
		' buffer : Buffer to apply the DSP to
		' length : Number of bytes in the buffer
		' user   : The 'user' parameter given when calling BASS_ChannelSetDSP
		
	End Sub
	
	Function RECORDPROC(ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer
		
		'CALLBACK FUNCTION !!!
		
		' Recording callback function.
		' handle : The recording handle
		' buffer : Buffer containing the recorded samples
		' length : Number of bytes
		' user   : The 'user' parameter value given when calling BASS_RecordStart
		' RETURN : BASSTRUE = continue recording, BASSFALSE = stop
		
	End Function
	
	
	Function BASS_GetDeviceDescriptionString(ByVal device As Integer) As String
		Dim pstring As Integer
		Dim sstring As String
		On Error Resume Next
		pstring = BASS_GetDeviceDescription(device)
		If pstring Then
			sstring = VBStrFromAnsiPtr(pstring)
		End If
		BASS_GetDeviceDescriptionString = sstring
	End Function
	
	Public Function BASS_MusicGetNameString(ByVal handle As Integer) As String
		Dim pstring As Integer
		Dim sstring As String
		On Error Resume Next
		pstring = BASS_MusicGetName(handle)
		If pstring Then
			sstring = VBStrFromAnsiPtr(pstring)
		End If
		BASS_MusicGetNameString = sstring
	End Function
	
	Function BASS_GetStringVersion() As String
		'This function will return the string version
		'of the BASS DLL. For example the provided function within the DLL
		'"BASS_GetVersion" will return 393216, whereas this function works
		'out the actual version string as you would need to see it.
		BASS_GetStringVersion = Trim(Str(LoWord(BASS_GetVersion))) & "." & Trim(Str(HiWord(BASS_GetVersion)))
	End Function
	
	Function BASS_SetEAXPreset(ByRef Preset As Object) As Integer
		' This function is a workaround, because VB doesn't support multiple comma seperated
		' paramaters for each Global Const, simply pass the EAX_ENVIRONMENT_xxx value to this function
		' instead of BASS_SetEAXParameters as you would do in C++
		Select Case Preset
			Case EAX_ENVIRONMENT_GENERIC
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_GENERIC, 0.5, 1.493, 0.5)
			Case EAX_ENVIRONMENT_PADDEDCELL
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_PADDEDCELL, 0.25, 0.1, 0)
			Case EAX_ENVIRONMENT_ROOM
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_ROOM, 0.417, 0.4, 0.666)
			Case EAX_ENVIRONMENT_BATHROOM
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_BATHROOM, 0.653, 1.499, 0.166)
			Case EAX_ENVIRONMENT_LIVINGROOM
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_LIVINGROOM, 0.208, 0.478, 0)
			Case EAX_ENVIRONMENT_STONEROOM
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_STONEROOM, 0.5, 2.309, 0.888)
			Case EAX_ENVIRONMENT_AUDITORIUM
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_AUDITORIUM, 0.403, 4.279, 0.5)
			Case EAX_ENVIRONMENT_CONCERTHALL
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_CONCERTHALL, 0.5, 3.961, 0.5)
			Case EAX_ENVIRONMENT_CAVE
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_CAVE, 0.5, 2.886, 1.304)
			Case EAX_ENVIRONMENT_ARENA
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_ARENA, 0.361, 7.284, 0.332)
			Case EAX_ENVIRONMENT_HANGAR
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_HANGAR, 0.5, 10, 0.3)
			Case EAX_ENVIRONMENT_CARPETEDHALLWAY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_CARPETEDHALLWAY, 0.153, 0.259, 2)
			Case EAX_ENVIRONMENT_HALLWAY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_HALLWAY, 0.361, 1.493, 0)
			Case EAX_ENVIRONMENT_STONECORRIDOR
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_STONECORRIDOR, 0.444, 2.697, 0.638)
			Case EAX_ENVIRONMENT_ALLEY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_ALLEY, 0.25, 1.752, 0.776)
			Case EAX_ENVIRONMENT_FOREST
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_FOREST, 0.111, 3.145, 0.472)
			Case EAX_ENVIRONMENT_CITY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_CITY, 0.111, 2.767, 0.224)
			Case EAX_ENVIRONMENT_MOUNTAINS
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_MOUNTAINS, 0.194, 7.841, 0.472)
			Case EAX_ENVIRONMENT_QUARRY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_QUARRY, 1, 1.499, 0.5)
			Case EAX_ENVIRONMENT_PLAIN
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_PLAIN, 0.097, 2.767, 0.224)
			Case EAX_ENVIRONMENT_PARKINGLOT
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_PARKINGLOT, 0.208, 1.652, 1.5)
			Case EAX_ENVIRONMENT_SEWERPIPE
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_SEWERPIPE, 0.652, 2.886, 0.25)
			Case EAX_ENVIRONMENT_UNDERWATER
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_UNDERWATER, 1, 1.499, 0)
			Case EAX_ENVIRONMENT_DRUGGED
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_DRUGGED, 0.875, 8.392, 1.388)
			Case EAX_ENVIRONMENT_DIZZY
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_DIZZY, 0.139, 17.234, 0.666)
			Case EAX_ENVIRONMENT_PSYCHOTIC
				BASS_SetEAXPreset = BASS_SetEAXParameters(EAX_ENVIRONMENT_PSYCHOTIC, 0.486, 7.563, 0.806)
		End Select
	End Function
	
	Public Function HiWord(ByRef lparam As Integer) As Integer
		' This is the HIWORD of the lParam:
		HiWord = lparam \ &H10000 And &HFFFF
	End Function
	Public Function LoWord(ByRef lparam As Integer) As Integer
		' This is the LOWORD of the lParam:
		LoWord = lparam And &HFFFF
	End Function
	Function MakeLong(ByRef LoWord As Integer, ByRef HiWord As Integer) As Integer
		'Replacement for the c++ Function MAKELONG
		MakeLong = (LoWord And &HFFFF) Or (HiWord * &H10000)
	End Function
	
	Public Function VBStrFromAnsiPtr(ByVal lpStr As Integer) As String
		Dim bStr() As Byte
		Dim cChars As Integer
		On Error Resume Next
		' Get the number of characters in the buffer
		cChars = lstrlen(lpStr)
		
		' Resize the byte array
		ReDim bStr(cChars - 1)
		
		' Grab the ANSI buffer
		Call CopyMemory(bStr(0), lpStr, cChars)
		
		' Now convert to a VB Unicode string
		'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		VBStrFromAnsiPtr = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(bStr), vbUnicode)
	End Function
End Module