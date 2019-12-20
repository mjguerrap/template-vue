function converterParametro(tipoParametroId) {
    var retorno = "";

    switch (tipoParametroId) {
        case 1:
            retorno = "Lista";
            break;
        case 2:
            retorno = "Objeto";
            break;
        case 3:
            retorno = "Lista de Objeto";
            break;
        case 4:
            retorno = "Variável";
            break;
        case 5:
            retorno = "Lista de Variável";
            break;
        case 6:
            retorno = "Void";
            break;
        case 8:
            retorno = "Nenhum";
            break;
        default:
            retorno = "";

    }

    return retorno;
}