<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Olimpia_Front_End.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="shortcut icon" href="img/logoblack.png">

    <title>Olimpia | Cadastro</title>

    <!-- Bootstrap CSS -->
    <link href="responsive/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Aqui estará todo o CSS para definir o estilo da página.-->
    <link href="css/design.css" rel="stylesheet">
</head>
<body>


    <!--Aqui contém as infos iniciais do site-->
    <header class="masthead text-center text-white d-flex" id="back-img-cadastro">
        <div class="container my-auto">
            <div class="row">
                <!--Essas 3 classes definem a estrutura do bg-->
                <div class="col-lg-10 mx-auto">
                    <h1 class="text-uppercase" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                        <strong>Cadastro
                        </strong>
                    </h1>
                    <hr/>
                    <br />
                </div>
                <div class="col-lg-8 mx-auto">

                    <form runat="server">


                        <div id="coluna-1">
                            <asp:TextBox ID="txtNomeFantasia" CssClass="form-cadastro" runat="server" placeholder="Nome Fantasia" />
                            <br>
                            <asp:TextBox ID="txtCNPJ" CssClass="form-cadastro" runat="server" size="14" placeholder="CNPJ" />
                            <br>
                            <asp:TextBox ID="txtUsuarioCadastro" CssClass="form-cadastro" runat="server" placeholder="Usuário" />
                            <br>
                            <asp:TextBox ID="txtCEP" CssClass="form-cadastro" runat="server" placeholder="CEP" />
                            <br>
                            <asp:TextBox ID="txtBairro" CssClass="form-cadastro" runat="server" placeholder="Bairro" />
                            <br>
                            <asp:TextBox ID="txtRua" CssClass="form-cadastro" runat="server" placeholder="Rua" />
                            <br>
                        </div>
                        <div id="coluna-2">
                            <asp:TextBox ID="txtRazao" CssClass="form-cadastro" runat="server" placeholder="Razão Social" />
                            <br>
                            <asp:TextBox ID="txtEmail" CssClass="form-cadastro" runat="server" placeholder="E-mail" type="email" />
                            <br>
                            <asp:TextBox ID="txtSenhaCadastro" CssClass="form-cadastro" runat="server" placeholder="Senha" type="password" />
                            <br>
                            <asp:TextBox ID="txtUF" CssClass="form-cadastro" runat="server" placeholder="UF" />
                            <br>
                            <asp:TextBox ID="txtCidade" CssClass="form-cadastro" runat="server" placeholder="Cidade" />
                            <br>
                            <asp:TextBox ID="numEnd" CssClass="num" runat="server" placeholder="Nº" />
                            <asp:TextBox ID="txtComplemento" CssClass="complEnd" runat="server" placeholder="Complemento" />


                        </div>


                        <asp:Button Text="Enviar" runat="server" ID="btnCadastrar" CssClass="btn-login" OnClick="btnCadastrar_Click" />

                    </form>



                </div>

            </div>
        </div>
        </div>
    </header>

</body>
</html>
