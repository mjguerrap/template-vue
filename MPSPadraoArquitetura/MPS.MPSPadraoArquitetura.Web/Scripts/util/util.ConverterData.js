// Converte data no formato "\/Date(1234656000000)\/"
function converterValorParaData(data, formato) {
    var retorno = "";

    if (typeof data === 'string' && data !== null && data !== "") {
        var valor = parseInt(data.replace(/\/Date\((\d+)\)\//g, "$1"));
        var dataCorreta = new Date(valor);

        if (formato == undefined) {
            formato = 'DD/MM/YYYY HH:mm:ss';
        }

        retorno = moment(dataCorreta).format(formato);
    }

    return retorno;
}

// Converte data no formato "2009-02-15T00:00:00Z"
function converterDataUtcParaDataBR(data, formato) {
    var retorno = "";

    if (typeof data === 'string' && data !== null && data !== "") {
        
        if (formato == undefined) {
            formato = 'DD/MM/YYYY HH:mm:ss';
        }

        retorno = moment(data).format(formato);
    }

    return retorno;
}
