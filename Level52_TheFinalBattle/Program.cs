using Level52_TheFinalBattle;

Console.WriteLine($"Which mode do you want to play?");
Console.WriteLine($"1- Player vs Player 2- Player vs Computer 3- Computer vs Computer");
int choiceUser, choicePotion = 1;
int.TryParse(Console.ReadLine(), out choiceUser);
Game.Gamemode gamemode = choiceUser switch {
    1 => Game.Gamemode.PVP,
    2 => Game.Gamemode.PVC,
    3 => Game.Gamemode.CVC
};
Console.Write($"Insert the hero name: ");
Game game = new Game([new Hero(Console.ReadLine()?.ToUpper())], [[new Skeleton()], [new Skeleton(), new Skeleton()], [new TheUncodedOne()]], gamemode);
string? currentAction, endPhrase, stringToPrint = "";
Random random = new Random();

while (true) {
    for(int i = 0; i < 100; i++) {
        if (i == 50)
            stringToPrint += "BATTLE";
        else
            stringToPrint += "=";
    }
    Console.WriteLine(stringToPrint);
    stringToPrint = "";

    foreach (var el in game.heroesParty) {
        Console.WriteLine($"{el.name}\t({el.currentHP}/{el.maxHP})");
    }

    for (int i = 0; i < 104; i++) {
        if (i == 52)
            stringToPrint += "VS";
        else
            stringToPrint += "-";
    }
    Console.WriteLine(stringToPrint);
    stringToPrint = "";

    foreach (var el in game.monstersParty) {
        Console.WriteLine($"{el.name}\t({el.currentHP}/{el.maxHP})");
    }

    for (int i = 0; i < 105; i++) {
            stringToPrint += "=";
    }
    Console.WriteLine(stringToPrint);
    stringToPrint = "";
    Console.WriteLine("\n\n");

    Console.WriteLine($"It's {game.currentCharacter.name} turn...");
    if (gamemode == Game.Gamemode.PVP) {
        Console.WriteLine("1- Do nothing\n2- Standard Attack\n3-Use health potion");
        Console.Write("What do you want to do? ");
        int.TryParse(Console.ReadLine(), out choiceUser);
        currentAction = game.NextTurn(choiceUser - 1, choiceUser - 1);
    } else if (gamemode == Game.Gamemode.PVC) {
        if (game.IsHeroTurn()) {
            Console.WriteLine("1- Do nothing\n2- Standard Attack\n3-Use health potion");
            Console.Write("What do you want to do? ");
            int.TryParse(Console.ReadLine(), out choiceUser);
        } else {
            choicePotion = 1;
            //the computer will use an health potion under some circumstance
            if (!game.IsMonstersInventoryEmpty() && game.currentCharacter.currentHP < game.currentCharacter.currentHP / 2 && random.Next(100) < 25)
                choicePotion = 3;
        }

        
        currentAction = game.NextTurn(choiceUser - 1, choicePotion);
    } else {
        if (game.IsHeroTurn()) {
            choicePotion = 1;
            //the computer will use an health potion under some circumstance
            if (!game.IsHeroesInventoryEmpty() && game.currentCharacter.currentHP < game.currentCharacter.currentHP / 2 && random.Next(100) < 25)
                choicePotion = 3;

            currentAction = game.NextTurn(choicePotion);
        } else {
            choicePotion = 1;
            //the computer will use an health potion under some circumstance
            if (!game.IsMonstersInventoryEmpty() && game.currentCharacter.currentHP < game.currentCharacter.currentHP / 2 && random.Next(100) < 25)
                choicePotion = 3;

            currentAction = game.NextTurn(actionMonster: choicePotion);
        }


    }
    Console.WriteLine($"{currentAction}.\n");
    Thread.Sleep(1000);

    if ((endPhrase = game.CheckEnd()) != null) {
        Console.WriteLine(endPhrase);
        break;
    }
}

