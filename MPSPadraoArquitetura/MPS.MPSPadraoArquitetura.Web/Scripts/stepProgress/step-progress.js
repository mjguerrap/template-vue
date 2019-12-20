//Exemplo 1 (Autocomplet Base)

function ExibirHtmlEx1() {
    $("#divHtmlEx1").show();
    $("#divJsEx1").hide();
    $("#divCssEx1").hide();

    $("#navExibirHtmlEx1").addClass("active");
    $("#navExibirJsEx1").removeClass("active");
    $("#navExibirCssEx1").removeClass("active");
}

function ExibirJsEx1() {
    $("#divJsEx1").show();
    $("#divHtmlEx1").hide();
    $("#divCssEx1").hide();

    $("#navExibirJsEx1").addClass("active");
    $("#navExibirHtmlEx1").removeClass("active");
    $("#navExibirCssEx1").removeClass("active");
}

function ExibirCssEx1() {
    $("#divJsEx1").show();
    $("#divHtmlEx1").hide();
    $("#divCssEx1").hide();

    $("#navExibirJsEx1").addClass("active");
    $("#navExibirHtmlEx1").removeClass("active");
    $("#navExibirCssEx1").removeClass("active");
}

function ExibirCssEx1() {
    $("#divCssEx1").show();
    $("#divJsEx1").hide();
    $("#divHtmlEx1").hide();

    $("#navExibirCssEx1").addClass("active");
    $("#navExibirJsEx1").removeClass("active");
    $("#navExibirHtmlEx1").removeClass("active");
}
