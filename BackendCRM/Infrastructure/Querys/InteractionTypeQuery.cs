using Application.Interfaces.InteractionType;
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
    public class InteractionTypeQuery : IInteractionTypeQuery
    {
        private readonly DataContext _context;
      
        public InteractionTypeQuery(DataContext context)
        {
            _context = context;           
        }

        public async Task<ICollection<InteractionTypes>> GetList()
        {
            var interactionTypes = await _context.InteractionTypes.ToListAsync();            
            return interactionTypes;
        }

        public Task<bool> InteractionTypeExists(int id)
        {
            return _context.InteractionTypes.AnyAsync(x => x.Id == id);
        }
    }
}
