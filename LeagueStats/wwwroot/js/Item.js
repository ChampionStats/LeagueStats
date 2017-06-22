function refresh(currentID) {

    var endID = 5000; // MAGIC

    if (currentID === endID)
    {
        window.location.replace("/Item/Index")
        alert('Successfully refresh item database table.');
    }
    else {
        setTimeout(addItem(currentID, endID), 1000) // MAGIC - RateLimit
    }

}

function addItem(currentID, endID) {

    $.ajax({
        type: "GET",
        url: "/Item/Refresh/" + currentID,
        success: function (status) {

            var progressValue = (currentID / endID) * 100;
            progressValue = Math.round(progressValue);


            currentID++;

            refresh(currentID);

        }
    })

}