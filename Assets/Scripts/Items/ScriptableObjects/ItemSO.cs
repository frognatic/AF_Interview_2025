using UnityEngine;

namespace AF_Interview.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Items/Item")]
    public class ItemSO : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected int _itemId;
        [SerializeField] protected string _itemName;
        [SerializeField] protected string _itemDescription;
        [SerializeField] protected ItemType _itemType;
        [SerializeField] protected Sprite _itemIcon;

        #endregion
        
        #region Properties

        public int ItemId => _itemId;
        public string ItemName => _itemName;
        public string ItemDescription => _itemDescription;
        public ItemType ItemType => _itemType;
        public Sprite ItemIcon => _itemIcon;

        #endregion
    }
    
    public enum ItemType
    {
        Resource,
        Crafted,
        Bonus
    }
}
