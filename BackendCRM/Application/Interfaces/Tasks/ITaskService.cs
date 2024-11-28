using Application.DTOs;
using Application.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Tasks
{
    public interface ITaskService
    {
        Task<TaskResponse> CreateTask(TaskRequest request, Guid projectId);


        Task<Domain.Entities.Tasks> GetById(Guid TaskId);

        Task<TaskResponse> UpdateTask(TaskRequest request, Guid taskId);

        Task TaskExists(Guid TaskId);
    }
}
