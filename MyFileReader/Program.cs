using Common.Module.Interface;
using Common.Module.Models;
using Data.Module.Helper;
using Data.Module.Provider;
using FileReader.Module.Interface;
using FileReader.Module.Provider;

namespace MyFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
           // Implement Factory Design Patterns
            IFactory<LPDatModel> factory = new Factory<LPDatModel>();
            var reader = factory.GetFileReaderInstance("CSV");
            var manager = factory.GetDataManagerInstance();
            string fileNameAndLocation = "C:\\files\\LP_210095893_20150901T011608049";
           
            var dataList = reader.ReadFileContent(fileNameAndLocation, factory.GetFileReaderDataManagerInstance());
            var minValue = manager.GetMedianValue(dataList);
            var minValueList = manager.FindBelowGivenValue(dataList, minValue, 20);
            var maxValueList = manager.FindAboveGivenValue(dataList, minValue, 20);
            var bothValueList = manager.FindAboveAndBelowGivenValue(dataList, minValue, 20);
            var invalidDataList = manager.FindInvalidData(dataList);
        }
        
    }
}
