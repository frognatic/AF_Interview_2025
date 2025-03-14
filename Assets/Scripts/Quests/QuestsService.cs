using System.Collections.Generic;
using Zenject;

namespace AF_Interview.Quests
{
    public interface IQuestsService
    {
        List<Quest> GetQuests();
        void Init(List<Quest> items);
    }
    
    public class QuestsService : IQuestsService
    {
        private List<Quest> _items = new List<Quest>();

        [Inject]
        public QuestsService()
        {
        }
        
        public void Init(List<Quest> quests)
        {
            _items = quests;
        }

        public List<Quest> GetQuests()
        {
            return _items;
        }
    }
}
