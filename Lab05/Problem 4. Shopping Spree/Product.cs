namespace Lab05.Problem_4._Shopping_Spree;

public class Product
{
    private string _name;
    private float _cost;

    public string Name
    {
        get => this._name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(this.Name), "Name cannot be empty.");
            this._name = value;
        }
    }

    public float Cost
    {
        get => this._cost;
        set
        {
            if (value < 0)
                throw new ArgumentNullException(nameof(this.Cost), "Cost cannot be negative.");
            this._cost = value;
        }
    }

    public Product(string name, float cost)
    {
        this.Name = name;
        this.Cost = cost;
    }
}