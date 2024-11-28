using Application.Interfaces.Interaction;
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
    public class InteractionQuery : IInteractionQuery
    {
        private readonly DataContext _context;

        public InteractionQuery(DataContext context)
        {
            _context = context;
        }

        public async Task<Interactions> GetInteraction(Guid InteractionId)
        {
            var interaction = await _context.Interactions
                .Include(i => i.InteractionTypesNavigator)
                .FirstOrDefaultAsync(i => i.InteractionID == InteractionId);

            return interaction;
        }
    }
}
