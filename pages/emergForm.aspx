<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="emergForm.aspx.cs" Inherits="emergForm" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="home" runat="Server">

    <script src="../inc/funcLib.js"></script>
    <script src="../inc/angularScript.js"></script>
    <script src="../json/infoTexts.json"></script>
  
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--Emergency form container -->

    <div class="row row-centered "  style="margin-bottom: 25px;" ng-controller="emergFormController" id="shay" Visible="true" runat="server">

        <div class="col-lg-6 col-lg-offset-3 col-md-8 col-md-offset-2 col-xs-12 col-centered " style="background: rgba(78, 134, 183, 0.8); border-left: 5px solid #C9EC25; border-right: 5px solid #C9EC25; border-radius: 5px; margin-top: 5px; margin-bottom: 5px; padding-bottom: 5px;">
            <br />
            <div runat="server" id="reportsInSystem" class="personalDetailsClass" style="width:80%;margin:auto;text-align:center">
                 <i Style="font-size:20px;color:#D44E3C" class="fa fa-heartbeat"></i>
                 <span style="margin-left:10px;font-size:15px;margin-top:10px;"><b>New Emergency Form</b></span>
            </div><br />

            <form style="color: #ffffff" name="myForm" runat="server" Visible="true" id="loForm" >

                <!--personal details button-->

                <div ng-click="myPersonalDetails()" id="personalDtlsBtn" class="emergFormBtn"">
                        <i Style="font-size:23px;" class="fa fa-info-circle"></i>
                        Personal Details
                </div>

                <div class="container" ng-show="personal">

                    <!--Personal details content -->
                    <div class="table-responsive TableDetailsCover">
                        <table class="table" id="TableDetails">

                            <tr class="colT">
                                <th>Car Category:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carCategory2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Car Model:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carModel2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Year Of Manufacture:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="yearManufact2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>License Plate:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="licensePlate2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Company Name:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceCompName2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Agent Name:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceAgentName2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Agent Phone:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insuranceAgentPhone2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Insurance Policy Number:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="insPolicyNum2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Policy Expiration:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="policyExp2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Driving License Number:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="drivingLicenseNum2"></asp:label>
                                </td>
                            </tr>

                            <tr class="colT">
                                <th>Car Owner Name:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carOwnerName2"></asp:label>
                                </td>
                            </tr>
                            <tr class="colT">
                                <th>Car Owner ID:</th>
                                <td class="colD">
                                    <asp:label runat="server" id="carOwnerId2"></asp:label>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>

                <!--Relevant real time information -->
                 <div runat="server" id="Div1" class="personalDetailsClass" style="margin-top:20px; border-color:white;">
                 
                 <div style="margin-left:10px;font-size:15px;margin-top:10px;">
  
                    <div class="rowForm">
                    <label for="text""><b>Date:</b><asp:Label runat="server" ID="date"></asp:Label></label>
                    </div>

                    <div class="rowForm">
                    <label for="text""><b>Hour:</b><asp:Label runat="server" ID="hour"></asp:Label></label>
                        </div>

                    <div class="rowForm">
                    <label for="text""><b>Location:</b><asp:Label runat="server" ID="location"></asp:Label></label>
                    <div class="formContainer" style="margin-left:2px;">
                    <asp:TextBox runat="server" ng-model="location1" class="form-control" id="location1" type="text" style="width:80%;display:inline;color:black;" placeholder="Please enter your location"/>
                    <span ng-hide="!location1.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!location1.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>

                    <label for="text">Towing destination:</label>

                    <br />
                    <div class="formContainer" style="margin-left:2px;">
                    <asp:TextBox runat="server" class="form-control"  name="towDest" ng-model="towDest" type="text" id="towDest"  style="width:80%;display: inline;color:black;" placeholder="Towing Destination" TextMode="SingleLine"/>
                    <span ng-hide="!towDest.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!towDest.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>

                    <label for="text">Witness Name:</label>

                    <br />
                    <div class="formContainer" style="margin-left:2px;">
                    <asp:TextBox runat="server" class="form-control"  name="witName" ng-model="witName" type="text" id="witName"  style="width:80%;display: inline;color:black;" placeholder="Witness Name" TextMode="SingleLine"/>
                    <span ng-hide="!witName.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!witName.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>
  
                    </div>


                     
                    <asp:TextBox id="TextArea1" runat="server"  TextMode="multiline" rows="4" cols="40" placeholder="Comments here..." style="color: #000000;width:auto;"/>
                    <br />
                 </div>
                 </div><br />

                <!--Start Third party details -->
                <div ng-click="thirdPartyDetails()" id="addThirdPartyDtls" class="emergFormBtn"">
                        <i Style="font-size:20px;margin-right:10px;" class="glyphicon glyphicon-th-list"></i>
                        Fill Third Party Details
                </div>

            
                <br />

                <!--Start Driver details -->
                <div ng-click="myFunc()" id="driverDtls" class="emergFormBtn"  class="driverDetailsButt" ng-show="driverDetailsBut">
                        <i Style="font-size:20px;margin-right:10px;" class="glyphicon glyphicon-user"></i>
                        Driver Details
                </div>

                <br />

                <!--slide down driver details div-->
                <div runat="server" style="margin-bottom: 20px;width:90%;" class="driverDetails" ng-show="showMe">
                    <label for="text">Please enter the third part details:</label>
                    <br />
                    <label for="text">Driver Name:</label>

                    <br />
                    <div class="formContainer">
                    <asp:TextBox runat="server" class="form-control"  name="myName" ng-model="myName" type="text" id="driver_name"  style="display: inline;color:black;" placeholder="Enter Driver Name" TextMode="SingleLine"/>
                    <span ng-hide="!myName.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!myName.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>
                  
                    <label for="text">Driver ID:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="driverID" class="form-control" type="text" id="driver_ID" style="display:inline;color:black;" placeholder="Enter Driver ID" />
                    <span ng-hide="!driverID.length" ng-hide="driverIdSuccess" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!driverID.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                   
                    
                    </div>

                    <label for="text">Phone Number:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="driverPhone" class="form-control" type="text" id="phoneNum" style="display:inline;color:black;" placeholder="Enter Phone Number" />
                    <span ng-hide="!driverPhone.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!driverPhone.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>

                    <label for="text">Driving License Number:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="driverLicenseNum" class="form-control" type="text" id="licenseNum" style="display:inline;color:black;" placeholder="Enter Driving License Number" />
                    <span ng-hide="!driverLicenseNum.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!driverLicenseNum.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>

                    <label for="text">Address:  </label>
                    <div class="formContainer">
                    <asp:TextBox runat="server"  ng-model="driverAddress" class="form-control" type="text" id="address1" style="display:inline;color:black;" placeholder="Enter Address"   />   
                    <span ng-hide="!driverAddress.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!driverAddress.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                    </div>

                
                </div>


                <!--Start car details-->

                <div ng-click="myFunc1()" id="carDtls" class="emergFormBtn carDetailsButt" ng-show="carDetailsBut">
                        <i Style="font-size:20px;margin-right:10px;" class="fa fa-car"></i>
                        Car Details
                </div>

                <!--slide down car details-->
                <div style="margin-top: 20px;" class="carDetails" ng-show="myValue">

                    <label for="text">Car Owner Name:</label>
                    <div class="formContainer">
                     <asp:TextBox runat="server" ng-model="carOwnerName" class="form-control" type="text" id="car_ownerName" style="width:80%;display:inline;color:black;" placeholder="Enter Car Owner Name"/>
                    <span ng-hide="!carOwnerName.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!carOwnerName.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Car Owner ID:</label>
                    <div class="formContainer">
                     <asp:TextBox runat="server" ng-model="carOwnerId" class="form-control" type="text" id="car_ownerID" style="width:80%;display:inline;color:black;" placeholder="Enter Car Owner ID"/>
                    <span ng-hide="!carOwnerId.length" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!carOwnerId.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">License Plate Number:</label>
                    <div class="formContainer">
                     <asp:TextBox runat="server" ng-model="carLicensePlate" class="form-control" type="text" id="license_plateNum" style="width:80%;display:inline;color:black;" placeholder="Enter License Plate Number"/>
                    <span ng-hide="!carLicensePlate.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!carLicensePlate.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Car Category:</label>
                    <div class="formContainer">
                     <asp:TextBox runat="server" ng-model="carCategory" class="form-control" type="text" id="carCategory" style="width:80%;display:inline;color:black;" placeholder="Enter Car Category"/>
                    <span ng-hide="!carCategory.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!carCategory.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Car Model:</label>
                    <div class="formContainer">
                     <asp:TextBox runat="server" ng-model="carModel" class="form-control" type="text" id="carModel" style="width:80%;display:inline;color:black;" placeholder="Enter Car Model"/>
                    <span ng-hide="!carModel.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!carModel.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Car Color:</label>
                    <select runat="server"  id="color1" class="selectpicker show-tick" >
                        <option>Red</option>
                        <option>White</option>
                        <option>Blue</option>
                        <option>Silver</option>
                        <option>Green</option>
                        <option>Purple</option>
                        <option>Brown</option>
                        <option>Yellow</option>
                        <option>Black</option>
                        <option>Grey</option>
                    </select>

                    <br />
                      
                    <label for="text">Year Of Manu facture:</label> 
                    
                    <asp:TextBox  runat="server" class="form-control" type="number" id="year" min="1995" max="2017" style="color:black;width: 48%;padding-left:50px;" placeholder="Year Of Manu facture"/>
                </div>
                <br />

                <!--Start Insurance details-->
                <div ng-click="myFunc2()" id="insCompDtls" class="emergFormBtn insuranceDetailsButt" ng-show="insuranceDetailsBut">
                        <i Style="font-size:20px;margin-right:10px;" class="fa fa-bank"></i>
                         Insurence Company Details 
                </div>

                <br />
                <!--slide down insurance company details div-->
                <div class="insuranceDetails" ng-show="myValue1">

                    <label for="text">Insurance Company Name:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="compName" class="form-control" type="text" id="insuranceCompanyN" style="width:80%;display:inline;color:black;" placeholder="Enter Insurance Company Name"/>
                    <span ng-hide="!compName.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!compName.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Insurance Policy Number:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="policyNum" class="form-control" type="text" id="insurancePolicyNum" style="width:80%;display:inline;color:black;" placeholder="Enter Insurance Policy Number"/>
                    <span ng-hide="!policyNum.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!policyNum.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Insurance Agent Name:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="agentName" class="form-control" id="insuranceAgentNa" type="text" style="width:80%;display:inline;color:black;" placeholder="Enter Insurance Agent Name"/>
                    <span ng-hide="!agentName.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!agentName.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>

                    <label for="text">Insurance Agent Phone Number:</label>
                    <div class="formContainer">
                    <asp:TextBox runat="server" ng-model="agentPhone" class="form-control" type="text" id="insuranceAgentPhone" style="width:80%;display:inline;color:black;" placeholder="Enter Insurance Agent Phone Number"/>
                    <span ng-hide="!agentPhone.length" ng-hide="validName" Style="color:lightgreen;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-ok form-control-feedback"></span>
                    <span ng-show="!agentPhone.length" Style="color:#FFC600;padding-left:5px;position:relative;display:inline;" class="glyphicon glyphicon-warning-sign form-control-feedback"></span>
                        </div>
                </div>
                <br />

                 <div runat="server" id="callTowService" class="personalDetailsClass">
                 <i Style="font-size:20px;" class="fa fa-truck"></i>
                 <span style="margin-left:10px;font-size:15px;margin-top:10px;">

                   <asp:CheckBox id="CheckBox1" Checked="false" runat="server" Text="Call For Towing "/>

                 </span>
                </div>
                <br />

                <asp:Button runat="server" type="submit" Text="Submit" OnClick="send_Details_Func" class="btn btn-default"/>


              
            </form>



        </div>
    </div>

                  <div runat="server" id="notifications" style="font-size:small; width: 80%; margin: 10px auto; text-align: center; padding: 3px 0px;">
                  <asp:Panel  runat="server" CssClass="alert" ID="submitDetails" Visible="false" Style="background-color:#22B14C;width:50%;margin:auto;margin-bottom:5px;"  >
                  <label for="text""><b>Create report is successfull </b></label>
                  <br/>  
                  <label for="text""><b>Case ID:</b><asp:Label runat="server" ID="caseId"></asp:Label></label>
                  </asp:Panel>
                  </div>



</asp:Content>
