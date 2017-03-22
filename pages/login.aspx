<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div ng-controller="mainController">

            <!-- start login page -->
            <div class="text-center" style="padding: 10px 0; ">
                
                <div class="login-form-1" style="background-color:white; border:1px solid #6394C0;width:50%" >
                    
                    <form runat="server" name="myLogin" class="text-left" >
                        <div class="login-form-main-message"></div>
                        <div toolstyle="toolcssBottomWide" toolinfo="Please use your username and password provided by the insurance company!" tooltip class="main-login-form">
                            <div class="login-group">
                                <div class="form-group">
                                    <asp:TextBox  ng-keypress="loginField()" ng-click="loginFieldclick()" ng-mouseleave="loginFieldleave()" ng-model="lgUser" type="text"  runat="server" TextMode="SingleLine" CssClass="form-control" ID="lgUser" name="lgUser" placeholder="User Name" ng-required="true"/>
                                    <span ng-hide="!lgUser.length" ng-hide="validUser" Style="color:lightgreen;padding-left:5px;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                                    <span ng-hide="notValidUser" Style="color:red;padding-left:5px;" class="glyphicon glyphicon-remove form-control-feedback"></span>
                                    <span ng-show="!lgUser.length" Style="color:#FFC600;padding-left:5px;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ng-keypress="loginPass()" ng-keydown="loginPass()" ng-keyup="loginPass()" ng-click="loginPassclick()" ng-mouseleave="loginFieldleave()" ng-model="lgPass" runat="server" TextMode="password" class="logInput" CssClass="form-control" ID="lgPass" name="lgPass" placeholder="password" ng-required="true"/>
                                    <span ng-hide="validPass" Style="color:lightgreen;padding-left:5px;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                                    <span ng-hide="notValidPass" Style="color:red;padding-left:5px;" class="glyphicon glyphicon-remove form-control-feedback"></span>
                                    <span ng-show="!lgPass.length" Style="color:#FFC600;padding-left:5px;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                                 </div>
                            </div>
                                 <asp:LinkButton runat="server" OnClick="login_Func" type="submit" class="login-button"><i Style="font-size:23px;" class="fa fa-chevron-right"></i></asp:LinkButton>
                         </div>
                    </form>
                </div>

               
                    <div class="loginAlertBoxCss">
                    <div class="alert alert-success" ID="panel1">
                       {{loginText}}
                     </div>
                     </div>
                 

                
                <!-- end login -->
            </div>

            <div style="width: 50%; margin: 3px auto; text-align: center; padding: 8px 0px">
            <asp:Panel runat="server" CssClass="alert alert-danger" ID="pnlMessage" Visible="false">
                Invalid user name or password, please try again.
            </asp:Panel>
            </div>

</div>
</asp:Content>
