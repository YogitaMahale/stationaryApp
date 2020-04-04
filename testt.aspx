<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="testt.aspx.cs" Inherits="testt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        /*.style1
        {
            width: 672px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div>
    <table >
        <asp:DataList ID="DataList1" runat="server">
        <HeaderTemplate>
        <h1> Details </h1>
        </HeaderTemplate>
      <ItemTemplate>
       
        <tr>
        <td><h5><%#Eval("id") %></h5></td>
         <td><h5><%#Eval("productname") %></h5></td>
          <td><h5><%#Eval("mainimage") %></h5></td>
           <td><h5><%#Eval("mrp") %></h5></td>
            <td><h5><%#Eval("mrp") %></h5></td>
        </tr>
        </ItemTemplate>
        </asp:DataList>
       </table>
   <table>
  <tr>
    <td>
        <asp:Button ID="btnfirst" runat="server" Font-Bold="true" Text="<<" Height="31px"
                    Width="43px" onclick="btnfirst_Click" /></td>
        <td>
            <asp:Button ID="btnprevious" runat="server" Font-Bold="true" Text="<" Height="31px"
                    Width="43px" onclick="btnprevious_Click" /></td>
            <td>
                <asp:Button ID="btnnext" runat="server" Font-Bold="true" Text=">" Height="31px"
                    Width="43px" onclick="btnnext_Click" /></td>
                <td>
                    <asp:Button ID="btnlast" runat="server" Font-Bold="true" Text=">>" Height="31px"
                    Width="43px" onclick="btnlast_Click" /></td>
    </tr>
   </table>
    </div>
</asp:Content>

