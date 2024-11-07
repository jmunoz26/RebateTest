using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        if (productIdentifier == "1")
        {
            return new Product
            {
                Identifier = "1",
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
                Price = 50 // Precio del producto, necesario para ciertos cálculos
            };
        }
        return new Product();
    }
}
