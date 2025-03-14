using System;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    public class InitialQuestsDataModel
    {
        #region Serialized Fields

        [SerializeField] protected QuestBaseSO _questData;

        #endregion

        #region Properties

        public QuestBaseSO QuestData { get => _questData; set => _questData = value; }

        #endregion
    }
}
