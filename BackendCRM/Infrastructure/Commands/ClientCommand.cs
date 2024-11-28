using Application.Interfaces.Client;
using Domain.Entities;
using Infrastructure.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class ClientCommand : IClientCommand
    {
        private readonly DataContext _context;

        public ClientCommand(DataContext context)
        {
            _context = context;
        }

        public async Task InsertClient(Clients client)
        {
            _context.Add(client);

            await _context.SaveChangesAsync();
        }

        public Task RemoveClient(int ClientId)
        {
            throw new NotImplementedException();
        }
    }
}
