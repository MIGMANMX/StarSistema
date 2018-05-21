
Imports SistemaLogica

Partial Class Principal
    Inherits System.Web.UI.MasterPage
    Protected Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Session.Clear()
        Response.Redirect("Default.aspx")
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("idusuario")) Then
            Response.Redirect("Default.aspx", True)
        End If
        'direc.Visible = False
        'Dim acceso As New ctiCatalogos
        'Dim datos() As String = acceso.datosUsuarioV(Session("idusuario"))
        'If datos(0) >= 3 And datos(0) <= 6 Then
        '    Response.Redirect("Sistema.aspx", True)
        'End If
    End Sub
End Class

