﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left'Checkout page
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
if (window.location.pathname == "/Index" || window.location.pathname == "/HotelPages/HotelsView") {
    if (document.getElementById("SearchModel_StartDate").value !== "") {
        SelectedStart = document.getElementById("SearchModel_StartDate").value;
    }
    if (document.getElementById("SearchModel_EndDate").value !== "") {
        SelectedEnd = document.getElementById("SearchModel_EndDate").value;
    } 
    ChangeHiddenDateToDefaultDate();
}

//Daterange settings
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
        opens: 'center',
        minDate: currentDate.toString(),
        startDate: SelectedStart.toString(),
        endDate: SelectedEnd.toString(),
        autoApply: true
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
    startInput.value = s.format('DD/MM/YYYY');
    endInput.value = e.format('DD/MM/YYYY');

}
function ChangeHiddenDateToDefaultDate() {
    var startInput = document.getElementById("SearchModel_StartDate");
    var endInput = document.getElementById("SearchModel_EndDate");
    startInput.value = SelectedStart.toString();
    endInput.value = SelectedEnd.toString();
}
//onpost
function submitForm(handlerName) {
    var form = document.getElementById("searchForm");
    form.action = "?handler=" + handlerName;
    form.submit();
}

//PLUS MINUS
if (window.location.pathname == "/HotelPages/HotelPage") {
    const plusButtons = document.querySelectorAll(".plus");
    const minusButtons = document.querySelectorAll(".minus");
    const inputs = document.querySelectorAll(".input");

    const totalPrice = document.querySelector(".totalPrice");
    const totalStayPrice = document.querySelector(".totalStayPrice");

    plusButtons.forEach((button) => {
        const buttonId = button.getAttribute("data-id"),
            quantity = document.querySelector(".quantity-" + buttonId)

        button.addEventListener("click", function () {
            quantity.value++;
            priceCalc(buttonId, quantity);
        });
    });

    minusButtons.forEach((button) => {
        const buttonId = button.getAttribute("data-id"),
            quantity = document.querySelector(".quantity-" + buttonId)
        button.addEventListener("click", function () {

            if (quantity.value > 0) {
                quantity.value--;
                priceCalc(buttonId, quantity);
            }

        });
    });
    inputs.forEach((input) => {
        input.addEventListener("input", function () {
            priceCalc();
        });
    });
    function priceCalc() {
        var cost = 0;
        var fullStayCost = 0;
        inputs.forEach((input) => {
            var inputId = input.getAttribute("data-id");
            var quantity = document.querySelector(".quantity-" + inputId).value;
            var price = document.getElementById("roomPrice-" + inputId).value;
            var priceForStay = document.getElementById("totalStayPrice-" + inputId).value;

            cost += (price * quantity);
            fullStayCost += (priceForStay * quantity)
            });
        totalPrice.innerHTML = cost.toFixed(2);
        totalStayPrice.innerHTML = fullStayCost.toFixed(2);
    }
}
