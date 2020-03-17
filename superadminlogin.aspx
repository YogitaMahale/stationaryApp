﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="superadminlogin.aspx.cs" Inherits="superadminlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="Template/bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="Template/bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="Template/bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="Template/dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="Template/plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <link rel="shortcut icon" href="uploads/mgcagro.png" />

</head>

<body class="hold-transition login-page">

    <div class="login-box">
        <div class="login-logo">
            <a href="#"><b>Login</b></a>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg">Sign in to start your session</p>

            <form id="form1" runat="server">
                <b id="bMsg" class="text-center" style="color: red" runat="server"></b>
                <div class="form-group has-feedback">

                    <asp:TextBox ID="txtUserName" CssClass="form-control" MaxLength="50" runat="server" placeholder="User Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtUserName" CssClass="fbold" runat="server" Display="Dynamic" ControlToValidate="txtUserName" ErrorMessage="*" ValidationGroup="l1" Font-Bold="True" Font-Size="Larger" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                    <%-- <input type="email" class="form-control" placeholder="Email">--%>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtPassword" CssClass="fbold" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="l1" Font-Bold="True" Font-Size="Larger" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <%--<input type="password" class="form-control" placeholder="Password">--%>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                   <%-- <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <input type="checkbox">
                                Remember Me
           
                            </label>
                        </div>
                    </div>--%>
                    <!-- /.col -->
                    <div class="col-xs-12">
                        <asp:Button ID="btnLogin" runat="server" class="btn btn-primary btn-block btn-flat" ValidationGroup="l1" Text="Login" OnClick="btnLogin_Click" />
                        <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>--%>
                    </div>
                    <!-- /.col -->
                </div>
            </form>

            <div class="social-auth-links text-center" style="display: none;">
                <p>- OR -</p>
                <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i>Sign in using
        Facebook</a>
                <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i>Sign in using
        Google+</a>
            </div>
            <!-- /.social-auth-links -->

            <%-- <a href="#">I forgot my password</a><br>
            <a href="#" class="text-center">Register a new membership</a>--%>
        </div>
        <!-- /.login-box-body -->
    </div>

    <!-- /.login-box -->

    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="Template/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
</script>
</body>
</html>
