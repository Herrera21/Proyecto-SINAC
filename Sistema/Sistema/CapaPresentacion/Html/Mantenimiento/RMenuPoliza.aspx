<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RMenuPoliza.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.RMenuPoliza" %>
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
              <a id="botonMensaje1" runat="server" href="CMenuPoliza.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Mantenimientos</li>
                <li class="active"><a href="CMenuPoliza.aspx"> Pólizas </a> </li>
                <li class="active">Registrar </li>
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar Póliza</h1><hr />
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server" method="post">
                            
                          <div class="form-group" id="divNombre">
                            <label class="control-label" >Nombre de la póliza</label>
                            <input type="text" id="nombre" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" class="form-control" placeholder="Ingrese el nombre de la póliza" maxlength="20"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                          </div>


                          <div class="form-group" id="divNumero">
                            <label class="control-label" >Número de póliza</label>
                            <input type="text" id="numero" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divNumero','span1Numero');" class="form-control" placeholder="Ingrese el número de póliza" maxlength="20"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="numero" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="numero" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Numero"></span>
                          </div>

                            <div class="form-group" id="divPeriodoInicio">
                            <label>Periodo de inicio</label>
                            <input type="text" class="form-control date fechaIni" id="periodoInicio" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divPeriodoInicio','span1PeriodoInicio');"
                                    placeholder="Ingrese la fecha de inicio de póliza" maxlength="10" readonly/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="periodoInicio" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Formato inválido" ControlToValidate="periodoInicio" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1PeriodoInicio"></span>
                            </div>

                            <div class="form-group" id="divPeriodoFin">
                            <label>Vencimiento de la póliza</label>
                            <input type="text" class="form-control date fechaVec" id="periodoFin" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divPeriodoFin','span1PeriodoFin');"
                                    placeholder="Ingrese la fecha de vencimiento" maxlength="10" readonly/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="periodoFin" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Formato inválido" ControlToValidate="periodoFin" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1PeriodoFin"></span>
                            </div>

                            <div class="form-group">
                                <label class="control-label" >Observaciones</label>
                                <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                            </div>
                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" ValidationGroup="enviar"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    <script>
        Configurafecha("+0m +0d +0y", ".fechaIni", "-65:+0");
        Configurafecha("+0m +0d +20y", ".fechaVec", "+0:+20");
    </script>
</asp:Content>
