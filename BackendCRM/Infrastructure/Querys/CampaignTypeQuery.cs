using Application.Interfaces.CampaignType;
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
    public class CampaignTypeQuery : ICampaignTypeQuery
    {
        private readonly DataContext _context;
      

        public CampaignTypeQuery(DataContext context)
        {
            _context = context;
        
        }

        public async Task<bool> CampaignExists(int id)
        {
            var resultado = await _context.CampaignTypes.AnyAsync(c => c.Id == id);
            return resultado;
        }

        public async Task<ICollection<CampaignTypes>> GetList()
        {
            var campaignTypes = await _context.CampaignTypes.ToListAsync();         
            return campaignTypes;
        }
    }
}
