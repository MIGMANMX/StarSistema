<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Clases.aspx.vb" Inherits="_Clases" %>

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
          width: 225px;
      }
      .auto-style6 {
          height: 24px;
      }
      .auto-style8 {
          width: 1217px;
      }
      .auto-style9 {
          width: 306px;
      }
      .auto-style20 {
        width: 908px;
    }
        .auto-style22 {
            width: 64px;
        }
        .auto-style25 {
            width: 40px;
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

    <h3>&nbsp;Clases de Productos</h3>
    <div id="izquierdo" class="auto-style20">
        <table>
            <tr>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idproducto" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="857px">
            <Columns>
                <asp:BoundField DataField="idproducto" ItemStyle-Width="1" ItemStyle-Font-Size="1" >
<ItemStyle Font-Size="1pt" Width="1px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/editar.png"></asp:ButtonField>
                <asp:BoundField DataField="clave" HeaderText="Clave" SortExpression="Clave" />
                 <asp:BoundField DataField="clase" HeaderText="Clase" SortExpression="clase" />     
                <asp:BoundField DataField="cuenta_s1" HeaderText="Cuenta_s1" SortExpression="cuenta_s1" />
                <asp:BoundField DataField="cuenta_s2" HeaderText="Cuenta_s2" SortExpression="cuenta_s2" />
                <asp:BoundField DataField="cuenta_s3" HeaderText="Cuenta_s3" SortExpression="cuenta_s3" />
                <asp:BoundField DataField="cuenta_s4" HeaderText="Cuenta_s4" SortExpression="cuenta_s4" />
                <asp:BoundField DataField="cuenta_s5" HeaderText="Cuenta_s5" SortExpression="cuenta_s5" />
                <asp:BoundField DataField="cuenta_s6" HeaderText="Cuenta_s6" SortExpression="cuenta_s6" />
                <asp:BoundField DataField="cuenta_sl" HeaderText="Cuenta_sL" SortExpression="cuenta_sl" />
                <asp:BoundField DataField="cuenta_si" HeaderText="Cuenta_sI" SortExpression="cuenta_si" />     
                
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
        <br />
        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <h4 class="auto-style9">
                        Editar registro de Clases de productos</h4>
                </td>
                    
               
            </tr>
            <tr>
                <td class="auto-style25">
                  
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
                <td class="auto-style25">Clase:<br />
                    <asp:TextBox ID="TxtClase" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" /></td>
                <td class="auto-style22">Clave:<br />
                                    <asp:TextBox ID="Txtclave" runat="server" CssClass="txtCaptura" MaxLength="40" Width="79px" style="margin-left: 0" />
                </td>  
            </tr>
            <tr>
                <td class="auto-style25">Cuenta S1:<br />
                    <asp:TextBox ID="TxtCuentaS1" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" /></td>
                <td class="auto-style22">CuentaS2:<br />
                                    <asp:TextBox ID="TxtCuentaS2" runat="server" CssClass="txtCaptura" MaxLength="40" Width="114px" style="margin-left: 0" />
                </td>  
            </tr>
            <tr>
                <td class="auto-style25">Cuenta S3:<br />
                    <asp:TextBox ID="TxtCuentaS3" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" /></td>
                <td class="auto-style22">CuentaS4:<br />
                                    <asp:TextBox ID="TxtCuentaS4" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" style="margin-left: 0" />
                </td>  
            </tr>
            <tr>
                <td class="auto-style25">Cuenta S5:<br />
                    <asp:TextBox ID="TxtCuentaS5" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" /></td>
                <td class="auto-style22">CuentaS6:<br />
                                    <asp:TextBox ID="TxtCuentaS6" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" style="margin-left: 0" />
                </td>  
            </tr>
            <tr>
                <td class="auto-style25">Cuenta L:<br />
                    <asp:TextBox ID="TxtCuentaL" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" /></td>
                <td class="auto-style22">Cuenta I:<br />
                                    <asp:TextBox ID="TxtCuentaI" runat="server" CssClass="txtCaptura" MaxLength="40" Width="115px" style="margin-left: 0" />
                </td>  
            </tr>
            <tr>
                <td class="auto-style25">

                    Impacta Costo:<asp:checkbox ID="Chkimpacta" runat="server" Checked="True" /> 

                </td>
            </tr>
             </table>
    </div> <!-- listaDatos -->
    <div>
    </div> <!-- registroDatos -->
</div>
</asp:Content>

