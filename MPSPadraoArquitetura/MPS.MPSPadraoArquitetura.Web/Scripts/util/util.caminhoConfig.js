var configUrlUtil = {
    obterCaminhoAPI: function (caminho) {
        return window.caminhoAPI + caminho;
    },

    obterCaminhoWebSite: function (area, controller, caminho) {

        if (area != undefined && area != "" && area != null) {
            var url = window.caminhoWebSite + area +"/"+ controller +"/"+caminho;
            return url;
        }
        else {
            return window.caminhoWebSite + controller + "/" + caminho;
        }

    },

    obterCaminho: function (area, caminho) {

        if (area != undefined && area != "" && area != null && area === areaSite.Cadastro) {
            var url = window.caminhoWebSiteCadastro + caminho;
            return url;
        }
        if (area != undefined && area != "" && area != null && area === areaSite.WebSite) {
            var url = window.caminhoWebSite + caminho;
            return url;
        }
    }
}
