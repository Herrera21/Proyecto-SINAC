<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MMenuPoliza.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.MMenuPoliza1" %>
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
    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Mantenimientos</li>
                <li class="active"><a href="CMenuPoliza.aspx"> Pólizas </a> </li>
                <li class="active">Modificar </li>
            </ol>
        </div>

            <form id="form1" runat="server">
            <div class="row" style="background-color:white; width:99.7%">
                
                <!--formulario-->

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

                <div class="col-sm-6 col-md-4 col-md-offset-4">

                <h1 class="text-center login-title">Modificar Póliza</h1><hr />

                <div class="form-group has-feedback has-success" id="divNombre">
                        <label class="control-label">Nombre de la póliza</label>
                        <input type="text" id="nombre" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" class="form-control" placeholder="Ingrese el nombre de la póliza" maxlength="20" required />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                        <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Nombre"></span>
                    </div>


                    <div class="form-group has-feedback has-success" id="divNumero">
                        <label class="control-label">Número de póliza</label>
                        <input type="text" id="numero" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divNumero','span1Numero');" class="form-control" placeholder="Ingrese el número de póliza" maxlength="20" required />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="numero" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="numero" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                        <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Numero"></span>
                    </div>

                    <div class="form-group has-feedback has-success" id="divPeriodoInicio">
                        <label>Periodo de inicio</label>
                        <input type="text" class="form-control date fechaIni" id="periodoInicio" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divPeriodoInicio','span1PeriodoInicio');"
                            placeholder="Ingrese la fecha de inicio de póliza" maxlength="10" readonly/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="periodoInicio" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Formato inválido" ControlToValidate="periodoInicio" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                        <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1PeriodoInicio"></span>
                    </div>

                    <div class="form-group has-feedback has-success" id="divPeriodoFin">
                        <label>Vencimiento de la póliza</label>
                        <input type="text" class="form-control date fechaVec" id="periodoFin" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divPeriodoFin','span1PeriodoFin');"
                            placeholder="Ingrese la fecha de vencimiento" maxlength="10" readonly/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="periodoFin" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Formato inválido" ControlToValidate="periodoFin" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                        <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1PeriodoFin"></span>
                    </div>

                    <div class="form-group">
                        <label class="control-label">Observaciones</label>
                        <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                    </div>

                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" ValidationGroup="enviar"/>
                    <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" /><br /><br />
                </div>
                    
            </div>
        </form>
        </div>
    <script>
        Configurafecha("+0m +0d +0y", ".fechaIni", "-65:+0");
        Configurafecha("+0m +0d +20y", ".fechaVec", "+0:+20");
    </script>
</asp:Content>
