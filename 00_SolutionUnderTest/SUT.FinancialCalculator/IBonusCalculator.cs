using SUT.Entities;

namespace SUT.FinancialCalculator
{
    public interface IBonusCalculator
    {
        decimal GetBonusPercentage(Employee employee);
    }
}