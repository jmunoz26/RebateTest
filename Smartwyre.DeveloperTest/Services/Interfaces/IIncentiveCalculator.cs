using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.Interfaces;

public interface IIncentiveCalculator
{
  decimal CalculateRebate(Rebate rebate, Product product, CalculateRebateRequest request, out bool success);
}
