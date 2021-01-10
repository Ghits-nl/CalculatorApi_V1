using CalculatorAPI.Controllers;
using CalculatorAPI.Models;
using NUnit.Framework;

namespace NUnitTest
{
    public class Tests
    {
        private CalculatorContext _context;

        [SetUp]
        public void Setup(CalculatorContext context)
        {
            _context = context;
        }

        [Test]
        public void StartCalculationApiMethodShouldCalculateCorrectly()
        {
            CalculatorController c = new CalculatorController(_context);
            var result  = c.StartCalculation(4, 5);
            Assert.AreEqual(9, result);

        }
    }
}