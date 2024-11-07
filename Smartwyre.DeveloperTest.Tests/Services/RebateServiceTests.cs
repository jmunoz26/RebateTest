using Xunit;
using Moq;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Repositories;
using Smartwyre.DeveloperTest.Repositories.Interfaces;

public class RebateServiceTests
{
  private readonly Mock<IRebateRepository> _rebateRepositoryMock;
  private readonly Mock<IProductRepository> _productRepositoryMock;
  private readonly IncentiveCalculatorFactory _incentiveCalculatorFactory;
  private readonly RebateService _rebateService;

  public RebateServiceTests()
  {
    _rebateRepositoryMock = new Mock<IRebateRepository>();
    _productRepositoryMock = new Mock<IProductRepository>();
    _incentiveCalculatorFactory = new IncentiveCalculatorFactory();
    _rebateService = new RebateService(_rebateRepositoryMock.Object, _productRepositoryMock.Object, _incentiveCalculatorFactory);
  }

  [Fact]
  public void Calculate_FixedRateRebate_SuccessfulCalculation()
  {
    var rebate = new Rebate { Incentive = IncentiveType.FixedRateRebate, Percentage = 0.1m };
    var product = new Product { Price = 50, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
    var request = new CalculateRebateRequest { RebateIdentifier = "rebate1", ProductIdentifier = "product1", Volume = 10 };

    _rebateRepositoryMock.Setup(r => r.GetRebate("rebate1")).Returns(rebate);
    _productRepositoryMock.Setup(p => p.GetProduct("product1")).Returns(product);

    var result = _rebateService.Calculate(request);

    Assert.True(result.Success);
    Assert.Equal(50, result.RebateAmount); // 50 * 0.1 * 10 = 50
  }

  [Fact]
  public void Calculate_FixedRateRebate_FailsWhenConditionsAreNotMet()
  {
    var rebate = new Rebate { Incentive = IncentiveType.FixedRateRebate, Percentage = 0 };
    var product = new Product { Price = 50, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
    var request = new CalculateRebateRequest { RebateIdentifier = "rebate1", ProductIdentifier = "product1", Volume = 10 };

    _rebateRepositoryMock.Setup(r => r.GetRebate("rebate1")).Returns(rebate);
    _productRepositoryMock.Setup(p => p.GetProduct("product1")).Returns(product);

    var result = _rebateService.Calculate(request);

    Assert.False(result.Success);
    Assert.Equal(0, result.RebateAmount);
  }

  [Fact]
  public void Calculate_AmountPerUom_SuccessfulCalculation()
  {
    var rebate = new Rebate { Incentive = IncentiveType.AmountPerUom, Amount = 5 };
    var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
    var request = new CalculateRebateRequest { RebateIdentifier = "rebate2", ProductIdentifier = "product2", Volume = 10 };

    _rebateRepositoryMock.Setup(r => r.GetRebate("rebate2")).Returns(rebate);
    _productRepositoryMock.Setup(p => p.GetProduct("product2")).Returns(product);

    var result = _rebateService.Calculate(request);

    Assert.True(result.Success);
    Assert.Equal(50, result.RebateAmount); // 5 * 10 = 50
  }

  [Fact]
  public void Calculate_AmountPerUom_FailsWhenConditionsAreNotMet()
  {
    var rebate = new Rebate { Incentive = IncentiveType.AmountPerUom, Amount = 0 };
    var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
    var request = new CalculateRebateRequest { RebateIdentifier = "rebate2", ProductIdentifier = "product2", Volume = 10 };

    _rebateRepositoryMock.Setup(r => r.GetRebate("rebate2")).Returns(rebate);
    _productRepositoryMock.Setup(p => p.GetProduct("product2")).Returns(product);

    var result = _rebateService.Calculate(request);

    Assert.False(result.Success);
    Assert.Equal(0, result.RebateAmount);
  }
}