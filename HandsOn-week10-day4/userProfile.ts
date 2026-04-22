// 1. Variable Declaration
const userName: string = "Aishwarya";
let age: number = 22;
const email: string = "aishwarya@example.com";
const isSubscribed: boolean = true;

// 2. Type Inference
let city = "Hyderabad";
let loginCount = 5;

// 3. let / const usage
const country: string = "India";
age = age + 1;

// 4. Template Literals
const profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;

// 5. Operators
age++;

const isEligibleForPremium: boolean = age > 18 && isSubscribed;
const isAdult: boolean = age >= 18;

// 6. Output
console.log("User Profile:");
console.log(profileMessage);
console.log("City:", city);
console.log("Login Count:", loginCount);
console.log("Country:", country);
console.log("Updated Age:", age);
console.log("Is Adult:", isAdult);
console.log("Eligible for Premium:", isEligibleForPremium);