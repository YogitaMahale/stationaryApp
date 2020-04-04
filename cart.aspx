<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="productdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--======= PAGES INNER =========-->
    <section class="padding-top-100 padding-bottom-100 pages-in chart-page">
        <div class="container">

            <!-- Payments Steps -->
            <div class="shopping-cart text-center">
                <div class="cart-head">
                    <ul class="row">
                        <!-- PRODUCTS -->
                        <li class="col-sm-2 text-left">
                            <h6>PRODUCTS</h6>
                        </li>
                        <!-- NAME -->
                        <li class="col-sm-4 text-left">
                            <h6>NAME</h6>
                        </li>
                        <!-- PRICE -->
                        <li class="col-sm-2">
                            <h6>PRICE</h6>
                        </li>
                        <!-- QTY -->
                        <li class="col-sm-1">
                            <h6>QTY</h6>
                        </li>

                        <!-- TOTAL PRICE -->
                        <li class="col-sm-2">
                            <h6>TOTAL</h6>
                        </li>
                        <li class="col-sm-1"></li>
                    </ul>
                </div>
               

                <!-- Cart Details -->
                <asp:Repeater ID="repcart" runat="server">
                    <ItemTemplate>
                        <ul class="row cart-details">
                            <li class="col-sm-6">
                                <div class="media">
                                    <!-- Media Image -->
                                    <div class="media-left media-middle"><a href="#." class="item-img">
                                         <br /><br />
                 
                                        <img class="media-object" src="uploads/product/<%#Eval("imagename") %>" alt="">
                                    </a></div>

                                    <!-- Item Name -->
                                    <div class="media-body">
                                        <div class="position-center-center">
                                            <asp:Label ID="lblpid" Visible="false"  runat="server" Text='<%#Eval("pid") %>'></asp:Label>
                                            <asp:Label ID="lblprice" Visible="false"  runat="server" Text='<%#Eval("price") %>'></asp:Label>
                                            <h5><%#Eval("productname") %></h5>
                                            <p><%#Eval("shortdescp") %></p>
                                        </div>
                                    </div>
                                </div>
                            </li>

                            <!-- PRICE -->
                            <li class="col-sm-2">
                                <div class="position-center-center"><span class="price"><small></small><%#Eval("price") %></span> </div>
                            </li>

                            <!-- QTY -->
                            <li class="col-sm-1">
                                <div class="position-center-center">
                                    <div class="quinty">
                                        <!-- QTY -->
                                        <%--<asp:TextBox ID="TextBox1" runat="server" Text="<%#Eval("qty") %>"></asp:TextBox>--%>

                                        <asp:TextBox ID="txtqty" runat="server" Text='<%#Eval("qty") %>' AutoPostBack="true" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                      
                                        <%--<select class="selectpicker">
                                            <option>1</option>
                                            <option>2</option>
                                            <option>3</option>
                                        </select>--%>
                                    </div>
                                </div>
                            </li>

                            <!-- TOTAL PRICE -->
                            <li class="col-sm-2">
                                <div class="position-center-center"><span class="price"><small></small><%#Eval("total") %></span> </div>
                            </li>

                            <!-- REMOVE -->
                            <li class="col-sm-1">
                                    
                                  
                                 <asp:LinkButton ID="lnkremove" class="position-center-center" runat="server" Text="Delete" OnClientClick="return confirm('Do you want to remove this product?');" OnClick="lnkremove_Click"></asp:LinkButton>
                           
                                <%--<div class="position-center-center"><a href="#."><i class="icon-close"></i></a></div>--%>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                  <div class="coupn-btn row">
                      <div class="col-sm-6">
                          <a href="Default.aspx" class="btn">continue shopping</a>
                            <a href="#." class="btn">Place Order</a>
                      </div>
                          <div class="col-sm-6">
                                                <br />       
                                <p class="all-total">TOTAL COST : <span id="lbltotalamt" runat="server">$998</span></p>
                           
                              </div>
                      
                       </div>
                  
                        
            </div>
        </div>
    </section>

   
    <script src="ecommerce/js/jquery-1.11.3.min.js"></script>
</asp:Content>


