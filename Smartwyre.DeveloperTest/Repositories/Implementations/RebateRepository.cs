using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Repositories.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Repositories.Implementations;

public class RebateRepository : IRebateRepository
{
  private readonly RebateDataStore _rebateDataStore = new();

  public Rebate GetRebate(string rebateIdentifier)
  {
    return _rebateDataStore.GetRebate(rebateIdentifier);
  }

  public void StoreCalculationResult(Rebate rebate, decimal amount)
  {
    _rebateDataStore.StoreCalculationResult(rebate, amount);
  }
}
