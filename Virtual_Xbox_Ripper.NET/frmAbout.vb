Option Strict Off
Option Explicit On
Friend Class frmAbout
	Inherits System.Windows.Forms.Form
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
		'Terminates This Window
		Me.Close()
		
	End Sub
	
	Private Sub frmAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'Transfers Picture from frmSplash
		'Me.imgAbout.Picture = frmSplash.Image1.Picture
		frmSplash.Close()
		
	End Sub
End Class