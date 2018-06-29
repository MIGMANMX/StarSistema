Imports System.Data.SqlClient
Imports SistemaLogica

Partial Class _Ventas
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Dim idventas2 As Integer
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
        'Depositos.Visible = False
        btnActualizar.Enabled = False
        btnAgregar.Enabled = True
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
            idventas2 = CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)

            'Depositos.Visible = True
            btnActualizar.Enabled = True
            btnAgregar.Enabled = False

            'If Not Page.IsPostBack Then
            Dim dbC As SqlConnection = New SqlConnection
                Dim dbc2 As SqlConnection = New SqlConnection
                Dim cmd As SqlCommand
                Dim cmd2 As SqlCommand
                Dim rdr As SqlDataReader
                Dim rdr2 As SqlDataReader
                Dim ident As Integer
                Dim subt As Double
                Dim ivaa As Double
                dbC.ConnectionString = ConfigurationManager.ConnectionStrings("CarlsJrConnectionString").ToString
                dbC.Open()
                dbc2.ConnectionString = ConfigurationManager.ConnectionStrings("CarlsJrConnectionString").ToString
                dbc2.Open()
                cmd = New SqlCommand("select * from Ventas2 where idventas2=" & idventas2, dbC)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    fecha.Text = FormatDateTime(rdr("fecha"), DateFormat.ShortDate).ToString
                    total.Text = rdr("ventan").ToString
                    IVA.Text = rdr("iva").ToString
                    subt = rdr("ventan")
                    ivaa = rdr("iva")
                    lblTotal.Text = String.Format("{0:c}", subt + ivaa)
                    If Session("nivel") = 1 Then
                        wucSucursales1.idSucursal = rdr("idsucursal").ToString
                    Else
                        lblsuc.Text = Session("suc")
                    End If
                    rdr.Close()
                    cmd2 = New SqlCommand("select * from partidasvoids where idventas2=" & idventas2, dbc2)
                    rdr2 = cmd2.ExecuteReader()
                    While rdr2.Read
                        ident = rdr2("idvoids").ToString
                        If ident = 1 Then
                            VoidsC.Text = rdr2("cantidad").ToString
                            VoidsT.Text = rdr2("monto").ToString
                        End If
                        If ident = 2 Then
                            MgrVoidsC.Text = rdr2("cantidad").ToString
                            MgrVoidsT.Text = rdr2("monto").ToString
                        End If
                        If ident = 3 Then
                            CorrecionC.Text = rdr2("cantidad").ToString
                            CorreccionT.Text = rdr2("monto").ToString
                        End If
                        If ident = 5 Then
                            TickEmpC.Text = rdr2("cantidad").ToString
                            TickEmpT.Text = rdr2("monto").ToString
                        End If
                        If ident = 6 Then
                            TickPagC.Text = rdr2("cantidad").ToString
                            TickPagT.Text = rdr2("monto").ToString
                        End If
                    End While
                    rdr2.Close()
                    rdr2 = Nothing
                    dbc2.Close()

                    dbc2.Open()
                    cmd2 = New SqlCommand("select * from partidastipoventa where idventas2=" & idventas2, dbc2)
                    rdr2 = cmd2.ExecuteReader()
                    While rdr2.Read
                        ident = rdr2("idtipoventa").ToString
                        If ident = 1 Then
                            ComedorC.Text = rdr2("cantidad").ToString
                            ComedorT.Text = rdr2("monto").ToString
                        End If
                        If ident = 2 Then
                            LlevarC.Text = rdr2("cantidad").ToString
                            LlevarT.Text = rdr2("monto").ToString
                        End If
                        If ident = 3 Then
                            AutoC.Text = rdr2("cantidad").ToString
                            AutoT.Text = rdr2("monto").ToString
                        End If
                    End While
                    rdr2.Close()
                    rdr2 = Nothing
                    dbc2.Close()

                    dbc2.Open()
                    cmd2 = New SqlCommand("select * from partidasformapago where idventas2=" & idventas2, dbc2)
                    rdr2 = cmd2.ExecuteReader()
                    While rdr2.Read
                        ident = rdr2("idformapago").ToString
                        If ident = 1 Then
                            EfectivoC.Text = rdr2("cantidad").ToString
                            EfectivoT.Text = rdr2("monto").ToString
                        End If
                        If ident = 2 Then
                            ValesC.Text = rdr2("cantidad").ToString
                            ValesT.Text = rdr2("monto").ToString
                        End If
                        If ident = 3 Then
                            CityC.Text = rdr2("cantidad").ToString
                            CityT.Text = rdr2("monto").ToString
                        End If
                        If ident = 4 Then
                            VisaC.Text = rdr2("cantidad").ToString
                            VisaT.Text = rdr2("monto").ToString
                        End If
                        If ident = 5 Then
                            AmericanC.Text = rdr2("cantidad").ToString
                            AmericanT.Text = rdr2("monto").ToString
                        End If
                        If ident = 9 Then
                            DebC.Text = rdr2("cantidad").ToString
                            DebT.Text = rdr2("monto").ToString
                        End If
                        If ident = 10 Then
                            UberC.Text = rdr2("cantidad").ToString
                            UberT.Text = rdr2("monto").ToString
                        End If
                    End While
                    rdr2.Close()
                    rdr2 = Nothing
                    dbc2.Close()

                    dbc2.Open()
                    cmd2 = New SqlCommand("select * from partidasdesc where idventas2=" & idventas2, dbc2)
                    rdr2 = cmd2.ExecuteReader()
                    While rdr2.Read
                        ident = rdr2("iddesc").ToString
                        If ident = 1 Then
                            Desc10C.Text = rdr2("cantidad").ToString
                            Desc10T.Text = rdr2("monto").ToString
                        End If
                        If ident = 2 Then
                            Desc15C.Text = rdr2("cantidad").ToString
                            Desc15T.Text = rdr2("monto").ToString
                        End If
                        If ident = 3 Then
                            Desc20C.Text = rdr2("cantidad").ToString
                            Desc20T.Text = rdr2("monto").ToString
                        End If
                        If ident = 4 Then
                            Desc25C.Text = rdr2("cantidad").ToString
                            Desc25T.Text = rdr2("monto").ToString
                        End If
                        If ident = 5 Then
                            Desc20FAC.Text = rdr2("cantidad").ToString
                            Desc20FAT.Text = rdr2("monto").ToString
                        End If
                        If ident = 6 Then
                            Desc20EC.Text = rdr2("cantidad").ToString
                            Desc20ET.Text = rdr2("monto").ToString
                        End If
                        If ident = 7 Then
                            Desc50EC.Text = rdr2("cantidad").ToString
                            Desc50ET.Text = rdr2("monto").ToString
                        End If
                        If ident = 8 Then
                            Desc50SoC.Text = rdr2("cantidad").ToString
                            Desc50SoT.Text = rdr2("monto").ToString
                        End If
                        If ident = 9 Then
                            Desc90Emp.Text = rdr2("cantidad").ToString
                            Desc90ET.Text = rdr2("monto").ToString
                        End If
                        If ident = 10 Then
                            Desc100C.Text = rdr2("cantidad").ToString
                            Desc100CT.Text = rdr2("monto").ToString
                        End If
                        If ident = 11 Then
                            Desc60Emp.Text = rdr2("cantidad").ToString
                            Desc60ET.Text = rdr2("monto").ToString
                        End If
                        If ident = 12 Then
                            Desc100SC.Text = rdr2("cantidad").ToString
                            Desc100ST.Text = rdr2("monto").ToString
                        End If
                        If ident = 13 Then
                            Desc100CoC.Text = rdr2("cantidad").ToString
                            Desc100CoT.Text = rdr2("monto").ToString
                        End If
                    End While
                    rdr2.Close()
                    rdr2 = Nothing
                    dbc2.Close()

                    dbc2.Open()
                    cmd2 = New SqlCommand("select * from partidasfamiliasventa where idventas2=" & idventas2, dbc2)
                    rdr2 = cmd2.ExecuteReader()
                    While rdr2.Read
                        ident = rdr2("idfam").ToString
                        If ident = 1 Then
                            HambC.Text = rdr2("cantidad").ToString
                            HambT.Text = rdr2("monto").ToString
                        End If
                        If ident = 2 Then
                            FritosC.Text = rdr2("cantidad").ToString
                            FritosT.Text = rdr2("monto").ToString
                        End If
                        If ident = 3 Then
                            EnsalC.Text = rdr2("cantidad").ToString
                            EnsalT.Text = rdr2("monto").ToString
                        End If
                        If ident = 4 Then
                            PostresC.Text = rdr2("cantidad").ToString
                            PostresT.Text = rdr2("monto").ToString
                        End If
                        If ident = 5 Then
                            CombosC.Text = rdr2("cantidad").ToString
                            CombosT.Text = rdr2("monto").ToString
                        End If
                        If ident = 6 Then
                            BebidasC.Text = rdr2("cantidad").ToString
                            BebidasT.Text = rdr2("monto").ToString
                        End If
                        If ident = 7 Then
                            CondC.Text = rdr2("cantidad").ToString
                            CondT.Text = rdr2("monto").ToString
                        End If
                        If ident = 8 Then
                            PromoC.Text = rdr2("cantidad").ToString
                            PromoT.Text = rdr2("monto").ToString
                        End If
                        If ident = 9 Then
                            CBKidC.Text = rdr2("cantidad").ToString
                            CBKidT.Text = rdr2("monto").ToString
                        End If
                        If ident = 10 Then
                            FiestaC.Text = rdr2("cantidad").ToString
                            FiestaT.Text = rdr2("monto").ToString
                        End If
                        If ident = 11 Then
                            SobranteC.Text = rdr2("cantidad").ToString
                            SobranteT.Text = rdr2("monto").ToString
                        End If
                        If ident = 12 Then
                            AntC.Text = rdr2("cantidad").ToString
                            AntT.Text = rdr2("monto").ToString
                        End If
                        If ident = 13 Then
                            WasteC.Text = rdr2("cantidad").ToString
                            WasteT.Text = rdr2("monto").ToString
                        End If
                    End While
                    rdr2.Close()
                    rdr2 = Nothing
                    dbc2.Close()

                End If
                rdr.Close()
                rdr = Nothing
                cmd.Dispose()
                dbC.Close()
                dbC.Dispose()
                dbc2.Close()

            'End If
        End If
    End Sub
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim dbC As SqlConnection = New SqlConnection
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim dbC2 As SqlConnection = New SqlConnection
        Dim cmd2 As SqlCommand
        Dim rdr2 As SqlDataReader
        Dim dbC3 As SqlConnection = New SqlConnection
        Dim cmd3 As SqlCommand
        Dim id As Integer
        dbC.ConnectionString = ConfigurationManager.ConnectionStrings("CarlsJrConnectionString").ToString
        dbC.Open()
        dbC2.ConnectionString = ConfigurationManager.ConnectionStrings("CarlsJrConnectionString").ToString
        dbC2.Open()
        dbC3.ConnectionString = ConfigurationManager.ConnectionStrings("CarlsJrConnectionString").ToString
        dbC3.Open()

        cmd = New SqlCommand("select * from Ventas2 where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("update ventas2 set ventan ='" & total.Text & "',iva='" & IVA.Text & "',cerrado=" & 1 & "  where idventas2 =" & idventas2 & "", dbC2)
            cmd2.ExecuteNonQuery()
        End If
        rdr.Close()

        '******VOIDS*************

        cmd = New SqlCommand("select * from partidasvoids where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("select * from voids", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idvoids").ToString
                If id = 1 Then
                    cmd3 = New SqlCommand("update partidasvoids set cantidad ='" & VoidsC.Text & "',monto ='" & VoidsT.Text & "' where idventas2 =" & idventas2 & " and idvoids = " & CSng(rdr2("idvoids")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 Then
                    cmd3 = New SqlCommand("update partidasvoids set cantidad ='" & MgrVoidsC.Text & "',monto ='" & MgrVoidsT.Text & "' where idventas2 =" & idventas2 & " and idvoids = " & CSng(rdr2("idvoids")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 Then
                    cmd3 = New SqlCommand("update partidasvoids set cantidad ='" & CorrecionC.Text & "',monto ='" & CorreccionT.Text & "' where idventas2 =" & idventas2 & " and idvoids = " & CSng(rdr2("idvoids")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 Then
                    cmd3 = New SqlCommand("update partidasvoids set cantidad ='" & TickEmpC.Text & "',monto ='" & TickEmpT.Text & "' where idventas2 =" & idventas2 & " and idvoids = " & CSng(rdr2("idvoids")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 Then
                    cmd3 = New SqlCommand("update partidasvoids set cantidad ='" & TickPagC.Text & "',monto ='" & TickPagT.Text & "' where idventas2 =" & idventas2 & " and idvoids = " & CSng(rdr2("idvoids")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        Else
            cmd2 = New SqlCommand("select * from voids", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idvoids").ToString
                If id = 1 And VoidsC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasVoids(idventas2,idvoids,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idvoids")) & "," & VoidsC.Text & "," & VoidsT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 And MgrVoidsC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasVoids(idventas2,idvoids,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idvoids")) & "," & MgrVoidsC.Text & "," & MgrVoidsT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 And CorrecionC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasVoids(idventas2,idvoids,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idvoids")) & "," & CorrecionC.Text & "," & CorreccionT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 And TickEmpC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasVoids(idventas2,idvoids,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idvoids")) & "," & TickEmpC.Text & "," & TickEmpT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 And TickPagC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasVoids(idventas2,idvoids,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idvoids")) & "," & TickPagC.Text & "," & TickPagT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        End If
        rdr.Close()
        rdr2.Close()

        '*********** TIPO DE TICKET *****************

        cmd = New SqlCommand("select * from partidastipoventa where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("select * from tipoventa", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idtipoventa").ToString
                If id = 1 Then
                    cmd3 = New SqlCommand("update partidastipoventa set cantidad ='" & ComedorC.Text & "',monto ='" & ComedorT.Text & "' where idventas2 =" & idventas2 & " and idtipoventa = " & CSng(rdr2("idtipoventa")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 Then
                    cmd3 = New SqlCommand("update partidastipoventa set cantidad ='" & LlevarC.Text & "',monto ='" & LlevarT.Text & "' where idventas2 =" & idventas2 & " and idtipoventa = " & CSng(rdr2("idtipoventa")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 Then
                    cmd3 = New SqlCommand("update partidastipoventa set cantidad ='" & AutoC.Text & "',monto ='" & AutoT.Text & "' where idventas2 =" & idventas2 & " and idtipoventa = " & CSng(rdr2("idtipoventa")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        Else
            cmd2 = New SqlCommand("select * from tipoventa", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idtipoventa").ToString
                If id = 1 And ComedorC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasTipoVenta(idventas2,idtipoventa,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idtipoventa")) & "," & ComedorC.Text & "," & ComedorT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 And LlevarC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasTipoVenta(idventas2,idtipoventa,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idtipoventa")) & "," & LlevarC.Text & "," & LlevarT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 And AutoC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasTipoVenta(idventas2,idtipoventa,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idtipoventa")) & "," & AutoC.Text & "," & AutoT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        End If
        rdr.Close()
        rdr2.Close()

        '****** FORMAS DE PAGO *************

        cmd = New SqlCommand("select * from PartidasFormaPago where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("select * from FormaPago", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idformapago").ToString
                If id = 1 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & EfectivoC.Text & "',monto ='" & EfectivoT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & ValesC.Text & "',monto ='" & ValesT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & CityC.Text & "',monto ='" & CityT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & VisaC.Text & "',monto ='" & VisaT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & AmericanC.Text & "',monto ='" & AmericanT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & DebC.Text & "',monto ='" & DebT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 Then
                    cmd3 = New SqlCommand("update PartidasFormaPago set cantidad ='" & UberC.Text & "',monto ='" & UberT.Text & "' where idventas2 =" & idventas2 & " and idformapago = " & CSng(rdr2("idformapago")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        Else
            cmd2 = New SqlCommand("select * from FormaPago", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idformapago").ToString
                If id = 1 And EfectivoC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & EfectivoC.Text & "," & EfectivoT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 And ValesC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & ValesC.Text & "," & ValesT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 And CityC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & CityC.Text & "," & CityT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 And VisaC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & VisaC.Text & "," & VisaT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 And AmericanC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & AmericanC.Text & "," & AmericanT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 And DebC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & DebC.Text & "," & DebT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 And DebC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFormaPago(idventas2,idformapago,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idformapago")) & "," & UberC.Text & "," & UberT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        End If
        rdr.Close()
        rdr2.Close()

        '****** DESCUENTOS *************

        cmd = New SqlCommand("select * from PartidasDesc where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("select * from Descuentos", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idDesc").ToString
                If id = 1 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc10C.Text & "',monto ='" & Desc10T.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc15C.Text & "',monto ='" & Desc15T.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc20C.Text & "',monto ='" & Desc20T.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc25C.Text & "',monto ='" & Desc25T.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc20FAC.Text & "',monto ='" & Desc20FAT.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc20EC.Text & "',monto ='" & Desc20ET.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 7 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc50EC.Text & "',monto ='" & Desc50ET.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 8 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc50SoC.Text & "',monto ='" & Desc50SoT.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc90Emp.Text & "',monto ='" & Desc90ET.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc100C.Text & "',monto ='" & Desc100CT.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 11 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc60Emp.Text & "',monto ='" & Desc60ET.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 12 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc100SC.Text & "',monto ='" & Desc100ST.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 13 Then
                    cmd3 = New SqlCommand("update PartidasDesc set cantidad ='" & Desc100CoC.Text & "',monto ='" & Desc100CoT.Text & "' where idventas2 =" & idventas2 & " and idDesc = " & CSng(rdr2("idDesc")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        Else
            cmd2 = New SqlCommand("select * from Descuentos", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idDesc").ToString
                If id = 1 And Desc10C.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc10C.Text & "," & Desc10T.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 And Desc15C.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc15C.Text & "," & Desc15T.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 And Desc20C.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc20C.Text & "," & Desc20T.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 And Desc25C.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc25C.Text & "," & Desc25T.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 And Desc20FAC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc20FAC.Text & "," & Desc20FAT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 And Desc20EC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc20EC.Text & "," & Desc20ET.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 7 And Desc50EC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc50EC.Text & "," & Desc50ET.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 8 And Desc50SoC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc50SoC.Text & "," & Desc50SoT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 And Desc90Emp.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc90Emp.Text & "," & Desc90ET.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 And Desc100C.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc100C.Text & "," & Desc100CT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 11 And Desc60Emp.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc60Emp.Text & "," & Desc60ET.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 12 And Desc100SC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc100SC.Text & "," & Desc100ST.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 13 And Desc100CoC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasDesc(idventas2,idDesc,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idDesc")) & "," & Desc100CoC.Text & "," & Desc100CoT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        End If
        rdr.Close()
        rdr2.Close()

        '****** FAMILIAS DE PRODUCTOS *************

        cmd = New SqlCommand("select * from PartidasFamiliasVenta where idventas2=" & idventas2, dbC)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            cmd2 = New SqlCommand("select * from FamiliasVenta", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idfam").ToString
                If id = 1 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & HambC.Text & "',monto ='" & HambT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & FritosC.Text & "',monto ='" & FritosT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & EnsalC.Text & "',monto ='" & EnsalT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & PostresC.Text & "',monto ='" & PostresT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & CombosC.Text & "',monto ='" & CombosT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & BebidasC.Text & "',monto ='" & BebidasT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 7 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & CondC.Text & "',monto ='" & CondT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 8 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & PromoC.Text & "',monto ='" & PromoT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & CBKidC.Text & "',monto ='" & CBKidT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & FiestaC.Text & "',monto ='" & FiestaC.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 11 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & SobranteC.Text & "',monto ='" & SobranteT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 12 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & AntC.Text & "',monto ='" & AntT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 13 Then
                    cmd3 = New SqlCommand("update PartidasFamiliasVenta set cantidad ='" & WasteC.Text & "',monto ='" & WasteT.Text & "' where idventas2 =" & idventas2 & " and idfam = " & CSng(rdr2("idfam")) & "", dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        Else
            cmd2 = New SqlCommand("select * from FamiliasVenta", dbC2)
            rdr2 = cmd2.ExecuteReader
            While rdr2.Read
                id = rdr2("idfam").ToString
                If id = 1 And HambC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & HambC.Text & "," & HambT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 2 And FritosC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & FritosC.Text & "," & FritosT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 3 And EnsalC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & EnsalC.Text & "," & EnsalT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 4 And PostresC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & PostresC.Text & "," & PostresT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 5 And CombosC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & CombosC.Text & "," & CombosT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 6 And BebidasC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & BebidasC.Text & "," & BebidasT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 7 And CondC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & CondC.Text & "," & CondT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 8 And PromoC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & PromoC.Text & "," & PromoT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 9 And CBKidC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & CBKidC.Text & "," & CBKidT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 10 And FiestaC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & FiestaC.Text & "," & FiestaC.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 11 And SobranteC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & SobranteC.Text & "," & SobranteT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 12 And AntC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & AntC.Text & "," & AntT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
                If id = 13 And WasteC.Text <> "" Then
                    cmd3 = New SqlCommand(("insert into PartidasFamiliasVenta(idventas2,idfam,cantidad,monto) values(" & idventas2 & "," & CSng(rdr2("idfam")) & "," & WasteC.Text & "," & WasteT.Text & ")"), dbC3)
                    cmd3.ExecuteNonQuery()
                End If
            End While
        End If

        cmd.Dispose()
        dbC.Close()
        dbC.Dispose()
        rdr.Close()
        cmd2.Dispose()
        dbC2.Close()
        dbC2.Dispose()
        rdr2.Close()
        dbC3.Close()
        dbC3.Dispose()
        'Response.Redirect("Ventas.aspx")
    End Sub
    Protected Sub btnDepos_Click(sender As Object, e As EventArgs) Handles btnDepos.Click
        Dim idventas2 As Integer
        idventas2 = Request.QueryString("idc")
        Response.Redirect("Depositos.aspx?idventas2=" & idventas2 & "&fecha=" & fecha.Text & "&suc=" & wucSucursales1.sucursal & "&subt=" & total.Text & "&iva=" & IVA.Text)
    End Sub
End Class
