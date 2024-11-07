using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Repositories.Interfaces;

public interface IRebateRepository
{
  Rebate GetRebate(string rebateIdentifier);
  void StoreCalculationResult(Rebate rebate, decimal amount);
}
