Imports System.Data.OleDb
Public Class Form3
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim command As New OleDbCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load, DataGridView1.ReadOnlyChanged
<<<<<<< HEAD
        Form1.Hide()
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Info2.R1PC05\source\repos\Projektarbeit-2021\IFB_DB.accdb"
=======
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\Desktop\vbshit-main\vbshit-main\Projektarbeit-2021\IFB_DB.accdb"
>>>>>>> 7b8b8092217f2fe2bb9c29901c60d38483373ada
        con.Open()
        command.Connection = con
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.myDataSet1.Tables.Clear()
        adapter1 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte WHERE Fertiger = '" + Form1.txtUsername.Text + "';", con)
        adapter1.Fill(myDataSet1)
        Me.DataGridView1.DataSource = myDataSet1.Tables(0)

        If txtFertig.Text = String.Empty Then
            MsgBox("Bitte geben sie die Menge an")
        ElseIf txtNr.Text = String.Empty Then
            MsgBox("Bitte geben sie die Auftragsnummer an")
        End If

        Try


            Me.myDataSet1.Tables.Clear()
<<<<<<< HEAD

            command.CommandText = "UPDATE Arbeitsvorräte SET BereitsGefertigt = BereitsGefertigt + '" + txtFertig.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
=======
            command.CommandText = "UPDATE Arbeitsvorräte SET BereitsGefertigtMenge = BereitsGefertigtMenge + '" + txtFertig.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
>>>>>>> 7b8b8092217f2fe2bb9c29901c60d38483373ada
            command.ExecuteNonQuery()

            command.CommandText = "UPDATE Arbeitsvorräte SET Kommentar = '" + txtKom.Text + "' WHERE Auftragsnummer = " + txtNr.Text + ";"
            command.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Close()
    End Sub

End Class