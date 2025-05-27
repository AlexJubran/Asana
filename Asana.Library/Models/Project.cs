using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class Project
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? CompletePercent { get; set; }
        public List<int> toDoIDs { get; set; } = new List<int>();

        public override string ToString()
        {
            //return $"{Name} - {Description} - {CompletePercent}";
            string response = string.Empty;
            response += Name + "-" + Description + "-Todo IDs: ";

            foreach (int item in toDoIDs)
            {
                response += item;
            }
            return response;
        }

        public string listToDos()
        {
            string todos = string.Empty;
            foreach (var item in toDoIDs)
            {
                todos += item.ToString() + " ";
            }

            return todos;
        }
    }
}