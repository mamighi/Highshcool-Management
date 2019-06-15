
Partial Class EditModule
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadLecturer()
            loadModuleList()
            loadIntakes()
        End If
    End Sub
    Public Sub loadModuleList()
        Dim modules As List(Of String) = ts.getModules()
        DropDownList5.Items.Clear()
        DropDownList5.Items.Add("MODULES")
        For Each modu As String In modules
            DropDownList5.Items.Add(modu)
        Next
    End Sub
    Public Sub loadLecturer()
        Dim le As List(Of String) = ts.getLecturer()
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("LECTURERS")
        For Each modu As String In le
            DropDownList1.Items.Add(modu)
        Next
    End Sub
    Public Sub loadIntakes()
        Dim le As List(Of String) = ts.getIntakes()
        DropDownList4.Items.Clear()
        DropDownList4.Items.Add("INTAKES")
        For Each modu As String In le
            DropDownList4.Items.Add(modu)
        Next
    End Sub

    Protected Sub DropDownList5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList5.SelectedIndexChanged
        Dim details As List(Of String) = ts.getModuleDetails(DropDownList5.SelectedItem.ToString())
        TextBox2.Text = details.ElementAt(0)
        DropDownList1.SelectedItem.Selected = False

        DropDownList1.Items.FindByText(details.ElementAt(1)).Selected = True
        DropDownList2.SelectedItem.Selected = False
        DropDownList2.Items.FindByText(details.ElementAt(2)).Selected = True
        Dim dur As Integer = Int32.Parse(details.ElementAt(3))
        Dim index = (dur / 30) - 1
        DropDownList3.SelectedIndex = index
        DropDownList4.SelectedItem.Selected = False
        DropDownList4.Items.FindByText(details.ElementAt(4)).Selected = True
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim code, name, lecturer, day, intake As String
        Dim dur As Integer
        code = DropDownList5.SelectedItem.ToString()
        name = TextBox2.Text
        lecturer = DropDownList1.SelectedItem.ToString()
        day = DropDownList2.SelectedItem.ToString()
        dur = DropDownList3.SelectedIndex * 30 + 30
        intake = DropDownList4.SelectedItem.ToString()
        If (code.Length < 1 Or name.Length < 2) Then
            Label3.Text = "Please Insert All Information."
            Label3.Visible = True
            Return
        End If
        Dim retVal As Boolean = ts.updateModule(code, name, lecturer, day, dur, intake)
        If (retVal) Then
            Session("MSG") = "Module Updated Successfully."
            Response.Redirect("SuccessMsg.aspx")
        Else
            Label3.Text = "Failed to add new module."
            Label3.Visible = True
        End If


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
