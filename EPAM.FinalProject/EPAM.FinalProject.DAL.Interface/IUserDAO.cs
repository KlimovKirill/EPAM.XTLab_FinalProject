using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.DAL.Interface
{
    public interface IUserDAO
    {
        void Add(User user);

        bool Delete(int id);

        void Edit(User user);

        User GetById(int id);

        IEnumerable<User> GetAllUsers();
    }
}
