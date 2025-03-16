namespace AF_Interview.Quests
{
    public abstract class QuestEventBase
    {
        public Quest Quest;
    }
    
    public class QuestProgressUpdateEvent : QuestEventBase {}
    public class QuestCompletedEvent : QuestEventBase {}
}
