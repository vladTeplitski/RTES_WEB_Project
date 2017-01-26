<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="clientPage.aspx.cs" Inherits="clientPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script src="inc/angularScript.js"></script>
<script src="inc/funcLib.js"></script>
<script src="json/infoTexts.json"></script>


<div class="container-fluid" ng-controller="clientController">

    <!--Client container-->



    <!--START Client Page-->
    <div class="row bodyRow clientWindow">

        <div class="col-lg-3 col-lg-offset-1 col-md-4 col-md-offset-0 col-xs-8 col-xs-offset-2">
            <div class="getStartedBox" style="position:relative;margin-top:8px;margin-bottom:8px;">
                <a href="emergForm.aspx"><div class="btnInfo_report"><div style="display:inline;position:absolute;left:8px;"><i class="glyphicon glyphicon-pencil"></i></div>New Report</div></a>
                <div class="btnInfo btn2"><div style="display:inline;position:absolute;left:8px;"><i class="glyphicon glyphicon-folder-open"></i></div>Reports Library</div>
                <div class="btnInfo btn3"><div style="display:inline;position:absolute;left:8px;"><i class="glyphicon glyphicon-cog"></i></div>Preferences</div>
                <div class="btnInfo btn4"><div style="display:inline;position:absolute;left:8px;"><i class="fa fa-info-circle" aria-hidden="true" style="font-size:20px;"></i></div>Personal Details</div>

            </div>
        </div>

        <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-12">

            <!-- client content -->
            <div class="mainWindow" style="margin-top:8px;">
                <div class="textContainer chapter1">
                    Client Page
                </div>
                <div class="textContainer chapter2">
                    The service<br /><br /><br />
                </div>
                <div class="textContainer chapter3">
                    RegistrationInfo<br /><br /><br />
                </div>
                <div class="textContainer chapter4">
                    Emergency<br /><br /><br />
                </div>
                <div class="textContainer chapter5">
                    <table class="table table-striped" id="TableDetails2">

                        <tr class="colT">
                            <th>Car Category:</th>
                            <td class="colD">hfhgfhffg</td>
                        </tr>
                        <tr class="colT">
                            <th>Car Model:</th>
                            <td class="colD">hfhfghfg</td>
                        </tr>
                        <tr class="colT">
                            <th>Year Of Manu facture:</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>License Plate:</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>Insurance Company Name</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>Insurance Company Phone</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>Insurance Policy Number:</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>Policy End Date:</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <!--when clicked open window with the detils of all drivers in the insurance-->
                            <th>Driving License Number:</th>
                            <td class="colD"></td>
                        </tr>

                        <tr class="colT">
                            <th>Car Owner Name:</th>
                            <td class="colD"></td>
                        </tr>
                        <tr class="colT">
                            <th>Car Owner ID:</th>
                            <td class="colD"></td>
                        </tr>

                    </table>
                </div>
                <div class="textContainer chapter6">
                    Towing Services<br /><br /><br />
                </div>
            </div>

        </div>

    </div>
</div>
<!--END Client Page-->

    </asp:Content>
