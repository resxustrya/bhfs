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

    $("input[name='status']").change(function () {
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
            + "<td><strong>"+ date.toLocaleDateString() +"</strong><input type='hidden' name='" + classMemeber + "[]' value='" + date.toLocaleDateString() + "' /></td>"
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
    if (action && actionDate) {
        $("table.actionTakenList")
       .append(
           "<tr>"
           + "<td><strong>"+ actionDate+"</strong><input type='hidden' name='actionDate[]' value='" + actionDate + "' /></td>"
           + "<td><strong>"+ action+"</strong><input type='hidden' name='actionTaken[]' value='" + action + "' /></td>"
           + "<td><a href='#' onclick='romoveMember(this);'><i class='material-icons'>remove</i></a></td>"
           + "</tr>"
       );
       $("#add_type_complaint").modal('close');
    }
}

function createInputElement(input,value)
{
    var element = document.createElement("input");
    element.type = "hidden";
    element.name = input; 
    element.value = value;
    return element;
}


$('.js-example-basic-single').select2({
    placeholder: 'Select an option'
});


function showFilter(el)
{
    var filter = $('.filter-container');
    var url = $(el).data('url');
    if (filter.hasClass('hidden')) {
        filter.removeClass('hidden').addClass('show').show();
        $(".filter-container").append('<span>Loading filter. Please wait</span>');
        $.get(url, function (res) {
            $(".filter-container").html(res);
        });
    } else {
        filter.html('').hide().addClass('hidden');
    }
}

function validateComplaintForm(form)
{

}