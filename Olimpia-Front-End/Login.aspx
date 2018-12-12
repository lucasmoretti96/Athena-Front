<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Olimpia_Front_End.login" %>

<!DOCTYPE html>
<!--Nota: Foi utilizado de um template em bootstrap já existente.
Foram feitas alterações no HTML, CSS e JavaScript. Os efeitos de
responsividades do site são exclusivos do template.

Para editar modelos e efeitos CSS, consulte as classes já existentes nos arquivos:
- Bootstrap.min.css
- creative.min.css

****Cuidado ao editar o tamanho, margin ou padding de alguma classe do Bootstrap.
Talvez ela possa estar sendo utilizada em vários lugares simultaneamente.

Usem bastante o Inspecionar no navegador, dêem um check na responsividade. ****
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="shortcut icon" href="img/logoblack.png">

    <title>Olimpia | Login</title>

    <!-- Bootstrap CSS -->
    <link href="responsive/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Aqui estará todo o CSS para definir o estilo da página.-->
    <link href="css/design.css" rel="stylesheet">
</head>
<body>

    <!--Aqui contém as infos iniciais do site-->
    <header class="text-center text-white d-flex" id="back-img">
        <div class="container my-auto">
            <div class="row">
                <!--Essas 3 classes definem a estrutura do bg-->
                <div class="col-lg-10 mx-auto">
                    <h1 class="text-uppercase" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                        <strong style="font">Login
                        </strong>
                        <hr>
                    </h1>
                </div>
                <div class="col-lg-8 mx-auto">


                    <form runat="server">

                        <asp:Label Text="" ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true" BackColor="WhiteSmoke" />
                        <br>
                        <asp:TextBox CssClass="userField" placeholder="Usuário" runat="server" ID="txtUserLogin" />
                        <br>
                        <asp:TextBox CssClass="userField" placeholder="Senha" runat="server" type="password" ID="txtPassLogin" />
                        <br>


                            <div class="clearfix">

                                <div class="optiontxt1">
                                    <a href="cadastro.aspx" id="link-register">Cadastrar</a>
                                </div>
                                <div class="optiontxt1">
                                    <a href="Home.aspx" id="link-pwd">Retornar à Home</a>
                                </div>
                        </br>
                </div>
                <asp:Button Text="Enviar" runat="server" ID="btnLogar" CssClass="btn-login" OnClick="btnLogar_Click" />

                <div>
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                </div>

                </form>
            </div>

        </div>
        </div>
        
    </header>
</body>

<!-- Bootstrap core JavaScript -->
<script src="responsive/jquery/jquery.min.js"></script>
<script src="responsive/bootstrap/js/bootstrap.bundle.min.js"></script>

</html>
