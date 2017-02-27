<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- start register -->
            <div class="text-center" style="padding: 10px 0">

                <!-- Main Form -->
                <div class="login-form-1">
                    <form id="register-form" class="text-left" style="background-color:white; border:1px solid #6394C0;">
                        <div class="login-form-main-message"></div>
                        <div class="main-login-form">
                            <div class="login-group">
                                <div class="form-group">
                                    <label for="reg_username" class="sr-only">Email address</label>
                                    <input type="text" class="form-control" id="reg_username" name="reg_username" placeholder="username">
                                </div>
                                <div class="form-group">
                                    <label for="reg_password" class="sr-only">Password</label>
                                    <input type="password" class="form-control" id="reg_password" name="reg_password" placeholder="password">
                                </div>
                                <div class="form-group">
                                    <label for="reg_password_confirm" class="sr-only">Password Confirm</label>
                                    <input type="password" class="form-control" id="reg_password_confirm" name="reg_password_confirm" placeholder="confirm password">
                                </div>

                                <div class="form-group">
                                    <label for="reg_email" class="sr-only">Email</label>
                                    <input type="text" class="form-control" id="reg_email" name="reg_email" placeholder="email">
                                </div>
                                <div class="form-group">
                                    <label for="reg_fullname" class="sr-only">Full Name</label>
                                    <input type="text" class="form-control" id="reg_fullname" name="reg_fullname" placeholder="full name">
                                </div>

                                <div class="form-group login-group-checkbox">
                                    <input type="radio" class="" name="reg_gender" id="male" placeholder="username">
                                    <label for="male">male</label>

                                    <input type="radio" class="" name="reg_gender" id="female" placeholder="username">
                                    <label for="female">female</label>
                                </div>

                                <div class="form-group login-group-checkbox">
                                    <input type="checkbox" class="" id="reg_agree" name="reg_agree">
                                    <label for="reg_agree">i agree with <a ng-click="$event.preventDefault();" href="#">terms</a></label>
                                </div>
                            </div>
                            <button ng-click="$event.preventDefault();" type="submit" class="login-button"><i class="fa-chevron-right"></i></button>
                        </div>
                    </form>
                </div>
                <!-- end:Main Form -->
            </div>
            <!-- end register -->


</asp:Content>
