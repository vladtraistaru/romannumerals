using Ninject;
using NUnit.Framework;
using Varian.RomanNumerals.DI;
using Varian.RomanNumerals.Services;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.Tests
{
    [TestFixture]
    public class RomanNumeralConverterBasicTests
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
        public void ConvertBaseNotations()
        {
            var roman = converter.Convert(1);
            Assert.AreEqual("I", roman.RomanNotation);

            roman = converter.Convert(5);
            Assert.AreEqual("V", roman.RomanNotation);

            roman = converter.Convert(10);
            Assert.AreEqual("X", roman.RomanNotation);

            roman = converter.Convert(50);
            Assert.AreEqual("L", roman.RomanNotation);

            roman = converter.Convert(100);
            Assert.AreEqual("C", roman.RomanNotation);

            roman = converter.Convert(1000);
            Assert.AreEqual("M", roman.RomanNotation);
        }
    }
}
