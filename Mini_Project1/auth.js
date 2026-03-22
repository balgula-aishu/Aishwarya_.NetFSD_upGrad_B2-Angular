document.addEventListener("DOMContentLoaded", function () {

    let form = document.getElementById("loginForm");

    if (!form) return;

    form.addEventListener("submit", function (e) {

        e.preventDefault();

        let email = document.getElementById("email").value;
        let password = document.getElementById("password").value;

        if (email === "admin@upgrad.com" && password === "12345") {

            sessionStorage.setItem("admin", "true");

            alert("Login Successful");

            window.location.href = "events.html";

        } else {

            alert("Invalid login credentials");

        }

    });

});