$(function () {
    $('#LoginForm').on('submit', function (e) {
        e.preventDefault();

        loginRequest();
    })

    $('#Scramble').on('click', function (e) {
        e.preventDefault();

        scramble();
    })
})

function loginRequest() {
    let username = $('#LoginUserName').val();
    let password = $('#LoginPassword').val();

    var urll = apiurl + 'api/User/Login';

    var data = {
        "UserName": username,
        "Password": password
    };

    $.ajax({
        method: 'POST',
        url: urll,
        body: JSON.stringify(data),
        contentType: 'application/json',
        success: function (data) {

        },
        error: function (data) {

        },
        complete: function (data) {

        }
    })
}

function scramble() {
    var urll = apiurl + 'api/user/scramble';


    console.log('Scramblin.. please wait');
    $.ajax({
        method: 'POST',
        url: urll,
        contentType: 'application/json',
        success: function (data) {
            console.log('Scramble succeded');
        },
        error: function (data) {
            console.log('Scramble failed');
        },
        complete: function (data) {

        }
    })
}