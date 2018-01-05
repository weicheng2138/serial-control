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

    'Normal sequence
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myPort)

        ButtonInit.Enabled = False
        ButtonWrite.Enabled = False
        ButtonTest.Enabled = False
        ButtonStop.Enabled = False
        ButtonZero.Enabled = False
        ButtonClose.Enabled = False
        ButtonM1.Enabled = False
        ButtonM2.Enabled = False
        ButtonM3.Enabled = False
        ButtonLink.Enabled = False
        ComboBox2.Enabled = False

        ButtonInit.BackColor = Color.Silver
        ButtonWrite.BackColor = Color.Silver
        ButtonTest.BackColor = Color.Silver
        ButtonStop.BackColor = Color.Silver
        ButtonZero.BackColor = Color.Silver
        ButtonClose.BackColor = Color.Silver
        ButtonM1.BackColor = Color.Silver
        ButtonM2.BackColor = Color.Silver
        ButtonM3.BackColor = Color.Silver
        ButtonLink.BackColor = Color.Silver
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ButtonInit.Enabled = True
        ButtonInit.BackColor = Color.LimeGreen
    End Sub
    Private Sub ButtonInit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonInit.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.StopBits = 1

        SerialPort1.Open()
        ButtonInit.Enabled = False
        ButtonLink.Enabled = True
        ComboBox1.Enabled = False

        ButtonInit.BackColor = Color.Silver
        ButtonLink.BackColor = Color.LimeGreen

    End Sub
    Private Sub ButtonLink_Click(sender As Object, e As EventArgs) Handles ButtonLink.Click
        SerialPort1.Write("L" & vbCr)
        Threading.Thread.Sleep(1000)

        ButtonWrite.Enabled = True
        ButtonClose.Enabled = False
        ButtonTest.Enabled = True
        ButtonStop.Enabled = True
        ButtonZero.Enabled = True
        ButtonM1.Enabled = True
        ButtonM2.Enabled = True
        ButtonM3.Enabled = True
        ButtonLink.Enabled = False

        ButtonWrite.BackColor = Color.LimeGreen

        ButtonStop.BackColor = Color.OrangeRed
        ButtonWrite.BackColor = Color.LimeGreen
        ButtonTest.BackColor = Color.LimeGreen
        ButtonZero.BackColor = Color.LimeGreen
        ButtonClose.BackColor = Color.Silver
        ButtonM1.BackColor = Color.LimeGreen
        ButtonM2.BackColor = Color.LimeGreen
        ButtonM3.BackColor = Color.LimeGreen
        ButtonLink.BackColor = Color.Silver
    End Sub
    Private Sub ButtonWrite_Click(sender As System.Object, e As System.EventArgs) Handles ButtonWrite.Click
        SerialPort1.Write(RichTextBox1.Text & vbCr) 'concatenate with \n
    End Sub
    Private Sub ButtonZero_Click(sender As Object, e As EventArgs) Handles ButtonZero.Click
        ButtonClose.Enabled = True
        ButtonClose.BackColor = Color.LimeGreen

        SerialPort1.Write("H1" & vbCr)
        Threading.Thread.Sleep(200)
        SerialPort1.Write("H2" & vbCr)
        Threading.Thread.Sleep(200)
        SerialPort1.Write("H3" & vbCr)
        Threading.Thread.Sleep(200)
    End Sub
    Private Sub ButtonClose_Click(sender As System.Object, e As System.EventArgs) Handles ButtonClose.Click
        ButtonInit.Enabled = True
        ButtonWrite.Enabled = False
        ButtonClose.Enabled = False
        ButtonTest.Enabled = False
        ButtonStop.Enabled = False
        ButtonZero.Enabled = False
        ButtonM1.Enabled = False
        ButtonM2.Enabled = False
        ButtonM3.Enabled = False
        ButtonLink.Enabled = False
        ComboBox1.Enabled = True

        ButtonInit.BackColor = Color.LimeGreen
        ButtonWrite.BackColor = Color.Silver

        ButtonStop.BackColor = Color.Silver
        ButtonWrite.BackColor = Color.Silver
        ButtonTest.BackColor = Color.Silver
        ButtonZero.BackColor = Color.Silver
        ButtonClose.BackColor = Color.Silver
        ButtonM1.BackColor = Color.Silver
        ButtonM2.BackColor = Color.Silver
        ButtonM3.BackColor = Color.Silver
        ButtonLink.BackColor = Color.Silver

        SerialPort1.Close()
    End Sub

    'Serialport data handling
    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub
    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        If Me.RichTextBox2.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.RichTextBox2.Text &= [text] 'append text
            Me.RichTextBox2.SelectionStart = Me.RichTextBox2.TextLength
            Me.RichTextBox2.ScrollToCaret()
        End If
    End Sub
    Private Sub ReceivedTextToStatus(ByVal [text] As String) 'input from ReadExisting
        Me.ToolStripStatusLabel1.Text &= [text]
    End Sub

    'Test button section
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
    Private Sub ButtonTest2_Click(sender As Object, e As EventArgs) Handles ButtonTest2.Click
        num += 1
        Me.ToolStripStatusLabel1.Text = "Status: " + CStr(num + 1)
        Me.ToolStripStatusLabel2.Text = "M1: " + CStr(num + 2)
        Me.ToolStripStatusLabel3.Text = "M2: " + CStr(num + 3)
        Me.ToolStripStatusLabel4.Text = "M3: " + CStr(num + 4)
    End Sub
    Private Sub ButtonTest3_Click(sender As Object, e As EventArgs) Handles ButtonTest3.Click
        Me.RichTextBox2.Text &= "QQQQQQQQQQQQQQQQ" 'append text
        Me.RichTextBox2.AppendText(Environment.NewLine)
        Me.RichTextBox2.SelectionStart = Me.RichTextBox2.TextLength
        Me.RichTextBox2.ScrollToCaret()
    End Sub

    'Menu item section
    Private Sub SpeedMenuItem_Click(sender As Object, e As EventArgs) Handles SpeedMenuItem.Click
        ShowSpeedSetingDialogBox()
    End Sub
    Private Sub LoadStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadStripMenuItem.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim content As String
        openFileDialog1.Filter = "Txt Files|*.txt"
        openFileDialog1.Title = "Select a Txt File"

        ' Show the Dialog.
        ' If the user clicked OK in the dialog and 
        ' a .CUR file was selected, open it.
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using SR As New System.IO.StreamReader(openFileDialog1.FileName)
                Dim firstline As String = SR.ReadLine
                'your code here for first line
                MsgBox(firstline)


            End Using 'closes file
        End If
    End Sub

    'One step machine controling section
    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        SerialPort1.Write("e" & vbCr)
        Threading.Thread.Sleep(1000)
    End Sub
    Private Sub ButtonM1_Click(sender As Object, e As EventArgs) Handles ButtonM1.Click
        SerialPort1.Write("M1 " + RichTextBoxM1.Text & vbCr)
        Threading.Thread.Sleep(100)
    End Sub

    Private Sub ButtonM2_Click(sender As Object, e As EventArgs) Handles ButtonM2.Click
        SerialPort1.Write("M2 " + RichTextBoxM2.Text & vbCr)
        Threading.Thread.Sleep(100)
    End Sub

    Private Sub ButtonM3_Click(sender As Object, e As EventArgs) Handles ButtonM3.Click
        SerialPort1.Write("M3 " + RichTextBoxM3.Text & vbCr)
        Threading.Thread.Sleep(100)
    End Sub

    Public Sub ShowSpeedSetingDialogBox()
        Dim speedSetingDialog As New FormSpeed(SerialPort1)
        speedSetingDialog.ShowDialog()
    End Sub

    'TODO X-Axis listening

End Class
