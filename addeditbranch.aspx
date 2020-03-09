<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="addeditbranch.aspx.cs" Inherits="addeditbranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">

        <!-- left column -->
        <div class="col-lg-12">
            <!-- general form elements -->
            <div class="box box-success">
                <div class="box-header">
                    <h3 class="box-title"><b id="spnMessage" runat="server"></b></h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">
                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Bank</label>
                            <asp:DropDownList ID="ddlbank" Class="form-control" runat="server" OnSelectedIndexChanged="ddlbank_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlbank" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1"> Zone </label>
                            <asp:DropDownList ID="ddlZone" Class="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlZone" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Login Name </label>
                            <asp:TextBox ID="txtloginname" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtloginname" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Password </label>
                            <asp:TextBox ID="txtpassword" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtpassword" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        
                    </div>

                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Email Id</label>
                            <asp:TextBox ID="txtemail" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="txtemail" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Name </label>
                            <asp:TextBox ID="txtname" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ControlToValidate="txtname" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">IFS Code</label>
                            <asp:TextBox ID="txtifsc" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ControlToValidate="txtifsc" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">MICR Code </label>
                            <asp:TextBox ID="txtmicr" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ControlToValidate="txtmicr" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        
                    </div>

                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">GST No </label>
                            <asp:TextBox ID="txtgstno" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtgstno" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Apartment</label>
                            <asp:TextBox ID="txtapartment" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ControlToValidate="txtapartment" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Road</label>
                            <asp:TextBox ID="txtroad" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" ControlToValidate="txtroad" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">State</label>
                            <asp:DropDownList ID="ddlState" Class="form-control" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlState" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        
                    </div>

                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">City </label>
                            <asp:DropDownList ID="ddlCity" Class="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlCity" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Pin Code</label>
                            <asp:TextBox ID="txtpincode" Class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ControlToValidate="txtpincode" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Branch Code</label>
                            <asp:TextBox ID="txtbranchcode" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic" ControlToValidate="txtbranchcode" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Phone</label>
                            <asp:TextBox ID="txtphone" Class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ControlToValidate="txtphone" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtphone" ValidationGroup="gg" ValidationExpression="^\d+" ErrorMessage="Enter valid number" Font-Bold="True" Font-Size="Large" />
                        </div>
                        
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-3 col-md-6">
                            <label for="exampleInputEmail1">Mobile No</label>
                            <asp:TextBox ID="txtmobileno" Class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtmobileno" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmobileno" ValidationGroup="gg" ValidationExpression="^\d+" ErrorMessage="Enter valid number" Font-Bold="True" Font-Size="Large" />
                        </div>
                        <div class="col-lg-6">
                            <label for="exampleInputEmail1">Address</label>
                            <asp:TextBox ID="txtaddress" Class="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ControlToValidate="txtpincode" CssClass="error" ErrorMessage="*" ValidationGroup="p1"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>



                </div>
                <!-- /.box-body -->

                <div class="box-footer" style="text-align: center">
                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="p1" Text="Save" class="btn btn-info btn-lg" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-danger  btn-lg" Text="Cancel" OnClick="btnCancel_Click" />


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

