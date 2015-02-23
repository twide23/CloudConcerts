

function chooseArtist() {
    $("#music_enthu_type:first-child").text("Artist");
    $("#music_enthu_type:first-child").val("Artist");
    var aForm = document.getElementById("artist_register");
    aForm.style.display = "initial";
    document.getElementById("host_register").style.display = "none";
    document.getElementById("listener_register").style.display = "none";
    $("#user_music_type").val("Artist");
}

function chooseHost() {
    $("#music_enthu_type:first-child").text("Host");
    $("#music_enthu_type:first-child").val("Host");
    var hForm = document.getElementById("host_register");
    hForm.style.display = "initial";
    document.getElementById("artist_register").style.display = "none";
    document.getElementById("listener_register").style.display = "none";
    $("#user_music_type").val("Host");
}

function chooseListener() {
    $("#music_enthu_type:first-child").text("Listener");
    $("#music_enthu_type:first-child").val("Listener");
    var lForm = document.getElementById("listener_register");
    lForm.style.display = "initial";
    document.getElementById("host_register").style.display = "none";
    document.getElementById("artist_register").style.display = "none";
    $("#user_music_type").val("Listener");
}

function deleteArtistImage(id) {
    var url = "/Artists/DeleteImage";
    $.post(url, { userid: id }, function (data) {
        window.location.href = "/Artists/Edit/" + id;
    });
}

function deleteHostImage(id) {
    var url = "/Hosts/DeleteImage";
    $.post(url, { userid: id }, function (data) {
        window.location.href = "/Hosts/Edit/" + id;
    });
}

function deleteListenerImage(id) {
    var url = "/Listeners/DeleteImage";
    $.post(url, { userid: id }, function (data) {
        window.location.href = "/Listeners/Edit/" + id;
    });
}