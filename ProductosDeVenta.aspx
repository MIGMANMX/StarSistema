<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ProductosDeVenta.aspx.vb" Inherits="_ProductosDeVenta" %>

<%@ Register src="cti/wucClasesInsumos.ascx" tagname="wucClasesInsumos" tagprefix="uc1" %>
<%@ Register src="cti/wucClasesInsumos.ascx" tagname="wucClasesInsumos" tagprefix="uc2" %>



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
          width: 500px;
      }
      .auto-style6 {
          height: 24px;
      }
      .auto-style8 {
          width: 989px;
      }
      .auto-style9 {
          width: 306px;
      }
      .auto-style20 {
        width: 472px;
    }
        .auto-style21 {
            width: 200px;
        }
        .auto-style22 {
            width: 64px;
        }
        .auto-style23 {
            width: 238px;
        }
        .auto-style24 {
            width: 502px;
        }
  </style>
    <div id="contenedor" class="auto-style8">
    <% If IsNumeric(Session("idz_e")) Then
            Response.Write("<div id=confirmar style='position:fixed; left:200; top:300; background-color:White; border-style:solid; border-width:1px; border-color:Black;'>")
            Response.Write("<table>")
            Response.Write("<tr><td rowspan=7 width=5 /><td height=6 /><td rowspan=7 width=6 /></tr>")
            Response.Write("<tr><td class=c_titulo>Confirmación</td></tr>")
            Response.Write("<tr><td height=6 /></tr>")
            Response.Write("<tr><td class=c_texto>¿Confirma la eliminación del empleado <b><i>" & Session("dz_e") & "</i></b> ?</td></tr>")
            Response.Write("<tr><td height=6 /></tr>")
            Response.Write("<tr><td align=center><input type=submit name=btnSi value='   Sí   ' class='boton' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")
            Response.Write("<input type=submit name=btnNo value='   No   ' class='boton' /></td></tr>")
            Response.Write("<tr><td height=6 /></tr></table></div>")
        End If%>

    <h3>Productos De Venta</h3>
    <div id="izquierdo" class="auto-style20">
        <table>
            <tr>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idproducto" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="464px">
            <Columns>
                <asp:BoundField DataField="idproducto" ItemStyle-Width="1" ItemStyle-Font-Size="1" >
<ItemStyle Font-Size="1pt" Width="1px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/editar.png"></asp:ButtonField>
                <asp:BoundField DataField="producto" HeaderText="Producto" SortExpression="producto" />
                 <asp:BoundField DataField="clave" HeaderText="Clave" SortExpression="clave" />     
                <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                        
                
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
    <div id="derecho" class="auto-style24">
        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <h4 class="auto-style9">
                        Editar registro de Productos de Venta</h4>
                </td>
                    
               
                <td class="auto-style21">
                    </td>
                
            </tr>
            <tr>
                <td class="auto-style23">
                  
                      <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-info btn-block btn-flat" Text="Actualizar"  ToolTip="Actualizar datos" Enabled="false" Width="108px" />
                  
                    <asp:label ID="Lmsg" runat="server" CssClass="error"></asp:label>
                  
                    <br />
                    </td>
                 <td class="auto-style22">
                  
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success btn-block btn-flat" Text="Agregar" ToolTip="Agregar" Width="108px" />
                  
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="auto-style23">Producto:<br />
                    <asp:TextBox ID="TxtInsumo" runat="server" CssClass="txtCaptura" MaxLength="40" Width="208px" /></td>
                <td class="auto-style22">Clave:<br />
                                    <asp:TextBox ID="Txtclave" runat="server" CssClass="txtCaptura" MaxLength="40" Width="79px" style="margin-left: 0" />
                </td>  
                <td class="auto-style21">

                    Costo:<br />
                    <asp:TextBox ID="TxtCosto" runat="server" CssClass="txtCaptura" MaxLength="40" Width="67px" />

                </td>      
            </tr>
            
             </table>
    </div> <!-- registroDatos -->
</div>
</asp:Content>

