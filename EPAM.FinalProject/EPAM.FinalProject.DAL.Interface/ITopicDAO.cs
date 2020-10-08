using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.DAL.Interface
{
    public interface ITopicDAO
    {
        void Add(Topic topic);

        bool Delete(int id);

        void Edit(Topic topic);

        Topic GetTopicById(int id);

        IEnumerable<Topic> ShowAllTopics();
    }
}
