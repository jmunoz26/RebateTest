using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Repositories.Interfaces;

public interface IProductRepository
{
  Product GetProduct(string productIdentifier);
}
