using System.Collections.Generic;
using AF_Interview.Quests;
using AF_Interview.Utilities;
using TMPro;
using UnityEngine;

namespace AF_Interview.UI.UIGameplay
{
    public class UIQuestDisplay : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private TextMeshProUGUI _questNameText;
        [SerializeField] private GameObject _questFinishPanel;
        
        [Header("Quest Tasks")]
        [SerializeField] private UIQuestTask _questTaskPrefab;
        [SerializeField] private Transform _questTaskContainer;

        #endregion

        #region Non-Serialized Fields

        private List<UIQuestTask> _questTasks = new List<UIQuestTask>();

        #endregion

        #region Public Methods

        public void Prepare(Quest quest)
        {
            _questNameText.text = quest.QuestData.QuestName;

            _questTaskContainer.DestroyAllChildren();
            foreach (var questProgress in quest.Progress)
            {
                UIQuestTask questTask = Instantiate(_questTaskPrefab, _questTaskContainer);
                questTask.Prepare(GetQuestTaskDescription(questProgress));
                
                _questTasks.Add(questTask);
            }
            
            _questFinishPanel.SetActive(quest.IsFinished);
        }

        #endregion
        
        #region Private Methods

        private string GetQuestTaskDescription(QuestProgress progress)
        {
            return $"Craft {progress.RequiredItem.ItemName} {progress.CurrentValue} / {progress.EndValue}";
        }
        
        #endregion
    }
}
