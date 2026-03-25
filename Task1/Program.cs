using System;
using System.IO;

public class TextHandler {
    public delegate string TextOperation(string Text);

    public void ProcessFile(string Path) {
        if (File.Exists(Path)) {

        } else {
            Console.WriteLine("File does not exist.");
        }
    }

}