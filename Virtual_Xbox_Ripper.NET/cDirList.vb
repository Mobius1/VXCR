Option Strict Off
Option Explicit On
Friend Class cDirList
	Implements System.Collections.IEnumerable
	
	Private Const FILE_ATTRIBUTE_READONLY As Short = &H1s
	Private Const FILE_ATTRIBUTE_HIDDEN As Short = &H2s
	Private Const FILE_ATTRIBUTE_SYSTEM As Short = &H4s
	Private Const FILE_ATTRIBUTE_DIRECTORY As Short = &H10s
	Private Const FILE_ATTRIBUTE_ARCHIVE As Short = &H20s
	Private Const FILE_ATTRIBUTE_NORMAL As Short = &H80s
	Private Const FILE_ATTRIBUTE_TEMPORARY As Short = &H100s
	Private Const FILE_ATTRIBUTE_COMPRESSED As Short = &H800s
	Private Const FILE_ATTRIBUTE_OFFLINE As Short = &H1000s
	
	Private mCol As New Collection
	
	Public Function Add(ByRef lAttrib As Integer, ByRef dtCreationTime As Date, ByRef dtLastAccessTime As Date, ByRef dtLastWriteTime As Date, ByRef lFileSize As Integer, ByRef sFilename As String) As cDirItem
		Dim newItem As New cDirItem
		
		With newItem
			.Archive = (lAttrib And FILE_ATTRIBUTE_ARCHIVE)
			.Compressed = (lAttrib And FILE_ATTRIBUTE_COMPRESSED)
			.Directory = (lAttrib And FILE_ATTRIBUTE_DIRECTORY)
			.Hidden = (lAttrib And FILE_ATTRIBUTE_HIDDEN)
			.Normal = (lAttrib And FILE_ATTRIBUTE_NORMAL)
			.Offline = (lAttrib And FILE_ATTRIBUTE_OFFLINE)
			.ReadOnly_Renamed = (lAttrib And FILE_ATTRIBUTE_READONLY)
			.System_Renamed = (lAttrib And FILE_ATTRIBUTE_SYSTEM)
			.Temporary = (lAttrib And FILE_ATTRIBUTE_TEMPORARY)
			.CreationTime = dtCreationTime
			.LastAccessTime = dtLastAccessTime
			.LastWriteTime = dtLastWriteTime
			.FileSize = lFileSize
			.Filename = sFilename
		End With
		mCol.Add(newItem, sFilename)
	End Function
	
	Public Function Clear() As Object
		Dim lIndex As Integer
		If mCol.Count() > 0 Then
			For lIndex = 1 To mCol.Count() - 1
				mCol.Remove(lIndex)
			Next 
		End If
	End Function
	
	Public Function Item(ByRef Index As Object) As cDirItem
		Item = mCol.Item(Index)
	End Function
	
	Public Function Count() As Integer
		Count = mCol.Count()
	End Function
	
	'UPGRADE_NOTE: NewEnum property was commented out. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3FC1610-34F3-43F5-86B7-16C984F0E88E"'
	'Public Function NewEnum() As stdole.IUnknown
		'NewEnum = mCol.GetEnumerator
	'End Function
	
	Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		'UPGRADE_TODO: Uncomment and change the following line to return the collection enumerator. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="95F9AAD0-1319-4921-95F0-B9D3C4FF7F1C"'
		'GetEnumerator = mCol.GetEnumerator
	End Function
End Class