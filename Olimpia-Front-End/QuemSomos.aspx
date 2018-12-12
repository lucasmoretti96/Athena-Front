<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuemSomos.aspx.cs" Inherits="Olimpia_Front_End.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Olimpia | Quem Somos</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Link CSS utilizado-->
    <link rel="stylesheet" href="css/pages.css" />
    <link rel="stylesheet" href="css/design.css" />
    <link rel="stylesheet" href="css/creative.css" />
    <!--Link do bootstrap-->
    <link rel="stylesheet" href="css/bootstrap.css" />

    <link rel="shortcut icon" href="img/logoblack.png" />

</head>
<body>

    <nav class="navbar-no-margin navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="home.aspx">
                    <img class="navbar-brand" src="img/olimpogold.png" /></a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav navbar-right">
                    <li class="nav-link"><a href="home.aspx">Home</a></li>
                    <li class="nav-link"><a href="QuemSomos.aspx">Quem Somos</a></li>
                    <li class="nav-link"><a href="contate.aspx">Contate-nos</a></li>
                    <li class="nav-link"><a href="login.aspx" target="_blank">Login</a></li>
                    <li class="nav-link"><a href="cadastro.aspx" style="color: #cb8933" target="_blank">Cadastre-se</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <header class="header0 text-center text-white d-flex">
    </header>


    <section style="background-color: #171719;">
        <div class="container">

            <div class="card" style="width: 100%;">
                <div class="card-body bg-transparent" style="padding: 3rem;">
                    <h2 class="title-pages-w text-uppercase ">Quem SOMOS</h2>
                    <br />
                    
                    <p class="subtitle-pages-w">
                        A Olímpia  teve seu nascimento no centro de São Paulo, em agosto de 2018, dentro de uma sala de aula da Faculdade de Tecnologia Bandeirantes (BandTec), por meio de seus quatro fundadores: Alessandra Vieira, 
                    Gustavo Batistuti, Jean Sales e Lucas Moretti.  Os fundadores foram desafiados a criar uma solução que monitorasse as informações de hardware máquinas em rede e, após uma longa pesquisa, perceberam que uma
                    área que necessitava de atenção era o segmento educacional, o qual eles mesmos estavam inseridos.                    
                    </p>
                    <p class="subtitle-pages-w">
                        Ao analisarem os processos dentro de instituições de ensino, perceberam que havia uma deficiência no processo. Na medida que a tecnologia avançou,
                     intituições de ensino passaram a utilizar grandes quantidades de computadores e a monitoração de cada máquina demandava muito tempo, além de sobrecarregar os profissionais 
                     responsáveis por monitorarem essa grande quantidade de máquinas.  Dessa necessidade nasceu a Olímpia com a idealização do Athena, uma empresa encarregada de facilitar o processo de monitoramento com uma solução inovadora.
                        <br />
                        <br />
                     
                    </p>
                    <h3 class="title-pages-w text-uppercase">Nosso jeito de ser</h3>
                    <br />
                    <p class="subtitle-pages-w">
                        Atuar diretamente na melhoria e desenvolvimento do cliente não é só nosso objetivo, é nossa filosofia. A Olímpia visa trazer 
                    o que há de novo e melhor em tecnologia com a intenção de melhorar a monitoração de máquinas no ambiente educacional. 
                    Nosso objetivo é fornecer uma solução que atenda e supere as expectativas do nosso cliente. 
                    </p>

                    <p class="subtitle-pages-w">
                        Nossa missão pode ser resumida em uma simples frase: "Não só atender, mas atender bem!". Buscamos atender a necessidade de nossos clientes, trazendo uma solução
                     que seja eficaz e auxilie no seu desenvolvimento empresarial, aumentando seu desempenho, auxiliando em suas decisões e otimizando seu tempo. A Olímpia busca atender 
                       seu cliente com toda atenção que ele merece.

                    </p>

                </div>

            </div>

        </div>



    </section>

    <footer>
        <div class="container">
        </div>
    </footer>
</body>
</html>
