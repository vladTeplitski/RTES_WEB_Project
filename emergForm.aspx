<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="emergForm.aspx.cs" Inherits="emergForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="inc/funcLib.js"></script>
    <script src="inc/angularScript.js"></script>
    <script src="json/infoTexts.json"></script>

    <div class="row row-centered " style="margin-bottom: 25px;" ng-controller="emergFormController">

        <div class="col-lg-6 col-lg-offset-3 col-md-8 col-md-offset-2 col-xs-12 col-centered " style="background: rgba(78, 134, 183, 0.8); border-left: 5px solid #C9EC25; border-right: 5px solid #C9EC25; border-radius: 5px; margin-top: 5px; margin-bottom: 5px; padding-bottom: 5px;">
            <h2 style="font-family: 'Regular', serif; font-size: 48px; color: #000000; text-decoration: underline;">Emergency Report</h2>
            <form style="color: #ffffff" name="myForm">

                <!--personal details button-->
                <div style="background: rgba(217, 219, 241, 0.5); width: 30%; border-radius: 3px; border-bottom: 2px solid #B1D607; border-top: 2px solid #B1D607; padding: 1px;">Personal Details
                    <button ng-click="myPersonalDetails()" style="background-color: Transparent; border: none;" type="button"><i class="fa fa-info-circle" aria-hidden="true" style="font-size: 30px; margin-left: 30px;"></i></button>
                </div>

                <div class="container presonalDetails" ng-show="personal">

                    <div class="table-responsive">
                        <table class="table table-striped" id="TableDetails">

                            <tr class="colT">
                                <th>Car Category:</th>
                                <td>hfhgfhffg</td>
                            </tr>
                            <tr>
                                <th>Car Model:</th>
                                <td>hfhfghfg</td>
                            </tr>
                            <tr>
                                <th>Year Of Manu facture:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>License Plate:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>Insurance Company Name:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>Insurance Company Phone:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>Insurance Policy Number:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>Policy End Date:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <!--when clicked open window with the detils of all drivers in the insurance-->
                                <th>Driving License Number:</th>
                                <td></td>
                            </tr>

                            <tr>
                                <th>Car Owner Name:</th>
                                <td></td>
                            </tr>
                            <tr>
                                <th>Car Owner ID:</th>
                                <td></td>
                            </tr>

                        </table>
                    </div>
                </div>

                <div style="background: rgba(217, 219, 241, 0.5); margin-top: 15px; border-radius: 3px; border-bottom: 2px solid #B1D607; border-top: 2px solid #B1D607; padding-left: 8px; padding-bottom: 8px;">
                    <label for="text" style="text-decoration: underline;">Case ID:</label>

                    <br />

                    <label for="text" style="text-decoration: underline;">Date: </label>

                    <br />
                    <label for="text" style="text-decoration: underline;">Hour: </label>
                    <br />

                    <label for="text" style="text-decoration: underline;">Location:</label>

                    <br />

                    <textarea rows="4" cols="50" placeholder="Comments here..." style="color: #000000;"></textarea>
                    <br />
                </div>
                <br />
                <div style="background: rgba(217, 219, 241, 0.5); width: 30%; border-radius: 3px; border-bottom: 2px solid #B1D607; border-top: 2px solid #B1D607; padding: 1px;">
                    <label style="padding-bottom: 5px;">Fill third party details </label>
                    <button ng-click="thirdPartyDetails()" style="background-color: Transparent; border: none;" type="button" class="third"><i class="fa fa-plus-square-o" style="font-size: 30px; margin-top: 5px; color: #000000;"></i></button>
                </div>

                <!--button + -->
                <br />
                <div style="background: rgba(217, 219, 241, 0.5); width: 30%; border-radius: 3px; border-bottom: 2px solid #D9DBF1; border-top: 2px solid #D9DBF1; padding: 1px;" class="driverDetailsButt" ng-show="driverDetailsBut">Driver Details
                    <button ng-click="myFunc()" style="background-color: Transparent; border: none;" type="button"><i class="fa fa-plus-square-o" style="font-size: 30px; color: #000000; margin-left: 46px;"></i></button>
                </div>

                <br />
                <!--slide down driver details div-->
                <div style="margin-bottom: 20px;" class="driverDetails" ng-show="showMe">
                    <label for="text">Please enter the third part details:</label>
                    <br />

                    <label for="text">Driver Name:</label>
                    <br />
                    <input class="form-control formInput" name="myName" ng-model="myName" type="text" id="example-text-input" style="width: 60%; display: inline;" placeholder="Enter Driver Name" required>
                    <span style="color: red; display: inline;" ng-show="myForm.myName.$touched && myForm.myName.$invalid">The name is required. </span>

                    <br />
                    <label for="text">Driver ID:</label>
                    <input ng-model="myInput" class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Driver ID" required>


                    <label for="text">Phone Number:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Phone Number">

                    <label for="text">Driving License Number:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Driving License Number">

                    <label for="text">Address:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Address">
                </div>

                <div style="background: rgba(217, 219, 241, 0.5); width: 30%; border-radius: 3px; border-bottom: 2px solid #D9DBF1; border-top: 2px solid #D9DBF1; padding: 1px; mar" class="carDetailsButt" ng-show="carDetailsBut">Car Details
                    <button ng-click="myFunc1()" style="background-color: Transparent; border: none;" type="button"><i class="fa fa-plus-square-o" style="font-size: 30px; color: #000000; margin-left: 62px;"></i></button>
                </div>

                <!--slide down car details div-->
                <div style="margin-top: 20px;" class="carDetails" ng-show="myValue">

                    <label for="text">Car Owner Name:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Car Owner Name">


                    <label for="text">Car Owner ID:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter Car Owner ID">


                    <label for="text">License Plate Number:</label>
                    <input class="form-control" type="text" id="example-text-input" style="width: 60%;" placeholder="Enter License Plate Number">


                    <label for="text">Car Category:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Enter Car Category">


                    <label for="text">Car Model:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Enter Car Model">

                    <label for="text">Car Color:</label>
                    <select class="selectpicker show-tick">
                        <option>Red</option>
                        <option>Blue</option>
                        <option>Silver</option>
                        <option>Green</option>
                        <option>Purple</option>
                        <option>Brown</option>
                        <option>Yellow</option>
                        <option>Black</option>
                    </select>

                    <br />
                    <label for="text">Year Of Manu facture:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Year Of Manu facture">
                </div>
                <br />
                <div style="background: rgba(217, 219, 241, 0.5); width: 38%; border-radius: 3px; border-bottom: 2px solid #D9DBF1; border-top: 2px solid #D9DBF1; padding: 1px;" class="insuranceDetailsButt" ng-show="insuranceDetailsBut">Insurence Company Details 
                    <button ng-click="myFunc2()" style="background-color: Transparent; border: none;" type="button"><i class="fa fa-plus-square-o" style="font-size: 30px; color: #000000"></i></button>
                </div>
                <br />
                <!--slide down insurance company details div-->
                <div class="insuranceDetails" ng-show="myValue1">
                    <label for="text">Insurance Company Name:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Enter Insurance Company Name">

                    <label for="text">Insurance Policy Number:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Enter Insurance Policy Number">


                    <label for="text">Insurance Agent Name:</label>
                    <input class="form-control" id="inputEmergencyForm" type="text" id="example-text-input" placeholder="Enter Insurance Agent Name">

                    <label for="text">Insurance Agent Phone Number:</label>
                    <input class="form-control" type="text" id="example-text-input" placeholder="Enter Insurance Agent Phone Number">
                </div>

                <label for="input-file2">Image Upload</label>

                <input type="file" id="input" multiple onchange="handleFiles(this.files)">

                <br />

                <p>Call For Towing 
                    <input type="checkbox">
                </p>

                <button type="submit" class="btn btn-default">Submit</button>

            </form>
        </div>
    </div>


</asp:Content>
