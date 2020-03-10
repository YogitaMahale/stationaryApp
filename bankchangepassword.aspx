<%@ Page Title="" Language="C#" MasterPageFile="~/bankMaster.master" AutoEventWireup="true" CodeFile="bankchangepassword.aspx.cs" Inherits="bankchangepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <!-- left column -->
        <div class="col-lg-12">
            <!-- general form elements -->
            <div class="box box-success">
                <div class="box-header with-border">
                    <h1>Change Password</h1>
                    <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">
                    <div class="form-group row">
                        <div class="col-lg-4">
                            <label for="exampleInputEmail1">New Password </label>
                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group row">
                        <div class="col-lg-4">
                            <label for="exampleInputEmail1">Confirm Password </label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and Confirm Password do not match." ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ValidationGroup="gg" ForeColor="#CC0000"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->

                <div class="box-footer">

                    <asp:Button ID="btnChangePassword" ValidationGroup="gg" runat="server" Text="Change Password" class="btn btn-success" OnClick="btnChangePassword_Click" ForeColor="White"></asp:Button>

                </div>

            </div>
            <!-- /.box -->

            <!-- Form Element sizes -->

            <!-- /.box -->


            <!-- /.box -->

            <!-- Input addon -->

            <!-- /.box -->

        </div>
        <!--/.col (left) -->
        <!-- right column -->

        <!--/.col (right) -->
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

