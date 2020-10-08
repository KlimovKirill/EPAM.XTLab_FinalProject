using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.BLL.Interface
{
    public interface IMessageBLL
    {
        void Add(Message message);

        void Delete(int id);

        void Edit(Message message);

        Message GetMessageById(int id);

        IEnumerable<Message> GetAllMessagesInTopic(int topicID);
    }
}
