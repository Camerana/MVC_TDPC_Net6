function ButtonClick() {
    alert("hi");
}

function getUsersWithFilter() {
    let filter = $('#TXTUsersFilter').val();
    $.ajax({
        method: "POST",
        url: "/api/User/GetsUsersWithFilter",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(filter),
        dataType: "json",
        success: function (data, status) {
            console.log(filter);
            console.log(data);
            console.log(status);

            $("#TBLUsersBody").empty();

            let tableBody = document.getElementById("TBLUsersBody");
            for (let i = 0; i < data.length; i++) {
                let tr = document.createElement("tr");
                tableBody.appendChild(tr);

                let firstNameTD = document.createElement("td");
                firstNameTD.innerText = data[i].firstName;
                tr.appendChild(firstNameTD);

                let lastNameTD = document.createElement("td");
                lastNameTD.innerText = data[i].lastName;
                tr.appendChild(lastNameTD);

                let updateTD = document.createElement("td");
                let updateBTN = document.createElement("button");

                updateBTN.innerText = "Update";
                updateBTN.classList.add("btn-sm");
                updateBTN.classList.add("btn-warning");
                updateBTN.onclick = function () { updateUserById(data[i].id, data[i].firstName, data[i].lastName); };
                updateTD.appendChild(updateBTN);
                tr.appendChild(updateTD);

                let deleteTD = document.createElement("td");
                let deleteBTN = document.createElement("button");
                deleteBTN.innerText = "Delete";
                deleteBTN.classList.add("btn-sm");
                deleteBTN.classList.add("btn-danger");
                deleteBTN.onclick = function () { deleteUserById(data[i].id); };
                deleteTD.appendChild(deleteBTN);
                tr.appendChild(deleteTD);
            }

            this.always();
        },
        error: function (error, status) {
            console.log(filter);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
        }
    });
}

function insertUser() {
    clearModal();
    let nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'First Name';
    document.getElementById("modal-body").appendChild(nameP);
    let nameTextArea = document.createElement("input");
    nameP.appendChild(nameTextArea);

    let lastNameP = document.createElement("p");
    lastNameP.style.textAlign = "center";
    lastNameP.innerText = 'Last Name';
    document.getElementById("modal-body").appendChild(lastNameP);
    let lastNameTextArea = document.createElement("input");
    lastNameP.appendChild(lastNameTextArea);

    let OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn-sm");
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
    let CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn-sm");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    showModal();
};

function updateUserById(id, firstname, lastname) {
    clearModal();
    let nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'First Name';
    document.getElementById("modal-body").appendChild(nameP);
    let nameTextArea = document.createElement("input");
    nameTextArea.value = firstname;
    nameP.appendChild(nameTextArea);

    let lastNameP = document.createElement("p");
    lastNameP.style.textAlign = "center";
    lastNameP.innerText = 'Last Name';
    document.getElementById("modal-body").appendChild(lastNameP);
    let lastNameTextArea = document.createElement("input");
    lastNameTextArea.value = lastname;
    lastNameP.appendChild(lastNameTextArea);

    let OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn-sm");
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
    let CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn-sm");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    showModal();
};

function deleteUserById(id) {
    clearModal();

    let confirmP = document.createElement("p");
    confirmP.style.textAlign = "center";
    confirmP.innerText = 'Are you sure ?';
    document.getElementById("modal-body").appendChild(confirmP);

    let OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.classList.add("btn-sm");
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
    let CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.classList.add("btn-sm");
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