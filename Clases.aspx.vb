﻿Imports SistemaLogica

Partial Class _Clases
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("usuario")) Then Response.Redirect("Default.aspx", True)
        If Not Page.IsPostBack Then
            Dim gvds As New ctiCatalogos
            GridView1.DataSource = gvds.gvClasesProductos
            gvds = Nothing
            GridView1.DataBind()
        End If
        Lmsg.Text = "" : gvPos = 0
        If Request.Form("btnSi") <> "" Then
            Dim ep As New ctiCatalogos
            Dim err As String = ep.eliminarClasesProductos(CInt(Session("idz_e").ToString))
            GridView1.DataSource = ep.gvClasesProductos()
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
            Dim datos() As String = dsP.datosClasesProductos(CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text))
            dsP = Nothing
            If datos(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
                Lmsg.Text = datos(0)
            Else

                TxtClase.Text = datos(1)
                Txtclave.Text = datos(2)
                Chkimpacta.Checked = datos(3)

                TxtCuentaS1.Text = datos(4)
                TxtCuentaS2.Text = datos(5)
                TxtCuentaS3.Text = datos(6)
                TxtCuentaS4.Text = datos(7)
                TxtCuentaS5.Text = datos(8)
                TxtCuentaS6.Text = datos(9)

                TxtCuentaL.Text = datos(10)
                TxtCuentaI.Text = datos(11)

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
        If TxtClase.Text = "" And Txtclave.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else

            Dim ap As New ctiCatalogos
            Dim idA As Integer = CInt(GridView1.Rows(Convert.ToInt32(grdSR.Text)).Cells(0).Text)
            Dim r As String = ap.actualizarClasesProductos(idA, TxtClase.Text, Txtclave.Text, Chkimpacta.Checked, TxtCuentaS1.Text, TxtCuentaS2.Text, TxtCuentaS3.Text, TxtCuentaS4.Text, TxtCuentaS5.Text, TxtCuentaS6.Text, TxtCuentaL.Text, TxtCuentaI.Text)
            GridView1.DataSource = ap.gvClasesProductos()
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
                TxtClase.Text = "" : Txtclave.Text = ""
                Chkimpacta.Checked = False
                TxtCuentaS1.Text = ""
                TxtCuentaS2.Text = ""
                TxtCuentaS3.Text = ""
                TxtCuentaS4.Text = ""
                TxtCuentaS5.Text = ""
                TxtCuentaS6.Text = ""
                TxtCuentaL.Text = ""
                TxtCuentaI.Text = ""

            End If
            gvp = Nothing
            Lmsg.Text = r
        End If

    End Sub
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If TxtClase.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else
            If IsNumeric(grdSR.Text) Then
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Dim gp As New ctiCatalogos

            Dim r() As String = gp.agregarClasesProductos(TxtClase.Text, Txtclave.Text, Chkimpacta.Checked, TxtCuentaS1.Text, TxtCuentaS2.Text, TxtCuentaS3.Text, TxtCuentaS4.Text, TxtCuentaS5.Text, TxtCuentaS6.Text, TxtCuentaL.Text, TxtCuentaI.Text)
            GridView1.DataSource = gp.gvClasesProductos()
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
                TxtClase.Text = "" : Txtclave.Text = ""
                Chkimpacta.Checked = False
                TxtCuentaS1.Text = ""
                TxtCuentaS2.Text = ""
                TxtCuentaS3.Text = ""
                TxtCuentaS4.Text = ""
                TxtCuentaS5.Text = ""
                TxtCuentaS6.Text = ""
                TxtCuentaL.Text = ""
                TxtCuentaI.Text = ""

            End If
            Lmsg.Text = r(0)
        End If
    End Sub
End Class
