Random random = new Random();
int numberOatmealCookie = random.Next(10);
string[] playersName = { "First", "Second" };
short turn = 0, inputConverted;
string? input;
List<int> previousNumbers = new List<int>();

try { 
    while (true) {
        Console.WriteLine($"{playersName[turn%2]} player turn.\n Choose a number between 0 and 9: ");
        input = Console.ReadLine();
        if (!short.TryParse(input, out inputConverted) || (inputConverted < 0 && inputConverted > 9))
            throw new Exception("Incorrect input");

        if (previousNumbers.Contains(inputConverted)) {
            Console.WriteLine("Number already chose. Choose another");
            continue;
        }

        if (inputConverted == numberOatmealCookie)
            throw new Exception("You picked the oatmeal cookie. You lose.");

        previousNumbers.Add(inputConverted);
        turn++;
    }
} catch (Exception e) {
    Console.WriteLine(e.Message);
}
