
// 1. Required parameter
function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}!`;
}

// 2. Optional parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age.`;
}

// 3. Default parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name} is subscribed.`
        : `${name} is not subscribed.`;
}

// 4. Boolean return type (RENAMED to avoid error)
function checkPremiumEligibility(age: number): boolean {
    return age > 18;
}

// 5. Arrow function
const getAlertMessage = (message: string): string => {
    return `Alert: ${message}`;
};

// 6. Lexical this
const notificationService = {
    appName: "MyApp",

    sendNotification: (user: string): string => {
        return `Hello ${user}, welcome to ${notificationService.appName}`;
    }
};

// 7. Execution
console.log(getWelcomeMessage("Aishwarya"));

console.log(getUserInfo("Aishwarya", 22));
console.log(getUserInfo("Aishwarya"));

console.log(getSubscriptionStatus("Aishwarya", true));
console.log(getSubscriptionStatus("Aishwarya"));

console.log("Eligible:", checkPremiumEligibility(22));

console.log(getAlertMessage("This is a system alert"));

console.log(notificationService.sendNotification("Aishwarya"));