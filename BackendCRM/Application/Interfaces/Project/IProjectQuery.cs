using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Project
{
    public interface IProjectQuery
    {
        Task<ICollection<Projects>> GetListProjects(string? name, int? campaignType, int? client, int? offset, int? size);

        Task<bool> Exists(string name);

        Task<bool> ProjectExists(Guid projectId);

        Task<Projects> GetProject(Guid ProjectId);


    }
}
