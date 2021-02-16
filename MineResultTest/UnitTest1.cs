using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedGateTechInterview;
using System;

namespace MineResultTest
{
    [TestClass]
    public class MineResultTest
    {
        [TestMethod]
        public void Test_MineResults_3X3()
        {
            var arr = new string[,]
            {
                { ".", ".", "*" },
                { ".", "*", "." },
                { ".", ".", "." }
            };
            var result = new MineResult(arr).GetMineResults();
            Assert.AreEqual(@"
12*
1*2
110", result);
        }



        [TestMethod]
        public void Test_MineResults_3X4()
        {
            var arr = new string[,]
            {
                { ".", ".", "*", "." },
                { ".", "*", ".", "." },
                { ".", ".", ".", "." }
            };
            var result = new MineResult(arr).GetMineResults();
            Assert.AreEqual(@"
12*1
1*20
1100", result);
        }
    }
}
