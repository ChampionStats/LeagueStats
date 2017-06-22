function refresh(currentID) {

    var endID = 500; // MAGIC

    if (currentID === endID)
    {
        window.location.replace("/Champion/Index")
        alert('Successfully refresh champion database table.');
    }
    else
    {
        setTimeout(addChampion(currentID, endID), 1000) // MAGIC - RateLimit
    }

}

function addChampion(currentID, endID) {

    $.ajax({
        type: "GET",
        url: "/Champion/Refresh/" + currentID,
        success: function (status) {

            var progressValue = (currentID / endID) * 100;
            progressValue = Math.round(progressValue);

            $('.progress-bar').attr('style', 'width:' + progressValue + '%');
            $('.progress-bar').text('' + progressValue + '% (' + currentID + '/' + endID + ' Champions)');
            $('#refreshStatus').text(status);


            currentID++;

            refresh(currentID);

        }
    })

}

function clearChampions() {
    alert('test');
    $.ajax({
        type: "GET",
        url: "/Champion/ClearChampions/",
        success: function () {

        }
    })
}