using Introduction.Entities;

namespace Introduction.FinancialCalculator
{
    public interface IFY16BonusCalculator
    {
        decimal GetBonusPercentage(Employee employee);
    }
}