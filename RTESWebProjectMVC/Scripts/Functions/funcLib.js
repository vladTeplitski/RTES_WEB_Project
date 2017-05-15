//Start JQuery
$(document).ready(function () {

    //info dropdown
    $(".drop1").on("click", function () {
        $(".EmrgPhones").fadeIn();
    });
    $(".CloseEmrgPhones").on("click", function () {
        $(".EmrgPhones").hide();
    });
    $(".drop2").on("click", function () {
        $(".ContactRtes").fadeIn();
    });
    $(".CloseContactRtes").on("click", function () {
        $(".ContactRtes").hide();
    });
    $(".drop3").on("click", function () {
        $(".AboutRTES").fadeIn();
    });
    $(".CloseAboutRTES").on("click", function () {
        $(".AboutRTES").hide();
    });
    $(".reportLabelHeadClose").on("click", function () {
        $(".opRepLabelJs").hide();
    });

    //Settings drop down
    $(".opt1").on("click", function () {
        $(".settingsGui").fadeIn();
    });
    $(".CloseSettings").on("click", function () {
        $(".settingsGui").hide();
    });

    //Message Notification
    $(".CloseMsgNotif").on("click", function () {
        $(".msgANorifGui").hide();
    });



});


//System loading control
function loadControl() {
    
    $(window).on('load', function () { $("#spinner").fadeOut('slow'); });
    
}


//Start search Javascript//

//operator - for users by ID
function searchIdJs() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];  // first column
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//operator - for users by name
function searchNameJs() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("myInput2");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1]; // second column
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//operator - for reports by report ID
function searchAllReportsByIdJs() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("repInput1");
    filter = input.value.toUpperCase();
    table = document.getElementById("allReportsTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];  // first column
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//operator - for reports by Client ID
function searchAllReportsByClientIdJs() {

    var input, filter, table, tr, td, i;
    input = document.getElementById("repInput2");
    filter = input.value.toUpperCase();
    table = document.getElementById("allReportsTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];  // 3rd column
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//END search Javascript//


//operator js functions
var refresh;
var flag1=0;
function closeViewOpNotif() {
    $('#operatorNotification').hide();

}

function setRefreshes() {
    $("#opsContain").show();
    flag = 1; // flag for: if the user if in operations room, interval should be activated
    refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
}
function stopRefresh() {
    clearInterval(refresh);
}
function returnRefresh() {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
}

//location dropdown refreshes
var flagLoc = 0;
function stopRefreshLoc() {
    clearInterval(refresh);
    flagLoc = 1;
}
function returnRefreshLoc() {
    if (flagLoc != 1)
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }
    
}


function hideOperations() {
    $("#opsContain").hide();
}
function hideClosedRepNotif() {
    $('#opsRoomNotif').hide();
}
function closeViewComment() {  //also used in operations room - auto refresh
    $('#commentContainer').hide();
    if(flag==1) //if the user if in operations room, interval should be activated
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }
}
function closeView3() {
    $('#editUserContainer').hide();

}
function closeView() {
    $('#messageContainer').hide();

}
function closeViewRep() {
    $('#opRepDetailsContainer').hide();
    if (flag == 1) //if the user if in operations room, interval should be activated
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }

}
function closeView2() {
    $('#userDetailsContainer').hide();
}
function closeViewDriversLocation() {
    $('#DriversLocationContainer').hide();
    if (flag == 1) //if the user if in operations room, interval should be activated
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }
    flagLoc = 0;
}
function closeViewShiftReg() {
    $('#shiftRegContainer').hide();
    if (flag == 1) //if the user if in operations room, interval should be activated
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }
}
function closeViewPhoneBook() {
    $('#PhoneBookContainer').hide();
    if (flag == 1) //if the user if in operations room, interval should be activated
    {
        refresh = setInterval(function () { $('#opsContain').load('/operator/GetOperationsRoom'); }, 3000); // every 3 sec
    }
}


//END operator js functions

//Location Functions

var publicLatLng;
var publicLat;
var publicLng;


function getLocation() {
    navigator.geolocation.getCurrentPosition(function (pos) {
        var lat = pos.coords.latitude;
        var lng = pos.coords.longitude;
        publicLatLng = lat + ", " + lng;
        publicLat = lat;
        publicLng = lng;

        if (lat != null) {
            document.getElementById("gpsIconOff").style.display = "none";
            document.getElementById("gpsIconOn").style.display = "inline";

        }
    });
}

function initMap() {
    getLocation();
    var geocoder = new google.maps.Geocoder;
    var infowindow = new google.maps.InfoWindow;
    document.getElementById('submit').addEventListener('click', function () {
        geocodeLatLng(geocoder, infowindow);
    });
}

function geocodeLatLng(geocoder, infowindow) {

    var input = publicLatLng;
    var latlngStr = input.split(',', 2);
    var latlng = { lat: parseFloat(latlngStr[0]), lng: parseFloat(latlngStr[1]) };
    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === 'OK') {
            if (results[1]) {
                document.getElementById('location1').value = results[0].formatted_address;
                alert(results[0].formatted_address);
                infowindow.setContent(results[0].formatted_address);
            } else {
                window.alert('No results found');
            }
        } else {
            window.alert('Geocoder failed due to: ' + status);
        }
    });
}

var address = "Shmu'el Salant St 16-18, Petah Tikva, Israel";   //TEST

function addressToLocation() {

    var geocoder = new google.maps.Geocoder();
    geocoder.geocode(
		{
		    address: address
		},
		function (results, status) {

		    var resultLocations = [];

		    if (status == google.maps.GeocoderStatus.OK) {
		        if (results) {
		            var numOfResults = results.length;
		            for (var i = 0; i < numOfResults; i++) {
		                var result = results[i];

		                document.getElementById('lat').value = result.geometry.location.lat();
		                resultLocations.push(
							{
							    text: result.formatted_address,
							    addressStr: result.formatted_address,
							    location: result.geometry.location
							}
						);
		            };
		        }
		    } else if (status == google.maps.GeocoderStatus.ZERO_RESULTS) {
		        // address not found
		        alert("address not found");
		    }

		}
	);

}



//END Location Functions


// Truck Driver functions
var counter = 0;

function driverAppSetRefreshes() {
    $("#tasksContain").show();
    truckFlag = 1;
    
    
    refreshTasks = setInterval(function () { $('#tasksContain').load('/truckDriver/GetTasksList'); }, 5000); // every 5 sec
    intervalGetLatLng = setInterval(function () { updateDriverLatLng(); }, 7000); // every 7 sec
}

function updateDriverLatLng() {
    
    getLocation();

    document.getElementById("testingLoc").innerHTML = counter + "__   lat: " + publicLat + "___   lng: " + publicLng;
    

    $.ajax({
        url: '/truckDriver/getCoordinates',
        type: 'POST',
        data: { latForm:publicLat, lngForm:publicLng},
        success: function (data) {
            alert("Data invoked");
        },
        error: function () {
            alert("error");
        }
    });

}