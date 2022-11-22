namespace Lab05;

public class Box
{
    private float _length;
    private float _width;
    private float _height;

    public float Length
    {
        get => this._length;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(this.Length), "Length cannot be zero or negative");

            this._length = value;
        }
    }

    public float Width
    {
        get => this._width;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(this.Width), "Width cannot be zero or negative");

            this._width = value;
        }
    }

    public float Height
    {
        get => this._height;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(this.Height), "Height cannot be zero or negative");

            this._height = value;
        }
    }

    public Box(float length, float width, float height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public void CalculateSurfaceArea()
    {
        Console.WriteLine(
            $"Surface Area - {2 * this._length * this._width + 2 * this._length * this._height + 2 * this._width * this._height}");
    }

    public void CalculateLateralSurfaceArea()
    {
        Console.WriteLine(
            $"Lateral Surface Area - {2 * this._length * this._height + 2 * this._width * this._height}");
    }
    
    public void CalculateVolume()
    {
        Console.WriteLine(
            $"Volume - {this._length * this._width * this._height}");
    }
}