const string groupCode = "PD21";

string baseDirectory = "C:\\Users\\Admin\\source\\repos\\csharptest1\\Task1";
string inputFilePath = Path.Combine(baseDirectory, $"text{groupCode}.txt");
string outputFilePath = Path.Combine(baseDirectory, $"result{groupCode}.txt");

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Input file was not found: {inputFilePath}");
    return;
}

File.WriteAllText(outputFilePath, string.Empty);

ProcessFile(inputFilePath, outputFilePath, "UPPERCASE", ToUpperCase);
ProcessFile(inputFilePath, outputFilePath, "CHARACTER COUNT", CountCharacters);
ProcessFile(inputFilePath, outputFilePath, "WORD COUNT", CountWords);

Console.WriteLine($"Results were written to: {outputFilePath}");

string ToUpperCase(string line)
{
    return line.ToUpper();
}

string CountCharacters(string line)
{
    return line.Length.ToString();
}

string CountWords(string line)
{
    string[] words = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
    return words.Length.ToString();
}

void ProcessFile(string inputFilePath, string outputFilePath, string operationName, TextOperation operation)
{
    string[] lines = File.ReadAllLines(inputFilePath);

    using StreamWriter writer = new(outputFilePath, append: true);

    writer.WriteLine($"Operation: {operationName}");

    if (lines.Length == 0)
    {
        writer.WriteLine("The input file is empty.");
        writer.WriteLine();
        return;
    }

    for (int i = 0; i < lines.Length; i++)
    {
        string result = operation(lines[i]);
        writer.WriteLine($"Line {i + 1}: {result}");
    }

    writer.WriteLine();
}

delegate string TextOperation(string line);