<%@ Page Title="" Language="C#" MasterPageFile="~/branchMaster.master" AutoEventWireup="true" CodeFile="addorder.aspx.cs" Inherits="addorder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div class="row">

                <div class="col-lg-12">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <div class="box-body">


                            <div class="form-group row">
                                <div class="col-lg-6">
                                    <label for="exampleInputEmail1">Select Maincategory </label>
                                    <asp:DropDownList ID="ddlmaincategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmaincategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlmaincategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-6">
                                    <label for="exampleInputEmail1">Select Subcategory </label>
                                    <asp:DropDownList ID="ddlsubcategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                                </div>
                            </div>

                            <div class="form-group row ">
                                <div class="col-lg-6">
                                    <label for="exampleInputEmail1">Select Type </label>
                                    <asp:DropDownList ID="ddltype" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddltype" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-6">
                                    <label for="exampleInputEmail1">Select Brand </label>
                                    <asp:DropDownList ID="ddlbrand" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlbrand_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                                </div>

                            </div>



                            <div class="form-group row">
                                <div class="col-lg-6">
                                    <label for="exampleInputEmail1">select Product  </label>
                                    <asp:DropDownList ID="ddlproduct" AutoPostBack="true" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" Class="form-control" runat="server"></asp:DropDownList>


                                </div>
                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">MRP</label>

                                    <asp:TextBox ID="txtprice1" class="form-control" runat="server"></asp:TextBox>

                                </div>

                                <div class="col-lg-2" style="display: none;">
                                    <label for="exampleInputEmail1">image</label>
                                    <asp:TextBox ID="txtimagename" class="form-control" runat="server"></asp:TextBox>
                                </div>


                                <div class="col-lg-2">
                                </div>

                            </div>
                            <div class="form-group row">

                                <div class="col-lg-2 col-md-6 col-sm-6">
                                    <label for="exampleInputEmail1">Quantity</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtqty" class="form-control" AutoPostBack="true" OnTextChanged="txtqty_TextChanged" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FTBtxtCustomerProductPrice" runat="server" FilterMode="ValidChars" TargetControlID="txtqty" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtqty" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>

                                        <span class="input-group-btn">
                                            <asp:Button ID="btnadd" runat="server" class="btn btn-primary" ValidationGroup="p1" Text="Add" OnClick="btnadd_Click" />&nbsp;&nbsp;

                                           
                                        </span>
                                    </div>
                                </div>



                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">Rate</label>
                                    <asp:TextBox ID="txtrate" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>


                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">Subtotal</label>
                                    <asp:TextBox ID="txtsubtotal" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">GST</label>
                                    <asp:TextBox ID="txtgst" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">GST Amount</label>
                                    <asp:TextBox ID="txtgstamt" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="exampleInputEmail1">Total Amount</label>
                                    <asp:TextBox ID="txtFinalAmt" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group row">
                            </div>
                            <div class="form-group row" style="margin-right: 5px; margin-left: 5px;">


                                <div class="col-lg-12" style="overflow: scroll;">
                                    <table id="example1" class="table table-bordered table-striped">
                                        <thead>
                                            <tr>

                                                <th style="text-align: center">Sr</th>
                                                <th style="text-align: center">Image</th>
                                                <th style="text-align: center">Product Name</th>
                                                <th style="text-align: center">Quantity</th>
                                                <th style="text-align: center">MRP</th>
                                                <th style="text-align: center">Rate</th>
                                                <th style="text-align: center">total</th>
                                                <th style="text-align: center">GST</th>
                                                <th style="text-align: center">gstamt</th>
                                                <th style="text-align: center">totalamt</th>
                                                <th style="text-align: center">Action</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="repProduct" runat="server" OnItemDataBound="repProduct_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="txtsr" runat="server" Text='<%# Eval("sr") %>'></asp:Label>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Image ID="imgCategory" Width="75px" Height="50px" runat="server"></asp:Image>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# Eval("pid") %>'></asp:Label>
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>

                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>

                                                        </td>

                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblmrp" runat="server" Text='<%# Eval("mrp") %>'></asp:Label>

                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblrate" runat="server" Text='<%# Eval("rate") %>'></asp:Label>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblsubtot" runat="server" Text='<%# Eval("totalvalue") %>'></asp:Label>
                                                        </td>

                                                        <td style="text-align: center">
                                                            <asp:Label ID="lblgst" runat="server" Text='<%# Eval("gst") %>'></asp:Label>
                                                        </td>

                                                        <td style="text-align: center">
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("gstamt") %>'></asp:Label>
                                                        </td>

                                                        <td style="text-align: center">
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("totalamt") %>'></asp:Label>
                                                        </td>

                                                        <td style="text-align: center">
                                                            <%--<asp:HyperLink ID="hlEdit" runat="server" Style="text-decoration: underline" class="btn btn-success" Text="Edit"></asp:HyperLink>&nbsp;--%>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" class="btn btn-danger" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                            <%--<asp:LinkButton ID="LinkButton1" runat="server" Text="Delete1"    OnClick="LinkButton1_Click"></asp:LinkButton>--%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                        <%--<tfoot>
                                        <tr>

                                            <th style="text-align: center">Image</th>

                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </tfoot>--%>
                                    </table>
                                </div>




                            </div>





                        </div>
                        <div class="box-footer" style="text-align: center;">
                            <div class="form-group row">
                                <div class="col-lg-2" style="text-align: right;">

                                    <b>Total Amount : </b>
                                </div>

                                <div class="col-lg-4" style="text-align: left;">
                                    <asp:TextBox ID="txtgrandTotal" class="form-control" Width="100" runat="server"></asp:TextBox>
                                    <br />

                                </div>
                                <div class="col-lg-6" style="text-align: left;">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" CausesValidation="true" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" CssClass="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />
                                </div>
                            </div>



                        </div>
                        <!-- /.box-body -->


                    </div>



                </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlmaincategory" />
            <asp:PostBackTrigger ControlID="ddlsubcategory" />
            <asp:PostBackTrigger ControlID="ddltype" />
            <asp:PostBackTrigger ControlID="ddlbrand" />
            <asp:PostBackTrigger ControlID="btnadd" />
            <asp:PostBackTrigger ControlID="ddlproduct" />
            <asp:PostBackTrigger ControlID="txtqty" />
            <asp:PostBackTrigger ControlID="repProduct" />
           
        </Triggers>
    </asp:UpdatePanel>




    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="Template/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Template/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="Template/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="Template/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Template/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Template/dist/js/demo.js"></script>
    <!-- page script -->

</asp:Content>


