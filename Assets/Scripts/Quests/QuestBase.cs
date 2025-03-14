using UnityEngine;

namespace AF_Interview.Quests
{
    public abstract class QuestBase : ScriptableObject, IQuestBaseDataModel
    {
        #region Properties
        
        protected virtual IQuestBaseDataModel DataModel { get; set; }

        public QuestBaseDataModel GetDataModel() => DataModel as QuestBaseDataModel;

        #endregion
    }
    
    public interface IQuestBaseDataModel
    {
        QuestBaseDataModel GetDataModel();
    }
}
