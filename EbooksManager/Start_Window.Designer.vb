<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart_Window
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart_Window))
        Me.btnSet_Directory = New System.Windows.Forms.Button
        Me.btnView_Information = New System.Windows.Forms.Button
        Me.btnUpdate_Information = New System.Windows.Forms.Button
        Me.btnBooklist = New System.Windows.Forms.Button
        Me.btnView_Recent_Files = New System.Windows.Forms.Button
        Me.btnHelp = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnExit_Program = New System.Windows.Forms.Button
        Me.btnMinimize = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnSet_Directory
        '
        Me.btnSet_Directory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSet_Directory.Image = CType(resources.GetObject("btnSet_Directory.Image"), System.Drawing.Image)
        Me.btnSet_Directory.Location = New System.Drawing.Point(74, 136)
        Me.btnSet_Directory.Name = "btnSet_Directory"
        Me.btnSet_Directory.Size = New System.Drawing.Size(97, 95)
        Me.btnSet_Directory.TabIndex = 0
        Me.btnSet_Directory.UseVisualStyleBackColor = True
        '
        'btnView_Information
        '
        Me.btnView_Information.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnView_Information.Image = CType(resources.GetObject("btnView_Information.Image"), System.Drawing.Image)
        Me.btnView_Information.Location = New System.Drawing.Point(209, 136)
        Me.btnView_Information.Name = "btnView_Information"
        Me.btnView_Information.Size = New System.Drawing.Size(97, 95)
        Me.btnView_Information.TabIndex = 1
        Me.btnView_Information.UseVisualStyleBackColor = True
        '
        'btnUpdate_Information
        '
        Me.btnUpdate_Information.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate_Information.Image = CType(resources.GetObject("btnUpdate_Information.Image"), System.Drawing.Image)
        Me.btnUpdate_Information.Location = New System.Drawing.Point(344, 136)
        Me.btnUpdate_Information.Name = "btnUpdate_Information"
        Me.btnUpdate_Information.Size = New System.Drawing.Size(97, 95)
        Me.btnUpdate_Information.TabIndex = 2
        Me.btnUpdate_Information.UseVisualStyleBackColor = True
        '
        'btnBooklist
        '
        Me.btnBooklist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBooklist.Image = CType(resources.GetObject("btnBooklist.Image"), System.Drawing.Image)
        Me.btnBooklist.Location = New System.Drawing.Point(74, 291)
        Me.btnBooklist.Name = "btnBooklist"
        Me.btnBooklist.Size = New System.Drawing.Size(97, 95)
        Me.btnBooklist.TabIndex = 3
        Me.btnBooklist.UseVisualStyleBackColor = True
        '
        'btnView_Recent_Files
        '
        Me.btnView_Recent_Files.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnView_Recent_Files.Image = CType(resources.GetObject("btnView_Recent_Files.Image"), System.Drawing.Image)
        Me.btnView_Recent_Files.Location = New System.Drawing.Point(209, 291)
        Me.btnView_Recent_Files.Name = "btnView_Recent_Files"
        Me.btnView_Recent_Files.Size = New System.Drawing.Size(97, 95)
        Me.btnView_Recent_Files.TabIndex = 4
        Me.btnView_Recent_Files.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(344, 291)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(97, 95)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightBlue
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(86, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "设置目录"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.Location = New System.Drawing.Point(221, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "浏览信息"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.Location = New System.Drawing.Point(356, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "更新信息"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.PowderBlue
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.Location = New System.Drawing.Point(78, 400)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "自定义书单"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(205, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "最近打开文档"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightBlue
        Me.Label6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.Location = New System.Drawing.Point(356, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "软件帮助"
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("隶书", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(39, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(457, 40)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "欢迎使用电子文档管理器"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExit_Program
        '
        Me.btnExit_Program.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnExit_Program.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit_Program.Font = New System.Drawing.Font("华文彩云", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnExit_Program.ForeColor = System.Drawing.Color.HotPink
        Me.btnExit_Program.Location = New System.Drawing.Point(488, 0)
        Me.btnExit_Program.Name = "btnExit_Program"
        Me.btnExit_Program.Size = New System.Drawing.Size(26, 25)
        Me.btnExit_Program.TabIndex = 7
        Me.btnExit_Program.Text = "×"
        Me.btnExit_Program.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimize.Font = New System.Drawing.Font("华文彩云", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnMinimize.ForeColor = System.Drawing.Color.HotPink
        Me.btnMinimize.Location = New System.Drawing.Point(465, 0)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(26, 25)
        Me.btnMinimize.TabIndex = 6
        Me.btnMinimize.Text = "－"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'frmStart_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(515, 478)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnExit_Program)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnView_Recent_Files)
        Me.Controls.Add(Me.btnBooklist)
        Me.Controls.Add(Me.btnUpdate_Information)
        Me.Controls.Add(Me.btnView_Information)
        Me.Controls.Add(Me.btnSet_Directory)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmStart_Window"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSet_Directory As System.Windows.Forms.Button
    Friend WithEvents btnView_Information As System.Windows.Forms.Button
    Friend WithEvents btnUpdate_Information As System.Windows.Forms.Button
    Friend WithEvents btnBooklist As System.Windows.Forms.Button
    Friend WithEvents btnView_Recent_Files As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExit_Program As System.Windows.Forms.Button
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip

End Class
