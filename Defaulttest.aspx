<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaulttest.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>
<%--<html lang="en">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="M_Adnan">
    <title>Stationery</title>

    <!-- SLIDER REVOLUTION 4.x CSS SETTINGS -->
    <link rel="stylesheet" type="text/css" href="ecommerce/rs-plugin/css/settings.css" media="screen" />

    <!-- Bootstrap Core CSS -->
    <link href="ecommerce/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="ecommerce/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="ecommerce/css/ionicons.min.css" rel="stylesheet">
    <link href="ecommerce/css/main.css" rel="stylesheet">
    <link href="ecommerce/css/style.css" rel="stylesheet">
    <link href="ecommerce/css/responsive.css" rel="stylesheet">

    <!-- JavaScripts -->
    <script src="ecommerce/js/modernizr.js"></script>

    <!-- Online Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Playfair+Display:400,700,900' rel='stylesheet' type='text/css'>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
            margin: 0;
            padding: 0;
        }

        .loader {
            height: 50px;
            width: 100px;
        }

        .item {
            width: 202px;
            border: 1px solid #ccc;
            box-shadow: 2px 2px 8px 2px #ccc;
        }

            .item .header {
                height: 30px;
                background-color: #9F9F9F;
                color: #fff;
            }

            .item .body {
                width: 200px;
                height: 200px;
            }

            .item .image {
                height: 200px;
                width: 200px;
            }

            .item .footer {
                height: 50px;
            }

        .button, .button:hover {
            height: 45px;
            padding: 10px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            border-radius: 4px;
            text-decoration: none;
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }

        #price_slider, #price_slider_value {
            width: 400px;
            margin: 5px;
        }

        #empty {
            display: block;
            width: 400px;
            background-color: #9F9F9F;
            color: #fff;
            height: 30px;
            line-height: 30px;
            margin: 5px;
            text-align: center;
        }

        .modal {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Wrap -->
        <div id="wrap">

            <!-- header -->
            <header>
                <div class="sticky">
                    <div class="container">

                        <!-- Logo -->
                        <div class="logo">
                            <a href="index.html">
                                <img class="img-responsive" src="ecommerce/images/logo.png" alt=""></a>
                        </div>
                        <nav class="navbar ownmenu">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#nav-open-btn" aria-expanded="false"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"><i class="fa fa-navicon"></i></span></button>
                            </div>

                            <!-- NAV -->
                            <div class="collapse navbar-collapse" id="nav-open-btn">
                                <ul class="nav">
                                    <li class="dropdown active"><a href="#." class="dropdown-toggle" data-toggle="dropdown">Home</a>
                                        <ul class="dropdown-menu">
                                            <li><a href="index.html">Index Default</a> </li>
                                            <li><a href="index-1.html">Index 2</a> </li>
                                            <li><a href="index-2.html">Index 3</a></li>
                                            <li><a href="index-header-1.html">Index Header 1</a></li>
                                            <li><a href="index-header-2.html">Index Header 2</a></li>
                                            <li><a href="index-header-3.html">Index Header 3</a></li>
                                            <li><a href="index-header-4.html">Index Header 4</a></li>
                                        </ul>
                                    </li>
                                    <li class="dropdown"><a href="#." class="dropdown-toggle" data-toggle="dropdown">Pages</a>
                                        <ul class="dropdown-menu">
                                            <li><a href="shop_01.html">Shop 01 </a></li>
                                            <li><a href="shop_02.html">Shop 02</a> </li>
                                            <li><a href="shop_03.html">Shop 03 </a></li>
                                            <li><a href="shop_04.html">Shop 04 </a></li>
                                            <li><a href="product-detail_01.html">Product Detail 01</a> </li>
                                            <li><a href="product-detail_02.html">Product Detail 02</a> </li>
                                            <li><a href="shopping-cart.html">Shopping Cart</a> </li>
                                            <li><a href="checkout.html">Checkout</a> </li>
                                            <li><a href="about-us_01.html">About 01</a> </li>
                                            <li><a href="about-us_02.html">About 02</a> </li>
                                            <li><a href="contact.html">Contact</a> </li>
                                            <li><a href="blog-list_01.html">Blog List 01</a> </li>
                                            <li><a href="blog-list_02.html">Blog List 02</a> </li>
                                            <li><a href="blog-list_03.html">Blog List 03 </a></li>
                                            <li><a href="blog-detail_01.html">Blog Detail 01 </a></li>
                                        </ul>
                                    </li>
                                    <li><a href="about-us_01.html">About </a></li>

                                    <!-- Two Link Option -->
                                    <li class="dropdown"><a href="#." class="dropdown-toggle" data-toggle="dropdown">Designer</a>
                                        <div class="dropdown-menu two-option">
                                            <div class="row">
                                                <ul class="col-sm-6">
                                                    <li><a href="shop_01.html">summer store</a></li>
                                                    <li><a href="shop_01.html">sarees</a></li>
                                                    <li><a href="shop_01.html">kurtas</a></li>
                                                    <li><a href="shop_01.html">shorts & tshirts</a></li>
                                                    <li><a href="shop_01.html">winter wear</a></li>
                                                    <li><a href="shop_01.html">jeans</a></li>
                                                    <li><a href="shop_01.html">bra</a></li>
                                                    <li><a href="shop_01.html">babydools</a> </li>
                                                </ul>
                                                <ul class="col-sm-6">
                                                    <li><a href="shop_01.html">deodornts</a></li>
                                                    <li><a href="shop_01.html">skin care</a></li>
                                                    <li><a href="shop_01.html">make up</a></li>
                                                    <li><a href="shop_01.html">watch</a></li>
                                                    <li><a href="shop_01.html">siting bags</a></li>
                                                    <li><a href="shop_01.html">totes</a></li>
                                                    <li><a href="shop_01.html">gold rings</a></li>
                                                    <li><a href="shop_01.html">jewellery</a> </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>

                                    <!-- MEGA MENU -->
                                    <li class="dropdown megamenu"><a href="#." class="dropdown-toggle" data-toggle="dropdown">store</a>
                                        <div class="dropdown-menu">
                                            <div class="row">

                                                <!-- Shop Pages -->
                                                <div class="col-md-3">
                                                    <h6>Shop Pages</h6>
                                                    <ul>
                                                        <li><a href="shop_01.html">Shop 01 </a></li>
                                                        <li><a href="shop_02.html">Shop 02</a> </li>
                                                        <li><a href="shop_03.html">Shop 03 </a></li>
                                                        <li><a href="shop_04.html">Shop 04 </a></li>
                                                        <li><a href="product-detail_01.html">Product Detail 01</a> </li>
                                                        <li><a href="product-detail_02.html">Product Detail 02</a> </li>
                                                        <li><a href="shopping-cart.html">Shopping Cart</a> </li>
                                                        <li><a href="checkout.html">Checkout</a> </li>
                                                    </ul>
                                                </div>

                                                <!-- TOp Rate Products -->
                                                <div class="col-md-4">
                                                    <h6>TOp Rate Products</h6>
                                                    <div class="top-rated">
                                                        <ul>
                                                            <li>
                                                                <div class="media-left">
                                                                    <div class="cart-img">
                                                                        <a href="#">
                                                                            <img class="media-object img-responsive" src="ecommerce/images/cart-img-1.jpg" alt="...">
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                                <div class="media-body">
                                                                    <h6 class="media-heading">WOOD CHAIR</h6>
                                                                    <div class="stars"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></div>
                                                                    <span class="price">129.00 USD</span>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <div class="media-left">
                                                                    <div class="cart-img">
                                                                        <a href="#">
                                                                            <img class="ecommerce/media-object img-responsive" src="ecommerce/images/cart-img-2.jpg" alt="...">
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                                <div class="media-body">
                                                                    <h6 class="media-heading">STOOL</h6>
                                                                    <div class="stars"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></div>
                                                                    <span class="price">129.00 USD</span>
                                                                </div>
                                                            </li>
                                                            <li>
                                                                <div class="media-left">
                                                                    <div class="cart-img">
                                                                        <a href="#">
                                                                            <img class="ecommerce/media-object img-responsive" src="ecommerce/images/cart-img-3.jpg" alt="...">
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                                <div class="media-body">
                                                                    <h6 class="media-heading">WOOD SPOON</h6>
                                                                    <div class="stars"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></div>
                                                                    <span class="price">129.00 USD</span>
                                                                </div>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>

                                                <!-- New Arrival -->
                                                <div class="col-md-5">
                                                    <h5>NEW ARRIVAL 2016 <span>(Best Collection)</span></h5>
                                                    <img class="nav-img" src="ecommerce/images/nav-img.png" alt="">
                                                    <p>
                                                        Lorem ipsum dolor sit amet,<br>
                                                        consectetur adipiscing elit.
                                                    <br>
                                                        Donec faucibus maximus<br>
                                                        vehicula.
                                                    </p>
                                                    <a href="#." class="btn btn-small btn-round">SHOP NOW</a>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li><a href="contact.html">contact</a> </li>
                                </ul>
                            </div>

                            <!-- Nav Right -->
                            <div class="nav-right">
                                <ul class="navbar-right">

                                    <!-- USER INFO -->
                                    <li class="dropdown user-acc"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button"><i class="icon-user"></i></a>
                                        <ul class="dropdown-menu">
                                            <li>
                                                <h6>HELLO! Jhon Smith</h6>
                                            </li>
                                            <li><a href="#">MY CART</a></li>
                                            <li><a href="#">ACCOUNT INFO</a></li>
                                            <li><a href="#">LOG OUT</a></li>
                                        </ul>
                                    </li>

                                    <!-- USER BASKET -->
                                    <li class="dropdown user-basket"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="true"><i class="icon-basket-loaded"></i></a>
                                        <ul class="dropdown-menu">
                                            <li>
                                                <div class="media-left">
                                                    <div class="cart-img">
                                                        <a href="#">
                                                            <img class="media-object img-responsive" src="ecommerce/images/cart-img-1.jpg" alt="...">
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="media-body">
                                                    <h6 class="media-heading">WOOD CHAIR</h6>
                                                    <span class="price">129.00 USD</span> <span class="qty">QTY: 01</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="media-left">
                                                    <div class="cart-img">
                                                        <a href="#">
                                                            <img class="media-object img-responsive" src="ecommerce/images/cart-img-2.jpg" alt="...">
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="media-body">
                                                    <h6 class="media-heading">WOOD STOOL</h6>
                                                    <span class="price">129.00 USD</span> <span class="qty">QTY: 01</span>
                                                </div>
                                            </li>
                                            <li>
                                                <h5 class="text-center">SUBTOTAL: 258.00 USD</h5>
                                            </li>
                                            <li class="margin-0">
                                                <div class="row">
                                                    <div class="col-xs-6"><a href="shopping-cart.html" class="btn">VIEW CART</a></div>
                                                    <div class="col-xs-6 "><a href="checkout.html" class="btn">CHECK OUT</a></div>
                                                </div>
                                            </li>
                                        </ul>
                                    </li>

                                    <!-- SEARCH BAR -->
                                    <li class="dropdown"><a href="javascript:void(0);" class="search-open"><i class=" icon-magnifier"></i></a>
                                        <div class="search-inside animated bounceInUp">
                                            <i class="icon-close search-close"></i>
                                            <div class="search-overlay"></div>
                                            <div class="position-center-center">
                                                <div class="search">
                                                    <form>
                                                        <input type="search" placeholder="Search Shop">
                                                        <button type="submit"><i class="icon-check"></i></button>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </nav>
                    </div>
                </div>
            </header>

            <!--======= HOME MAIN SLIDER =========-->
            <section class="home-slider">

                <!-- SLIDE Start -->
                <div class="tp-banner-container">
                    <div class="tp-banner">
                        <ul>

                            <asp:Repeater ID="Repeater_Slider" runat="server">
                                <ItemTemplate>
                                    <li data-transition="random" data-slotamount="7" data-masterspeed="300" data-saveperformance="off">
                                        <!-- MAIN IMAGE -->
                                        <img class="imgsliderclass" src="uploads/websiteslider/<%#Eval("imagename") %>" alt="slider" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat">
                                        <!-- LAYERS -->
                                        <!-- LAYER NR. 1 -->
                                        <%-- <div class="tp-caption font-playfair sfb tp-resizeme"
                                    data-x="left" data-hoffset="0"
                                    data-y="center" data-voffset="-200"
                                    data-speed="800"
                                    data-start="500"
                                    data-easing="Power3.easeInOut"
                                    data-splitin="none"
                                    data-splitout="none"
                                    data-elementdelay="0.1"
                                    data-endelementdelay="0.1"
                                    data-endspeed="300"
                                    style="z-index: 7; font-size: 18px; color: #fff; max-width: auto; max-height: auto; white-space: nowrap;">
                                    The Latest Product from PAVSHOP
                                </div>
                                <!-- LAYER NR. 2 -->
                                <div class="tp-caption sfl font-extra-bold tp-resizeme"
                                    data-x="left" data-hoffset="0"
                                    data-y="center" data-voffset="-120"
                                    data-speed="800"
                                    data-start="800"
                                    data-easing="Power3.easeInOut"
                                    data-splitin="none"
                                    data-splitout="none"
                                    data-elementdelay="0.07"
                                    data-endelementdelay="0.1"
                                    data-endspeed="300"
                                    style="z-index: 6; font-size: 80px; color: #2d3a4b; text-transform: uppercase; white-space: nowrap;">
                                    <small class="font-regular">$</small>299
                                </div>
                                <!-- LAYER NR. 2 -->
                                <div class="tp-caption sfr font-extra-bold tp-resizeme"
                                    data-x="left" data-hoffset="0"
                                    data-y="center" data-voffset="0"
                                    data-speed="800"
                                    data-start="800"
                                    data-easing="Power3.easeInOut"
                                    data-splitin="chars"
                                    data-splitout="none"
                                    data-elementdelay="0.07"
                                    data-endelementdelay="0.1"
                                    data-endspeed="300"
                                    style="z-index: 6; font-size: 120px; color: #fff; text-transform: uppercase; white-space: nowrap;">
                                    featured
                                </div>
                                <!-- LAYER NR. 2 -->
                                <div class="tp-caption sfr font-extra-bold tp-resizeme"
                                    data-x="left" data-hoffset="0"
                                    data-y="center" data-voffset="110"
                                    data-speed="800"
                                    data-start="1300"
                                    data-easing="Power3.easeInOut"
                                    data-splitin="chars"
                                    data-splitout="none"
                                    data-elementdelay="0.07"
                                    data-endelementdelay="0.1"
                                    data-endspeed="300"
                                    style="z-index: 6; font-size: 120px; color: #fff; text-transform: uppercase; white-space: nowrap;">
                                    cycle
                                </div>
                                <!-- LAYER NR. 4 -->
                                <div class="tp-caption lfb tp-resizeme"
                                    data-x="left" data-hoffset="0"
                                    data-y="center" data-voffset="240"
                                    data-speed="800"
                                    data-start="2200"
                                    data-easing="Power3.easeInOut"
                                    data-elementdelay="0.1"
                                    data-endelementdelay="0.1"
                                    data-endspeed="300"
                                    data-scrolloffset="0"
                                    style="z-index: 8;">
                                    <a href="#." class="btn">SHOP NOW</a>
                                </div>--%>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>


                            <!-- SLIDE  -->

                            <%--     divslider
imgsliderclass
divRepeaterslider--%>
                        </ul>
                    </div>
                </div>
            </section>

            <!-- Content -->
            <div id="content">

                <!-- New Arrival -->
                <section class="padding-top-100 padding-bottom-100">
                    <div class="container">

                        <!-- Main Heading -->
                        <div class="heading text-center">
                            <h4>new arrival</h4>
                            <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus maximus vehicula. 
          Sed feugiat, tellus vel tristique posuere, diam</span>
                        </div>
                    </div>

                    <!-- New Arrival -->
                    <div class="arrival-block" id="divRepeaterNewArrival">
                        <asp:Repeater ID="repnewArrival" runat="server">
                            <ItemTemplate>

                                <!-- Item -->
                                <div class="item" id="divNewArrival">
                                    <!-- Images -->
                                    <img class="img-1" src="uploads/product/websiteproduct/<%#Eval("mainimage") %>" alt="">
                                    <img class="img-2" src="uploads/product/websiteproduct/<%#Eval("mainimage") %>" alt="">
                                    <!-- Overlay  -->
                                    <div class="overlay">
                                        <!-- Price -->
                                        <span class="price"><small></small><span class="mrp"><%#Eval("mrp") %></span></span>
                                        <div class="position-center-center"><a href="images/item-img-1-1.jpg" data-lighter><i class="icon-magnifier"></i></a></div>
                                    </div>
                                    <!-- Item Name -->
                                    <div class="item-name">
                                        <a href="#."><span class="productname">
                                            <%#Eval("productname") %></span>
                                        </a>
                                        <p><span class="shortdescp"><%#Eval("shortdescp") %></span></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--<div class="arrival-block">

                        <!-- Item -->
                        <div class="item">
                            <!-- Images -->
                            <img class="img-1" src="ecommerce/images/item-img-1-1.jpg" alt="">
                            <img class="img-2" src="ecommerce/images/item-img-1-1-1.jpg" alt="">
                            <!-- Overlay  -->
                            <div class="overlay">
                                <!-- Price -->
                                <span class="price"><small>$</small>299</span>
                                <div class="position-center-center"><a href="images/item-img-1-1.jpg" data-lighter><i class="icon-magnifier"></i></a></div>
                            </div>
                            <!-- Item Name -->
                            <div class="item-name">
                                <a href="#.">wooden chair</a>
                                <p>Lorem ipsum dolor sit amet</p>
                            </div>
                        </div> 

                       
                    </div>--%>
                </section>



                <!-- Price Slider -->
                <section class="padding-top-100 padding-bottom-100">
                    <div style="text-align:center">
                          <h4>Filter by Price </h4>

                    </div>
                   
                    <div style="text-align: center;" id="price_slider_value">
                            </div>
                            <div class="text-center" style="text-align: center;" id="price_slider">
                            </div>

                    <div class="arrival-block" id="dvProducts">
                    </div>
                    <hr />
                    <%-- <div id="dvProducts">
                    </div>--%>
                    <div style="display: none">



                        <asp:DataList ID="dlProducts" runat="server" RepeatLayout="Table" RepeatColumns="3"
                            CellPadding="2" CellSpacing="20">
                            <ItemTemplate>

                                <table class="item" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td align="center" class="header">
                                            <span class="name">
                                                <%# Eval("Name") %></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="body">
                                            <img class="image" src="" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="footer" align="center">
                                            <span class="button"></span>
                                            <input type="hidden" class="is_used" value="0" />
                                            <input type="hidden" class="product_id" value='<%# Eval("ProductId")%>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <div class="modal">
                        <div class="center">
                            <img alt="" src="loader.gif" />
                        </div>
                    </div>



                    <%--<div class="arrival-block">


                        <div id="price_slider_value" style="width: 400px">
                        </div>
                        <div id="price_slider" class="col-md-4">
                        </div>
                        <hr />
                        <div id="dvProducts">
                        </div>
                        <div style="display: none">
                            <asp:DataList ID="dlProducts" runat="server" RepeatLayout="Table" RepeatColumns="3"
                                CellPadding="2" CellSpacing="20">
                                <ItemTemplate>




                                    <table class="item" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="center" class="header">
                                                <span class="name">
                                                    <%# Eval("Name") %></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="body">
                                                <img class="image" src="" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="footer" align="center">
                                                <span class="button"></span>
                                                <input type="hidden" class="is_used" value="0" />
                                                <input type="hidden" class="product_id" value='<%# Eval("ProductId")%>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div class="modal">
                            <div class="center">
                                <img alt="" src="loader.gif" />
                            </div>
                        </div>
                    
                    </div>--%>
                </section>









                <!-- Popular Products -->
                <section class="padding-top-50 padding-bottom-150">
                    <div class="container">

                        <!-- Main Heading -->
                        <div class="heading text-center">
                            <h4>popular products</h4>
                            <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus maximus vehicula. 
          Sed feugiat, tellus vel tristique posuere, diam</span>
                        </div>

                        <!-- Popular Item Slide -->
                        <div class="papular-block block-slide">

                            <!-- Item -->
                            <div class="item">
                                <!-- Item img -->
                                <div class="item-img">
                                    <img class="img-1" src="ecommerce/images/product-1.jpg" alt="">
                                    <img class="img-2" src="ecommerce/images/product-2.jpg" alt="">
                                    <!-- Overlay -->
                                    <div class="overlay">
                                        <div class="position-center-center">
                                            <div class="inn"><a href="images/product-1.jpg" data-lighter><i class="icon-magnifier"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To Cart"><i class="icon-basket"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To WishList"><i class="icon-heart"></i></a></div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Item Name -->
                                <div class="item-name">
                                    <a href="#.">stone cup</a>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                                <!-- Price -->
                                <span class="price"><small>$</small>299</span>
                            </div>

                            <!-- Item -->
                            <div class="item">
                                <!-- Item img -->
                                <div class="item-img">
                                    <img class="img-1" src="ecommerce/images/product-2.jpg" alt="">
                                    <img class="img-2" src="ecommerce/images/product-2.jpg" alt="">
                                    <!-- Overlay -->
                                    <div class="overlay">
                                        <div class="position-center-center">
                                            <div class="inn"><a href="images/product-2.jpg" data-lighter><i class="icon-magnifier"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To Cart"><i class="icon-basket"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To WishList"><i class="icon-heart"></i></a></div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Item Name -->
                                <div class="item-name">
                                    <a href="#.">gray bag</a>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                                <!-- Price -->
                                <span class="price"><small>$</small>299</span>
                            </div>

                            <!-- Item -->
                            <div class="item">
                                <!-- Item img -->
                                <div class="item-img">
                                    <img class="img-1" src="ecommerce/images/product-3.jpg" alt="">
                                    <img class="img-2" src="ecommerce/images/product-2.jpg" alt="">
                                    <!-- Overlay -->
                                    <div class="overlay">
                                        <div class="position-center-center">
                                            <div class="inn"><a href="images/product-3.jpg" data-lighter><i class="icon-magnifier"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To Cart"><i class="icon-basket"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To WishList"><i class="icon-heart"></i></a></div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Item Name -->
                                <div class="item-name">
                                    <a href="#.">chiar</a>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                                <!-- Price -->
                                <span class="price"><small>$</small>299</span>
                            </div>

                            <!-- Item -->
                            <div class="item">
                                <!-- Item img -->
                                <div class="item-img">
                                    <img class="img-1" src="ecommerce/images/product-4.jpg" alt="">
                                    <img class="img-2" src="ecommerce/images/product-2.jpg" alt="">
                                    <!-- Overlay -->
                                    <div class="overlay">
                                        <div class="position-center-center">
                                            <div class="inn"><a href="images/product-4.jpg" data-lighter><i class="icon-magnifier"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To Cart"><i class="icon-basket"></i></a><a href="#." data-toggle="tooltip" data-placement="top" title="Add To WishList"><i class="icon-heart"></i></a></div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Item Name -->
                                <div class="item-name">
                                    <a href="#.">STool</a>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                                <!-- Price -->
                                <span class="price"><small>$</small>299</span>
                            </div>
                        </div>
                    </div>
                </section>

                <!-- Knowledge Share -->
                <section class="light-gray-bg padding-top-150 padding-bottom-150">
                    <div class="container">

                        <!-- Main Heading -->
                        <div class="heading text-center">
                            <h4>knowledge share</h4>
                            <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus maximus vehicula. 
          Sed feugiat, tellus vel tristique posuere, diam</span>
                        </div>
                        <div class="knowledge-share">
                            <ul class="row">

                                <!-- Post 1 -->
                                <li class="col-md-6">
                                    <div class="date"><span>December</span> <span class="huge">27</span> </div>
                                    <a href="#.">Donec commo is vulputate</a>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus maximus vehicula. Sed feugiat, tellus vel tristique posuere, diam</p>
                                    <span>By <strong>Admin</strong></span> </li>

                                <!-- Post 2 -->
                                <li class="col-md-6">
                                    <div class="date"><span>December</span> <span class="huge">09</span> </div>
                                    <a href="#.">Donec commo is vulputate</a>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus maximus vehicula. Sed feugiat, tellus vel tristique posuere, diam</p>
                                    <span>By <strong>Admin</strong></span> </li>
                            </ul>
                        </div>
                    </div>
                </section>

                <!-- Testimonial -->
                <section class="testimonial padding-top-100">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6">

                                <!-- SLide -->
                                <div class="single-slide">

                                    <!-- Slide -->
                                    <div class="testi-in">
                                        <i class="fa fa-quote-left"></i>
                                        <p>Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed ullamcorper sapien lacus, eu posuere odio luctus non. Nulla lacinia, eros vel fermentum consectetur, risus p</p>
                                        <h5>john smith</h5>
                                    </div>

                                    <!-- Slide -->
                                    <div class="testi-in">
                                        <i class="fa fa-quote-left"></i>
                                        <p>Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed ullamcorper sapien lacus, eu posuere odio luctus non. Nulla lacinia, eros vel fermentum consectetur, risus p</p>
                                        <h5>john smith</h5>
                                    </div>

                                    <!-- Slide -->
                                    <div class="testi-in">
                                        <i class="fa fa-quote-left"></i>
                                        <p>Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed ullamcorper sapien lacus, eu posuere odio luctus non. Nulla lacinia, eros vel fermentum consectetur, risus p</p>
                                        <h5>john smith</h5>
                                    </div>
                                </div>
                            </div>

                            <!-- Img -->
                            <div class="col-sm-6">
                                <img class="img-responsive" src="ecommerce/images/testi-avatar.jpg" alt="">
                            </div>
                        </div>
                    </div>
                </section>

                <!-- About -->
                <section class="small-about padding-top-150 padding-bottom-150">
                    <div class="container">

                        <!-- Main Heading -->
                        <div class="heading text-center">
                            <h4>about PAVSHOP</h4>
                            <p>
                                Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsumien lacus, eu posuere odio luctus non. Nulla lacinia,
            eros vel fermentum consectetur, risus purus tempc, et iaculis odio dolor in ex.
                            </p>
                        </div>

                        <!-- Social Icons -->
                        <ul class="social_icons">
                            <li><a href="#."><i class="icon-social-facebook"></i></a></li>
                            <li><a href="#."><i class="icon-social-twitter"></i></a></li>
                            <li><a href="#."><i class="icon-social-tumblr"></i></a></li>
                            <li><a href="#."><i class="icon-social-youtube"></i></a></li>
                            <li><a href="#."><i class="icon-social-dribbble"></i></a></li>
                        </ul>
                    </div>
                </section>
                <section class="news-letter padding-top-150 padding-bottom-150">
                    <div class="container">
                        <div class="heading light-head text-center margin-bottom-30">
                            <h4>NEWSLETTER</h4>
                            <span>Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsumien lacus, eu posuere odi </span>
                        </div>
                        <form>
                            <input type="email" placeholder="Enter your email address" required>
                            <button type="submit">SEND ME</button>
                        </form>
                    </div>
                </section>
            </div>

            <!--======= FOOTER =========-->
            <footer>
                <div class="container">

                    <!-- ABOUT Location -->
                    <div class="col-md-3">
                        <div class="about-footer">
                            <img class="margin-bottom-30" src="ecommerce/images/logo-foot.png" alt="">
                            <p>
                                <i class="icon-pointer"></i>Street No. 12, Newyork 12,
                            <br>
                                MD - 123, USA.
                            </p>
                            <p><i class="icon-call-end"></i>1.800.123.456789</p>
                            <p><i class="icon-envelope"></i>info@PAVSHOP.com</p>
                        </div>
                    </div>

                    <!-- HELPFUL LINKS -->
                    <div class="col-md-3">
                        <h6>HELPFUL LINKS</h6>
                        <ul class="link">
                            <li><a href="#.">Products</a></li>
                            <li><a href="#.">Find a Store</a></li>
                            <li><a href="#.">Features</a></li>
                            <li><a href="#.">Privacy Policy</a></li>
                            <li><a href="#.">Blog</a></li>
                            <li><a href="#.">Press Kit </a></li>
                        </ul>
                    </div>

                    <!-- SHOP -->
                    <div class="col-md-3">
                        <h6>SHOP</h6>
                        <ul class="link">
                            <li><a href="#.">About Us</a></li>
                            <li><a href="#.">Career</a></li>
                            <li><a href="#.">Shipping Methods</a></li>
                            <li><a href="#.">Contact</a></li>
                            <li><a href="#.">Support</a></li>
                            <li><a href="#.">Retailer</a></li>
                        </ul>
                    </div>

                    <!-- MY ACCOUNT -->
                    <div class="col-md-3">
                        <h6>MY ACCOUNT</h6>
                        <ul class="link">
                            <li><a href="#.">Login</a></li>
                            <li><a href="#.">My Account</a></li>
                            <li><a href="#.">My Cart</a></li>
                            <li><a href="#.">Wishlist</a></li>
                            <li><a href="#.">Checkout</a></li>
                        </ul>
                    </div>

                    <!-- Rights -->

                    <div class="rights">
                        <p>©  2017 PAVSHOP All right reserved. </p>
                        <div class="scroll"><a href="#wrap" class="go-up"><i class="lnr lnr-arrow-up"></i></a></div>
                    </div>
                </div>
            </footer>

            <!--======= RIGHTS =========-->

        </div>
    </form>
    <%--<!-- LOADER -->
<div id="loader">
  <div class="position-center-center">
    <div class="ldr"></div>
  </div>
</div>--%>



    <%-- price /////////////////////--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script>  
        var jQuery172 = jQuery.noConflict();
        window.jQuery = jQuery172;
    </script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/excite-bike/jquery-ui.css"
        rel="stylesheet" type="text/css" />


    <%-- price /////////////////////--%>


    <script src="ecommerce/js/jquery-1.11.3.min.js"></script>



    <script src="ecommerce/js/bootstrap.min.js"></script>
    <script src="ecommerce/js/own-menu.js"></script>
    <script src="ecommerce/js/jquery.lighter.js"></script>
    <script src="ecommerce/js/owl.carousel.min.js"></script>

    <!-- SLIDER REVOLUTION 4.x SCRIPTS  -->
    <script type="text/javascript" src="ecommerce/rs-plugin/js/jquery.tp.t.min.js"></script>
    <script type="text/javascript" src="ecommerce/rs-plugin/js/jquery.tp.min.js"></script>
    <script src="ecommerce/js/main.js"></script>
    <script src="ecommerce/js/main.js"></script>
    <%--//----price slider
      
        --------------------%>
    <script type="text/javascript">
        jQuery172(document).ready(function ($) {


            var min = 0;
            var max = 0;
            $(function () {
                //Get records for all prices.
                GetRecords(0, 0);
            });
            function SetSlider() {
                //Intialize the slider
                $("#price_slider").slider({
                    min: min,
                    max: max,
                    step: 5,
                    values: [min, max],
                    stop: function (event, ui) {
                        var start = parseInt(ui.values[0]);
                        var end = parseInt(ui.values[1]);
                        $("#price_slider_value").html("Rs." + ui.values[0] + " - Rs." + ui.values[1]);

                        //When slider is stopped then get records for range.
                        GetRecords(start, end);
                    },
                    slide: function (event, ui) {
                        if ((ui.values[0] + 5) >= ui.values[1]) {
                            return false;
                        }
                    }
                });
                //Display the minimum and maximum values.
                $("#price_slider_value").html("Rs." + min + " - Rs." + max);
            }
            function GetRecords(start, end) {
                $(".modal").show();
                $.ajax({
                    type: "POST",
                    url: "Defaulttest.aspx/GetProducts",
                    data: '{start: ' + start + ', end: ' + end + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            }
            function OnSuccess(response) {
                var xmlDoc = $.parseXML(response.d);
                var xml = $(xmlDoc);
                if (min == 0 && max == 0) {
                    //Only for the first time set the minimum and maximum values.
                    min = parseInt(xml.find("Range").eq(0).find("Min").text());
                    max = parseInt(xml.find("Range").eq(0).find("Max").text());
                    SetSlider();
                }
                var products = xml.find("Products");
                var repeatColumns = parseInt("<%=RepeatColumns %>");
                $("#dvProducts").html("<div id = 'empty'>There are no products available for the selected price range.</div>");
                if (products.length > 0) {
                    //Copy the DataList HTML into the DIV.
                    $("#dvProducts").html($("[id*=dlProducts]").parent().html());
                }
                $("#dvProducts > table").removeAttr("id");
                var rowCount = Math.ceil(products.length / repeatColumns);
                var j = 0;
                products.each(function () {
                    var product = $(this);
                    var row = $("#dvProducts > table .item:last").closest("tr");
                    if ($(".is_used[value='1']", row).length == repeatColumns) {
                        row = $("#dvProducts > table tr").eq(0).clone();
                        $(".is_used", row).val("0");
                        $("#dvProducts > table").append(row);
                        j = 0;
                    } else {
                        row = $("#dvProducts > table .item:last").closest("tr");
                    }
                    var cell = $(".item", row).eq(j);
                    $(".name", cell).html(product.find("Name").text());
                    var productId = product.find("ProductId").text();
                    $(".product_id", cell).val(productId);
                    $(".button", cell).text(product.find("Price").text());
                    $(".is_used", cell).attr("value", "1");
                    //var img = $(".image", cell);
                    //img.attr("src", "uploads/product/websiteproduct/" + mainimage);
                    //img.attr("src", "Images/1.png");
                    //  mainimage = "uploads/product/websiteproduct/" + mainimage;
                    // alert(product.find("img").text());
                    // img.attr("src", product.find("mainimage").text());
                    $(".image", cell).attr("src", product.find("img").text());

                    j++;
                });
                $("#dvProducts > table .is_used[value='0']").closest(".item").remove();
                $(".modal").hide();
            }
        });

    </script>
</body>
</html>
