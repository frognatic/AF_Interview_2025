using System;
using AF_Interview.Items.DataModels;
using UnityEngine;

namespace AF_Interview.Items
{
    [Serializable]
    public class BonusItemDataModel : ItemBaseDataModel
    {
        #region Serialized Fields
        // temp
        [SerializeField] private string _effect;
        [SerializeField] private int _effectValue;
        
        #endregion

        #region Properties

        public string Effect { get => _effect; set => _effect = value; }
        public int EffectValue { get => _effectValue; set => _effectValue = value; }

        #endregion
    }
}
