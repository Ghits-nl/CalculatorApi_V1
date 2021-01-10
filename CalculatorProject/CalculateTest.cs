using CalculatorAPI.Controllers;
using CalculatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CalculatorTest
{
    [TestClass]
    public class CalculateTest
    {

        private IConfigurationRoot _configuration;	
        private DbContextOptions<CalculatorContext> _options;

        public CalculateTest()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<CalculatorContext>()
                .UseSqlServer(_configuration.GetConnectionString("DevConnection")).Options;
        }

        [TestMethod]
        public void StartCalculationApiMethodShouldCalculateCorrectly()
        {
            using (var context = new CalculatorContext(_options))
            {
                CalculatorController c = new CalculatorController(context);
                var result = c.StartCalculation(4, 5);
                Assert.AreEqual(9, result);
            }
        }
    }
}
