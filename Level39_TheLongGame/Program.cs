string? username;
int score;

Console.Write("Enter you username: ");
username = Console.ReadLine();

if(File.Exists(username + ".txt"))
    int.TryParse(File.ReadAllText(username + ".txt"), out score);
else
    score = 0;

Console.WriteLine($"Hello {username}, your score is {score}.\nNow press any random key.\nPress Enter to end the game.");
while (true) {
    if (Console.ReadKey(true).Key == ConsoleKey.Enter) {
        File.WriteAllText(username + ".txt", score + "");
        break;
    }
    score++;
    Console.WriteLine($"Score: {score}");
}

Console.WriteLine($"You stopped the game, your final score is {score}.");