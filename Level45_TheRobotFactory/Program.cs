using System.Dynamic;

dynamic robot;
int currentId = 1;

while (true) {
    robot = new ExpandoObject();
    Console.WriteLine("You are producing robot #" + currentId);
    robot.Id = currentId;
    Console.Write("Do you want to name the robot? (yes/no): ");
    if (Console.ReadLine() == "yes") {
        Console.Write("What is its name? ");
        robot.Name = Console.ReadLine();
    }

    Console.Write("Does this robot have a specific size? (yes/no): ");
    if (Console.ReadLine() == "yes") {
        Console.Write("What is its height? ");
        robot.Height = Console.ReadLine();
        Console.Write("What is its width? ");
        robot.Width = Console.ReadLine();
    }

    Console.Write("Does this robot need to be a specific color? (yes/no): ");
    if (Console.ReadLine() == "yes") {
        Console.Write("What color? ");
        robot.Color = Console.ReadLine();
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>) robot)
        Console.WriteLine($"{property.Key}: {property.Value}");

    currentId++;
}

