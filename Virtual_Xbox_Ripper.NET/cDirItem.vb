Option Strict Off
Option Explicit On
Friend Class cDirItem
	
	'UPGRADE_NOTE: ReadOnly was upgraded to ReadOnly_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public ReadOnly_Renamed As Boolean
	Public Hidden As Boolean
	'UPGRADE_NOTE: System was upgraded to System_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public System_Renamed As Boolean
	Public Directory As Boolean
	Public Archive As Boolean
	Public Normal As Boolean
	Public Temporary As Boolean
	Public Compressed As Boolean
	Public Offline As Boolean
	
	Public CreationTime As Date
	Public LastAccessTime As Date
	Public LastWriteTime As Date
	
	Public FileSize As Integer
	Public Filename As String
End Class