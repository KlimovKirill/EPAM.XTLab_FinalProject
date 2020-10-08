var addTopicBtn = document.getElementById('addTopic'),
    editTopicBtn = document.getElementById('editTopic'),
    delTopicBtn = document.getElementById('delTopic'),

    showAllMessagesInTopicBtn = document.getElementById('showAllMessagesInTopic'),
    addMessageBtn = document.getElementById('addMessage'),
    editMessageBtn = document.getElementById('editMessage'),
    delMessageBtn = document.getElementById('delMessage'),

    registrationBtn = document.getElementById('registration'),
    getAllUsersBtn = document.getElementById('getAllUsers'),
    getUserByIDBtn = document.getElementById('getUserByID'),
    editUserBtn = document.getElementById('editUser'),
    delUserBtn = document.getElementById('delUser');


function redirect(url) {
    location = url;
}

addTopicBtn.onclick = function () {
    redirect('/pages/AddTopic.cshtml');
}

editTopicBtn.onclick = function () {
    redirect('/pages/EditTopic.cshtml');
}

delTopicBtn.onclick = function () {
    redirect('/pages/DeleteTopic.cshtml');
}

showAllMessagesInTopicBtn.onclick = function () {
    redirect('/pages/ShowAllMessagesInTopic.cshtml');
}

addMessageBtn.onclick = function () {
    redirect('/pages/AddMessage.cshtml');
}

editMessageBtn.onclick = function () {
    redirect('/pages/EditMessage.cshtml');
}
delMessageBtn.onclick = function () {
    redirect('/pages/DeleteMessage.cshtml');
}

registrationBtn.onclick = function () {
    redirect('/pages/Registration.cshtml');
}

editUserBtn.onclick = function () {
    redirect('/pages/EditUser.cshtml');
}

delUserBtn.onclick = function () {
    redirect('/pages/DeleteUser.cshtml');
}

getAllUsersBtn.onclick = function () {
    redirect('/pages/GetAllUsers.cshtml');
}

getUserByIDBtn.onclick = function () {
    redirect('/pages/GetUserByID.cshtml');
}