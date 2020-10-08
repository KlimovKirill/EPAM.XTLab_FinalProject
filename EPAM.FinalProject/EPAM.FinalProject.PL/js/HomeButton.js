var homeBtn = document.getElementById('homeBtn');

function redirect(url) {
    location = url;
}

homeBtn.onclick = function () {
    redirect('/Index.cshtml');
}