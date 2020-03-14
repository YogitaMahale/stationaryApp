<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderinvoice.aspx.cs" Inherits="orderinvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Order Invoice</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="Template/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="Template/bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="Template/bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="Template/dist/css/AdminLTE.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="Template/plugins/iCheck/square/blue.css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

    <link rel="shortcut icon" href="uploads/mgcagro.png" />
    <style type="text/css">
        /*body{
    background-color: #525252; #e3dee0; #ebccd1;
}*/
.centered-form{
	margin-top: 60px;
}

.centered-form .panel{
	/*background: rgba(255, 255, 255, 0.8);*/
	box-shadow: rgba(0, 0, 0, 0.3) 20px 20px 20px;
}
    </style>
</head>
<body style="background-color: #525252;">
    <%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />--%>

    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="Template/bower_components/bootstrap/dist/css/bootstrap.min.css" />

<!------ Include the above in your HEAD tag ---------->
    <div class="container">
        <form runat="server">
                    <div class="row centered-form">
        <div class="col-lg-12">
        	<div class="panel" >
        		<div class="panel-heading">
			    		<div class="row">
                                <h1>&nbsp;&nbsp;&nbsp; Invoice Order No - #<span id="sminvoiceNo" runat="server" class="text-center"></span>
                                </h1>
                               
                                <div class="col-xs-4">
                                    From
                              <address>
                                  <strong>All Stationary.</strong><br />
                                  <span id="spnFormAddress" runat="server">305-306, Bhaveshwar Arcade LBS Marg , Ghatkopar W Mumbai.
                                  </span>
                                  <br />
                                  Phone: <span id="spnFromPhone" runat="server">(+91 ) 9920104157, 022-25002111</span><br />
                                  
                              </address>
                                </div>
                                <div class="col-xs-4">
                                    To
                            <address>
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
			 			<div class="panel-body">
			    		
                             <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>

                                        <th style="text-align: center">Sr</th>
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
                            </table>
			    	</div>
                <%--<div class="panel-footer" text-align: center">
                                            

                </div>--%>
	    		</div>
    		</div>
    	</div>
        </div>
                        </form>

    </div>
<%--<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>

    
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
</body>

</html>




<%--<%@ Page Title="" Language="C#" MasterPageFile="~/branchMaster.master" AutoEventWireup="true" CodeFile="orderinvoice.aspx.cs" Inherits="orderinvoice" %>

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
                            
                        </div>


                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <h1>&nbsp;&nbsp;&nbsp; Invoice Order No - #<span id="sminvoiceNo" runat="server" class="text-center"></span>
                                </h1>
                               
                                <div class="col-xs-4">
                                    From
                              <address>
                                  <strong>All Stationary.</strong><br />
                                  <span id="spnFormAddress" runat="server">305-306, Bhaveshwar Arcade LBS Marg , Ghatkopar W Mumbai.
                                  </span>
                                  <br />
                                  Phone: <span id="spnFromPhone" runat="server">(+91 ) 9920104157, 022-25002111</span><br />
                                  
                              </address>
                                </div>
                                <div class="col-xs-4">
                                    To
                            <address>
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



--%>
