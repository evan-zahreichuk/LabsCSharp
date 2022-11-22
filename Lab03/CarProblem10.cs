namespace Lab03;

public class CarProblem10
{
    public string Model { get; set; }
    public EngineProblem10 Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public CarProblem10(string model, EngineProblem10 engine, int weight = -1, string color = "n/a")
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public override string ToString()
    {
        var weight = "";
        if (this.Weight > 0)
            weight = this.Weight.ToString();
        else
            weight = "n/a";

        var color = "";
        if (!string.IsNullOrEmpty(this.Color))
            color = this.Color.ToString();
        else
            color = "n/a";

        var displacement = "";
        if (this.Engine.Displacement > 0)
            displacement = this.Engine.Displacement.ToString();
        else
            displacement = "n/a";

        var efficiency = "";
        if (!string.IsNullOrEmpty(this.Engine.Efficiency))
            efficiency = this.Engine.Efficiency.ToString();
        else
            efficiency = "n/a";

        return
            $"{this.Model}:" +
            $"\n  {this.Engine.Model}:" +
            $"\n    Power: {this.Engine.Power}" +
            $"\n    Displacement: {displacement}" +
            $"\n    Efficiency: {efficiency}" +
            $"\n  Weight: {weight}" +
            $"\n  Color: {color}";
    }
}

public class EngineProblem10
{
    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public EngineProblem10(string model, int power, int displacement = -1, string efficiency = "n/a")
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
}