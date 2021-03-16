
Imports MySql.Data.MySqlClient
Public Class Egreso
    Dim pro As New MySqlConnection("server=localhost;user=root;password=19982017;database= grupoexposicion_3;port=3306")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_GUARDAR.Click
        Try
            Dim cadena As String
            cadena = String.Format("INSERT INTO egreso(codigo_egreso, codigo_insumo2, cantidad) values ('{0}','{1}','{2}')", TextBox1.Text, TextBox2.Text, TextBox4.Text)
            Dim insertar As New MySqlCommand(cadena, pro)
            pro.Open()
            insertar.ExecuteNonQuery()
            pro.Close()
            MsgBox("El registro fue ingresado de forma satisfactoria", MsgBoxStyle.Information, " Egreso")
        Catch ex As Exception
            MsgBox("Error al ingresar los datos, verifique por favor", MsgBoxStyle.Information, "Egreso")
            pro.Close()
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        REPORTE.Show()
    End Sub

    

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If bandera = 0 Then
            Codigo_busqueda = TextBox2.Text
        End If
        Try
            pro.Open()
            Dim cadena As String
            cadena = String.Format("SELECT * FROM insumo WHERE codigo_insumo= '{0}'", Codigo_busqueda)
            Dim consultar As New MySqlCommand(cadena, pro)
            Dim da As New MySqlDataAdapter(consultar)
            Dim datos As New DataTable
            da.Fill(datos)
            pro.Close()
        Catch ex As Exception
            MsgBox("Error al consultar los datos, verifique por favor", MsgBoxStyle.Critical, "Compra - Venta")
            pro.Close()
        End Try
    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cadena As String
            cadena = String.Format("DELETE FROM egreso WHERE codigo_egreso='{0}'", TextBox1.Text)
            Dim borrar As New MySqlCommand(cadena, pro)
            pro.Open()
            borrar.ExecuteNonQuery()
            pro.Close()
            MsgBox("El registro fue eliminado de forma satisfactoria", MsgBoxStyle.Information, "EGRESO")
        Catch ex As Exception
            MsgBox("Error al eliminar los datos, verifique por favor", MsgBoxStyle.Critical, "EGRESO")
            pro.Close()
        End Try

        TextBox1.Text = ""
        TextBox2.Text = ""

        TextBox4.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            pro.Open()
            Dim cadena As String
            cadena = String.Format("SELECT * FROM egreso WHERE codigo_egreso = '{0}'", TextBox1.Text)
            Dim consultar As New MySqlCommand(cadena, pro)
            Dim da As New MySqlDataAdapter(consultar)
            Dim datos As New DataTable
            da.Fill(datos)
            TextBox2.Text = datos.Rows(0).Item("codigo_insumo2").ToString()
            TextBox4.Text = datos.Rows(0).Item("cantidad").ToString()
            pro.Close()
        Catch ex As Exception
            MsgBox("Error al consultar los datos, verifique por favor", MsgBoxStyle.Critical, "ELIMINAR")
            pro.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cadena As String
            cadena = String.Format("UPDATE egreso SET  codigo_insumo2='{1}', cantidad='{2}'WHERE codigo_egreso='{0}'", TextBox1.Text, TextBox2.Text, TextBox4.Text)
            Dim insertar As New MySqlCommand(cadena, pro)
            pro.Open()
            insertar.ExecuteNonQuery()
            pro.Close()
            MsgBox("El registro fue modificado de forma satisfactoria", MsgBoxStyle.Information, "ACTUALIZAR")
        Catch ex As Exception
            MsgBox("Error al editar los datos, verifique por favor", MsgBoxStyle.Critical, "ACTUALIZAR")
            pro.Close()
        End Try

    End Sub
End Class