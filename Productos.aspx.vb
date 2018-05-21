Imports SistemaLogica

Partial Class _Productos
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("usuario")) Then Response.Redirect("Default.aspx", True)
        If Not Page.IsPostBack Then
            Session("menu") = "C"
            wucClasesInsumos.ddlAutoPostBack = True
        End If
        Lmsg.Text = "" : gvPos = 0
        If Request.Form("btnSi") <> "" Then
            Dim ep As New ctiCatalogos
            Dim err As String = ep.eliminarInsumos(CInt(Session("idz_e").ToString))
            GridView1.DataSource = ep.gvInsumos(wucClasesInsumos.idClase)
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
            Dim datos() As String = dsP.datosInsumos(CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text))
            dsP = Nothing
            If datos(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
                Lmsg.Text = datos(0)
            Else

                TxtInsumo.Text = datos(1)
                Txtclave.Text = datos(2)
                wucClases.idClase = datos(3)
                TxtMangas.Text = datos(4)
                TxtPiezas.Text = datos(5)
                TxtCaja.Text = datos(6)

                Critico.Checked = datos(7)
                IVA.Checked = datos(8)
                medible.Checked = datos(9)
                activo.Checked = datos(10)
                TxtCosto.Text = datos(11)

                ' Txtclave.Enabled = True

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
        If TxtInsumo.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else
            Dim _clave As String
            If Txtclave.Text <> "" Then
                _clave = Convert.ToString(Txtclave.Text)
            Else
                _clave = " "
            End If

            Dim _manga As String
            If TxtMangas.Text <> "" Then
                _manga = Convert.ToString(TxtMangas.Text)
            Else
                _manga = " "
            End If

            Dim _pieza As String
            If TxtPiezas.Text <> "" Then
                _pieza = Convert.ToString(TxtPiezas.Text)
            Else
                _pieza = " "
            End If

            Dim _caja As String
            If TxtCaja.Text <> "" Then
                _caja = Convert.ToString(TxtCaja.Text)
            Else
                _caja = " "
            End If

            Dim _costo As String
            If TxtCosto.Text <> "" Then
                _costo = Convert.ToString(TxtCosto.Text)
            Else
                _costo = " "
            End If

            Dim ap As New ctiCatalogos
            Dim idA As Integer = CInt(GridView1.Rows(Convert.ToInt32(grdSR.Text)).Cells(0).Text)
            Dim r As String = ap.actualizarInsumos(idA, TxtInsumo.Text, _clave, wucClases.idClase, _manga, _pieza, _caja, Critico.Checked, IVA.Checked, medible.Checked, activo.Checked, _costo)
            GridView1.DataSource = ap.gvInsumos(wucClasesInsumos.idClase)
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
                TxtInsumo.Text = "" : wucClases.idClase = 0 : Txtclave.Text = "" : TxtCaja.Text = "" : Txtclave.Text = ""
                TxtCosto.Text = "" : TxtMangas.Text = "" : TxtPiezas.Text = ""
                activo.Checked = True
                Critico.Checked = False
                medible.Checked = False
                IVA.Checked = False

            End If
            gvp = Nothing
            Lmsg.Text = r
        End If

    End Sub
    Protected Sub wucClasesInsumos_insumoSeleccionado(sender As Object, e As System.EventArgs) Handles wucClasesInsumos.insumoSeleccionado
        Dim gvds As New ctiCatalogos
        GridView1.DataSource = gvds.gvInsumos(wucClasesInsumos.idClase)
        gvds = Nothing
        GridView1.DataBind()
        If IsNumeric(grdSR.Text) Then
            grdSR.Text = ""
            btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            TxtInsumo.Text = "" : wucClases.idClase = 0 : Txtclave.Text = "" : TxtCaja.Text = "" : Txtclave.Text = ""
            TxtCosto.Text = "" : TxtMangas.Text = "" : TxtPiezas.Text = ""
            activo.Checked = True
            Critico.Checked = False
            medible.Checked = False
            IVA.Checked = False
        End If
        'wucSuc.idSucursal = wucSucursales.idSucursal
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If TxtInsumo.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else

            Dim _clave As String
            If Txtclave.Text <> "" Then
                _clave = Convert.ToString(Txtclave.Text)
            Else
                _clave = " "
            End If

            Dim _manga As String
            If TxtMangas.Text <> "" Then
                _manga = Convert.ToString(TxtMangas.Text)
            Else
                _manga = " "
            End If

            Dim _pieza As String
            If TxtPiezas.Text <> "" Then
                _pieza = Convert.ToString(TxtPiezas.Text)
            Else
                _pieza = " "
            End If

            Dim _caja As String
            If TxtCaja.Text <> "" Then
                _caja = Convert.ToString(TxtCaja.Text)
            Else
                _caja = " "
            End If

            Dim _costo As String
            If TxtCosto.Text <> "" Then
                _costo = Convert.ToString(TxtCosto.Text)
            Else
                _costo = " "
            End If

            If IsNumeric(grdSR.Text) Then
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Dim gp As New ctiCatalogos

            Dim r() As String = gp.agregarInsumos(TxtInsumo.Text, _clave, wucClases.idClase, _manga, _pieza, _caja, Critico.Checked, IVA.Checked, medible.Checked, activo.Checked, _costo)
            GridView1.DataSource = gp.gvInsumos(wucClasesInsumos.idClase)
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


                TxtInsumo.Text = "" : wucClases.idClase = 0 : Txtclave.Text = "" : TxtCaja.Text = "" : Txtclave.Text = ""
                TxtCosto.Text = "" : TxtMangas.Text = "" : TxtPiezas.Text = ""
                activo.Checked = True
                Critico.Checked = False
                medible.Checked = False
                IVA.Checked = False

            End If
            Lmsg.Text = r(0)
        End If
    End Sub
End Class
