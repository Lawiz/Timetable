// Получение всех пользователей
function GetUsers() {
    $.ajax({
        url: '/api/Users',
        type: 'GET',
        contentType: "application/json",
        success: function (users) {
            var rows = "";
            users.forEach(user => {
                console.log(user);
                // добавляем полученные элементы в таблицу
                rows += row(user);
            });
            $("table tbody").append(rows);
        }
    });
}
// Получение одного пользователя
function GetUser(id) {
    $.ajax({
        url: '/api/Users/' + id,
        type: 'GET',
        contentType: "application/json",
        success: function (user) {
            var form = document.forms["userForm"];
            form.elements["id"].value = user.id;
            form.elements["login"].value = user.login;
            form.elements["password"].value = user.password;
            form.elements["idRole"].value = user.idRole;
        }
    });
}
// отправка формы
$("form").submit(function (e) {
    e.preventDefault();
    var id = this.elements["id"].value;
    var login = this.elements["login"].value;
    var password = this.elements["password"].value;
    var idRole = Number(this.elements["idRole"].value);

    if (id != 0) {
        EditUser(id, login, password, idRole);
    }
    else {
        Create(login, password, idRole);
    }
});
// Добавление пользователя
function Create(userLogin, userPassword, userIdRole) {

    $.ajax({
        url: "api/Users",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify({
            Login: userLogin,
            Password: userPassword,
            IdRole: userIdRole
        }),
        success: function (user) {
            reset();
            $("table tbody").append(row(user));
        }
    })
}
// Изменение пользователя
function EditUser(userId, userLogin, userPassword, userIdRole) {
    $.ajax({
        url: "api/Users",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify({
            Id: userId,
            Login: userLogin,
            Password: userPassword,
            IdRole: userIdRole
        }),
        success: function (user) {
            reset();
            $("tr[data-rowid='" + user.id + "']").replaceWith(row(user));
        }
    })
}

// сброс формы
function reset() {
    var form = document.forms["userForm"];
    form.reset();
    form.elements["id"].value = 0;
}

// Удаление пользователя
function DeleteUser(id) {
    $.ajax({
        url: "api/Users/" + id,
        contentType: "application/json",
        method: "DELETE",
        success: function (user) {
            $("tr[data-rowid='" + user.id + "']").remove();
        }
    })
}
// создание строки для таблицы
var row = function (user) {
    console.log(user.login);
    return "<tr data-rowid='" + user.id + "'><td>" + user.id + "</td>" +
        "<td>" + user.login + "</td> <td>" + user.password + "</td>" + "</td> <td>" + user.idRole + "</td>" +
        "<td><a class='editLink' data-id='" + user.id + "'>Изменить</a> | " +
        "<a class='removeLink' data-id='" + user.id + "'>Удалить</a></td></tr>";
}
// сброс значений формы
$("#reset").click(function (e) {

    e.preventDefault();
    reset();
})

// нажимаем на ссылку Изменить
$("body").on("click", ".editLink", function () {
    var id = $(this).data("id");
    GetUser(id);
})
// нажимаем на ссылку Удалить
$("body").on("click", ".removeLink", function () {
    var id = $(this).data("id");
    DeleteUser(id);
})

// загрузка пользователей
GetUsers();