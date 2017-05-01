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

//END operator js functions