<%@ Page Title="" Language="C#" MasterPageFile="~/branchMaster.master" AutoEventWireup="true" CodeFile="orderinvoice.aspx.cs" Inherits="orderinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="row">
                <div class="col-xs-12">

                    <!-- /.box -->



                    <div class="box">

                        <div class="text-center">
                            <b id="spnMessage" visible="false" runat="server"></b>
                        </div>
                        <div style="text-align: right;">
                            <%--<asp:Button ID="btnNeworder" runat="server" Text="New Order" class="btn btn-Normal btn-primary" OnClick="btnNeworder_Click" Width="150" />--%>
                        </div>


                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <h1>&nbsp;&nbsp;&nbsp; Invoice Order No - #<span id="sminvoiceNo" runat="server" class="text-center"></span>
                                </h1>
                               <%-- <h4>Order Date : <small id="smOrderDate" runat="server" class="pull-right"></small>
                                </h4>--%>

                                <div class="col-xs-4">
                                    From
                              <address>
                                  <strong>All Stationary.</strong><br />
                                  <span id="spnFormAddress" runat="server">305-306, Bhaveshwar Arcade LBS Marg , Ghatkopar W Mumbai.
                                  </span>
                                  <br />
                                  Phone: <span id="spnFromPhone" runat="server">(+91 ) 9920104157, 022-25002111</span><br />
                                  <%--Email: <span id="spnFromEmail" runat="server">abc.abc@gmail.com</span>--%>
                              </address>
                                </div>
                                <div class="col-xs-4">
                                    To
                            <address>
                              <%--  Name   : <span id="spnloginUserName" runat="server"></span>--%>
                                
                                Bank   : <span id="spnToBank" runat="server"></span>
                                <br />
                                Branch : <span id="spnToBranch" runat="server"></span>
                                <br />
                                Block No : <span id="spnTooaddress" runat="server"></span>
                                <br />
                                Appartment : <span id="spnTooApartment" runat="server"></span>
                                <br />
                                Road : <span id="spnTooRoad" runat="server"></span>
                                <br />
                                State : <span id="spnTooState" runat="server"></span>
                                <br />
                                City : <span id="spnTooCity" runat="server"></span>
                                <br />



                                <br />
                            </address>
                                </div>
                                <div class="col-xs-4">
                                    <br />
                                    <address>
                                        Pin Code : <span id="spnTooPincode" runat="server"></span>
                                        <br />
                                        Mobile No. : <span id="spnTooMobileNo" runat="server"></span>
                                        <br />
                                        Phone No. : <span id="spnTooPhoneNo" runat="server"></span>
                                        <br />
                                        GST : <span id="spnTooGst" runat="server"></span>
                                        <br />
                                        Zonal Manager Name : <span id="spnTooZonalmgrName" runat="server"></span>
                                        <br />
                                        Zonal Manager Email : <span id="spnTooZonalmgrEmail" runat="server"></span>
                                        <br />
                                     
                                    </address>
                                </div>
                            </div>

                            <br />
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>

                                        <th style="text-align: center">Sr</th>
                                <%--        <th style="text-align: center">Image</th>--%>
                                        <th style="text-align: center">Product Name</th>
                                        <th style="text-align: center">Quantity</th>
                                        <th style="text-align: center">MRP</th>
                                        <th style="text-align: center">Rate</th>
                                        <th style="text-align: center">Subtotal</th>
                                        <th style="text-align: center">GST</th>
                                        <th style="text-align: center">Gst Amount</th>
                                        <th style="text-align: center">Total</th>


                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repProduct" runat="server" >
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="txtsr" runat="server" Text='<%# Eval("sr") %>'></asp:Label>
                                                </td>
                                               <%-- <td style="text-align: center">
                                                    <asp:Image ID="imgCategory" Width="75px" Height="50px" runat="server"></asp:Image>
                                                </td>--%>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# Eval("pid") %>'></asp:Label>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>

                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>

                                                </td>

                                                <td style="text-align: center">
                                                    <asp:Label ID="lblmrp" runat="server" Text='<%# Eval("mrp") %>'></asp:Label>

                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblrate" runat="server" Text='<%# Eval("rate") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblsubtot" runat="server" Text='<%# Eval("totalvalue") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: center">
                                                    <asp:Label ID="lblgst" runat="server" Text='<%# Eval("gst") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: center">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("gstamt") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: center">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("totalamt") %>'></asp:Label>
                                                </td>


                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <%--<tfoot>
                                        <tr>

                                            <th style="text-align: center">Image</th>

                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </tfoot>--%>
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




