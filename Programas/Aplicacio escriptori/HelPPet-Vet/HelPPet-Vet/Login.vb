Imports MySql.Data.MySqlClient

Public Class Login
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''coger codigo veterinario
        Dim leer As MySqlDataReader
        ''base de datos
        Dim MySQLDA As MySqlDataAdapter
        Dim DT As New DataTable
        Dim Data As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim data3 As DataSet
        Dim no As Boolean
        Dim Connection As New MySqlConnection("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
        Dim Query As String
        Dim comando As New MySqlCommand(Query, Connection)
        Dim MySQLCMD As New MySqlCommand
        Dim lista As Byte
        Dim admin As Boolean = False
        ''fichero de login admin
        Dim fileReader As String
        Dim dades() As String
        Dim usuario As Boolean = False
        Dim path As String = My.Computer.FileSystem.CurrentDirectory + "\\admin.txt"
        If My.Computer.FileSystem.FileExists(path) Then
            fileReader = My.Computer.FileSystem.ReadAllText(path)
            dades = Split(fileReader)
            AdminSide.user.Text = dades(0).ToString
            AdminSide.uno1.Text = dades(0).ToString
            AdminSide.AU.Text = dades(1).ToString
            AdminSide.AP.Text = dades(2).ToString
            AdminSide.uac.Text = dades(3).ToString
            usuario = True
        End If
        ''validar datos de login
        If usuario = True Then
            If (user.Text = "") Or (pas.Text = "") Then
                MsgBox("¡Identificación invalida!")
                ''entrar como administrador

            ElseIf (user.Text = dades(1).ToString) And (pas.Text = dades(2).ToString) Then
                Me.Hide()
                AdminSide.Show()
                AdminSide.user.Text = "Administrador"
                admin = True
                ''entrar como veterinario
            Else
                'mirar usuari
                Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
                Connection.Open()
                MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE Usuari LIKE '" & user.Text & "'"
                MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
                Data1 = MySQLDA.Fill(DT)
                Connection.Close()
                ''mirar Primary key
                Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
                Connection.Open()
                MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE codi= " & pas.Text
                MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
                Data2 = MySQLDA.Fill(DT)
                Connection.Close()
                no = False
            End If
        Else
            If (user.Text = "") Or (pas.Text = "") Then
                MsgBox("¡Identificación invalida!")
                ''entrar como administrador

            ElseIf (user.Text = "adm") And (pas.Text = "4444") Then
                Me.Hide()
                AdminSide.Show()
                AdminSide.user.Text = "Administrador"
                admin = True
                ''entrar como veterinario
            Else
                'mirar usuari
                Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            Connection.Open()
            MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE Usuari LIKE '" & user.Text & "'"
            MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
            Data1 = MySQLDA.Fill(DT)
            Connection.Close()
            ''mirar Primary key
            Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
            Connection.Open()
            MySQLCMD.CommandText = "SELECT * FROM veterinari WHERE codi= " & pas.Text
            MySQLDA = New MySqlDataAdapter(MySQLCMD.CommandText, Connection)
            Data2 = MySQLDA.Fill(DT)
            Connection.Close()
            no = False
        End If

        End If
        If no = False Then

            If (Data1 <= 0) And (Data2 <= 0) And (admin = False) Then
                MsgBox("¡Identificación invalida!")

            Else

                Try
                    Connection.ConnectionString = ("server=br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com; user=upc64zf66fxq8gq9; password=hqD9cgVKNkL0zGpLCSoJ; database=br6yuhxjtf6d9t43hrii")
                    Connection.Open()
                    Dim consulta As String
                    consulta = "SELECT codi FROM veterinari where Usuari like '" & user.Text & "'"
                    MySQLDA = New MySqlDataAdapter(consulta, Connection)
                    data3 = New DataSet
                    MySQLDA.Fill(data3, "veterinari")
                    lista = data3.Tables("veterinari").Rows.Count
                    Console.WriteLine(lista)
                    Connection.Close()
                Catch ex As Exception
                End Try

                If admin = False Then
                    If (lista <> 0) Then
                        veterinario.Text = data3.Tables("veterinari").Rows(0).Item("codi")
                        Me.Hide()
                        Veterinari.Show()
                    Else
                        MsgBox("Error del sistema,contacte con su administrador")
                    End If
                End If

            End If

            End If









    End Sub

    Private Sub pas_TextChanged(sender As Object, e As EventArgs) Handles pas.TextChanged

    End Sub
End Class