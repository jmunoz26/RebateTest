using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Repositories;
using Smartwyre.DeveloperTest.Repositories.Interfaces;
using Smartwyre.DeveloperTest.Repositories.Implementations;

namespace Smartwyre.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancias de repositorios
            IRebateRepository rebateRepository = new RebateRepository();
            IProductRepository productRepository = new ProductRepository();

            // Crear instancia de la fábrica de calculadoras y del servicio de rebates
            var incentiveCalculatorFactory = new IncentiveCalculatorFactory();
            var rebateService = new RebateService(rebateRepository, productRepository, incentiveCalculatorFactory);

            // Solicitar entrada del usuario para el identificador de rebate y producto
            Console.WriteLine("Ingrese el identificador del rebate:");
            var rebateIdentifier = Console.ReadLine();

            Console.WriteLine("Ingrese el identificador del producto:");
            var productIdentifier = Console.ReadLine();

            Console.WriteLine("Ingrese el volumen de la solicitud:");
            if (!decimal.TryParse(Console.ReadLine(), out var volume))
            {
                Console.WriteLine("Volumen no válido. Saliendo del programa.");
                return;
            }

            // Crear la solicitud de cálculo
            var request = new CalculateRebateRequest
            {
                RebateIdentifier = rebateIdentifier,
                ProductIdentifier = productIdentifier,
                Volume = volume
            };

            // Ejecutar el cálculo de rebate
            var result = rebateService.Calculate(request);

            // Mostrar el resultado
            if (result.Success)
            {
                Console.WriteLine($"Cálculo exitoso. Monto del rebate: {result.RebateAmount}");
            }
            else
            {
                Console.WriteLine("El cálculo del rebate falló.");
            }
        }
    }
}