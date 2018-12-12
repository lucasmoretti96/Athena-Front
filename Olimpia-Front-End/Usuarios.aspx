<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Olimpia_Front_End.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Athena | Usuários</title>
    <link rel="shortcut icon" href="img/athenablack.png" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!--Link CSS utilizado-->
    <link rel="stylesheet" href="css/pages.css" />
    <!--Link do bootstrap-->
    <link rel="stylesheet" href="css/bootstrap.css" />
    <!--Link do Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <!--Efeito JavaScript para trocar Boxes-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="tableUsers.js"></script>
    <script src="js/changebox.js"></script>

</head>
<body style="background-color: ghostwhite">
    <form runat="server">

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


                    <div class="btn-group navbar-right">

                        <button type="button" class="dropdown btn-new btn dropdown-toggle" data-toggle="dropdown">
                            <% string usuario = (string)Session["UserName"];
                                Response.Write($"Bem-vindo(a): {usuario} "); %><span class="caret"></span></button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
                            <li><a href="Salas.aspx">Suas Salas</a></li>
                            <li><a href="Maquinas.aspx">Suas Máquinas</a></li>
                            <li><a href="Usuarios.aspx">Seus Usuários</a></li>
                            <li>
                                <asp:Button runat="server" Style="border: none; text-align: center; padding-left: 2rem" Text="Logout" ID="btnLogoutUsers" OnClick="btnLogoutUsers_Click" BackColor="Transparent" /></li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
        <br />

        <div class="container">
            <h1 class="title-pages">Gerenciamento de Usuários</h1>
            <hr style="border-color: #cfcecf; margin-bottom: 10px" />
            <br />
            <button type="button" class="btn-pages-p" onclick="newUser()">Cadastrar Novo Usuário</button>
            <button type="button" class="btn-pages" onclick="userEdit()">Editar</button>
            <button type="button" class="btn-pages" onclick="userDelete()">Excluir</button>
            <br />
            <br />
            <hr style="border-color: #cfcecf" />
            <br />
            <div id="table_div"></div>
            <div id="box1">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />

            </div>



        </div>

        <!--input de cadastrar usuário-->
        <div class="container" id="box2" style="display: none;">

            <div class="form-group">
                <label>Nome do Usuário</label>
                <br />
                <asp:TextBox class="txt-pages" placeholder="Nome" ID="txtUserName" runat="server" />
            </div>
            <div class="form-group">
                <label>Email do Usuário</label>
                <br />
                <asp:TextBox type="email" class="txt-pages" placeholder="email@exemplo.com" ID="txtUserEmail" runat="server" />
            </div>
            <div class="form-group">
                <label>CPF</label>
                <br />
                <asp:TextBox class="txt-pages" placeholder="Ex: 999.999.999-99" ID="numUserCPF" runat="server" />
            </div>
            <div class="form-group">
                <label>Senha</label>
                <br />
                <asp:TextBox type="password" class="txt-pages" placeholder="Senha" ID="txtUserPwd" runat="server" />
            </div>

            <asp:Button Text="Cadastrar" type="submit" CssClass="btn-pages-show" runat="server" ID="btnCadastrarUser" OnClick="btnCadastrarUser_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel" onclick="cancelUser()">Cancelar</button>


        </div>

        <!--input de editar usuário-->

        <div class="container" id="box3" style="display: none;">

            <div class="form-group">
                <label>Selecione o usuário que deseja editar:</label>
                <br />
                <asp:DropDownList CssClass="ddl-pages" ID="ddlUserEdit" runat="server">
                    <asp:ListItem Text="" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Nome do Usuário:</label>
                <br />
                <asp:TextBox class="txt-pages" placeholder="Nome" ID="txtUserNameEdit" runat="server" />
            </div>
            <div class="form-group">
                <label>E-mail do Usuário:</label>
                <br />
                <asp:TextBox type="email" class="txt-pages" placeholder="email@exemplo.com" ID="txtUserEmailEdit" runat="server" />
            </div>
            <div class="form-group">
                <label>Senha:</label>
                <br />
                <asp:TextBox type="password" class="txt-pages" placeholder="Nova Senha" ID="txtPasswordEdit" runat="server" />
            </div>


            <asp:Button Text="Editar" runat="server" CssClass="btn-pages-show" ID="btnEditarUser" OnClick="btnEditarUser_Click" />
            <button type="button" class="btn-pages-n" id="btnCancel3" onclick="cancelEdit()">Cancelar</button>

        </div>

        <!--input de excluir usuário-->

        <div class="container" id="box4" style="display: none">

            <div class="form-group">

                <label>Selecione o usuário que deseja EXCLUIR:</label>
                <br />
                <asp:DropDownList CssClass="ddl-pages" ID="ddlUserDel" runat="server">
                    <asp:ListItem Text="" />
                </asp:DropDownList>

                <asp:Button Text="Deletar" runat="server" CssClass="btn-pages-show" ID="btnDeleteuser" OnClick="btnDeleteUser_Click" />
                <button type="button" class="btn-pages-n" id="btnCancel1" onclick="cancelDelete()">Cancelar</button>
            </div>

        </div>



    </form>



</body>
</html>
