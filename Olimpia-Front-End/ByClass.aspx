<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ByClass.aspx.cs" Inherits="Olimpia_Front_End.MachinesFilters.ByClass" %>

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
                                <asp:Button runat="server" CssClass="dropdown-item" Text="Logout" ID="btnLogoutUsers" OnClick="btnLogoutUsers_Click" BackColor="Transparent" /></li>
                        </ul>
                    </div>
            </div>
        </div>
    </nav>
    <!-- Final NAV -->



    <div class="container">
        <h1 class="title-pages">Filtro por Sala</h1>
        <hr style="border-color: #cfcecf; margin-bottom: 10px" />
        <br />
        <label>Escolha uma máquina para mostrar mais informações:</label><br />
        <asp:TextBox class="txt-pages" ID="txtGetidMachines" placeholder="Apenas números" runat="server" />
        <asp:Button runat="server" type="button" Text="Mostrar Informações" CssClass="btn-pages-show" ID="Button1" OnClick="btnIdMachines_Click"></asp:Button>
        <asp:Button runat="server" type="button" Text="Voltar à Máquinas" CssClass="btn-pages-s" ID="btnVoltar" OnClick="btnVoltar_Click"></asp:Button>




        <br />
        <br />
        <hr style="border-color: #cfcecf; margin-bottom: 10px" />
        <br />

        <label>Escolha a Sala para filtrar:</label>
        <asp:DropDownList ID="ddlFiltroSala" runat="server">
            <asp:ListItem Text="" />
        </asp:DropDownList>
        <asp:Button runat="server" CssClass="btn-pages" Text="Selecionar" ID="btnFiltroSala" OnClick="btnFiltroSala_Click" />

        <br />
        <br />

        <div id="table_div"></div>
        <div id="box1">
            <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
        </div>
    </div>

    </form>
</body>
</html>
