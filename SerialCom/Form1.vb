Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel


Public Class Form1
    '------------------------------------------------
    Dim myPort As Array
    Dim num As Integer = 1
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data
    '------------------------------------------------
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myPort)

        ButtonWrite.Enabled = False
        ButtonTest.Enabled = False
        ButtonStop.Enabled = False
        ButtonZero.Enabled = False

    End Sub
    '------------------------------------------------
    Private Sub ComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ComboBox1.Click
    End Sub
    '------------------------------------------------
    Private Sub ButtonInit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonInit.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.StopBits = 1

        SerialPort1.Open()
        ButtonInit.Enabled = False
        ButtonWrite.Enabled = True
        ButtonClose.Enabled = True
        ButtonTest.Enabled = True
        ButtonStop.Enabled = True
        ButtonZero.Enabled = True

    End Sub
    '------------------------------------------------
    Private Sub ButtonWrite_Click(sender As System.Object, e As System.EventArgs) Handles ButtonWrite.Click

        SerialPort1.Write(RichTextBox1.Text & vbCr) 'concatenate with \n
    End Sub

    Private Sub ButtonClose_Click(sender As System.Object, e As System.EventArgs) Handles ButtonClose.Click
        ButtonInit.Enabled = True
        ButtonWrite.Enabled = False
        ButtonClose.Enabled = False
        ButtonTest.Enabled = False
        ButtonStop.Enabled = False
        ButtonZero.Enabled = False
        SerialPort1.Close()
    End Sub

    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())

    End Sub

    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        If Me.RichTextBox2.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.RichTextBox2.Text &= [text] 'append text
        End If
    End Sub

    Private Sub ReceivedTextToStatus(ByVal [text] As String) 'input from ReadExisting
        Me.ToolStripStatusLabel1.Text &= [text]
    End Sub


    Private Sub ButtonTest_Click(sender As System.Object, e As System.EventArgs) Handles ButtonTest.Click
        SerialPort1.Write("M1 +10" & vbCr)
        Threading.Thread.Sleep(1000)
        SerialPort1.Write("M2 +10" & vbCr)
        Threading.Thread.Sleep(1000)
        SerialPort1.Write("M3 +0.03" & vbCr)

        Threading.Thread.Sleep(1000)
        SerialPort1.Write("M2 -10" & vbCr)
        Threading.Thread.Sleep(1000)
        SerialPort1.Write("M3 -0.03" & vbCr)
        Threading.Thread.Sleep(500)
        SerialPort1.Write("M2 +10" & vbCr)
        Threading.Thread.Sleep(500)
        SerialPort1.Write("M2 -10" & vbCr)

        Threading.Thread.Sleep(4000)
        SerialPort1.Write("M1 -10" & vbCr)
    End Sub

    Private Sub ButtonZero_Click(sender As Object, e As EventArgs) Handles ButtonZero.Click
        SerialPort1.Write("H1" & vbCr)
        Threading.Thread.Sleep(1000)
        SerialPort1.Write("H2" & vbCr)
        Threading.Thread.Sleep(1000)
        SerialPort1.Write("H3" & vbCr)
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        SerialPort1.Write("e" & vbCr)
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub ButtonTest2_Click(sender As Object, e As EventArgs) Handles ButtonTest2.Click
        num += 1
        Me.ToolStripStatusLabel1.Text = "Status: " + CStr(num + 1)
        Me.ToolStripStatusLabel2.Text = "M1: " + CStr(num + 2)
        Me.ToolStripStatusLabel3.Text = "M2: " + CStr(num + 3)
        Me.ToolStripStatusLabel4.Text = "M3: " + CStr(num + 4)



    End Sub
End Class
