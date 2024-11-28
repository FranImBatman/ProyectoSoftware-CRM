using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Project
{
    public interface IProjectServices
    {
        Task<ProjectDetails> CreateProject(ProjectRequest request);

        Task<ICollection<ProjectResponse>> GetProjects(string? name, int? campaignType, int? client, int? offset, int? size);

        Task<ProjectDetails> GetById(Guid ProjectId);

        Task NameExists(string projectName);

        Task ProjectExists(Guid projectId);

        Task<TaskResponse> AddTask(Guid ProjectId, TaskRequest request);

        Task<TaskResponse> UpdateTask(TaskRequest request, Guid taskId);

        Task<InteractionResponse> AddInteraction(Guid guid, InteractionRequest request);


    }
}
