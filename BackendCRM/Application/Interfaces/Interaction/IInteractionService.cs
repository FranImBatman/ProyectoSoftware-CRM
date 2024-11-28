using Application.DTOs.Requests;
using Application.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Interaction
{
    public interface IInteractionService
    {
        Task<InteractionResponse> CreateInteraction(InteractionRequest request, Guid ProjectId);


        Task<Interactions> GetById(Guid InteractionId);
    }
}
