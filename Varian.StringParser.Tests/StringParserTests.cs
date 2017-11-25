using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varian.StringParser.DI;
using Varian.StringParser.Services;
using Varian.StringParser.Services.Interfaces;

namespace Varian.StringParser.Tests
{
    [TestFixture]
    public class StringParserTests
    {
        private IStringParserService parserService;
        IKernel kernel = new StandardKernel(new StringParserModule());

        [SetUp]
        public void Setup()
        {
            parserService = kernel.Get<IStringParserService>();
        }

        [Test]
        public void ConstructorIsRobust()
        {
            Assert.DoesNotThrow(() =>
            {
                var converter = new StringParserService();
            });
        }
    }
}
