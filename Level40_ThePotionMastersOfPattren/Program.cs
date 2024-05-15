Potion currentPotion = Potion.Water;

while(true) {
    Console.WriteLine($"You have a {currentPotion} potion");
    Console.WriteLine("There are the ingredients:");
    Console.WriteLine($"1-Stardust\t2-Snake venom\t3-Dragon breath");
    Console.WriteLine($"4-Shadow glass\t4-Eyeshine gem");
    Console.Write($"Pick an ingredient: ");

    currentPotion = getNewPotion(currentPotion, Console.ReadLine() switch {
        "1" => Ingredients.Stardust,
        "2" => Ingredients.SnakeVenom,
        "3" => Ingredients.DragonBreath,
        "4" => Ingredients.EyeshineGem,
        _ => throw new ArgumentException("Invalid input")
    });

    if(currentPotion == Potion.Ruined) {
        Console.WriteLine("You ruined the potion. You will start again from Water");
        currentPotion = Potion.Water;
    }

    Console.Write("Do you want to continue adding an ingredient? (y/n): ");
    if(Console.ReadLine() == "n") {
        Console.WriteLine($"You completed the potion. The potion is a {currentPotion} potion");
        break;
    }
}

Potion getNewPotion(Potion potion, Ingredients ingredient) {
    return (potion, ingredient) switch {
        (Potion.Water, Ingredients.Stardust) => Potion.Elixir,
        (Potion.Elixir, Ingredients.SnakeVenom) => Potion.Poison,
        (Potion.Elixir, Ingredients.DragonBreath) => Potion.Flying,
        (Potion.Elixir, Ingredients.ShadowGlass) => Potion.Invisibility,
        (Potion.Elixir, Ingredients.EyeshineGem) => Potion.NightSight,
        (Potion.NightSight, Ingredients.ShadowGlass) => Potion.CloudyBrew,
        (Potion.Invisibility, Ingredients.EyeshineGem) => Potion.CloudyBrew,
        (Potion.CloudyBrew, Ingredients.Stardust) => Potion.Wraith,
        _ => Potion.Ruined
    };
}
enum Ingredients {
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem
}

enum Potion {
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined
}