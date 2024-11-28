using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.CampaignType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CampaignTypeServices : ICampaignTypeService
    {
        private readonly ICampaignTypeQuery _query;
        private readonly IMapper _mapper;

        public CampaignTypeServices(ICampaignTypeQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task CampaignExists(int id)
        {
            var exists = await _query.CampaignExists(id);

            if (!exists)
            {
                throw new InvalidCampaignTypeException();
            }
        }

        public async Task<ICollection<GenericResponse>> GetAll()
        {
            var campaignTypes = await _query.GetList();
            var response = _mapper.Map<ICollection<GenericResponse>>(campaignTypes);
            return response;
        }
    }
}
