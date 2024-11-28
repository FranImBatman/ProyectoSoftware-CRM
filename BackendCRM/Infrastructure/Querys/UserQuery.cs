using Application.Interfaces.User;
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
    public class UserQuery : IUserQuery
    {
        private readonly DataContext _context;
        

        public UserQuery(DataContext context)
        {
            _context = context;
           
        }

        public async Task<ICollection<Users>> GetList()
        {
            var users = await _context.Users.ToListAsync();          
            return users;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserID == id);  
        }
    }
}
