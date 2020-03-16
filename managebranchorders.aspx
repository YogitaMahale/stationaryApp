<%@ Page Title="" Language="C#" MasterPageFile="~/bankMaster.master" AutoEventWireup="true" CodeFile="managebranchorders.aspx.cs" Inherits="managebranchorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12">

                    <!-- /.box -->



                    <div class="box box-success">

                        <div class="box-header">

                            <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                <b id="spnMessage" visible="false" runat="server"></b>

                            </div>


                        </div>


                        <%--<div style="text-align:right;">
                             <asp:Button ID="btnNeworder" runat="server" Text="New Order" class="btn btn-Normal btn-primary" OnClick="btnNeworder_Click" Width="150" />
                        </div>--%>


                        <!-- /.box-header -->
                        <div class="box-body">
                            <br />
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="text-align: center">ID</th>
                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Branch</th>
                                        <th style="text-align: center">Order Date</th>
                                        <th style="text-align: center">Amount</th>

                                        <th style="text-align: center">Action</th>

                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="reporders" runat="server" OnItemDataBound="repproduct_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lbloid1" runat="server" Text='<%# Eval("oid") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("bankname") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center; width: 100px;">
                                                    <asp:Label ID="lblOId" runat="server" Visible="false" Text='<%# Eval("oid") %>'></asp:Label>
                                                    <asp:Label ID="lblbranchname" runat="server" Text='<%# Eval("branchname") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("orderdate") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: center">
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("totalamount") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: center">

                                                    <asp:HyperLink ID="hlinvoice" runat="server" CssClass="btn btn-sm btn-warning" Text="Invoice" Target="_blank"></asp:HyperLink>&nbsp;&nbsp; 
                                     <asp:HyperLink ID="hlEdit" Visible="false" runat="server" CssClass="btn btn-sm btn-success" Text="Edit"></asp:HyperLink>&nbsp;
                            &nbsp;<asp:LinkButton ID="lnkTodayDelete" Visible="false" runat="server" Text="Delete" CommandArgument='<%# Eval("oid") %>' CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Do you want to delete this order?');" OnClick="lnkDelete_Click"></asp:LinkButton>

                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">ID</th>
                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Branch</th>
                                        <th style="text-align: center">Order Date</th>
                                        <th style="text-align: center">Amount</th>

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



