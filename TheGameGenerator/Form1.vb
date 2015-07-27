﻿Imports Serilog
Imports System.Runtime.InteropServices
Public Class Form1
    Dim Data As New Database

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Win32.AllocConsole()
        Me.BringToFront()
        Log.Logger = (New LoggerConfiguration).WriteTo.LiterateConsole.MinimumLevel.Verbose.CreateLogger()
        Log.Information("Form1_Load")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
''' <summary>
''' Used to Show console for logging and debugging
''' </summary>
''' <remarks></remarks>
Public Class Win32
    <DllImport("kernel32.dll")>
    Public Shared Function AllocConsole() As Boolean
    End Function
End Class