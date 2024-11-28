using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Client;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ClientServices : IClientService
    {
        private readonly IClientCommand _command;
        private readonly IClientQuery _query;
        private readonly IMapper _mapper;

        public ClientServices(IClientCommand command, IClientQuery query, IMapper mapper)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
        }

        public async Task ClientExists(int ClientId)
        {
            bool exists = await _query.ClientExists(ClientId);

            if (!exists)
            {
                throw new InvalidClientException();
            }
        }

        public async Task<ClientResponse> CreateClient(ClientRequest request)
        {           
            ValidateClient(request);

            var client = _mapper.Map<Domain.Entities.Clients>(request);
            await _command.InsertClient(client);
            var response = _mapper.Map<ClientResponse>(client);
            return response;
        }




        public async Task<ICollection<ClientResponse>> GetAll()
        {
            var clients = await _query.GetListClients();
            var response = _mapper.Map<ICollection<ClientResponse>>(clients);
            return response;
        }


        private void ValidateClient(ClientRequest request) 
        {
            if (String.IsNullOrEmpty(request.Name))
            {
                throw new EmptyFieldException(nameof(request.Name));
            }
            if (String.IsNullOrEmpty(request.Email))
            {
                throw new EmptyFieldException(nameof(request.Email));
            }
            if (String.IsNullOrEmpty(request.Phone))
            {
                throw new EmptyFieldException(nameof(request.Phone));
            }
            if (String.IsNullOrEmpty(request.Company))
            {
                throw new EmptyFieldException(nameof(request.Company));
            }
            if (String.IsNullOrEmpty(request.Address))
            {
                throw new EmptyFieldException(nameof(request.Address));
            }

            

        }

    }
}
