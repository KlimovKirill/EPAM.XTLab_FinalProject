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
    public class MessageBLL : IMessageBLL
    {
        private readonly IMessageDAO _messageDAO;

        public MessageBLL()
        {
            _messageDAO = EPAMFinalProjectDALDependencies.MessageDAO;
        }

        public void Add(Message message)
        {
            _messageDAO.Add(message);
        }

        public void Delete(int id)
        {
            _messageDAO.Delete(id);
        }

        public void Edit(Message message)
        {
            _messageDAO.Edit(message);
        }

        public IEnumerable<Message> GetAllMessagesInTopic(int topicID)
        {
            return _messageDAO.GetAllMessagesInTopic(topicID);
        }

        public Message GetMessageById(int id)
        {
            return _messageDAO.GetMessageById(id);
        }
    }
}
