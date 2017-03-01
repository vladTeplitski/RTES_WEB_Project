<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="operatorPage.aspx.cs" Inherits="operatorPage" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../inc/angularScript.js"></script>

</asp:Content>


<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="container-fluid" ng-controller="operatorController">

        <!--START Operator Page-->
        <div class="row bodyRow operatorWindow">

            <div class="col-lg-3 col-lg-offset-1 col-md-4 col-md-offset-0 col-xs-8 col-xs-offset-2">
                <div class="getStartedBox" style="position: relative; margin-top: 8px; margin-bottom: 8px;">
                <div class="btnInfo btn1">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    View Current Cases
                </div>
     
                <div class="btnInfo btn2">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    Reports Library
                </div>

               <div class="btnInfo btn3">
                   <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-pencil"></i></div>
                   Send Message To Client
               </div>
  
                <div class="btnInfo btn4">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                    View Client Details
                </div>
                
                <a href="clientMainPage.aspx">
                <div class="btnInfo btn5">
                    <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-th-large"></i></div>
                    Client CP
                </div>
                </a>
                </div>
            </div>

            <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-12">
            <div class="mainWindow">
                <div class="textContainer chapter1">
                    operator Home.
                </div>
                <div class="textContainer chapter2">
                    Current Cases
                </div>
                <div class="textContainer chapter3">
                    Reports Library
                </div>
                <div class="textContainer chapter4">
                    Message to client
                </div>
                <div class="textContainer chapter5">
                    View client details
                </div>
            </div>

            </div>

        </div>



    </div>

</asp:Content>
