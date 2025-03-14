using UnityEngine;

namespace AF_Interview.Quests
{
    public abstract class QuestBaseSO : ScriptableObject, IQuestBaseDataModel
    {
        #region Properties
        
        protected virtual QuestBaseDataModel DataModel { get; set; }

        public QuestBaseDataModel GetDataModel() => DataModel;

        #endregion
    }
    
    public interface IQuestBaseDataModel
    {
        QuestBaseDataModel GetDataModel();
    }
}
