using Application.Interfaces.Tasks;
using Domain.Entities;
using Infrastructure.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class TaskCommand : ITaskCommand
    {
        private readonly DataContext _context;

        public TaskCommand(DataContext context)
        {
            _context = context;
        }

        public async Task InsertTask(Tasks task)
        {
            _context.Add(task);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
