using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    public class QuestsLibraryDataModel
    {
        #region Serialized Fields

        [SerializeField] protected List<QuestBase> _quests = new();

        #endregion

        #region Properties

        public List<QuestBase> Quests { get => _quests; set => _quests = value; }

        #endregion
    }
}
