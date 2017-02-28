<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="clientMainPage.aspx.cs" Inherits="clientMainPage" %>

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
                    <a href="emergForm.aspx">
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

                </div>
            </div>
            <div class="col-lg-6 col-lg-offset-1 col-md-6 col-md-offset-1 col-xs-12">

                <!-- client content -->
                <div class="mainWindow" style="margin-top: 8px;">
                    <div class="textContainer chapter1">
                        Client Page
                        <br />
                        <asp:Literal runat="server" ID="vladLabel"></asp:Literal>
                    </div>
                    <div class="textContainer chapter2">
                        The service<br />
                        <br />
                        <br />
                    </div>
                    <div class="textContainer chapter3">
                        RegistrationInfo<br />
                        <br />
                        <br />
                    </div>

                    <div class="textContainer chapter4">
                        <!--Start settings -->
                        <form runat="server" id="settingsForm">


                        <div id="changePswd" class="SettingClass changePswdJS">
                        Change password
                        </div>
                        <div id="subChangePswd" class="subSettingClass subchangePswdJS">
                            Present password:
                            <asp:TextBox runat="server" CssClass="form-control" ID="changePswTxtPresent" Style="color:#646464" placeholder="Present pass"></asp:TextBox>
                            New password:
                            <asp:TextBox runat="server" CssClass="form-control" ID="changePswNew" Style="color:#646464" placeholder="New pass"></asp:TextBox>
                        
                            <asp:Button runat="server" ID="changePswdBtn" CssClass="settingsBtn"/>

                        <div style="font-size:small; width: 80%; margin: 10px auto; text-align: center; padding: 3px 0px">
                            <asp:Panel runat="server" CssClass="alert alert-danger" ID="Panel1" Visible="true">
                             Present passsword is wrong!
                             </asp:Panel>
                         </div>
                        </div>


                        <div id="changeEmail" class="SettingClass changeEmailJS">
                        Edit Email
                        </div>
                        <div id="subChangeEmail" class="subSettingClass subchangeEmailJS">
                            Present email:
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBox1" Style="color:#646464" placeholder="Present email@"></asp:TextBox>
                            New email:
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBox2" Style="color:#646464" placeholder="New email@"></asp:TextBox>
                        <asp:Button runat="server" ID="changeEmailBtn" CssClass="settingsBtn"/>

                        <div style="font-size:small; width: 80%; margin: 10px auto; text-align: center; padding: 3px 0px">
                            <asp:Panel runat="server" CssClass="alert alert-danger" ID="Panel2" Visible="true">
                             Present email is wrong!
                             </asp:Panel>
                        </div>
                        </div>

                        <div id="changePhone" class="SettingClass changePhoneJS">
                        Edit Phone number
                        </div>
                        <div id="subChangePhone" class="subSettingClass subchangePhoneJS">
                            New phone number:
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBox4" Style="color:#646464" placeholder="New Phone-num#"></asp:TextBox>
                        <asp:Button runat="server" ID="changePhoneBtn" CssClass="settingsBtn"/>

                        </div>

                     </form>
                        <!--End settings -->
                    </div>
                    <div class="textContainer chapter5">

                     <div style="width: 400px; margin: 10px auto; text-align: center; padding: 8px 0px">
                     <asp:Panel runat="server" CssClass="alert alert-danger" ID="noClientAccount" Visible="false">
                      No client account.
                      </asp:Panel>
                      </div>

                        <table runat="server" class="table table-striped" id="TableDetails2">

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
                        Towing Services<br />
                        <br />
                        <br />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!--END Client Page-->

</asp:Content>
