<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="managesocialpage.aspx.cs" Inherits="managesocialpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        #active {
            color:  #ff0052 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--======= PAGES INNER =========-->
    <section class="padding-top-100 padding-bottom-100 pages-in chart-page">
        <div class="container">

            <!-- Payments Steps -->

            <div style="text-align: right;">
                <asp:Button ID="Button1" runat="server" Class="btn" Text="Add New" OnClick="Button1_Click" />
            </div>
            <div class="text-center">
                <b id="spnMessage" runat="server"></b>
            </div>
            
            <br />
            <div class="shopping-cart text-center">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th style="text-align: center;">sr</th>
                            <th style="text-align: center;">Title</th>
                            <th style="text-align: center;">Description</th>
                            <th style="text-align: center;">Date</th>
                            <th style="text-align: center;">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repsocialinfo" runat="server" OnItemDataBound="repsocialinfo_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("sr") %>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%# Eval("title") %>
                                 
                                    </td>
                                    <td>
                                        <%# Eval("shortdesc") %>
                                 
                                    </td>
                                    <td>
                                        <%# Eval("date1") %>
                                 
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkremove" runat="server" Text="Delete" OnClientClick="return confirm('Do you want to remove this?');" OnClick="lnkremove_Click"></asp:LinkButton>
                                         <asp:HyperLink ID="hlEdit" Visible="false" runat="server" Style="text-decoration: underline" CssClass="btn btn-sm btn-success" Text="Edit"></asp:HyperLink>&nbsp;
                                       
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                <%--<div class="cart-head">
                    <ul class="row">
                        <!-- PRODUCTS -->
                        <li class="col-sm-3">
                            <h6>sr</h6>
                        </li>
                        <!-- NAME -->
                        <li class="col-sm-3">
                            <h6>Title</h6>
                        </li>
                        <!-- PRICE -->
                        <li class="col-sm-3">
                            <h6>Description</h6>
                        </li>
                        <!-- QTY -->
                        <li class="col-sm-1">
                            <h6>Date</h6>
                        </li>

                        <li class="col-sm-2"></li>
                    </ul>
                </div>--%>
            </div>
        </div>
    </section>



    <script src="ecommerce/js/jquery-1.11.3.min.js"></script>
     <script>
        $("a[href='managesocialpage.aspx']").attr("id", "active");
        
    </script>
</asp:Content>




