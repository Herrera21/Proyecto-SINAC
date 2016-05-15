<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="ReseniaMedica.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.ReseniaMedica" %>
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
              <a id="botonMensaje1" runat="server" href="../MenuPrincipal.aspx" class="btn">Cerrar</a>
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
                    <li class="active">Información detallada </li>
                    <li class="active">Reseña médica </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">


                <form id="form1" runat="server">
                    <!-- menu-->
                    <ul class="nav nav-tabs">
                        <%--<li><a href="RBomInfoPerson.aspx">Información Personal</a></li>--%>
                        <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
                        <%--<li><a href="RCarne.aspx">Información del carné</a></li>--%>
                        <%--<li><a href="RCapacitación.aspx">Capacitaciones</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="RActivPrevenc.aspx">Actividades de Prevención</a></li>
                                <li><a href="RIncendForest.aspx">Participación en incencios forestales</a></li>
                            </ul>
                        </li>--%>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="RBomPoliza.aspx">Pólizas</li>
                                <li><a href="RBomBenef.aspx">Beneficiarios</a></li>
                                <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
                                <li class="active"><a href="ReseniaMedica.aspx">Reseña médica</a></li>
                            </ul>
                        </li>
                        <li><a href="../MenuPrincipal.aspx">Salir</a></li>
                    </ul>

                    <%--formulario--%>

                    <h1 class="text-center login-title">Reseña médica</h1>

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
                            <asp:CheckBox text=" Internado" ID="internado" runat="server"/>
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
                    <td><asp:TextBox ID="lentContText" runat="server" CssClass="form-control"></asp:TextBox></td>
                  </tr>
                    <tr style="height:60px">
                    <td> <div class="checkbox">
                     <asp:CheckBox text="Operado" ID="operado" runat="server" />
                     </div>  </td>
                    <td><asp:TextBox ID="operadoText" runat="server" CssClass="form-control"></asp:TextBox></td>
                  </tr>
                    <tr style="height:60px">
                    <td> <div class="checkbox">
                    <asp:CheckBox text="Cuenta con limitación física" ID="limitFisic" runat="server" />
                    </div>  </td>
                    <td><asp:TextBox ID="limitacionFisica" runat="server" CssClass="form-control"></asp:TextBox></td>
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

              <div class="form-group form-signin" id="divTipoSangre">
                <label class="control-label">Tipo de sangre</label>
                    <asp:DropDownList ID="TipoSangre" class="form-control" runat="server">
                        <asp:listitem value ="0"> Seleccionar </asp:listitem>
                        <asp:listitem value ="A+"> A+ </asp:listitem>
                        <asp:listitem value ="A-"> A- </asp:listitem>
                        <asp:listitem value ="B+"> B+ </asp:listitem>
                        <asp:listitem value ="B-"> B- </asp:listitem>
                        <asp:listitem value ="AB+"> AB+ </asp:listitem>
                        <asp:listitem value ="AB-"> AB- </asp:listitem>
                        <asp:listitem value ="O+"> O+ </asp:listitem>
                        <asp:listitem value ="O-"> O- </asp:listitem>
                    </asp:DropDownList>

                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" class="btn btn-lg btn-primary btn-block" />
                 </div>
                </form>
            </div>
        </div>
</asp:Content>
