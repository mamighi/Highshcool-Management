
Partial Class EditUser
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadUsers()
            loadStudent()
            loadIntakes()
        End If
    End Sub
    Public Sub loadUsers()
        DropDownList4.Items.Clear()
        DropDownList4.Items.Add("USER")
        Dim users As List(Of String) = ts.getUserNames()
        For Each User As String In users
            DropDownList4.Items.Add(User)
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
    Public Sub loadIntakes()
        Dim intakes As List(Of String) = New List(Of String)
        intakes = ts.getIntakes()
        DropDownList2.Items.Clear()
        DropDownList2.Items.Add("INTAKE")
        For Each intake As String In intakes
            DropDownList2.Items.Add(intake)
        Next
    End Sub

    Protected Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged
        If (DropDownList4.SelectedItem.Equals("USER")) Then
            Return
        End If
        DropDownList2.Visible = False
        DropDownList3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Dim selectedUser As String = DropDownList4.SelectedItem.ToString()
        Dim details As List(Of String) = ts.getUserDetails(selectedUser)
        TextBox2.Text = details.ElementAt(0)
        TextBox3.Text = details.ElementAt(1)
        TextBox4.Text = details.ElementAt(2)
        TextBox5.Text = details.ElementAt(2)
        TextBox6.Text = details.ElementAt(3)

        If (details.ElementAt(3).TrimEnd().Equals("student")) Then
            Label5.Visible = True
            DropDownList2.SelectedItem.Selected = False
            DropDownList2.Items.FindByText(ts.getStudentIntake(selectedUser)).Selected = True
            DropDownList2.Visible = True
        ElseIf (details.ElementAt(3).TrimEnd().Equals("parent")) Then
            Label4.Visible = True
            DropDownList3.SelectedItem.Selected = False
            DropDownList3.Items.FindByText(ts.getParentStudent(selectedUser)).Selected = True
            DropDownList3.Visible = True
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
        If (TextBox2.Text.Length() < 1 Or TextBox3.Text.Length() < 1 Or TextBox4.Text.Length() < 1) Then
            Label3.Text = "Please insert all the information."
            Label3.Visible = True
            Return
        End If
        typ = TextBox6.Text
        us = DropDownList4.SelectedItem.ToString
        pas = TextBox4.Text.ToString()
        fn = TextBox2.Text.ToString()
        ln = TextBox3.Text.ToString()
        ts.updateUser(us, fn, ln, pas)
        If (typ.Equals("student")) Then
            ts.updateStudentIntake(us, DropDownList2.SelectedItem.ToString())
        ElseIf (typ.Equals("parent")) Then
            ts.updateParentStudent(us, DropDownList3.SelectedItem.ToString())

        End If
        Session("MSG") = "User Updated Successfully."
        Response.Redirect("SuccessMsg.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
