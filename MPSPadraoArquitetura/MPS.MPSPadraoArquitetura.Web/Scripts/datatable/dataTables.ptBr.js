(function () {
    $.extend($.fn.dataTable.defaults, {
        language: {
            processing: "Processando aguarde...",
            search: "Pesquisar&nbsp;:",
            lengthMenu: "Mostrar _MENU_  registros",
            info: "Registro _START_ &agrave; _END_ de _TOTAL_ registros",
            infoEmpty: "Registro 0 &agrave; 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Aguarde um momento...",
            zeroRecords: "Nenhum registro encontrado",
            emptyTable: "Nenhum registro encontrado",
            paginate: {
                first: "Primeira",
                previous: "Anterior",
                next: "Próxima",
                last: "Ultima"
            }
        }
    });

    if (window.matchMedia('screen and (max-width: 768px)').matches) {
        $.fn.DataTable.ext.pager.numbers_length = 5;
    }
})();