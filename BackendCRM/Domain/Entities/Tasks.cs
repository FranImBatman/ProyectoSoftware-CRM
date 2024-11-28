
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tasks
    {
        public Guid TaskID { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public Guid ProjectID { get; set; }

        public int AssignedTo { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Projects ProjectNavigator { get; set; }

        public Users UserNavigator { get; set; }

        public TaskStatus TaskStatusNavigator { get; set; }
    }
}
