using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Tasks
{
    public interface ITaskQuery
    {
        Task<Domain.Entities.Tasks> GetTask(Guid TaskId);

        Task<bool> TaskExists(Guid TaskId);
    }
}
