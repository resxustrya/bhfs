(function ($) {
    $(function () {
        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $('#healthFacility').DataTable();
        $("#facilityType").DataTable();
        $('#complaintType').DataTable();
        $("#complaintAssistance").DataTable();

        $('input[name="date_confined"]').daterangepicker({
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });
        $(".applyBtn").click("click");
        $('input[name="date_confined"]').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
        });

    }); // end of document ready
})(jQuery); // end of jQuery name space

