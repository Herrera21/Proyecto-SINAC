<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="CCapacitación.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.CCapacitación" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!--contenido-->               
     <div class="container">
         <!-- menu-->
        <ul class="nav nav-tabs">
            <li class="dropdown"><a href="CMenuPoliza.aspx">Pólizas</a></li>
            <li class="dropdown"><a href="CCapacitación.aspx">Capacitaciones</a></li>
            <li class="dropdown active"><a href="CActivPrevenc.aspx">Actividades de prevención</a></li>
            <li class="dropdown"><a href="CIncendForest.aspx">Evento de incendio forestal</a></li>
            <li class="dropdown"><a href="../MenuPrincipal.aspx">Salir</a></li>
        </ul>

             <!-- Miga -->
            <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                    <li class="active">Mantenimiento </li>
                    <li class="active">Actividades de prevención</li>
                    <li class="active">Consultas </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">

                <!-- Script que muestra un mensaje al pasar el mouse sobre los iconos-->
            <script>
                $(document).ready(function(){
                    $('[data-toggle="tooltip"]').tooltip();
                });
            </script>


                <form id="form1" runat="server">
                    <!--filtro-->
                        <div id="filtro" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                                <div class="modal-header">
                                  <h3>Filtrar</h3>
                                </div>

                                <div class="modal-header">
                                    <asp:DropDownList ID="columna" class="form-control" runat="server">
                                        <asp:listitem value ="nombre_Capacitacion"> Nombre </asp:listitem>
                                        <asp:listitem value ="lugar_Capacitacion"> Lugar de capacitación </asp:listitem>
                                        <asp:listitem value ="institucion"> Institución </asp:listitem>
                                        <asp:listitem value ="cantHoras"> Cantidad de horas </asp:listitem>
                                        <asp:listitem value ="fechaEmision"> Fecha de la emisión </asp:listitem>
                                        <asp:listitem value ="fechaCaducidad"> Fecha de caducidad </asp:listitem>
                                    </asp:DropDownList>
                                </div>

                                <div class="modal-header">
                                    <asp:DropDownList ID="operador" class="form-control" runat="server">
                                        <asp:listitem value ="="> = </asp:listitem>
                                    </asp:DropDownList>
                                </div>

                                <div class="modal-header">
                                    <input type="text" id="valor" runat="server" class="form-control"/>
                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="ButtonMuestra" runat="server" Text="Mostrar elementos inactivos" class="btn btn-primary" OnClick="buttonMuestraInactivos"/>
                                    <asp:Button ID="botonFiltrar" runat="server" Text="Filtrar" class="btn btn-primary" OnClick="buttonFiltrarModal"/>
                                </div>
                        </div>


                    <%--botones menu--%>



                    <div class="row" style="padding-left:20%;">
                        <div class="col-md-2" >
                            <asp:ImageButton ID="buttonAgregar" data-toggle="tooltip" title="Crear una Capacitación"  runat="server"  ImageUrl="~/Imagenes/Icono_Agregar.png" CssClass="Imagen_boton" Text="Crear"  OnClick="buttonAgregar_Click" />
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonModificar" data-toggle="tooltip" title="Modificar una Capacitación" runat="server" ImageUrl="~/Imagenes/Icono_Editar.png" CssClass="Imagen_boton" Text="Modificar" OnClick="buttonModificar_Click" />
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonConsultar" data-toggle="tooltip" title="Asignar a Bomberos" ImageUrl="~/Imagenes/Icono_Consultar.jpg" CssClass="Imagen_boton" Text="Consultar" runat="server" OnClick="buttonConsultar_Click" />
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonFiltrar"  data-toggle="tooltip" title="Filtrar una Capacitación" runat="server" ImageUrl="~/Imagenes/Icono_Buscar.png" CssClass="Imagen_boton" Text="Buscar" OnClick="buttonFiltrar_Click"  />
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonImprimir" data-toggle="tooltip" title="Imprimir las Capacitaciones" runat="server" ImageUrl="~/Imagenes/Icono_Imprimir.png" CssClass="Imagen_boton" Text="Imprimir" OnClick="buttonImprimir_Click" />
                        </div>
                    </div>

                    <hr />

                    <h1 class="text-center login-title">Actividades de prevención</h1>

                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"  
                        AllowPaging="True" CssClass="mGrid table-responsive" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"  
                        PageSize="7" onrowcommand="gvPerson_RowCommand" DataKeyNames="PK_Id_Capacitacion,nombre_Capacitacion,lugar_Capacitacion,institucion,cantHoras,fechaEmision,fechaCaducidad" CellPadding="4" ForeColor="#333333" >
        <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="/Imagenes/editar.gif" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre_Capacitacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lugar de capacitación">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("lugar_Capacitacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Institución">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("institucion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad de horas">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("cantHoras") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de la emisión">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("fechaEmision") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de caducidad">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("fechaCaducidad") %>'></asp:Label>
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
