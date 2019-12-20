var ListaResultadoPesquisa = {
    Data: "",
    ListaDetalhes: ""
};

$(document).ready(function () {
    $('.datetimepicker').datetimepicker();
    $('[data-toggle="tooltip"]').tooltip();
    ListaResultadoPesquisa.Data = "";
    ListaResultadoPesquisa.ListaDetalhes = "";
});

function onSuccess(data) {
    modalCarregando.ocultar(function () {
        $(":submit").show();
    });

    if (data.Notificacao) {
        MensagemToastr(tipoToastr.alerta, data.Mensagem);
        $("#divTabela").hide();
    }
}

function onFailure(data, status, stack) {
    modalCarregando.ocultar(function () {
        $(":submit").show();
    });

    MensagemToastr(tipoToastr.erro, mensagemPadrao.Erro + " ao tentar pesquisar Logs.");
}

function pesquisar() {
    MensagemToastrFechar();

    CustomizarMensagemPesquisa();
    modalCarregando.exibir();

    $("#divTabela").hide();
    $('#tabelaResultado').DataTable().destroy();

    var form = $('#formPesquisa');

    var table = $('#tabelaResultado').DataTable({

        bAutoWidth: true,
        pagingType: "full_numbers",
        processing: true,
        serverSide: true,
        stateSave: false,
        responsive: {
            details: {
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return col.hidden ? "<tr><td><div class='col-sm-6'>" + col.title + ":</div></td><td><div class='col-sm-6'>" + col.data + "</div></td></tr>" : "";
                    }).join('');

                    return data ? $('<table/>').append(data) : false;
                }
            }
        },
        ajax: {
            type: 'POST',
            cache: false,
            url: form.attr('action'),
            data: function (d) {
                $.each(form.serializeArray(), function (key, val) {
                    d[val.name] = val.value;
                });
            },
            dataFilter: function (data) {
                var json = jQuery.parseJSON(data);

                if (json.Notificacao) {
                    MensagemToastr(tipoToastr.alerta, json.Mensagem);
                    modalCarregando.ocultar();
                }

                json.ListaRetorno = formatarLista(json.ListaRetorno);
                json.recordsTotal = json.Total;
                json.recordsFiltered = json.Total;
                return JSON.stringify(json);
            },
            dataSrc: function (json) {
                MensagemToastrFechar();

                if (json.Notificacao) {
                    MensagemToastr(tipoToastr.alerta, json.Mensagem);
                } else {
                    if (json.ListaRetorno !== null && json.ListaRetorno.length > 0) {
                        $("#divTabela").show();
                    } else {
                        MensagemToastr(tipoToastr.alerta, mensagemPadrao.PesquisaRealizadaSemResultado);
                    }
                }

                modalCarregando.ocultar();

                return json.ListaRetorno;
            }
        },
        async: false,
        rowId: 'AuditLogId',
        scrollX: true,
        scrollCollapse: true,
        columns: [
            { "": "AuditLogId" },
            { "data": "UserName" },
            { "data": "EventDateUTC" },
            { "data": "EventType" },
            { "data": "TypeFullName" }
        ],
        searching: false,
        paging: true,
        order: [[3, 'asc']],
        columnDefs: [
            {
                "targets": 0, "defaultContent": "<button id='btnDetalhes' class='btn btn-info '>Detalhes</button>"
            },
            {
                "targets": 0,
                "orderable": false,
                "render": function (data, type, row) {

                    var botaoOpcoes =
                        '<div class="btn-group" role="group">' +
                        '<button id="btnOpcoesGrid" type="button" class="btn btn-secondary btn-sm dropdown-toggle fas fa-list" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></button>' +
                        '<div class="dropdown-menu" aria-labelledby="btnOpcoesGrid">' +
                        '<a href="javascript:void(0)" class="dropdown-item item-ativo" aria-label="Detalhes do Registro" data-toggle="tooltip" data-placement="top" title="Detalhes do Registro" data-registro="' + row.AuditLogId + '" onclick="exibirDetalhes(this);"><span class="fas fa-eye"></span> Detalhes do Registro</a>' +
                        '<a href="javascript:void(0)" class="dropdown-item item-ativo" aria-label="Detalhes do Metadata" data-toggle="tooltip" data-placement="top" title="Detalhes do Metadata" data-registro="' + row.AuditLogId + '" onclick="exibirMetadata(this);"><span class="fas fa-eye"></span> Detalhes do Metadata</a>' +
                        '</div>' +
                        '</div>';

                    return botaoOpcoes;
                }
            }
        ],
        initComplete: function (settings, json) {
            $('html,body').animate({ scrollTop: $('#tabelaResultado_wrapper').offset().top }, 500, function () {
                $('#tabelaResultado_wrapper').focus();
                $('[data-toggle="tooltip"]').tooltip();
            });
        }

    });

    return false;
}

