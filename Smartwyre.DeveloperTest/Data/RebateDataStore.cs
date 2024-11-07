using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        if (rebateIdentifier == "1234")
        {
            return new Rebate
            {
                Identifier = "1234",
                Incentive = IncentiveType.FixedCashAmount,
                Amount = 10 // Valor de rebate por unidad o monto fijo
            };
        }
        return new Rebate();
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
