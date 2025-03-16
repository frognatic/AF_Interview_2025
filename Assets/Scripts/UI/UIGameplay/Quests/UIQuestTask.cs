using TMPro;
using UnityEngine;

namespace AF_Interview.UI.UIGameplay
{
    public class UIQuestTask : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _questTaskText;

        #endregion

        #region Public Methods

        public void Prepare(string questTaskDescription)
        {
            _questTaskText.text = questTaskDescription;
        }

        #endregion
    }
}
