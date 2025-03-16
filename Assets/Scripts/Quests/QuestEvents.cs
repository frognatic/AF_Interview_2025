namespace AF_Interview.Quests
{
    public abstract class QuestEventBase
    {
        public UserQuest UserQuest;
    }
    
    public class QuestProgressUpdateEvent : QuestEventBase {}
    public class QuestCompletedEvent : QuestEventBase {}
}
