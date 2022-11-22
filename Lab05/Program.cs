using System.Globalization;
using System.Text;
using Lab05;
using Lab05.Problem_3._Animal_Farm;
using Lab05.Problem_4._Shopping_Spree;
using Lab05.Problem_5._Pizza_Calories;

var loopBreak = true;
while (loopBreak)
{
    Console.WriteLine("Select the problem(1-5) or exit(0):");

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
        default:
            Console.WriteLine("Exiting the Lab 5...");
            loopBreak = false;
            break;
    }

    if (!loopBreak) break;
}

// Problem 1 & 2
void Problem1_2()
{
    Console.WriteLine("Problem 1 & 2");

    Console.WriteLine("length / width / height:");
    var length = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    var width = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    var height = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    try
    {
        var box = new Box(length, width, height);
        box.CalculateSurfaceArea();
        box.CalculateLateralSurfaceArea();
        box.CalculateVolume();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

// Problem 3
void Problem3()
{
    Console.WriteLine("Problem 3");

    Console.WriteLine("name / age:");
    var name = Console.ReadLine();
    var age = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    var chicken = new Chicken(name, age);
    Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} egg(s) per day");
}

// Problem 4
void Problem4()
{
    Console.WriteLine("Problem 4");
    try
    {
        var persons = new List<Person>();
        var products = new List<Product>();
        Console.WriteLine("Line with persons and their money:");
        var personsWithMoneyStr = Console.ReadLine();
        Console.WriteLine("Line with products and their costs:");
        var productsWithCostsStr = Console.ReadLine();

        var separatorForPersons = personsWithMoneyStr.Contains(';') ? ";" : "";
        for (int i = 0; i < personsWithMoneyStr.Split(separatorForPersons).Length; i++)
        {
            var name = personsWithMoneyStr.Split(separatorForPersons)[i].Split('=')[0];
            var money = float.Parse(personsWithMoneyStr.Split(separatorForPersons)[i].Split('=')[1],
                CultureInfo.InvariantCulture);

            persons.Add(new Person(name, money));
        }

        var separatorForProducts = productsWithCostsStr.Contains(';') ? ";" : "";
        for (int i = 0; i < productsWithCostsStr.Split(separatorForProducts).Length; i++)
        {
            //handle when extra ; at the end of the string
            if (!productsWithCostsStr.Split(separatorForProducts)[i].Contains('='))
                continue;
            var name = productsWithCostsStr.Split(separatorForProducts)[i].Split('=')[0];
            var cost = float.Parse(productsWithCostsStr.Split(separatorForProducts)[i].Split('=')[1],
                CultureInfo.InvariantCulture);

            products.Add(new Product(name, cost));
        }

        var buyCommands = new List<string>();
        Console.WriteLine("Type buy commands and press ENTER (type \"END\" when done)");
        while (true)
        {
            var command = Console.ReadLine();
            if (command is "End" or "end" or "END")
                break;

            buyCommands.Add(command);
        }

        var sb = new StringBuilder();
        foreach (var buyCommand in buyCommands)
        {
            var personName = buyCommand.Split(' ')[0];
            var productNameThatPersonTriesToBuy = buyCommand.Split(' ')[1];
            var person = persons.FirstOrDefault(p => p.Name == personName);
            var product = products.FirstOrDefault(p => p.Name == productNameThatPersonTriesToBuy);
            if (person.Money - product.Cost >= 0)
            {
                person.Money -= product.Cost;
                person.BagOfProducts.Add(product);
                sb.AppendLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                sb.AppendLine($"{person.Name} can't afford {product.Name}");
            }
        }

        Console.Write(sb.ToString());
        foreach (var person in persons)
        {
            var boughtProductsStr = person.BagOfProducts.Count > 0
                ? string.Join(',', person.BagOfProducts.Select(p => p.Name))
                : "Nothing bought";
            Console.WriteLine($"{person.Name} - {boughtProductsStr}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

// Problem 5
void Problem5()
{
    Console.WriteLine("Problem 5");

    var commands = new List<string>();
    Console.WriteLine("Type pizza commands and press ENTER (type \"END\" when done)");
    while (true)
    {
        var command = Console.ReadLine();
        if (command is "End" or "end" or "END")
            break;

        commands.Add(command);
    }

    //get pizza name from first line
    var pizzaNameCommand = commands[0];
    var pizzaName = pizzaNameCommand.Split(' ')[1];

    //get dough from second line
    var doughCommand = commands[1];
    var flourType = doughCommand.Split(' ')[1];
    var bakingTechnique = doughCommand.Split(' ')[2];
    var doughWeight = double.Parse(doughCommand.Split(' ')[3], CultureInfo.InvariantCulture);
    var dough = new Dough(flourType, bakingTechnique, doughWeight);
    var pizza = new Pizza(pizzaName, dough);

    //cut only topping commands from all the commands
    var toppingCommands = commands.GetRange(2, commands.Count - 2);
    foreach (var toppingCommand in toppingCommands)
    {
        var toppingType = toppingCommand.Split(' ')[1];
        var toppingWeight = double.Parse(toppingCommand.Split(' ')[2], CultureInfo.InvariantCulture);
        var topping = new Topping(toppingType, toppingWeight);
        pizza.AddTopping(topping);
    }

    Console.WriteLine($"{pizza.Name} has {pizza.GetTotalCalories()} calories");
}