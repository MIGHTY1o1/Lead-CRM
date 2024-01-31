<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Hotel_ERP_UI.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password Page</title>
    <!-- [Font] Family -->
    <link rel="stylesheet" href="/assets/css/inter.css" id="main_font_link" />
    <!-- [Tabler Icons] https://tablericons.com -->
    <link rel="stylesheet" href="/assets/css/tabler-icons.min.css" />
    <!-- [Feather Icons] https://feathericons.com -->
    <link rel="stylesheet" href="/assets/css/feather.css" />
    <!-- [Font Awesome Icons] https://fontawesome.com/icons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- [Template CSS Files] -->
    <link rel="stylesheet" href="/assets/css/style.css" id="main_style_link" />
    <link rel="stylesheet" href="/assets/css/style-preset.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="auth-main">
            <div class="auth-wrapper v1">
                <div class="auth-form">
                    <div class="card my-5">
                        <div class="card-body">
                            <div class="text-center">
                                <a href="#">
                                    <img src="/assets/img/logo.png" alt="logo" height="60" width="190" /></a>
                            </div>
                            <div class="d-flex justify-content-between align-items-end mb-4 mt-4">
                                <h3 class="mb-0"><b>Forgot Password</b></h3>
                                
                            </div>
                            <div class="form-group mb-3">
                                <label class="form-label">Email Address</label>
                                <input type="email" class="form-control" id="floatingInput" placeholder="Email Address" />
                            </div>
                            <p class="text-center"><a href="login.aspx" class="link-primary">Back to Login</a></p>
                            <div class="d-grid mt-3">
                                <button type="button"onclick="window.location.href='VerificationCode.aspx'" class="btn btn-primary">Send Password Reset Email</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
