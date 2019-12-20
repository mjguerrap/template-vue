var modalCarregando = {
    exibir: function (funcao) {
        $('#modalCarregando').off('shown.bs.modal').on('shown.bs.modal', function (e) {
            modalCarregando.controleAssincrono = false;
            if (funcao != undefined)
                funcao();
        });

        $('#modalCarregando').modal('show');
        modalCarregando.controleAssincrono = true;
    },
    ocultar: function (funcao) {
        if (modalCarregando.controleAssincrono) {
            $('#modalCarregando').off('shown.bs.modal').on('shown.bs.modal', function (e) {
                $('#modalCarregando').modal('hide');
            });
        } else {
            $('#modalCarregando').modal('hide');
        }

        $('#modalCarregando').off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
            if (funcao != undefined)
                funcao();
        });
    },
    customizar: function (htmlHeader, htmlBody, htmlFooter) {
        $("#modalCarregando-header").html(htmlHeader);
        $("#modalCarregando-body").html(htmlBody);
        $("#modalCarregando-footer").html(htmlFooter);
    },
    modalEstaAberta: function () {
        return ($("#modalCarregando").data('bs.modal') || {})._isShown;
    },
    controleAssincrono: false
}

function CustomizarMensagemSalvar() {
    modalCarregando.customizar("<h6 class='modal-title'>Salvando...</h6>");
}

function CustomizarMensagemExcluir() {
    modalCarregando.customizar("<h6 class='modal-title'>Excluindo...</h6>");
}

function CustomizarMensagemAtualizar() {
    modalCarregando.customizar("<h6 class='modal-title'>Atualizando...</h6>");
}

function CustomizarMensagemPesquisa() {
    modalCarregando.customizar("<h6 class='modal-title'>Pesquisando...</h6>");
}

function CustomizarMensagemCarregando() {
    modalCarregando.customizar("<h6 class='modal-title'>Carregando...</h6>");
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}