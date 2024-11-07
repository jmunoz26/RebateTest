using System;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class FixedCashAmountCalculator : IIncentiveCalculator
{
  public decimal CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request, out bool success)
  {
    success = rebate != null &&
              product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) &&
              rebate.Amount > 0;

    return success ? rebate.Amount : 0;
  }
}
