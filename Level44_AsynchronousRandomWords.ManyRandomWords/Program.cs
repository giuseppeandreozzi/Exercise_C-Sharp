Console.WriteLine("Insert the words that you want to recreate and after every word press enter:");
while (true) {
    string input = Console.ReadLine();
    RandomlyRecreateAsync(input, logOutput);

}

void RandomlyRecreate(string word, Action<string, int, TimeSpan> cb) {
    var before = DateTime.Now;
    int count = 0;
    string wordGenerated;
    Random random = new Random();

    while (true) {
        count++;
        wordGenerated = "";
        for (int i = 0; i < word.Length; i++) {
            wordGenerated += (char)('a' + random.Next(26));

            if (wordGenerated == word) {
                var after = DateTime.Now;
                cb(wordGenerated, count, after - before);
                return;
            }  
        }
    }

}

Task RandomlyRecreateAsync(string word, Action<string, int, TimeSpan> cb) {
    return Task.Run(() => RandomlyRecreate(word, cb));
}

void logOutput(string word, int numAttempt, TimeSpan time) {
    Console.WriteLine($"Word {word} generated. Number of attempt: {numAttempt}. Time: {time}");
}
