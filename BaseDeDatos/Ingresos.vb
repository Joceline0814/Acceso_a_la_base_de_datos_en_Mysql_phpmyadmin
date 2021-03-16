
Imports MySql.Data.MySqlClient

Public Class Ingresos
    Dim con As New MySqlConnection("server=localhost;user=root;password=19982017;database= grupoexposicion_3;port=3306")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cadena As String
            cadena = String.Format("INSERT INTO ingreso(codigo_ingreso, codigo_insumo1,cantidad) values ('{0}','{1}','{2}')", TextBox1.Text, TextBox2.Text, TextBox3.Text)
            Dim insertar As New MySqlCommand(cadena, con)
            con.Open()
            insertar.ExecuteNonQuery()
            con.Close()
            MsgBox("El registro fue ingresado de forma satisfactoria", MsgBoxStyle.Information, " Ingresos")
        Catch ex As Exception
            MsgBox("Error al ingresar los datos, verifique por favor", MsgBoxStyle.Information, "Ingresos")
            con.Close()
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Egreso.Show()
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If bandera = 0 Then
            Codigo_busqueda = TextBox2.Text
        End If
        Try
            con.Open()
            Dim cadena As String
            cadena = String.Format("SELECT * FROM insumo WHERE codigo_insumo= '{0}'", Codigo_busqueda)
            Dim consultar As New MySqlCommand(cadena, con)
            Dim da As New MySqlDataAdapter(consultar)
            Dim datos As New DataTable
            da.Fill(datos)
            TextBox3.Text = datos.Rows(0).Item("cantidad").ToString()
            con.Close()
        Catch ex As Exception
            MsgBox("Error al consultar los datos, verifique por favor", MsgBoxStyle.Critical, "INGRESO")
            con.Close()
        End Try
    End Sub

    Private Sub TextBox3_LocationChanged(sender As Object, e As EventArgs) Handles TextBox3.LocationChanged
        Try
            con.Open()
            Dim cadena As String
            cadena = String.Format("SELECT * FROM insumo WHERE cantidad = '{3}'", TextBox3.Text.ToString())
            Dim consultar As New MySqlCommand(cadena, con)
            Dim da As New MySqlDataAdapter(consultar)
            Dim datos As New DataTable
            da.Fill(datos)
            TextBox3.Text = datos.Rows(0).Item("cantidad").ToString()
            con.Close()
        Catch ex As Exception

            con.Close()
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class