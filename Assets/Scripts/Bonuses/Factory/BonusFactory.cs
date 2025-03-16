using AF_Interview.Items;

namespace AF_Interview.Bonuses
{
    public class BonusFactory : IBonusesFactory
    {
        public Bonus CreateBonus(BonusType bonusType, int bonusValue)
        {
            return new Bonus(bonusType, bonusValue);
        }
    }
    
    public interface IBonusesFactory
    {
        Bonus CreateBonus(BonusType bonusType, int bonusValue);
    }
}
