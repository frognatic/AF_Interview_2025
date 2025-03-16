using System.Collections.Generic;
using AF_Interview.Quests;
using AF_Interview.Utilities;
using UnityEngine;

namespace AF_Interview.UI.UIGameplay
{
    public class UIQuestsPanelDataModel : DataModel
    {
        public List<Quest> Quest;
    }
    
    public class UIQuestsPanel : UIBasePanel
    {
        #region Serialized Fields

        [SerializeField] private UIQuestDisplay _uiQuestDisplayPrefab;
        [SerializeField] private Transform _uiDisplaysContainer;

        #endregion
        
        #region Properties
        
        protected new UIQuestsPanelDataModel DataModel => (UIQuestsPanelDataModel)base.DataModel;
        
        #endregion

        #region Public Methods

        public override void Prepare(DataModel dataModel)
        {
            base.Prepare(dataModel);
            
            _uiDisplaysContainer.DestroyAllChildren();
            foreach (var quest in DataModel.Quest)
            {
                UIQuestDisplay uiQuestDisplay = Instantiate(_uiQuestDisplayPrefab, _uiDisplaysContainer);
                uiQuestDisplay.Prepare(quest);
            }
        }

        #endregion
    }
}
