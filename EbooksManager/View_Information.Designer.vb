<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Information
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
        Dim ToolStripMenuItem_Change_Class As System.Windows.Forms.ToolStripMenuItem
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Information))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("按类别浏览", 1, 1)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("按作者浏览")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("按名称浏览", 3, 3)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("按添加日期浏览", 2, 2)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItem_large_icon = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_small_icon = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_list = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_details = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSplitButton2 = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.imglstTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.imglstListView_Large = New System.Windows.Forms.ImageList(Me.components)
        Me.imglstListView_Small = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Open = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Open_Directory = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Rename = New System.Windows.Forms.ToolStripMenuItem
        Me.名称作者ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.作者名称ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.名称ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Send_to = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Delete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Edit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Modify_Author = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Add_into_booklist = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem_Search_in_the_internet = New System.Windows.Forms.ToolStripMenuItem
        Me.全部勾选ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.取消勾选ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        ToolStripMenuItem_Change_Class = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenuItem_Change_Class
        '
        ToolStripMenuItem_Change_Class.Name = "ToolStripMenuItem_Change_Class"
        ToolStripMenuItem_Change_Class.Size = New System.Drawing.Size(160, 22)
        ToolStripMenuItem_Change_Class.Text = "更改分类"
        AddHandler ToolStripMenuItem_Change_Class.Click, AddressOf Me.ToolStripMenuItem_Change_Class_Click
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripComboBox1, Me.ToolStripLabel2, Me.ToolStripTextBox1, Me.ToolStripSplitButton2})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(902, 45)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(88, 21)
        Me.ToolStripButton1.Text = "返回总目录"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(170, 23)
        Me.ToolStripLabel1.Text = "共计有  项"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_large_icon, Me.ToolStripMenuItem_small_icon, Me.ToolStripMenuItem_list, Me.ToolStripMenuItem_details})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(85, 21)
        Me.ToolStripDropDownButton1.Text = "视图方式"
        '
        'ToolStripMenuItem_large_icon
        '
        Me.ToolStripMenuItem_large_icon.Image = CType(resources.GetObject("ToolStripMenuItem_large_icon.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_large_icon.Name = "ToolStripMenuItem_large_icon"
        Me.ToolStripMenuItem_large_icon.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_large_icon.Text = "大图标"
        '
        'ToolStripMenuItem_small_icon
        '
        Me.ToolStripMenuItem_small_icon.Image = CType(resources.GetObject("ToolStripMenuItem_small_icon.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_small_icon.Name = "ToolStripMenuItem_small_icon"
        Me.ToolStripMenuItem_small_icon.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_small_icon.Text = "小图标"
        '
        'ToolStripMenuItem_list
        '
        Me.ToolStripMenuItem_list.Image = CType(resources.GetObject("ToolStripMenuItem_list.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_list.Name = "ToolStripMenuItem_list"
        Me.ToolStripMenuItem_list.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_list.Text = "列表"
        '
        'ToolStripMenuItem_details
        '
        Me.ToolStripMenuItem_details.Image = CType(resources.GetObject("ToolStripMenuItem_details.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_details.Name = "ToolStripMenuItem_details"
        Me.ToolStripMenuItem_details.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_details.Text = "详细信息"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(112, 21)
        Me.ToolStripButton2.Text = "返回上一级内容"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"单项处理", "批量处理"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(170, 22)
        Me.ToolStripLabel2.Text = "请输入书名或作者的关键词："
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(110, 23)
        '
        'ToolStripSplitButton2
        '
        Me.ToolStripSplitButton2.Image = CType(resources.GetObject("ToolStripSplitButton2.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton2.Name = "ToolStripSplitButton2"
        Me.ToolStripSplitButton2.Size = New System.Drawing.Size(52, 21)
        Me.ToolStripSplitButton2.Text = "搜索"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 45)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(902, 462)
        Me.SplitContainer1.SplitterDistance = 193
        Me.SplitContainer1.TabIndex = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 324)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(171, 123)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(32, 209)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(151, 118)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Control
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.imglstTreeView
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 1
        TreeNode1.Name = "nodeClass"
        TreeNode1.SelectedImageIndex = 1
        TreeNode1.Text = "按类别浏览"
        TreeNode2.ImageIndex = 0
        TreeNode2.Name = "nodeAuthor"
        TreeNode2.Text = "按作者浏览"
        TreeNode3.ImageIndex = 3
        TreeNode3.Name = "nodeWork_Name"
        TreeNode3.SelectedImageIndex = 3
        TreeNode3.Text = "按名称浏览"
        TreeNode4.ImageIndex = 2
        TreeNode4.Name = "nodeAdd_Date"
        TreeNode4.SelectedImageIndex = 2
        TreeNode4.Text = "按添加日期浏览"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(193, 462)
        Me.TreeView1.TabIndex = 0
        '
        'imglstTreeView
        '
        Me.imglstTreeView.ImageStream = CType(resources.GetObject("imglstTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstTreeView.Images.SetKeyName(0, "20120210090635160_easyicon_cn_48.png")
        Me.imglstTreeView.Images.SetKeyName(1, "20120210091001429_easyicon_cn_48.png")
        Me.imglstTreeView.Images.SetKeyName(2, "20120210091054742_easyicon_cn_48.png")
        Me.imglstTreeView.Images.SetKeyName(3, "20120210091152914_easyicon_cn_48.png")
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.LargeImageList = Me.imglstListView_Large
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(705, 462)
        Me.ListView1.SmallImageList = Me.imglstListView_Small
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'imglstListView_Large
        '
        Me.imglstListView_Large.ImageStream = CType(resources.GetObject("imglstListView_Large.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstListView_Large.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstListView_Large.Images.SetKeyName(0, "20120215031617449_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(1, "2012021503192253_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(2, "20120215032402164_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(3, "20120215114303459_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(4, "20120215112546377_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(5, "20120215112810878_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(6, "20120215112837894_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(7, "20120215112851889_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(8, "20120215113059895_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(9, "20120215112914506_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(10, "20120215113426425_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(11, "20120215113530217_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(12, "20120215113649371_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(13, "20120215113713954_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(14, "20120215114058653_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(15, "20120215113814266_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(16, "20120215113933191_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(17, "20120215114144836_easyicon_cn_64.png")
        Me.imglstListView_Large.Images.SetKeyName(18, "20120215115127504_easyicon_cn_64.png")
        '
        'imglstListView_Small
        '
        Me.imglstListView_Small.ImageStream = CType(resources.GetObject("imglstListView_Small.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstListView_Small.TransparentColor = System.Drawing.Color.Transparent
        Me.imglstListView_Small.Images.SetKeyName(0, "20120215031641384_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(1, "20120215031928851_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(2, "20120215032409712_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(3, "20120215114306514_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(4, "20120215112617890_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(5, "20120215112815621_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(6, "20120215112840912_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(7, "20120215112855899_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(8, "20120215113103340_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(9, "20120215112917279_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(10, "20120215113429692_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(11, "20120215113530218_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(12, "20120215113652763_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(13, "20120215113718606_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(14, "20120215114102753_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(15, "20120215113817572_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(16, "20120215113936308_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(17, "20120215114147778_easyicon_cn_32.png")
        Me.imglstListView_Small.Images.SetKeyName(18, "20120215115131817_easyicon_cn_32.png")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Open, Me.ToolStripMenuItem_Open_Directory, Me.ToolStripMenuItem_Rename, Me.ToolStripMenuItem_Send_to, Me.ToolStripMenuItem_Delete, Me.ToolStripMenuItem_Edit, ToolStripMenuItem_Change_Class, Me.ToolStripMenuItem_Modify_Author, Me.ToolStripMenuItem_Add_into_booklist, Me.ToolStripMenuItem_Search_in_the_internet, Me.全部勾选ToolStripMenuItem, Me.取消勾选ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 268)
        '
        'ToolStripMenuItem_Open
        '
        Me.ToolStripMenuItem_Open.Image = CType(resources.GetObject("ToolStripMenuItem_Open.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open"
        Me.ToolStripMenuItem_Open.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Open.Text = "打开"
        '
        'ToolStripMenuItem_Open_Directory
        '
        Me.ToolStripMenuItem_Open_Directory.Name = "ToolStripMenuItem_Open_Directory"
        Me.ToolStripMenuItem_Open_Directory.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Open_Directory.Text = "打开目录并选中"
        '
        'ToolStripMenuItem_Rename
        '
        Me.ToolStripMenuItem_Rename.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.名称作者ToolStripMenuItem, Me.作者名称ToolStripMenuItem, Me.名称ToolStripMenuItem})
        Me.ToolStripMenuItem_Rename.Name = "ToolStripMenuItem_Rename"
        Me.ToolStripMenuItem_Rename.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Rename.Text = "重命名原文件"
        '
        '名称作者ToolStripMenuItem
        '
        Me.名称作者ToolStripMenuItem.Name = "名称作者ToolStripMenuItem"
        Me.名称作者ToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.名称作者ToolStripMenuItem.Text = "书名-作者"
        '
        '作者名称ToolStripMenuItem
        '
        Me.作者名称ToolStripMenuItem.Name = "作者名称ToolStripMenuItem"
        Me.作者名称ToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.作者名称ToolStripMenuItem.Text = "作者-书名"
        '
        '名称ToolStripMenuItem
        '
        Me.名称ToolStripMenuItem.Name = "名称ToolStripMenuItem"
        Me.名称ToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.名称ToolStripMenuItem.Text = "书名"
        '
        'ToolStripMenuItem_Send_to
        '
        Me.ToolStripMenuItem_Send_to.Name = "ToolStripMenuItem_Send_to"
        Me.ToolStripMenuItem_Send_to.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Send_to.Text = "发送到"
        '
        'ToolStripMenuItem_Delete
        '
        Me.ToolStripMenuItem_Delete.Image = CType(resources.GetObject("ToolStripMenuItem_Delete.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete"
        Me.ToolStripMenuItem_Delete.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Delete.Text = "删除"
        '
        'ToolStripMenuItem_Edit
        '
        Me.ToolStripMenuItem_Edit.Image = CType(resources.GetObject("ToolStripMenuItem_Edit.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Edit.Name = "ToolStripMenuItem_Edit"
        Me.ToolStripMenuItem_Edit.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Edit.Text = "编辑信息"
        '
        'ToolStripMenuItem_Modify_Author
        '
        Me.ToolStripMenuItem_Modify_Author.Name = "ToolStripMenuItem_Modify_Author"
        Me.ToolStripMenuItem_Modify_Author.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Modify_Author.Text = "修改作者"
        '
        'ToolStripMenuItem_Add_into_booklist
        '
        Me.ToolStripMenuItem_Add_into_booklist.Name = "ToolStripMenuItem_Add_into_booklist"
        Me.ToolStripMenuItem_Add_into_booklist.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Add_into_booklist.Text = "添加到书单"
        '
        'ToolStripMenuItem_Search_in_the_internet
        '
        Me.ToolStripMenuItem_Search_in_the_internet.Image = CType(resources.GetObject("ToolStripMenuItem_Search_in_the_internet.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Search_in_the_internet.Name = "ToolStripMenuItem_Search_in_the_internet"
        Me.ToolStripMenuItem_Search_in_the_internet.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem_Search_in_the_internet.Text = "网络搜索"
        '
        '全部勾选ToolStripMenuItem
        '
        Me.全部勾选ToolStripMenuItem.Image = CType(resources.GetObject("全部勾选ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.全部勾选ToolStripMenuItem.Name = "全部勾选ToolStripMenuItem"
        Me.全部勾选ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.全部勾选ToolStripMenuItem.Text = "全部勾选"
        '
        '取消勾选ToolStripMenuItem
        '
        Me.取消勾选ToolStripMenuItem.Image = CType(resources.GetObject("取消勾选ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.取消勾选ToolStripMenuItem.Name = "取消勾选ToolStripMenuItem"
        Me.取消勾选ToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.取消勾选ToolStripMenuItem.Text = "取消勾选"
        '
        'frmView_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 507)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "电子文档管理器"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents imglstTreeView As System.Windows.Forms.ImageList
    Friend WithEvents imglstListView_Large As System.Windows.Forms.ImageList
    Friend WithEvents imglstListView_Small As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSplitButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem_large_icon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_small_icon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_list As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_details As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Open_Directory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem_Rename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Send_to As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Add_into_booklist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Search_in_the_internet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents 全部勾选ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 取消勾选ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Modify_Author As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 名称作者ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 作者名称ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 名称ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
