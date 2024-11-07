using System;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class FixedRateRebateCalculator : IIncentiveCalculator
{
  public decimal CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request, out bool success)
  {
    success = rebate != null &&
              product != null &&
              product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) &&
              rebate.Percentage > 0 &&
              product.Price > 0 &&
              request.Volume > 0;

    return success ? product.Price * rebate.Percentage * request.Volume : 0;
  }
}
