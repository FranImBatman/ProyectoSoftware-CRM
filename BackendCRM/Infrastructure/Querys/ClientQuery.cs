using Application.Interfaces.Client;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ClientQuery : IClientQuery
    {
        private readonly DataContext _context;
      

        public ClientQuery(DataContext context)
        {
            _context = context;          
        }

        public async Task<bool> ClientExists(int ClientId)
        {
            return await _context.Clients.AnyAsync(c => c.ClientID == ClientId);
        }

        public Clients GetClient(int ClientId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Clients>> GetListClients()
        {
            var clients = await _context.Clients.ToListAsync();           
            return clients;
        }
    }
}
