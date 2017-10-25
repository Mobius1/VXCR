Option Strict Off
Option Explicit On
Module modCDDB
	'---------------------------------------
	'Description:   Allows CDDB Access
	'Created by:    BlueCELL
	'Date:          March 21, 2004
	'Started:       March 21, 2004 4.10 PM EST
	'Finished:      NA
	'---------------------------------------
	
	'CD Structure (Used for Generating CD-ID)
	Public Structure TableOfContent
		Dim lngMin As Integer
		Dim lngSec As Integer
		Dim lngFram As Integer
		Dim lngOffSet As Integer
	End Structure
	
	'Declares Memory Variables
	Public CDToc() As TableOfContent
	Public intTotalR As Short
	Public strA As New VB6.FixedLengthString(40)
	
	'Libary Calls (MCI - "Multimedia Control Interface")
	Public Declare Function mciGetErrorString Lib "winmm.dll"  Alias "mciGetErrorStringA"(ByVal dwError As Integer, ByVal lpstrBuffer As String, ByVal uLength As Integer) As Integer
	Public Declare Function mciSendString Lib "winmm.dll"  Alias "mciSendStringA"(ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
	
	'Returns Errors from MCI
	Public Function SendMCIString(ByRef cmd As String, ByRef fShowError As Boolean) As Boolean
		Dim hWnd As Object
		
		'Declares Static Varibles
		Static lngRC As Integer
		Static strError As New VB6.FixedLengthString(200)
		
		'Grabs MCI Handle
		'UPGRADE_WARNING: Couldn't resolve default property of object hWnd. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lngRC = mciSendString(cmd, CStr(0), 0, hWnd)
		
		'Checks for MCI Errors
		If (fShowError And lngRC <> 0) Then
			
			'Reads Error String
			mciGetErrorString(lngRC, strError.Value, Len(strError.Value))
			
			'Displays Error(s) Message
			MsgBox(strError.Value)
		End If
		
		'Returns 0
		SendMCIString = (lngRC = 0)
		
	End Function
	
	'Reads CD Table Of Content (TOC)
	Public Function ReadCDToc() As Short
		Dim cmd As Object
		Dim i As Object
		
		'Requests Track Count
		mciSendString("status cd69 number of tracks wait", strA.Value, Len(strA.Value), 0)
		
		'Gets Total Number into Memory
		intTotalR = CShort(Mid(strA.Value, 1, 2))
		
		'Resizes CDToc to SoundTrack Count
		ReDim CDToc(intTotalR + 1)
		
		'Requests Output Format
		mciSendString("set cd69 time format msf", CStr(0), 0, 0)
		
		'Loops through Each Track
		For i = 1 To intTotalR
			
			'Returns Status of CD
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object cmd. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmd = "status cd69 position track " & i
			'UPGRADE_WARNING: Couldn't resolve default property of object cmd. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mciSendString(cmd, strA.Value, Len(strA.Value), 0)
			
			'Places Data into Memory Structor
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CDToc(i - 1).lngMin = CShort(Mid(strA.Value, 1, 2))
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CDToc(i - 1).lngSec = CShort(Mid(strA.Value, 4, 2))
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CDToc(i - 1).lngFram = CShort(Mid(strA.Value, 7, 2))
			'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CDToc(i - 1).lngOffSet = (CDToc(i - 1).lngMin * 60 * 75) + (CDToc(i - 1).lngSec * 75) + CDToc(i - 1).lngFram
		Next 
		
	End Function
	
	'This Code Gets The CD ID.
	Public Function CDDBDiscId() As String
		
		'Declares Memory Units
		Dim lngA As Integer
		Dim lngB As Integer
		Dim lngC As Integer
		Dim lngD As Integer
		Dim lngTrackC As Integer
		
		'Gets Number of Tracks
		ReadCDToc()
		lngTrackC = intTotalR
		
		'Closes ALL CD Drives
		mciSendString("close all", CStr(0), 0, 0)
		
		'Checks for Error
		If (SendMCIString("open cdaudio alias cd69 wait shareable", True) = False) Then
			
			'Returns 0 for Error
			CDDBDiscId = CStr(0)
			Exit Function
		End If
		
		'Loops Through Track Count
		For lngC = 0 To lngTrackC - 1
			
			'Converts Length into Key
			lngB = ((CDToc(lngC).lngMin * 60) + CDToc(lngC).lngSec)
			
			'Sums up Key
			Do While lngB > 0
				lngA = lngA + (lngB Mod 10)
				lngB = lngB \ 10
			Loop 
		Next 
		
		'Requests Length
		mciSendString("status cd69 length wait", strA.Value, Len(strA.Value), 0)
		lngD = (CShort(Mid(strA.Value, 1, 2)) * 60) + CShort(Mid(strA.Value, 4, 2))
		
		'Returns CD ID
		CDDBDiscId = LCase(Zeros(Hex(lngA Mod &HFFs), 2) & Zeros(Hex(lngD), 4) & Zeros(Hex(lngTrackC), 2))
		
	End Function
	
	'Adds Zero(s) to Sent String
	Private Function Zeros(ByRef strInput As String, ByRef intNumber As Short) As String
		
		If Len(strInput) < intNumber Then
			Zeros = New String("0", intNumber - Len(strInput)) & strInput
		Else
			Zeros = strInput
		End If
		
	End Function
End Module