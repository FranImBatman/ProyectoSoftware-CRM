using Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ICollection<UserReponse>> GetAll();

        Task UserExists(int id);
    }
}
