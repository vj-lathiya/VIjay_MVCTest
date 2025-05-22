
$(document).ready(function () {
    loadUsers(); 
});
function insertUser() {
    $(".error").text("");
    var isValid = true;

    var user = {
        firstName: $("#FirstName").val(),
        middleName: $("#MiddleName").val(),
        lastName: $("#LastName").val(),
        emailId: $("#EmailId").val(),
        userName: $("#UserName").val(),
        birthDate: $("#BirthDate").val()
    };

    if (user.firstName === "") {
        $("#FirstName_Error").text("First Name is required.");
        isValid = false;
    }

    if (user.middleName === "") {
        $("#MiddleName_Error").text("Middle Name Name is required.");
        isValid = false;
    }

    if (user.lastName === "") {
        $("#LastName_Error").text("Last Name is required.");
        isValid = false;
    }

    if (user.emailId === "") {
        $("#EmailId_Error").text("Email is required.");
        isValid = false;
    } else if (!isValidEmail(user.emailId)) {
        $("#EmailId_Error").text("Enter a valid email address.");
        isValid = false;
    }

    if (user.userName === "") {
        $("#UserName_Error").text("Username is required.");
        isValid = false;
    }

    if (user.birthDate === "") {
        $("#BirthDate_Error").text("Birth Date is required.");
        isValid = false;
    } else if (!isValidBirthDate(user.birthDate)) {
        $("#BirthDate_Error").text("Enter a valid past date.");
        isValid = false;
    }

    if (isValid) {
        $.ajax({
            type: "POST",
            url: "https://localhost:7214/api/v1/Home/InsertUser",
            data: JSON.stringify(user),
            contentType: "application/json",
            success: function (response) {
                if (response.statusCode === 200) {
                    window.location.href = "https://localhost:7164";
                } else {
                    alert("Failed to insert user: " + (response.message || "Unknown error"));
                }
            },
            error: function () {
                alert("Something went wrong while inserting the user.");
            }
        });
    }
}

function isValidEmail(email) {
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}
function isValidBirthDate(dateStr) {
    const date = new Date(dateStr);
    const today = new Date();
    return !isNaN(date.getTime()) && date <= today;
}
function loadUsers() {
    $.ajax({
        type: "GET",
        url: "https://localhost:7214/api/v1/Home/GetUsers",
        contentType: "application/json",
        success: function (response) {
            var rows = "";

            // Check if API call was successful and data exists
            if (response.statusCode === 200 && response.data && response.data.length > 0) {
                $.each(response.data, function (index, user) {
                    rows += `<tr>
                                <td>${index + 1}</td>
                                <td>${user.firstName}</td>
                                <td>${user.middleName || ''}</td>
                                <td>${user.lastName}</td>
                                <td>${user.userName}</td>
                                <td>${user.birthDate}</td>
                            </tr>`;
                });
            } else {
                rows = `<tr><td colspan="6" class="text-center">No users found</td></tr>`;
            }

            $("#UserTable tbody").html(rows);
        },
        error: function () {
            alert("Failed to load users.");
        }
    });
}



