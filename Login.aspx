<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Patient Registration System | Log in (v2)</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <!-- /.login-logo -->
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <a href="#" class="h1">Patient Registration System</a>
    </div>
      <form runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  
       
    <div class="card-body">
      <p class="login-box-msg">Sign in to start your session</p>
           <asp:Login ID="Login1" runat="server">
                 <LayoutTemplate>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
            <div class="form-group">
                    <label>User Name</label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
   
                  </div>
            <div class="form-group">
                    <label>Password</label>
                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="" TextMode="Password"></asp:TextBox>
   
                  </div>
        </ContentTemplate>
      </asp:UpdatePanel>
                     </LayoutTemplate>
                </asp:Login>
        <div class="row">
          <div class="col-8">
           <asp:Label ID="FailureText" runat="server" Text=""></asp:Label>
          </div>
          <!-- /.col -->
          <div class="col-4">
           <asp:LinkButton ID="LinkButton4" CssClass="btn btn-primary float-right"
                                                        runat="server" OnClick="btn_submit_Click">Sign In</asp:LinkButton>
          </div>
          <!-- /.col -->
        </div>
   

     
      <!-- /.social-auth-links -->

      
    </div>
             
 
          </form>
    <!-- /.card-body -->

  </div>
  <!-- /.card -->
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>

