using Application.Interfaces.Project;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectCommand(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }        

        public async Task InsertProject(Projects project)
        {
            _context.Add(project);       
            await _context.SaveChangesAsync();
           
        }

        public Task RemoveProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
