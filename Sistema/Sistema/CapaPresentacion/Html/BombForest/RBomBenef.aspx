<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RBomBenef.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RBomBenef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <section>
        prueba
    </section>

    <!-- menu-->
    <ul class="nav nav-tabs">
      <li class="active"><a href="REquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li><a href="RCarne.aspx">Información del carné</a></li>
      <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RContactosEmergencia.aspx">Contactos de Emergencia</a></li>
              <li><a href="RReseniaMedica.aspx">Reseña médica</a></li>
          </ul>
      </li>
        <li><a href="RBomBenef.aspx">Beneficiarios</a></li>
      <li><a href="../MenuPrincipal.aspx">Salir</a></li>
    </ul>

    <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje1" runat="server" href="MenuPrincipal.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Bomberos Forestales</li>
                <li class="active">Información médica</li>
                <li class="active">Registrar Beneficiario </li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">

                <div class="col-sm-4"> 
                    <h1 class="text-center login-title">Registrar Beneficiario</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server"> 
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
                                   placeholder="Ingrese el segundo apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Porcentaje</label>
                            <input type="text" class="form-control" id="porcent" runat="server" 
                                   placeholder="Ingrese el porcentaje"/>
                          </div>
                          <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar" OnClick="Button1_Click" />
                            
                          <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Limpiar" OnClick="Button1_Click" />

                        </form>
                    </div>
             </div> 
                <!-- aqui empieza la segunda columna -->
               
                  <div class="col-md-8">
                      <h1 class="text-center login-title"> Beneficiarios</h1>
                      <br />
                      <br />
                      <table class="table table-hover table-bordered">
                        <thead>
                            <tr>
                            <th style="height:50%">Nombre completo</th>
                            <th style="height:20%">Cédula</th>
                            <th style="height:20%">Parentesco</th>
                            <th style="height:10%">Porcentaje</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                            <td>John</td>
                            <td>11155003</td>
                            <td>hermano</td>
                            <td>50%</td>
                            </tr>
                            <tr>
                            <td>Mary</td>
                            <td>201610456</td>
                            <td>hermana</td>
                            <td>50%</td>
                            </tr>
                        </tbody>
                      </table>
                   </div>
            </div> <!-- aqui termina el formulario-->
    </div>
</asp:Content>
