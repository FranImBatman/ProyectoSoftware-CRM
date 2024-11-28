using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CampaignType
{
    public interface ICampaignTypeQuery
    {
        Task<ICollection<CampaignTypes>> GetList();

        Task<bool> CampaignExists(int id);
    }
}
