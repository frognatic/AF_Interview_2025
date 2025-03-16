using TMPro;
using UnityEngine;

namespace AF_Interview.UI.UIGameplay
{
    public class UIBonusDisplay : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _bonusTypeText;
        [SerializeField] private TextMeshProUGUI _bonusValueText;

        #endregion

        #region Public Methods

        public void Prepare(string bonusType, int bonusValue, string bonusUnit)
        {
            _bonusTypeText.text = bonusType;
            _bonusValueText.text = $"{bonusValue}{bonusUnit}";
        }

        #endregion
    }
}
