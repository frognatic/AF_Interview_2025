using System;
using System.Collections.Generic;
using AF_Interview.Bonuses;
using AF_Interview.Items;
using Cysharp.Threading.Tasks;
using MessagePipe;
using Zenject;

namespace AF_Interview.Systems
{
    public class BonusSystem : SystemBase
    {
        #region Non-Serialized Fields

        private List<Bonus> _activeBonuses = new List<Bonus>();

        #endregion
        
        #region Injected Fields
        
        [Inject] private ItemSystem _itemSystem;
        
        [Inject] private BonusFactoryProvider _bonusFactoryProvider;

        #endregion

        #region Properties

        public List<Bonus> ActiveBonuses => _activeBonuses;

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
            container.Bind<BonusFactoryProvider>()
                .AsSingle();
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

            foreach (BonusUserItem bonusItem in getBonusItems)
            {
                if (bonusItem.Amount <= 0)
                {
                    continue;
                }

                Bonus bonus = _bonusFactoryProvider.CreateBonus(bonusItem.BonusType, bonusItem.BonusValue);
                _activeBonuses.Add(bonus);
            }
        }

        private int TryGetBonusValue(BonusType bonusType)
        {
            var bonus = _activeBonuses.Find(x => x.BonusType == bonusType);
            return bonus?.BonusValue ?? 0;
        }

        #endregion
    }
}
