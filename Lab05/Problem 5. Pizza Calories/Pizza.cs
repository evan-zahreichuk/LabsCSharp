namespace Lab05.Problem_5._Pizza_Calories;

public class Pizza
{
    private string _name;
    private readonly List<Topping> _toppings;
    private readonly Dough _dough;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this._dough = dough;
        this._toppings = new List<Topping>();
    }

    public string Name
    {
        get => this._name;
        private set
        {
            try
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this._name = value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public IReadOnlyCollection<Topping> Toppings
    {
        get { return this._toppings.AsReadOnly(); }
    }

    public void AddTopping(Topping topping)
    {
        try
        {
            if (_toppings.Count >= 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this._toppings.Add(topping);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public double GetTotalCalories()
    {
        var doughCalories = this._dough.Calories;
        var toppingsCalories = this._toppings.Select(t => t.Calories).Sum();
        var totalCalories = doughCalories + toppingsCalories;

        return totalCalories;
    }
}