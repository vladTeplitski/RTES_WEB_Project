<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

                <!-- start login -->
            <div class="text-center" style="padding: 10px 0; ">
                

                <div class="login-form-1" style="background-color:white; border:1px solid #6394C0;" >
                    
                    
                    <form runat="server"  class="text-left" >
                        <div class="login-form-main-message"></div>
                        <div class="main-login-form">
                            <div class="login-group">
                                <div class="form-group">
                                    <label for="lgUser" class="sr-only">Username</label>
                                    <asp:TextBox runat="server" TextMode="SingleLine" CssClass="form-control" ID="lgUser" placeholder="User Name"/>
                                
                                </div>
                                <div class="form-group">
                                    <label for="lgPass" class="sr-only">Password</label>
                                    <asp:TextBox runat="server" TextMode="password" CssClass="form-control" ID="lgPass" placeholder="password"/>
                                </div>
                                <div class="form-group login-group-checkbox">
                                    <input type="checkbox" id="lg_remember" name="lg_remember">
                                    <label for="lg_remember">remember</label>
                                </div>
                            </div>
                             <asp:LinkButton runat="server" OnClick="login_Func" type="submit" class="login-button"><i Style="font-size:23px;" class="fa fa-chevron-right"></i></asp:LinkButton>
                        <!--<i class="fa fa-chevron-right"></i>-->
                        </div>
                    </form>
                </div>


                
                <!-- end login -->
            </div>

            <div style="width: 400px; margin: 10px auto; text-align: center; padding: 8px 0px">
            <asp:Panel runat="server" CssClass="alert alert-danger" ID="pnlMessage" Visible="false">
                Invalid user name or password, please try again.
            </asp:Panel>
        </div>
    



</asp:Content>
