Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports SerialReader.Form1.AppSetting

Public Class Form1
    Public Machine As Machine
    Private _SamplingEnabled As Boolean
    Public Property SamplingEnabled As Boolean
        Get
            Return _SamplingEnabled
        End Get
        Set(value As Boolean)
            _SamplingEnabled = value
            Invoke(Sub()
                       If value Then
                           ButtonEnableAutoSampling.Text = "停止采样"
                       Else
                           ButtonEnableAutoSampling.Text = "开始采样"
                       End If
                   End Sub)

        End Set
    End Property
    Public Property SamplingStartTime As Date = Now
    Public SamplingSwitch As New Object
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Machine = New Machine
        AddHandler Machine.ConnectionChanged,
            Sub(b As Boolean)
                Invoke(
                Sub()
                    If b Then
                        ButtonSPConnect.Text = "断开"
                        ToolStripStatusLabelPortStatus.Text = "已连接 - " & Machine.SPort1.BaudRate & "@" & Machine.SPort1.PortName
                        ToolStripStatusLabelPortStatus.ForeColor = Color.Green
                        ButtonSPSend.Enabled = True
                        ButtonEnableAutoSampling.Enabled = True
                    Else
                        ToolStripStatusLabelPortStatus.Text = "未连接"
                        ToolStripStatusLabelPortStatus.ForeColor = Color.Red
                        ButtonSPConnect.Text = "连接"
                        ButtonSPSend.Enabled = False
                        ButtonEnableAutoSampling.Enabled = False
                    End If
                End Sub)
            End Sub
        AddHandler Machine.ErrorMsgThrow,
            Sub(s As String)
                PrintMsg(vbCrLf & s)
            End Sub
        AddHandler Machine.DataReceived,
            Sub(ByVal s As String)
                PrintMsg(s)
            End Sub
        AddHandler Machine.RawDataReceived,
            Sub(ByVal d As Byte(), ByVal time As Date)
                PrintData(d, time)
            End Sub
        AddHandler Machine.StatusChanged,
            Sub(s As String)
                Dim th As New Threading.Thread(
                Sub()
                    Dim t() As String = s.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To t.Length - 1
                        t(i) = t(i).Replace(" ", "")
                        If t(i)(0) = "%" Then Continue For
                        For j As Integer = 0 To t(i).Length - 1
                            If Not IsAlphabet(t(i)(0)) Then Continue For
                            Dim k As Integer
                            For k = j + 1 To t(i).Length - 1
                                If Not IsNumChar(t(i)(k)) Then
                                    k -= 1
                                    Exit For
                                End If
                            Next
                            If k > t(i).Length - 1 Then k = t(i).Length - 1
                            Dim vals As String = Mid(t(i), j + 2, k - j)
                            If vals = "" Then Continue For
                            Dim value As Double = Val(vals)
                            Machine.SetStatus(t(i)(j).ToString.ToUpper, value)
                        Next
                    Next
                End Sub)
                th.Start()
            End Sub
    End Sub
    Public Function IsNumChar(ByVal c As Char) As Boolean
        If Asc(c) >= Asc("0") And Asc(c) <= Asc("9") Then
            Return True
        ElseIf c = "." Or c = "-" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function IsAlphabet(ByVal c As Char) As Boolean
        c = c.ToString.ToLower.ToCharArray()(0)
        If Asc(c) >= Asc("a") And Asc(c) <= Asc("z") Then Return True Else Return False

    End Function
    Public Sub PrintMsg(ByRef s As String)
        PrintMsgEx(Threading.Interlocked.Exchange(s, ""))
    End Sub
    Public Sub PrintData(ByVal d As Byte(), ByVal time As Date)
        Try
            Invoke(Sub()
                       Dim parsevalue As Integer = 0
                       If d.Length >= 7 Then
                           parsevalue <<= 8
                           parsevalue = parsevalue Or d(4)
                           parsevalue <<= 8
                           parsevalue = parsevalue Or d(5)
                           parsevalue <<= 8
                           parsevalue = parsevalue Or d(6)
                           If d(3) = 1 Then parsevalue *= -1
                       End If
                       SyncLock TextBoxParse.Text
                           Dim output As New StringBuilder
                           output.Append($"{time.ToString("yyyyMMdd_HH:mm:ss.fffffff")}>{vbTab}{time.Ticks}{vbTab}{parsevalue / 10000}{vbTab}")
                           output.AppendLine(Misc.Byte2Hex(d, False))
                           TextBoxParse.AppendText(output.ToString())
                           TextBoxParse.Select(TextBoxParse.TextLength, 0)
                           TextBoxParse.ScrollToCaret()
                           My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Application.StartupPath, $"data_{SamplingStartTime.ToString("yyyyMMdd_HHmmss_fffffff")}.txt"), output.ToString(), True)
                       End SyncLock
                   End Sub)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PrintMsgEx(ByVal s As String)
        Try
            Me.Invoke(Sub()
                          SyncLock TextBoxOutput.Text
                              TextBoxOutput.AppendText(s)
                              Dim t As String() = s.Split(",")

                              If t.Length >= 7 Then
                                  Dim NewParseString As String = ($"{Now.ToString("yyyyMMdd-HH:mm:ss.fff")},{ _
                                  (Val(t(0)) / 1023 * 5).ToString("F3")},{(Val(t(1)) / 1023 * 5).ToString("F3") _
                                  },{(Val(t(2)) / 1023 * 5).ToString("F3")},{(Val(t(3)) / 1023 * 15).ToString("F3") _
                                  },{(Val(t(2)) / 1023 * 15).ToString("F3")},{(Val(t(4)) / 1023 * 30.5).ToString("F3") _
                                  },{(Val(t(5)) / 1023 * 30.5).ToString("F3")},{(Val(t(6)) / 1023 * 50).ToString("F3")}{vbCrLf}")
                                  TextBoxParse.AppendText(NewParseString)
                                  My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Application.StartupPath, $"output_{SamplingStartTime.ToString("yyyyMMdd_HHmmss_fffffff")}.txt"), NewParseString, True)
                              End If
                              TextBoxOutput.AppendText(vbCrLf)
                              TextBoxOutput.Select(TextBoxOutput.TextLength, 0)
                              TextBoxOutput.ScrollToCaret()
                          End SyncLock
                      End Sub)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonSPScan_Click(sender As Object, e As EventArgs) Handles ButtonSPScan.Click
        Dim s() As String = {}
        s = IO.Ports.SerialPort.GetPortNames
        ComboBoxSPort.Items.Clear()
        If s Is Nothing Then Exit Sub
        If s.Length = 0 Then Exit Sub
        For Each t As String In s
            ComboBoxSPort.Items.Add(t)
        Next
        If ComboBoxSPort.Text = "" Then ComboBoxSPort.SelectedItem = ComboBoxSPort.Items.Item(ComboBoxSPort.Items.Count - 1)
    End Sub

    Private Sub ButtonSPConnect_Click(sender As Object, e As EventArgs) Handles ButtonSPConnect.Click
        If ButtonSPConnect.Text = "连接" Then
            Machine.PortName = ComboBoxSPort.Text
            Machine.BaudRate = Math.Max(9600, Val(ComboBoxSPBaudrate.Text))
            ComboBoxSPBaudrate.Text = Machine.BaudRate
            Machine.Connect()
        Else
            SyncLock SamplingSwitch
                SamplingEnabled = False
                Machine.DisConnect()
            End SyncLock
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSetting()
        ButtonSPScan_Click(sender, e)
        Task.Run(
            Sub()
                Dim lastValue As Integer = Integer.MaxValue
                Dim lastRawData As Byte() = {}
                Dim lastTime As New Date
                Dim valueSkipped As Boolean = False
                Dim dataWindow1 As DataWindow = Nothing
                While True
                    Threading.Thread.Sleep(50)
                    SyncLock SamplingSwitch
                        If SamplingEnabled Then
                            If dataWindow1 Is Nothing Then
                                dataWindow1 = New DataWindow
                                Invoke(Sub() dataWindow1.Show())
                            End If
                            If ContextMenuStrip1.Items IsNot Nothing AndAlso ContextMenuStrip1.Items.Count > 0 Then
                                Machine.SPort1.ReceivedBytesThreshold = 9
                                Machine.ReadDelay = 50
                                Machine.EventEnabled = False
                                If CheckBoxSendHex.Checked Then
                                    'hex
                                    Machine.SendData(Misc.HexStringToByteArray(ContextMenuStrip1.Items(0).Tag))
                                Else
                                    'ascii
                                    Machine.SendData(ContextMenuStrip1.Items(0).Tag)
                                End If
                                Dim outData As New List(Of Byte)
                                Dim timeout As Date = Now + New TimeSpan(0, 0, 1)
                                Dim readtime As Date = timeout
                                While Now < timeout
                                    If outData.Count = 9 Then Exit While
                                    If Machine.SPort1.BytesToRead > 0 Then
                                        Dim nowtime As Date = Now
                                        If nowtime < readtime Then readtime = nowtime
                                        outData.Add(Machine.SPort1.ReadByte())
                                    End If
                                End While
                                If outData.Count = 9 Then
                                    Dim currentValue As Integer = outData(4)
                                    currentValue <<= 8
                                    currentValue = currentValue Or outData(5)
                                    currentValue <<= 8
                                    currentValue = currentValue Or outData(6)
                                    If dataWindow1 Is Nothing OrElse dataWindow1.Visible = False Then
                                        dataWindow1 = Nothing
                                        SamplingEnabled = False
                                        Continue While
                                    End If
                                    dataWindow1.AddPoint(readtime.Ticks, currentValue / 10000)
                                    If outData(3) = 1 Then currentValue *= -1
                                    If currentValue = lastValue Then
                                        lastRawData = outData.ToArray()
                                        lastTime = readtime
                                        valueSkipped = True
                                    ElseIf valueSkipped Then
                                        PrintData(lastRawData, lastTime)
                                        valueSkipped = False
                                        PrintData(outData.ToArray(), readtime)
                                    Else
                                        PrintData(outData.ToArray(), readtime)
                                    End If
                                    lastValue = currentValue


                                End If
                            End If
                        Else
                            Machine.SPort1.ReceivedBytesThreshold = 1
                            Machine.ReadDelay = 100
                        End If
                    End SyncLock

                End While
            End Sub)
    End Sub

    Private Sub ButtonSPSend_Click(sender As Object, e As EventArgs) Handles ButtonSPSend.Click
        If CheckBoxSendHex.Checked Then
            'hex
            Dim data As Byte() = Misc.HexStringToByteArray(TextBoxTerminalInput.Text)
            If CheckBoxCRC.Checked Then
                Dim crcdata As UShort = Misc.CRC(data)
                Dim data2 As List(Of Byte) = data.ToList
                data2.AddRange({CByte(crcdata And &HFF), CByte(crcdata >> 8 And &HFF)})
                data = data2.ToArray()
            End If
            Machine.SendData(data)
        Else
            'ascii
            Machine.SendData(TextBoxTerminalInput.Text)
        End If
        If CheckBoxClearInput.Checked Then TextBoxTerminalInput.Clear()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting()
    End Sub
    Public ReadOnly Property ConfigPath As String
        Get
            Return IO.Path.Combine(Application.StartupPath, "config.ini")
        End Get
    End Property
    Public Class AppSetting
        Public Property Port As String = ""
        Public Property BaudRate As Integer = 38400
        Public Property SendValue As String = "01 03 00 00 ff ff 44 7a"
        Public Property SendHex As Boolean = True
        Public Property CRC As Boolean = False
        Public Class RapidSendValueItem
            Public Key As String
            Public Value As String
        End Class
        Public Property RapidSendValue As New List(Of RapidSendValueItem)

        Public Function GetSerializedText() As String
            Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(AppSetting))
            Dim sb As New Text.StringBuilder
            Dim t As New IO.StringWriter(sb)
            writer.Serialize(t, Me)
            Return sb.ToString()
        End Function
        Public Shared Function FromXML(s As String) As AppSetting
            Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(AppSetting))
            Dim t As IO.TextReader = New IO.StringReader(s)
            Return CType(reader.Deserialize(t), AppSetting)
        End Function
    End Class
    Public Sub LoadSetting()
        If IO.File.Exists(ConfigPath) Then
            Dim cfg As AppSetting = AppSetting.FromXML(IO.File.ReadAllText(ConfigPath))
            ComboBoxSPort.Text = cfg.Port
            ComboBoxSPBaudrate.Text = cfg.BaudRate
            TextBoxTerminalInput.Text = cfg.SendValue
            CheckBoxSendHex.Checked = cfg.SendHex
            CheckBoxCRC.Checked = cfg.CRC
            If cfg.RapidSendValue IsNot Nothing AndAlso cfg.RapidSendValue.Count > 0 Then
                ContextMenuStrip1.Items.Clear()
                For Each sv As RapidSendValueItem In cfg.RapidSendValue
                    Dim ts As New ToolStripMenuItem With {.Text = sv.Key, .Tag = sv.Value}
                    AddHandler ts.Click,
                        Sub()
                            If CheckBoxSendHex.Checked Then
                                'hex
                                Machine.SendData(Misc.HexStringToByteArray(sv.Value))
                            Else
                                'ascii
                                Machine.SendData(sv.Value)
                            End If
                        End Sub
                    ContextMenuStrip1.Items.Add(ts)
                Next
            End If
        End If
    End Sub
    Public Sub SaveSetting()
        Dim cfg As New AppSetting With {.BaudRate = ComboBoxSPBaudrate.Text,
            .Port = ComboBoxSPort.Text,
            .SendHex = CheckBoxSendHex.Checked,
            .CRC = CheckBoxCRC.Checked,
            .SendValue = TextBoxTerminalInput.Text}
        For Each c As ToolStripMenuItem In ContextMenuStrip1.Items
            cfg.RapidSendValue.Add(New RapidSendValueItem With {.Key = c.Text, .Value = c.Tag})
        Next
        IO.File.WriteAllText(ConfigPath, cfg.GetSerializedText)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonEnableAutoSampling.Click
        SyncLock SamplingSwitch
            SamplingEnabled = Not SamplingEnabled
            If SamplingEnabled Then
                SamplingStartTime = Now
            End If
        End SyncLock
    End Sub
