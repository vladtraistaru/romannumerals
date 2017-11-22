using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varian.Common.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void TestIsInBetween()
        {
            Assert.IsTrue(1.IsInBetween(1, 1, true));
            Assert.IsFalse(1.IsInBetween(1, 1, false));
            Assert.IsTrue(0.IsInBetween(-1, 1, false));
            Assert.IsTrue(int.MaxValue.IsInBetween(int.MaxValue-1, int.MaxValue, true));
            Assert.IsTrue((int.MaxValue-1).IsInBetween(-int.MaxValue, int.MaxValue, false));
        }
    }
}
