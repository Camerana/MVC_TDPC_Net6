function ButtonClick() {
    alert("hi");
}

function insertUser() {
    clearModal();
    nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'First Name';
    document.getElementById("modal-body").appendChild(nameP);
    nameTextArea = document.createElement("input");
    nameP.appendChild(nameTextArea);

    lastNameP = document.createElement("p");
    lastNameP.style.textAlign = "center";
    lastNameP.innerText = 'Last Name';
    document.getElementById("modal-body").appendChild(lastNameP);
    lastNameTextArea = document.createElement("input");
    lastNameP.appendChild(lastNameTextArea);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.FirstName = nameTextArea.value;
        body.LastName = lastNameTextArea.value;
        $.ajax({
            method: "POST",
            url: "/api/User/InsertUser",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
                window.location = window.location;
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    showModal();
};

function updateUserById(id, firstname, lastname) {
    clearModal();
    nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'First Name';
    document.getElementById("modal-body").appendChild(nameP);
    nameTextArea = document.createElement("input");
    nameTextArea.value = firstname;
    nameP.appendChild(nameTextArea);

    lastNameP = document.createElement("p");
    lastNameP.style.textAlign = "center";
    lastNameP.innerText = 'Last Name';
    document.getElementById("modal-body").appendChild(lastNameP);
    lastNameTextArea = document.createElement("input");
    lastNameTextArea.value = lastname;
    lastNameP.appendChild(lastNameTextArea);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.ID = id;
        body.FirstName = nameTextArea.value;
        body.LastName = lastNameTextArea.value;
        $.ajax({
            method: "POST",
            url: "/api/User/UpdateUser",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
                window.location = window.location;
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    showModal();
};

function deleteUserById(id) {
    clearModal();

    confirmP = document.createElement("p");
    confirmP.style.textAlign = "center";
    confirmP.innerText = 'Are you sure ?';
    document.getElementById("modal-body").appendChild(confirmP);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.ID = id;
        $.ajax({
            method: "POST",
            url: "/api/User/DeleteUser",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
                window.location = window.location;
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    showModal();
};

function clearModal() {
    $(".modal-body").empty();
    $(".modal-footer").empty();
}

function showModal() {
    var modal = new bootstrap.Modal(document.getElementById('modal'), {
        keyboard: false
    })
    modal.show();
}

function hideModal() {
    clearModal();
    var modal = bootstrap.Modal.getInstance(document.getElementById('modal'));
    modal.hide();
}