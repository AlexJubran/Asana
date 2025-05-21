using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDos = new List<ToDo>();
            int choiceInt;
            do
            {
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDos");
                Console.WriteLine("5. Exit");



                var choice = Console.ReadLine() ?? "5";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1://create
                            Console.Write("Name:");
                            var name = Console.ReadLine();
                            Console.Write("Description:");
                            var description = Console.ReadLine();

                            toDos.Add(new ToDo { Name = name, Description = description });
                            break;
                        case 2://delete
                            Console.Write("ID to delete:");
                            string sID = Console.ReadLine() ?? "-1";
                            int dID = Int32.Parse(sID);
                            if (dID >= 0)
                            {
                                Console.Write($"Removed {toDos[dID]}");
                                toDos.RemoveAt(dID);
                            }
                            break;
                        case 3://update
                            Console.Write("ID to update:");
                            string suID = Console.ReadLine() ?? "-1";
                            int uID = Int32.Parse(suID);

                            Console.Write("Name:");
                            var u_name = Console.ReadLine();
                            Console.Write("Description:");
                            var u_description = Console.ReadLine();

                            toDos[uID] = new ToDo { Name = u_name, Description = u_description };
                            break;

                        case 4://List
                            for (int i = 0; i < toDos.Count(); i++)
                            {
                                Console.WriteLine($"{i}: {toDos[i]}");
                            }
                            break;

                        case 5:
                            break;
                        default:
                            Console.WriteLine("ERROR: Unknown menu selection");
                            break;
                    }
                } else
                {
                    Console.WriteLine($"ERROR: {choice} is not a valid menu selection");
                }

                if(toDos.Any())
                {
                    Console.WriteLine(toDos.Last());
                }

            } while (choiceInt != 5);

        }
    }
}