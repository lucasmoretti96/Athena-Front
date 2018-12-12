<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maquinas.aspx.cs" Inherits="Olimpia_Front_End.Maquinas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Athena | Suas Máquinas</title>
    <link rel="shortcut icon" href="img/athenablack.png" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Link CSS utilizado-->
    <link rel="stylesheet" href="css/pages.css" />
    <!--Link do bootstrap-->
    <link rel="stylesheet" href="css/bootstrap.css">
    <!--Link do Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <!--Efeito JavaScript para trocar Boxes-->
    <script src="js/changeBox.js"></script>
</head>
<body style="background-color: ghostwhite">


    <!-- Início NAV -->
    <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="home.aspx">
                    <img style="float: left" class="navbar-brand" src="img/athenalogogold3.png" /></a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">

                <ul class="nav navbar-nav">
                    <li class="nav-link"><a style="padding-top: 1.2rem; margin-left: 1rem" href="index.html">Home</a></li>
                    <li class="nav-link"><a style="padding-top: 1.2rem" href="QuemSomos.aspx">Quem Somos</a></li>
                    <li class="nav-link"><a style="padding-top: 1.2rem" href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Contate-nos</a></li>
                </ul>


                <form runat="server">
                    <div class="btn-group navbar-right">

                        <button type="button" class="dropdown btn-new btn dropdown-toggle" data-toggle="dropdown">
                            <% string usuario = (string)Session["UserName"];
                                Response.Write($"Bem-vindo(a): {usuario} "); %><span class="caret"></span></button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
                            <li><a href="Salas.aspx">Suas Salas</a></li>
                            <li><a href="Maquinas.aspx">Suas Máquinas</a></li>
                            <li><a href="Usuarios.aspx">Seus Usuários</a></li>
                            <li>
                                <asp:Button runat="server" style="border:none; text-align:center; padding-left:2rem" Text="Logout" ID="btnLogoutUsers" OnClick="btnLogoutUsers_Click" BackColor="Transparent" /></li>
                        </ul>
                    </div>
            </div>
        </div>
    </nav>
    <br />
    <!-- Final NAV -->


    <div class="container">
        <h1 class="title-pages">Gerenciamento de Máquinas</h1>
        <hr style="border-color: #cfcecf; margin-bottom: 10px" />
        <br />
        <button type="button" class="btn-pages-p" id="btnNewMach" onclick="userView()">Cadastrar Máquina</button>
        <button type="button" class="btn-pages" id="btnNew" onclick="newUser(), feed">Filtrar</button>
        <button type="button" class="btn-pages" onclick="userEdit()">Editar</button>
        <button type="button" class="btn-pages" onclick="userDelete()">Excluir</button>
        <br />
        <br />
        <hr style="border-color: #cfcecf; margin-bottom: 10px" />
        <br />
        <label>Escolha uma máquina para mostrar mais informações:</label><br />
        <asp:TextBox class="txt-pages" ID="txtGetidMachines" placeholder="Apenas números" runat="server" />
        <asp:Button runat="server" type="button" Text="Mostrar Informações" CssClass="btn-pages-show" ID="btnIdMachines" OnClick="btnIdMachines_Click"></asp:Button>
        <br />
        <br />
        <div id="table_div"></div>
        <div id="box1">
            <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
        </div>


    </div>



    <!--input filtrar máquinas-->
    <div class="container" id="box2" style="display: none;">
        
            <div class="form-group">
                <label>Filtrar máquinas por:</label>
                <br />
                <asp:DropDownList CssClass="ddl-pages" ID="ddlFiltroMaquina" runat="server">
                    <asp:ListItem Text="Sala" Value="1" />
                    <asp:ListItem Text="Usuário" Value="2" />
                    <asp:ListItem Text="Uso de Mem. CPU acima de 70%" Value="3" />
                </asp:DropDownList>
            </div>

            <asp:Button Text="Visualizar" target="_blank" type="submit" CssClass="btn-pages-show" runat="server" ID="btnViewMachine" OnClick="btnViewMachine_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel2" onclick="cancelUser()">Cancelar</button>
       
    </div>

    <!--input de editar Sala da máquina-->

    <div class="container" id="box3" style="display: none;">
        
            <div class="form-group">
                <label>Código da Máquina que deseja editar a Sala </label>
                <div class="form-group">

                    <asp:DropDownList CssClass="ddl-pages" ID="ddlEditMachine" runat="server">
                        <asp:ListItem Text="" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label>Nova Sala:</label>
                <br />
                <asp:DropDownList CssClass="ddl-pages" ID="ddlSalaEdit" runat="server">
                    <asp:ListItem Text="" />
                </asp:DropDownList>
            </div>

            <asp:Button Text="Salvar" runat="server" CssClass="btn-pages-show" ID="btnEditMachine" OnClick="btnEditMachine_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel3" onclick="cancelEdit()">Cancelar</button>
        
    </div>



    <!--input de excluir máquina-->

    <div class="container" id="box4" style="display: none">
        
            <div class="form-group">
                <label>Escolha a Máquina que deseja EXCLUIR:</label>
                <div class="form-group">

                    <asp:DropDownList CssClass="ddl-pages" ID="ddlDelMachine" runat="server">
                        <asp:ListItem Text="" />
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Button Text="Excluir" runat="server" CssClass="btn-pages-show" ID="btnDeleteMachine" OnClick="btnDeleteMachine_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel4" onclick="cancelDelete()">Cancelar</button>
        
    </div>

    <!--input de cadastrar nova máquina-->

    <div class="container" id="box5" style="display: none">
        
            <div class="form-group">
                <label>Insira um <b>código <u>único</u></b> para a Máquina</label>
                <br />
                <asp:TextBox class="txt-pages" ID="txtidMachine" placeholder="Apenas números" runat="server" />
            </div>
            <label>Escolha em qual sala a máquina ficará:</label>
            <div class="form-group">
                <asp:DropDownList CssClass="ddl-pages" ID="ddlSala" runat="server">
                    <asp:ListItem Text="" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
            </div>

            <asp:Button Text="Cadastrar" runat="server" CssClass="btn-pages-show" ID="btnAddMachine" OnClick="btnAddMachine_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel5" onclick="cancelAddMachine()">Cancelar</button>
        
    </div>
    </form>      
</body>
</html>
