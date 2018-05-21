
Imports SistemaLogica

Partial Class _ProveedorCompras
    Inherits System.Web.UI.Page
    Public gvPos As Integer
    Dim Catt As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session("usuario")) Then Response.Redirect("Default.aspx", True)
        Session("menu") = "C"
        Lmsg.Text = "" : gvPos = 0
        If Not Page.IsPostBack Then
            Dim gvds As New ctiCatalogos
            GridView1.DataSource = gvds.gvProveedorCompras
            gvds = Nothing
            GridView1.DataBind()
        End If
        Lmsg.Text = "" : gvPos = 0
        If Request.Form("btnSi") <> "" Then
            Dim ep As New ctiCatalogos
            Dim err As String = ep.eliminarProveedorCompras(CInt(Session("idz_e").ToString))
            GridView1.DataSource = ep.gvProveedorCompras()
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
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If TxtProveedor.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else

            Dim _razon As String
            If TxtRazon.Text <> "" Then
                _razon = Convert.ToString(TxtRazon.Text)
            Else
                _razon = " "
            End If

            Dim _cuenta As String
            If TxtCuenta.Text <> "" Then
                _cuenta = Convert.ToString(TxtCuenta.Text)
            Else
                _cuenta = " "
            End If

            Dim _contacto1 As String
            If TxtContacto1.Text <> "" Then
                _contacto1 = Convert.ToString(TxtContacto1.Text)
            Else
                _contacto1 = " "
            End If

            Dim _contacto2 As String
            If TxtContacto2.Text <> "" Then
                _contacto2 = Convert.ToString(TxtContacto2.Text)
            Else
                _contacto2 = " "
            End If

            Dim _numero As String
            If TxtNumero1.Text <> "" Then
                _numero = Convert.ToString(TxtNumero1.Text)
            Else
                _numero = " "
            End If

            Dim _numero2 As String
            If TxtNumero2.Text <> "" Then
                _numero2 = Convert.ToString(TxtNumero2.Text)
            Else
                _numero2 = " "
            End If

            Dim _diacredito As String
            If TxtDias.Text <> "" Then
                _diacredito = Convert.ToString(TxtDias.Text)
            Else
                _diacredito = " "
            End If

            Dim _limite As String
            If TxtLimite.Text <> "" Then
                _limite = Convert.ToString(TxtLimite.Text)
            Else
                _limite = " "
            End If

            Dim _diapago As String
            If TxtDiaspago.Text <> "" Then
                _diapago = Convert.ToString(TxtDiaspago.Text)
            Else
                _diapago = " "
            End If

            Dim ap As New ctiCatalogos
            Dim idA As Integer = CInt(GridView1.Rows(Convert.ToInt32(grdSR.Text)).Cells(0).Text)
            Dim r As String = ap.actualizarProveedorCompras(idA, TxtProveedor.Text, _cuenta, _numero, _numero2, _razon, _contacto1, _contacto2, _diacredito, _limite, _diapago)
            GridView1.DataSource = ap.gvProveedorCompras()
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
                TxtContacto1.Text = "" : TxtCuenta.Text = "" : TxtDias.Text = "" : TxtDiaspago.Text = "" : TxtLimite.Text = "" : TxtNumero1.Text = "" : TxtNumero2.Text = ""
                TxtContacto2.Text = "" : TxtProveedor.Text = "" : TxtRazon.Text = ""


            End If


            gvp = Nothing
            Lmsg.Text = r
        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If TxtProveedor.Text = "" Then
            Lmsg.Text = "Error : Falta capturar un dato"
        Else

            Dim _razon As String
            If TxtRazon.Text <> "" Then
                _razon = Convert.ToString(TxtRazon.Text)
            Else
                _razon = " "
            End If

            Dim _cuenta As String
            If TxtCuenta.Text <> "" Then
                _cuenta = Convert.ToString(TxtCuenta.Text)
            Else
                _cuenta = " "
            End If

            Dim _contacto1 As String
            If TxtContacto1.Text <> "" Then
                _contacto1 = Convert.ToString(TxtContacto1.Text)
            Else
                _contacto1 = " "
            End If

            Dim _contacto2 As String
            If TxtContacto2.Text <> "" Then
                _contacto2 = Convert.ToString(TxtContacto2.Text)
            Else
                _contacto2 = " "
            End If

            Dim _numero As String
            If TxtNumero1.Text <> "" Then
                _numero = Convert.ToString(TxtNumero1.Text)
            Else
                _numero = " "
            End If

            Dim _numero2 As String
            If TxtNumero2.Text <> "" Then
                _numero2 = Convert.ToString(TxtNumero2.Text)
            Else
                _numero2 = " "
            End If

            Dim _diacredito As String
            If TxtDias.Text <> "" Then
                _diacredito = Convert.ToString(TxtDias.Text)
            Else
                _diacredito = " "
            End If

            Dim _limite As String
            If TxtLimite.Text <> "" Then
                _limite = Convert.ToString(TxtLimite.Text)
            Else
                _limite = " "
            End If

            Dim _diapago As String
            If TxtDiaspago.Text <> "" Then
                _diapago = Convert.ToString(TxtDiaspago.Text)
            Else
                _diapago = " "
            End If


            If IsNumeric(grdSR.Text) Then
                grdSR.Text = ""
                btnActualizar.CssClass = "btn btn-info btn-block btn-flat" : btnActualizar.Enabled = False
            End If
            Dim gp As New ctiCatalogos

            Dim r() As String = gp.agregarProveedorCompras(TxtProveedor.Text, _cuenta, _numero, _numero2, _razon, _contacto1, _contacto2, _diacredito, _limite, _diapago)
            GridView1.DataSource = gp.gvProveedorCompras()
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

                TxtContacto1.Text = "" : TxtCuenta.Text = "" : TxtDias.Text = "" : TxtDiaspago.Text = "" : TxtLimite.Text = "" : TxtNumero1.Text = "" : TxtNumero2.Text = ""
                TxtContacto2.Text = "" : TxtProveedor.Text = "" : TxtRazon.Text = ""

            End If
            Lmsg.Text = r(0)
        End If
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
            Dim datos() As String = dsP.datosProveedorCompras(CInt(GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text))
            dsP = Nothing
            If datos(0).StartsWith("Error") Then
                Lmsg.CssClass = "error"
                Lmsg.Text = datos(0)
            Else
                TxtProveedor.Text = datos(0)
                TxtCuenta.Text = datos(1)
                TxtNumero1.Text = datos(2)
                TxtNumero2.Text = datos(3)
                TxtRazon.Text = datos(4)
                TxtContacto1.Text = datos(5)
                TxtContacto2.Text = datos(6)
                TxtDias.Text = datos(7)
                TxtLimite.Text = datos(8)
                TxtDiaspago.Text = datos(9)

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
End Class
