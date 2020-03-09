<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="addeditCountry.aspx.cs" Inherits="addeditCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <td style="width: 250px; font-weight: bold">Country Code <span style="color: red">*</span></td>
                    <td style="width: 850px">
                        <asp:TextBox ID="txtCountrycode" CssClass="form-control" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVtxtCompanyName" runat="server" Display="Dynamic" ControlToValidate="txtCountrycode" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                

                <tr>
                    <td style="width: 250px; font-weight: bold">Country Name <span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtCountryName" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVtxtCompanyShortDescription" runat="server" Display="Dynamic" ControlToValidate="txtCountryName" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>
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
</asp:Content>