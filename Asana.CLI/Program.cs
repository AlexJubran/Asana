using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDos = new List<ToDo>();
            var projects = new List<Project>();
            
            int choiceInt;
            do
            {
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. Delete a ToDo");
                Console.WriteLine("3. Update a ToDo");
                Console.WriteLine("4. List all ToDos");
                Console.WriteLine("5. Create a Project");
                Console.WriteLine("6. Delete a Project");
                Console.WriteLine("7. Update a Project");
                Console.WriteLine("8. List all Projects");
                Console.WriteLine("9. List all ToDos in a Project");
                Console.WriteLine("10. Exit");




                var choice = Console.ReadLine() ?? "10";

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
                            if (dID >= 0 && dID <= toDos.Count())
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
                            Console.Write("Completed (T/F):");
                            string? completeLetter = Console.ReadLine();
                            bool complete = false;
                            if (completeLetter.Equals("T"))
                            {
                                complete = true;
                            }
                            toDos[uID] = new ToDo { Name = u_name, Description = u_description, IsCompleted = complete };
                            break;


                        case 4://List
                            for (int i = 0; i < toDos.Count(); i++)
                            {
                                Console.WriteLine($"{i}: {toDos[i]}");
                            }
                            break;


                        case 5://create a project
                            Console.Write("Project name:");
                            var p_name = Console.ReadLine();
                            Console.Write("Project Description:");
                            var p_description = Console.ReadLine();

                            int toDoIndex = 0;

                            List<int> newToDos = new List<int>();

                            while (toDoIndex >= 0)
                            {
                                Console.Write("ToDO ID to add to project (-1 to quit):");
                                string stringToDoID = Console.ReadLine() ?? "-1";
                                toDoIndex = Int32.Parse(stringToDoID);

                                if (toDoIndex <= toDos.Capacity && toDoIndex >= 0)
                                {
                                    newToDos.Add(toDoIndex);
                                }

                            }

                            projects.Add(new Project { Name = p_name, Description = p_description,  toDoIDs = newToDos});
                            break;


                        case 6://Delete a project
                            Console.Write("Project ID to delete:");
                            string stringID = Console.ReadLine() ?? "-1";
                            int projectID = Int32.Parse(stringID);
                            if (projectID >= 0 && projectID <= projects.Count())
                            {
                                Console.Write($"Removed {projects[projectID]}");
                                projects.RemoveAt(projectID);
                            }
                            break;
                        case 7://Update a project
                            break;
                        case 8://list all projects
                            for (int i = 0; i < projects.Count(); i++)
                            {
                                Console.WriteLine($"{i}: {projects[i]}");
                            }
                            break;


                            break;
                        case 10:
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

            } while (choiceInt != 10);

        }
    }
}