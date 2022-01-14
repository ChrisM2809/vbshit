Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim command As New OleDbCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        adapter1 = New OleDbDataAdapter()
    End Sub

End Class