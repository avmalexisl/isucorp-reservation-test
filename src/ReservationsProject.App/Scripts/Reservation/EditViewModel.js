﻿var EditViewModel = {
    Reservation: ko.observable(),
    AvailableRatings: ko.observable([1,2,3,4,5]),

    send: function () {

        var json = ko.toJS(EditViewModel.Reservation());
        json.ReservationDate = json.FormattedReservationDate;
        json.Contact.BirthDate = json.Contact.FormattedBirthDate;
        $.ajax({
            url: "/Reservation/Edit",
            type: "POST",
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (result) {
                window.location.href = window.location.origin + "/Reservation/List";
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
};

$.getJSON("/Reservation/GetById/" + $('#hidden-id').val(),
    function (data) {
        EditViewModel.Reservation(data);

        ko.applyBindings(EditViewModel);
    });

$('#reservation-date').prop('min', function () {
    return new Date().toJSON().split('T')[0];
});