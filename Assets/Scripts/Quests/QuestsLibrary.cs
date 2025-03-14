using System;
using UnityEngine;

namespace AF_Interview.Quests
{
    [Serializable]
    [CreateAssetMenu(fileName = "QuestsLibrary", menuName = "Data/Quests/QuestsLibrary")]
    public class QuestsLibrary : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField] private QuestsLibraryDataModel _questsLibraryDataModel;

        #endregion

        #region Public Methods

        public QuestsLibraryDataModel GetQuestsLibraryDataModel()
        {
            return _questsLibraryDataModel;
        }

        #endregion
    }
}
