<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ProveedorGastos.aspx.vb" Inherits="_ProveedorGastos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        #contenedor{
            overflow:hidden
        }
        #izquierdo{
            float:left;
        }

         #derecho{
             float:right;
        }
      .auto-style1 {
          width: 598px;
      }
      .auto-style5 {
            width: 322px;
        }
      .auto-style8 {
          width: 1121px;
      }
      .auto-style9 {
          width: 256px;
      }
      .auto-style16 {
          width: 175px;
      }
      .auto-style20 {
        width: 472px;
    }
        .auto-style24 {
            width: 335px;
            height: 56px;
        }
        .auto-style26 {
            width: 335px;
        }
        .auto-style27 {
            width: 281px;
        }
  </style>
    <div id="contenedor" class="auto-style8">
         <% If IsNumeric(Session("idz_e")) Then
                 Response.Write("<div id=confirmar style='position:fixed; left:200; top:300; background-color:White; border-style:solid; border-width:1px; border-color:Black;'>")
                 Response.Write("<table>")
                 Response.Write("<tr><td rowspan=7 width=5 /><td height=6 /><td rowspan=7 width=6 /></tr>")
                 Response.Write("<tr><td class=c_titulo>Confirmación</td></tr>")
                 Response.Write("<tr><td height=6 /></tr>")
                 Response.Write("<tr><td class=c_texto>¿Confirma la eliminación  <b><i>" & Session("dz_e") & "</i></b> ?</td></tr>")
                 Response.Write("<tr><td height=6 /></tr>")
                 Response.Write("<tr><td align=center><input type=submit name=btnSi value='   Sí   ' class='boton' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
                 Response.Write("<input type=submit name=btnNo value='   No   ' class='boton' /></td></tr>")
                 Response.Write("<tr><td height=6 /></tr></table></div>")
             End If%>
        <h3>Proveedor de Gastos</h3>
    <div id="izquierdo" class="auto-style20">
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idproveedor" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="464px">
            <Columns>
                <asp:BoundField DataField="idproveedor" ItemStyle-Width="1" ItemStyle-Font-Size="1" >
<ItemStyle Font-Size="1pt" Width="1px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/editar.png"></asp:ButtonField>
                <asp:BoundField DataField="proveedor" HeaderText="Proveedor" SortExpression="Proveedor" />
                <%--<asp:BoundField DataField="razon_social" HeaderText="Razon Social" SortExpression="razon_social" />--%>              
                <asp:BoundField DataField="cuenta" HeaderText="Cuenta" SortExpression="cuenta" />               
                <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/Imagenes/eliminar.png"></asp:ButtonField> 
           </Columns>
            <HeaderStyle BackColor="#0099CC" ForeColor="#f8f8f8" />
            <RowStyle BackColor="#f3f3f3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="#fbfbfb" />
            <SelectedRowStyle BackColor="#fffcbf" />
            <FooterStyle BackColor="#3088b0" Font-Size="1" Height="1" />
            <PagerStyle BackColor="#3088b0" ForeColor="#333333" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:TextBox ID="grdSR" runat="server" Visible="false"></asp:TextBox>
    </div> <!-- listaDatos -->
    <div id="derecho">
        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <h4 class="auto-style9">
                        Editar Proveedor de Gastos</h4>  </td>
                    
               
                
                
            </tr>
            <tr>
                <td class="auto-style24">
                  
                      <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-info btn-block btn-flat" Text="Actualizar"  ToolTip="Actualizar datos" Enabled="false" Width="108px" />
                  
                    <asp:label ID="Lmsg" runat="server" CssClass="error"></asp:label>
                  
                    <br />
                    </td>
                 <td class="auto-style24">
                  
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success btn-block btn-flat" Text="Agregar" ToolTip="Agregar" Width="108px" />
                  
                    <br />
                    </td>
                  
            </tr>
            <tr>
                <td class="auto-style26">Proveedor:<br />
                    <asp:TextBox ID="TxtProveedor" runat="server" CssClass="txtCaptura" MaxLength="40" Width="309px" /></td>
                <td>Cuenta:<br />
                    <asp:TextBox ID="TxtCuenta" runat="server" CssClass="txtCaptura" MaxLength="40" Width="162px" /></td>
                   
            </tr>
            
            
             </table>
        <hr class="auto-style1" />
        <table>Datos de Contacto:
            
             <tr>

                <td class="auto-style5">Contacto:<br />
                    <asp:TextBox ID="TxtContacto1" runat="server" CssClass="txtCaptura" MaxLength="40" Width="250px" /></td>
                <td class="auto-style27">Telefono:<br />

                    <asp:TextBox ID="TxtNumero1" runat="server" CssClass="txtCaptura" MaxLength="40" Width="163px" /></td>        
            
             </tr>
             <tr>
                <td class="auto-style5">Contacto:<br />
                    <asp:TextBox ID="TxtContacto2" runat="server" CssClass="txtCaptura" MaxLength="40" Width="248px" /></td>
                <td class="auto-style27">Telefono:<br />
                    <asp:TextBox ID="TxtNumero2" runat="server" CssClass="txtCaptura" MaxLength="40" Width="168px" /></td>   
                   
            </tr>
            <tr>

                <td class="auto-style5">Contacto:<br />
                    <asp:TextBox ID="TxtContacto3" runat="server" CssClass="txtCaptura" MaxLength="40" Width="250px" /></td>
                <td class="auto-style27">Telefono:<br />

                    <asp:TextBox ID="TxtNumero3" runat="server" CssClass="txtCaptura" MaxLength="40" Width="163px" /></td>        
            
             </tr>
            </table>
        <hr />
        <table>Datos de Crédito:
            <tr>
               <td class="auto-style16">Días de crédito:<br />
                    <asp:TextBox ID="TxtDias" runat="server" CssClass="txtCaptura" MaxLength="40" Width="89px" /></td>
                <td class="auto-style16">Límite de crédito:<br />
                    <asp:TextBox ID="TxtLimite" runat="server" CssClass="txtCaptura" MaxLength="40" Width="123px" /></td>
              <td class="auto-style16">Días de pago:<br />
                    <asp:TextBox ID="TxtDiaspago" runat="server" CssClass="txtCaptura" MaxLength="40" Width="123px" /></td>
             
                 </tr>
             </table>
    </div> <!-- registroDatos -->
</div>
</asp:Content>

