namespace AF_Interview.Quests
{
    public class UserQuestsFactory : IUserQuestsFactory
    {
        public UserQuest CreateUserQuest(QuestSO data)
        {
            return new UserQuest(data);
        }
    }
    
    public interface IUserQuestsFactory
    {
        UserQuest CreateUserQuest(QuestSO data);
    }
}
