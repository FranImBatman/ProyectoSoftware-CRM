using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserQuery
    {
        Task<ICollection<Users>> GetList();

        Task<bool> UserExists(int id);
    }
}
