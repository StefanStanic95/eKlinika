
$(function () {   
    $('#date').datetimepicker('setStartDate', new Date());
    $('#date').datetimepicker('update');
    getReserved();
    banMinutes();
});
var result;
function handleData(data) {
    result = data;
}
function getReserved() {
    //console.log("reserved")
    var dateInput = $("#dateInp").val();
    var doktoriSelect = $("#doktoriSel").val();
    $.ajax({
        type: 'GET',
        url: '/Pregledi/getJsonResponse?date=' + dateInput + '&doktorId=' + doktoriSelect,
        contentType: 'json',
        success: function (rez) {
            var res;
            res = JSON.parse(rez);
            console.log(res);
            handleData(res);           
        },
        fail: function () {
            console.log("Fail")
        }
    })
}

$('#date').datetimepicker({
    language: 'hr',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0,
});

$('#time').datetimepicker({

    language: 'hr',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 1,
    minView: 0,
    maxView: 1,
    forceParse: 0,
    minuteStep: 15
});

$('#date').change(function () {
    getReserved();
    $('#time').datetimepicker('remove');        
    banMinutes();


});
$("#doktoriSel").change(function () {
    getReserved();
    $('#time').datetimepicker('remove');
    banMinutes();

});
function banMinutes() {


    $('#time').datetimepicker({
        language: 'en',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        forceParse: 0,
        minuteStep: 15,

        onRenderMinute: function (hours) {

            var sat = hours.getUTCHours();
            var minuta = hours.getUTCMinutes();

            if (result[sat] !== undefined) {
                if (result[sat].indexOf(minuta) !== -1) {
                    return ['disabled']
                }
   
            }
        }
    });
}
