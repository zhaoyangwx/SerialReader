<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBoxSP = New System.Windows.Forms.GroupBox()
        Me.ButtonSPConnect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxSPBaudrate = New System.Windows.Forms.ComboBox()
        Me.ButtonSPScan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxSPort = New System.Windows.Forms.ComboBox()
        Me.GroupBoxSPTerminal = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonEnableAutoSampling = New System.Windows.Forms.Button()
        Me.CheckBoxSendHex = New System.Windows.Forms.CheckBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TextBoxOutput = New System.Windows.Forms.TextBox()
        Me.TextBoxParse = New System.Windows.Forms.TextBox()
        Me.TextBoxTerminalInput = New System.Windows.Forms.TextBox()
        Me.CheckBoxClearInput = New System.Windows.Forms.CheckBox()
        Me.ButtonSPSend = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FfFf447aToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeBusZerosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelPortStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CheckBoxCRC = New System.Windows.Forms.CheckBox()
        Me.GroupBoxSP.SuspendLayout()
        Me.GroupBoxSPTerminal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxSP
        '
        Me.GroupBoxSP.Controls.Add(Me.ButtonSPConnect)
        Me.GroupBoxSP.Controls.Add(Me.Label1)
        Me.GroupBoxSP.Controls.Add(Me.ComboBoxSPBaudrate)
        Me.GroupBoxSP.Controls.Add(Me.ButtonSPScan)
        Me.GroupBoxSP.Controls.Add(Me.Label2)
        Me.GroupBoxSP.Controls.Add(Me.ComboBoxSPort)
        Me.GroupBoxSP.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxSP.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxSP.Name = "GroupBoxSP"
        Me.GroupBoxSP.Size = New System.Drawing.Size(828, 95)
        Me.GroupBoxSP.TabIndex = 8
        Me.GroupBoxSP.TabStop = False
        Me.GroupBoxSP.Text = "连接"
        '
        'ButtonSPConnect
        '
        Me.ButtonSPConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonSPConnect.Location = New System.Drawing.Point(376, 66)
        Me.ButtonSPConnect.Name = "ButtonSPConnect"
        Me.ButtonSPConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSPConnect.TabIndex = 7
        Me.ButtonSPConnect.Text = "连接"
        Me.ButtonSPConnect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "端口"
        '
        'ComboBoxSPBaudrate
        '
        Me.ComboBoxSPBaudrate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxSPBaudrate.FormattingEnabled = True
        Me.ComboBoxSPBaudrate.Items.AddRange(New Object() {"9600", "38400", "57600", "115200"})
        Me.ComboBoxSPBaudrate.Location = New System.Drawing.Point(83, 39)
        Me.ComboBoxSPBaudrate.Name = "ComboBoxSPBaudrate"
        Me.ComboBoxSPBaudrate.Size = New System.Drawing.Size(686, 20)
        Me.ComboBoxSPBaudrate.TabIndex = 6
        Me.ComboBoxSPBaudrate.Text = "38400"
        '
        'ButtonSPScan
        '
        Me.ButtonSPScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSPScan.Location = New System.Drawing.Point(775, 11)
        Me.ButtonSPScan.Name = "ButtonSPScan"
        Me.ButtonSPScan.Size = New System.Drawing.Size(45, 23)
        Me.ButtonSPScan.TabIndex = 2
        Me.ButtonSPScan.Text = "刷新"
        Me.ButtonSPScan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "波特率"
        '
        'ComboBoxSPort
        '
        Me.ComboBoxSPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxSPort.FormattingEnabled = True
        Me.ComboBoxSPort.Location = New System.Drawing.Point(83, 13)
        Me.ComboBoxSPort.Name = "ComboBoxSPort"
        Me.ComboBoxSPort.Size = New System.Drawing.Size(686, 20)
        Me.ComboBoxSPort.TabIndex = 3
        '
        'GroupBoxSPTerminal
        '
        Me.GroupBoxSPTerminal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxSPTerminal.Controls.Add(Me.Panel1)
        Me.GroupBoxSPTerminal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxSPTerminal.Location = New System.Drawing.Point(12, 113)
        Me.GroupBoxSPTerminal.Name = "GroupBoxSPTerminal"
        Me.GroupBoxSPTerminal.Size = New System.Drawing.Size(839, 399)
        Me.GroupBoxSPTerminal.TabIndex = 10
        Me.GroupBoxSPTerminal.TabStop = False
        Me.GroupBoxSPTerminal.Text = "终端"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.CheckBoxCRC)
        Me.Panel1.Controls.Add(Me.ButtonEnableAutoSampling)
        Me.Panel1.Controls.Add(Me.CheckBoxSendHex)
        Me.Panel1.Controls.Add(Me.SplitContainer2)
        Me.Panel1.Controls.Add(Me.CheckBoxClearInput)
        Me.Panel1.Controls.Add(Me.ButtonSPSend)
        Me.Panel1.Location = New System.Drawing.Point(0, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(839, 388)
        Me.Panel1.TabIndex = 4
        '
        'ButtonEnableAutoSampling
        '
        Me.ButtonEnableAutoSampling.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonEnableAutoSampling.Enabled = False
        Me.ButtonEnableAutoSampling.Location = New System.Drawing.Point(614, 359)
        Me.ButtonEnableAutoSampling.Name = "ButtonEnableAutoSampling"
        Me.ButtonEnableAutoSampling.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnableAutoSampling.TabIndex = 6
        Me.ButtonEnableAutoSampling.Text = "开始采样"
        Me.ButtonEnableAutoSampling.UseVisualStyleBackColor = True
        '
        'CheckBoxSendHex
        '
        Me.CheckBoxSendHex.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CheckBoxSendHex.AutoSize = True
        Me.CheckBoxSendHex.Checked = True
        Me.CheckBoxSendHex.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSendHex.Location = New System.Drawing.Point(283, 363)
        Me.CheckBoxSendHex.Name = "CheckBoxSendHex"
        Me.CheckBoxSendHex.Size = New System.Drawing.Size(42, 16)
        Me.CheckBoxSendHex.TabIndex = 5
        Me.CheckBoxSendHex.Text = "HEX"
        Me.CheckBoxSendHex.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBoxTerminalInput)
        Me.SplitContainer2.Size = New System.Drawing.Size(833, 350)
        Me.SplitContainer2.SplitterDistance = 196
        Me.SplitContainer2.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxOutput)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxParse)
        Me.SplitContainer1.Size = New System.Drawing.Size(833, 196)
        Me.SplitContainer1.SplitterDistance = 235
        Me.SplitContainer1.TabIndex = 1
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxOutput.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxOutput.Size = New System.Drawing.Size(235, 196)
        Me.TextBoxOutput.TabIndex = 0
        Me.TextBoxOutput.WordWrap = False
        '
        'TextBoxParse
        '
        Me.TextBoxParse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxParse.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxParse.Multiline = True
        Me.TextBoxParse.Name = "TextBoxParse"
        Me.TextBoxParse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxParse.Size = New System.Drawing.Size(594, 196)
        Me.TextBoxParse.TabIndex = 1
        Me.TextBoxParse.WordWrap = False
        '
        'TextBoxTerminalInput
        '
        Me.TextBoxTerminalInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTerminalInput.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxTerminalInput.Multiline = True
        Me.TextBoxTerminalInput.Name = "TextBoxTerminalInput"
        Me.TextBoxTerminalInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxTerminalInput.Size = New System.Drawing.Size(833, 150)
        Me.TextBoxTerminalInput.TabIndex = 1
        Me.TextBoxTerminalInput.Text = "01 03 00 00 ff ff 44 7a"
        Me.TextBoxTerminalInput.WordWrap = False
        '
        'CheckBoxClearInput
        '
        Me.CheckBoxClearInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CheckBoxClearInput.AutoSize = True
        Me.CheckBoxClearInput.Location = New System.Drawing.Point(460, 363)
        Me.CheckBoxClearInput.Name = "CheckBoxClearInput"
        Me.CheckBoxClearInput.Size = New System.Drawing.Size(96, 16)
        Me.CheckBoxClearInput.TabIndex = 3
        Me.CheckBoxClearInput.Text = "自动清空输入"
        Me.CheckBoxClearInput.UseVisualStyleBackColor = True
        '
        'ButtonSPSend
        '
        Me.ButtonSPSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonSPSend.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ButtonSPSend.Enabled = False
        Me.ButtonSPSend.Location = New System.Drawing.Point(379, 359)
        Me.ButtonSPSend.Name = "ButtonSPSend"
        Me.ButtonSPSend.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSPSend.TabIndex = 2
        Me.ButtonSPSend.Text = "发送"
        Me.ButtonSPSend.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FfFf447aToolStripMenuItem, Me.ModeBusZerosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(195, 48)
        '
        'FfFf447aToolStripMenuItem
        '
        Me.FfFf447aToolStripMenuItem.Name = "FfFf447aToolStripMenuItem"
        Me.FfFf447aToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.FfFf447aToolStripMenuItem.Tag = "01 03 00 00 ff ff 44 7a"
        Me.FfFf447aToolStripMenuItem.Text = "ModeBusReadValue"
        '
        'ModeBusZerosToolStripMenuItem
        '
        Me.ModeBusZerosToolStripMenuItem.Name = "ModeBusZerosToolStripMenuItem"
        Me.ModeBusZerosToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ModeBusZerosToolStripMenuItem.Tag = "01 06 00 00 ab 56 76 c4"
        Me.ModeBusZerosToolStripMenuItem.Text = "ModeBusZeros"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelPortStatus, Me.ToolStripStatusLabelMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 531)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(863, 26)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelPortStatus
        '
        Me.ToolStripStatusLabelPortStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelPortStatus.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabelPortStatus.Name = "ToolStripStatusLabelPortStatus"
        Me.ToolStripStatusLabelPortStatus.Size = New System.Drawing.Size(48, 21)
        Me.ToolStripStatusLabelPortStatus.Text = "未连接"
        '
        'ToolStripStatusLabelMessage
        '
        Me.ToolStripStatusLabelMessage.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelMessage.Name = "ToolStripStatusLabelMessage"
        Me.ToolStripStatusLabelMessage.Size = New System.Drawing.Size(800, 21)
        Me.ToolStripStatusLabelMessage.Spring = True
        Me.ToolStripStatusLabelMessage.Text = "无消息"
        '
        'CheckBoxCRC
        '
        Me.CheckBoxCRC.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CheckBoxCRC.AutoSize = True
        Me.CheckBoxCRC.Location = New System.Drawing.Point(331, 363)
        Me.CheckBoxCRC.Name = "CheckBoxCRC"
        Me.CheckBoxCRC.Size = New System.Drawing.Size(42, 16)
        Me.CheckBoxCRC.TabIndex = 7
        Me.CheckBoxCRC.Text = "CRC"
        Me.CheckBoxCRC.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 557)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBoxSPTerminal)
        Me.Controls.Add(Me.GroupBoxSP)
        Me.Name = "Form1"
        Me.Text = "Serial Reader"
        Me.GroupBoxSP.ResumeLayout(False)
        Me.GroupBoxSP.PerformLayout()
        Me.GroupBoxSPTerminal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBoxSP As GroupBox
    Friend WithEvents ButtonSPConnect As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxSPBaudrate As ComboBox
    Friend WithEvents ButtonSPScan As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBoxSPort As ComboBox
    Friend WithEvents GroupBoxSPTerminal As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TextBoxOutput As TextBox
    Friend WithEvents TextBoxTerminalInput As TextBox
    Friend WithEvents CheckBoxClearInput As CheckBox
    Friend WithEvents ButtonSPSend As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelPortStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMessage As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TextBoxParse As TextBox
    Friend WithEvents CheckBoxSendHex As CheckBox
    Friend WithEvents ButtonEnableAutoSampling As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents FfFf447aToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModeBusZerosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBoxCRC As CheckBox
End Class
