
// Store student marks in an array
const studentMarks = [78, 85, 62, 90, 55];

// Arrow function to calculate total using reduce()
const calculateTotal = (marks) =>
  marks.reduce((total, mark) => total + mark, 0);

// Arrow function to calculate average
const calculateAverage = (marks) =>
  marks.length === 0 ? 0 : calculateTotal(marks) / marks.length;

// Arrow function to determine pass/fail
const getResult = (average) =>
  average >= 40 ? "Pass ✅" : "Fail ❌";

// Using map() to format marks display
const formattedMarks = studentMarks.map(
  (mark, index) => `Subject ${index + 1}: ${mark}`
);

// Perform calculations
const totalMarks = calculateTotal(studentMarks);
const averageMarks = calculateAverage(studentMarks);
const result = getResult(averageMarks);

// Display Output using template literals
console.log(`
 Student Marks Report
-----------------------
Marks:
${formattedMarks.join("\n")}

Total Marks: ${totalMarks}
Average Marks: ${averageMarks.toFixed(2)}
Result: ${result}
`);