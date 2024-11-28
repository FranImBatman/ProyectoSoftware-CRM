using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.InteractionType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class InteractionTypeServices : IInteractionTypeService
    {
        private readonly IInteractionTypeQuery _query;
        private readonly IMapper _mapper;

        public InteractionTypeServices(IInteractionTypeQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<ICollection<GenericResponse>> GetAll()
        {
            var interactionTypes = await _query.GetList();
            var response = _mapper.Map<ICollection<GenericResponse>>(interactionTypes);
            return response;
        }

        public async Task InteractionTypeExists(int id)
        {
            var exists = await _query.InteractionTypeExists(id);

            if (!exists)
            {
                throw new InvalidInteractionTypeException();
            }
        }
    }
}
