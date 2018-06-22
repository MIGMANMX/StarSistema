Imports SistemaLogica

Partial Class _Ventas
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("usuario")) Then Response.Redirect("Default.aspx", True)
        If Not Page.IsPostBack Then
            Session("menu") = "C"
            wucSucursales.ddlAutoPostBack = True
        End If
        Lmsg.Text = "" : gvPos = 0

        If Request.Form("btnSi") <> "" Then
            Dim ep As New ctiVentas
            Dim err As String = ep.eliminarVentas(CInt(Session("idz_e").ToString))
            GridView1.DataSource = ep.gvVentas(wucSucursales.idSucursal)
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
    Protected Sub wucSucursales_sucursalSeleccionada(sender As Object, e As System.EventArgs) Handles wucSucursales.sucursalSeleccionada
        Dim gvds As New ctiVentas
        GridView1.DataSource = gvds.gvVentas(wucSucursales.idSucursal)
        gvds = Nothing
        GridView1.DataBind()
        If IsNumeric(grdSR.Text) Then
            grdSR.Text = ""
            btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            'empleado.Text = "" : WucPuestos.idPuesto = 3 : wucSuc.idSucursal = 0
        End If
        wucSucursales1.idSucursal = wucSucursales.idSucursal
    End Sub
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If fechaTxtV.Text = "" And subTxtV.Text = "" And ivaTxtV.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else


            If IsNumeric(grdSR.Text) Then
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Dim gp As New ctiVentas

            Dim r() As String = gp.agregarVentas(wucSucursales.idSucursal, fechaTxtV.Text, subTxtV.Text, ivaTxtV.Text)
            GridView1.DataSource = gp.gvVentas(wucSucursales.idSucursal)
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
                subTxtV.Text = ""
                fechaTxtV.Text = ""
                ivaTxtV.Text = ""
            End If
            Lmsg.Text = r(0)
        End If
    End Sub
    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        If FIngreso0.Visible = True Then
            FIngreso0.Visible = False
        ElseIf FIngreso0.Visible = False Then
            FIngreso0.Visible = True
        End If
    End Sub
    Protected Sub FIngreso0_SelectionChanged(sender As Object, e As EventArgs) Handles FIngreso0.SelectionChanged
        fechaTxtV.Text = FIngreso0.SelectedDate.ToString("yyyy-MM-dd")
        FIngreso0.Visible = False
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Dim ec As New ctiVentas
        'Dim FechaFinal As Date
        'Dim FechaFinal2 As Date
        'FechaFinal = Convert.ToDateTime(TxFechaFin.Text)
        'FechaFinal2 = DateAdd(DateInterval.Day, 1, FechaFinal).ToString("yyyy-MM-dd")

        'GridView1.DataSource = ec.gvChequeo(wucEmpleados2.idEmpleado, Format(CDate(TxFechaInicio.Text), "yyyy-dd-MM"), Format(CDate(FechaFinal2), "yyyy-dd-MM"), 3)
        GridView1.DataSource = ec.gvVentas(wucSucursales.idSucursal)

        ec = Nothing
        GridView1.DataBind()
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
            'baj.Visible = True
            'fecha_baja.Visible = True
            'ImageButton3.Visible = True
            'CFBaja.Visible = True

            Dim dsP As New ctiCatalogos
            Dim datos() As String = dsP.datosEmpleado(CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text))
            dsP = Nothing
            If datos(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
                Lmsg.Text = datos(0)
            Else
                'empleado.Text = datos(0)
                'wucSuc.idSucursal = CInt(datos(1))
                'WucPuestos.idPuesto = datos(2)
                'activo.Checked = datos(3)
                'nss.Text = datos(4)
                'fecha_ingreso.Text = Convert.ToDateTime(datos(5)).ToString("dd/MM/yyyy")

                'rfc.Text = datos(6)
                'fecha_nacimiento.Text = Convert.ToDateTime(datos(7)).ToString("dd/MM/yyyy")
                'calle.Text = datos(8)
                'numero.Text = datos(9)
                'colonia.Text = datos(10)
                'cp.Text = datos(11)
                'telefono.Text = datos(12)
                'correo.Text = datos(13)
                'fecha_baja.Text = Convert.ToDateTime(datos(14)).ToString("dd/MM/yyyy")
                'claveTX.Text = ""
                'claveTX.Text = datos(16)
                'Catt = datos(16)
                'wucTipoJornada.idTipoJornada = datos(17)
                'baja.Checked = datos(18)

                'curp.Text = datos(19)
                'nombreTxt.Text = datos(20)
                'telefonoTxt.Text = datos(21)
                'nombreTxt.Text = datos(22)


                'claveTX.Enabled = True

                grdSR.Text = e.CommandArgument.ToString
                GridView1.Rows(Convert.ToInt32(e.CommandArgument)).RowState = DataControlRowState.Selected

                Dim gvp As New clsCTI
                gvPos = gvp.gridViewScrollPos(CInt(e.CommandArgument))
                gvp = Nothing
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = True
                'btnGuardarNuevo.Enabled = False
            End If
        End If
    End Sub
End Class
