<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Ventas.aspx.vb" Inherits="_Ventas" %>

<%@ Register src="cti/wucSucursales.ascx" tagname="wucSucursales" tagprefix="uc1" %>
<%@ Register src="cti/wucPuestos.ascx" tagname="wucPuestos" tagprefix="uc2" %>
<%@ Register src="cti/wucSuc.ascx" tagname="wucSuc" tagprefix="uc3" %>
<%@ Register src="cti/wucFormasPagoSub.ascx" tagname="wucFormasPagoSub" tagprefix="uc4" %>

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
          width: 684px;
      }
      .auto-style6 {
          height: 24px;
            width: 178px;
        }
      .auto-style8 {
          width: 1102px;
      }
      .auto-style9 {
          width: 256px;
      }
      .auto-style10 {
          width: 140px;
      }
      .auto-style11 {
          height: 24px;
          width: 144px;
      }
      .auto-style19 {
          width: 179px;
      }
    .auto-style20 {
        width: 365px;
    }
        .auto-style21 {
            width: 178px;
        }
        .auto-style23 {
            height: 23px;
        }
        .auto-style24 {
            width: 144px;
            height: 23px;
        }
        .auto-style29 {
            width: 144px;
            height: 20px;
        }
        .auto-style30 {
            height: 20px;
        }
        .auto-style31 {
            height: 24px;
        }
        .auto-style32 {
            height: 23px;
            width: 88px;
        }
        .auto-style33 {
            width: 88px;
        }
        .auto-style37 {
            height: 12px;
        }
        .auto-style38 {
            width: 144px;
            height: 12px;
        }
        .auto-style39 {
            width: 692px;
            margin-right: 15px;
        }
        .auto-style40 {
            width: 88px;
            height: 20px;
        }
        .auto-style42 {
            height: 12px;
            width: 155px;
        }
        .auto-style44 {
            height: 24px;
            width: 155px;
        }
        .auto-style45 {
            height: 23px;
            width: 155px;
        }
        .auto-style46 {
            width: 155px;
            height: 20px;
        }
        .auto-style48 {
            width: 170px;
            height: 23px;
        }
        .auto-style49 {
            width: 170px;
            height: 12px;
        }
        .auto-style50 {
            width: 170px;
            height: 20px;
        }
        .auto-style51 {
            width: 170px;
        }
        .auto-style52 {
            width: 170px;
            height: 24px;
        }
        .auto-style54 {
            width: 155px;
            height: 25px;
        }
        .auto-style55 {
            height: 25px;
            width: 117px;
        }
        .auto-style56 {
            width: 170px;
            height: 25px;
        }
        .auto-style57 {
            width: 155px;
        }
        .auto-style58 {
            width: 179px;
            height: 23px;
        }
        .auto-style59 {
            height: 12px;
            width: 179px;
        }
        .auto-style60 {
            width: 179px;
            height: 20px;
        }
        .auto-style61 {
            height: 24px;
            width: 179px;
        }
        .auto-style63 {
            height: 25px;
            width: 179px;
        }
        .auto-style64 {
            height: 23px;
            width: 117px;
        }
        .auto-style65 {
            height: 12px;
            width: 117px;
        }
        .auto-style66 {
            height: 20px;
            width: 117px;
        }
        .auto-style67 {
            height: 24px;
            width: 117px;
        }
        .auto-style68 {
            width: 117px;
        }
        .auto-style71 {
            width: 144px;
        }
        .auto-style72 {
            height: 23px;
            width: 109px;
        }
        .auto-style73 {
            height: 12px;
            width: 109px;
        }
        .auto-style74 {
            height: 20px;
            width: 109px;
        }
        .auto-style75 {
            height: 24px;
            width: 109px;
        }
        .auto-style76 {
            width: 109px;
        }
        .auto-style77 {
            width: 109px;
            height: 25px;
        }
        .auto-style78 {
            height: 25px;
        }
        .auto-style79 {
            width: 144px;
            height: 25px;
        }
        .auto-style81 {
            width: 254px;
            height: 24px;
        }
        .auto-style82 {
            width: 254px;
        }
        .auto-style83 {
            width: 152px;
        }
        .auto-style85 {
            width: 156px;
        }
        .auto-style86 {
            height: 39px;
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

    <h3>Ventas</h3>
    <div id="izquierdo" class="auto-style20">
        <table>
            <tr>
                <td class="auto-style81">Sucursal:<br />
                    <uc1:wucsucursales ID="wucSucursales" runat="server" /></td>
                
                <td class="auto-style83">Subotal:<br />
                    <asp:TextBox ID="subTxtV" runat="server" CssClass="txtCaptura" MaxLength="40" Width="73px" Height="22px" /></td>
                <td>                  
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success btn-block btn-flat" Text="Agregar" ToolTip="Agregar" Width="83px" />
                  
                    </td>
            </tr>
            <tr>
                <td class="auto-style82">Fecha:<br />
                    <asp:TextBox ID="fechaTxtV" runat="server" CssClass="txtCaptura" MaxLength="40" Width="135px" />

                    
                    &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Height="18px" ImageUrl="~/img/favicon.ico" Width="19px" />

                    </td>

                <td class="auto-style83">IVA:<br />
                    <asp:TextBox ID="ivaTxtV" runat="server" CssClass="txtCaptura" MaxLength="40" Width="55px" /></td>
            </tr>
            <tr>
                <td class="auto-style82">
                    
                <asp:Calendar ID="FIngreso0" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="76px" Width="161px" TitleFormat="Month" Visible="False" >
                    <DayHeaderStyle BackColor="White" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#999999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#FFCC66" ForeColor="#336666" />
                    <TitleStyle BackColor="#FF9900" BorderColor="#FFCC66" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>

                </td>
                <td class="auto-style83">

                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" 
            DataKeyNames ="idventas2" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="360px" AllowPaging="True" PageSize="50">
            <Columns>
                <asp:BoundField DataField="idventas2" ItemStyle-Width="1" ItemStyle-Font-Size="1" >
<ItemStyle Font-Size="1pt" Width="1px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Imagenes/editar.png"></asp:ButtonField>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" HtmlEncode="False" DataFormatString = "{0:d}"/>
                <asp:BoundField DataField="sucursal" HeaderText="Sucursal" SortExpression="sucursal" />               
                <asp:BoundField DataField="VentaN" HeaderText="Subtotal" SortExpression="VentaN" HtmlEncode="False" DataFormatString = "{0:C3}"/>                
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
    <div id="derecho" class="auto-style39">
        <table class="auto-style1">
            <tr>
                <td colspan="2" class="auto-style86">
                    <h4 class="auto-style9">
                        Editar registro de Ventas</h4>  </td>
                    
               
                <td class="auto-style86">
                    </td>
                
            </tr>
            <tr>
                <td class="auto-style57">

                      <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-info btn-block btn-flat" Text="Actualizar"  ToolTip="Actualizar datos" Enabled="false" Width="108px" />

                </td>
                <td class="auto-style85">

<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" id="Dep" runat="server">
    Depositos
</button>

                    
                </td>
                <td>

                    <asp:label ID="Lmsg" runat="server" CssClass="error"></asp:label>
                  
                  
                  
                </td>
            </tr>
              </table>
        <hr />
            <table>
            <tr>
                <td class="auto-style6">Sucursal:<br />
                    <uc1:wucsucursales ID="wucSucursales1" runat="server" />
                    
                    
                 
                    <asp:label ID="lblsuc" runat="server" CssClass="error"></asp:label>
                  
                </td>
                
                <td class="auto-style10">Subotal:<br />
                    <asp:TextBox ID="total" runat="server" CssClass="txtCaptura" MaxLength="40" Width="102px" Height="22px" /></td>
                <td class="auto-style19">                  

                    
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h2 class="modal-title" id="exampleModalLabel">Depósitos</h2>
        <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">--%>
          <%--<span aria-hidden="true">&times;</span>--%>
        <%--</button>--%>
      </div>
      <div class="modal-body">
          <table>
              <tr>
                <td>Sucursal:<asp:label ID="lblSucM" runat="server" CssClass="error"></asp:label>
                </td>
              </tr>
              <tr>
                <td>Fecha:<asp:label ID="lblFechaM" runat="server" CssClass="error"></asp:label>
                </td>  
              </tr>
              <tr>
                <td>Total:<asp:label ID="lblTotalM" runat="server" CssClass="error"></asp:label>
                </td>   
              </tr>  
            
          </table>
           <asp:Button ID="ibGuardarCompra" runat="server" CssClass="btn btn-danger btn-block btn-flat" Text="Agregar"  ToolTip="Agregar datos" Enabled="false" Width="108px" />
   
          <hr />
          <h3>AGREGAR FORMA DE PAGO</h3>
           <table>
          
              <tr>
                 <td>Realizó:<asp:TextBox ID="txtRealizoM" runat="server" CssClass="txtCaptura" MaxLength="40" Width="140px" Height="22px" />
                 </td>
                 <td>Referencia:<asp:TextBox ID="txtRefM" runat="server" CssClass="txtCaptura" MaxLength="40" Width="140px" Height="22px" />
                 </td>
                 <td>Comentarios:<asp:TextBox ID="txtInfoM" runat="server" CssClass="txtCaptura" MaxLength="40" Width="140px" Height="22px" />
                 </td>                
              </tr>
             <tr>
                 <td>Forma de Pago:<br />
                     <uc4:wucFormasPagoSub ID="wucFormasPagoSub" runat="server" />
                  </td>
                 <td>Monto:	<asp:TextBox ID="txtMontoM" runat="server" CssClass="txtCaptura" MaxLength="40" Width="150px" Height="22px" />
                 </td>
                 <td>  <asp:Button ID="ibGuardarPartida" runat="server" CssClass="btn btn-warning btn-block btn-flat" Text="Agregar"  ToolTip="Agregar datos" Enabled="false" Width="108px" />
                 </td>
            </tr>          
          </table>
          <hr />
          <h3>FORMAS DE PAGO</h3>
         <table>
              <tr>
                <td>Monto total:<asp:label ID="ltotalM" runat="server" CssClass="error"></asp:label>
                </td>
              </tr>
              <tr>
                <td>Diferencia:<asp:label ID="ldifM" runat="server" CssClass="error"></asp:label>
                </td>  
              </tr>                       
          </table>


      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
        <%--<button type="button" class="btn btn-primary">Guardar</button>--%>
      </div>
    </div>
  </div>
</div>

                </td>
            </tr>
            <tr>
                <td class="auto-style21">Fecha:<br />
                    <asp:TextBox ID="fecha" runat="server" CssClass="txtCaptura" MaxLength="40" Width="135px" />

                    
                    &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" Height="18px" ImageUrl="~/img/favicon.ico" Width="19px" />

                    </td>

                <td class="auto-style10">IVA:<br />
                    <asp:TextBox ID="IVA" runat="server" CssClass="txtCaptura" MaxLength="40" Width="74px" /></td>
                <td class="auto-style19">
                   
                    Total :&nbsp;
                    <asp:label ID="lblTotal" runat="server" CssClass="error"></asp:label>
                  
                </td>
            </tr>
            <tr>
                <td class="auto-style21">
                    
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="76px" Width="161px" TitleFormat="Month" Visible="False" >
                    <DayHeaderStyle BackColor="White" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#999999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#FFCC66" ForeColor="#336666" />
                    <TitleStyle BackColor="#FF9900" BorderColor="#FFCC66" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="White" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>

                </td>
                <td class="auto-style10">

                </td>
            </tr>
      
          </table>
        <hr />
        <table>
            <tr>
                <td class="auto-style72"></td>
                <td class="auto-style24">TICKETS Y VOIDS</td>
                <td class="auto-style23"></td>
                <td class="auto-style24">TIPO DE TICKET </td>  
                <td class="auto-style32"></td>
                <td class="auto-style23">FORMAS DE PAGO</td>      
            </tr>
             <tr>
                <td class="auto-style73"></td>
                <td class="auto-style37">Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total</td>
                <td class="auto-style37"></td>
                <td class="auto-style38">Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total</td>
                <td class="auto-style37"></td>
                 <td class="auto-style37">Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total</td>
            </tr>
            <tr>
                <td class="auto-style74">Tickets 
                    <br />
                    Empezados:</td>
             
            <td class="auto-style29">

                    <asp:TextBox ID="TickEmpC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TickEmpT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style30">
                    Comedor: </td>
                <td class="auto-style29">

                    <asp:TextBox ID="ComedorC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="ComedorT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style40">Efectivo: </td>
                <td class="auto-style30">

                    <asp:TextBox ID="EfectivoC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="EfectivoT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style75">Tickets 
                    <br />
                    Pagados: </td>
                <td class="auto-style11">

                    <asp:TextBox ID="TickPagC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TickPagT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style31">Llevar: </td>
                <td class="auto-style71">

                    <asp:TextBox ID="LlevarC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="LlevarT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style33">Vales: </td>
                <td>

                    <asp:TextBox ID="ValesC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="ValesT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style76">Voids: 
                    <br />
                 </td>
                <td>

                    <asp:TextBox ID="VoidsC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="VoidsT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>     
               <td>Auto: </td>
                 <td class="auto-style71">

                    <asp:TextBox ID="AutoC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="AutoT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>
                 <td class="auto-style33">City:&nbsp;&nbsp; </td>
                 <td>

                    <asp:TextBox ID="CityC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="CityT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="auto-style74">Mgr Voids: 
                    <br />
                </td>
             
            <td class="auto-style29">

                    <asp:TextBox ID="MgrVoidsC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="MgrVoidsT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style71"></td>
                <td class="auto-style30">Tarj Credito: </td>
                <td class="auto-style30">

                    <asp:TextBox ID="VisaC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="VisaT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style75">Correcciones: 
                    <br />
                </td>
                <td class="auto-style11">

                    <asp:TextBox ID="CorrecionC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="CorreccionT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style31"></td>
                <td class="auto-style71"></td>
                <td class="auto-style31">Tarj Debito: </td>
                <td class="auto-style31">

                    <asp:TextBox ID="DebC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="DebT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style77">
                    <br />
                </td>
                <td class="auto-style78"></td>
                <td class="auto-style78"></td><td class="auto-style79"></td>
                <td class="auto-style78">American Exp: </td>
                <td class="auto-style78">

                    <asp:TextBox ID="AmericanC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="AmericanT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style76">
                    <br />
                </td>
                <td></td>
                <td></td><td class="auto-style71"></td>
                <td>Uber eats: </td>
                <td>

                    <asp:TextBox ID="UberC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="UberT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>
            </table>
        
        <hr />
        <table>
            <tr>
                <td class="auto-style45"></td>
                <td class="auto-style58">DESCUENTOS</td>
                <td class="auto-style64"></td>
                <td class="auto-style48">TIPO DE PRODUCTO </td>  
            </tr>
             <tr>
                <td class="auto-style42"></td>
                <td class="auto-style59">Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total</td>
                <td class="auto-style65"></td>
                <td class="auto-style49">Cantidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total</td>
            </tr>
            <tr>
                <td class="auto-style46">10%:</td>
             
            <td class="auto-style60">

                    <asp:TextBox ID="Desc10C" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc10T" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style66">
                    Hamburguesas: </td>
                <td class="auto-style50">

                    <asp:TextBox ID="HambC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="HambT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style44">15%:</td>
                <td class="auto-style61">

                    <asp:TextBox ID="Desc15C" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc15T" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
                <td class="auto-style67">Fritos: </td>
                <td class="auto-style51">

                    <asp:TextBox ID="FritosC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="FritosT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style54">20%:</td>
                <td class="auto-style63">

                    <asp:TextBox ID="Desc20C" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc20T" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>     
               <td class="auto-style55">Ensaladas: </td>
                 <td class="auto-style56">

                    <asp:TextBox ID="EnsalC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="EnsalT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>
            </tr>
                 <tr>
                <td class="auto-style57">25%:</td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc25C" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc25T" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">Postres: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="PostresC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="PostresT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style57">20% Farm. Ahorro: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc20FAC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc20FAT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">Combos: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="CombosC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="CombosT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style44">20% Emp: </td>
                <td class="auto-style61">

                    <asp:TextBox ID="Desc20EC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc20ET" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style67">Bebidas: </td>
                 <td class="auto-style52">

                    <asp:TextBox ID="BebidasC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="BebidasT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style57">50% Emp: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc50EC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc50ET" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">Condimentos: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="CondC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="CondT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style54">50% Socios: </td>
                <td class="auto-style63">

                    <asp:TextBox ID="Desc50SoC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc50SoT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style55">Promociones: </td>
                 <td class="auto-style56">

                    <asp:TextBox ID="PromoC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="PromoT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style57">60% Emp.: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc60Emp" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc60ET" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">CB Kid: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="CBKidC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="CBKidT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style57">90% Emp.: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc90Emp" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc90ET" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">Fiestas: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="FiestaC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="FiestaT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>
            </tr>
                 <tr>
                <td class="auto-style57">99% Cumple: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc100C" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc100CT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>     
               <td class="auto-style68">Sobrantes: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="SobranteC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="SobranteT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                     </td>

            </tr>
             <tr>
                <td class="auto-style57">99% Socios: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc100SC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc100ST" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>     
               <td class="auto-style68">Anticipos Fiesta: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="AntC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

                    <asp:TextBox ID="AntT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>

            </tr>
             <tr>
                <td class="auto-style57">99% Cort: </td>
                <td class="auto-style19">

                    <asp:TextBox ID="Desc100CoC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="Desc100CoT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>     
               <td class="auto-style68">Waste: </td>
                 <td class="auto-style51">

                    <asp:TextBox ID="WasteC" runat="server" CssClass="txtCaptura" MaxLength="40" Width="32px" >0</asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="WasteT" runat="server" CssClass="txtCaptura" MaxLength="40" Width="66px" >0</asp:TextBox>
                 </td>

            </tr>
            </table>
    </div> <!-- registroDatos -->
</div>
</asp:Content>

