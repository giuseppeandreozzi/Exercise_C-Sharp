Robot robot = new Robot();
string? input;

Console.WriteLine("Write three command, separated by enter key (on, off, nord, surd, east, west):");

for(int i = 0; i < 3; i++) {
    input = Console.ReadLine();

    if(input == "on") {
        robot.Commands[i] = new OnCommand();
    } else if (input == "off") {
        robot.Commands[i] = new OffCommand();
    } else if (input == "north") {
        robot.Commands[i] = new NorthCommand();
    } else if (input == "south") {
        robot.Commands[i] = new SouthCommand();
    } else if (input == "west") {
        robot.Commands[i] = new WestCommand();
    } else if (input == "east") {
        robot.Commands[i] = new EastCommand();
    }
}

robot.Run();