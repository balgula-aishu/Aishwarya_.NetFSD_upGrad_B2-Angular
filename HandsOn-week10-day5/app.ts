// app.ts

import { Student } from "./student.model";
import { getGrade, getTopper } from "./student.service";
import { formatName, calculateAverage } from "./utils";

// Sample Data
const students: Student[] = [
    { id: 1, name: "aishwarya", marks: 85 },
    { id: 2, name: "rahul", marks: 72 },
    { id: 3, name: "sneha", marks: 90 }
];

// Format Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});

// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${s.name}: ${getGrade(s.marks)}`);
});

// Average
console.log("\nAverage Marks:", calculateAverage(students));

// Topper
const topper = getTopper(students);
console.log("\nTopper:", topper);