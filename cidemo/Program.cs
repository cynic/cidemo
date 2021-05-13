// This file is copyright by ME
using System;
using System.IO;

namespace cidemo
{
    public class Prepender {
        private string line;
        public Prepender(string s) {
            line = s;
        }
        public void Prepend(string filename) {
            // start by assuming that there are no lines in the file
            string[] lines = new string[0];
            if (File.Exists(filename)) { // but if the file exists
                // read all the lines from it
                lines = File.ReadAllLines(filename);
            }
            // write my line at the top of a new file
            File.WriteAllLines(filename, new string[] { line });
            // write the lines that were originally in the file
            File.AppendAllLines(filename, lines);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2) {
                return;
            }
            var prepender = new Prepender(args[0]);
            for (int i = 1; i < args.Length; i++) {
                prepender.Prepend(args[i]);
            }
        }
    }
}
