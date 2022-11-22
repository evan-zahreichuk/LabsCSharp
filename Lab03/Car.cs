using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lab03;

public class Car
{
    public string Model { get; set; }
    public float FuelAmount { get; set; }
    public float FuelConsumptionPer1Km { get; set; }
    public float DistanceTraveled { get; set; }

    public Car(string model, float fuelAmount, float fuelConsumptionPer1Km)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPer1Km = fuelConsumptionPer1Km;
        this.DistanceTraveled = 0;
    }

    public void Travel(int kmToTravel)
    {
        var maxPossibleKmToTravel = this.FuelAmount / this.FuelConsumptionPer1Km;
        if (maxPossibleKmToTravel - kmToTravel > 0)
        {
            this.DistanceTraveled += kmToTravel;
            this.FuelAmount -= (kmToTravel * this.FuelConsumptionPer1Km);
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}