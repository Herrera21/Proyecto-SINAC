<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="CBomberos.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.CBomberos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!--contenido-->               
     <div class="container">
             <!-- Miga -->
            <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                    <li><a href="../CAreaConserv.aspx">Áreas de conservación </a></li>
                    <li><a href="../CBrigadas.aspx">Brigada </a></li>
                     <li>Bomberos</li>
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
                    <!--buscar-->
                    <div id="buscar" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                        <div class="modal-header">
                        <a class="close" href="../MenuPrincipal.aspx">×</a>
                            <h3>Buscar</h3>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>Área de Conservación</label>
                                <%--<asp:DropDownList ID="Area" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Area_SelectedIndexChanged">--%>
                                <asp:DropDownList ID="Area" class="form-control" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Brigada</label>
                                <asp:DropDownList ID="Brigadas" class="form-control" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="botonCargar" runat="server" Text="Cargar" class="btn btn-primary " OnClick="ButtonCargar"/>
                        </div>
                     </div>

                    <!--filtro-->
                        <div id="filtro" class="modal" style="display: none; ">
                                <div class="modal-header">
                                  <a class="close" data-dismiss="modal">×</a>
                                  <h3>Filtrar</h3>
                                </div>

                                <div class="modal-header">
                                    <asp:DropDownList ID="columna" class="form-control" runat="server">
                                        <asp:listitem value ="PK_Id_BomberoForestal"> Cédula </asp:listitem>
                                        <asp:listitem value ="nombre"> Nombre </asp:listitem>
                                        <asp:listitem value ="apellido1"> Primer Apellido </asp:listitem>
                                        <asp:listitem value ="apellido2"> Segundo Apellido </asp:listitem>
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
                            <asp:ImageButton ID="buttonAgregar" data-toggle="tooltip" title="Crear un Bombero"  runat="server"  ImageUrl="~/Imagenes/Icono_Agregar.png" CssClass="Imagen_boton" Text="Crear un bombero"  OnClick="buttonAgregar_Click" />
                        </div>

                       <div class="col-md-2">
                            <asp:ImageButton ID="buttonModificar" data-toggle="tooltip" title="Modificar un Bombero" runat="server" ImageUrl="~/Imagenes/Icono_Editar.png" CssClass="Imagen_boton" Text="Modificar un bombero" OnClick="buttonModificar_Click"/>
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonConsultar" data-toggle="tooltip" title="Consultar información" ImageUrl="~/Imagenes/Icono_Consultar.jpg" CssClass="Imagen_boton" Text="Consultar bombero" runat="server" OnClick="buttonConsultar_Click"/>
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="buttonFiltrar"  data-toggle="tooltip" title="Filtrar Bomberos" runat="server" ImageUrl="~/Imagenes/Icono_Buscar.png" CssClass="Imagen_boton" Text="Buscar bombero" OnClick="buttonFiltrar_Click"/>
                        </div>

                        <div class="col-md-2">
                            <asp:ImageButton ID="Imprimir" data-toggle="tooltip" title="Imprimir lista de Bomberos" runat="server" ImageUrl="~/Imagenes/Icono_Imprimir.png" CssClass="Imagen_boton" Text="Imprimir bombero" OnClick="buttonImprimir_Click" />
                        </div>
                    </div>

                    <hr />

                    <h1 class="text-center login-title" id="titulo" runat="server"></h1>

                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"  
                        AllowPaging="True" CssClass="mGrid table-responsive" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"  
                        PageSize="7" onrowcommand="gvPerson_RowCommand" DataKeyNames="PK_Id_BomberoForestal, nombre, apellido1, apellido2" CellPadding="4" ForeColor="#333333" >
        <AlternatingRowStyle CssClass="alt" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="/Imagenes/editar.gif" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="C&#233dula">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("PK_Id_BomberoForestal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Primer Apellido">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("apellido1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Segundo Apellido">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("apellido2") %>'></asp:Label>
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
