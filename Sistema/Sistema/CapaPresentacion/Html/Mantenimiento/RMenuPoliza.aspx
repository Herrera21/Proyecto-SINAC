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
                            <input type="text" id="nombre" runat="server" onblur="textVal(this,'divNombre','span1Nombre','span2Nombre');" class="form-control" placeholder="Ingrese el nombre de la póliza" maxlength="20" required/>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                            <span class="help-block" id="span2Nombre"></span>
                          </div>


                          <div class="form-group" id="divLBrigada">
                            <label class="control-label" >Número de póliza</label>
                            <input type="text" id="numero" runat="server" onblur="" class="form-control" placeholder="Ingrese el número de póliza" maxlength="20" required/>
                            <span class="" aria-hidden="true" id="span1LBrigada"></span>
                            <span class="help-block" id="span2LBrigada"></span>
                          </div>

                            <div class="form-group">
                            <label>Periodo de inicio</label>
                            <input type="text" class="form-control date" id="periodoInicio" runat="server" 
                                    placeholder="Ingrese la fecha de inicio de póliza" maxlength="10"/>
                            </div>

                            <div class="form-group">
                            <label>Vencimiento de la póliza</label>
                            <input type="text" class="form-control date" id="periodoFin" runat="server" 
                                    placeholder="Ingrese la fecha de vencimiento" maxlength="10"/>
                            </div>

                            <div class="form-group">
                                <label class="control-label" >Observaciones</label>
                                <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                            </div>
                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
