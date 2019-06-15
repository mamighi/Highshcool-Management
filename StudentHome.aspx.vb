
Partial Class StudentHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACC") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
        If Session("ACC").ToString().Equals("student") = False Then
            Response.Redirect("default.aspx")
        End If
        Label2.Text = "WELCOME " + Session("USER").ToString().ToUpper()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("StudentTimeTabel.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FeeStatment.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("ReportCard.aspx")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Response.Redirect("ViewEvents.aspx")
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Session("USER") = ""
        Session("ACC") = ""
        Response.Redirect("Default.aspx")
    End Sub
End Class
