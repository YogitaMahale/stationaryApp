<%@ Page Title="" Language="C#" MasterPageFile="~/branchMaster.master" AutoEventWireup="true" CodeFile="addorder.aspx.cs" Inherits="addorder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
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
                            <asp:DropDownList ID="ddlmaincategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmaincategory_SelectedIndexChanged" Width="500px" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlmaincategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">Select Subcategory </label>
                            <asp:DropDownList ID="ddlsubcategory" Class="form-control" Width="500px" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group row ">
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">Select Type </label>
                            <asp:DropDownList ID="ddltype" Class="form-control" Width="500px" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddltype" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">Select Brand </label>
                            <asp:DropDownList ID="ddlbrand" Class="form-control" Width="500px" AutoPostBack="true" OnSelectedIndexChanged="ddlbrand_SelectedIndexChanged" runat="server"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                        </div>

                    </div>



                    <div class="form-group row">
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">select Product  </label>
                            <asp:DropDownList ID="ddlproduct" Class="form-control" Width="500px" runat="server"></asp:DropDownList>

                            
                        </div>
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">Quantity</label>
                            <asp:TextBox ID="txtqty" class="form-control" runat="server"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FTBtxtCustomerProductPrice" runat="server" FilterMode="ValidChars" TargetControlID="txtqty" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>
                      
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtqty" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                 
                    
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


