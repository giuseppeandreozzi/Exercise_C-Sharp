Console.Title = "Fountain of Objects";

Grid grid = new Grid();

while (true) {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"You are in the room at (Row = {grid.positionPlayer.x}, Column={grid.positionPlayer.y})");
    if (grid.CheckWin()) {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!");
        break;
    }
    if (grid.positionPlayer == (0, 0)) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
    } else if (grid.positionPlayer == grid.positionFountain) {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (!grid.fountainState)
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        else
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
    }

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("What do you want to do? ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    string? input = Console.ReadLine();
    string[]? command = input?.Split(" ");

    if (command?[0] == "move") {
        if (!grid.MovePlayer(command[1])) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You can't go there!");
            continue;
        }
    } else if (input == "enable fountain") {
        if(grid.positionPlayer == grid.positionFountain)
            grid.fountainState = true;
    }

}
