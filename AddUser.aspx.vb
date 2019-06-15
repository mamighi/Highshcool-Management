
Partial Class AddUser
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadIntakes()
            loadStudent()

        End If
    End Sub
    Public Sub loadIntakes()
        Dim intakes As List(Of String) = New List(Of String)
        intakes = ts.getIntakes()
        DropDownList2.Items.Clear()
        DropDownList2.Items.Add("INTAKE")
        For Each intake As String In intakes
            DropDownList2.Items.Add(intake)
        Next

    End Sub
    Public Sub loadStudent()
        Dim students As List(Of String) = New List(Of String)
        students = ts.getStudents()

        DropDownList3.Items.Clear()
        DropDownList3.Items.Add("STUDENTS")
        For Each student As String In students
            DropDownList3.Items.Add(student)
        Next
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        DropDownList2.Visible = False
        DropDownList3.Visible = False
        Label4.Visible = False
        Label5.Visible = False

        If (DropDownList1.SelectedItem.ToString().Equals("STUDENT")) Then
            DropDownList2.Visible = True
            Label5.Visible = True
        End If
        If (DropDownList1.SelectedItem.ToString().Equals("PARENT")) Then
            DropDownList3.Visible = True
            Label4.Visible = True
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim us, pas, fn, ln, typ As String
        If (TextBox4.Text.Equals(TextBox5.Text)) Then
        Else
            Label3.Text = "Passwords not match."
            Label3.Visible = True
            Return
        End If
        If (TextBox1.Text.Length() < 1 Or TextBox2.Text.Length() < 1 Or TextBox3.Text.Length() < 1 Or TextBox4.Text.Length() < 1) Then
            Label3.Text = "Please insert all the information."
            Label3.Visible = True
            Return
        End If
        If (DropDownList1.SelectedItem.ToString().Equals("PARENT") And DropDownList3.SelectedItem.ToString().Equals("STUDENTS")) Then
            Label3.Text = "Please choose the student."
            Label3.Visible = True
            Return
        End If
        us = TextBox1.Text.ToString()
        pas = TextBox4.Text.ToString()
        fn = TextBox2.Text.ToString()
        ln = TextBox3.Text.ToString()
        Dim retVal As Boolean = ts.addUser(us, pas, fn, ln, DropDownList1.SelectedItem.ToString().ToLower)
        If (retVal) Then
            If (DropDownList1.SelectedItem.ToString().Equals("STUDENT")) Then
                retVal = ts.addStudent(us, DropDownList2.SelectedItem.ToString())
            ElseIf (DropDownList1.SelectedItem.ToString().Equals("PARENT")) Then
                retVal = ts.addParent(us, DropDownList3.SelectedItem.ToString())
            End If
        End If
        If (retVal) Then
            Session("MSG") = "User Added Successfully."
            Response.Redirect("SuccessMsg.aspx")
        Else
            Label3.Text = "Failed to add new user."
        End If

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
