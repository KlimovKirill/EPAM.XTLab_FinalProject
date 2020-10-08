using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.DAL.Interface
{
    public interface IMessageDAO
    {
        void Add(Message message);

        bool Delete(int id);

        void Edit(Message message);

        Message GetMessageById(int id);

        IEnumerable<Message> GetAllMessagesInTopic(int topicID);
    }
}
