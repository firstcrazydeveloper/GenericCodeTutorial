using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;

namespace Common.Module.Interface
{
    public interface IDataManager<T>
    {
        double GetMedianValue(IList<T> dataList);
        IList<T> FindAboveGivenValue(IList<T> dataList, double minValue, int compareValue);
        IList<T> FindBelowGivenValue(IList<T> dataList, double minValue, int compareValue);
        IList<T> FindInvalidData(IList<T> dataList);
        IList<T> FindAboveAndBelowGivenValue(IList<T> dataList, double minValue, int compareValue);


    }
}
