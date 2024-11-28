using Application.DTOs;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Tasks;
using Application.Interfaces.TaskStatus;
using Application.Interfaces.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class TaskServices : ITaskService
    {
        private readonly ITaskCommand _command;
        private readonly ITaskQuery _query;
        private readonly IMapper _mapper;
        private readonly ITaskStatusService _statusService;
        private readonly IUserService _userService;

        public TaskServices(ITaskCommand command, ITaskQuery query, IMapper mapper, ITaskStatusService statusService, IUserService userService)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _statusService = statusService;
            _userService = userService;
        }

        public async Task<TaskResponse> CreateTask(TaskRequest request, Guid projectId)
        {
            ValidateTask(request);

            await _statusService.TaskStatusExists(request.Status);
            await _userService.UserExists(request.AssignedTo);

            var task = _mapper.Map<Tasks>(request);
            task.ProjectID = projectId;
            await _command.InsertTask(task);
            var taskResponse = _mapper.Map<TaskResponse>(await GetById(task.TaskID));
            return taskResponse;
        }


        public async Task<Tasks> GetById(Guid TaskId)
        {
            await TaskExists(TaskId);

            var selectTask = await _query.GetTask(TaskId);
            return selectTask;
        }

        public async Task TaskExists(Guid TaskId)
        {
            var exists = await _query.TaskExists(TaskId);

            if (!exists)
            {
                throw new InvalidTaskException();
            }
        }

        public async Task<TaskResponse> UpdateTask(TaskRequest request, Guid TaskId)
        {
            ValidateTask(request);

            await _statusService.TaskStatusExists(request.Status);
            await _userService.UserExists(request.AssignedTo);

            var selectTask = await GetById(TaskId);
            _mapper.Map(request, selectTask);
            selectTask.UpdateDate = DateTime.Now;
            await _command.SaveChangesAsync();
            var updatedTask = await GetById(TaskId);
            var response = _mapper.Map<TaskResponse>(updatedTask);
            return response;
        }

        private void ValidateTask(TaskRequest request)
        {
            if (String.IsNullOrEmpty(request.Name))
            {
                throw new EmptyFieldException(nameof(request.Name));
            }

         

        }

    }

}
