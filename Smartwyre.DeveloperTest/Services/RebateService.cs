using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Repositories.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService(IRebateRepository rebateRepository, IProductRepository productRepository, IncentiveCalculatorFactory incentiveCalculatorFactory) : IRebateService
{
    private readonly IRebateRepository _rebateRepository = rebateRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IncentiveCalculatorFactory _incentiveCalculatorFactory = incentiveCalculatorFactory;

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebate = _rebateRepository.GetRebate(request.RebateIdentifier);
        var product = _productRepository.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();
        var calculator = _incentiveCalculatorFactory.GetCalculator(rebate.Incentive);

        result.RebateAmount = calculator.CalculateRebate(rebate, product, request, out bool success);
        result.Success = success;

        if (result.Success)
        {
            _rebateRepository.StoreCalculationResult(rebate, result.RebateAmount);
        }

        return result;
    }
}