using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AF_Interview.UI.UIGameplay
{
    public class UIInventorySlot : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Filled Slot Data")]
        [SerializeField] private GameObject _slotFillPanel;
        [SerializeField] private Image _slotImage;
        [SerializeField] private TextMeshProUGUI _slotInventoryAmountText;

        #endregion

        #region Public Methods

        public void SetSlotOccupied(Sprite sprite, int amount)
        {
            _slotFillPanel.SetActive(true);
            
            _slotImage.sprite = sprite;
            _slotInventoryAmountText.text = amount.ToString();
        }

        public void SetSlotEmpty()
        {
            _slotFillPanel.SetActive(false);
        }

        #endregion
    }
}
