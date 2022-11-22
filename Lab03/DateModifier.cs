namespace Lab03;

public class DateModifier
{
    public int DifferenceBetweenTwoDatesInDays { get; set; }

    public void CalculateDifference(string date1Str, string date2Str)
    {
        var date1 = DateTime.Parse(date1Str);
        var date2 = DateTime.Parse(date2Str);
        this.DifferenceBetweenTwoDatesInDays = Math.Abs((date1 - date2).Days);
        Console.WriteLine(this.DifferenceBetweenTwoDatesInDays);
    }
}