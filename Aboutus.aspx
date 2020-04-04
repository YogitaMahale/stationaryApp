<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="Aboutus.aspx.cs" Inherits="Aboutus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
        .error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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
                                <label for="exampleInputEmail1">Description </label>
                                <asp:TextBox ID="txtDescription" class="form-control"  Rows="15" TextMode="MultiLine" runat="server" ></asp:TextBox>
                               </div>                         
                          
                        </div>
                        <!-- /.box-body -->

                        <div class="box-footer">

                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" CausesValidation="true"  Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" CssClass="btn btn-info" OnClick="btnCancel_Click1" Text="Cancel" />
                        </div>

                    </div>
                    

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

