namespace Lab05.Problem_5._Pizza_Calories;

public class Dough
{
    private readonly FlourType _flourType;
    private readonly BakingTechnique _bakingTechnique;
    private double _weight;
    private double _calories;

    public Dough(string flourType, string backingTechnique, double weight)
    {
        try
        {
            this._flourType = (FlourType)Enum.Parse(typeof(FlourType), flourType, true);
            this._bakingTechnique = (BakingTechnique)Enum.Parse(typeof(BakingTechnique), backingTechnique, true);
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid type of dough.");
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
                if (value is < 1 or > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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
        if (this._flourType == FlourType.White)
        {
            this._calories *= 1.5;
            switch (this._bakingTechnique)
            {
                case BakingTechnique.Crispy:
                    return this._calories *= 0.9;
                case BakingTechnique.Chewy:
                    return this._calories *= 1.1;
                case BakingTechnique.Homemade:
                    return this._calories *= 1.0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            this._calories *= 1.0;
            switch (this._bakingTechnique)
            {
                case BakingTechnique.Crispy:
                    return this._calories *= 0.9;
                case BakingTechnique.Chewy:
                    return this._calories *= 1.1;
                case BakingTechnique.Homemade:
                    return this._calories *= 1.0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}