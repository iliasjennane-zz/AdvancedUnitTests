using SUT.Entities;

namespace SUT.FinancialCalculator
{
    public interface IBonusCalculator
    {
        double GetBonusPercentage(Employee employee);
    }
}