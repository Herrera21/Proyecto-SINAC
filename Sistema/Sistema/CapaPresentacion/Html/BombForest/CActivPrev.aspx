﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="CActivPrev.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.CActivPrev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
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
                    <li class="active">Actividades de Prevención </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">


                <form id="form1" runat="server">
                    <!-- menu-->
                    <ul class="nav nav-tabs">
                        <li><a href="InfPersDetallado.aspx">Información Personal</a></li>
                        <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
                        <li><a href="Carne.aspx">Información del carné</a></li>
                        <li><a href="CCapacit.aspx">Capacitaciones</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li class="active"><a href="CActivPrev.aspx">Actividades de Prevención</a></li>
                                <li><a href="CIncendForest.aspx">Participación en incencios forestales</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CPoliza.aspx">Pólizas</a></li>
                                <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
                                <li><a href="ReseniaMedica.aspx">Reseña médica</a></li>
                            </ul>
                        </li>
                        <li><a href="CBomberos.aspx">Salir</a></li>
                    </ul>

                    <%--formulario--%>

                    <h1 class="text-center login-title">Actividades de prevención del bombero</h1>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"  
                        AllowPaging="True" CssClass="mGrid table-responsive" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"  
                        PageSize="7" onrowcommand="gvPerson_RowCommand" DataKeyNames="PK_Id_ActividadPrevencion,nombre,fecha,lugar,cantHorasPart,observaciones" CellPadding="4" ForeColor="#333333" >
        <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="/Imagenes/editar.gif" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha de la actividad">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Lugar donde se realizó la actividad">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("lugar") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Horas participadas">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("cantHorasPart") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Observaciones">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("observaciones") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                         <EditRowStyle BackColor="#999999" />
                         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

        <PagerStyle CssClass="pgr" BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#E9E7E2" />
                         <SortedAscendingHeaderStyle BackColor="#506C8C" />
                         <SortedDescendingCellStyle BackColor="#FFFDF8" />
                         <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                </form>
            </div>
        </div>
</asp:Content>
