using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    internal interface IUserService
    {
        bool Create(string firstname, string lastname, string email, int roleId);
        IEnumerable<User> GetAll();
    }
    internal class UserService : IUserService
    {
        private readonly SqlContext _context = new();
        public bool Create(string firstname, string lastname, string email, int roleId)
        {
            var user = _context.Users.Where(x => x.Email == email);
            if (user == null)
            {
                _context.Users.Add(new User
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    RoleId = roleId
                });
                    _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(x => x.Role);
        }
    }
}
