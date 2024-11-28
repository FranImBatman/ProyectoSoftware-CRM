using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Client
{
    public interface IClientCommand
    {
        Task InsertClient(Clients client);

        Task RemoveClient(int ClientId);
    }
}
