<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="managetype.aspx.cs" Inherits="managetype" %>

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
                            <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                <asp:Button ID="btnNewCategoty" runat="server" Text="New Type" class="btn btn-success" OnClick="btnNewCategoty_Click" />
                            </div>

                        </div>

                        <div class="box-body">
                            <div class="col-xs-4">
                                <label for="exampleInputEmail1">Select Maincategory </label>
                                <asp:DropDownList ID="ddlmaincategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmaincategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlmaincategory" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-4">
                                <label for="exampleInputEmail1">Select Subcategory </label>
                                <asp:DropDownList ID="ddlsubcategory" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlsubcategory" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                            </div>


                        </div>

                        <!-- /.box-header -->
                        <div class="box-body">
                            <br />
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="text-align: center;">SR No.</th>
                                        <th style="text-align: center">Name</th>
                                        <%--        
                                        <th style="text-align: center">Is Show</th>--%>
                                        <th style="text-align: center">Action</th>

                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repType" runat="server" OnItemDataBound="repType_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("sr") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblCategoryId" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                                    <%--<asp:Label ID="lblProductCount" runat="server" Visible="false" Text='<%# Eval("productcount") %>'></asp:Label>--%>

                                                    <asp:Label ID="lbltypename" runat="server" Text='<%# Eval("typename") %>'></asp:Label>
                                                </td>

                                                <%--<td style="text-align: center">
                                                    <asp:CheckBox ID="IsActive" runat="server" AutoPostBack="true" Checked='<%# Eval("isactive") %>' OnCheckedChanged="IsActive_CheckedChanged" />
                                                </td>--%>
                                                <td style="text-align: center">
                                                    <asp:HyperLink ID="hlEdit" runat="server" Style="text-decoration: underline" class="btn btn-success" Text="Edit"></asp:HyperLink>&nbsp;
                                        &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this category?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">SR No</th>
                                        <th style="text-align: center">Name</th>

                                        <%-- <th style="text-align: center">Is Show</th>--%>
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







