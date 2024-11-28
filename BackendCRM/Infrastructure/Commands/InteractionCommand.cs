using Application.Interfaces.Interaction;
using Domain.Entities;
using Infrastructure.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class InteractionCommand : IInteractionCommand
    {
        private readonly DataContext _context;

        public InteractionCommand(DataContext context)
        {
            _context = context;
        }

        public async Task InsertInteraction(Interactions interaction)
        {
            _context.Add(interaction);

            await _context.SaveChangesAsync();  

        }

        
    }
}
