using Application.Interfaces.TaskStatus;
using AutoMapper;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class TaskStatusQuery : ITaskStatusQuery
    {
        private readonly DataContext _context;       

        public TaskStatusQuery(DataContext context)
        {
            _context = context;
        
        }

        public async Task<ICollection<Domain.Entities.TaskStatus>> GetList()
        {
            var taskStatus = await _context.TaskStatus.ToListAsync();           
            return taskStatus;
        }

        public async Task<bool> TaskStatusExists(int Id)
        {
            return await _context.TaskStatus.AnyAsync(t => t.Id == Id);
        }
    }
}
