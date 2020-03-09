<%@ Page Title="" Language="C#" MasterPageFile="~/superadmin.master" AutoEventWireup="true" CodeFile="manageState.aspx.cs" Inherits="manageState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
  <div style="text-align: right">
        <asp:Button ID="btnNewCompany" runat="server" Text="Add State" CssClass="btn btn-danger" OnClick="btnNewCompany_Click" />
    </div>
    <div class="text-center">
        <b id="spnMessage" visible="false" runat="server"></b>
    </div>
    <br />
    <table id="tblCategory" class="display table table-hover table-striped table-bordered">
        <thead>
            <tr class="tableheader">
                <th style="text-align: center">CountryName</th>
                 <th style="text-align: center">StateName</th>
                
                <th style="text-align: center">Action</th>

               
                 
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repCompany" runat="server" OnItemDataBound="repCompany_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="lblCompanyId" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                            <asp:Label ID="lblProductCount" runat="server" Visible="false" Text='<%# Eval("productcount") %>'></asp:Label>
                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
                        </td>  
                      
                        
                           <td style="text-align: center">
                                <asp:Label ID="lblbank"  runat="server" Text='<%# Eval("statename") %>'></asp:Label>
                            </td>                      
                              
                        <td style="text-align: center">
                            <asp:HyperLink ID="hlEdit" runat="server" Style="text-decoration: underline" CssClass="btn btn-sm btn-success" Text="Edit"></asp:HyperLink>&nbsp;
                            &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Do you want to delete this category?');" OnClick="lnkDelete_Click"></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <script src="js/datatables.js" type="text/javascript"></script>
    <link href="js/datatables.css" rel="stylesheet" />
    <script src="datatable/jquery.dataTables.min.js"></script>
    <script src="datatable/dataTables.buttons.min.js"></script>
    <script src="datatable/jszip.min.js"></script>
    <script src="datatable/pdfmake.min.js"></script>
    <script src="datatable/vfs_fonts.js"></script>
    <script src="datatable/buttons.html5.min.js"></script>
    <link href="datatable/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="datatable/buttons.dataTables.min.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $('#tblCategory').DataTable({
                "bLengthChange": true,
                "iDisplayLength": 50,
                "bFilter": true,
                "bInfo": true,
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5',
                ]
            });
        });
    </script>
</asp:Content>

