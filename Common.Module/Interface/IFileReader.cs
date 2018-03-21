using Common.Module.Interface;
using System.Collections.Generic;

namespace FileReader.Module.Interface
{
    public interface IFileReader<T>
    {
        IList<T> ReadFileContent(string pathLocation, IFileReaderDataManager<T> converter);
    }
}
