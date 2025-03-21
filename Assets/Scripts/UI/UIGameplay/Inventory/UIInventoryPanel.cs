using System.Collections.Generic;
using AF_Interview.Items;
using AF_Interview.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace AF_Interview.UI.UIGameplay
{
    public class UIInventoryPanelDataModel : DataModel
    {
        public List<UserItem> AvailableItemsList;
    }
    
    public class UIInventoryPanel : UIBasePanel
    {
        #region Serialized Fields

        [Header("Grid Settings")]
        [SerializeField] private Vector2Int _gridSize = new Vector2Int(4, 5);
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        [Header("Slots")]
        [SerializeField] private UIInventorySlot _uiInventorySlotPrefab;
        [SerializeField] private Transform _slotsContent;

        #endregion

        #region Non-Serialized Fields

        private readonly List<UIInventorySlot> _inventorySlots = new List<UIInventorySlot>();
        
        #endregion
        
        #region Properties
        
        protected new UIInventoryPanelDataModel DataModel => (UIInventoryPanelDataModel)base.DataModel;
        
        #endregion

        #region Public Methods

        public override void Prepare(DataModel dataModel)
        {
            base.Prepare(dataModel);
            
            PrepareSlots();
            RefreshSlots();
        }

        public void RefreshSlots()
        {
            FillSlots();
        }

        #endregion

        #region Private Methods

        private void PrepareSlots()
        {
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.constraintCount = _gridSize.x;
            
            int inventorySlotsElements = _gridSize.x * _gridSize.y;

            _slotsContent.DestroyAllChildren();
            _inventorySlots.Clear();
            
            for (int i = 0; i < inventorySlotsElements; i++)
            {
                UIInventorySlot inventorySlot = Instantiate(_uiInventorySlotPrefab, _slotsContent);
                inventorySlot.name = $"Slot_{i}";
                _inventorySlots.Add(inventorySlot);
            }
        }

        private void FillSlots()
        {
            int availableItemsListCount = DataModel.AvailableItemsList.Count;

            int i = 0;
            for (; i < availableItemsListCount; i++)
            {
                var dataItem = DataModel.AvailableItemsList[i];
                _inventorySlots[i].SetSlotOccupied(dataItem.ItemData.ItemIcon, dataItem.Amount);
            }

            for (; i < _inventorySlots.Count; i++)
            {
                _inventorySlots[i].SetSlotEmpty();
            }
        }

        #endregion
    }
}
