<%@ Page Title="" Language="C#" MasterPageFile="~/branchMaster.master" AutoEventWireup="true" CodeFile="branchdashboard.aspx.cs" Inherits="branchdashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Image {
            /*width: 475px;*/
            margin: 0px auto;
            text-align: center;
            padding: 20px;
            /*border: 1px dashed gray;*/
            background-color: #ecf0f5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="row">
                <asp:TextBox ID="TextBox1" Visible="false" runat="server" Text="fdsf"></asp:TextBox>
                <div class="box-body">
                    <div class="Image col-lg-12">
                        <asp:Image ID="img1" runat="server"
                            Height="400px" class="col-lg-12"
                            ImageUrl="~/images/Autumn Leaves.jpg" />

                    </div>
                    <%--Height="400px" Width="400px"--%>
                    <cc1:SlideShowExtender ID="SlideShowExtender1" runat="server"
                        BehaviorID="SSBehaviorID"
                        TargetControlID="img1"
                        SlideShowServiceMethod="GetSlides"
                        AutoPlay="true"
                        ImageDescriptionLabelID="lblDesc"
                        NextButtonID="btnNext"
                        PreviousButtonID="btnPrev"
                        PlayButtonID="btnPlay"
                        PlayButtonText="Play"
                        StopButtonText="Stop"
                        Loop="true">
                    </cc1:SlideShowExtender>
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="btnPrev" runat="server" Text="Previous" />
                        <asp:Button ID="btnPlay" runat="server" Text="" />
                        <asp:Button ID="btnNext" runat="server" Text="Next" />
                    </div>


                    <div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


