<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Hotel_ERP_UI.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password Page</title>
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
                             <div class="text-center mb-5">
                                <a href="#">
                                    <img src="/assets/img/logo.png" alt="logo" height="60" width="190" /></a>
                            </div>
                            <div class="mb-4">
                                <h3 class="mb-2"><b>Reset Password</b></h3>
                                <p class="text-muted">Please choose your new password</p>
                            </div>
                            <div class="form-group mb-3">
                                <label class="form-label">Password</label>
                                <input type="password" class="form-control" id="floatingInput" placeholder="Password" />
                            </div>
                            <div class="form-group mb-3">
                                <label class="form-label">Confirm Password</label>
                                <input type="password" class="form-control" id="floatingInput1" placeholder="Confirm Password" />
                            </div>
                            <div class="d-grid mt-4">
                                <button type="button" onclick="window.location.href='login.aspx'" class="btn btn-primary">Reset Password</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
