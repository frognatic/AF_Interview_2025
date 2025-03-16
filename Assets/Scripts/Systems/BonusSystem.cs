using System;
using System.Collections.Generic;
using AF_Interview.Items;
using Cysharp.Threading.Tasks;
using MessagePipe;
using Zenject;

namespace AF_Interview.Systems
{
    public class BonusSystem : SystemBase
    {
        #region Non-Serialized Fields

        private Dictionary<BonusType, int> _bonuses = new();

        #endregion
        
        #region Injected Fields
        
        [Inject] private ItemSystem _itemSystem;

        #endregion
        
        #region Override Methods

        public override Type[] BindingContractTypes => new Type[]
        {
            typeof(BonusSystem)
        };
        public override void Construct()
        {

        }
        public override void InstallBindings(DiContainer container, MessagePipeOptions messagePipeOptions)
        {
            
        }

        public override async UniTask Init()
        {
            PrepareBonuses();
            IsReady = true;
            await UniTask.CompletedTask;
        }

        #endregion

        #region Public Methods

        public int GetCraftingTimeReduceBonus()
        {
            return TryGetBonusValue(BonusType.CraftingTimeReduce);
        }

        public int GetCraftingSuccessRateBonus()
        {
            return TryGetBonusValue(BonusType.CraftingSuccessRate);
        }

        #endregion
        

        #region Private Methods

        private void PrepareBonuses()
        {
            var getBonusItems = _itemSystem.GetAllAvailableBonusItems();

            foreach (BonusItem bonusItem in getBonusItems)
            {
                if (bonusItem.Amount <= 0)
                {
                    continue;
                }
                    
                _bonuses.TryAdd(bonusItem.BonusType, bonusItem.BonusValue);
            }
        }

        private int TryGetBonusValue(BonusType bonusType)
        {
            return _bonuses.GetValueOrDefault(bonusType, 0);
        }

        #endregion
    }
}
