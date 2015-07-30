Imports Serilog
Imports System.Runtime.InteropServices
Public Class Form1
    Dim Data As New Database

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NativeMethods.AllocateConsole() 'Remove in production
        Me.BringToFront()
        Dim logfile As String = My.Computer.FileSystem.GetTempFileName()
        Log.Logger = (New LoggerConfiguration).WriteTo.LiterateConsole.WriteTo.File(logfile).MinimumLevel.Debug.CreateLogger()
        Log.Debug("Writing log to {logfile}", logfile)
        Log.Information("TheGameGenerator version {version}", My.Application.Info.Version.ToString)
        ''UPDATES propably not necessary
        'Log.Information("Checking for update")
        'Dim info = My.Application.Deployment.CheckForDetailedUpdate()
        'If info.UpdateAvailable Then
        '    Log.Information("Updating to {version} ({size} bytes)", info.AvailableVersion, info.UpdateSizeBytes)
        '    Log.Debug("Update info {@info}", info)
        '    If My.Application.Deployment.Update() Then
        '        Log.Information("Update to {version} succeeded!", info.AvailableVersion)
        '    Else
        '        Log.Fatal("Update failed: {@info}", info)
        '    End If
        'Else
        '    Log.Information("No update found!")
        'End If
        Me.Text = "TheGameGenerator " & My.Application.Info.Version.ToString
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
        Data.GenerateGPUPairs(0)
    End Sub
End Class
''' <summary>
''' Used to Show console for logging and debugging
''' </summary>
''' <remarks></remarks>
Public Class NativeMethods
    <DllImport("kernel32.dll")>
    Private Shared Function AllocConsole() As Boolean
    End Function
    Public Shared Sub AllocateConsole()
        AllocConsole()
    End Sub
End Class