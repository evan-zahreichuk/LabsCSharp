namespace Lab03;

public class Employee : Person
{
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }

    public Employee(string name, double salary, string position, string department, string email = "n/a", int age = -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = !string.IsNullOrEmpty(email) ? email : "n/a";
        this.Age = age;
    }
}