End Class


Public Class Machine
    Public Property PortName As String
    Public Property BaudRate As Integer
    Public Property Name As String
    Public Property IsBusy As Boolean
    Public Property DebugMode As Boolean = False
    Public Property ReadDelay As Integer = 70

    Private OperationLock As New Object
    Public Property EventEnabled As Boolean = True

    Public Event ConnectionChanged(ByVal b As Boolean)
    Public Event ErrorMsgThrow(ByVal s As String)
    Public Event DataReceived(ByVal s As String)
    Public Event RawDataReceived(ByVal d As Byte(), ByVal time As Date)
    Public Event DataSent(ByVal Info As Integer)
    Public Event StatusChanged(ByVal s As String)
    Public Structure StatusDef
        Property G0 As Boolean
        Property G1 As Boolean
        Property G90 As Boolean
        Property G91 As Boolean
        Property G92 As Boolean
        Property F As Double
        Property X As Double
        Property Y As Double
        Property Z As Double
        Property E As Double
        Property M As Double
    End Structure
    Public Status As StatusDef
    Public StatusString As String
    Public Sub SetStatus(ByVal cmd As String, ByVal value As Double)
        Select Case cmd.ToUpper
            Case "G"
                Select Case CInt(value)
                    Case 0
                        Status.G0 = True
                        Status.G1 = False
                        Status.G92 = False
                    Case 1
                        Status.G0 = False
                        Status.G1 = True
                        Status.G92 = False
                    Case 90
                        Status.G90 = True
                        Status.G91 = False
                        Status.G92 = False
                    Case 91
                        Status.G90 = False
                        Status.G91 = True
                        Status.G92 = False
                    Case 92
                        Status.G92 = True
                End Select

            Case "F"
                Status.F = value
                Status.G92 = False
            Case "X"
                If Status.G92 Then
                    Status.X = value
                Else
                    If Status.G90 Then Status.X = value Else Status.X += value
                End If
            Case "Y"
                If Status.G92 Then
                    Status.Y = value
                Else
                    If Status.G90 Then Status.Y = value Else Status.Y += value
                End If
            Case "Z"
                If Status.G92 Then
                    Status.Z = value
                Else
                    If Status.G90 Then Status.Z = value Else Status.Z += value
                End If
            Case "M"
                Status.G92 = False
            Case "S"
                Status.G92 = False
        End Select
    End Sub
    Public Function GetStatus() As String
        GetStatus = ""
        If Status.G90 Then GetStatus &= "G90 "
        If Status.G91 Then GetStatus &= "G91 "
        If Status.G0 Then GetStatus &= "G0 "
        If Status.G1 Then GetStatus &= "G1 "
        If GetStatus <> "" Then GetStatus &= vbCrLf
        GetStatus &= "F" & Math.Round(Status.F) & " "
        GetStatus &= "X" & Math.Round(Status.X, 2) & " "
        GetStatus &= "Y" & Math.Round(Status.Y, 2) & " "
        GetStatus &= "Z" & Math.Round(Status.Z, 2) & " "
        StatusString = GetStatus
    End Function

    Public SPort1 As IO.Ports.SerialPort
    Public Sub New()
        SPort1 = New IO.Ports.SerialPort
        AddHandler SPort1.DataReceived,
            Sub(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
                If Not EventEnabled Then Exit Sub
                SyncLock OperationLock
                    Dim rawdata As New List(Of Byte)
                    Dim time As Date = Now
                    While SPort1.BytesToRead > 0
                        While SPort1.BytesToRead > 0
                            Dim readeddata As Integer = SPort1.ReadByte()
                            If readeddata <> -1 Then rawdata.Add(readeddata And &HFFB)
                        End While
                        Threading.Thread.Sleep(ReadDelay)
                    End While
                    If rawdata.Count = 0 Then Exit Sub
                    RaiseEvent DataReceived(Text.Encoding.ASCII.GetString(rawdata.ToArray()))
                    RaiseEvent RawDataReceived(rawdata.ToArray(), time)
                End SyncLock
            End Sub
        AddHandler SPort1.ErrorReceived,
            Sub(sender As Object, ex As IO.Ports.SerialErrorReceivedEventArgs)
                If Not EventEnabled Then Exit Sub
                SyncLock OperationLock
                    Try
                        DisConnect()
                    Catch e As Exception
                    End Try
                    RaiseEvent ConnectionChanged(False)
                    RaiseEvent ErrorMsgThrow(ex.ToString)
                End SyncLock
            End Sub

    End Sub
    Public Sub Connect()
        If DebugMode Then Exit Sub
        Try
            DisConnect()
        Catch ex As Exception
        End Try
        Try
            SyncLock OperationLock
                SPort1.PortName = PortName
                SPort1.BaudRate = BaudRate

                SPort1.DataBits = 8
                SPort1.StopBits = 2
                SPort1.Parity = False
                SPort1.Open()
                RaiseEvent ConnectionChanged(True)
            End SyncLock

        Catch ex As Exception
            RaiseEvent ErrorMsgThrow(ex.ToString)
            RaiseEvent ConnectionChanged(False)
        End Try

    End Sub
    Public Sub DisConnect()
        If DebugMode Then Exit Sub
        SyncLock OperationLock
            SPort1.Close()
            RaiseEvent ConnectionChanged(False)
        End SyncLock
    End Sub

    Public Sub SendData(ByVal s As String)
        Task.Run(Sub()
                     If DebugMode Then
                         RaiseEvent StatusChanged(s)
                         Exit Sub
                     End If
                     SyncLock OperationLock
                         While Threading.Interlocked.CompareExchange(IsBusy, True, False)
                         End While
                         For i As Integer = 0 To s.Length - 1
                             SPort1.Write(s(i))
                         Next
                         RaiseEvent DataSent(s.Length)
                         RaiseEvent StatusChanged(s)
                         IsBusy = False
                     End SyncLock

                 End Sub)

    End Sub
    Public Sub SendData(data As Byte())
        Task.Run(Sub()
                     If DebugMode Then
                         RaiseEvent StatusChanged(Misc.Byte2Hex(data))
                         Exit Sub
                     End If
                     SyncLock OperationLock
                         While Threading.Interlocked.CompareExchange(IsBusy, True, False)
                         End While
                         SPort1.Write(data, 0, data.Length)
                         RaiseEvent DataSent(data.Length)
                         RaiseEvent StatusChanged(Misc.Byte2Hex(data))
                         IsBusy = False
                     End SyncLock
                 End Sub)


    End Sub
    Public Sub Dispose()
        Try
            DisConnect()
            SPort1.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class Misc
    Public Shared Function Byte2Hex(bytes As Byte(), Optional ByVal TextShow As Boolean = False) As String
        Const HalfWidthChars As String = "~!@#$%^&*()_+-=|\ <>?,./:;""''{}[]0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        If bytes Is Nothing Then Return ""
        If bytes.Length = 0 Then Return ""
        Dim sb As New StringBuilder
        Dim tb As String = ""
        Dim ln As New StringBuilder
        For i As Integer = 0 To bytes.Length - 1
            If i Mod 16 = 0 And TextShow Then
                ln.Append("|" & Hex(i).PadLeft(5) & "h: ")
            End If
            ln.Append(Convert.ToString((bytes(i) And &HFF) + &H100, 16).Substring(1).ToUpper)
            ln.Append(" ")
            Dim c As Char = Chr(bytes(i))
            If Not HalfWidthChars.Contains(c) Then
                tb &= "."
            Else
                tb &= c
            End If
            If i Mod 16 = 15 Then
                If TextShow Then
                    ln.Append(tb)
                    sb.Append(ln.ToString().PadRight(74) & "|")
                End If
                sb.Append(vbCrLf)
                ln = New StringBuilder()
                tb = ""
            End If
        Next
        If TextShow And tb <> "" Then
            ln.Append(tb)
        End If

        If ln.Length > 0 Then
            If TextShow Then
                sb.Append(ln.ToString().PadRight(74) & "|")
            Else
                sb.Append(ln.ToString())
            End If
        End If
        Return sb.ToString()
    End Function
    Public Shared Function HexStringToByteArray(s As String) As Byte()
        s = s.ToUpper
        Dim dataList As New List(Of Byte)
        Dim charbuffer As String = ""
        Dim allowedChar() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"}
        For i As Integer = 0 To s.Length - 1
            If allowedChar.Contains(s(i)) Then
                charbuffer &= s(i)
            End If
            If charbuffer.Length = 2 Or (charbuffer.Length = 1 And s(i) = " ") Then
                dataList.Add(Convert.ToByte(charbuffer, 16))
                charbuffer = ""
            End If
        Next
        Return dataList.ToArray()
    End Function
    Public Shared Function CRC(data As Byte()) As UInt16
        Dim CRCResult As UInt16 = &HFFFFUS
        Dim flag As UInt16
        For i As Integer = 0 To data.Length - 1
            CRCResult = CRCResult Xor data(i)
            For j As Integer = 0 To 7
                flag = CRCResult And 1
                CRCResult >>= 1
                If flag Then
                    CRCResult = CRCResult And &H7FFFUS
                    CRCResult = CRCResult Xor &HA001US
                End If
            Next
        Next
        Return CRCResult
    End Function
End Class