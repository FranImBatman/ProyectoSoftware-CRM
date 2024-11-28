using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class UserServices : IUserService
    {
        private readonly IUserQuery _query;
        private readonly IMapper _mapper;

        public UserServices(IUserQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<ICollection<UserReponse>> GetAll()
        {
            var users = await _query.GetList();
            var response = _mapper.Map<ICollection<UserReponse>>(users);
            return response;
        }

        public async Task UserExists(int id)
        {
            var exists = await _query.UserExists(id);

            if (!exists)
            {
                throw new InvalidUserException();
            }
        }
    }
}
