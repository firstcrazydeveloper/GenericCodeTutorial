using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;

namespace Common.Module.Interface
{
    public interface IFileReaderDataManager<T>
    {
        IList<T> GenerateData(CsvReader csv);
    }
}
