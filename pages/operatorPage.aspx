<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="operatorPage.aspx.cs" Inherits="operatorPage" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>


<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="container-fluid" ng-controller="operatorController">

        <!--START Operator Page-->
        <div class="row bodyRow operatorWindow">

            <div class="col-lg-3 col-lg-offset-1 col-md-4 col-md-offset-0 col-xs-8 col-xs-offset-2">
                <div class="getStartedBox" style="position: relative; margin-top: 8px; margin-bottom: 8px;">
                    <div class="btnInfo_report">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                        View Current Cases
                    </div>
                    </a>
                <div class="btnInfo btn2">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    Reports Library
                    </div>
                    </a>
               <div class="btnInfo btn2">
                   <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-pencil"></i></div>
                   Send Message To Client
                    </div>
                    </a>
                <div class="btnInfo btn2">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    View Client Details
                    </div>
                </div>
            </div>
        </div>



    </div>

</asp:Content>
