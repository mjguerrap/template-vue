$(function () {
    $("#frameDemo").on("load", function () {
        $("#frameDemo").attr("height", $("#frameDemo").contents(document).height() + "px")
            .attr("width", $(".body-content").width() - 3 + "px");
    });
});