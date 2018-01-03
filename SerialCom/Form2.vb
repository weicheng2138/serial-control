Public Class FormSpeed

    Dim serialport As System.IO.Ports.SerialPort

    Public Sub New(ByVal serialportInput As System.IO.Ports.SerialPort)
        InitializeComponent()
        Me.serialport = serialportInput

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If RichTextBoxM11.Text IsNot Nothing Then
            serialport.Write("V1 " + RichTextBoxM11.Text & vbCr)
            Threading.Thread.Sleep(100)
        End If

        If RichTextBoxM22.Text IsNot Nothing Then
            serialport.Write("V2 " + RichTextBoxM22.Text & vbCr)
            Threading.Thread.Sleep(100)
        End If

        If RichTextBoxM33.Text IsNot Nothing Then
            serialport.Write("V3 " + RichTextBoxM33.Text & vbCr)
            Threading.Thread.Sleep(100)
        End If
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
End Class