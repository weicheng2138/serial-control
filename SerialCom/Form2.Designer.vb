<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSpeed
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RichTextBoxM33 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxM22 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxM11 = New System.Windows.Forms.RichTextBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(42, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 20)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "M3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(42, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 20)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "M2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(42, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 20)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "M1"
        '
        'RichTextBoxM33
        '
        Me.RichTextBoxM33.BackColor = System.Drawing.Color.White
        Me.RichTextBoxM33.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxM33.Location = New System.Drawing.Point(79, 130)
        Me.RichTextBoxM33.Name = "RichTextBoxM33"
        Me.RichTextBoxM33.Size = New System.Drawing.Size(124, 28)
        Me.RichTextBoxM33.TabIndex = 30
        Me.RichTextBoxM33.Text = ""
        '
        'RichTextBoxM22
        '
        Me.RichTextBoxM22.BackColor = System.Drawing.Color.White
        Me.RichTextBoxM22.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxM22.Location = New System.Drawing.Point(79, 82)
        Me.RichTextBoxM22.Name = "RichTextBoxM22"
        Me.RichTextBoxM22.Size = New System.Drawing.Size(124, 28)
        Me.RichTextBoxM22.TabIndex = 31
        Me.RichTextBoxM22.Text = ""
        '
        'RichTextBoxM11
        '
        Me.RichTextBoxM11.BackColor = System.Drawing.Color.White
        Me.RichTextBoxM11.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxM11.Location = New System.Drawing.Point(79, 32)
        Me.RichTextBoxM11.Name = "RichTextBoxM11"
        Me.RichTextBoxM11.Size = New System.Drawing.Size(124, 28)
        Me.RichTextBoxM11.TabIndex = 32
        Me.RichTextBoxM11.Text = ""
        '
        'ButtonOK
        '
        Me.ButtonOK.BackColor = System.Drawing.Color.LimeGreen
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOK.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonOK.ForeColor = System.Drawing.SystemColors.Window
        Me.ButtonOK.Location = New System.Drawing.Point(233, 32)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(91, 61)
        Me.ButtonOK.TabIndex = 33
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonOK.UseVisualStyleBackColor = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.LimeGreen
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonCancel.ForeColor = System.Drawing.SystemColors.Window
        Me.ButtonCancel.Location = New System.Drawing.Point(233, 99)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(91, 59)
        Me.ButtonCancel.TabIndex = 34
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'FormSpeed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 205)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.RichTextBoxM11)
        Me.Controls.Add(Me.RichTextBoxM22)
        Me.Controls.Add(Me.RichTextBoxM33)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Name = "FormSpeed"
        Me.Text = "FormSpeed"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RichTextBoxM33 As RichTextBox
    Friend WithEvents RichTextBoxM22 As RichTextBox
    Friend WithEvents RichTextBoxM11 As RichTextBox
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
End Class
