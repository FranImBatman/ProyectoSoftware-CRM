using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.TaskStatus;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class TaskStatusServices : ITaskStatusService
    {

        private readonly ITaskStatusQuery _query;
        private readonly IMapper _mapper;

        public TaskStatusServices(ITaskStatusQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<ICollection<GenericResponse>> GetAll()
        {
            var taskStatus = await _query.GetList();
            var response = _mapper.Map<ICollection<GenericResponse>>(taskStatus);
            return response;
        }

        public async Task TaskStatusExists(int Id)
        {
            var exists = await _query.TaskStatusExists(Id);

            if (!exists)
            {
                throw new InvalidStatusException();
            }
        }
    }
}
