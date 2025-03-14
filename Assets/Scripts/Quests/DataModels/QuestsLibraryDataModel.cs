using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    public class QuestsLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<QuestBaseSO> _quests = new();
        [SerializeField] protected List<InitialQuestsDataModel> _initialQuests = new();

        #endregion

        #region Properties

        public List<QuestBaseSO> Quests { get => _quests; set => _quests = value; }
        public List<InitialQuestsDataModel> InitialQuests { get => _initialQuests; set => _initialQuests = value; }

        #endregion
    }
}
