let db;

// Open or create database
let request = indexedDB.open("eventdb", 2);

request.onupgradeneeded = function (event) {
    db = event.target.result;

    console.log("Database created");

    // Create object store if not exists
    if (!db.objectStoreNames.contains("events")) {
        db.createObjectStore("events", { keyPath: "id" }); // keyPath as id
        console.log("ObjectStore 'events' created");
    }

    if (!db.objectStoreNames.contains("registrations")) {
        db.createObjectStore("registrations", { keyPath: "id" });
        console.log("ObjectStore 'registrations' created");
    }
};

request.onsuccess = function (event) {
    db = event.target.result;
    console.log("Database connected successfully");
};

request.onerror = function (event) {
    console.log("Database error:", event.target.error);
};