using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;



namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();


            string regex = @"(?<name>[A-z^\!#@?$]+)*?=(?<number>\d+)<<(?<coordinates>[a-z\d]+)";

            while (command != "Last note")
            {
                if (Regex.IsMatch(command, regex))
                {
                    MatchCollection matches = Regex.Matches(command, regex);


                    foreach (Match line in matches)
                    {
                        string name = line.Groups["name"].Value;
                        int number = int.Parse(line.Groups["number"].Value);
                        string cordinates = line.Groups["coordinates"].Value;

                        char[] n = name.ToCharArray();
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < n.Length; i++)
                        {
                            char k = n[i];

                            if (k == '!' || k == '@' || k == '?' || k == '#' || k == '$')
                            {
                                continue;
                            }
                            sb.Append(k);
                        }
                        cordinates.TrimEnd();
                        sb.ToString().TrimEnd();
                        if (cordinates.Length == number && sb.Length > 0)
                        {
                            Console.WriteLine($"Coordinates found! {sb.ToString()} -> {cordinates} ");

                        }
                        else
                        {
                            Console.WriteLine($"Nothing found!");


                        }

                    }





                }
                else
                {
                    Console.WriteLine($"Nothing found!");
                }






                command = Console.ReadLine();
            }
        }
    }

}

      