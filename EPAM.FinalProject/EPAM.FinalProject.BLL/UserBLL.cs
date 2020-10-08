using EPAM.FinalProject.BLL.Interface;
using EPAM.FinalProject.DAL.Dependencies;
using EPAM.FinalProject.DAL.Interface;
using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAO _userDAO;

        public UserBLL()
        {
            _userDAO = EPAMFinalProjectDALDependencies.UserDAO;
        }

        public void Add(User user)
        {
            _userDAO.Add(user);
        }

        public void Delete(int id)
        {
            _userDAO.Delete(id);
        }

        public void Edit(User user)
        {
            _userDAO.Edit(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public User GetById(int id)
        {
            return _userDAO.GetById(id);
        }
    }
}
