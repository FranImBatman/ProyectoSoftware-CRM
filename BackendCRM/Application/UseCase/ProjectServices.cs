using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.CampaignType;
using Application.Interfaces.Client;
using Application.Interfaces.Interaction;
using Application.Interfaces.Project;
using Application.Interfaces.Tasks;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectCommand _command;
        private readonly IProjectQuery _query;
        private readonly IMapper _mapper;
        private readonly ITaskService _task;
        private readonly IInteractionService _interaction;
        private readonly IClientService _clientService;
        private readonly ICampaignTypeService _campaignTypeService;

        public ProjectServices(IProjectCommand command, IProjectQuery query, IMapper mapper, ITaskService task, IInteractionService interaction, IClientService clientService, ICampaignTypeService campaignTypeService)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _task = task;
            _interaction = interaction;
            _clientService = clientService;
            _campaignTypeService = campaignTypeService;
        }

        public async Task<ProjectDetails> CreateProject(ProjectRequest request)
        {
            ValidateProject(request);
            await NameExists(request.Name);
            await _clientService.ClientExists(request.Client);
            await _campaignTypeService.CampaignExists(request.CampaignType);

            var project = _mapper.Map<Projects>(request);
            await _command.InsertProject(project);
            var response = await GetById(project.ProjectID);
            return response;
        }



        public async Task<ICollection<ProjectResponse>> GetProjects(string? name, int? campaignType, int? client, int? offset, int? size)
        {
            NegativeValidate(size, offset);
           
            var projects = await _query.GetListProjects(name, campaignType, client, offset, size);
            var response = _mapper.Map<ICollection<ProjectResponse>>(projects);
            return response;
        }

        public async Task<ProjectDetails> GetById(Guid ProjectId)
        {
            await ProjectExists(ProjectId);
            
            var project = await _query.GetProject(ProjectId);
            var response = _mapper.Map<ProjectDetails>(project);
            return response;
        }

        public async Task<TaskResponse> AddTask(Guid ProjectId, TaskRequest request)
        {
            var newTask = await _task.CreateTask(request, ProjectId);
            var project = await _query.GetProject(ProjectId);
            project.UpdateDate = DateTime.Now;
            await _command.SaveChangesAsync();

            return newTask;
        }
        public async Task<InteractionResponse> AddInteraction(Guid ProjectId, InteractionRequest request)
        {
            var newInteraction = await _interaction.CreateInteraction(request, ProjectId);
            var project = await _query.GetProject(ProjectId);
            project.UpdateDate = DateTime.Now;
            await _command.SaveChangesAsync();

            return newInteraction;
        }

        public async Task<TaskResponse> UpdateTask(TaskRequest request, Guid taskId)
        {
            var auxTask = await _task.GetById(taskId);
            var projectUpdate = await _query.GetProject(auxTask.ProjectID);
            projectUpdate.UpdateDate = DateTime.Now;
            await _command.SaveChangesAsync();

            return await _task.UpdateTask(request, taskId);
        }

        public async Task NameExists(string pName)
        {
            var exists = await _query.Exists(pName);

            if (exists)
            {
                throw new SameNameProjectException();
            }
        }

        private void ValidateProject(ProjectRequest request)
        {
            if(String.IsNullOrWhiteSpace(request.Name))
            {
                throw new EmptyFieldException("Name");
            }
            if (request.EndDate < request.StartDate)
            {
                throw new InvalidDateTimeException();
            }           
        }

        public async Task ProjectExists(Guid projectId)
        {
            var exists = await _query.ProjectExists(projectId);

            if (!exists) 
            {
                throw new InvalidProjectException();
            }
        }

        private void NegativeValidate(int? size, int? offset)
        {
            if (size < 0 || offset < 0)
            {
                throw new NegativeNumberException();
            }
        }
    }
}
