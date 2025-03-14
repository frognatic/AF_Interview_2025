using TMPro;
using UnityEngine;

namespace AF_Interview.UI
{
    public class UITextLabel : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _textLabel;

        #endregion
        
        #region Public Methods

        public void SetText(string text)
        {
            _textLabel.text = text;
        }
        
        #endregion
    }
}
