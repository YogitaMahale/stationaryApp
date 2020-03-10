<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="productimages.aspx.cs" Inherits="productimages" %>

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
                                <div class="col-lg-4">
                                    <label for="exampleInputFile">Image</label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:FileUpload ID="fpProduct" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Image ID="imgProduct" Visible="false" Width="75px" Height="50px" runat="server" />
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRemove" runat="server" Visible="false" Text="X" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnRemove_Click" />
                                                &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnImageUpload" runat="server" Text="Upload" CssClass="btn btn-flickr" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-lg-6">
                                    <label for="exampleInputFile"></label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="p1" Text="Save" class="btn btn-info btn-lg" OnClick="btnSave_Click" />

                                            </td>
                                        </tr>
                                    </table>

                                </div>

                            </div>

                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>

                                        <th style="text-align: center">Image</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="repCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                                    <asp:Label ID="lblproductid" runat="server" Visible="false" Text='<%# Eval("pid") %>'></asp:Label>
                                                    <asp:Label ID="lblimagename" runat="server" Visible="false" Text='<%# Eval("imagename") %>'></asp:Label>
                                                    
                                                    <asp:Image ID="imgCategory" Width="150px" Height="100px" runat="server"></asp:Image>

                                                </td>

                                                <td style="text-align: center">
                                                    <div style="margin:30px 0px 30px 0px">
                                                        <%--<asp:HyperLink ID="hlEdit" runat="server" class="btn btn-success" Text="EDIT"></asp:HyperLink>&nbsp;
                                        &nbsp;--%><asp:LinkButton ID="lnkDelete" runat="server" Text="DELETE" class="btn btn-danger btn-lg" OnClientClick="return confirm('Do you want to delete this record?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                    </div>
                                                    
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Image</th>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnImageUpload" />
            <asp:PostBackTrigger ControlID="btnRemove" />
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

    <script type="text/javascript">
        function checkFileExtension() {
            var result = false;
            var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
            //if (($("#ctl00_ContentPlaceHolder1_fpProduct").val() == "") || ($("#ctl00_ContentPlaceHolder1_fpProduct").val() == null)) {
            if ((document.getElementById("fpProduct").val() == "") || (document.getElementById("fpProduct").val() == null)) {
                alert("Please Upload Image.")
                result = false;
            }
            else {
                var allowedFiles = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
                //var fileUpload = document.getElementById("ctl00_ContentPlaceHolder1_fpProduct");
                var fileUpload = document.getElementById("fpProduct");
                var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
                if (!regex.test(fileUpload.value.toLowerCase())) {
                    alert("Please upload files having extensions:" + allowedFiles.join(', ') + " only.");
                    result = false;
                }
                else {
                    result = true;
                }
            }

            return result;
        }
    </script>

</asp:Content>

