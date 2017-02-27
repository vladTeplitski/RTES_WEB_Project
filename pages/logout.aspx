<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="logout.aspx.cs" Inherits="logout" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

                <!-- logout -->
            <div class="text-center" style="padding: 10px 0">
                

                <div class="login-form-1" >
                    
                    
                    <form runat="server"  class="text-left">
                        <div class="login-form-main-message"></div>
                        <div class="main-login-form" style="background-color:#5A95C9; border:1px solid #77A8D2; border-radius: 3px; color:white;padding:5px;margin-top:10px;width:100%">
                            Are you sure you want to logout ?
                             <asp:Button runat="server" OnClick="logout_func" type="submit" Text="Logout" CssClass="btn btn-default submitMy" Style="margin-left:35%"/>
                        </div>
                    </form>
                </div>


                
                <!-- end login -->
            </div>
</asp:Content>
