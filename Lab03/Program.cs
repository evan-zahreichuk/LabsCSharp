using System.Drawing;
using System.Globalization;
using Lab03;
using Rectangle = Lab03.Rectangle;

var loopBreak = true;
while (loopBreak)
{
    Console.WriteLine("Select the problem(1-10) or exit(0):");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            Problem1_2();
            break;
        case 2:
            Problem1_2();
            break;
        case 3:
            Problem3();
            break;
        case 4:
            Problem4();
            break;
        case 5:
            Problem5();
            break;
        case 6:
            Problem6();
            break;
        case 7:
            Problem7();
            break;
        case 8:
            Problem8();
            break;
        case 9:
            Problem9();
            break;
        case 10:
            Problem10();
            break;
        default:
            Console.WriteLine("Exiting the Lab 3...");
            loopBreak = false;
            break;
    }

    if (!loopBreak) break;
}

// Problem 1 & 2
void Problem1_2()
{
    Console.WriteLine("Problem 1 & 2");
    Person person = new Person();
    person.Age = 20;
    person.Name = "Pesho";

    var personInline = new Person { Age = 18, Name = "Gosho" };
    var personInline1 = new Person("Stamat", 43);
}

// Problem 3
void Problem3()
{
    Console.WriteLine("Problem 3");

    var family = new Family();
    Console.WriteLine("Number of family members to add:");
    var count = int.Parse(Console.ReadLine());
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine("Name of the family member:");
        var name = Console.ReadLine();
        Console.WriteLine("Age of the family member:");
        var age = int.Parse(Console.ReadLine());
        family.AddMember(new Person(name, age));
    }

    Console.WriteLine(family.GetOldestMember());
}

// Problem 4
void Problem4()
{
    Console.WriteLine("Problem 4");

    var pollMembers = new List<Person>();
    Console.WriteLine("Number of poll members to add:");
    var countOfPollMembers = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfPollMembers; i++)
    {
        Console.WriteLine("Name and age of the family member:");
        var personalInfo = Console.ReadLine();
        var name = personalInfo.Split(' ')[0];
        var age = int.Parse(personalInfo.Split(' ')[1]);
        pollMembers.Add(new Person(name, age));
    }

    var moreThan30 = pollMembers
        .Where(pm => pm.Age > 30)
        .OrderBy(pm => pm.Name)
        .ToList();
    foreach (var p in moreThan30)
    {
        Console.WriteLine(p);
    }
}

// Problem 5
void Problem5()
{
    Console.WriteLine("Problem 5");

    var dateModifier = new DateModifier();
    Console.WriteLine("Date 1:");
    var date1Str = Console.ReadLine();
    Console.WriteLine("Date 2:");
    var date2Str = Console.ReadLine();
    dateModifier.CalculateDifference(date1Str, date2Str);
}

// Problem 6
void Problem6()
{
    Console.WriteLine("Problem 6");

    var employees = new List<Employee>();
    Console.WriteLine("Number of employees to add:");
    var countOfEmployees = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfEmployees; i++)
    {
        Console.WriteLine("Name / Salary / Position / Department / Email(optional) / Age(optional): ");
        var employeeInfo = Console.ReadLine();
        var hasEmail = !string.IsNullOrEmpty(employeeInfo.Split(' ')[4]) &&
                       !int.TryParse(employeeInfo.Split(' ')[4], out _);
        int hasAgeCharPosition = 0;
        if (!string.IsNullOrEmpty(employeeInfo.Split(' ')[4]) && int.TryParse(employeeInfo.Split(' ')[4], out _))
            hasAgeCharPosition = 4;
        else if (!string.IsNullOrEmpty(employeeInfo.Split(' ').Last()) &&
                 int.TryParse(employeeInfo.Split(' ').Last(), out _))
            hasAgeCharPosition = 5;
        var name = employeeInfo.Split(' ')[0];
        var salary = Math.Truncate(double.Parse(employeeInfo.Split(' ')[1]) * 100) / 100;
        var position = employeeInfo.Split(' ')[2];
        var department = employeeInfo.Split(' ')[3];
        var email = string.Empty;
        if (hasEmail)
            email = employeeInfo.Split(' ')[4];
        var age = 0;
        if (hasAgeCharPosition > 0)
            age = int.Parse(employeeInfo.Split(' ')[hasAgeCharPosition]);
        employees.Add(new Employee(name, salary, position, department, email, age));
    }

    var averageSalariesPerDepartmentDictionary = new Dictionary<double, string>();
    foreach (var dep in employees.Select(x => x.Department).ToHashSet())
    {
        averageSalariesPerDepartmentDictionary.TryAdd(employees.Where(e => e.Department == dep).Average(e => e.Salary),
            dep);
    }

    var maxAvgSalaryDepartment = averageSalariesPerDepartmentDictionary.MaxBy(x => x.Key);
    Console.WriteLine(
        $"Highest Average Salary is {maxAvgSalaryDepartment.Key} in {maxAvgSalaryDepartment.Value} department");
    Console.WriteLine("Name\tSalary\tPosition\tDepartment\tEmail(optional)\tAge(optional): ");
    foreach (var e in employees.Where(e => e.Department == maxAvgSalaryDepartment.Value).ToList())
    {
        Console.WriteLine($"{e.Name}\t{e.Salary}\t{e.Position}\t{e.Department}\t{e.Email}\t{e.Age}");
    }
}

