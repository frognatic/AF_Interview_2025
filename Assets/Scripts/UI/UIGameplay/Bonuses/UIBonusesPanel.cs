using System.Collections.Generic;
using AF_Interview.Bonuses;
using AF_Interview.Utilities;
using UnityEngine;

namespace AF_Interview.UI.UIGameplay
{
    public class UIBonusesPanelDataModel : DataModel
    {
        public List<Bonus> Bonuses;
    }
    
    public class UIBonusesPanel : UIBasePanel
    {
        #region Serialized Fields

        [SerializeField] private UIBonusDisplay _bonusDisplayPrefab;
        [SerializeField] private Transform _bonusesContainer;

        [SerializeField] private GameObject _noBonusPanel;

        #endregion
        
        #region Properties
        
        protected new UIBonusesPanelDataModel DataModel => (UIBonusesPanelDataModel)base.DataModel;
        
        #endregion

        #region Public Methods

        public override void Prepare(DataModel dataModel)
        {
            base.Prepare(dataModel);

            _bonusesContainer.DestroyAllChildren();
            _noBonusPanel.SetActive(DataModel.Bonuses.Count == 0);
            
            foreach (var bonus in DataModel.Bonuses)
            {
                UIBonusDisplay bonusDisplay = Instantiate(_bonusDisplayPrefab, _bonusesContainer);
                bonusDisplay.Prepare(bonus.BonusType.ToString(), bonus.BonusValue, bonus.BonusUnit);
            }
        }

        #endregion
    }
}
