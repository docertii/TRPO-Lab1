using System;
using System.IO;
class ValidateMessage {
    static int Main(string[] args) {
        if (args.Length != 1) return 2;
        string[] lines = File.ReadAllLines(args[0]);
        bool valid = lines.Length > 0 && lines[0].Length > 0 && lines[0].Length <= 72;
        if (lines.Length > 1 && lines[1].Length != 0) valid = false;
        for (int i = 2; i < lines.Length; i++)
            if (lines[i].Length > 0 && (lines[i].Length > 100 || !lines[i].StartsWith("    "))) valid = false;
        if (!valid) Console.Error.WriteLine("Commit rejected: subject 1..72; blank second line; body indented 4 spaces, <=100.");
        return valid ? 0 : 1;
    }
}
