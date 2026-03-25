const string groupCode = "PD21";

string baseDirectory = "C:\\Users\\Admin\\source\\repos\\csharptest1\\Task2";
string logFilePath = Path.Combine(baseDirectory, $"log{groupCode}.txt");

File.WriteAllText(logFilePath, string.Empty);

MessagePublisher publisher = new();
FileLogger logger = new(logFilePath, publisher);

for (int i = 1; i <= 4; i++)
{
    Console.Write($"Enter message {i}: ");
    string message = Console.ReadLine() ?? string.Empty;
    publisher.Send(message);
}

Console.WriteLine($"All messages were written to: {logFilePath}");

class MessagePublisher
{
    public event Action<string>? MessageSent;

    public void Send(string message)
    {
        MessageSent?.Invoke(message);
    }
}

class FileLogger
{
    private readonly string _logFilePath;

    public FileLogger(string logFilePath, MessagePublisher publisher)
    {
        _logFilePath = logFilePath;
        publisher.MessageSent += WriteToFile;
    }

    private void WriteToFile(string message)
    {
        string logLine = $"[{DateTime.Now:HH:mm:ss}] {message}";
        File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
    }
}
