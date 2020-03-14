<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="productprices.aspx.cs" Inherits="productprices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <%--<div style="text-align: right;">
                                <asp:Button ID="btnNewBrand" runat="server" Text="New Brand" class="btn btn-Normal btn-success" OnClick="btnNewBrand_Click" />
                            </div>--%>
                        </div>

                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="form-group row">
                                <div class="col-lg-3 col-md-6 col-sm-6">
                                    <label for="exampleInputEmail1">Main Category </label>
                                    <asp:DropDownList ID="ddlbank" Class="form-control" runat="server"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlbank" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                                </div>
                                <%--<div class="col-lg-4 col-md-4 col-sm-4">
                                     <label for="exampleInputEmail1">Price</label>
                            <asp:TextBox ID="txtprice" class="form-control" runat="server" Text="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="txtprice" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                 </div>
                                 <div class="col-lg-4 col-md-4 col-sm-4">
                                     <label for="exampleInputEmail1"> </label>
                                     <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="p1" Text="Save" class="btn btn-info" OnClick="btnSave_Click" />
                                 </div>--%>

                                <div class="col-lg-3 col-md-6 col-sm-6">
                                    <label for="exampleInputEmail1">Price</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtprice" class="form-control" runat="server" Text="0"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtprice" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                        <span class="input-group-btn">
                                            <%--<button type="button" class="btn btn-info btn-flat">Go!</button>--%>
                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="p1" Text="Save" class="btn btn-info" OnClick="btnSave_Click" />
                                        </span>
                                    </div>
                                </div>

                            </div>

                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>

                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Rate</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="repCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                                    <asp:Label ID="lblbankid" runat="server" Visible="false" Text='<%# Eval("bankid") %>'></asp:Label>
                                                    <asp:Label ID="lblproductid" runat="server" Visible="false" Text='<%# Eval("pid") %>'></asp:Label>
                                                    <asp:Label ID="lblbankname" runat="server" Text='<%# Eval("bankname") %>'></asp:Label>


                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblprice" runat="server" Text='<%# Eval("price") %>'></asp:Label>

                                                </td>

                                                <td style="text-align: center">
                                                    <%--<asp:HyperLink ID="hlEdit" runat="server" class="btn btn-success" Text="EDIT"></asp:HyperLink>&nbsp;
                                        &nbsp;--%><asp:LinkButton ID="lnkDelete" runat="server" Text="DELETE" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this record?');" OnClick="lnkDelete_Click"></asp:LinkButton>


                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Bank</th>
                                        <th style="text-align: center">Rate</th>
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
