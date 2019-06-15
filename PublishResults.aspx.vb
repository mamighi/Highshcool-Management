
Partial Class PublishResults
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadIntake()

        End If
        If (IsPostBack) Then
            loadlist()
        End If
    End Sub
    Public Sub loadlist()
        Dim students As List(Of String) = ts.getStudentByIntake(DropDownList1.SelectedItem.ToString())
        Dim ids As Integer = 0
        Table1.Rows.Clear()
        Table1.BackColor = System.Drawing.Color.LightBlue
        Dim tbrow1 As TableRow = New TableRow()
        Dim cellId1 As TableCell = New TableCell()
        cellId1.Text = "NUMBER"
        cellId1.Width = 50
        Dim cellSt1 As TableCell = New TableCell()
        cellSt1.Text = "STUDENT ID"
        cellSt1.Width = 150
        Dim cellatt1 = New TableCell()
        cellatt1.Text = "RESULT"
        cellatt1.Width = 250
        tbrow1.Cells.Add(cellId1)
        tbrow1.Cells.Add(cellSt1)
        tbrow1.Cells.Add(cellatt1)
        Table1.Rows.Add(tbrow1)
        For Each student As String In students
            ids = ids + 1
            Dim ddl As DropDownList = New DropDownList()
            ddl.Items.Add("A+")
            ddl.Items.Add("A")
            ddl.Items.Add("B+")
            ddl.Items.Add("B")
            ddl.Items.Add("C+")
            ddl.Items.Add("C")
            ddl.Items.Add("D+")
            ddl.Items.Add("D")
            ddl.Items.Add("D")
            Dim tbrow As TableRow = New TableRow()
            Dim cellId As TableCell = New TableCell()
            cellId.Text = ids.ToString() + ""
            Dim cellSt As TableCell = New TableCell()
            cellSt.Text = student
            Dim cellatt = New TableCell()
            cellatt.Controls.Add(ddl)
            tbrow.Cells.Add(cellId)
            tbrow.Cells.Add(cellSt)
            tbrow.Cells.Add(cellatt)
            Table1.Rows.Add(tbrow)
        Next
        Table1.EnableViewState = True
        ViewState("Table1") = True

    End Sub
    Public Sub loadModuleList()
        Dim modules As List(Of String) = ts.getModuleByIntake(DropDownList1.SelectedItem.ToString())
        DropDownList2.Items.Clear()
        DropDownList2.Items.Add("MODULES")
        For Each modu As String In modules
            DropDownList2.Items.Add(modu)
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        loadModuleList()
        loadlist()
    End Sub
    Protected Sub loadIntake()
        Dim intakes As List(Of String) = New List(Of String)
        intakes = ts.getIntakes()
        DropDownList1.Items.Clear()
        DropDownList1.Items.Add("INTAKE")
        For Each intake As String In intakes
            DropDownList1.Items.Add(intake)
        Next

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (DropDownList1.SelectedItem.ToString.Equals("INTAKE") Or DropDownList2.SelectedItem.ToString().Equals("MODULES")) Then
            Label3.Text = "Please select intake and module."
            Label3.Visible = True
            Return
        End If
        If (ts.isResultPublished(DropDownList2.SelectedItem.ToString)) Then
            Label3.Text = "The result for this module is already published."
            Label3.Visible = True
            Return
        End If
        Dim studentlist As List(Of String) = New List(Of String)
        Dim attendencest As List(Of String) = New List(Of String)
        For value As Integer = 1 To Table1.Rows.Count - 1
            Dim row As TableRow = Table1.Rows(value)
            Dim stID As String = row.Cells(1).Text.ToString()
            Dim drl As DropDownList = row.Cells(2).Controls(0)
            Dim attSts = drl.SelectedItem.ToString()
            studentlist.Add(stID)
            attendencest.Add(attSts)
        Next
        Dim modul As String = DropDownList2.SelectedItem.ToString()
        Dim today As DateTime = Date.Today
        ts.PublishResult(modul, studentlist, attendencest)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("AdminHome.aspx")
    End Sub
End Class
