using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class ProjectDetails
    {
        public ProjectResponse Data { get; set; }

        public ICollection<TaskResponse> Tasks { get; set; }

        public ICollection<InteractionResponse> Interactions { get; set; }
    }
}
