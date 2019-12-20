function criarConfiguracaoSelect(url, mapeamento, mensagemErro) {
    return {
        url: url,
        dataType: 'json',
        type: "GET",
        delay: 1000,
        data: function (params) {
            //parametro do metodo do API que estou enviando
            return { descricao: params.term, page: params.page };
        },
        processResults: function (data, params) {
            params.page = params.page || 1;
            return { results: $.map(data, mapeamento) };
        },
        error: function (error) {
            if (error.status > 0)
                $(".loading-results").html("<b style='color: red'>" + mensagemErro + "</b>");
        }
    };
}