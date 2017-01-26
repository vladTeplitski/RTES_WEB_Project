<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="homePage.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="json/infoTexts.json"></script>

    <script src="inc/funcLib.js"></script>
    <script src="inc/angularScript.js"></script>


    <!--Home Page container-->

    <div class="row bodyRow homeWindow" ng-controller="mainController">

        <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-6">
            <div class="mainWindow">
                <div class="textContainer chapter1">
                    {{ welcomeText }}
                        <br />
                </div>
                <div class="textContainer chapter2">
                    {{ theServiceText }}
                        <br />
                </div>
                <div class="textContainer chapter3">
                    {{ registrationText }}
                </div>
                <div class="textContainer chapter4">
                    {{ emergencyText }}
                </div>
                <div class="textContainer chapter5">
                    {{ appraisingText }}
                </div>
                <div class="textContainer chapter6">
                    {{ towingText }}
                </div>
            </div>

        </div>

        <div class="col-lg-3 col-lg-offset-1 col-md-4 col-xs-6">
            <div class="getStartedBox" style="position: relative;">
                <div class="btnInfo btn1">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-bank"></i></div>
                    The service</div>
                <div class="btnInfo btn2">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-list-alt"></i></div>
                    Registration</div>
                <div class="btnInfo btn3">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-heartbeat"></i></div>
                    Emergency</div>
                <div class="btnInfo btn4">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-bar-chart"></i></div>
                    Appraising</div>
                <div class="btnInfo btn5">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-truck"></i></div>
                    Towing Service</div>

            </div>
        </div>

    </div>
    <!--END Home Page-->
</asp:Content>

