<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Productos.aspx.vb" Inherits="_Productos" %>

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
          width: 564px;
      }
      .auto-style3 {
          height: 24px;
          width: 185px;
      }
      .auto-style6 {
          height: 24px;
      }
      .auto-style7 {
          width: 109px;
      }
      .auto-style8 {
          width: 1115px;
      }
      .auto-style9 {
          width: 256px;
      }
      .auto-style11 {
          height: 24px;
          width: 179px;
      }
      .auto-style18 {
          width: 185px;
      }
      .auto-style19 {
          width: 179px;
      }
    .auto-style20 {
        width: 472px;
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

    <h3>Productos</h3>
    <div id="izquierdo" class="auto-style20">
        <table>
            <tr>
                <td class="auto-style6">Productos:<br />
                    <uc1:wucClasesInsumos ID="wucClasesInsumos" runat="server" /></td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idinsumo" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="464px">
            <Columns>
                <asp:BoundField DataField="idinsumo" ItemStyle-Width="1" ItemStyle-Font-Size="1" >
<ItemStyle Font-Size="1pt" Width="1px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/editar.png"></asp:ButtonField>
                <asp:BoundField DataField="insumo" HeaderText="Producto" SortExpression="producto" />
                 <asp:BoundField DataField="clave" HeaderText="Clave" SortExpression="clave" />     
                <asp:BoundField DataField="clase" HeaderText="Clase" SortExpression="clase" />
                        
                
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
                        Editar registro de Productos</h4>  </td>
                    
               
                <td>
                    </td>
                
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
                <td class="auto-style18">Insumo:<br />
                    <asp:TextBox ID="TxtInsumo" runat="server" CssClass="txtCaptura" MaxLength="40" Width="168px" /></td>
                <td class="auto-style19">Clave:<br />
                                    <asp:TextBox ID="Txtclave" runat="server" CssClass="txtCaptura" MaxLength="40" Width="99px" style="margin-left: 0" />
                </td>  
                <td>

                    Activo:<asp:checkbox ID="activo" runat="server" Checked="True" /> <br />
                    <br />

                </td>      
            </tr>
            
            <tr>
                <td class="auto-style18">Crítico:&nbsp;<asp:checkbox ID="Critico" runat="server" />
                    </td>
             
            <td class="auto-style19">Medible:&nbsp;<asp:checkbox ID="medible" runat="server" />
            </td>
                <td>
                    IVA:&nbsp;<asp:checkbox ID="IVA" runat="server" />
                    <br />
                </td>
            </tr>

            <tr>
                <td class="auto-style3">Clase:<br />
                    <uc2:wucClasesInsumos ID="wucClases" runat="server" /></td>
                <td class="auto-style11">Mangas por Caja:<br />
                    <asp:TextBox ID="TxtMangas" runat="server" CssClass="txtCaptura" MaxLength="40" Width="162px" /></td>
                <td>Piezas por Manga:<br />
                    <asp:TextBox ID="TxtPiezas" runat="server" CssClass="txtCaptura" MaxLength="40" Width="168px" /></td>
                
            </tr>
            <tr>
                <td>

                    Piezas por Caja:<br />
                    <asp:TextBox ID="TxtCaja" runat="server" CssClass="txtCaptura" MaxLength="40" Width="162px" />

                </td>
                <td>

                    Costo:<br />
                    <asp:TextBox ID="TxtCosto" runat="server" CssClass="txtCaptura" MaxLength="40" Width="162px" />

                </td>
                <td>

                    &nbsp;</td>
            </tr>
             </table>
    </div> <!-- registroDatos -->
</div>
</asp:Content>

