using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CampaignType
{
    public interface ICampaignTypeService
    {
        Task<ICollection<GenericResponse>> GetAll();

        Task CampaignExists(int id);
    }
}
