using System;
using System.Collections.Generic;
using System.Linq;

namespace Batle_Maneger
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> people = new Dictionary<string, int>();
            Dictionary<string, int> people2 = new Dictionary<string, int>();
            string cmd = Console.ReadLine();

            while (cmd != "Results")
            {
                string[] token = cmd.Split(':');

                string comand = token[0];
               

                if ( comand== "Add")
                {
                    string name = token[1];
                    int health = int.Parse(token[2]);
                    int energy = int.Parse(token[3]);
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name,health);
                    }
                    
                    
                        if (people[name] > health)
                        {
                            people[name] += health;

                        }
                    

                    if (!people2.ContainsKey(name))
                    {
                        people2.Add(name,energy);
                    }
                    

                }
                else if (comand == "Attack")
                {
                    string attacerName = token[1];
                    string deffenderName = token[2];
                    int demage = int.Parse(token[3]);

                    if (people.ContainsKey(attacerName) && people.ContainsKey(deffenderName))
                    {
                        
                        people[deffenderName] -= demage;
                        if (people[deffenderName] <=0)
                        {
                            people.Remove(deffenderName);
                            people2.Remove(deffenderName);
                            Console.WriteLine($"{deffenderName} was disqualified!");
                        }
                        
                    }
                    if (people2.ContainsKey(attacerName)) 
                    {
                        people2[attacerName] -= 1;
                        if (people2[attacerName] <=0)
                        {
                            people2.Remove(attacerName);
                            people.Remove(attacerName);
                            Console.WriteLine($"{attacerName} was disqualified!");
                        }
                    }

                }
                else if (comand == "Delete")
                {
                    string userName = token[1];
                    people.Remove(userName);
                    people2.Remove(userName);
                    if (userName == "All")
                    {
                        people.Clear();
                        people2.Clear();
                    }

                }





                cmd = Console.ReadLine();
            }

                            Console.WriteLine($"People count: {people.Count}");

            foreach(var x in people)
            {
                foreach(var y in people2) 
                { 
                    if (x.Key == y.Key)
                    {
                        Console.WriteLine($"{x.Key} - {x.Value} - {y.Value}");
                    }
                }
            }



        }
    }

}

      