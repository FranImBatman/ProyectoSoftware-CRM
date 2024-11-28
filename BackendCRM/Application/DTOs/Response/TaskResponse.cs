using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class TaskResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public Guid Project { get; set; }
       
        public UserReponse AssignedTo { get; set; }

        public GenericResponse Status { get; set; }


    }
}

