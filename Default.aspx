﻿<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        #active {
            color: #ff0052 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- New Arrival -->
    <section class="padding-top-100 padding-bottom-100">
        <div class="container">

            <!-- Main Heading -->
            <div class="heading text-center">
                <h4>Product</h4>
               <%-- <span>lorem ipsum dolor sit amet, consectetur adipiscing elit. donec faucibus maximus vehicula. 
          sed feugiat, tellus vel tristique posuere, diam</span>--%>
            </div>

            
        </div>

        <!-- New Arrival -->
        <div class="arrival-block" id="divRepeaterNewArrival">
            <asp:Repeater ID="repnewArrival" runat="server">
                <ItemTemplate>

                    <!-- Item -->
                    <div class="item" id="divNewArrival">
                        <!-- Images -->
                        <a href="web_productdetails.aspx?pid=<%#Eval("id") %>">
                            <img class="img-1" src="uploads/product/websiteproduct/<%#Eval("mainimage") %>" alt="">
                        </a>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img class="img-2" src="uploads/product/websiteproduct/<%#Eval("mainimage") %>" alt="">
                        <!-- Overlay  -->
                        <div class="overlay">
                            <!-- Price -->
                            <span class="price"><small>Rs.</small><span class="mrp"><%#Eval("mrp") %></span></span><%-- <div class="position-center-center"><a   href="uploads/product/websiteproduct/<%#Eval("mainimage") %>" data-lighter><i class="icon-magnifier"></i></a></div>--%><div class="position-center-center"><a href="uploads/product/websiteproduct/<%#Eval("mainimage") %>" data-lighter><i class="icon-magnifier"></i></a></div>
                        </div>
                        <!-- Item Name -->
                        <div class="item-name">
                            <a href="web_productdetails.aspx?pid=<%#Eval("id") %>"><span class="productname">
                                <%#Eval("productname") %></span>
                            </a>
                            <p><span class="shortdescp"><%#Eval("shortdescp") %></span></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
        <%--   <div style="text-align:center;">
  
              <table>
                <tr>
                    
                    <td>
                        <asp:Button ID="btnfirst" runat="server" Font-Bold="true" Text="<<" Height="31px"
                            Width="43px" OnClick="btnfirst_Click" /></td>
                    <td>
                        <asp:Button ID="btnprevious" runat="server" Font-Bold="true" Text="<" Height="31px"
                            Width="43px" OnClick="btnprevious_Click" /></td>
                    <td>
                        <asp:Button ID="btnnext" runat="server" Font-Bold="true" Text=">" Height="31px"
                            Width="43px" OnClick="btnnext_Click" /></td>
                    <td>
                        <asp:Button ID="btnlast" runat="server" Font-Bold="true" Text=">>" Height="31px"
                            Width="43px" OnClick="btnlast_Click" /></td>
                </tr>
            </table>
        </div>--%>
        <div style="margin-top: 20px; text-align: center; margin-left: 300px; margin-right: 300px;">
            <table style="width: 600px;">
                <tr>
                    <td>
                        <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click">First</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click">Previous</asp:LinkButton>
                    </td>
                    <td>
                        <asp:DataList ID="rptPaging" runat="server"
                            OnItemCommand="rptPaging_ItemCommand"
                            OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPaging" runat="server"
                                    CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                    Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click">Next</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click">Last</asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    </section>


    <!-- Price Slider -->

    <section class="padding-top-100 padding-bottom-100"  >
        <div style="text-align: center">
            <h4>Filter by Price </h4>

        </div>

        <div style="text-align: center;" id="price_slider_value">
        </div>
        <div class="text-center" style="text-align: center;" id="price_slider">
        </div>

        <div class="arrival-block" id="dvProducts">
            <%-- <div class="item">
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
            --%>
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
                    url: "Default.aspx/GetProducts",
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
                var testbody = '';
                products.each(function () {
                    var product = $(this);
                    //alert(product.find("ProductId").text());
                    //var row = $("#dvProducts > table .item:last").closest("tr");
                    //if ($(".is_used[value='1']", row).length == repeatColumns) {
                    //    row = $("#dvProducts > table tr").eq(0).clone();
                    //    $(".is_used", row).val("0");
                    //    $("#dvProducts > table").append(row);
                    //    j = 0;
                    //} else {
                    //    row = $("#dvProducts > table .item:last").closest("tr");
                    //}
                    //var cell = $(".item", row).eq(j);
                    //$(".name", cell).html(product.find("Name").text());
                    //var productId = product.find("ProductId").text();
                    //$(".product_id", cell).val(productId);
                    //$(".button", cell).text(product.find("Price").text());
                    //$(".is_used", cell).attr("value", "1");                    
                    //$(".image", cell).attr("src", product.find("img").text());



                    testbody += "<div class='item'>";
                    testbody += "<img class='img-1' src='" + product.find("img").text() + "' alt=''>";
                    testbody += "<img class='img-2' src='" + product.find("img").text() + "' alt=''>";
                    testbody += "<div class='overlay'>";
                    testbody += " <span class='price'><small>$</small>" + product.find("Price").text() + "</span>";
                    testbody += "<div class='position-center-center'><a href='" + product.find("img").text() + "' data-lighter><i class='icon-magnifier'></i></a></div>";
                    testbody += " </div>";
                    testbody += "<div class='item-name'>";
                    testbody += " <a href='web_productdetails.aspx?pid=" + product.find("ProductId").text() + "'>" + product.find("Name").text() + "</a>";
                    //alert(product.find("shortdescp").text());
                    testbody += "<p>" + product.find("shortdescp").text() + "</p>";
                    testbody += "</div>";
                    testbody += "</div> ";




                    j++;
                });
                //$("#dvProducts > table .is_used[value='0']").closest(".item").remove();
                $("#dvProducts").html(testbody);
                $(".modal").hide();
            }
        });

    </script>
    <script>
        $("a[href='Default.aspx']").attr("id", "active");

    </script>
</asp:Content>


