using FileReader.Module.Interface;

namespace Common.Module.Interface
{
    public interface IFactory<T>
    {
        IFileReader<T> GetFileReaderInstance(string fileType);
        IDataManager<T> GetDataManagerInstance();
        IFileReaderDataManager<T> GetFileReaderDataManagerInstance();
    }
}
