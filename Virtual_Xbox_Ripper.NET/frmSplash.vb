Option Strict Off
Option Explicit On
Friend Class frmSplash
	Inherits System.Windows.Forms.Form
	Private Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'Sets Splash in Center Screer of Screen lill Higher
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) * 0.65) / 2 - VB6.PixelsToTwipsY(Me.Height) / 25) ',85
		Me.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 2 - VB6.PixelsToTwipsX(Me.Width) / 2)
		
	End Sub
	
	Private Sub tmrUpdate_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrUpdate.Tick
		
		'Loads Main Window
		frmMain.Show()
		Me.Close()
	End Sub
End Class