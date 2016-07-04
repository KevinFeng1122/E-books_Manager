<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClass_Edit_Information
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_File_Path = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox_Guess_Method = New System.Windows.Forms.ComboBox
        Me.btn_Guess = New System.Windows.Forms.Button
        Me.btn_Previous = New System.Windows.Forms.Button
        Me.btn_Next = New System.Windows.Forms.Button
        Me.btn_Save_and_Close = New System.Windows.Forms.Button
        Me.btn_Cancle = New System.Windows.Forms.Button
        Me.txt_Author = New System.Windows.Forms.TextBox
        Me.txt_Book_Name = New System.Windows.Forms.TextBox
        Me.ComboBox_Class2 = New System.Windows.Forms.ComboBox
        Me.ComboBox_Class1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "文件路径："
        '
        'txt_File_Path
        '
        Me.txt_File_Path.Location = New System.Drawing.Point(81, 17)
        Me.txt_File_Path.Name = "txt_File_Path"
        Me.txt_File_Path.ReadOnly = True
        Me.txt_File_Path.Size = New System.Drawing.Size(376, 21)
        Me.txt_File_Path.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "按如下方式从路径猜测书名和作者"
        '
        'ComboBox_Guess_Method
        '
        Me.ComboBox_Guess_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Guess_Method.FormattingEnabled = True
        Me.ComboBox_Guess_Method.Items.AddRange(New Object() {"书名+作者", "作者+书名", "书名"})
        Me.ComboBox_Guess_Method.Location = New System.Drawing.Point(221, 34)
        Me.ComboBox_Guess_Method.Name = "ComboBox_Guess_Method"
        Me.ComboBox_Guess_Method.Size = New System.Drawing.Size(127, 20)
        Me.ComboBox_Guess_Method.TabIndex = 0
        '
        'btn_Guess
        '
        Me.btn_Guess.Location = New System.Drawing.Point(379, 31)
        Me.btn_Guess.Name = "btn_Guess"
        Me.btn_Guess.Size = New System.Drawing.Size(50, 23)
        Me.btn_Guess.TabIndex = 4
        Me.btn_Guess.Text = "GO！"
        Me.btn_Guess.UseVisualStyleBackColor = True
        '
        'btn_Previous
        '
        Me.btn_Previous.Location = New System.Drawing.Point(32, 295)
        Me.btn_Previous.Name = "btn_Previous"
        Me.btn_Previous.Size = New System.Drawing.Size(77, 30)
        Me.btn_Previous.TabIndex = 15
        Me.btn_Previous.Text = "上一项"
        Me.btn_Previous.UseVisualStyleBackColor = True
        '
        'btn_Next
        '
        Me.btn_Next.Location = New System.Drawing.Point(140, 295)
        Me.btn_Next.Name = "btn_Next"
        Me.btn_Next.Size = New System.Drawing.Size(77, 30)
        Me.btn_Next.TabIndex = 16
        Me.btn_Next.Text = "下一项"
        Me.btn_Next.UseVisualStyleBackColor = True
        '
        'btn_Save_and_Close
        '
        Me.btn_Save_and_Close.Location = New System.Drawing.Point(248, 295)
        Me.btn_Save_and_Close.Name = "btn_Save_and_Close"
        Me.btn_Save_and_Close.Size = New System.Drawing.Size(77, 30)
        Me.btn_Save_and_Close.TabIndex = 17
        Me.btn_Save_and_Close.Text = "保存"
        Me.btn_Save_and_Close.UseVisualStyleBackColor = True
        '
        'btn_Cancle
        '
        Me.btn_Cancle.Location = New System.Drawing.Point(356, 295)
        Me.btn_Cancle.Name = "btn_Cancle"
        Me.btn_Cancle.Size = New System.Drawing.Size(77, 30)
        Me.btn_Cancle.TabIndex = 18
        Me.btn_Cancle.Text = "放弃"
        Me.btn_Cancle.UseVisualStyleBackColor = True
        '
        'txt_Author
        '
        Me.txt_Author.Location = New System.Drawing.Point(317, 79)
        Me.txt_Author.Name = "txt_Author"
        Me.txt_Author.Size = New System.Drawing.Size(110, 21)
        Me.txt_Author.TabIndex = 26
        '
        'txt_Book_Name
        '
        Me.txt_Book_Name.Location = New System.Drawing.Point(60, 79)
        Me.txt_Book_Name.Name = "txt_Book_Name"
        Me.txt_Book_Name.Size = New System.Drawing.Size(184, 21)
        Me.txt_Book_Name.TabIndex = 25
        '
        'ComboBox_Class2
        '
        Me.ComboBox_Class2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Class2.FormattingEnabled = True
        Me.ComboBox_Class2.Location = New System.Drawing.Point(290, 27)
        Me.ComboBox_Class2.Name = "ComboBox_Class2"
        Me.ComboBox_Class2.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox_Class2.TabIndex = 24
        '
        'ComboBox_Class1
        '
        Me.ComboBox_Class1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Class1.FormattingEnabled = True
        Me.ComboBox_Class1.Location = New System.Drawing.Point(78, 27)
        Me.ComboBox_Class1.Name = "ComboBox_Class1"
        Me.ComboBox_Class1.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox_Class1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(219, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "二级分类："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "一级分类："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "作者："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "书名："
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Author)
        Me.GroupBox1.Controls.Add(Me.txt_Book_Name)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btn_Guess)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Guess_Method)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 127)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "书名与作者"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox_Class2)
        Me.GroupBox2.Controls.Add(Me.ComboBox_Class1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 206)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 5, 3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 70)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "分类"
        '
        'frmClass_Edit_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 349)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Cancle)
        Me.Controls.Add(Me.btn_Save_and_Close)
        Me.Controls.Add(Me.btn_Next)
        Me.Controls.Add(Me.btn_Previous)
        Me.Controls.Add(Me.txt_File_Path)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmClass_Edit_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "编辑信息（逐项操作）"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_File_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Guess_Method As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Guess As System.Windows.Forms.Button
    Friend WithEvents btn_Previous As System.Windows.Forms.Button
    Friend WithEvents btn_Next As System.Windows.Forms.Button
    Friend WithEvents btn_Save_and_Close As System.Windows.Forms.Button
    Friend WithEvents btn_Cancle As System.Windows.Forms.Button
    Friend WithEvents txt_Author As System.Windows.Forms.TextBox
    Friend WithEvents txt_Book_Name As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_Class2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Class1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
