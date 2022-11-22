namespace Lab03;

public class Person
{
    private string _name;
    private int _age;

    public string Name
    {
        get => this._name;
        set => this._name = value;
    }

    public int Age
    {
        get => this._age;
        set => this._age = value > 0 ? value : -1;
    }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}; Age: {this.Age}";
    }
}