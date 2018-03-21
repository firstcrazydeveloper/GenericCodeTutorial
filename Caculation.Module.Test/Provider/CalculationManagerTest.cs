using Caculation.Module.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Caculation.Module.Test.Provider
{
    [TestClass]
    public class CalculationManagerTest
    {
        CalculationManager manager;

        public CalculationManagerTest()
        {
            manager = new CalculationManager();
        }

        [TestMethod]
        public void CaculateMedianValueTest()
        {
            List<double?> dataList = new List<double?>();
            dataList.Add(3.5);
            dataList.Add(4.5);
            dataList.Add(7.5);
            dataList.Add(8.5);
            dataList.Add(2.5);
            dataList.Add(9.5);
            dataList.Add(3);

            Assert.IsTrue(manager.CaculateMedianValue(dataList) == 4.5);
        }

        [TestMethod]
        public void FindPercentageValueTest()
        {
            Assert.IsTrue(manager.FindPercentageValue(50,5) == 2.5);
        }
    }
}
