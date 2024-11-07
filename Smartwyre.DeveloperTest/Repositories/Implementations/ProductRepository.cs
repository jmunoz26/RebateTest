using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Repositories.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
  private readonly ProductDataStore _productDataStore = new();

  public Product GetProduct(string productIdentifier)
  {
    return _productDataStore.GetProduct(productIdentifier);
  }
}