// Problem 7
void Problem7()
{
    Console.WriteLine("Problem 7");

    var cars = new List<Car>();
    Console.WriteLine("Number of cars to add:");
    var countOfCars = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfCars; i++)
    {
        Console.WriteLine("Model / FuelAmount / FuelConsumptionFor1Km: ");
        var carInfo = Console.ReadLine();
        var model = carInfo.Split(' ')[0];
        var fuelAmount = float.Parse(carInfo.Split(' ')[1], CultureInfo.InvariantCulture);
        var fuelConsumptionPer1Km = float.Parse(carInfo.Split(' ')[2], CultureInfo.InvariantCulture);
        cars.Add(new Car(model, fuelAmount, fuelConsumptionPer1Km));
    }

    var driveCommands = new List<string>();
    while (true)
    {
        var command = Console.ReadLine();
        if (command is "End" or "end")
            break;

        driveCommands.Add(command);
    }

    foreach (var driveCommand in driveCommands)
    {
        var model = driveCommand.Split(' ')[1];
        var kmToTravel = int.Parse(driveCommand.Split(' ')[2]);
        cars.FirstOrDefault(c => c.Model == model)?.Travel(kmToTravel);
    }

    foreach (var car in cars)
    {
        Console.WriteLine(
            $"{car.Model}\t{car.FuelAmount.ToString("0.00", CultureInfo.InvariantCulture)}\t{car.DistanceTraveled}");
    }
}

// Problem 8
void Problem8()
{
    Console.WriteLine("Problem 8");

    var cars = new List<CarRawData>();
    Console.WriteLine("Number of cars to add:");
    var countOfCars = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfCars; i++)
    {
        Console.WriteLine(
            "Model / EngineSpeed / EnginePower / CargoWeight / CargoType / Tire1Pressure / Tire1Age / Tire2Pressure / Tire2Age / Tire3Pressure / Tire3Age / Tire4Pressure / Tire4Age: ");
        var carInfo = Console.ReadLine();
        var model = carInfo.Split(' ')[0];
        var engineSpeed = int.Parse(carInfo.Split(' ')[1], CultureInfo.InvariantCulture);
        var enginePower = int.Parse(carInfo.Split(' ')[2], CultureInfo.InvariantCulture);
        var cargoWeight = int.Parse(carInfo.Split(' ')[3], CultureInfo.InvariantCulture);
        var cargoType = carInfo.Split(' ')[4];
        var tire1Pressure = double.Parse(carInfo.Split(' ')[5], CultureInfo.InvariantCulture);
        var tire1Age = int.Parse(carInfo.Split(' ')[6], CultureInfo.InvariantCulture);
        var tire2Pressure = double.Parse(carInfo.Split(' ')[7], CultureInfo.InvariantCulture);
        var tire2Age = int.Parse(carInfo.Split(' ')[8], CultureInfo.InvariantCulture);
        var tire3Pressure = double.Parse(carInfo.Split(' ')[9], CultureInfo.InvariantCulture);
        var tire3Age = int.Parse(carInfo.Split(' ')[10], CultureInfo.InvariantCulture);
        var tire4Pressure = double.Parse(carInfo.Split(' ')[11], CultureInfo.InvariantCulture);
        var tire4Age = int.Parse(carInfo.Split(' ')[12], CultureInfo.InvariantCulture);
        cars.Add(new CarRawData(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType),
            new List<Tire>
            {
                new Tire(tire1Age, tire1Pressure), new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure), new Tire(tire4Age, tire4Pressure)
            }));
    }

    var command = Console.ReadLine();
    if (command == "fragile")
    {
        cars.Where(c => c.Cargo.Type == "fragile"
                        && c.Tires.Any(t => t.Pressure < 1))
            .Select(c => c.Model).ToList()
            .ForEach(Console.WriteLine);
    }
    else if (command == "flamable")
    {
        cars.Where(c => c.Cargo.Type == "flamable"
                        && c.Engine.Power > 250)
            .Select(c => c.Model).ToList()
            .ForEach(Console.WriteLine);
    }
}

