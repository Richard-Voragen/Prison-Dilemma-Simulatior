Public Class Form2
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        TextBox1.Text = TrackBar1.Value
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Forms.Form1.Timer1.Interval
        CheckBox1.Checked = My.Forms.Form1.Loops
        TrackBar1.Value = My.Forms.Form1.Timer1.Interval
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        My.Forms.Form1.Timer1.Interval = TrackBar1.Value
        My.Forms.Form1.Loops = CheckBox1.Checked
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TrackBar1.Value = CInt(TextBox1.Text)
    End Sub
End Class