int[] array = [1, 9, 2, 8, 3, 7, 4, 6, 5];

Console.WriteLine("Procedural:");
foreach (int el in GetElementsProcedural(array))
    Console.WriteLine(el);

Console.WriteLine("Keyword query:");
foreach (int el in GetElementsKeywordQuery(array).ToList())
    Console.WriteLine(el);

Console.WriteLine("Method query:");
foreach (int el in GetElementsMethodQuery(array).ToList())
    Console.WriteLine(el);

IEnumerable<int> GetElementsProcedural(int[] array) {
    IEnumerable<int> arrayProcessed = [];
    Array.Sort(array);
    for (int i = 0; i < array.Length; i++) {
        if (array[i] % 2 == 0)
            arrayProcessed = arrayProcessed.Append(array[i] * 2);
    }

    return arrayProcessed;
}

IEnumerable<int> GetElementsKeywordQuery(int[] array) {
    return from n in array
           where n % 2 == 0
           orderby n
           select n * 2;
}

IEnumerable<int> GetElementsMethodQuery(int[] array) {
    return array.Where(n =>  n % 2 == 0)
                .OrderBy(n => n)
                .Select(n => n * 2);
}

