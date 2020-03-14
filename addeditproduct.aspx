<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="addeditproduct.aspx.cs" Inherits="addeditproduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Main Category </label>
                            <asp:DropDownList ID="ddlmaincategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmaincategory_SelectedIndexChanged"  runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlmaincategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Sub Category </label>
                            <asp:DropDownList ID="ddlsubcategory" Class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Type </label>
                            <asp:DropDownList ID="ddltype" Class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddltype" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Brand </label>
                            <asp:DropDownList ID="ddlbrand" Class="form-control"  runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Product Name </label>
                            <asp:TextBox ID="txtproductName" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtCategoryName" runat="server" Display="Dynamic" ControlToValidate="txtproductName" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">GST</label>
                            <asp:TextBox ID="txtgst" class="form-control" runat="server"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FTBtxtCustomerProductPrice" runat="server" FilterMode="ValidChars" TargetControlID="txtgst" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>
                      
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtgst" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Stock</label>
                            <asp:TextBox ID="txtstock" class="form-control" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FTBtxtQuantites" runat="server" FilterMode="ValidChars" TargetControlID="txtstock" ValidChars="01234567890"></cc1:FilteredTextBoxExtender>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtstock" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">MOQ</label>
                            <asp:TextBox ID="txtmoq" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="txtmoq" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-lg-6">
                            <label for="exampleInputPassword1">Short Description</label>
                            <asp:TextBox ID="txtShortDescription" Class="form-control" TextMode="MultiLine" runat="server" Height="110px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtCategoryShortDescription" runat="server" Display="Dynamic" ControlToValidate="txtShortDescription" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-lg-6">
                            <label for="exampleInputPassword1">Long Description</label>
                            <asp:TextBox ID="txtLongDescription" Class="form-control" TextMode="MultiLine" Height="110px" runat="server"></asp:TextBox>
                        </div>

                    </div>


                    <div class="form-group row">
                        <div class="col-lg-6">
                            <label for="exampleInputFile">Product Image</label>
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="fpCategory" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Image ID="imgCategory" Visible="false" Width="75px" Height="50px" runat="server" />
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRemove" runat="server" Visible="false" CssClass="btn btn-danger" Text="X" CausesValidation="false" OnClick="btnRemove_Click" />
                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnImageUpload" runat="server" CssClass="btn btn-info" Text="Upload" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Mrp</label>
                            <asp:TextBox ID="txtmrp" class="form-control" runat="server"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtmrp" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>
                      
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="txtmrp" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <%--<div class="form-group">
                        <div class="col-lg-6">
                                <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="text-align: center;">SR No.</th>
                                         <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Price</th>

                                    </tr>
                                </thead>
 
                                <tbody>
                                    <asp:Repeater ID="repbank" runat="server" OnItemDataBound="repbank_ItemDataBound" >
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                                    <asp:Label ID="lblsrno" runat="server"></asp:Label>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:Label ID="lblbankname" runat="server" Text='<%# Eval("bankname") %>'></asp:Label>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:TextBox ID="txtprice" class="form-control" runat="server" Text="0"></asp:TextBox>
                                                </td>
                                               
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center;">SR No.</th>
                                         <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Price</th>

                                    </tr>
                                </tfoot>
                            </table>
                        
                        </div>
                    </div>--%>
                </div>
                <div class="box-footer">
                    <div class="form-group row" style="text-align:center;">
                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="c1" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" CssClass="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />
                        </div>
                </div>



            </div>
            <!-- /.box-body -->

            
        </div>



    </div>






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

