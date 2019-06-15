
Partial Class AddIntake
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim code, des As String
        Dim fee As Double

        code = TextBox1.Text
        des = TextBox2.Text
        Dim parseRetVal As Boolean = Integer.TryParse(TextBox3.Text, fee)
        If (parseRetVal = False) Then
            Label3.Text = "Fee value is invalid."
            Label3.Visible = True
            Return
        End If

        If (code.Length < 1 Or des.Length < 1) Then
            Label3.Text = "please insert all the values."
            Label3.Visible = True
            Return
        End If
        Dim retVal As Boolean = ts.addIntake(code, des, fee)
        If (retVal) Then
            Session("MSG") = "Intake Added Successfully."
            Response.Redirect("SuccessMsg.aspx")
        Else
            Label3.Text = "Failed to add new module."
            Label3.Visible = True
            Return
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
