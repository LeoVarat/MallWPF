using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    internal interface IRoleService
    {
        bool Create(string roleName);
        IEnumerable<Role> GetAll();
    }
    internal class RoleService : IRoleService
    {
        private readonly SqlContext _context = new();
        public bool Create(string roleName)
        {
            var role = _context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            if(role == null)
            {
                _context.Roles.Add(new Role
                {
                    Name = roleName,
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }
    }
}
