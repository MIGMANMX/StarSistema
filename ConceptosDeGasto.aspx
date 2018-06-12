<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ConceptosDeGasto.aspx.vb" Inherits="_ConceptosDeGasto" %>

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
      .auto-style8 {
          width: 770px;
      }
      .auto-style20 {
        width: 586px;
    }
        .auto-style23 {
            height: 23px;
            width: 247px;
        }
        .auto-style24 {
            width: 200px;
            height: 36px;
        }
        .auto-style25 {
            height: 23px;
            width: 200px;
        }
        .auto-style26 {
            width: 247px;
            height: 36px;
        }
        .auto-style27 {
            width: 298px;
        }
        .auto-style28 {
            height: 23px;
            width: 298px;
        }
        .auto-style29 {
            width: 298px;
            height: 36px;
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

    <h3>Conceptos de Gasto</h3>
    <div id="izquierdo" class="auto-style20">
        <table>
            <tr>
                <td class="auto-style29">

                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success btn-block btn-flat" Text="Agregar" ToolTip="Agregar" Width="108px" />
                  
                </td>
                <td class="auto-style26">

                      <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-info btn-block btn-flat" Text="Actualizar"  ToolTip="Actualizar datos" Enabled="false" Width="108px" />
                  
                </td>
                <td class="auto-style24">
                  
                    <asp:label ID="Lmsg" runat="server" CssClass="error"></asp:label>
                  
                    </td>
            </tr>
            <tr>
                <td class="auto-style28">Clase:<br />
                    <uc1:wucClasesInsumos ID="wucClasesInsumos" runat="server" width="200px"/></td>
                <td class="auto-style23">Concepto:<br />
                    <asp:TextBox ID="TxtInsumo" runat="server" CssClass="txtCaptura" MaxLength="40" Width="168px" /></td>
                <td class="auto-style25">&nbsp;Clave:<br />
                                    <asp:TextBox ID="Txtclave" runat="server" CssClass="txtCaptura" MaxLength="40" Width="99px" style="margin-left: 0" />
                    &nbsp;</td>
                
            </tr>
                    <tr>
                        <td class="auto-style27">

                        </td>
                    </tr>    
        </table>
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idinsumo" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="573px">
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
    </div> <!-- registroDatos -->
</div>
</asp:Content>

