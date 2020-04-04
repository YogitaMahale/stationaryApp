<%@ Page Title="" Language="C#" MasterPageFile="~/websitemaster.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
<style>
        #active {
            color:  #ff0052 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Content -->
  <div id="content"> 
    
    <!--======= CONATACT  =========-->
    <section class="contact padding-top-100 padding-bottom-100">
      <div class="container">
        <div class="contact-form">
          <h5>PLEASE fill-up FEW details</h5>
          <div class="row">
            <div class="col-md-12"> 
              
              <!--======= Success Msg =========-->
              <div id="contact_message" class="success-msg"> <i class="fa fa-paper-plane-o"></i>Thank You. Your Message has been Submitted</div>
              
              <!--======= FORM  =========-->
              <form role="form" id="contact_form" class="contact-form" method="post" onSubmit="return false">
                <ul class="row">
                  <li class="col-sm-5">
                    <label>full name *
                        <asp:TextBox ID="txtfullname" class="form-control"  runat="server"></asp:TextBox>
                         
                    </label>
                  </li>
                   <li class="col-sm-1">
                       <br />
                       <span> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="p" ErrorMessage="*"   ControlToValidate="txtfullname" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </span>
                  
                  </li>
                  <li class="col-sm-5">
                    <label>Email *
                        <asp:TextBox ID="txtemail" class="form-control"  runat="server"></asp:TextBox>
                       
                          <%--<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>--%>
                    </label>
                  </li>
                    <li class="col-sm-1">
                       <br />
                       <span> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="p" ErrorMessage="*"   ControlToValidate="txtemail" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        </span>
                  
                  </li>
                  <li class="col-sm-6">
                    <label>Phone *
                         <asp:TextBox ID="txtphone" class="form-control"  runat="server"></asp:TextBox>
                  
                        
                    </label>
                  </li>
                  <li class="col-sm-6">
                    <label>SUBJECT
                        <asp:TextBox ID="txtsubject" class="form-control"  runat="server"></asp:TextBox>
                       
                    </label>
                  </li>
                  <li class="col-sm-12">
                    <label>Message
                       <asp:TextBox ID="txtmessage" Rows="5" TextMode="MultiLine" class="form-control"  runat="server" ></asp:TextBox>
                     
                    </label>
                  </li>
                  <li class="col-sm-12">
                      <asp:Button ID="Button1" class="btn"  runat="server" validationgroup="p" Text="SEND " OnClick="Button1_Click" />
                     
                  </li>
                </ul>
              </form>
            </div>
            
            <!--======= ADDRESS INFO  =========-->
            <%--<div class="col-md-4">
              <div class="contact-info">
                <h6>OUR ADDRESS</h6>
                <ul>
                  <li> <i class="icon-map-pin"></i> Street No. 12, Newyork 12,<br>
                    MD - 123, USA.</li>
                  <li> <i class="icon-call-end"></i> 1.800.123.456789</li>
                  <li> <i class="icon-envelope"></i> <a href="mailto:someone@example.com" target="_top">info@PAVSHOP.com</a> </li>
                  <li>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam erat turpis, pellentesque non leo eget.</p>
                  </li>
                </ul>
              </div>
            </div>--%>
          </div>
        </div>
      </div>
    </section>
    
    <!--======= MAP =========-->
    <div id="map"></div>
    
    <!-- About -->
    <%--<section class="small-about padding-top-150 padding-bottom-150">
      <div class="container"> 
        
        <!-- Main Heading -->
        <div class="heading text-center">
          <h4>about PAVSHOP</h4>
          <p>Phasellus lacinia fermentum bibendum. Interdum et malesuada fames ac ante ipsumien lacus, eu posuere odio luctus non. Nulla lacinia,
            eros vel fermentum consectetur, risus purus tempc, et iaculis odio dolor in ex. </p>
        </div>
        
        <!-- Social Icons -->
        <ul class="social_icons">
          <li><a href="#."><i class="icon-social-facebook"></i></a></li>
          <li><a href="#."><i class="icon-social-twitter"></i></a></li>
          <li><a href="#."><i class="icon-social-tumblr"></i></a></li>
          <li><a href="#."><i class="icon-social-youtube"></i></a></li>
          <li><a href="#."><i class="icon-social-dribbble"></i></a></li>
        </ul>
      </div>
    </section>--%>
    
  
  </div>
   <script src="ecommerce/js/jquery-1.11.3.min.js"></script>
    <!-- Begin Map Script --> 
<script type='text/javascript' src='http://maps.google.com/maps/api/js?sensor=false'></script> 
<script type="text/javascript">
/*==========  Map  ==========*/
var map;
function initialize_map() {
if ($('#map').length) {
	var myLatLng = new google.maps.LatLng(-37.814199, 144.961560);
	var mapOptions = {
		zoom: 17,
		center: myLatLng,
		scrollwheel: false,
		panControl: false,
		zoomControl: true,
		scaleControl: false,
		mapTypeControl: false,
		streetViewControl: false
	};
	map = new google.maps.Map(document.getElementById('map'), mapOptions);
	var marker = new google.maps.Marker({
		position: myLatLng,
		map: map,
		tittle: 'Envato',
		icon: './images/map-locator.png'
	});
} else {
	return false;
}}
google.maps.event.addDomListener(window, 'load', initialize_map);
</script>
     <script>
        $("a[href='Contact.aspx']").attr("id", "active");
        
    </script>
</asp:Content>

