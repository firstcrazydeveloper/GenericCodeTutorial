using System.Collections.Generic;

namespace Caculation.Module.Interface
{
    public interface ICalculation
    {
        double CaculateMedianValue(IList<double?> valueList);
        double FindPercentageValue(double minValue, int compareValue);
    }
}
