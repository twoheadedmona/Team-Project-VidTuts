$(function () {
    $("#goDown").on("click", function () {
        if ($("#goDown").hasClass("down")) {
            $("#formHiden").slideDown("slow");
            $("#goDown").removeClass("down");
            $("#goDown").addClass("up");
        } else {
            $("#formHiden").slideUp("slow");
            $("#goDown").removeClass("up");
            $("#goDown").addClass("down");
        }
    });
});