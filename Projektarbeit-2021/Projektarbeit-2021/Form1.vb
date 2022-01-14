Imports System.Data.OleDb

Public Class Form1
    Dim con As New OleDbConnection
    Dim adapter1 As OleDbDataAdapter
    Dim adapter2 As OleDbDataAdapter
    Dim adapter3 As OleDbDataAdapter
    Dim myDataSet1 As New DataSet
    Dim myDataSet2 As New DataSet
    Dim myDataSet3 As New DataSet
    Dim command As New OleDbCommand
    Dim mycheck As Boolean = False
    Dim mystop As Boolean = False


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\phili\source\repos\Projektarbeit-2021\IFB_DB.accdb"
        con.Open()
        command.Connection = con

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mycheck = True
        adapter1 = New OleDbDataAdapter("SELECT * FROM Benutzer;", con)
        adapter2 = New OleDbDataAdapter("SELECT * FROM Arbeitsvorräte;", con)
        adapter3 = New OleDbDataAdapter("SELECT Artikelnr, Bezeichnung, WANummer, Starttermin, Endtermin, Menge FROM Arbeitsvorräte;", con)
        adapter1.Fill(myDataSet1)
        adapter2.Fill(myDataSet2)
        adapter3.Fill(myDataSet3)
        Form2.DataGridView1.DataSource = myDataSet1.Tables(0)
        For i As Integer = 0 To Form2.DataGridView1.Rows.Count - 1
            Try
                If myDataSet1.Tables(0).Rows(i).ItemArray(0) = txtUsername.Text And myDataSet1.Tables(0).Rows(i).ItemArray(1) = txtPassword.Text Then
                    mystop = True
                    If myDataSet1.Tables(0).Rows(i).ItemArray(2) = mycheck Then         'Admin
                        Form2.DataGridView1.DataSource = myDataSet2.Tables(0)
                        Form2.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(3) = mycheck Then         'Admin
                        Form2.DataGridView1.DataSource = myDataSet2.Tables(0)
                        Form2.Show()
                    End If
                    If myDataSet1.Tables(0).Rows(i).ItemArray(4) = mycheck Then         'User
                        Form3.DataGridView1.DataSource = myDataSet3.Tables(0)
                        Form3.Show()
                    End If

                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next i

        If mystop = False Then
            txtUsername.Text = " "
            txtPassword.Text = " "
            MsgBox("falsche Eingabe!")
        End If

    End Sub

End Class