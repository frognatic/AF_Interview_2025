using AF_Interview.Items;

namespace AF_Interview.Bonuses
{
    public class Bonus : IBonus
    {
        public BonusType BonusType { get; set; }
        public int BonusValue { get; set; }
        public string BonusUnit { get; set; }

        public Bonus(BonusType bonusType, int bonusValue)
        {
            BonusType = bonusType;
            BonusValue = bonusValue;
            BonusUnit = GetBonusUnit(bonusType);
        }

        private string GetBonusUnit(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.CraftingSuccessRate:
                    return "%";
                case BonusType.CraftingTimeReduce:
                    return "s";
                default:
                    return string.Empty;
            }
        }
    }

    public interface IBonus
    {
        BonusType BonusType { get; set; }
        int BonusValue { get; set; }
        string BonusUnit { get; set; }
    }
}
