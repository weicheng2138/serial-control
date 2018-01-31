Imports System.ComponentModel

'TODO Real time update the machine status
Public Class Form1
    '------------------------------------------------
    Dim myPort As Array
    Dim num As Integer = 1
    Dim tempCommand As String = ""
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

        'Test 
        DataGridView1.Rows.Add("M1", "+1000", True)
        DataGridView1.Rows.Add("M2", "-1000", True)
        DataGridView1.Rows.Add("M3", "+100", True)
        DataGridView1.Rows.Add("Delay", "1000ms", False)


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
        tempCommand = "L"
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

        'SerialPort1.Write("Q" & vbCr)
    End Sub
    Private Sub ButtonWrite_Click(sender As System.Object, e As System.EventArgs) Handles ButtonWrite.Click
        SerialPort1.Write(RichTextBox1.Text & vbCr) 'concatenate with \n
        Dim pattern As Char() = New Char() {" "c}
        Dim target As String() = RichTextBox1.Text.Split(pattern, StringSplitOptions.RemoveEmptyEntries)
        tempCommand = target.First
        'Me.RichTextBox2.Text &= tempCommand
        'Me.RichTextBox2.AppendText(Environment.NewLine)
        'Me.RichTextBox2.SelectionStart = Me.RichTextBox2.TextLength
        'Me.RichTextBox2.ScrollToCaret()
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

            If Me.RichTextBox2.Text.EndsWith(vbLf) Then
                Dim pattern1 As Char() = New Char() {vbLf}
                Dim lastReceivedData As String = Me.RichTextBox2.Text.Split(pattern1, StringSplitOptions.RemoveEmptyEntries).Last

                'Me.RichTextBox2.Text &= lastReceivedData  'append text
                'Me.RichTextBox2.AppendText(Environment.NewLine)
                Me.RichTextBox2.SelectionStart = Me.RichTextBox2.TextLength
                Me.RichTextBox2.ScrollToCaret()


                Select Case lastReceivedData.First
                    Case Nothing
                    Case "E"
                        Me.ToolStripStatusLabel1.Text = "Status: " + "E"
                    Case "C"
                        Me.ToolStripStatusLabel1.Text = "Status: " + "C"
                    Case "G"
                        Me.ToolStripStatusLabel1.Text = "Status: " + "G"
                        'SerialPort1.Write("Q" & vbCr)

                        Dim data As Double = Convert.ToInt32(lastReceivedData.Substring(2), 16) / 1000
                        Select Case tempCommand
                            Case "M1"
                                Me.ToolStripStatusLabel2.Text = "M1: " + GetChar(lastReceivedData, 2) + data.ToString
                            Case "M2"
                                Me.ToolStripStatusLabel3.Text = "M2: " + GetChar(lastReceivedData, 2) + (data * 10).ToString
                            Case "M3"
                                Me.ToolStripStatusLabel4.Text = "M3: " + GetChar(lastReceivedData, 2) + data.ToString
                            Case Else
                                MsgBox("Current Command is..." + lastReceivedData + "..." + tempCommand)
                        End Select
                    Case "+"
                        Dim pattern2 As Char() = New Char() {" "c}
                        Dim target As String() = lastReceivedData.Split(pattern2, StringSplitOptions.RemoveEmptyEntries)

                        Me.ToolStripStatusLabel2.Text = "M1: " + target(0)
                        Me.ToolStripStatusLabel3.Text = "M2: " + target(1)
                        Me.ToolStripStatusLabel4.Text = "M3: " + target(2)
                    Case Else
                        MsgBox("Command not exist...", 0 + 48)
                End Select



            End If






        End If
    End Sub


    'Three-axis machine status


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
        Dim text As String = "+000.016 +0000.00 +000.220"

        ReceivedText(TextBox1.Text)
    End Sub
    Private Sub ButtonTest3_Click(sender As Object, e As EventArgs) Handles ButtonTest3.Click
        Dim sAttr As Double = My.Settings.M2
        MsgBox(My.Settings.M1)
        Threading.Thread.Sleep(2000)
        My.Settings.M1 = 100
        MsgBox(My.Settings.M1)
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
        ' a .txt file was selected, open it.
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim fileReader As String

            fileReader = My.Computer.FileSystem.ReadAllText(openFileDialog1.FileName)
            MsgBox(My.Computer.FileSystem.CurrentDirectory)


        End If
    End Sub

    'One step machine controling section
    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        SerialPort1.Write("e" & vbCr)
        Threading.Thread.Sleep(1000)
        tempCommand = "e"
    End Sub
    Private Sub ButtonM1_Click(sender As Object, e As EventArgs) Handles ButtonM1.Click
        SerialPort1.Write("M1 " + RichTextBoxM1.Text & vbCr)
        Threading.Thread.Sleep(100)
        tempCommand = "M1"
    End Sub
    Private Sub ButtonM2_Click(sender As Object, e As EventArgs) Handles ButtonM2.Click
        SerialPort1.Write("M2 " + RichTextBoxM2.Text & vbCr)
        Threading.Thread.Sleep(100)
        tempCommand = "M2"
    End Sub
    Private Sub ButtonM3_Click(sender As Object, e As EventArgs) Handles ButtonM3.Click
        SerialPort1.Write("M3 " + RichTextBoxM3.Text & vbCr)
        Threading.Thread.Sleep(100)
        tempCommand = "M3"
    End Sub

    Public Sub ShowSpeedSetingDialogBox()
        Dim speedSetingDialog As New FormSpeed(SerialPort1)
        speedSetingDialog.ShowDialog()
    End Sub


    'TODO X-Axis listening


    'Tab of Scripts for sequencing controling
    Private Sub DataGridView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        'Works with both buttons
        If e.Button = Windows.Forms.MouseButtons.Right And DataGridView1.Rows.Count > 0 Then
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub
    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        DataGridView1.Rows.Clear()
    End Sub
    Private Sub ButtonSelectAll_Click(sender As Object, e As EventArgs) Handles ButtonSelectAll.Click
        DataGridView1.SelectAll()
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
    End Sub

End Class
