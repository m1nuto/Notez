Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class FrmMain


#Region "Variables & Constants"
    ''Variables for FrmNewStudy
    Private Const tf As String = "C:\ProgramData\Notez\temp.txt"
    Private Const td As String = "C:\ProgramData\Notez\"
    ReadOnly t As New List(Of String)()
    Dim mb As String = "Left"
    ReadOnly ad As String = AppDomain.CurrentDomain.BaseDirectory
    ReadOnly nl As String = Environment.NewLine
    ''Variables for mainform
    ''Dim batlaunch As String = Environment.ExpandEnvironmentVariables("%appdata%\Norffman\batlaunch\")
    'Dim batlaunch As String = ad & "batlaunch\"
    Dim programlocation As String = Nothing
    Dim paragon As String = Nothing
    Dim doSplit As Boolean = True
    Dim doCheck As Boolean = True
    Dim lasStr As String = ""

    <Flags()>
    Private Enum SHOW_WINDOW As Integer
        SW_HIDE = 0
        SW_SHOWNORMAL = 1
        SW_NORMAL = 1
        SW_SHOWMINIMIZED = 2
        SW_SHOWMAXIMIZED = 3
        SW_MAXIMIZE = 3
        SW_SHOWNOACTIVATE = 4
        SW_SHOW = 5
        SW_MINIMIZE = 6
        SW_SHOWMINNOACTIVE = 7
        SW_SHOWNA = 8
        SW_RESTORE = 9
        SW_SHOWDEFAULT = 10
        SW_FORCEMINIMIZE = 11
        SW_MAX = 11
    End Enum
    Const WS_MAXIMIZEBOX As Integer = &H10000
    Const GWL_STYLE As Integer = -16
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")>
    Public Shared Function SetWindowLong(<[In]()> hWnd As IntPtr, nIndex As Integer, dwNewLong As UInt64) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="GetWindowLong")>
    Public Shared Function GetWindowLong(<[In]()> hWnd As IntPtr, nIndex As Integer) As UInt64
    End Function
    'Imports for Launch/Switch
    <DllImport("user32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)>
    Public Shared Function SetForegroundWindow(hwnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Private Declare Function ShowWindow Lib "user32.dll" (hWnd As IntPtr, nCmdShow As SHOW_WINDOW) As Boolean

#End Region

    Public Sub testparagon()
        If Directory.Exists("C:\Program Files (x86)\") = True Then
            programlocation = "C:\Program Files (x86)\"
        Else
            programlocation = "C:\Program Files\"
        End If

        Try
            Dim dirs As String() = Directory.GetDirectories(programlocation, "Paragon*")
            Dim dir As String
            For Each dir In dirs
                If File.Exists(dir & "\radiology_management.exe") Then
                    paragon = dir & "\"
                End If
            Next
        Catch ex As Exception
            If File.Exists(programlocation & "Paragon1401\radiology_management.exe") = True Then
                paragon = "Paragon1401\"
            Else
                MsgBox("Paragon is not installed on this machine, please contact IT about: " & My.Computer.Name.ToString, MsgBoxStyle.Critical, "Woops...")
                Application.Exit()
            End If
        End Try
        If paragon = "" Then
            MsgBox("Paragon is not installed on this machine, please contact IT about: " & My.Computer.Name.ToString, MsgBoxStyle.Critical, "Woops...")
            Application.Exit()
        End If
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TopMost = True
        Top = My.Computer.Screen.WorkingArea.Height - Height
        Left = 0
        If File.Exists(tf) Then
            Dim s() As String = File.ReadAllText(tf).Split(nl)
            For Each a As String In s
                If a <> "" And a <> " " And a <> "    " And a <> nl And a <> vbNullChar And a <> vbNullString Then
                    Dim totl() As String = a.TrimEnd.TrimStart.Split(Environment.NewLine)
                    For Each toad As String In totl
                        Dim tt As String = toad.Trim
                        If tt <> "" And tt <> Nothing Then
                            LstNotes.Items.Add(tt)
                            t.Add(tt)
                        End If
                    Next
                End If
            Next
        End If
        TmrCollect.Enabled = True
        testparagon()
        nonCheck()
    End Sub

    Private Function nonCheck() As String
        Dim thisStr = Windows.Forms.Clipboard.GetText().Trim()
        If lasStr = "" Then
            lasStr = thisStr
        ElseIf lasStr = "" Or (lasStr <> thisStr) Then
            lasStr = thisStr
            Return thisStr
        Else
            Return ""
        End If
    End Function

    Private Sub ListBox1_RightClick(sender As Object, e As MouseEventArgs) Handles LstNotes.MouseDown
        If e.Button = MouseButtons.Right Then
            mb = "Right"
            If LstNotes.Items.Count > 0 Then
                Try
                    Dim i As Integer = LstNotes.IndexFromPoint(e.X, e.Y)
                    Dim d As Integer = LstNotes.SelectedIndex
                    If i <> d Then
                        LstNotes.SelectedIndex = LstNotes.IndexFromPoint(e.X, e.Y)
                        If LstNotes.SelectedItems.Count > 0 Then
                            LstNotes.Items.RemoveAt(LstNotes.SelectedIndex)
                        End If
                    Else
                        LstNotes.Items.RemoveAt(LstNotes.SelectedIndex)
                    End If
                Catch ex As Exception
                    Try
                        LstNotes.Items.RemoveAt(LstNotes.SelectedIndex)
                    Catch ex2 As Exception
                        CMSave.Show(PointToScreen(e.Location))
                    End Try
                End Try
            Else
                LstNotes.SelectedIndex = LstNotes.IndexFromPoint(e.X, e.Y)
                If LstNotes.SelectedItems.Count > 0 Then
                    LstNotes.Items.RemoveAt(LstNotes.SelectedIndex)
                End If
            End If
        Else
            mb = "Left"
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles LstNotes.DoubleClick
        placest()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstNotes.SelectedIndexChanged

        If LstNotes.SelectedItems.Count > 0 Then
            If mb = "Left" Then
                Dim found = False
                Dim curstring As String = Clipboard.GetText().Trim
                For Each t1 In LstNotes.Items
                    If t1.ToString.Trim = curstring Then
                        found = True
                    End If
                Next
                If found = False And CheckListToolStripMenuItem.Font.Strikeout = False Then
                    Dim acttmr As Boolean = False
                    If TmrCollect.Enabled = True Then
                        acttmr = True
                        TmrCollect.Enabled = False
                    End If
                    Dim result As Integer = MessageBox.Show("Copy clipboard without saving string?", "Save String?", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        copyst()
                    Else
                        placest()
                        copyst()
                    End If
                    If acttmr = True Then
                        TmrCollect.Enabled = True
                    End If
                Else
                    copyst()
                End If
            Else
            End If
        End If
        mb = "Left"
    End Sub

    Private Sub placest()
        Dim s As String = Clipboard.GetText()
        LstNotes.Items.Add(s)
        t.Add(s)
    End Sub

    Private Sub copyst()
        If LstNotes.SelectedItems.Count.ToString > 0 Then
            Try
                Do Until Clipboard.GetText.Trim = LstNotes.SelectedItem.ToString.Trim
                    Clipboard.SetText(LstNotes.SelectedItem.ToString.Trim)
                Loop

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnRenew_Click(sender As Object, e As MouseEventArgs) Handles BtnRenew.Click
        CMSave.Show(PointToScreen(e.Location))
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        'Dim s As String = TxtMore.Text.Trim()
        addentry(True)
        'If TxtMore.Text <> "" Then
        '    If doSplit = True Then
        '        If s.Contains(nl) Then
        '            Dim ar() As String = s.Split(nl)
        '            For Each toad As String In ar
        '                LstNotes.Items.Add(toad)
        '                t.Add(toad)
        '            Next
        '        Else
        '            LstNotes.Items.Add(s)
        '        End If
        '    Else
        '            LstNotes.Items.Add(s)
        '    End If

        'LstNotes.Items.Add(s)
        't.Add(s)
        TxtMore.Clear()
            TxtMore.Focus()
        'End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        If LstNotes.Items.Count = 0 Then
            t.Clear()
        Else
            LstNotes.Items.Clear()
        End If
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        TxtMore.Top = BtnRenew.Height
        TxtMore.Left = 0
        TxtMore.Width = Width - 15
        TxtMore.Height = SplitContainer1.Panel1.Height - BtnRenew.Height
        LstNotes.Top = SplitContainer1.Panel2.Top
        LstNotes.Height = SplitContainer1.Panel2.Height - 2
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        LstNotes.Items.Clear()
        For Each Str As String In t
            LstNotes.Items.Add(Str)
        Next
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim s = New SaveFileDialog()
        s.OverwritePrompt = False
        s.Filter = "TXT Files|*.txt"
        If s.ShowDialog() = DialogResult.OK Then
            If s.FileName.Contains(".txt") Then
                Dim t1 As String = ""
                Dim c As Integer = LstNotes.Items.Count
                Dim i = 0
                For Each q1 As String In LstNotes.Items
                    i = i + 1
                    If i = c Then

                        t1 &= q1

                        Else

                        t1 &= q1 & nl

                    End If
                Next
                If File.Exists(s.FileName) Then
                    Dim result As Integer = MessageBox.Show("Overwrite Existing?", "Save File", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Yes Then
                        If result = DialogResult.Yes Then
                            Dim res As Integer = MessageBox.Show("Append to Existing File?", "Merge Text", MessageBoxButtons.YesNo)
                            If res = DialogResult.Yes Then
                                Try
                                    Dim temptxt As String = File.ReadAllText(s.FileName) & nl & t1
                                    File.WriteAllText(s.FileName, t1)
                                Catch
                                    MsgBox("File in use.", MsgBoxStyle.Exclamation, "Error")
                                End Try
                            Else
                                Try
                                    File.Delete(s.FileName)
                                    File.WriteAllText(s.FileName, t1)
                                Catch ex As Exception
                                    MsgBox("File in use.", MsgBoxStyle.Exclamation, "Error")
                                End Try
                            End If
                        End If
                    End If

                Else
                    Try

                        File.WriteAllText(s.FileName, t1)
                    Catch ex As Exception
                        MsgBox("File in use.", MsgBoxStyle.Exclamation, "Error")
                    End Try
                End If
            End If
        End If
        s.Dispose()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim s = New OpenFileDialog()
        s.Filter = "TXT Files|*.txt"
        If s.ShowDialog() = DialogResult.OK Then
            If s.FileName.ToString.ToUpper.Contains("TXT") Then
            Else
                MsgBox("Not a TXT file.", MsgBoxStyle.Exclamation, "Error")
            End If
            Dim a() As String = File.ReadAllText(s.FileName).Split(nl)
            LstNotes.Items.Clear()
            t.Clear()
            For Each st As String In a
                If st <> "" And st <> " " And st <> nl Then
                    LstNotes.Items.Add(st)
                    t.Add(st)
                End If
            Next
        End If
        s.Dispose()
    End Sub

    Private Sub writetemp()
        Dim c As Integer = LstNotes.Items.Count
        Dim i = 0
        Dim s As String = Nothing
        For Each t1 As String In LstNotes.Items
            i = i + 1
            If i = c Then
                If t1 <> "" Then
                    s &= t1
                End If
            Else
                If t1 <> "" Then
                    s &= t1 & nl
                End If
            End If
        Next
        If Directory.Exists(td) = False Then
            Directory.CreateDirectory(td)
        End If
        File.WriteAllText(tf, s)
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If File.Exists(tf) Then
            File.Delete(tf)
            writetemp()
        Else
            writetemp()
        End If
    End Sub

    Private Sub AutoCollectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoCollectToolStripMenuItem.Click
        autocollect()

    End Sub

    Public Sub autocollect(Optional ByVal dostop As Boolean = False)
        If dostop = True Then
            GoTo Stopit
        Else
            If TmrCollect.Enabled = False Then
                TmrCollect.Start()
                AutoCollectToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            Else
Stopit:
                TmrCollect.Stop()
                AutoCollectToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Strikeout)
            End If
        End If
    End Sub

    Private Sub TmrCollect_Tick(sender As Object, e As EventArgs) Handles TmrCollect.Tick
        addentry()
    End Sub

    Private Sub addentry(Optional ByVal man As Boolean = False)

        Try
            Dim a
            If man = True Then
                GoTo StartStop
            ElseIf doCheck = False And man = False Then
                GoTo ChekPre

            Else

                GoTo ChekPre
                'Dim s As String = TxtMore.Text.Trim()

                'If TxtMore.Text <> "" Then
                '    If doSplit = True Then
                '        If s.Contains(nl) Then
                '            Dim ar() As String = s.Split(nl)
                '            For Each toad As String In ar
                '                LstNotes.Items.Add(toad)
                '                t.Add(toad)
                '            Next
                '        Else
                '            LstNotes.Items.Add(s)
                '        End If
                '    Else
                '        LstNotes.Items.Add(s)
                '    End If
                'End If

            End If

ChekPre:
            Dim nowStr As String = nonCheck()
            If nowStr <> "" Then
                GoTo StartStop
            Else
                GoTo TheEnd

            End If

StartStop:

            If doSplit = True Then
                'Dim a() As String
                'SPLIT AND CLIP

                If man = False Then
                    a = Clipboard.GetText(TextDataFormat.Text).Split(nl)
                Else
                    a = TxtMore.Text.Trim.Split(nl)
                End If

                For Each toad As String In a
                    Dim got = False
                    Dim ct As String = toad.Trim
                    ' If doCheck = True Then
                    For Each s As String In LstNotes.Items
                        If s = ct Then
                            got = True
                        End If
                    Next
                    If got = False Or doCheck = False Then
                        LstNotes.Items.Add(ct)
                        t.Add(ct)
                    End If

                Next


            Else
                'DONT SPLIT
                If man = False Then
                    a = Clipboard.GetText()
                Else
                    a = TxtMore.Text
                End If

                Dim got = False
                Dim ct As String = a.Trim()
                'If doCheck = True Then
                For Each s As String In LstNotes.Items
                    If s = ct Then
                        got = True
                    End If
                Next
                If got = False Or doCheck = False Then
                    LstNotes.Items.Add(ct)
                    t.Add(ct)
                End If
                'Else
                '    t.Add(ct)
                'End If
            End If

TheEnd:
            Exit Sub

        Catch
        End Try
    End Sub

    Private Sub TopMostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopMostToolStripMenuItem.Click
        If TopMost = True Then
            TopMost = False
            TopMostToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Strikeout)
        Else
            TopMost = True
            TopMostToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        End If
    End Sub

    Private Sub CheckListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckListToolStripMenuItem.Click
        If CheckListToolStripMenuItem.Font.Strikeout = True Then
            CheckListToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            doCheck = True
            lasStr = ""
        Else
            CheckListToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Strikeout)
            doCheck = False
            nonCheck()
        End If
    End Sub


    Private Sub MergeTrashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeTrashToolStripMenuItem.Click
        Try
            autocollect(True)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information, "autocollect")
        End Try

        Try
            MCKPACS64or86("alihmicafhost")
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information, "MCKPACS64or86")
        End Try

        'Threading.Thread.Sleep(2000)
        Try
            'Dim result As MsgBoxResult = Nothing

            'result = MsgBox("Carry out procedure?", vbYesNo, "Start?")

            'If result <> MsgBoxResult.Yes Then
            '    Exit Sub

            'End If
            mergetrash()


        Catch ex As Exception

        End Try
    End Sub


    '        'Do While LblStopMerge.Text = "0"
    'Me.TopMost = True


    'If msgboxautoclose("Stop the merge?", MsgBoxStyle.YesNo, "Stop", 5) = True Then
    '    Exit Sub
    'End If

    'Me.TopMost = False





    'If LblStopMerge.Text = "1" Then
    '    Exit Sub

    'End If

