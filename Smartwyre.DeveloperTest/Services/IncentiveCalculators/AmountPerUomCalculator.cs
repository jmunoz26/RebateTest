using System;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators;

public class AmountPerUomCalculator : IIncentiveCalculator
{
  public decimal CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request, out bool success)
  {
    success = rebate != null &&
              product != null &&
              product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) &&
              rebate.Amount > 0 &&
              request.Volume > 0;

    return success ? rebate.Amount * request.Volume : 0;
  }
}