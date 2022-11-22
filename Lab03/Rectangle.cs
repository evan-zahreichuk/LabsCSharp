namespace Lab03;

public class Rectangle
{
    public string Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int TopLeftCornerXCoordinate { get; set; }
    public int TopLeftCornerYCoordinate { get; set; }
    public int BottomRightCornerXCoordinate { get; set; }
    public int BottomRightCornerYCoordinate { get; set; }

    public Rectangle(string id, int width, int height, int topLeftCornerXCoordinate, int topLeftCornerYCoordinate)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftCornerXCoordinate = topLeftCornerXCoordinate;
        this.TopLeftCornerYCoordinate = topLeftCornerYCoordinate;
        this.BottomRightCornerXCoordinate = topLeftCornerXCoordinate + this.Width;
        this.BottomRightCornerYCoordinate = topLeftCornerYCoordinate - this.Height;
    }

    public bool CheckIntersection(Rectangle other)
    {
        //if one rectangle is on left / right / top / bottom side of other
        if (this.TopLeftCornerXCoordinate + this.Width < other.TopLeftCornerXCoordinate
            || this.TopLeftCornerXCoordinate > other.TopLeftCornerXCoordinate + other.Width
            || this.TopLeftCornerYCoordinate + this.Height < other.TopLeftCornerYCoordinate
            || this.TopLeftCornerYCoordinate > other.TopLeftCornerYCoordinate + other.Height)
            return false;

        //if everything is ok
        return true;
    }
}