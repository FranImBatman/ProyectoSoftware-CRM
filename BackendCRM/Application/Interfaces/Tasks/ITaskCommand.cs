using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Tasks
{
    public interface ITaskCommand
    {
        Task InsertTask(Domain.Entities.Tasks task);

        Task SaveChangesAsync();


    }
}
