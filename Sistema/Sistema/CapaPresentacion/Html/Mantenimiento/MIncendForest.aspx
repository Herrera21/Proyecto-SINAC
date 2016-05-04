<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MIncendForest.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.MIncendForest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <script>
        function idBoton() {
            return "<%=Button1.ClientID%>";
        }
    </script>
   <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje1" runat="server" href="CIncendForest.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Mantenimientos</li>
                <li class="active"><a href="CIncendForest.aspx"> Incendios Forestales </a> </li>
                <li class="active">Registrar </li>
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Modificar incendio forestal</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                        <!--alert-->
                        <div id="alert" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                                <div class="modal-header">
                                  <h3>Alerta</h3>
                                </div>
                                <div class="modal-body">
                                   <label id="labelAlert" runat="server"></label>		        
                                </div>
                                <div class="modal-footer">
                                  <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" class="btn" OnClick="ButtonAcepta"/>
                                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" class="btn" OnClick="ButtonCancela"/>
                                </div>
                        </div>
                          <!--formulario-->
                          <div class="form-group has-feedback has-success" id="divLugInce">
                            <label class="control-label">Lugar del incendio</label>
                            <input type="text" class="form-control" id="lugInce" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divLugInce','span1LugInce');"
                                placeholder="Ingrese el lugar del incendio" maxlength="50"/>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="lugInce" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="lugInce" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1LugInce"></span>
                          </div>
                          <div class="form-group has-feedback has-success" id="divFechaPart">
                            <label class="control-label">Fecha de participación</label>
                            <input type="text" class="form-control date" id="fechaPart" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divFechaPart','span1FechaPart');" placeholder="Ingrese la fecha de participación" maxlength="10"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fechaPart" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechaPart" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1FechaPart"></span>
                          </div>

                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" Enabled="true" OnClick="Button1_Click" OnClientClick="area()" ValidationGroup="enviar"/>
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="area()" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
