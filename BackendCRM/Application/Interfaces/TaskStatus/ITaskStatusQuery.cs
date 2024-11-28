
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.TaskStatus
{
    public interface ITaskStatusQuery
    {
        Task<ICollection<Domain.Entities.TaskStatus>> GetList();

        Task<bool> TaskStatusExists(int Id);
    }
}
