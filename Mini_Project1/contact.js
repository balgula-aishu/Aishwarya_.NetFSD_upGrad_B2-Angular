document.addEventListener("DOMContentLoaded", function () {

    let form = document.getElementById("contactForm");

    if (!form) return;

    form.addEventListener("submit", function (e) {

        e.preventDefault();

        let name = document.getElementById("name").value;
        let email = document.getElementById("email").value;
        let message = document.getElementById("message").value;

        console.log(name, email, message);

        alert("Your query has been submitted successfully!We will get back to you soon.");

        form.reset();

    });

});