$(function () {

    //$(".date-picker").datepicker({
    //    dateFormat: 'dd-MM-yyyy HH:mm'
    //});

    jQuery('#feeCalculator .date-control').datetimepicker({
        format: 'd/m/Y H:i',
        autoclose: true, minView: 2
    });

})