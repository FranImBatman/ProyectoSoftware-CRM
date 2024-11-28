using Application.Interfaces.Tasks;
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
    public class TaskQuery : ITaskQuery
    {
        private readonly DataContext _context;

        public TaskQuery(DataContext context)
        {
            _context = context;
        }

        public async Task<Tasks> GetTask(Guid TaskId)
        {
            var task = await _context.Tasks
                .Include(t => t.TaskStatusNavigator)
                .Include(t => t.UserNavigator)
                .FirstOrDefaultAsync(t => t.TaskID == TaskId);

            return task;
        }

        public async Task<bool> TaskExists(Guid TaskId)
        {
            return await _context.Tasks.AnyAsync(t => t.TaskID == TaskId);    
        }
    }
}
