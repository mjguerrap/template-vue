function configurarStepProgress($target, passoAtivo) {

    var qtdePassos = arguments.length - 2;

    if (qtdePassos > 12)
        qtdePassos = 12;

    if (qtdePassos <= 0)
        qtdePassos = 1;

    var qtdeColumns = parseInt(12 / qtdePassos);
    var $divPaiStepProgress = "<div id='StepProgress' class='row bs-wizard' style='border-bottom:0;'>";
    var items = "";

    for (i = 0; i < qtdePassos; i++) {

        var numeroPasso = i + 1;
        var tituloPasso = arguments[i + 2];
        var nomePasso = "Etapa " + (numeroPasso).toString();
        var estadoPasso = "";

        if (numeroPasso == passoAtivo) {
            estadoPasso = "active";
        } else if (numeroPasso < passoAtivo) {
            estadoPasso = "complete";
        } else {
            estadoPasso = "disabled";
        }

        var item = "<div id='passoum' class='col-sm-" + qtdeColumns + " col-" + qtdeColumns + " bs-wizard-step " + estadoPasso + "'><div class='text-center bs-wizard-stepnum'>" + nomePasso + "</div><div class='progress'><div class='progress-bar'></div></div><a href='#' class='bs-wizard-dot'></a><div class='bs-wizard-info text-center'>" + tituloPasso + "</div></div>";
        items = items + item;
    }

    $target.append($divPaiStepProgress + items + "</div>");
}