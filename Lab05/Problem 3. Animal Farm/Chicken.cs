namespace Lab05.Problem_3._Animal_Farm;

public class Chicken
{
    private string _name;
    private int _age;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(this.Name), "Name cannot be empty.");
            _name = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value <= 0 || value > 15)
                throw new ArgumentNullException(nameof(this.Age), "Age should be between 0 and 15.");
            _age = value;
        }
    }

    public int ProductPerDay
    {
        get => CalculateProductPerDay();
    }

    private int CalculateProductPerDay()
    {
        //2 eggs if younger than 10, otherwise 1 egg
        return this.Age >= 10 ? 1 : 2;
    }

    public Chicken(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}