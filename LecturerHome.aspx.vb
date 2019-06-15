
Partial Class LecturerHome
    Inherits System.Web.UI.Page

    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Response.Redirect("ViewEvents.aspx")
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Session("USER") = ""
        Session("ACC") = ""
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Response.Redirect("ReportCard_SP.aspx")
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Response.Redirect("AddAttendence.aspx")
    End Sub

    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Response.Redirect("ViewAttendece.aspx")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("ACC") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
        If Session("ACC").ToString().Equals("lecturer") = False Then
            Response.Redirect("default.aspx")
        End If
        Label2.Text = "WELCOME " + Session("USER").ToString().ToUpper()
    End Sub
End Class
