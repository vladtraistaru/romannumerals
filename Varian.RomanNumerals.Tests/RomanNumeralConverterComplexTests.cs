using Ninject;
using NUnit.Framework;
using Varian.RomanNumerals.DI;
using Varian.RomanNumerals.Services;
using Varian.RomanNumerals.Services.Interfaces;

namespace Varian.RomanNumerals.Tests
{
    [TestFixture]
    public class RomanNumeralConverterComplexTests
    {
        private IRomanNumeralConverter converter;
        IKernel kernel = new StandardKernel(new RomanNumeralModule());

        [SetUp]
        public void Setup()
        {
            converter = kernel.Get<IRomanNumeralConverter>();
        }


        [Test]
        public void Convert_2()
        {
            var roman = converter.Convert(4);
            Assert.AreEqual("II", roman.RomanNotation);
        }

        [Test]
        public void Convert_3()
        {
            var roman = converter.Convert(4);
            Assert.AreEqual("III", roman.RomanNotation);
        }

        [Test]
        public void Convert_4()
        {
            var roman = converter.Convert(4);
            Assert.AreEqual("IV", roman.RomanNotation);
        }

        [Test]
        public void Convert_6()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("VI", roman.RomanNotation);
        }

        [Test]
        public void Convert_7()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("VII", roman.RomanNotation);
        }

        [Test]
        public void Convert_8()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("VIII", roman.RomanNotation);
        }

        [Test]
        public void Convert_9()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("IX", roman.RomanNotation);
        }

        [Test]
        public void Convert_11()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("XI", roman.RomanNotation);
        }

        [Test]
        public void Convert_1234()
        {
            var roman = converter.Convert(6);
            Assert.AreEqual("MCCXXXIV", roman.RomanNotation);
        }
    }
}
