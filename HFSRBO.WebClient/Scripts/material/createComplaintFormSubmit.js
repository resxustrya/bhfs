$(document).ready(function () {
    $('#date_informed_the_hf').click(function () {
        var el = M.Datepicker.getInstance($("input[name='input_date_informed_the_hf']"));
        el.open();
    });
    $("input[name='input_date_informed_the_hf']").change(function () {
        var date = new Date($(this).val());
        addDates(date, "date_informed_the_hf");
    });

    $('#date_hf_submitted_reply').click(function () {
        var el = M.Datepicker.getInstance($("input[name='input_date_hf_submitted_reply']"));
        el.open();
    });
    $("input[name='input_date_hf_submitted_reply']").change(function () {
        var date = new Date($(this).val());
        addDates(date, "date_hf_submitted_reply");
    });

    $('#date_release_to_records').click(function () {
        var el = M.Datepicker.getInstance($("input[name='input_date_release_to_records']"));
        el.open();
    });
    $("input[name='input_date_release_to_records']").change(function () {
        var date = new Date($(this).val());
        addDates(date, "date_release_to_records");
    });

    $('#date_final_resolution').click(function () {
        var el = M.Datepicker.getInstance($("input[name='input_date_final_resolution']"));
        el.open();
    });

    $("input[name='input_date_final_resolution']").change(function () {
        var date = new Date($(this).val());
        addDates(date, "date_final_resolution");
    });

    $("input[name='pccCheck']").change(function () {
        var stat = $(this).prop('checked');
        if (stat) {
            $("input[name='pccNumber']").prop('disabled', false);
            $(this).val(true);
            $("select[name='communication_form']").prop('disabled', true);
        } else {
            $(this).val(false);
            $("input[name='pccNumber']").prop('disabled', true);
            $("select[name='communication_form']").prop('disabled', false);
        }
    });

    $("input[name='anonymous']").change(function () {
        var stat = $(this).prop('checked');
        if (stat) {
            $(this).val(true);
        } else {
            $(this).val(false);
        }
    });

    $(".addAction").click(function () {
        var elem = $("#add_type_complaint");
        elem.modal('open');
        $("#add_type_complaint .modal-content")
        .html('')
        .append(
            "<div class='row'>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='text' name='actionTaken' required autocomplete='off' />"
                    + "<label for='description'>Action Taken</label>"
                + "</div>"
                + "<div class='col l12 m12 s12 input-field'>"
                    + "<input type='date' name='actionDate' required autocomplete='off' />"
                + "</div>"
            + "</div>"
            + "<div class='modal-footer'>"
                + "<button type='submit' class='btn-large waves-effect waves-light green' onclick='addAction();'>Add</button>"
            + "</div>"
        );
    });

    
});

function addDates(date, classMemeber) {
    $("table." + classMemeber)
        .append(
            "<tr>"
            + "<td><input type='text' disabled name='" + classMemeber + "[]' value='" + date.toLocaleDateString() + "' /></td>"
            + "<td><a href='#' onclick='romoveMember(this);'><i class='material-icons'>remove</i></a></td>"
            + "</tr>"
        );
}

function romoveMember(el) {
    var parentEl = $(el).parent().parent();
    parentEl.remove();
}

function addAction() {
    var action = $("input[name='actionTaken']").val();
    var actionDate = $("input[name='actionDate']").val();
    $("table.actionTakenList")
       .append(
           "<tr>"
           + "<td><input type='text' disabled name='actionDate[]' value='" + actionDate + "' /></td>"
           + "<td><input type='text' disabled name='actionTaken[]' value='" + action + "' /></td>"
           + "<td><a href='#' onclick='romoveMember(this);'><i class='material-icons'>remove</i></a></td>"
           + "</tr>"
       );
    $("#add_type_complaint").modal('close');
}

$("#CreateComplaint").on('submit', function (e) {
    e.preventDefault();

    var form = document.createElement('form');
    form.method = "POST";
    form.action = $(this).data('action');
    form.style.display = "none";

    var token = document.createElement("input");
    token.type = "hidden";
    token.name = "__RequestVerificationToken";
    token.value = $("input[name='__RequestVerificationToken']").val();
    form.appendChild(token);

    var anonymos = document.createElement('input');
    anonymos.type = "hidden";
    anonymos.name = "anonymos";
    anonymos.value = $("input[name='anonymos']").val();
    form.appendChild(anonymos);

    var codeNumber = document.createElement('input');
    codeNumber.type = "hidden";
    codeNumber.name = "codeNumber";
    codeNumber.value = $("input[name='codeNumber']").val();
    form.appendChild(codeNumber);


    $('input[name^="date_informed_the_hf"]').each(function () {
        var date_informed_the_hf = document.createElement("input");
        date_informed_the_hf.type = "hidden";
        date_informed_the_hf.name = "date_informed_the_hf[]";
        date_informed_the_hf.value = $(this).val();
        form.appendChild(date_informed_the_hf);
    });


    $('input[name^="date_hf_submitted_reply"]').each(function () {
        var date_hf_submitted_reply = document.createElement("input");
        date_hf_submitted_reply.type = "hidden";
        date_hf_submitted_reply.name = "date_hf_submitted_reply[]";
        date_hf_submitted_reply.value = $(this).val();
        form.appendChild(date_hf_submitted_reply);
    });

    $('input[name^="date_release_to_records"]').each(function () {
        var date_release_to_records = document.createElement("input");
        date_release_to_records.type = "hidden";
        date_release_to_records.name = "date_release_to_records[]";
        date_release_to_records.value = $(this).val();
        form.appendChild(date_release_to_records);
    });

    $('input[name^="date_final_resolution"]').each(function () {
        var date_final_resolution = document.createElement("input");
        date_final_resolution.type = "hidden";
        date_final_resolution.name = "date_final_resolution[]";
        date_final_resolution.value = $(this).val();
        form.appendChild(date_final_resolution);
    });

    $('input[name^="complaint_type"]').each(function () {
        if ($(this).is(':checked')) {
            var complaint_type = document.createElement("input");
            complaint_type.type = "hidden";
            complaint_type.name = "complaint_type[]";
            complaint_type.value = $(this).val();
            form.appendChild(complaint_type);
        }
    });

    $('input[name^="complaint_assistance"]').each(function () {
        if ($(this).is(':checked')) {
            var complaint_assistance = document.createElement("input");
            complaint_assistance.type = "hidden";
            complaint_assistance.name = "complaint_assistance[]";
            complaint_assistance.value = $(this).val();
            form.appendChild(complaint_assistance);
        }
    });

    document.body.appendChild(form);
    $(this).submit();
});