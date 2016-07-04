<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_Class1_Batch
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
        Me.btn_new_Class1 = New System.Windows.Forms.Button
        Me.btn_Cancle = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Select_Class2 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'btn_new_Class1
        '
        Me.btn_new_Class1.Location = New System.Drawing.Point(173, 34)
        Me.btn_new_Class1.Name = "btn_new_Class1"
        Me.btn_new_Class1.Size = New System.Drawing.Size(69, 28)
        Me.btn_new_Class1.TabIndex = 9
        Me.btn_new_Class1.Text = "新增分类"
        Me.btn_new_Class1.UseVisualStyleBackColor = True
        '
        'btn_Cancle
        '
        Me.btn_Cancle.Location = New System.Drawing.Point(171, 172)
        Me.btn_Cancle.Name = "btn_Cancle"
        Me.btn_Cancle.Size = New System.Drawing.Size(69, 28)
        Me.btn_Cancle.TabIndex = 8
        Me.btn_Cancle.Text = "放弃"
        Me.btn_Cancle.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(171, 126)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(69, 28)
        Me.btn_OK.TabIndex = 7
        Me.btn_OK.Text = "确定"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Select_Class2
        '
        Me.btn_Select_Class2.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_Select_Class2.Location = New System.Drawing.Point(171, 80)
        Me.btn_Select_Class2.Name = "btn_Select_Class2"
        Me.btn_Select_Class2.Size = New System.Drawing.Size(69, 28)
        Me.btn_Select_Class2.TabIndex = 6
        Me.btn_Select_Class2.Text = "再选分类二"
        Me.btn_Select_Class2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(25, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(131, 184)
        Me.ListBox1.TabIndex = 5
        '
        'Change_Class1_Batch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 233)
        Me.Controls.Add(Me.btn_new_Class1)
        Me.Controls.Add(Me.btn_Cancle)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Select_Class2)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Change_Class1_Batch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "选择分类一（批量）"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_new_Class1 As System.Windows.Forms.Button
    Friend WithEvents btn_Cancle As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Select_Class2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
