<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="managebranches.aspx.cs" Inherits="managebranches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12">

                    <!-- /.box -->
                    <div class="box box-primary">
                        <div class="box-header">
                            <div class="text-center">
                            <b id="spnMessage" visible="false" runat="server"></b>
                        </div>
                            <div style="text-align: right;">
                                <asp:Button ID="btnNewBranch" runat="server" Text="New Branch" class="btn btn-Normal btn-success" OnClick="btnNewBranch_Click" />
                            </div>
                        </div>
                        
                        
                        <!-- /.box-header -->
                        <div class="box-body">
                            
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        
                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Zone</th>
                                        <th style="text-align: center">Branch</th>
                                        <th style="text-align: center">Login Name</th>
                                        <th style="text-align: center">Password</th>
                                        
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="repCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("branchid") %>'></asp:Label>
                                                    <asp:Label ID="lblbankname" runat="server" Text='<%# Eval("bankname") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblzonename" runat="server" Text='<%# Eval("zonename") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblbranchname" runat="server" Text='<%# Eval("branchcode") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblloginname" runat="server" Text='<%# Eval("loginname") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblpassword" runat="server" Text='<%# Eval("password") %>'></asp:Label>
                                                </td>
                                                
                                                <td style="text-align: center">
                                                    <asp:HyperLink ID="hlEdit" runat="server" class="btn btn-success" Text="EDIT"></asp:HyperLink>&nbsp;
                                        &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="DELETE" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this record?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Zone</th>
                                        <th style="text-align: center">Branch</th>
                                        <th style="text-align: center">Login Name</th>
                                        <th style="text-align: center">Password</th>
                                        
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- ./wrapper -->
        </ContentTemplate>
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
    <script>
        $(function () {
            $('#example1').DataTable()
            $('#example2').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })
    </script>

</asp:Content>


