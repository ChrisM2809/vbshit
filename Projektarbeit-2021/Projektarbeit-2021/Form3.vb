Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim command As New OleDbCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load, DataGridView1.ReadOnlyChanged
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\Desktop\vbshit-main\vbshit-main\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            adapter1 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte WHERE GeplanterFertiger = '" + Form1.txtUsername.Text + "';", con)
            adapter1.Fill(myDataSet1)
            Me.DataGridView1.DataSource = myDataSet1.Tables(0)
            Me.myDataSet1.Tables.Clear()
            command.CommandText = "UPDATE Arbeitsvorräte SET BereitsGefertigtMenge = BereitsGefertigtMenge + '" + txtFertig.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class