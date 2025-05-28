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
        public int Id { get; set; }

        public override string ToString()
        {
            //return $"{Name} - {Description} - {CompletePercent}";
            string response = string.Empty;
            response += $"[{Id}]" + Name + "-" + Description + $"-{CompletePercent}%";

            return response;
        }

    }
}