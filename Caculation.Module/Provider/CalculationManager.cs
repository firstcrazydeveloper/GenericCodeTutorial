using Caculation.Module.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Caculation.Module.Provider
{
    public class CalculationManager : ICalculation
    {
        public double CaculateMedianValue(IList<double?> valueList)
        {
            valueList = valueList.OrderBy(val => val).ToList();
            int size = valueList.Count;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)valueList[mid] : ((double)valueList[mid] +
                (double)valueList[mid - 1]) / 2;

            return median;
        }

       

        public double FindPercentageValue(double minValue, int compareValue)
        {
            double percentageVal = ((double)(compareValue * minValue) / 100);
            return percentageVal;
        }
        
    }
}
