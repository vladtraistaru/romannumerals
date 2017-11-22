using Ninject;
using NUnit.Framework;
using Varian.RomanNumerals.DI;
using Varian.RomanNumerals.Services;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.Tests
{
    [TestFixture]
    public class RomanNumeralConverterTests
    {
        private IRomanNumeralConverter converter;
        IKernel kernel = new StandardKernel(new RomanNumeralModule());

        [SetUp]
        public void Setup()
        {
            converter = kernel.Get<IRomanNumeralConverter>();
        }

        [Test]
        public void ConstructorIsRobust()
        {
            Assert.DoesNotThrow(() =>
            {
                var converter = new RomanNumeralConverter();
            });            
        }

        [Test]
        public void Convert_1()
        {
            var roman = converter.Convert(1);
            Assert.AreEqual("I", 1);
        }
    }
}
