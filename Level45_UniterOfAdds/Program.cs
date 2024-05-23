Console.WriteLine("2 + 3 = " + Add(2, 3));

Console.WriteLine("2.5 + 5.2 = " + Add(2.5, 5.2));

Console.WriteLine("'Hello' + 'user' = " + Add("Hello", "user"));

DateTime dateTime = DateTime.Now;
TimeSpan timeSpan = TimeSpan.FromHours(2);
Console.WriteLine($"{dateTime} + {timeSpan} = " + Add(dateTime, timeSpan));

dynamic Add(dynamic a, dynamic b) => a + b;
