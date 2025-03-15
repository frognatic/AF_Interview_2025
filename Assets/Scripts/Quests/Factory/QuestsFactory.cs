namespace AF_Interview.Quests
{
    public class QuestsFactory : IQuestsFactory
    {
        public Quest CreateQuest(QuestSO data)
        {
            return new Quest(data);
        }
    }
    
    public interface IQuestsFactory
    {
        Quest CreateQuest(QuestSO data);
    }
}
