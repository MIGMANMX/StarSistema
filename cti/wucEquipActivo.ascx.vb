Imports SistemaLogica

Partial Class cti_wucEquipActivo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim lista As New ctiWUC
            ddlEquipActivo.DataSource = lista.wucEquipActivo
            lista = Nothing
            ddlEquipActivo.DataTextField = "key"
            ddlEquipActivo.DataValueField = "value"
            ddlEquipActivo.DataBind()
            Dim selItm As New ListItem
            selItm.Text = "Seleccionar..." : selItm.Value = 0
            ddlEquipActivo.Items.Insert(0, selItm)
        End If
    End Sub

    Public Property idClase As Integer
        Get
            If ddlEquipActivo.SelectedIndex >= 0 Then Return CInt(ddlEquipActivo.SelectedValue) Else Return 0
        End Get
        Set(value As Integer)
            Try
                ddlEquipActivo.SelectedValue = value
            Catch ex As Exception
                ddlEquipActivo.SelectedIndex = -1
            End Try
        End Set
    End Property
    Public Property ddlAutoPostBack() As Boolean
        Get
            Return ddlEquipActivo.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            ddlEquipActivo.AutoPostBack = value
        End Set
    End Property

    Public Event claseSeleccionada As EventHandler
    Protected Sub ddlEquipActivo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlEquipActivo.SelectedIndexChanged
        RaiseEvent claseSeleccionada(ddlEquipActivo, e)
    End Sub
End Class
