<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="socialpage.aspx.cs" Inherits="socialpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .fileupload1 {
            height: 44px;
            float: left;
            width: 100%;
            font-size: 11px;
            display: inline-block;
            font-weight: normal;
            text-align: left;
            -webkit-transition: all 0.4s
        }
    </style>

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
                            <h6>SOCIAL INFORMATION</h6>
                            <form>
                                <ul class="row">
                                    <li class="col-md-12">
                                        <b id="spnMessgae" runat="server"></b>
                                    </li>
                                    <!-- Name -->
                                    <li class="col-md-6">
                                        <label>
                                            TITLE
                   <asp:TextBox ID="txttitle" runat="server" placeholder="ENTER TITLE"></asp:TextBox>

                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="p" ControlToValidate="txttitle" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </li>
                                    <!-- LAST NAME -->
                                    <li class="col-md-6">
                                        <label>
                                            SHORT DESCRIPTION

                       <asp:TextBox ID="txtshortdesc" runat="server" placeholder="ENTER SHORT DESCRIPTION"></asp:TextBox>

                                        </label>
                                    </li>

                                    <!-- EMAIL ADDRESS -->
                                    <li class="col-md-12">
                                        <label>
                                            LONG DESCRIPTION
                        <asp:TextBox ID="txtlongdesc" runat="server" placeholder="ENTER LONG DESCRIPTION"></asp:TextBox>

                                        </label>
                                    </li>
                                    <!-- LAST NAME -->
                                    <li class="col-md-6">
                                        <label>
                                            VIEDO URL 1
                        <asp:TextBox ID="txturl1" runat="server" placeholder="ENTER URL"></asp:TextBox>

                                        </label>

                                    </li>

                                    <!-- LAST NAME -->
                                    <li class="col-md-6">
                                        <label>
                                            VIEDO URL 2
                        <asp:TextBox ID="txturl2" runat="server" placeholder="ENTER URL"></asp:TextBox>
                                        </label>
                                    </li>
                                    <li class="col-md-6">
                                        <label>
                                            VIEDO URL 3
                        <asp:TextBox ID="txturl3" runat="server" placeholder="ENTER URL"></asp:TextBox>

                                        </label>
                                       </li>


                                    <!-- LAST NAME -->
                                    <li class="col-md-6">
                                        <label>
                                            VIEDO URL 4
                        <asp:TextBox ID="txturl4" runat="server" placeholder="ENTER URL"></asp:TextBox>
                                        </label>
                                    </li>



                                </ul>
                                <div>
                                    <table class="table table-bordered">
                                        <tr>
                                            <td style="width:20%;">Upload Images : </td>
                                            <td style="width:40%;">
                                                <asp:FileUpload ID="fpProduct" runat="server" />
                                            </td>
                                            <td style="width:20%;">
                                                <asp:Image ID="imgProduct" Visible="false" Width="75px" Height="50px" runat="server" />
                                            </td>
                                            <td style="width:10%;">
                                                <asp:Button ID="btnRemove" runat="server" Visible="false" Text="X" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnRemove_Click" />
                                                <asp:Button ID="btnImageUpload" runat="server" Text="Upload" CssClass="btn btn-flickr" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                            </td>

                                            <td style="width:10%;">
                                                <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-flickr" OnClick="btnAdd_Click" />

                                            </td>
                                        </tr>
                                    </table>

                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>

                                                <th style="text-align: center; display: none;">Sr</th>
                                                <th style="text-align: center">Image</th>
                                                <th style="text-align: center">Action</th>
                                            </tr>
                                        </thead>


                                        <tbody>
                                            <asp:Repeater ID="repProduct" runat="server" OnItemDataBound="repProduct_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="text-align: center; display: none;">
                                                            <asp:Label ID="lblsr" runat="server" Text='<%# Eval("sr") %>'></asp:Label>
                                                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                            <asp:Label ID="lblimg" Visible="false" runat="server" Text='<%# Eval("img") %>'></asp:Label>
                                                        </td>

                                                        <td style="text-align: center">
                                                            <asp:Image ID="imgCategory" Width="75px" Height="50px" runat="server"></asp:Image>
                                                        </td>


                                                        <td style="text-align: center">

                                                            <asp:LinkButton ID="lnkrepproductDelete" runat="server" Text="Delete" class="btn btn-danger" OnClick="lnkrepproductDelete_Click"></asp:LinkButton>

                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>



                                </div>
                                <ul>
                                    <li class="col-md-6">
                                        <asp:Button ID="btnSave" ValidationGroup="p" runat="server" Width="150px" Style="margin: 10px 10px" class="btn" Text="REGISTER NOW" OnClick="btnsave_Click" />
                                        <asp:Button ID="btncancel" runat="server" Width="150px" Style="margin: 10px 10px" class="btn" Text="Cancel" OnClick="btncancel_Click" />

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

