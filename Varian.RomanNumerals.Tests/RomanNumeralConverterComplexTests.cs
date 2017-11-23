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

        [TestCase(2,"II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        public void GeneralTest_Under10(int number, string romanNumeral)
        {
            var roman = converter.Convert(number);
            Assert.AreEqual(romanNumeral, roman.RomanNotation);
        }

        [TestCase(11, "X I")]
        [TestCase(12, "X II")]
        [TestCase(20, "XX")]
        public void GeneralTest_10_100(int number, string romanNumeral)
        {
            var roman = converter.Convert(number);
            Assert.AreEqual(romanNumeral, roman.RomanNotation);
        }

        [TestCase(1234, "M CC XXX IV")]
        [TestCase(12, "X II")]
        [TestCase(1954, "M CM L IV")]
        [TestCase(1990, "M CM XC")]
        [TestCase(2014, "MM X IV")]
        [TestCase(2006, "MM VI")]
        [TestCase(2004, "MM IV")]
        [TestCase(650, "DC L")]
        [TestCase(222, "CC XX II")]
        [TestCase(1066, "M LX VI")]
        [TestCase(714, "DCC X IV")]
        [TestCase(650, "DC L")]
        [TestCase(99, "XC IX")]
        [TestCase(1066, "M LX VI")]
        [TestCase(714, "DCC X IV")]
        [TestCase(1999, "M CM XC IX")]
        [TestCase(3999, "MMM CM XC IX")]
        public void GeneralTest_Complex(int number, string romanNumeral)
        {
            var roman = converter.Convert(number);
            Assert.AreEqual(romanNumeral, roman.RomanNotation);
        }        
    }
}
