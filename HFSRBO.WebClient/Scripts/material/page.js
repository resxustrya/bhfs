function setFacilityID(el)
{
    $("input[name='facilityIDInfo']").val($(el).data('id'));
    alert($(el).data('id'));
}