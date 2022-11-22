namespace Lab05.Problem_5._Pizza_Calories;

public class Topping
{
    private readonly ToppingType _toppingType;
    private double _weight;
    private double _calories;

    public Topping(string toppingType, double weight)
    {
        try
        {
            this._toppingType = (ToppingType)Enum.Parse(typeof(ToppingType), toppingType, true);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cannot place {toppingType} on top of your pizza.");
            throw;
        }

        this.Weight = weight;
        this._calories = this._weight * 2;
    }

    private double Weight
    {
        set
        {
            try
            {
                if (value is < 1 or > 50)
                {
                    throw new ArgumentException($"{this._toppingType} weight should be in the range [1..50].");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            this._weight = value;
        }
    }

    public double Calories
    {
        get { return this.GetCalories(); }
    }

    private double GetCalories()
    {
        return this._toppingType switch
        {
            ToppingType.Meat => this._calories *= 1.2,
            ToppingType.Veggies => this._calories *= 0.8,
            ToppingType.Cheese => this._calories *= 1.1,
            ToppingType.Sauce => this._calories *= 0.9,
            _ => throw new InvalidOperationException()
        };
    }
}