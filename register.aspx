<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--======= PAGES INNER =========-->
    <section class="chart-page padding-top-100 padding-bottom-100">
        <div class="container">

            <!-- Payments Steps -->
            <div class="shopping-cart">

                <!-- SHOPPING INFORMATION -->
                <div class="cart-ship-info register">
                    <div class="row">

                        <!-- ESTIMATE SHIPPING & TAX -->
                        <div class="col-sm-12">
                            <h6>REGISTER</h6>
                            <form>
                                <ul class="row">

                                    <!-- Name -->
                                    <li class="col-md-6">
                                        <label>
                                            NAME
                   <asp:TextBox ID="txtname" runat="server" placeholder="ENTER NAME"></asp:TextBox>

                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="p" ControlToValidate="txtname" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </li>
                                    <!-- LAST NAME -->
                                    <li class="col-md-6">
                                        <label>
                                            MOBILE NO.

                       <asp:TextBox ID="txtmobileno" runat="server" placeholder="ENTER MOBILE NO"></asp:TextBox>

                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="p" ControlToValidate="txtmobileno" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </li>

                                    <!-- EMAIL ADDRESS -->
                                    <li class="col-md-6">
                                        <label>
                                            EMAIL ID
                        <asp:TextBox ID="txtemailid" runat="server" placeholder="ENTER EMAIL ID"></asp:TextBox>
                                           
                                        </label>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtemailid" ForeColor="#CC0000" Font-Bold="True"></asp:RegularExpressionValidator>
                                    </li>
                                    <!-- LAST NAME -->
                                    <li class="col-md-3">
                                        <label>
                                            PASSWORD
                        <asp:TextBox ID="txtpassword" runat="server" placeholder="ENTER PASSWORD"></asp:TextBox>

                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="p" ControlToValidate="txtpassword" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </li>

                                    <!-- LAST NAME -->
                                    <li class="col-md-3">
                                        <label>
                                            CONFIRM PASSWORD
                        <asp:TextBox ID="txtconfirmedpass" runat="server" placeholder="ENTER CONFIRM PASSWORD"></asp:TextBox>
                                        </label>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm passwordmust be same" ValidationGroup="p" ControlToCompare="txtpassword" ControlToValidate="txtconfirmedpass" ForeColor="#CC0000" Font-Bold="True"></asp:CompareValidator>
                                    </li>

                                    <!-- PHONE -->
                                    <li class="col-md-12">
                                        <label>
                                            ADDRESS
                       <asp:TextBox ID="txtaddress" runat="server" placeholder="ENTER ADDRESS"></asp:TextBox>
                                        </label>
                                    </li>


                                    <!-- PHONE -->

                                </ul>
                                <ul>
                                    <li class="col-md-6">
                                        <asp:Button ID="Button1" ValidationGroup="p" runat="server" Width="150px" Style="margin: 10px 10px" class="btn" OnClick="Button1_Click" Text="REGISTER NOW" />
                                        <asp:Button ID="tbnLogin" runat="server" Width="150px" Style="margin: 10px 10px" class="btn" OnClick="tbnLogin_Click" Text="Login NOW" />

                                    </li>
                                </ul>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <script src="ecommerce/js/jquery-1.11.3.min.js"></script>
</asp:Content>