#Region "MCK PACS"

    'Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte,
    '                   ByVal bScan As Byte,
    '                   ByVal dwFlags As Byte,
    '                   ByVal dwExtraInfo As Byte)

    'Private Const VK_RETURN As Byte = &HD
    'Private Const KEYEVENTF_KEYDOWN As Byte = &H0
    'Private Const KEYEVENTF_KEYUP As Byte = &H2



    'Private Function msgboxautoclose(ByVal Message As String, Optional ByVal Style As MsgBoxStyle = MsgBoxStyle.YesNo, Optional ByVal title As String = Nothing, Optional ByVal delay As Integer = 5) As Boolean

    '    '5 second default delay
    '    Try
    '        Dim t As New Threading.Thread(AddressOf closeMsgbox)
    '        t.Start(delay)
    '        Dim result As MsgBoxResult = Nothing
    '            result = MsgBox(Message, Style, title)
    '            If result = MsgBoxResult.Yes Then
    '                Return True
    '            ElseIf result = MsgBoxResult.No Then
    '                Return False
    '            End If
    '        Return False
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "MsbBoxAutoClose")
    '    End Try

    'End Function


    'Private Function closeMsgbox(ByVal delay As Object)
    '    Threading.Thread.Sleep(CInt(delay) * 1000)
    '    AppActivate(Me.Text)
    '    keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, 0)
    '    keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0)
    'End Function

    Public Sub mergetrash()


        For Each i As String In LstNotes.Items

            startoth("_MCKOccasionalScreen", 4)


            Try


                Dim success = False
                Do Until success = True
                    Try
                        Clipboard.SetText(i.ToString.Trim)
                        success = True
                    Catch ex As Exception

                    End Try

                Loop

                Try
                    StartProcWait("_MCKPACSMergePatient")

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "MergePatientError")
                End Try



            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "CopyToClip")
            End Try
        Next

        killoth(4)



        LstNotes.Items.Clear()

        'Loop
        'LblStopMerge.Text = "0"
    End Sub

    Public Sub killoth(i As Integer)
        Dim t1 = 1

        Do Until t1 = i + 1
            For Each proc As Process In Process.GetProcessesByName("_MCKOccasionalScreen" & t.ToString)
                proc.Kill()

            Next

            t1 = t1 + 1
        Loop


    End Sub

    'Open MCK PACS
    Private Shared Sub MaximizeMCKPACS()
        Dim hwnd As IntPtr
        Dim prc() As Process = Process.GetProcessesByName("alihmicafhost")
        If Not prc Is Nothing AndAlso Not prc.Length = 0 Then
            hwnd = prc(0).MainWindowHandle
            SetForegroundWindow(hwnd)
            ShowWindow(hwnd, SHOW_WINDOW.SW_MAXIMIZE)
        End If
    End Sub

    Public Sub MCKPACS64or86(exe As String)

        Dim prc() As Process = Process.GetProcessesByName(exe)
        Dim hwnd As IntPtr
        If Not prc Is Nothing AndAlso Not prc.Length = 0 Then
            hwnd = prc(0).MainWindowHandle
            Try
                SetForegroundWindow(hwnd)
            Catch ex As Exception

            End Try

            Try
                MaximizeMCKPACS()
            Catch ex As Exception

            End Try

            Thread.Sleep(200)
        Else
            'Dim ofile As String = "\\omc-app01\fcd\thinstall\store\cmccarty\radiology\mckpacs.exe"
            ''If File.Exists(ofile) Then
            '    File.Copy(ofile, ad & "mckpacs.exe", True)
            'End If 
            Try
                If Directory.Exists("c:\Program Files (x86)\") = True Then

                    Process.Start(programlocation & "Internet Explorer\iexplore.exe", "http://pacs.obmc.org/hrs/")

                Else
                    Process.Start(programlocation & "Internet Explorer\iexplore.exe", "http://pacs.obmc.org/hrs/")

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "launch ie mck")
            End Try

            Thread.Sleep(200) ' give some time to create a main window (probably not needed)
            StartProcWait("mckpacs")
            StartProcWait("_MCKSearch1111")
        End If
    End Sub
    '
    Public Sub startoth(filename As String, i As Integer)

        Dim t1 = 1

        Do Until t1 = i + 1
            Dim thefile As String = ad & filename & t.ToString & ".exe"
            Dim isfound = False

            ' ReSharper disable once RedundantAssignment
            For Each proc As Process In Process.GetProcessesByName(filename & t.ToString)
                isfound = True
            Next
            If isfound = False Then
                Process.Start(thefile)
            End If

            t1 = t1 + 1
        Loop

    End Sub


    'Public Sub StartIfNotRunningAD(filename As String) ' As Boolean

    '    Try

    '        Dim thefile As String = ad & filename & ".exe"
    '        Dim isfound As Boolean = False

    '        ' ReSharper disable once RedundantAssignment
    '        For Each proc As Process In Process.GetProcessesByName(filename)
    '            isfound = True
    '        Next
    '        If isfound = False Then
    '            Process.Start(thefile)
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Error Opening " & filename.ToString)
    '    End Try

    'End Sub

    Public Sub StartIfNotRunningPath(filename As String, path As String) ' As Boolean

        Try

            Dim thefile As String = path & filename & ".exe"
            Dim isfound = False

            ' ReSharper disable once RedundantAssignment
            For Each proc As Process In Process.GetProcessesByName(filename)
                isfound = True
            Next
            If isfound = False Then
                Process.Start(thefile)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Opening " & filename.ToString)
        End Try

    End Sub
    Public Sub StartProcWait(filename As String, Optional ByVal tmout As Integer = Nothing) ' As Boolean
        Try

            For Each proc As Process In Process.GetProcessesByName(filename)
                proc.Kill()
            Next

            Dim thefile As String = ad & filename & ".exe"
            Dim p = New Process
            ' Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.FileName = thefile

            p.Start()
            If tmout = Nothing Then
                p.WaitForExit()
            Else
                p.WaitForExit(tmout)
                For Each proc As Process In Process.GetProcessesByName(filename)
                    proc.Kill()
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Opening " & filename.ToString)
        End Try

    End Sub




    'Private Shared Function GetNumOutputChars(process As Process, timeoutInMilliseconds As Integer) As Integer
    '    Dim counter As Object = 0
    '    Event DataReceived As Process.OutputDataReceived

    '    process.OutputDataReceived += Function(sender, e)
    '                                      If e.Data IsNot Nothing Then
    '                                          counter += e.Data.Length
    '                                      End If

    '                                  End Function

    '    process.BeginOutputReadLine()

    '    If Not process.WaitForExit(timeoutInMilliseconds) Then
    '        process.Kill()
    '        Return 0
    '    End If

    '    Return counter
    'End Function


    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        LstNotes.Items.Clear()
    End Sub

    Private Sub ClickToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClickToolStripMenuItem.Click
        StartIfNotRunningPath("Capture2Text", "C:\Capture2Text_v4.3.0_64bit\")
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        autocollect(True)
        Dim curstring = ""
        For Each t1 As String In LstNotes.Items
            curstring &= t1 & Environment.NewLine
        Next
        Dim success = False
        Do Until success = True
            Try
                Clipboard.SetText(curstring)
                success = True
            Catch ex As Exception

            End Try
        Loop
    End Sub

    Private Sub SplitLinesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitLinesToolStripMenuItem.Click
        If SplitLinesToolStripMenuItem.Font.Strikeout = True Then
            doSplit = True
            SplitLinesToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        Else
            SplitLinesToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Strikeout)
            doSplit = False
        End If
    End Sub


#End Region

End Class
