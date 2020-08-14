using System;
using EddyNewHome.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EddyNewHome.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string ex_ip = "210.119.12.61";
            string actualip = Commons.GetIpAddress();
            Assert.AreEqual(ex_ip, actualip);
        }
    }
}
