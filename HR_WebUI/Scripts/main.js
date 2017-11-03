$(document).ready(function () {

    console.log("loaded");

    $(".deleteEmployee").click(function () {
        if (confirm("You are sure?")) {
            return true;
        }
        else {
            e.preventDefault();
        }
    })
})