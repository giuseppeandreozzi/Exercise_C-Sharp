using Level34_BetterRandom;

Random random = new Random();

Console.WriteLine("I will pick a random double value with 30 as max value:");
Console.WriteLine(random.NextDouble(30));

Console.WriteLine(@"I will pick a random string between 'Hey', 'how', 'are' and 'you?':");
Console.WriteLine(random.NextString("Hey", "how", "are", "you?"));

Console.WriteLine("I will flip a coin, with 0.5 of probability of head coming up:");
Console.WriteLine(random.CoinFlip() ? "Head" : "Tail");
