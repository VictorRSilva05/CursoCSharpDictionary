using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp29
{
    internal class Program
    {
        Program()
        {
            Console.Write("Enter file full path: ");        //C:\Windows\Temp\online_users.txt
            string path = Console.ReadLine();

            Dictionary<string, int> candidates = new Dictionary<string, int>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] strings = line.Split(',');
                        string name = strings[0];
                        int votes = int.Parse(strings[1]);

                        if (candidates.ContainsKey(name))
                        {
                            candidates[name] += votes;
                        }
                        else
                        {
                            candidates[name] = votes;
                        }
                    }

                    foreach (var  pair in candidates)
                    {
                        Console.WriteLine(pair.Key + ", " + pair.Value);
                    }
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            _ = new Program();
        }
    }
}
