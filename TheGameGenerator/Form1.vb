Imports Serilog
Imports System.Runtime.InteropServices
Public Class Form1
    Dim Data As New Database

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Win32.AllocConsole() 'Remove in production
        Me.BringToFront()
        Log.Logger = (New LoggerConfiguration).WriteTo.LiterateConsole.MinimumLevel.Debug.CreateLogger()
        Log.Information("Form1_Load")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        For Each v In Data.GetAllItems
            Log.Information("Item: {@Item}", v)
        Next
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Data.GenerateMB_CPUPairs()
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