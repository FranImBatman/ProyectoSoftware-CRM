using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class InteractionResponse
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }

        public DateTime Date { get; set; }

        public Guid Project { get; set; }

        public GenericResponse InteractionType { get; set; }




    }
}
