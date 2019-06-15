

Partial Class _Default

    Inherits Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label2.Visible = False
        Dim username, password As String
        username = TextBox1.Text.ToString().ToLower()
        password = TextBox2.Text.ToString()
        Dim acctyp As String
        acctyp = ts.login(username, password)
        Session.Add("USER", username)
        Session.Add("ACC", acctyp)
        If (acctyp.Equals("admin")) Then
            Response.Redirect("AdminHome.aspx")
        ElseIf (acctyp.Equals("student")) Then
            Response.Redirect("StudentHome.aspx")
        ElseIf (acctyp.Equals("lecturer")) Then
            Response.Redirect("LecturerHome.aspx")
        ElseIf (acctyp.Equals("parent")) Then
            Response.Redirect("ParentHome.aspx")
        Else
            Label2.Text = "Wrong User Name Or Password"
            Label2.Visible = True
        End If

    End Sub
End Class