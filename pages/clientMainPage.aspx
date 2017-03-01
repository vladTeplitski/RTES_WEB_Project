﻿<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="clientMainPage.aspx.cs" Inherits="clientMainPage" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../json/infoTexts.json"></script>
    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>

</asp:Content>

<asp:Content runat="server" ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1">

    <div runat="server" class="container-fluid" ng-controller="clientController">

        <!--START Client Page-->
        <div class="row bodyRow clientWindow">

            <div class="col-lg-3 col-lg-offset-1 col-md-4 col-md-offset-0 col-xs-8 col-xs-offset-2">
                <div class="getStartedBox" style="position: relative; margin-top: 8px; margin-bottom: 8px;">

                    <a runat="server" id="backOperator" href="operatorPage.aspx">
                    <div class="btnInfo">
                       <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-home"></i></div>
                        Operator Page
                    </div>
                    </a>
                    <a runat="server" ID="reportButton" href="emergForm.aspx">
                    <div class="btnInfo_report">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-pencil"></i></div>
                        New Report</div>
                    </a>
                    <div class="btnInfo btn2">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-folder-open"></i></div>
                        Reports Library</div>
                    <div class="btnInfo btn3">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-cog"></i></div>
                        Settings</div>
                    <div class="btnInfo btn4">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="fa fa-info-circle" aria-hidden="true" style="font-size: 20px;"></i></div>
                        Personal Details</div>
                    <div class="btnInfo btn5">
                        <div style="display: inline; position: absolute; left: 8px;"><i class="glyphicon glyphicon-envelope" aria-hidden="true" style="font-size: 20px;"></i></div>
                        Messages</div>
                </div>

            </div>
            <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-12">

                <!-- client content -->
                <div class="mainWindow" style="margin-top: 8px;">
                    <div class="textContainer chapter1">
                        <asp:Label runat="server" ID="clientWelcome"></asp:Label>
                        <asp:Label runat="server" ID="clientOps"></asp:Label>
                        <!-- Notifications-->
                         <div runat="server" id="notifications" style="font-size:small; width: 80%; margin: 10px auto; text-align: center; padding: 3px 0px;">
                            <asp:Panel runat="server" CssClass="alert alert-danger" ID="pswdWrongPanel" Visible="false">
                             Present passsword is wrong!
                             </asp:Panel>
                             <asp:Panel runat="server" CssClass="alert" ID="pswdChangeSuccess" Visible="false" Style="background-color:#22B14C">
                             Password changed successfully!
                             </asp:Panel>
                            <asp:Panel runat="server" CssClass="alert alert-danger" ID="emailWrongPanel" Visible="false">
                             Present email is wrong!
                             </asp:Panel>
                            <asp:Panel runat="server" CssClass="alert" ID="emailChangeSuccess" Visible="false" Style="background-color:#22B14C">
                             Email changed successfully!
                             </asp:Panel>
                            <asp:Panel runat="server" CssClass="alert" ID="phoneChangeSuccess" Visible="false" Style="background-color:#22B14C">
                             Phone number changed successfully!
                             </asp:Panel>
                         </div>

                        <br />
                        <asp:Literal runat="server" ID="vladLabel"></asp:Literal>
                    </div>

                    <!--Reports Library-->
                    <div class="textContainer chapter3">
                         <div runat="server" id="repLibNotif" style="font-size:small; width: 80%; margin: 10px auto; text-align: center; padding: 3px 0px;">
                            <asp:Panel runat="server" CssClass="alert alert-success" ID="repLibNotifPanel" Visible="false">
                             No reports available!
                            </asp:Panel>
                         </div>
                             
                    <asp:Literal runat="server" ID="rowsContent"/>

                    </div>

                    <div class="textContainer chapter4">
                        <!--Start settings -->
                        <form runat="server" id="settingsForm">

                        <div id="changePswd" class="SettingClass changePswdJS">
                        <i Style="font-size:23px;" class="glyphicon glyphicon-lock"></i>
                        Change password
                        </div>
                        <div id="subChangePswd" class="subSettingClass subchangePswdJS">
                            Present password:
                            <asp:TextBox runat="server" CssClass="form-control" ID="changePswTxtPresent" Style="color:#646464" placeholder="Present pass"></asp:TextBox>
                            New password:
                            <asp:TextBox runat="server" CssClass="form-control" ID="changePswNew" Style="color:#646464" placeholder="New pass"></asp:TextBox>
                        
                            <asp:Button runat="server" ID="changePswdBtn" OnClick="changePswd" CssClass="btn btn-default settingsBtn" Text="Save" Style="margin-left:40%; margin-top:5px; "/>

                        </div>


                        <div id="changeEmail" class="SettingClass changeEmailJS">
                        <i Style="font-size:23px;" class="glyphicon glyphicon-envelope"></i>
                        Edit Email
                        </div>
                        <div id="subChangeEmail" class="subSettingClass subchangeEmailJS">
                            Present email:
                            <asp:TextBox runat="server" CssClass="form-control" ID="presentEmailBox" Style="color:#646464" placeholder="Present email@"></asp:TextBox>
                            New email:
                            <asp:TextBox runat="server" CssClass="form-control" ID="newEmailBox" Style="color:#646464" placeholder="New email@"></asp:TextBox>
                        <asp:Button runat="server" ID="changeEmailBtn" onclick="changeEmail" CssClass="btn btn-default settingsBtn" Text="Save" Style="margin-top:5px; margin-left:40%;"/>

                        </div>

                        <div id="changePhone" class="SettingClass changePhoneJS">
                        <i Style="font-size:23px;" class="glyphicon glyphicon-earphone"></i>
                        Edit Phone number
                        </div>
                        <div id="subChangePhone" class="subSettingClass subchangePhoneJS">
                            New phone number:
                            <asp:TextBox runat="server" CssClass="form-control" ID="newPhoneBox" Style="color:#646464" placeholder="New Phone-num#"></asp:TextBox>
                        <asp:Button runat="server" ID="changePhoneBtn" onclick="changePhone" CssClass="btn btn-default settingsBtn" Text="Save" Style="margin-top:5px; margin-left:40%;" />

                        </div>


                     </form>
                        <!--End settings -->
                    </div>
                    <div class="textContainer chapter5">

                     <div style="width: 80%; margin: 10px auto; text-align: center;">
                     <asp:Panel runat="server" CssClass="alert alert-danger" ID="noClientAccount" Visible="false">
                      No details available!
                      </asp:Panel>
                      </div>
                        <div runat="server" id="personalDetailsPanel" class="personalDetailsClass">
                        <i Style="font-size:23px;" class="glyphicon glyphicon-tasks"></i>
                        <span style="margin-left:10px;">Personal Details</span>
                        </div><br />
                        <table runat="server" class="table table-striped" id="TableDetails2" style="cursor:default">

                            <tr class="colT">
                                <th>Car Category:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carCategory"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Car Model:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carModel"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Year Of Manufacture:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="yearManufact"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>License Plate:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="licensePlate"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Company Name</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceCompName"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Agent Name</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceAgentName"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Agent Phone</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceAgentPhone"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Policy Number:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insPolicyNum"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Policy Expiration:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="policyExp"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Driving License Number:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="drivingLicenseNum"></asp:label>
                                </td>
                            </tr>

                            <tr class="colT">
                                <th>Car Owner Name:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carOwnerName"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Car Owner ID:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carOwnerId"></asp:label>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="textContainer chapter6">
                        Messages<br />
                        <br />
                        <br />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!--END Client Page-->

</asp:Content>
