// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    const timeElements = Array.from(document.querySelectorAll("time[datetime]"));
    console.log(timeElements);
    if (timeElements.length === 0) {
        return;
    }

    timeElements.forEach(element => {
        const time = moment.utc(element.getAttribute("datetime")).local();

        element.textContent = time.format("llll");
    })
})
