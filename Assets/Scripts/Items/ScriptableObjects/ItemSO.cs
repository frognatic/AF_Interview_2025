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

        public int ItemId { get => _itemId; set => _itemId = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
        public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
        public ItemType ItemType { get => _itemType; set => _itemType = value; }
        public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }

        #endregion
    }
    
    public enum ItemType
    {
        Resource,
        Crafted,
        Bonus
    }
}
