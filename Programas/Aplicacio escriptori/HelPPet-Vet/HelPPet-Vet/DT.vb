Imports MySql.Data.MySqlClient
Public Class DT
    Public conexion As MySqlConnection

    Sub conexion_bd()
        Try
            conexion = New MySqlConnection("server=localhost; user=; password=; database=helppet")
            conexion.Open()
        Catch ex As Exception
            conexion.Dispose()
        End Try
    End Sub
End Class
