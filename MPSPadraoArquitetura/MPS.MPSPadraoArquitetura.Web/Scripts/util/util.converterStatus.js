function converterStatus(statusRegistroId) {
    var retorno = "";

    switch (statusRegistroId) {
        case 0:
            retorno = "Inativo";
            break;
        case 1:
            retorno = "Ativo";
            break;
        default:
            retorno = "Excluído";
    }

    return retorno;
}

function converterOperacaoAuditLog(operacao) {
    var retorno = "";

    switch (operacao) {
        case 0:
            retorno = "Inserção";
            break;
        case 1:
            retorno = "Exclusão";
            break;
        case 2:
            retorno = "Alteração";
            break;
        case 3:
            retorno = "Exclusão Lógica";
            break;
        case 4:
            retorno = "Retorno Exclusão Lógica";
            break;
        default:
            retorno = "";
    }

    return retorno;
}