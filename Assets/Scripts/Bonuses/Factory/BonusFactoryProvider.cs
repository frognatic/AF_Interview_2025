using System.Collections.Generic;
using AF_Interview.Items;
using UnityEngine;
using Zenject;

namespace AF_Interview.Bonuses
{
    public class BonusFactoryProvider
    {
        [Inject]
        public BonusFactoryProvider()
        {
        }
        
        private readonly Dictionary<BonusType, IBonusesFactory> _factories = new Dictionary<BonusType, IBonusesFactory>()
        {
            { BonusType.CraftingSuccessRate, new BonusFactory() },
            { BonusType.CraftingTimeReduce, new BonusFactory() }
        };

        public Bonus CreateBonus(BonusType bonusType, int bonusValued)
        {
            if (_factories.TryGetValue(bonusType, out IBonusesFactory factory))
            {
                return factory.CreateBonus(bonusType, bonusValued);
            }

            Debug.LogError($"Can't create bonus for {bonusType}");
            return null;
        }
    }
}
