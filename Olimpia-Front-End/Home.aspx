<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Olimpia_Front_End.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Olimpia | Home</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!--Link CSS utilizado-->
    <link rel="stylesheet" href="css/pages.css" />
    <link rel="stylesheet" href="css/design.css" />
    <link rel="stylesheet" href="css/creative.css" />
    <!--Link do bootstrap-->
    <link rel="stylesheet" href="css/bootstrap.css" />
    <!--Link do Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <!--Efeito JavaScript para trocar Boxes-->
    <script src="js/switch.js"></script>

    <!--JS Bootstrap-->
    <script src="responsive/bootstrap/bootstrap.min.js"></script>

    <link rel="shortcut icon" href="img/logoblack.png" />

</head>
<body style="background-color: black">

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
                    <li class="nav-link"><a href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Contate-nos</a></li>
                    <li class="nav-link"><a href="login.aspx" target="_blank">Login</a></li>
                    <li class="nav-link"><a href="cadastro.aspx" style="color: #cb8933" target="_blank">Cadastre-se</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <header class="header0 text-center text-white d-flex">

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Carousel indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <!-- Wrapper for carousel items -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="img/carousel1.png" alt="First Slide">
                </div>
                <div class="item">
                    <img src="img/carousel2.png" alt="Second Slide">
                </div>
                <div class="item">
                    <img src="img/carousel3.png" alt="Third Slide">
                </div>
            </div>
            <!-- Carousel controls -->
            <a class="carousel-control left" href="#myCarousel" data-slide="prev">
                <%--<span class="glyphicon glyphicon-chevron-left"></span>--%>
            </a>
            <a class="carousel-control right" href="#myCarousel" data-slide="next">
                <%-- <span class="glyphicon glyphicon-chevron-right"></span>--%>
            </a>
        </div>


    </header>


    <section style="background-color: #171719;">
        <div class="container">

            <div class="card" style="width: 100%;">
                <div class="card-body bg-transparent" style="padding: 3rem;">
                    <h2 class="title-pages-w">Conheça mais a Olímpia</h2>

                    <br />
                    <p class="subtitle-pages-w">
                        Com uma forte vontade de empreender, quatro estudantes fundaram, em agosto de 2018, Olímpia, uma empresa de tecnologia 
                        que busca fornecer a melhor experiência para seus clientes. Localizada no centro de São paulo, traz consigo as melhores 
                        soluções em monitoração de computadores para instituições de ensino.
                    </p>
                    <p class="subtitle-pages-w">
                        Olímpia fornece mais do que sistemas de monitoração de máquinas, fornecemos agilidade e boa experiência ficou interessado? Conheça um pouco mais sobre nossa  história,
                            <a href="QuemSomos.aspx" title="Conheça mais aqui">clique aqui.</a>

                    </p>

                </div>

            </div>

        </div>


        <p class="divider-sections"></p>



        <div class="container">
            <div class="col-lg-3">
                <div class="card" style="width: 25rem;">
                    <div class="card-body bg-white" style="padding: 3rem;">
                        <h3 class="title-pages">ATHENA</h3>
                        <h6 class="card-subtitle mb-2 text-muted"></h6>
                        <p class="subtitle-pages">Conheça Athena, a melhor solução de monitoramento de máquinas para a sua instituição de ensino.</p>
                        <p><a href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Clique aqui.</a></p>
                    </div>
                </div>
            </div>

            <div class="col-lg-3">
                <div class="card" style="width: 25rem;">

                    <div class="card-body bg-white" style="padding: 3rem;">
                        <h3 class="title-pages">Planos</h3>
                        <h6 class="card-subtitle mb-2 text-muted"></h6>
                        <p class="subtitle-pages">Conheça nosso planos e veja qual pacote combina melhor com a sua instituição de ensino.</p>
                        <p><a href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Clique aqui.</a></p>
                    </div>

                </div>
            </div>

            <div class="col-lg-3">
                <div class="card" style="width: 25rem;">

                    <div class="card-body bg-white" style="padding: 3rem;">
                        <h3 class="title-pages">Investidor</h3>
                        <h6 class="card-subtitle mb-2 text-muted"></h6>
                        <p class="subtitle-pages">Quer entender mais sobre nós? Conheça nosso balanço trimestral por aqui: </p>
                        <p><a href="https://www.facebook.com/OlimpiaTechnology/?modal=admin_todo_tour">Clique aqui.</a></p>
                        <br />
                    </div>

                </div>
            </div>

            <div class="col-lg-3">
                <div class="card" style="width: 25rem;">

                    <div class="card-body bg-white" style="padding: 3rem;">
                        <h3 class="title-pages">Suporte</h3>
                        <h6 class="card-subtitle mb-2 text-muted"></h6>
                        <p class="subtitle-pages">Para um apoio sobre a nossa solução, entre em contato conosco atráves do link abaixo:</p>
                        <p><a href="https://olimpiaathena.freshdesk.com/support/home">Clique aqui.</a></p>
                        <br />
                    </div>

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
