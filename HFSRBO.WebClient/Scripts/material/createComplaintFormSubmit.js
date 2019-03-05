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
            $(this).val(1);
            $("select[name='communication_form']").prop('disabled', true);
        } else {
            $(this).val(0);
            $("input[name='pccNumber']").prop('disabled', true);
            $("select[name='communication_form']").prop('disabled', false);
        }
    });


    $("input[name='anonymous']").change(function () {
        var stat = $(this).prop('checked');
        if (stat) {
            $(this).val(1);
        } else {
            $(this).val(0);
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

$("#btnSave").on('click', function (e) {
    
    $("#CustomComplaintForm").remove();
    $("input[name='actionDate']").remove();
    $("input[name='actionTaken']").remove();

    var form = document.createElement('form');
    form.method = "POST";
    form.action = $("#CreateComplaint").data('action');
    form.style.display = "none";
    form.id = "CustomComplaintForm";
    
    form.appendChild(createInputElement('__RequestVerificationToken',$("input[name='__RequestVerificationToken']").val()));
    form.appendChild(createInputElement('codeNumber',$("input[name='codeNumber']").val()));
    form.appendChild(createInputElement('anonymous', $("input[name='anonymous']").val()));
    form.appendChild(createInputElement('firstname', $("input[name='firstname']").val()));
    form.appendChild(createInputElement('lastname',$("input[name='lastname']").val()));
    form.appendChild(createInputElement('mi', $("input[name='mi']").val()));
    form.appendChild(createInputElement('civil_status', $("select[name='civil_status']").val()));
    form.appendChild(createInputElement('gender', $("select[name='gender']").val()));
    form.appendChild(createInputElement('date', $("input[name='date']").val()));
    form.appendChild(createInputElement('relationship', $("input[name='relationship']").val()));
    form.appendChild(createInputElement('telNo', $("input[name='telNo']").val()));
    form.appendChild(createInputElement('mobile', $("input[name='mobile']").val()));
    form.appendChild(createInputElement('address', $("input[name='address']").val()));
    form.appendChild(createInputElement('p_firstname', $("input[name='p_firstname']").val()));
    form.appendChild(createInputElement('p_lastname', $("input[name='p_lastname']").val()));
    form.appendChild(createInputElement('p_mi', $("input[name='p_mi']").val()));
    form.appendChild(createInputElement('date_confined', $("input[name='date_confined']").val()));
    form.appendChild(createInputElement('age', $("input[name='age']").val()));
    form.appendChild(createInputElement('hospitalID', $("select[name='hospitalID']").val()));
    form.appendChild(createInputElement('other_complaint', $("input[name='other_complaint']").val()));
    form.appendChild(createInputElement('other_assistance', $("input[name='other_assistance']").val()));
    form.appendChild(createInputElement('reasonOfConfinement', $("input[name='reasonOfConfinement']").val()));
    form.appendChild(createInputElement('pccCheck', $("input[name='pccCheck']").val()));
    form.appendChild(createInputElement('pccNumber', $("input[name='pccNumber']").val()));
    form.appendChild(createInputElement('communication_form', $("input[name='communication_form']").val()));
    form.appendChild(createInputElement('ownership', $("select[name='ownership']").val()));


    $("input[name='date_informed_the_hf']").remove();
    $('input[name^="date_informed_the_hf"]').each(function () {
        var date_informed_the_hf = document.createElement("input");
        date_informed_the_hf.type = "hidden";
        date_informed_the_hf.name = "date_informed_the_hf[]";
        date_informed_the_hf.value = $(this).val();
        form.appendChild(date_informed_the_hf);
    });

    $("input[name='date_hf_submitted_reply']").remove();
    $('input[name^="date_hf_submitted_reply"]').each(function () {
        var date_hf_submitted_reply = document.createElement("input");
        date_hf_submitted_reply.type = "hidden";
        date_hf_submitted_reply.name = "date_hf_submitted_reply[]";
        date_hf_submitted_reply.value = $(this).val();
        form.appendChild(date_hf_submitted_reply);
    });

    $("input[name='date_release_to_records']").remove();
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

    $('input[name^="actionTaken"]').each(function () {
        var actionTaken = document.createElement("input");
        actionTaken.type = "hidden";
        actionTaken.name = "actionTaken[]";
        actionTaken.value = $(this).val();
        form.appendChild(actionTaken);
    });
    $('input[name^="actionDate"]').each(function () {
        var actionDate = document.createElement("input");
        actionDate.type = "hidden";
        actionDate.name = "actionDate[]";
        actionDate.value = $(this).val();
        form.appendChild(actionDate);
    });

    document.body.appendChild(form);
    form.submit();
});

function createInputElement(input,value)
{
    var element = document.createElement("input");
    element.type = "hidden";
    element.name = input; //"__RequestVerificationToken";
    element.value = value;//$("input[name='__RequestVerificationToken']").val();
    return element;
}