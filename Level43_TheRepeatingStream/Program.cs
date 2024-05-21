RecentNumbers recentNumbers = new RecentNumbers();
Thread threadGeneration = new Thread(generateNumbers);

threadGeneration.Start();

do {
    Console.ReadKey(true);
    if (recentNumbers[0] == recentNumbers[1])
        Console.WriteLine("You correctly identified a repetition");
    else
        Console.WriteLine("You got it wrong. None repetition identified.");

} while (true);
void generateNumbers() {
    Random rnd = new Random();
    int i = 0;
    byte number;

    while(true) {
        number = (byte) rnd.Next(0, 10);
        Console.WriteLine(number);
        recentNumbers[i] = number;
        i = (i + 1) % 2;
        Thread.Sleep(1000);
    }
}
class RecentNumbers {
    private byte firstNumber;
    private byte secondNumber;
    private readonly object _lockNumbers = new object(); //used to lock access for threads

    public byte this[int index] {
        get {
            lock (_lockNumbers) {
                if (index == 0)
                    return firstNumber;
                else
                    return secondNumber;
            }
        }
        set {
                lock (_lockNumbers) {
                    if (index == 0)
                        firstNumber = value;
                    else
                        secondNumber = value;
            }
        }
    }
}