// Problem 9
void Problem9()
{
    Console.WriteLine("Problem 9");

    var rectangles = new List<Rectangle>();
    Console.WriteLine("Number of rectangles to check:");
    var countOfRectangles = int.Parse(Console.ReadLine());
    Console.WriteLine("Number of intersections to check:");
    var countOfIntersections = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfRectangles; i++)
    {
        Console.WriteLine(
            "Id / Width / Height / Top Left X / Top Left Y: ");
        var rectangleInfo = Console.ReadLine();
        var id = rectangleInfo.Split(' ')[0];
        var width = int.Parse(rectangleInfo.Split(' ')[1], CultureInfo.InvariantCulture);
        var height = int.Parse(rectangleInfo.Split(' ')[2], CultureInfo.InvariantCulture);
        var topLeftXCoordinate = int.Parse(rectangleInfo.Split(' ')[3], CultureInfo.InvariantCulture);
        var topLeftYCoordinate = int.Parse(rectangleInfo.Split(' ')[4], CultureInfo.InvariantCulture);
        rectangles.Add(new Rectangle(id, width, height, topLeftXCoordinate, topLeftYCoordinate));
    }

    var ids = Console.ReadLine();
    var id1 = ids.Split(' ')[0];
    var id2 = ids.Split(' ')[1];
    var rectangle1 = rectangles.FirstOrDefault(r => r.Id == id1);
    var rectangle2 = rectangles.FirstOrDefault(r => r.Id == id2);
    var res = rectangle1.CheckIntersection(rectangle2);
    Console.WriteLine($"Do {rectangle1.Id} and {rectangle2.Id} intersect?: " + res);
}

// Problem 10
void Problem10()
{
    Console.WriteLine("Problem 10");

    var engines = new List<EngineProblem10>();
    Console.WriteLine("Number of engines:");
    var countOfEngines = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfEngines; i++)
    {
        Console.WriteLine(
            "Model / Power / Displacement(Optional) / Efficiency(Optional): ");
        var engineInfo = Console.ReadLine();
        var model = engineInfo.Split(' ')[0];
        var power = int.Parse(engineInfo.Split(' ')[1]);

        int displacement = 0;
        int hasDisplacementCharPosition = 0;
        if (!string.IsNullOrEmpty(engineInfo.Split(' ')[2])
            && int.TryParse(engineInfo.Split(' ')[2], out _))
            hasDisplacementCharPosition = 2;

        string efficiency = string.Empty;
        int hasEfficiencyCharPosition = 0;
        if (!string.IsNullOrEmpty(engineInfo.Split(' ').Last())
            && !int.TryParse(engineInfo.Split(' ').Last(), out _))
            hasEfficiencyCharPosition = 3;

        if (hasDisplacementCharPosition > 0)
            displacement = int.Parse(engineInfo.Split(' ')[hasDisplacementCharPosition]);
        if (hasEfficiencyCharPosition > 0)
            efficiency = engineInfo.Split(' ')[hasEfficiencyCharPosition];

        engines.Add(new EngineProblem10(model, power, displacement, efficiency));
    }

    var cars = new List<CarProblem10>();
    Console.WriteLine("Number of cars:");
    var countOfCars = int.Parse(Console.ReadLine());
    for (int i = 0; i < countOfCars; i++)
    {
        Console.WriteLine(
            "Model / Engine Model / Weight(Optional) / Color(Optional): ");
        var carInfo = Console.ReadLine();
        var model = carInfo.Split(' ')[0];
        var engineModel = carInfo.Split(' ')[1];

        int weight = 0;
        int hasWeightCharPosition = 0;
        try
        {
            if (!string.IsNullOrEmpty(carInfo.Split(' ')[2])
                && int.TryParse(carInfo.Split(' ')[2], out _))
                hasWeightCharPosition = 2;
        } catch (Exception e) { }

        string color = string.Empty;
        int hasColorCharPosition = 0;
        if (Color.FromName(carInfo.Split(' ').Last()).IsKnownColor)
            hasColorCharPosition = carInfo.Split(' ').Length - 1;

        if (hasWeightCharPosition > 0)
            weight = int.Parse(carInfo.Split(' ')[hasWeightCharPosition]);
        if (hasColorCharPosition > 0)
            color = carInfo.Split(' ')[hasColorCharPosition];

        cars.Add(new CarProblem10(model, engines.FirstOrDefault(e => e.Model == engineModel), weight, color));
    }

    foreach (var car in cars)
    {
        Console.WriteLine(car);
    }
}