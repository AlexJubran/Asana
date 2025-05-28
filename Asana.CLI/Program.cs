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
            int itemCount = 0;
            int projectCount = 0;
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

                            toDos.Add(new ToDo { Name = name, Description = description, IsCompleted = false , Id = ++itemCount });
                            break;


                        case 2://delete
                            toDos.ForEach(Console.WriteLine);
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

                            toDos.ForEach(Console.WriteLine);
                            Console.Write("ID to update:");
                            string suID = Console.ReadLine() ?? "-1";
                            int uID = Int32.Parse(suID);
                            uID--; //covert from ID to list index
                            if (uID < 0)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }
                            Console.Write("Current Name: " + toDos[uID].Name + " \nName:");
                            var u_name = Console.ReadLine();

                            Console.WriteLine($"Current Description: {toDos[uID].Description}");
                            Console.Write("Description:");
                            var u_description = Console.ReadLine();

                            Console.WriteLine($"Current Status: {toDos[uID].IsCompleted}");
                            Console.Write("Completed (T/F):");
                            string? completeLetter = Console.ReadLine();
                            bool complete = false;
                            if (completeLetter.Equals("T"))
                            {
                                complete = true;
                            }
                            toDos[uID] = new ToDo { Name = u_name, Description = u_description, IsCompleted = complete, Id = toDos[uID].Id };
                            break;


                        case 4://List
                            toDos.ForEach(Console.WriteLine);
                            break;


                        case 5://create a project
                            Console.Write("Project name:");
                            var p_name = Console.ReadLine();
                            Console.Write("Project Description:");
                            var p_description = Console.ReadLine();

                            int toDoIndex = 0;

                            List<int> newToDos = new List<int>();

                            toDos.ForEach(Console.WriteLine);

                            while (toDoIndex >= 0)
                            {
                                Console.Write("ToDO ID to add to project (-1 to quit):");
                                string stringToDoID = Console.ReadLine() ?? "-1";
                                toDoIndex = Int32.Parse(stringToDoID);
                                toDoIndex--; //covert from ID to list index
                                if (toDoIndex < 0)
                                {
                                    Console.WriteLine("Invalid ID");
                                    break;
                                }

                                if (toDoIndex <= toDos.Capacity && toDoIndex >= 0)
                                {
                                    newToDos.Add(toDoIndex);
                                    Console.WriteLine($"Added {toDos[toDoIndex].Name}");
                                }

                            }

                            int numCompleted = 0;

                            for (int i = 0; i < newToDos.Count(); i++)
                            {
                                if (toDos[newToDos[i]].IsCompleted == true)
                                {
                                    numCompleted++;
                                }
                            }
                            int completePercent = 0;
                            if (newToDos.Count() > 0)
                            {
                                completePercent = 100 * numCompleted / newToDos.Count();
                            }

                            projects.Add(new Project { Name = p_name, Description = p_description,  toDoIDs = newToDos, CompletePercent = completePercent, Id = ++projectCount });
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
                            projects.ForEach(Console.WriteLine);

                            Console.Write("ID to update:");
                            string stringProjectID = Console.ReadLine() ?? "-1";
                            int editProjectID = Int32.Parse(stringProjectID);
                            editProjectID--;
                            if (editProjectID < 0)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Current Name: " + projects[editProjectID].Name + " \nName:");
                            var project_name = Console.ReadLine();

                            Console.WriteLine($"Current Description: {projects[editProjectID].Description}");
                            Console.Write("Description:");
                            var project_description = Console.ReadLine();
                            
                            Console.WriteLine("Current ToDos:");

                            for (int i = 0; i < projects[editProjectID].toDoIDs.Count(); i++)
                            {
                                Console.Write($"{toDos[projects[editProjectID].toDoIDs[i]]} ");
                            }
                            Console.WriteLine();
                            int editToDoIndex = 1;

                            List<int> editToDos = new List<int>();
                            Console.WriteLine("All ToDos:");
                            toDos.ForEach(Console.WriteLine);
                            while (editToDoIndex >= 0)
                            {
                                Console.Write("ToDO ID to add to project (-1 to quit):");
                                
                                string stringToDoID = Console.ReadLine() ?? "-1";
                                editToDoIndex = Int32.Parse(stringToDoID);

                                editToDoIndex--; //covert from ID to list index
                                if (editToDoIndex < 0)
                                {
                                    Console.WriteLine("Invalid ID");
                                    break;
                                }

                                if (editToDoIndex <= toDos.Capacity && editToDoIndex >= 0)
                                {
                                    editToDos.Add(editToDoIndex);
                                    Console.WriteLine($"Added {toDos[editToDoIndex].Name}");
                                }

                            }

                            int completeNum = 0;

                            for (int i = 0; i < editToDos.Count(); i++)
                            {
                                if (toDos[editToDos[i]].IsCompleted == true)
                                {
                                    completeNum++;
                                }
                            }
                            int percent = 0;
                            if (editToDos.Count() > 0)
                            {
                                percent = 100 * completeNum / editToDos.Count();
                            }

                            projects[editProjectID] = new Project { Name = project_name, Description = project_description, toDoIDs = editToDos, CompletePercent = percent };
                            break;

                        case 8://list all projects
                            //update complete percent before printing
                            foreach (var project in projects)
                            {
                                int completed = 0;
                                for (int i = 0; i < project.toDoIDs.Count(); i++)
                                {
                                    if (toDos[project.toDoIDs[i]].IsCompleted == true)
                                    {
                                        completed++;
                                    }
                                }
                                int c_percent = 0;
                                if (project.toDoIDs.Count() > 0)
                                {
                                    c_percent = 100 * completed / project.toDoIDs.Count();
                                }
                                project.CompletePercent = c_percent;
                            }

                            

                 
                            foreach (var project in projects)
                            {
                                Console.WriteLine(project);
                            }
                            break;


                        case 9: //list toDos in a project
                            projects.ForEach(Console.WriteLine);

                            Console.Write("Project ID:");
                            string stringPID = Console.ReadLine() ?? "-1";
                            int ePID = Int32.Parse(stringPID);
                            ePID--;
                            if (ePID < 0)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            foreach (var todo in projects[ePID].toDoIDs)
                            {
                                Console.WriteLine(toDos[todo]);
                            }

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


            } while (choiceInt != 10);

        }
    }
}