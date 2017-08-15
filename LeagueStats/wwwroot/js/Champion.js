var endID = 500; // MAGIC
var championID = 1;

function refresh() {

    if (championID === endID)
    {
        window.location.replace("/Admin/Index")
        alert('Successfully refresh champion database table.');
    }
    else
    {
        addChampion(championID);
        
    }

}

function addChampion(currentID) {

    $.ajax({
        type: "GET",
        url: "/Champion/Refresh/" + championID,
        success: function (status) {

            var progressValue = (championID / endID) * 100;
            progressValue = Math.round(progressValue);

            $('.progress-bar').attr('style', 'width:' + progressValue + '%');
            $('.progress-bar').text('' + progressValue + '% (' + championID + '/' + endID + ' Champions)');
            $('#refreshStatus').text(status);


            championID++;
            refresh();

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