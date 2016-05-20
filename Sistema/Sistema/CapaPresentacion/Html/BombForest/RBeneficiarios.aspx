<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RBeneficiarios.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RBeneficiarios" %>
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
              <a id="botonMensaje1" runat="server" href="CBeneficiarios.aspx" class="btn">Cerrar</a>
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
                    <li><a href="../BombForest/CBomberos.aspx">Bomberos </a></li>
                    <li>Información detallada </li>
                    <li><a href="CPoliza.aspx">Pólizas</a></li>
                    <li class="active">Beneficiarios </li> 
                    <li class="active">Registrar </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar contacto de emergencia</h1>
                    <div class="account-wall">
                        <form id="form2" class="form-signin" runat="server">
                          <div class="form-group">
                            <label>Nombre</label>
                            <input type="text" class="form-control" id="nombre" runat="server"
                                placeholder="Ingrese el nombre" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Primer apellido</label>
                            <input type="text" class="form-control" id="p_Ape" runat="server"
                                   placeholder="Ingrese el primer apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Segundo apellido</label>
                            <input type="text" class="form-control" id="s_Ape" runat="server"
                                   placeholder="Ingrese el segundo apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Cédula</label>
                            <input type="text" class="form-control" id="cedula" runat="server" 
                                   placeholder="Ingrese la cédula"/>
                          </div>
                          <div class="form-group">
                            <label>Parentesco</label>
                            <input type="text" class="form-control" id="parent" runat="server" 
                                   placeholder="Ingrese el parentesco"/>
                          </div>
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Guardar" ValidationGroup="enviar" OnClick="Button1_Click"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
