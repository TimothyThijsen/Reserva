// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left'
    }, function (start, end, label) {
        console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
    });
});*/
var today = new Date()
var currentDate = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear(); 
var secondaryDate = new Date();
secondaryDate.setDate(today.getDate() + 3)

var SelectedStart = currentDate;
var SelectedEnd = secondaryDate.getDate() + '/' + (secondaryDate.getMonth() + 1) + '/' + secondaryDate.getFullYear()

if (document.getElementById("SearchModel_StartDate").value !== "") {
    SelectedStart = document.getElementById("SearchModel_StartDate").value;
} if (document.getElementById("SearchModel_EndDate").value !== "") {
    SelectedEnd = document.getElementById("SearchModel_EndDate").value;
}
$(function () {
    $('input[name="daterange"]').daterangepicker({
        "locale": {
            "format": "DD/MM/YYYY",
            "separator": " - ",
            "applyLabel": "Apply",
            "cancelLabel": "Cancel",
            "fromLabel": "From",
            "toLabel": "To",
            "customRangeLabel": "Custom",
            "weekLabel": "W",
            "daysOfWeek": [
                "Su",
                "Mo",
                "Tu",
                "We",
                "Th",
                "Fr",
                "Sa"
            ],
            "monthNames": [
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            ],

        },
        opens: 'left',
        minDate: currentDate.toString(),
        startDate: SelectedStart.toString(),
        endDate: SelectedEnd.toString()
    }, function (start, end, label) {
        console.log("A new date selection was made: " + start.format('DD-MM-YYYY') + ' to ' + end.format('DD-MM-YYYY'));
        
        ChangeHiddenValues(start, end);
    });

});
function ChangeHiddenValues(start, end) {
    var s = start;
    var e = end;
    var startInput = document.getElementById("SearchModel_StartDate");
    var endInput = document.getElementById("SearchModel_EndDate");

    startInput.value = s.format('DD-MM-YYYY');
    endInput.value = e.format('DD-MM-YYYY');

}

