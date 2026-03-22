document.addEventListener("DOMContentLoaded", function () {

    // Admin check
    if(sessionStorage.getItem("admin") !== "true"){
        alert("Unauthorized Access");
        window.location.href = "login.html";
    }

    let form = document.getElementById("eventForm");
    if (form) form.addEventListener("submit", addEvent);

    let checkDB = setInterval(() => {
        if(typeof db !== "undefined"){
            displayEvents();
            clearInterval(checkDB);
        }
    }, 500);

    // Search button
    document.getElementById("searchBtn").addEventListener("click", function() {
        let type = document.getElementById("searchType").value;
        searchEvents(type);
    });
});

// ➕ ADD EVENT
function addEvent(e){
    e.preventDefault();

    let eventData = {
        id: document.getElementById("eventId").value.trim(),
        name: document.getElementById("eventName").value.trim(),
        category: document.getElementById("eventCategory").value,
        date: document.getElementById("eventDate").value,
        time: document.getElementById("eventTime").value,
        url: document.getElementById("eventUrl").value
    };

    if(!eventData.id){
        alert("Event ID is required!");
        return;
    }

    let tx = db.transaction(["events"], "readwrite");
    let store = tx.objectStore("events");

    let request = store.add(eventData);

    request.onsuccess = function(){
        alert("Event Added Successfully");
        document.getElementById("eventForm").reset();
        displayEvents();
    };

    request.onerror = function(){
        alert("Error: Event ID already exists!");
    };
}

// 📋 DISPLAY ALL EVENTS
function displayEvents(){
    let tx = db.transaction(["events"], "readonly");
    let store = tx.objectStore("events");

    store.getAll().onsuccess = function(e){
        let events = e.target.result;
        renderEvents(events);
    };
}

// 🔍 SEARCH EVENTS
function searchEvents(type){
    let tx = db.transaction(["events"], "readonly");
    let store = tx.objectStore("events");

    store.getAll().onsuccess = function(e){
        let events = e.target.result;

        // Prompt user to enter value for ID/Name/Category
        let value = "";
        if(type !== "all"){
            value = prompt("Enter value to search by " + type + ":");
            if(!value) return; // cancel if empty
            value = value.toLowerCase();
        }

        let filtered = events.filter(ev => {
            if(type === "all") return true;
            if(type === "id") return ev.id.toLowerCase() === value;
            if(type === "name") return ev.name.toLowerCase() === value;
            if(type === "category") return ev.category.toLowerCase() === value;
        });

        renderEvents(filtered);
    };
}

// Render event cards dynamically
function renderEvents(events){
    let container = document.getElementById("eventContainer");
    container.innerHTML = "";

    events.forEach(e => {
        container.innerHTML += `
        <div class="col-md-6 mb-4">
            <div class="card shadow">
                <div class="card-body text-center">
                    <h5 style="color:#001f3f;">${e.name}</h5>
                    <p><b>ID:</b> ${e.id}</p>
                    <p><b>Category:</b> ${e.category}</p>
                    <p><b>Date:</b> ${e.date}</p>
                    <p><b>Time:</b> ${e.time}</p>
                    <a href="${e.url}" target="_blank" class="btn btn-primary mb-2" style="background-color:#001f3f;">Join Event</a>
                    <a href="register.html?id=${e.id}" class="btn btn-success mb-2">Register</a>
                    <button onclick="deleteEvent('${e.id}')" class="btn btn-danger">Delete</button>
                </div>
            </div>
        </div>
        `;
    });
}

// ❌ DELETE EVENT
function deleteEvent(id){
    let tx = db.transaction(["events"], "readwrite");
    let store = tx.objectStore("events");
    store.delete(id);
    alert("Event Deleted");
    displayEvents();
}


