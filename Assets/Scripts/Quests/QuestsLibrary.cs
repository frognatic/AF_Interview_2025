using System;
using System.Collections.Generic;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    [CreateAssetMenu(fileName = "QuestsLibrary", menuName = "Data/Quests/QuestsLibrary")]
    public class QuestsLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] protected List<QuestSO> _quests = new();
        [SerializeField] protected List<QuestSO> _initialQuests = new();

        #endregion

        #region Properties

        public List<QuestSO> Quests { get => _quests; set => _quests = value; }
        public List<QuestSO> InitialQuests { get => _initialQuests; set => _initialQuests = value; }

        #endregion
    }
}
