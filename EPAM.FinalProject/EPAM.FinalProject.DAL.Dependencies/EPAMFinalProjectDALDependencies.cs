using EPAM.FinalProject.DAL.Interface;

namespace EPAM.FinalProject.DAL.Dependencies
{
    public static class EPAMFinalProjectDALDependencies
    {
        private static IUserDAO _userDAO;

        private static IMessageDAO _messageDAO;

        private static ITopicDAO _topicDAO;

        public static IUserDAO UserDAO => _userDAO ?? (_userDAO = new UserSQLDao());

        public static IMessageDAO MessageDAO => _messageDAO ?? (_messageDAO = new MessageSQLDao());

        public static ITopicDAO TopicDAO => _topicDAO ?? (_topicDAO = new TopicSQLDao());

    }
}
