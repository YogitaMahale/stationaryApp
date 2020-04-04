<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="Privacypolicy.aspx.cs" Inherits="Privacypolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <style type="text/css">
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
            <div class="row">
                <!-- left column -->
                <div class="col-md-12">
                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <div class="box-body">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Privacy and Policy </label>
                                <asp:TextBox ID="txtDescription" class="form-control" runat="server" Rows="15" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVtxtCategoryName" runat="server" Display="Dynamic" ControlToValidate="txtDescription" CssClass="error" ErrorMessage="*" ValidationGroup="c1"></asp:RequiredFieldValidator>
                            </div>                         
                         
                        </div>
                        <!-- /.box-body -->

                        <div class="box-footer">

                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="c1" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" CssClass="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />
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


