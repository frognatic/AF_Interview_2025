using System;
using AF_Interview.Systems;
using UnityEngine;
using Zenject;

namespace AF_Interview.UI
{
    public class UIGameplayHUDDataModel
    {
        
    }
    
    public class UIGameplayHUD : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private UITextLabel _textLabelPrefab;
        [SerializeField] private Transform _inventoryContent;
        [SerializeField] private Transform _forgeContent;
        [SerializeField] private Transform _questsContent;

        #endregion

        #region Injected Fields

        [Inject] private readonly ItemSystem _itemSystem;
        [Inject] private readonly QuestsSystem _questsSystem;
        [Inject] private readonly CraftingSystem _craftingSystem;

        #endregion
        
        #region Private Methods

        private void Start()
        {
            CreateInventoryContent();
            CreateForgeContent();
            CreateQuestsContent();
        }

        private void CreateInventoryContent()
        {
            foreach (var item in _itemSystem.GetItems())
            {
                var itemDisplay = Instantiate(_textLabelPrefab, _inventoryContent);

                string itemDisplayText = $"{item.ItemData.GetDataModel().ItemName} || {item.Amount}";
                itemDisplay.SetText(itemDisplayText);
            }
        }

        private void CreateQuestsContent()
        {
            foreach (var quest in _questsSystem.GetQuests())
            {
                var questDisplay = Instantiate(_textLabelPrefab, _questsContent);

                string questDisplayText = $"{quest.QuestData.GetDataModel().QuestName} || {quest.Progress[0].CurrentValue}/{quest.Progress[0].EndValue}";
                questDisplay.SetText(questDisplayText);
            }
        }

        private void CreateForgeContent()
        {
            foreach (var craftingMachine in _craftingSystem.GetCraftingMachines())
            {
                var craftingMachineDisplay = Instantiate(_textLabelPrefab, _forgeContent);

                string craftingMachineText = $"{craftingMachine.CraftingMachineData.GetDataModel().MachineName}";
                craftingMachineDisplay.SetText(craftingMachineText);
            }
        }

        #endregion
    }
}
