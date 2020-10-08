using EPAM.FinalProject.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FinalProject.BLL.Dependencies
{
    public class EPAMFinalProjectBLLDependencies
    {
        private static ITopicBLL _topicLogic;

        private static IMessageBLL _messageLogic;

        private static IUserBLL _userLogic;
        public static ITopicBLL TopicLogic => _topicLogic ?? (_topicLogic = new TopicBLL());

        public static IMessageBLL MessageLogic => _messageLogic ?? (_messageLogic = new MessageBLL());

        public static IUserBLL UserLogic => _userLogic ?? (_userLogic = new UserBLL());
    }
}
