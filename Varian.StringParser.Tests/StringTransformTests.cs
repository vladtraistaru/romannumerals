using Moq;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varian.RomanNumerals.DI;
using Varian.RomanNumerals.Services.Interfaces;
using Varian.StringTransform.DI;
using Varian.StringTransform.Services;
using Varian.StringTransform.Services.Interfaces;

namespace Varian.StringTransform.Tests
{
    [TestFixture]
    public class StringTransformTests
    {
        private IStringTransform stringTransform;
        IKernel kernel = new StandardKernel(new RomanNumeralModule(), new StringTransformModule());

        [SetUp]
        public void Setup()
        {
            stringTransform = kernel.Get<IStringTransform>();
        }

        [Test]
        public void ConstructorIsRobust()
        {
            Assert.DoesNotThrow(() =>
            {
                var dependency = new Mock<IRomanNumeralConverter>();
                var transformer = new RomanNumeralStringTransformNumbers(dependency.Object);
            });
        }

        [Test]
        [TestCase("abc", "abc")]
        [TestCase("numberlast1", "numberlastI")]
        [TestCase("1numberfirst", "Inumberfirst")]
        [TestCase("1a2b3c", "IaIIbIIIc")]
        [TestCase("10larger1000numbers", "XlargerMnumbers")]
        public void TextTransformTests(string input, string output)
        {
            Assert.AreEqual(output, stringTransform.Transform(input));
        }

        [Test]
        [TestCase("Lorem ipsum 2 dolor sit amet.", "Lorem ipsum II dolor sit amet.")]
        [TestCase("Consectetur 5 adipiscing elit 9.", "Consectetur V adipiscing elit IX.")]
        [TestCase("1numberfirst", "Inumberfirst")]
        [TestCase("1a2b3c", "IaIIbIIIc")]
        [TestCase("Ut enim quis nostrum 1904 qui.", "Ut enim quis nostrum M CM IV qui.")]
        public void TextTransformreaLiveTests(string input, string output)
        {
            Assert.AreEqual(output, stringTransform.Transform(input));
        }        
    }
}
