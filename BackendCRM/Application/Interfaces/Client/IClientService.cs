using Application.DTOs.Requests;
using Application.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Client
{
    public interface IClientService
    {
        Task<ClientResponse> CreateClient(ClientRequest request);



        Task<ICollection<ClientResponse>> GetAll();



        Task ClientExists(int ClientId);
    }
}