function formatarLista(string) {

    var arrayJson = JSON.parse(string);

    $(arrayJson).each(function (index, item) {
        item.EventDateUTC = converterDataUtcParaDataBR(item.EventDateUtc);
        item.EventType = converterOperacaoAuditLog(item.EventType);
    });

    ListaResultadoPesquisa.Data = arrayJson;

    return arrayJson;
}

function exibirDetalhes(botao) {
    var id = $(botao).data("registro");
    ListaResultadoPesquisa.ListaDetalhes = "";

    $(ListaResultadoPesquisa.Data).each(function (index, item) {
        if (item.AuditLogId === id) {
            ListaResultadoPesquisa.ListaDetalhes = item.LogDetails;
        }
    });

    $('#tabelaDetalhes').DataTable().destroy();
    $("#modal-detalhes").modal('toggle');

    $('#tabelaDetalhes').DataTable({
        bFilter: false,
        responsive: {
            details: {
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return col.hidden ? "<tr><td><div class='col-sm-6'>" + col.title + ":</div></td><td><div class='col-sm-6'>" + col.data + "</div></td></tr>" : "";
                    }).join('');

                    return data ? $('<table/>').append(data) : false;
                }
            }
        },
        data: formatarListaDetalhes(ListaResultadoPesquisa.ListaDetalhes),
        async: false,
        scrollX: true,
        columns: [
            { "data": "PropertyName" },
            { "data": "OriginalValue" },
            { "data": "NewValue" }
        ]
    });

}

function formatarListaDetalhes(data) {

    $(data).each(function (index, item) {
        if (item.OriginalValue === null || item.OriginalValue === undefined) {
            item.OriginalValue = "NULL";
        }
    });

    return data;
}

function exibirMetadata(botao) {
    $('#tabelaMetadata').DataTable().destroy();
    $("#modal-metadata").modal('toggle');

    var dado = { id: $(botao).data("registro"), __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val() };
    var url = configUrlUtil.obterCaminhoWebSite(areaSite.Administrativo, controllerSite.Logs, urlLog.PesquisarMetadata);

    $.post(url, dado).done(function (data) {
        if (data.Notificacao) {
            MensagemToastr(tipoToastr.alerta, data.Mensagem);
        }
        else {
            $('#tabelaMetadata').DataTable({
                bFilter: false,
                responsive: {
                    details: {
                        renderer: function (api, rowIdx, columns) {
                            var data = $.map(columns, function (col, i) {
                                return col.hidden ? "<tr><td><div class='col-sm-6'>" + col.title + ":</div></td><td><div class='col-sm-6'>" + col.data + "</div></td></tr>" : "";
                            }).join('');

                            return data ? $('<table/>').append(data) : false;
                        }
                    }
                },
                data: JSON.parse(data.ListaRetorno),
                paging: true,
                scrollX: true,
                columns: [
                    { "data": "Key" },
                    { "data": "Value" }
                ]
            });
        }
    }).fail(function (error) {
        MensagemToastr(tipoToastr.erro, mensagemPadrao.Erro + " ao pesquisar Metadata.");
    }).always(function () {
        modalCarregando.ocultar();
    });
}
