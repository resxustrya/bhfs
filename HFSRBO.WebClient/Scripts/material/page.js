function setFacilityID(el)
{
    $("input[name='facilityIDInfo']").val($(el).data('id'));
    alert($(el).data('id'));
}

$("#health_add").click(function () {
    if ($('.fal_list').hasClass('active')) {
        var url = $(".fal_list").data('url');
        $.get(url, function (res) {
            $("#add_type_complaint").modal('open');
            $("#add_type_complaint .modal-content").html(res);
        });
    } else if ($('.facility_type').hasClass('active')) {
        $("#add_fal_type").modal('open');
    }
});
function updateHealthFacility(el) {
    var url = $(el).data('url');
    $.get(url, function (res) {
        $("#add_type_complaint").modal('open');
        $("#add_type_complaint .modal-content").html(res);
    });
}

function updateFacilityType(el)
{
    var url = $(el).data('url');
    var ftID = $(el).data('id');
    var ftType = $(el).data('ft');

    $("#add_type_complaint").modal('open');
    $("#add_type_complaint .modal-content")
        .html('')
        .append(
            "<form action='" + url +"' method='POST'>"
            +"<div class='row'>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='hidden' value='"+ftID+"' name='ID' />"
                + "</div>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='text' name='name' value='"+ ftType +"' required autocomplete='off' />"
                + "</div>"
            + "</div>"
            + "<div class='modal-footer'>"
                + "<button type='submit' class='btn-large waves-effect waves-light green'>Edit</button>"
            + "</div>"
        );
}


function editAssistance(el) {
    var url = $(el).data('url');
    var ID = $(el).data('id');
    var assistance = $(el).data('assistance');

    $("#add_type_complaint").modal('open');
    $("#add_type_complaint .modal-content")
        .html('')
        .append(
            "<form action='" + url + "' method='POST'>"
            + "<div class='row'>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='hidden' value='" + ID + "' name='ID' />"
                + "</div>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='text' name='assistance' value='" + assistance + "' required autocomplete='off' />"
                + "</div>"
            + "</div>"
            + "<div class='modal-footer'>"
                + "<button type='submit' class='btn-large waves-effect waves-light green'>Edit</button>"
            + "</div>"
        );
}



