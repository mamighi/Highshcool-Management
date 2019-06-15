
Partial Class ViewAttendece
    Inherits System.Web.UI.Page
    Dim ts As TaskManager = New TaskManager()
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        loadModuleList()

    End Sub
    Public Sub loadModuleList()
        Dim modules As List(Of String) = ts.getModuleByIntake(DropDownList1.SelectedItem.ToString())
        DropDownList2.Items.Clear()
        DropDownList2.Items.Add("MODULES")
        For Each modu As String In modules
            DropDownList2.Items.Add(modu)
        Next
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack = False) Then
            loadIntake()

        End If
       
    End Sub
    Public Sub loadlist()
        Dim students As List(Of List(Of String)) = ts.loadClassAttendence(DropDownList2.SelectedItem.ToString(), (DropDownList1.SelectedItem.ToString()))
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
        cellatt1.Text = "ATTENDENCE"
        cellatt1.Width = 250
        tbrow1.Cells.Add(cellId1)
        tbrow1.Cells.Add(cellSt1)
        tbrow1.Cells.Add(cellatt1)
        Table1.Rows.Add(tbrow1)
        For Each student As List(Of String) In students
            ids = ids + 1
            Dim tbrow As TableRow = New TableRow()
            Dim cellId As TableCell = New TableCell()
            cellId.Text = ids.ToString() + ""
            Dim cellSt As TableCell = New TableCell()
            cellSt.Text = student.ElementAt(0)
            Dim cellatt = New TableCell()
            cellatt.Text = student.ElementAt(1)
            tbrow.Cells.Add(cellId)
            tbrow.Cells.Add(cellSt)
            tbrow.Cells.Add(cellatt)
            Table1.Rows.Add(tbrow)
        Next
        Table1.EnableViewState = True
        ViewState("Table1") = True

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

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        loadlist()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("LecturerHome.aspx")
    End Sub
End Class
