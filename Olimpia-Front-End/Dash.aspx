<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dash.aspx.cs" Inherits="Olimpia_Front_End.Dash" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Athena | Dashboard</title>
    <link rel="shortcut icon" href="img/athenablack.png" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Link CSS utilizado-->
    <link rel="stylesheet" href="css/pages.css">

    <!--Link do bootstrap-->
    <link rel="stylesheet" href="css/bootstrap.css">

    <!--Link do Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <!--Efeito JavaScript para trocar Boxes-->
    <script src="js/HideShowSections.js"></script>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="js/linechart.js"></script>
    <script src="js/piechart.js"></script>
    <script src="js/donutchart.js"></script>


</head>

<body style="background-color: ghostwhite">
    <form runat="server">

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
                        <li class="nav-link"><a style="padding-top: 1.2rem; margin-left: 1rem" href="index.html">HOME</a></li>
                        <li class="nav-link"><a style="padding-top: 1.2rem" href="QuemSomos.aspx">Quem Somos</a></li>
                        <li class="nav-link"><a style="padding-top: 1.2rem" href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Contate-nos</a></li>
                    </ul>


                    <div class="btn-group navbar-right">

                        <button type="button" class="dropdown btn-new btn dropdown-toggle" data-toggle="dropdown" style="margin-top: 1rem; background-color: #cb8933; color: white">
                            <% string usuario = (string)Session["UserName"];
                                Response.Write($"Bem-vindo(a): {usuario} "); %><span class="caret"></span></button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">

                            <center>
                            <li>
                                <asp:Button runat="server" CssClass="dropdown-item btn-logout" Text="Logout" ID="Button1" OnClick="btnLogoutUsers_Click" BackColor="Transparent" style="border: none" /></li>
                            </center>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
        <br />
        <!-- Final NAV -->


        <div class="container-fluid">
            <div class="row">
                <nav class="col-md-2 d-none d-md-block sidebar">
                    <div class="sidebar-sticky" style="top: 0">
                        <ul class="nav flex-column">

                            <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                <span>Outras informações</span>
                                <a class="d-flex align-items-center text-muted" href="#"></a>
                            </h6>
                           
                            <li class="nav-item">
                                <a class="nav-link-side" href="Maquinas.aspx" style="color: black">Suas Máquinas
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link-side" href="Salas.aspx" style="color: black">Suas Salas
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link-side" href="Usuarios.aspx" style="color: black">Usuários cadastrados
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>

                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
                    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                        <h1 class="title-pages">Dashboard</h1>
                        <br />
                        <div class="table-responsive">
                            <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
                        </div>
                        <div class="btn-toolbar mb-2 mb-md-0">

<%--                            <asp:Button CssClass="btn-pages-show" runat="server" ID="btnInfos" text="Informações Avançadas" OnClick="btnInfos_Click" />--%>
                            <%--<button class="btn btn-sm btn-outline-secondary dropdown-toggle">
                                Informações Avançadas
                            </button>--%>
                        </div>
                    </div>
                    <br />
                    <hr style="border-color: #cfcecf; margin-bottom: 10px" />
                    <div class="container-fluid">
                        <div class="box7">
                            <center><h2>Uso CPU</h2></center>
                            <div id="chart_div" class="linechart" style="border: solid 1px #cfcfcf; border-radius: 10px"></div>
                        </div>
                    </div>
                    <br />
                    <div class="container-fluid">
                        <div id="piechart_RAM" style="width: 45rem; float: left; height: 45rem; margin-right: 2rem; margin-top: 1rem; border: solid 1px #cfcfcf; border-radius: 10px"></div>

                        <div id="donutchart" style="width: 45rem; float: right; height: 45rem; margin-top: 1rem; border: solid 1px #cfcfcf; border-radius: 10px"></div>
                    </div>
                </main>
            </div>
        </div>
        <br />
        <br />
        <br />

    </form>
</body>
</html>
