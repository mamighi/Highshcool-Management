
Partial Class SuccessMsg
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Session("ACC") Is Nothing Then
            Response.Redirect("default.aspx")
        End If
        If Session("ACC").ToString().Equals("admin") = True Then
            Response.Redirect("AdminHome.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("MSG") Is Nothing Then
            Return
        End If
        Label2.Text = Session("MSG").ToString()
    End Sub
End Class
