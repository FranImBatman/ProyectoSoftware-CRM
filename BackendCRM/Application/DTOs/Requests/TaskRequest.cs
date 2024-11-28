using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TaskRequest
    {

        public string Name { get; set; }

        public DateTime DueDate { get; set; }
        
        public int AssignedTo { get; set; }

        public int Status { get; set; }



    }
}
