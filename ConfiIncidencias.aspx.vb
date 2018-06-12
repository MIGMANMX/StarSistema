Imports SistemaLogica

Partial Class _ConfiIncidencias
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("usuario")) Then Response.Redirect("Default.aspx", True)
        If Not Page.IsPostBack Then
            Dim gvds As New ctiCatalogos
            GridView1.DataSource = gvds.gvConfiIncidencias()
            gvds = Nothing
            GridView1.DataBind()
        End If
        Lmsg.Text = "" : gvPos = 0
        If Request.Form("btnSi") <> "" Then
            Dim ep As New ctiCatalogos
            Dim err As String = ep.eliminarConfiIncidencias(CInt(Session("idz_e").ToString))
            GridView1.DataSource = ep.gvConfiIncidencias()
            ep = Nothing
            GridView1.DataBind()
            If err.StartsWith("Error") Then
                Lmsg.CssClass = "error"
                If IsNumeric(grdSR.Text) AndAlso CInt(grdSR.Text) <= GridView1.Rows.Count Then
                    GridView1.Rows(Convert.ToInt32(grdSR.Text)).RowState = DataControlRowState.Selected
                End If
            Else
                Lmsg.CssClass = "correcto"
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Lmsg.Text = err
        End If
        Session("idz_e") = ""

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Eliminar" Then
            Session("idz_e") = GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            Session("dz_e") = GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
        ElseIf e.CommandName = "Editar" Then
            If IsNumeric(grdSR.Text) Then
                GridView1.Rows(Convert.ToInt32(grdSR.Text)).RowState = DataControlRowState.Normal
                grdSR.Text = ""
            End If


            Dim dsP As New ctiCatalogos
            Dim datos() As String = dsP.datosConfiIncidencias(CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text))
            dsP = Nothing
            If datos(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
                Lmsg.Text = datos(0)
            Else


                TxtClave.Text = datos(1)


                grdSR.Text = e.CommandArgument.ToString
                GridView1.Rows(Convert.ToInt32(e.CommandArgument)).RowState = DataControlRowState.Selected

                Dim gvp As New clsCTI
                gvPos = gvp.gridViewScrollPos(CInt(e.CommandArgument))
                gvp = Nothing
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = True
                btnAgregar.Enabled = False
            End If
        End If
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If TxtClave.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else

            Dim ap As New ctiCatalogos
            Dim idA As Integer = CInt(GridView1.Rows(Convert.ToInt32(grdSR.Text)).Cells(0).Text)
            Dim r As String = ap.actualizarConfiIncidencias(idA, TxtClave.Text)
            GridView1.DataSource = ap.gvConfiIncidencias()
            ap = Nothing
            GridView1.DataBind()
            If r.StartsWith("Error") Then
                Lmsg.CssClass = "error"
            Else
                Lmsg.CssClass = "correcto"
            End If

            Dim gvp As New clsCTI
            grdSR.Text = gvp.seleccionarGridRow(GridView1, idA)
            If IsNumeric(grdSR.Text) AndAlso CInt(grdSR.Text) > 0 Then
                GridView1.Rows(Convert.ToInt32(grdSR.Text)).RowState = DataControlRowState.Selected
                gvPos = gvp.gridViewScrollPos(CInt(grdSR.Text))
            Else
                TxtClave.Text = ""

            End If
            gvp = Nothing
            Lmsg.Text = r
        End If

    End Sub
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If TxtClave.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else



            If IsNumeric(grdSR.Text) Then
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Dim gp As New ctiCatalogos

            Dim r() As String = gp.agregarConfiIncidencias(TxtClave.Text)
            GridView1.DataSource = gp.gvConfiIncidencias()
            gp = Nothing
            GridView1.DataBind()
            If r(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
            Else
                Lmsg.CssClass = "correcto"
                Dim sgr As New clsCTI
                grdSR.Text = sgr.seleccionarGridRow(GridView1, CInt(r(1))).ToString
                gvPos = sgr.gridViewScrollPos(CInt(grdSR.Text))
                sgr = Nothing
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = True
                TxtClave.Text = ""
            End If
            Lmsg.Text = r(0)
        End If
    End Sub
End Class
