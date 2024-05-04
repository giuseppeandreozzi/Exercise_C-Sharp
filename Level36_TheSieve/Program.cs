using Level36_TheSieve;

Func<int, bool>[] filters = { x => x % 2 == 0, x => x > 0, x => x % 10 == 0 };
short choiceUser;
int inputUser;

Console.WriteLine("Which filter do you want to use?:\n1.Check if the number is even.\n2.Check if the number is positive\n3.Check if the number is multiple of ten\nWrite your choice: ");

if(!short.TryParse(Console.ReadLine(), out choiceUser) || (choiceUser < 1 || choiceUser > 3)) {
    Console.WriteLine("Incorrect input. The program will terminate.");
    return;
}

Sieve sieve = new Sieve(filters[choiceUser - 1]);

while (true) {
    Console.WriteLine("Insert a number: ");
    int.TryParse(Console.ReadLine(), out inputUser);
    if (sieve.IsGood(inputUser))
        Console.WriteLine("The number is good");
    else
        Console.WriteLine("The number is bad");
}
