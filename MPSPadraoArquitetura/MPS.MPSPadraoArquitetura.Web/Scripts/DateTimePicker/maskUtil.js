/*Máscara e classes de ajuda para o DateTimePicker*/
$(document).ready(function () {
    //Máscaras para o datetimepicker
    //Máscaras para dia e hora
    $(".datetimepicker-input-dh").inputmask({
        alias: 'datetime',
        placeholder: " ",
        inputFormat: 'dd/mm/yyyy HH:MM',
        showMaskOnHover: false,
        showMaskOnFocus: false,
    });

    //Máscaras para somente dia
    $(".datetimepicker-input-d").inputmask({
        alias: 'datetime',
        placeholder: " ",
        inputFormat: 'dd/mm/yyyy',
        showMaskOnHover: false,
        showMaskOnFocus: false,
    });

    //Máscaras para somente hora
    $(".datetimepicker-input-h").inputmask({
        alias: 'datetime',
        placeholder: " ",
        inputFormat: 'HH:MM',
        showMaskOnHover: false,
        showMaskOnFocus: false,
    });

    //Inicializa o TimeDatePicker
    // Data e Hora
    $('.datetimepicker-input-dh').datetimepicker({
        useCurrent: false,
        locale: 'pt-BR',
    });
    // Somente Data
    $('.datetimepicker-input-d').datetimepicker({
        useCurrent: false,
        format: 'L',
        locale: 'pt-BR',
    });
    // Somente Hora
    $('.datetimepicker-input-h').datetimepicker({
        useCurrent: false,
        format: 'LT',
        locale: 'pt-BR',
    });
});