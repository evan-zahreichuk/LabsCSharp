namespace Lab05.Problem_4._Shopping_Spree;

public class Person
{
    private string _name;
    private float _money;

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

    public float Money
    {
        get => this._money;
        set
        {
            if (value < 0)
                throw new ArgumentNullException(nameof(this.Money), "Money cannot be negative.");
            this._money = value;
        }
    }

    public List<Product> BagOfProducts { get; set; }

    public Person(string name, float money)
    {
        this.Name = name;
        this.Money = money;
        BagOfProducts = new List<Product>();
    }
}