using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FinalProject.BLL.Interface;
using EPAM.FinalProject.DAL.Dependencies;
using EPAM.FinalProject.DAL.Interface;
using EPAM.FinalProject.Entities;

namespace EPAM.FinalProject.BLL
{
    public class TopicBLL : ITopicBLL
    {
        private readonly ITopicDAO _topicDAO;

        public TopicBLL() 
        {
            _topicDAO = EPAMFinalProjectDALDependencies.TopicDAO;
        }

        public void Add(Topic topic)
        {
            _topicDAO.Add(topic);
        }

        public void Delete(int id)
        {
            _topicDAO.Delete(id);
        }

        public void Edit(Topic topic)
        {
            _topicDAO.Edit(topic);
        }

        public Topic GetTopicById(int id)
        {
            return _topicDAO.GetTopicById(id);
        }

        public IEnumerable<Topic> ShowAllTopics()
        {
            return _topicDAO.ShowAllTopics();
        }
    }
}
