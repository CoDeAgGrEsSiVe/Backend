using BackendLink.Data.Models;
using BackendLink.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLink.Data.Services
{
    public class UserService
    {
        private static AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUsers(UserVM user)
        {
            var _user = new Users()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                email = user.email,
                IsMale = user.IsMale

            };

            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public List<Users> GetAllUsers() => _context.Users.ToList();

        public Users GetUserById(int UserId) => _context.Users.FirstOrDefault(U => U.Id == UserId);

        public Users UpdateUserById(int bookId, UserVM user)
        {
            var _user = _context.Users.FirstOrDefault(U => U.Id == bookId);
            if(_user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.email = user.email;
                _user.IsMale = user.IsMale;

                _context.SaveChanges();
            }
            return _user;
        }

        public void DelectUserById(int Id)
        {
            var _user = _context.Users.FirstOrDefault(U => U.Id == Id);
            if(_user != null)
            {
                _context.Remove(_user);
                _context.SaveChanges();
            }
        }
 
    }
}
