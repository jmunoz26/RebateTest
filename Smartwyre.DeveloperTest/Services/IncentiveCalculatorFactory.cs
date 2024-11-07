using System;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class IncentiveCalculatorFactory
{
  public IIncentiveCalculator GetCalculator(IncentiveType incentiveType)
  {
    return incentiveType switch
    {
      IncentiveType.FixedCashAmount => new FixedCashAmountCalculator(),
      IncentiveType.FixedRateRebate => new FixedRateRebateCalculator(),
      IncentiveType.AmountPerUom => new AmountPerUomCalculator(),
      _ => throw new NotSupportedException($"Incentive type '{incentiveType}' is not supported.")
    };
  }
}
