<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RReseniaMedica.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RReseniaMedica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li><a href="REquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li><a href="RCarne.aspx">Información del carné</a></li>
      <li class="dropdown active">
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
                <li class="active">Registrar reseña médica </li>                
            </ol>
        </div>
       
            <div class="row" style="background-color:white; width:99.7%">
             <div class="col-sm-6 col-md-4 col-md-offset-4">
                 <!--    <div class="col-md-"> -->
                
              <div class=" col-xs-6 col-xs-6"></div> 
                    <h1 class="text-center login-title">Registrar reseña médica</h1> </div>
                   <div class="account-wall">
                       
         <form id="form1" runat="server">

   <table style="width:80%; margin:0 auto">
   <thead>
    <tr >
        <th style="text-align:center">Reseña Médica</th>
        <th style="text-align:center">Descripción</th>
      </tr>
    </thead>
    <tbody >
        <tr style="height:60px">
            <td style="align-content:center">
                <div class="checkbox">
                <asp:CheckBox text=" Internado" ID="internado" runat="server" Checked="true"/>
                </div>
            </td>
            <td style="width:65%; border:1px" ><asp:TextBox ID="inter" runat="server" CssClass="form-control"></asp:TextBox> </td>
        </tr>
      <tr style="height:60px">
        <td><div class="checkbox">
        <asp:CheckBox text="Tiene tratamiento médico" ID="tratMedic" runat="server" />
        </div></td>
        <td>  <asp:TextBox ID="tratamiento" runat="server" CssClass="form-control"></asp:TextBox></td>
      </tr>
      <tr style="height:60px">
        <td><div class="checkbox">
         <asp:CheckBox text="Usa lentes de contacto" ID="lentesContacto" runat="server" />
         </div>  </td>
        <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></td>
      </tr>
        <tr style="height:60px">
        <td> <div class="checkbox">
         <asp:CheckBox text="Operado" ID="operado" runat="server" />
         </div>  </td>
        <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox></td>
      </tr>
        <tr style="height:60px">
        <td> <div class="checkbox">
        <asp:CheckBox text="Cuenta con limitación física" ID="limitfisic" runat="server" />
        </div>  </td>
        <td><asp:TextBox ID="limitacionFisica" runat="server" CssClass="form-control"></asp:TextBox></td>
      </tr>
        <tr style="height:60px">
        <td><div class="checkbox">
        <asp:CheckBox text="Limitación física" ID="CheckBox1" runat="server" />
        </div></td>
        <td>  <asp:TextBox ID="limitacion" runat="server" CssClass="form-control"></asp:TextBox></td>
      </tr>
        <tr style="height:60px">
        <td> <div class="checkbox">
         <asp:CheckBox text="Chequeado recientemente por médico" ID="checkMedic" runat="server" />
         </div></td>
        <td>
            <asp:TextBox ID="Chequeado" runat="server" CssClass="form-control"></asp:TextBox>
        </td>
      </tr>



    </tbody>
  </table>



                          <div class="form-group form-signin">
                              <label>Tipo de sangre</label>
                              <select class="form-control" id="nacionalidad">
	                            <option selected="selected">Seleccionar</option>
	                           
                                <option>A+</option>
                                <option>A-</option>
                                <option>B+</option>
                                <option>B-</option>
                                <option>AB+</option>
                                <option>AB-</option>
                                <option>O+</option>
                                <option>O-</option>
                               
                              </select>
                         <br />
                         <br />
                          <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" class="btn btn-lg btn-primary btn-block" />
                               </div>
                        </form>
                    </div>
                </div>
</div>

</asp:Content>
