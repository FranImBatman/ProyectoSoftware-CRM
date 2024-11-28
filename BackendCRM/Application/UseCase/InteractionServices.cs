using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Interaction;
using Application.Interfaces.InteractionType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class InteractionServices : IInteractionService
    {
        private readonly IInteractionCommand _command;
        private readonly IInteractionQuery _query;
        private readonly IMapper _mapper;
        private readonly IInteractionTypeService _interactionTypeService;

        public InteractionServices(IInteractionCommand command, IInteractionQuery query, IMapper mapper, IInteractionTypeService interactionTypeService)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _interactionTypeService = interactionTypeService;
        }

        public async Task<InteractionResponse> CreateInteraction(InteractionRequest request, Guid ProjectId)
        {
            ValidateInteraction(request);
            await _interactionTypeService.InteractionTypeExists(request.InteractionType);

            var interaction = _mapper.Map<Domain.Entities.Interactions>(request);
            interaction.ProjectID = ProjectId;
            await _command.InsertInteraction(interaction);
            var interactionResponse = _mapper.Map<InteractionResponse>(await GetById(interaction.InteractionID));
            return interactionResponse;

        }

        public async Task<Domain.Entities.Interactions> GetById(Guid InteractionId)
        {
           return await _query.GetInteraction(InteractionId);

        }

        private void ValidateInteraction(InteractionRequest request)
        {
            if (String.IsNullOrEmpty(request.Notes))
            {
                throw new EmptyFieldException(nameof(request.Notes));
            }
            
          

        }
    }
}
