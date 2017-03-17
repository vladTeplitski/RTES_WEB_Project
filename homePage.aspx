<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="homePage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--Home Page container-->
    <div class="row bodyRow homeWindow" ng-controller="mainController">

        <!-- Start home information switching content -->

        <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-6">
            <div class="mainWindow">
                <div ng-hide="home0" class="textContainer">
                    {{ welcomeText }}
                        <br />
                    <asp:Literal runat="server" ID="vladLabel"></asp:Literal>
                </div>
                <div ng-hide="home1" class="textContainer">
                    {{ theServiceText }}
                        <br />
                </div>
                <div ng-hide="home2" class="textContainer">
                    {{ registrationText }}
                </div>
                <div ng-hide="home3" class="textContainer">
                    {{ emergencyText }}
                </div>
                <div ng-hide="home4" class="textContainer">
                    {{ appraisingText }}
                </div>
                <div ng-hide="home5" class="textContainer">
                    {{ towingText }}
                </div>
            </div>

        </div>

        <!-- Start home information content buttons  -->

        <div class="col-lg-3 col-lg-offset-1 col-md-4 col-xs-6">
            <div class="getStartedBox" style="position: relative;">
                <div ng-click="buttonsClick(1)" class="btnInfo">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-bank"></i></div>
                    The service</div>
                <div ng-click="buttonsClick(2)" class="btnInfo">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-list-alt"></i></div>
                    Registration</div>
                <div ng-click="buttonsClick(3)" class="btnInfo">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-heartbeat"></i></div>
                    Emergency</div>
                <div ng-click="buttonsClick(4)" class="btnInfo">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-bar-chart"></i></div>
                    Appraising</div>
                <div ng-click="buttonsClick(5)" class="btnInfo">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-truck"></i></div>
                    Towing Service</div>

            </div>
        </div>

    </div>
    <!--END Home Page-->
</asp:Content>

