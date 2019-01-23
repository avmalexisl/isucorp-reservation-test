var EditViewModel = {
    Reservation: ko.observable(),
    AvailableRatings: ko.observable([1,2,3,4,5]),

    send: function () {

        var json = ko.toJS(EditViewModel.Reservation());
        json.ReservationDate = json.FormattedReservationDate;
        json.Contact.BirthDate = json.Contact.FormattedBirthDate;
        $.ajax({
            url: urlActions.edit,
            type: "POST",
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (result) {
                window.location.href = urlActions.list;
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
};

$.getJSON(urlActions.getById + '/' + $('#hidden-id').val(),
    function (data) {
        EditViewModel.Reservation(data);

        ko.applyBindings(EditViewModel);
    });

$('#reservation-date').prop('min', function () {
    return new Date().toJSON().split('T')[0];
});