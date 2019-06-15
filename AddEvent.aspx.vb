
Partial Class AddEvent
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text.Length < 1 Or TextBox2.Text.Length < 1) Then
            Label3.Text = "Please insert title and description."
            Label3.Text = True
            Return
        End If
        ts.AddEvent(TextBox1.Text, TextBox2.Text, Calendar1.SelectedDate)
        Session("MSG") = "Event Added Successfully."
        Response.Redirect("SuccessMsg.aspx")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Calendar1.SelectedDate = Date.Today

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
