using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Client
{
    public interface IClientQuery
    {
        Task<ICollection<Clients>> GetListClients();

        Clients GetClient(int ClientId);

        Task<bool> ClientExists(int ClientId);
    }
}
