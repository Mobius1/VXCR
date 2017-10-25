VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmOptions 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Virtual Xbox CD Ripper - Options"
   ClientHeight    =   6045
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   8205
   Icon            =   "frmOptions.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6045
   ScaleWidth      =   8205
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdDone 
      Caption         =   "Done"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   6600
      TabIndex        =   21
      Top             =   5520
      Width           =   1455
   End
   Begin VB.PictureBox picnob 
      BorderStyle     =   0  'None
      Height          =   255
      Left            =   2420
      ScaleHeight     =   255
      ScaleWidth      =   5775
      TabIndex        =   20
      Top             =   5160
      Width           =   5775
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderStyle     =   6  'Inside Solid
         Index           =   5
         X1              =   0
         X2              =   5760
         Y1              =   160
         Y2              =   160
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00808080&
         BorderStyle     =   6  'Inside Solid
         Index           =   4
         X1              =   0
         X2              =   5760
         Y1              =   150
         Y2              =   150
      End
   End
   Begin MSComctlLib.ListView lvOptions 
      Height          =   4455
      Left            =   0
      TabIndex        =   7
      Top             =   860
      Width           =   2415
      _ExtentX        =   4260
      _ExtentY        =   7858
      View            =   2
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      NumItems        =   0
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'None
      Height          =   840
      Left            =   0
      Picture         =   "frmOptions.frx":472A
      ScaleHeight     =   840
      ScaleWidth      =   8280
      TabIndex        =   8
      Top             =   0
      Width           =   8280
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   4440
      Left            =   2400
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   855
      Width           =   6135
      _ExtentX        =   10821
      _ExtentY        =   7832
      _Version        =   393216
      TabOrientation  =   3
      Style           =   1
      Tabs            =   5
      TabsPerRow      =   5
      TabHeight       =   520
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TabCaption(0)   =   "General"
      TabPicture(0)   =   "frmOptions.frx":1B1AC
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Line1(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Line1(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "lblAuoConnect"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "lblTempFld"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "lblDst"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label2"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "chkAutoConnect"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "txtIP"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "txtTempFld"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "cmdSelFld"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).ControlCount=   10
      TabCaption(1)   =   "Formats"
      TabPicture(1)   =   "frmOptions.frx":1B1C8
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Line1(10)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "Line1(9)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "lblFileType"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "lblBitRates"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "cmdUnselect"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "chkMP3"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "chkMp2"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "chkMp1"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "chkWMA"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).Control(9)=   "chkOGG"
      Tab(1).Control(9).Enabled=   0   'False
      Tab(1).Control(10)=   "chkWAV"
      Tab(1).Control(10).Enabled=   0   'False
      Tab(1).Control(11)=   "cmdSelectAll"
      Tab(1).Control(11).Enabled=   0   'False
      Tab(1).Control(12)=   "opt128"
      Tab(1).Control(12).Enabled=   0   'False
      Tab(1).Control(13)=   "opt160"
      Tab(1).Control(13).Enabled=   0   'False
      Tab(1).Control(14)=   "opt192"
      Tab(1).Control(14).Enabled=   0   'False
      Tab(1).Control(15)=   "opt256"
      Tab(1).Control(15).Enabled=   0   'False
      Tab(1).Control(16)=   "optSmart"
      Tab(1).Control(16).Enabled=   0   'False
      Tab(1).ControlCount=   17
      TabCaption(2)   =   "Virtual Drive"
      TabPicture(2)   =   "frmOptions.frx":1B1E4
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "lblinfo"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).Control(1)=   "Label1"
      Tab(2).Control(1).Enabled=   0   'False
      Tab(2).Control(2)=   "chkVDrive"
      Tab(2).Control(2).Enabled=   0   'False
      Tab(2).ControlCount=   3
      TabCaption(3)   =   "CD Ripper"
      TabPicture(3)   =   "frmOptions.frx":1B200
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "chkAutoCDDB"
      Tab(3).Control(0).Enabled=   0   'False
      Tab(3).ControlCount=   1
      TabCaption(4)   =   "ID Tags"
      TabPicture(4)   =   "frmOptions.frx":1B21C
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "Line1(8)"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "lblIdTags"
      Tab(4).Control(1).Enabled=   0   'False
      Tab(4).Control(2)=   "imgRB"
      Tab(4).Control(2).Enabled=   0   'False
      Tab(4).Control(3)=   "Line1(7)"
      Tab(4).Control(3).Enabled=   0   'False
      Tab(4).Control(4)=   "chkManualName"
      Tab(4).Control(4).Enabled=   0   'False
      Tab(4).Control(5)=   "chkShowLocalBitrate"
      Tab(4).Control(5).Enabled=   0   'False
      Tab(4).Control(6)=   "Picture2"
      Tab(4).Control(6).Enabled=   0   'False
      Tab(4).ControlCount=   7
      Begin VB.PictureBox Picture2 
         AutoRedraw      =   -1  'True
         BorderStyle     =   0  'None
         Height          =   1095
         Left            =   -72960
         ScaleHeight     =   1095
         ScaleWidth      =   3375
         TabIndex        =   34
         Top             =   840
         Width           =   3375
         Begin VB.OptionButton optFileName 
            Caption         =   "Show File Name"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   120
            TabIndex        =   37
            Top             =   0
            Width           =   1695
         End
         Begin VB.OptionButton optIDstuff 
            Caption         =   "ID Tag (Title Only)"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   0
            Left            =   120
            TabIndex        =   36
            Top             =   720
            Width           =   1695
         End
         Begin VB.OptionButton optIDstuff 
            Caption         =   "ID Tag (Artist - Title)"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   1
            Left            =   120
            TabIndex        =   35
            Top             =   360
            Width           =   2175
         End
      End
      Begin VB.OptionButton optSmart 
         Caption         =   "Smart Detection (Recommend)"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -72960
         TabIndex        =   32
         Top             =   3000
         Width           =   3135
      End
      Begin VB.OptionButton opt256 
         Caption         =   "256 Kbps"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   -74280
         TabIndex        =   31
         Top             =   3720
         Width           =   1215
      End
      Begin VB.OptionButton opt192 
         Caption         =   "192 Kbps"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   -74280
         TabIndex        =   30
         Top             =   3480
         Width           =   1215
      End
      Begin VB.OptionButton opt160 
         Caption         =   "160 Kbps"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   -74280
         TabIndex        =   29
         Top             =   3240
         Width           =   1215
      End
      Begin VB.OptionButton opt128 
         Caption         =   "128 Kbps"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Left            =   -74280
         TabIndex        =   28
         Top             =   3000
         Width           =   1215
      End
      Begin VB.CheckBox chkShowLocalBitrate 
         Caption         =   "Show Local Music Files BitRate"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74640
         TabIndex        =   26
         Top             =   2640
         Width           =   5055
      End
      Begin VB.CommandButton cmdSelFld 
         Caption         =   "..."
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   4920
         TabIndex        =   25
         Top             =   2040
         Width           =   255
      End
      Begin VB.TextBox txtTempFld 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   1080
         TabIndex        =   23
         Top             =   2040
         Width           =   3735
      End
      Begin VB.CheckBox chkManualName 
         Caption         =   "Allow me to Manually Enter Names before Upload"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74640
         TabIndex        =   19
         Top             =   2400
         Width           =   4935
      End
      Begin VB.CommandButton cmdSelectAll 
         Caption         =   "Select All"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -71040
         TabIndex        =   16
         Top             =   1200
         Width           =   1335
      End
      Begin VB.CheckBox chkWAV 
         Caption         =   "WAV (Uncompressed Audio)"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74280
         TabIndex        =   15
         Top             =   1920
         Width           =   2655
      End
      Begin VB.CheckBox chkOGG 
         Caption         =   "Ogg (Vorbis's Format)"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74280
         TabIndex        =   14
         Top             =   1560
         Width           =   2655
      End
      Begin VB.CheckBox chkWMA 
         Caption         =   "WMA (Windows Media Audio)"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74280
         TabIndex        =   13
         Top             =   1200
         Width           =   2655
      End
      Begin VB.CheckBox chkMp1 
         Caption         =   "MP1"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -72720
         TabIndex        =   12
         Top             =   840
         Width           =   975
      End
      Begin VB.CheckBox chkMp2 
         Caption         =   "MP2"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -73560
         TabIndex        =   11
         Top             =   840
         Width           =   1215
      End
      Begin VB.CheckBox chkMP3 
         Caption         =   "MP3"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74280
         TabIndex        =   10
         Top             =   840
         Width           =   1095
      End
      Begin VB.CheckBox chkAutoCDDB 
         Caption         =   "Automaticly Check for CDDB"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74760
         TabIndex        =   6
         Top             =   270
         Width           =   3375
      End
      Begin VB.CheckBox chkVDrive 
         Caption         =   "Enable Virtual Drive"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74760
         TabIndex        =   5
         Top             =   990
         Width           =   2415
      End
      Begin VB.TextBox txtIP 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   1080
         TabIndex        =   3
         Text            =   "127.0.0.1"
         Top             =   1080
         Width           =   3735
      End
      Begin VB.CheckBox chkAutoConnect 
         Caption         =   "Attempt To Connect to Xbox During Load"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   1080
         TabIndex        =   2
         Top             =   720
         Width           =   4335
      End
      Begin VB.CommandButton cmdUnselect 
         Caption         =   "UnSelect All"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -71040
         TabIndex        =   17
         Top             =   840
         Width           =   1335
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Doesnt work yet!"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   -74760
         TabIndex        =   38
         Top             =   1320
         Width           =   3855
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "IP:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   33
         Top             =   1080
         Width           =   735
      End
      Begin VB.Label lblBitRates 
         BackStyle       =   0  'Transparent
         Caption         =   $"frmOptions.frx":1B238
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -74760
         TabIndex        =   27
         Top             =   2520
         Width           =   5295
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00808080&
         BorderStyle     =   6  'Inside Solid
         Index           =   7
         X1              =   -74880
         X2              =   -69480
         Y1              =   2280
         Y2              =   2280
      End
      Begin VB.Label lblDst 
         Alignment       =   1  'Right Justify
         Caption         =   "Folder:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   240
         TabIndex        =   24
         Top             =   2070
         Width           =   735
      End
      Begin VB.Label lblTempFld 
         BackStyle       =   0  'Transparent
         Caption         =   "Please Select where you would like VXCR to store Temporary Files."
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   240
         TabIndex        =   22
         Top             =   1680
         Width           =   4935
      End
      Begin VB.Image imgRB 
         Height          =   990
         Left            =   -74520
         Picture         =   "frmOptions.frx":1B2C9
         Top             =   840
         Width           =   1365
      End
      Begin VB.Label lblIdTags 
         Caption         =   "When Virtual Xbox CD Ripper Transfers files to the Xbox how would you like to name these files in the Xbox SoundTrack Database?"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -74880
         TabIndex        =   18
         Top             =   120
         Width           =   5415
      End
      Begin VB.Label lblFileType 
         BackStyle       =   0  'Transparent
         Caption         =   "Please select which files you would like Virtual Xbox CD Ripper to list when you select a Root directory."
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   -74880
         TabIndex        =   9
         Top             =   120
         Width           =   5415
      End
      Begin VB.Label lblinfo 
         BackStyle       =   0  'Transparent
         Caption         =   $"frmOptions.frx":1C897
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Left            =   -74880
         TabIndex        =   4
         Top             =   150
         Width           =   5415
      End
      Begin VB.Label lblAuoConnect 
         BackStyle       =   0  'Transparent
         Caption         =   "If you would like VXCR to attempt to connect to an Xbox during the load, please enter the information below. (Doesnt work yet)"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   240
         TabIndex        =   1
         Top             =   120
         Width           =   5415
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00808080&
         BorderStyle     =   6  'Inside Solid
         Index           =   1
         X1              =   120
         X2              =   5520
         Y1              =   1580
         Y2              =   1580
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   2
         Index           =   0
         X1              =   120
         X2              =   5520
         Y1              =   1590
         Y2              =   1590
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   2
         Index           =   8
         X1              =   -74880
         X2              =   -69480
         Y1              =   2295
         Y2              =   2295
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00808080&
         BorderStyle     =   6  'Inside Solid
         Index           =   9
         X1              =   -74760
         X2              =   -69480
         Y1              =   2400
         Y2              =   2400
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   2
         Index           =   10
         X1              =   -74760
         X2              =   -69480
         Y1              =   2400
         Y2              =   2415
      End
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00FFFFFF&
      BorderStyle     =   6  'Inside Solid
      Index           =   6
      X1              =   0
      X2              =   4800
      Y1              =   5325
      Y2              =   5325
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00808080&
      BorderStyle     =   6  'Inside Solid
      Index           =   3
      X1              =   0
      X2              =   2640
      Y1              =   5310
      Y2              =   5310
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00808080&
      BorderStyle     =   6  'Inside Solid
      Index           =   2
      X1              =   0
      X2              =   8520
      Y1              =   840
      Y2              =   840
   End
End
Attribute VB_Name = "frmOptions"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function SHGetSpecialFolderLocation Lib "Shell32.dll" (ByVal hWndOwner As Long, ByVal nFolder As Long, pidl As ITEMIDLIST) As Long
Private Declare Function SHGetPathFromIDList Lib "Shell32.dll" Alias "SHGetPathFromIDListA" (ByVal pidl As Long, ByVal pszPath As String) As Long
Private Declare Function PathFileExists Lib "shlwapi.dll" Alias "PathFileExistsA" (ByVal pszPath As String) As Long

Private Const BIF_RETURNONLYFSDIRS = 1
Private Const BIF_DONTGOBELOWDOMAIN = 2
Private Const MAX_PATH = 260

Private Declare Function SHBrowseForFolder Lib "shell32" (lpbi As BrowseInfo) As Long
Private Declare Function lstrcat Lib "kernel32" Alias "lstrcatA" (ByVal lpString1 As String, ByVal lpString2 As String) As Long

Private Type SH_ITEMID
    cb As Long
    abID As Byte
End Type

Private Type ITEMIDLIST
    mkid As SH_ITEMID
End Type

Private Type BrowseInfo
    hWndOwner      As Long
    pIDLRoot       As Long
    pszDisplayName As Long
    lpszTitle      As Long
    ulFlags        As Long
    lpfnCallback   As Long
    lParam         As Long
    iImage         As Long
End Type

Private Sub cmdDone_Click()
    
    'Declares Memory Varibles
    Dim lngA As Long

    'Sets Format Memory to NULL
    VXCRSettings.strSFormats = ""
    blnFirst = True
    
    'Saves Audio Format
    If chkMP3.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp3,"
    End If
    If chkMp2.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp2,"
    End If
    If chkMp1.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "mp1,"
    End If
    If chkOGG.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "ogg,"
    End If
    If chkWMA.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "wma,"
    End If
    If chkWAV.value = 1 Then
        VXCRSettings.strSFormats = VXCRSettings.strSFormats & "wav,"
    End If
    If Right(VXCRSettings.strSFormats, 1) = "," Then
        VXCRSettings.strSFormats = Left(VXCRSettings.strSFormats, Len(VXCRSettings.strSFormats) - 1)
    End If
    
    'Saves Auto Connect Settings
    If Me.chkAutoConnect.value = 1 Then
        VXCRSettings.strAutoCIP = Me.txtIP
      Else
        VXCRSettings.strAutoCIP = 0
    End If
    
    'Saves IDTag Stuff
    If Me.optFileName.value = True Then
        VXCRSettings.intIDStuff = 1     'Show FileName
    End If
    If Me.optIDstuff(0).value = True Then
        VXCRSettings.intIDStuff = 2     'Title from IDTag Only
    End If
    If Me.optIDstuff(1).value = True Then
        VXCRSettings.intIDStuff = 3     'Artist - Title from IDTag
    End If
    
    'Saves Manual Edit ID Tag
    If Me.chkManualName.value = 1 Then
        VXCRSettings.blnManuIDTag = True
      Else
        VXCRSettings.blnManuIDTag = False
    End If
    
    'Saves Temp Folder Setting
    If modFileSystem.fFolderExists(txtTempFld.text) = True Then
    
        'Saves Setting
        VXCRSettings.strTempFld = txtTempFld.text
        
       Else
               
        'Messages User
        MsgBox "Please Select Another Temporary Folder!", vbOKOnly + vbExclamation
        
    End If
    
    'Saves (enabled BitRate)
    If Me.chkShowLocalBitrate.value = 1 Then
        VXCRSettings.blnShwLBitRate = True
      Else
        VXCRSettings.blnShwLBitRate = False
    End If
    
    'Saves WMA BitRate Conversion
    If opt128.value = True Then
        VXCRSettings.lngWmaBitRate = 128000
    End If
    If opt160.value = True Then
        VXCRSettings.lngWmaBitRate = 160000
    End If
    If opt192.value = True Then
        VXCRSettings.lngWmaBitRate = 192000
    End If
    If opt256.value = True Then
        VXCRSettings.lngWmaBitRate = 256000
    End If
    If optSmart.value = True Then
        VXCRSettings.lngWmaBitRate = 0
    End If
    
    'Saves Settings to HDD
    SaveVXCRSettings
    
    'Unloads Option Dialog
    Unload Me
End Sub

Private Sub cmdSelectAll_Click()
    
    'Selects All items
    Me.chkMp1.value = 1
    Me.chkMp2.value = 1
    Me.chkMP3.value = 1
    Me.chkOGG.value = 1
    Me.chkWAV.value = 1
    Me.chkWMA.value = 1
    
End Sub

Public Sub cmdSelFld_Click()
    
    'Shows the Folder Dialog
    txtTempFld.text = SelectFolder
    
End Sub

Private Sub cmdUnselect_Click()
    
    'UnSelects All items
    Me.chkMp1.value = 0
    Me.chkMp2.value = 0
    Me.chkMP3.value = 0
    Me.chkOGG.value = 0
    Me.chkWAV.value = 0
    Me.chkWMA.value = 0
    
End Sub

Private Sub Form_Load()
    On Error Resume Next
    
    'Loads Option List
    lvOptions.ListItems.Add , , "  General"
    lvOptions.ListItems.Add , , "  Formats"
    lvOptions.ListItems.Add , , "  Virtual Drive"
    lvOptions.ListItems.Add , , "  CD Ripper"
    lvOptions.ListItems.Add , , "  ID Tags"
    
    'Declares Memory Varibles
    Dim lngA As Long
    Dim strPhase() As String
       
    'Loads Formats (x,x,x) into Array
    strPhase = Split(VXCRSettings.strSFormats, ",")
    
    'Loops Through each Format
    For lngA = 0 To UBound(strPhase)
        DoEvents
        
        'Enables Formats if Found
        Select Case strPhase(lngA)
            Case "mp3"
                chkMP3.value = 1
            Case "mp2"
                chkMp2.value = 1
            Case "mp1"
                chkMp1.value = 1
            Case "ogg"
                chkOGG.value = 1
            Case "wma"
                chkWMA.value = 1
            Case "wav"
                chkWAV.value = 1
            
        End Select
    Next lngA
    
    'Loads Auto Connect Stuff
    If VXCRSettings.strAutoCIP <> 0 Then
        Me.chkAutoConnect.value = 1
        Me.txtIP.text = VXCRSettings.strAutoCIP
    End If
        
    'Loads IDTag Stuff
    Select Case VXCRSettings.intIDStuff
        Case 1
            Me.optFileName.value = True     'Show FileName
        Case 2
            Me.optIDstuff(0).value = True   'Title from IDTag Only
        Case 3
            Me.optIDstuff(1).value = True   'Artist - Title from IDTag
    End Select
       
    'Loads Manually Enter IDtag
    If VXCRSettings.blnManuIDTag = True Then
        Me.chkManualName.value = 1
      Else
        Me.chkManualName.value = 0
    End If
    
    'Loads Temp Folder Settings
    txtTempFld.text = VXCRSettings.strTempFld
    
    'Loads (enabled BitRate)
    If VXCRSettings.blnShwLBitRate = True Then
        Me.chkShowLocalBitrate.value = 1
      Else
        Me.chkShowLocalBitrate.value = 2
    End If
    
    'Loads WMA BitRate
    Select Case VXCRSettings.lngWmaBitRate
        Case 128000
            opt128.value = True
        Case 160000
            opt160.value = True
        Case 192000
            opt192.value = True
        Case 256000
            opt256.value = True
        Case 0
            optSmart.value = True
    End Select
        
End Sub

Private Sub lvOptions_Click()
    
    'Selects Which Button was pressed
    Select Case Trim(lvOptions.SelectedItem.text)
        
        Case "General"
            SSTab.Tab = 0
            
        Case "Formats"
            SSTab.Tab = 1
            
        Case "Virtual Drive"
            SSTab.Tab = 2
            
        Case "CD Ripper"
            SSTab.Tab = 3
            
        Case "ID Tags"
            SSTab.Tab = 4
            
    End Select
End Sub

Public Function fGetSpecialFolder(CSIDL As Long) As String
    
    'Declares Memory Varibles
    Dim sPath As String
    Dim IDL As ITEMIDLIST
    
    fGetSpecialFolder = ""
    If SHGetSpecialFolderLocation(frmMain.hWnd, CSIDL, IDL) = 0 Then
       
        sPath = Space$(MAX_PATH)
        If SHGetPathFromIDList(ByVal IDL.mkid.cb, ByVal sPath) Then
            fGetSpecialFolder = Left$(sPath, InStr(sPath, vbNullChar) - 1) & "\"
        End If
    End If
    
End Function

Public Function SelectFolder()
   
    'Declares Memory Varibles
    Dim lpIDList As Long
    Dim sBuffer As String
    Dim szTitle As String
    Dim tBrowseInfo As BrowseInfo

    szTitle = "Select Folder"
    With tBrowseInfo
        .hWndOwner = frmOptions.hWnd
        .lpszTitle = lstrcat(szTitle, "")
        .ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN
    End With

    lpIDList = SHBrowseForFolder(tBrowseInfo)

    If (lpIDList) Then
        sBuffer = Space(MAX_PATH)
        SHGetPathFromIDList lpIDList, sBuffer
        sBuffer = Left(sBuffer, InStr(sBuffer, vbNullChar) - 1)
        SelectFolder = sBuffer & "\"
    End If
         
End Function



