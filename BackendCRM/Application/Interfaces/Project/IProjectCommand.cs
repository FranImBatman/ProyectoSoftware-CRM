using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Project
{
    public interface IProjectCommand
    {
        Task InsertProject(Projects project);

        Task RemoveProject(int ProjectId);

        Task SaveChangesAsync();


    }
}
