<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="REquipoProtPerso.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.REquipoProtPerso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje1" runat="server" href="CEquipoProtPerso.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

         <!-- Miga -->
            <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                    <li><a href="../CAreaConserv.aspx">Áreas de conservación </a></li>
                    <li><a href="../CBrigadas.aspx">Brigada </a></li>
                    <li><a href="../CBomberos.aspx">Bomberos </a></li>
                    <li class="active">Información detallada </li>
                    <li><a href="../CEquipoProtPerso.aspx">Equipo de protección personal </a></li>
                    <li class="active">Registrar </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar equipo de protección personal</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                          <div class="form-group" id="divNombre">
                            <label>Equipo</label>
                            <input type="text" class="form-control" id="nombre" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');"
                                placeholder="Ingresar el nombre"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                          </div>
                          <div class="form-group" id="divCantEntre">
                            <label>Cantidad entregada</label>
                            <input type="text" class="form-control" id="cantEntre" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divCantEntre','span1CantEntre');"
                                   placeholder="Ingresar la cantidad entregada" maxlength="3"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="cantEntre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="cantEntre" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1CantEntre"></span>
                          </div>
                          <div class="form-group" id="divFechaEntreg">
                            <label>Fecha de Entrega</label>
                            <input type="text" class="form-control date fechaEntre" id="fechEntreg" runat="server"  onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divFechaEntreg','span1FechaEntreg');"
                                   placeholder="Ingresar la fecha de entrega" readonly/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fechEntreg" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechEntreg" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1FechaEntreg"></span>
                          </div>
                          <div class="form-group" id="divEstado">
                            <label>Estado</label>
                            <asp:DropDownList ID="estado" class="form-control" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorTipo','divEstado','span1Estado');">
                                <asp:listitem value ="0"> Seleccionar </asp:listitem>
                                <asp:listitem value ="Bueno"> Bueno </asp:listitem>
                                <asp:listitem value ="Malo"> Malo </asp:listitem>
                                <asp:listitem value ="Regular"> Regular </asp:listitem>
                            </asp:DropDownList>
                               <asp:RequiredFieldValidator id="RequiredFieldValidatorTipo" ControlToValidate="estado" ErrorMessage="Seleccione un tipo de estado" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Estado"></span>
                          </div>
                          <div class="form-group">
                                <label class="control-label" >Observaciones</label>
                                <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                            </div>
                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" ValidationGroup="enviar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    <script>
        Configurafecha("+0m +0d +0y", ".fechaEntre", "-65:+0");
    </script>
</asp:Content>
