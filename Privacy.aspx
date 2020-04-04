<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Privacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        #active {
            color:  #ff0052 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="content"> 
    
    <!-- History -->
    <section class="history-block padding-top-100 padding-bottom-100">
      <div class="container">
        <div class="row">
          <div class="col-xs-10 center-block">
            <div class="col-sm-10 center-block">
              <h4>A Brief History</h4>
              <p runat="server" id="lblabout">

              </p>
              
             <%-- <!-- IMG -->
              <div class="relative"> <img class="img-responsive margin-top-80 margin-bottom-80" src="ecommerce/images/about-img-1.jpg" alt="">
                <div class="position-center-center"> <span class="huge-text">our team
                  united by love</span> </div>
              </div>
              <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam volutpat dui at lacus aliquet, a consequat enim aliquet. Integer molestie sit amet sem et faucibus. Nunc ornare pharetra dui, vitae auctor orci fringilla eget. Pellentesque in placerat felis. Etiam mollis venenatis luctus. Morbi ac scelerisque mauris. Etiam sodales a nulla ornare viverra. Nunc at blandit neque, bibendum varius purus. <br>
                <br>
                Nam sit amet sapien vitae enim vehicula tincidunt. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc faucibus imperdiet vulputate. Morbi volutpat leo iaculis elit vehicula, eu convallis magna finibus. Suspendisse tristique ullamcorper erat a elementum. Cras eget elit non nunc aliquam ullamcorper quis sed metus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada, erat in ullamcorper bibendum, elit lacus mattis lorem, quis luctus diam lorem vel ligula. </p>
              <img class="margin-top-50" src="images/signature.jpg" alt="" > --%>

            </div>
          </div>
        </div>
      </div>
    </section>
    
   
  </div>
     <script src="ecommerce/js/jquery-1.11.3.min.js"></script>
     <script>
        $("a[href='Privacy.aspx']").attr("id", "active");
        
    </script>
</asp:Content>

