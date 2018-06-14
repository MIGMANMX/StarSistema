Imports SistemaLogica

Partial Class cti_wucClasesA
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim lista As New ctiWUC
            ddlClaseA.DataSource = lista.wucClaseA
            lista = Nothing
            ddlClaseA.DataTextField = "key"
            ddlClaseA.DataValueField = "value"
            ddlClaseA.DataBind()
            Dim selItm As New ListItem
            selItm.Text = "Seleccionar..." : selItm.Value = 0
            ddlClaseA.Items.Insert(0, selItm)
        End If
    End Sub

    Public Property idClase As Integer
        Get
            If ddlClaseA.SelectedIndex >= 0 Then Return CInt(ddlClaseA.SelectedValue) Else Return 0
        End Get
        Set(value As Integer)
            Try
                ddlClaseA.SelectedValue = value
            Catch ex As Exception
                ddlClaseA.SelectedIndex = -1
            End Try
        End Set
    End Property
    Public Property ddlAutoPostBack() As Boolean
        Get
            Return ddlClaseA.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            ddlClaseA.AutoPostBack = value
        End Set
    End Property

    Public Event claseSeleccionada As EventHandler
    Protected Sub ddlClaseA_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlClaseA.SelectedIndexChanged
        RaiseEvent claseSeleccionada(ddlClaseA, e)
    End Sub
End Class
