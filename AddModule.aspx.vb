
Partial Class AddModule
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim code, name, lecturer, day, intake As String
        Dim dur As Integer
        code = TextBox1.Text
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
        Dim retVal As Boolean = ts.addModule(code, name, lecturer, day, dur, intake)
        If (retVal) Then
            Session("MSG") = "Module Added Successfully."
            Response.Redirect("SuccessMsg.aspx")
        Else
            Label3.Text = "Failed to add new module."
            Label3.Visible = True
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadLecturer()
            loadIntake()

        End If
    End Sub
    Public Sub loadLecturer()
        Dim lecturers As List(Of String) = New List(Of String)
        lecturers = ts.getLecturer()
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("LECTURER")
        For Each lecturer As String In lecturers
            DropDownList1.Items.Add(lecturer)

        Next
    End Sub
    Public Sub loadIntake()
        Dim Intakes As List(Of String) = New List(Of String)
        Intakes = ts.getIntakes()
        DropDownList4.Items.Clear()
        DropDownList4.Items.Add("INTAKE")
        For Each intake As String In Intakes
            DropDownList4.Items.Add(intake)

        Next
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
