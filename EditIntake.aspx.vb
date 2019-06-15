
Partial Class EditIntake
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadIntakes()
        End If
    End Sub
    Public Sub loadIntakes()
        Dim intakes As List(Of String) = ts.getIntakes()
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("INTAKE")
        For Each intake As String In intakes
            DropDownList1.Items.Add(intake)
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim details As List(Of String) = ts.getIntakeDetails(DropDownList1.SelectedItem.ToString())
        TextBox2.Text = details.ElementAt(0)
        TextBox3.Text = details.ElementAt(1)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim code, des As String
        Dim fee As Double

        code = DropDownList1.SelectedItem.ToString()
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
        ts.updateIntake(code, des, fee)

        Session("MSG") = "Intake Updated Successfully."
        Response.Redirect("SuccessMsg.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
