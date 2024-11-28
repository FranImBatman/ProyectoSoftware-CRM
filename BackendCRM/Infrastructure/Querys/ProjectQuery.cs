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

namespace Infrastructure.Querys
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly DataContext _context;     

        public ProjectQuery(DataContext context)
        {
            _context = context;
        }

       

        public async Task<Projects> GetProject(Guid ProjectId)
        {
            var project = await _context.Projects
                .Include(p => p.CampaignTypesNavigator)
                .Include(p => p.ClientsNavigator)
                .Include(p => p.Interactions).ThenInclude(i => i.InteractionTypesNavigator)
                .Include(p => p.Tasks).ThenInclude(t => t.UserNavigator)
                .Include(p => p.Tasks).ThenInclude(t => t.TaskStatusNavigator)
                .FirstOrDefaultAsync(p => p.ProjectID == ProjectId);
                    
            return project;
        }      
   
              
        
        public async Task<ICollection<Projects>> GetListProjects(string? name, int? campaignType, int? client, int? offset, int? size)
        {
            var query = _context.Projects.AsQueryable();           

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.ProjectName.Contains(name));
            }

            if(campaignType != null)
            {
                query = query.Where(p => p.CampaignType == campaignType);
            }

            if (client != null)
            {
                query = query.Where(p => p.ClientID == client);
            }

            if(offset != null)
            {
                query = query.Skip(offset.Value);
            }

            if (size != null) 
            { 
                query = query.Take(size.Value);
            }


            var projects = await query
                .Include(p => p.CampaignTypesNavigator)
                .Include(p => p.ClientsNavigator)              
                .ToListAsync();

            return projects;
        }

        public async Task<bool> Exists(string pName)
        {
            return await _context.Projects.AnyAsync(p => p.ProjectName == pName);
        }

        public Task<bool> ProjectExists(Guid projectId)
        {
            return _context.Projects.AnyAsync(p => p.ProjectID == projectId);   
        }
    }
}
