namespace Lab03;

public class CarRawData
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public List<Tire> Tires { get; set; }

    public CarRawData(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }
}

public class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }

    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }
}

public class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }
}

public class Tire
{
    public int Age { get; set; }
    public double Pressure { get; set; }

    public Tire(int age, double pressure)
    {
        this.Age = age;
        this.Pressure = pressure;
    }
}