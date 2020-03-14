<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="addeditCity.aspx.cs" Inherits="addeditCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .error {
            color: red;
        }
    </style>
    <script type="text/javascript">
        function checkFileExtension() {
            var result = false;
            var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
            if (($("#ctl00_ContentPlaceHolder1_fpProduct").val() == "") || ($("#ctl00_ContentPlaceHolder1_fpProduct").val() == null)) {
                alert("Please Upload Image.")
                result = false;
            }
            else {
                var allowedFiles = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
                var fileUpload = document.getElementById("ctl00_ContentPlaceHolder1_fpProduct");
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <!-- left column -->
                <div class="col-md-6">
                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <div class="box-body">

                            <%--                            <div class="form-group">
                                <label for="exampleInputEmail1">Bank Name </label>
                                <asp:TextBox ID="txtbankName" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVtxtCategoryName" runat="server" Display="Dynamic" ControlToValidate="txtbankName" CssClass="error" ErrorMessage="*" ValidationGroup="c1"></asp:RequiredFieldValidator>
                            </div>
                            --%>


                            <div class="form-group">
                                
                                    <label for="exampleInputEmail1">Country</label>
                                    <asp:DropDownList ID="ddlCountry" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVtxtCategoryName" runat="server" Display="Dynamic" ControlToValidate="ddlCountry" CssClass="error" ErrorMessage="*" ValidationGroup="c1"></asp:RequiredFieldValidator>

                                

                            </div>
                            <div class="form-group">
                                
                                    <label for="exampleInputEmail1">State</label>
                                    <asp:DropDownList ID="ddlState" Class="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="ddlState" CssClass="error" ErrorMessage="*" ValidationGroup="c1"></asp:RequiredFieldValidator>
                                
                            </div>
                            <div class="form-group">
                                
                                    <label for="exampleInputEmail1">City Name</label>
                                    <asp:TextBox ID="txtCityName" Class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtCompanyName" runat="server" Display="Dynamic" ControlToValidate="txtCityName" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                                
                            </div>
                            
                        </div>
                        <!-- /.box-body -->

                        <div class="box-footer">

                            <asp:Button ID="btnSave" runat="server" class="btn btn-danger" CausesValidation="true" ValidationGroup="c1" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlCountry" />
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

</asp:Content>




<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="col-md-8 col-sm-12 col-lg-8 col-md-offset-3 well" style="background-color: white">
        <table class="table table-user-information">
            <tbody>
                <tr id="trMessage" runat="server" visible="false">
                    <td>&nbsp;</td>
                    <td>
                        <b id="spnMessgae" runat="server"></b>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><span style="color: red">* Indicates Required Fields</span> </td>
                </tr>
                <tr>
                    <td style="width: 250px; font-weight: bold">Country: <span style="color: red">*</span></td>
                    <td style="width: 850px">
                         <asp:DropDownList ID="ddlCountry" runat="server" style="height: 34px;width: 291px;" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td>
                    <td> 
                    </td>
                </tr>

                 <tr>
                    <td style="width: 250px; font-weight: bold">State : <span style="color: red">*</span></td>
                    <td style="width: 850px">
                         <asp:DropDownList ID="ddlState" runat="server" style="height: 34px;width: 291px;" AutoPostBack="true"></asp:DropDownList></td>
                    <td> 
                    </td>
                </tr>


                <tr>
                    <td style="width: 250px; font-weight: bold">City Name <span style="color: red">*</span></td>
                    <td style="width: 850px">
                        <asp:TextBox ID="txtCityName" CssClass="form-control" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVtxtCompanyName" runat="server" Display="Dynamic" ControlToValidate="txtCityName" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="c1" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn btn-info" OnClick="btnCancel_Click" Text="Cancel" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>--%>