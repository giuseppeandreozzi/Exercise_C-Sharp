Console.Title = "Fountain of Objects";

Game game;

while (true) { 
    Console.Write($"Type which size of game you want to play: small, medium or large: ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    string sizeGame = Console.ReadLine();

    if (sizeGame == "small") {
        game = new Game(new GridSmall());
    } else if (sizeGame == "medium") {
        game = new Game(new GridMedium());
    } else if (sizeGame == "large") {
        game = new Game(new GridLarge());
    } else {
        Console.WriteLine("Incorrect input");
        continue;
    }

    break;
}
while (true) {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"You are in the room at (Row = {game.positionPlayer.x}, Column={game.positionPlayer.y})");
    if (game.CheckPits()) {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You fell in a pit. You lose!");
        break;
    }

    if (game.CheckWin()) {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!");
        break;
    }

    if (game.CheckAdjacentRoomsForPits())
        Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
 
    if (game.positionPlayer == (0, 0)) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
    } else if (game.positionPlayer == game.GetPositionFountain()) {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (!game.fountainState)
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
        if (!game.MovePlayer(command[1])) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You can't go there!");
            continue;
        }
    } else if (input == "enable fountain") {
        if(game.positionPlayer == game.GetPositionFountain())
            game.fountainState = true;
    }

}
