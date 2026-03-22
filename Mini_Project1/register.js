// Get Event ID from URL
let eventId = new URLSearchParams(window.location.search).get("id");

document.addEventListener("DOMContentLoaded", function () {

    // Wait until DB is ready
    let checkDB = setInterval(() => {
        if (typeof db !== "undefined") {
            loadEventDetails();
            clearInterval(checkDB);
        }
    }, 500);

    let form = document.getElementById("registerForm");

    form.addEventListener("submit", function (e) {
        e.preventDefault();

        if (!db) {
            alert("Please wait, database is loading...");
            return;
        }

        let data = {
            id: Date.now().toString(), // unique registration ID
            eventId:(eventId), // ensure number matches event ID type
            firstName: document.getElementById("firstName").value,
            lastName: document.getElementById("lastName").value,
            email: document.getElementById("email").value
        };

        let tx = db.transaction(["registrations"], "readwrite");
        let store = tx.objectStore("registrations");
        let req = store.add(data);

        req.onsuccess = function () {
            alert("🎉 You have registered for this event!");
            form.reset();
        };

        req.onerror = function () {
            alert("❌ Registration failed. Try again.");
        };
    });
});

function loadEventDetails() {

    if (!eventId) {
        document.getElementById("eventDetails").innerHTML =
            "<p class='text-danger'>No event selected</p>";
        return;
    }

    let tx = db.transaction(["events"], "readonly");
    let store = tx.objectStore("events");
    let req = store.get(eventId); // make sure type matches ID in DB

    req.onsuccess = function () {
        let event = req.result;

        if (event) {
            document.getElementById("eventDetails").innerHTML = `
                <h5 class="mb-3">Event Details</h5>
                <p><b>ID:</b> ${event.id}</p>
                <p><b>Name:</b> ${event.name}</p>
                <p><b>Category:</b> ${event.category}</p>
                <p><b>Date:</b> ${event.date}</p>
                <p><b>Time:</b> ${event.time}</p>
            `;
        } else {
            document.getElementById("eventDetails").innerHTML =
                "<p class='text-danger'>Event not found</p>";
        }
    };

    req.onerror = function () {
        document.getElementById("eventDetails").innerHTML =
            "<p class='text-danger'>Error loading event</p>";
    };
}