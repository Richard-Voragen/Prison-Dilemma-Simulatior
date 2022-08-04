Public Class Form1

    Public Loops As Boolean = False

    Private AllButtons() As Button
    Private Mainlist As New ListBox
    Private Sub ButtonHandler(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click, Button99.Click, Button98.Click, Button97.Click, Button96.Click, Button95.Click, Button94.Click, Button93.Click, Button92.Click, Button91.Click, Button90.Click, Button89.Click, Button88.Click, Button87.Click, Button86.Click, Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button80.Click, Button79.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button71.Click, Button70.Click, Button69.Click, Button68.Click, Button67.Click, Button66.Click, Button65.Click, Button64.Click, Button63.Click, Button62.Click, Button61.Click, Button60.Click, Button59.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button50.Click, Button49.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button40.Click, Button39.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button100.Click
        Guesses.Text = CInt(Guesses.Text) - 1

        Dim location As Integer = CInt(sender.ToString().Remove(0, 35)) - 1
        Dim btn As Button = AllButtons(location)
        btn.ForeColor = Color.Red
        If Timer1.Interval > 10 Then
            btn.BackColor = Color.LightPink
        End If
        btn.Text = Mainlist.Items.Item(location)
        If Mainlist.Items.Item(location) = Inmate Then
            CheckedListBox1.SetItemChecked(CheckedListBox1.Items.Count - 1, True)
            NextInmate()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AllButtons = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button10, Button11, Button12, Button13, Button14, Button15, Button16, Button17, Button18, Button19, Button20, Button21, Button22, Button23, Button24, Button25, Button26, Button27, Button28, Button29, Button30, Button31, Button32, Button33, Button34, Button35, Button36, Button37, Button38, Button39, Button40, Button41, Button42, Button43, Button44, Button45, Button46, Button47, Button48, Button49, Button50, Button51, Button52, Button53, Button54, Button55, Button56, Button57, Button58, Button59, Button60, Button61, Button62, Button63, Button64, Button65, Button66, Button67, Button68, Button69, Button70, Button71, Button72, Button73, Button74, Button75, Button76, Button77, Button78, Button79, Button80, Button81, Button82, Button83, Button84, Button85, Button86, Button87, Button88, Button89, Button90, Button91, Button92, Button93, Button94, Button95, Button96, Button97, Button98, Button99, Button100}
        For Each btn As Button In AllButtons
            btn.Text = CInt(btn.Name.Remove(0, 6))
        Next
        Label1.Text = ""
        GameEnabled(False)
    End Sub

    Private Sub CountLoops(cutlist As Boolean)
        Dim list As New ListBox
        For Each item As Integer In Mainlist.Items
            list.Items.Add(item)
        Next
        Dim newList As New ListBox
        Label1.ResetText()
        While list.Items.Count > 0
            newList.Items.Clear()
            Dim starting As Integer = Mainlist.Items.IndexOf(list.Items.Item(0)) + 1
            Dim current As Integer = list.Items.Item(0)
            newList.Items.Add(starting)
            list.Items.Remove(starting)
            While current <> starting
                newList.Items.Add(current)
                list.Items.Remove(current)
                current = Mainlist.Items.Item(current - 1)
            End While
            If cutlist And newList.Items.Count > 50 Then
                Dim temp As Integer = Mainlist.Items.Item(CInt(newList.Items.Count / 2))
                Mainlist.Items.Item(CInt(newList.Items.Count / 2)) = starting
                Mainlist.Items.Item(newList.Items.Count) = temp
            End If
            Label1.Text = Label1.Text + "Length: " + newList.Items.Count().ToString + " {" + StringOutput(newList) + "}" + Environment.NewLine
        End While
    End Sub

    Private Function StringOutput(list As ListBox) As String
        Dim output As String = list.Items.Item(0)
        Dim i As Integer = 1

        While i < list.Items.Count
            output += ", " + list.Items.Item(i).ToString
            i += 1
        End While
        Return output
    End Function

    Dim rand As New Random
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim temps As New ListBox
        Mainlist.Items.Clear()
        Inmates.Items.Clear()

        For i As Integer = 1 To 100
            temps.Items.Add(i)
            Inmates.Items.Add(i)
        Next
        Dim index As Integer
        While temps.Items.Count > 0
            index = rand.Next(0, temps.Items.Count)
            Mainlist.Items.Add(temps.Items.Item(index))
            temps.Items.RemoveAt(index)
        End While

        CheckedListBox1.Items.Clear()

        NextInmate()
        CountLoops(False)
        GameEnabled(True)

    End Sub

    Dim Inmate As Integer
    Private Inmates As New ListBox

    Private Sub NextInmate()
        Guesses.Text = 50

        If Inmates.Items.Count = 0 Then
            Timer1.Stop()
            MsgBox("Prisoners Set Free")
        Else

            Inmate = Inmates.Items.Item(rand.Next(0, Inmates.Items.Count))
        Inmates.Items.Remove(Inmate)
        CheckedListBox1.Items.Add("Inmate " + Inmate.ToString + " walks in")

        For Each btn As Button In AllButtons
            btn.ForeColor = Color.Black
            If Timer1.Interval > 10 Then
                btn.BackColor = Color.White
            End If
            btn.Text = CInt(btn.Name.Remove(0, 6))
        Next

        CheckedListBox1.TopIndex = CheckedListBox1.Items.Count - 1

        Timer1.Stop()
        If Loops Then
            If StrategicPlay Then
                Strategy.PerformClick()
            Else
                Random.PerformClick()
            End If
        End If
        End If
    End Sub

    Dim StrategicPlay As Boolean
    Dim randomboxes As New ListBox
    Private Sub Random_Click(sender As Object, e As EventArgs) Handles Random.Click
        If Timer1.Enabled Then
            Timer1.Stop()
        Else
            If CInt(Guesses.Text) = 50 Then
                StrategicPlay = False
                randomboxes.Items.Clear()

                For Each item As Integer In Mainlist.Items
                    randomboxes.Items.Add(item)
                Next
            End If
            Timer1.Start()
        End If
    End Sub

    Dim currentTrial As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If StrategicPlay Then
            AllButtons(currentTrial - 1).PerformClick()
            currentTrial = Mainlist.Items.Item(currentTrial - 1)
        Else
            Dim ran As Integer = randomboxes.Items.Item(rand.Next(0, randomboxes.Items.Count))
            AllButtons(ran - 1).PerformClick()
            randomboxes.Items.Remove(ran)
        End If
    End Sub

    Private Sub Guesses_TextChanged(sender As Object, e As EventArgs) Handles Guesses.TextChanged
        If Guesses.Text = "0" Then
            Timer1.Stop()
            GameEnabled(False)
        End If
    End Sub

    Private Sub GameEnabled(enabled As Boolean)
        If enabled Then
            For Each btn As Button In AllButtons
                btn.Enabled = True
            Next
            Random.Enabled = True
            Strategy.Enabled = True
        Else
            For Each btn As Button In AllButtons
                btn.Enabled = False
            Next
            Random.Enabled = False
            Strategy.Enabled = False
        End If
    End Sub

    Private Sub Strategy_Click(sender As Object, e As EventArgs) Handles Strategy.Click
        If Timer1.Enabled Then
            Timer1.Stop()
        Else
            If CInt(Guesses.Text) = 50 Then
                StrategicPlay = True
                currentTrial = Inmate
            End If
            Timer1.Start()
        End If
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        My.Forms.Form2.Show()
    End Sub
End Class
