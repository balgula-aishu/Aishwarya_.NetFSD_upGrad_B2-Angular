
class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    getSalary(): number {
        return this.salary;
    }

    setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be positive");
        }
    }

    displayDetails(): void {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
    }
}

class Manager extends Employee {
    public teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }

    displayDetails(): void {
        console.log(`ID: ${this.id}, Name: ${this.name}, Salary: ${this.getSalary()}, Team Size: ${this.teamSize}`);
    }
}

// Execution
const emp1 = new Employee(1, "Aishwarya", 30000);
emp1.displayDetails();

emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());

const mgr1 = new Manager(2, "Rahul", 60000, 5);
mgr1.displayDetails();