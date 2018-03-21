using Common.Module.Interface;
using Common.Module.Models;
using Data.Module.Helper;
using FileReader.Module.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReader.Module.Test.Provider
{
    [TestClass]
    public class CSVFileReaderManagerTest
    {
        IFactory<LPDatModel> factory;
        IFileReader<LPDatModel> fileReader;
        public CSVFileReaderManagerTest()
        {
            factory= factory = new Factory<LPDatModel>();
            fileReader= factory.GetFileReaderInstance("CSV");
        }

        [TestMethod]
        public void ReaderInstanceShouldBeCreatedTest()
        {
            Assert.AreNotEqual(this.fileReader, null);
        }

        [TestMethod]
        public void ReadFileContentTest()
        {
            var dataList = this.fileReader.ReadFileContent("C:\\files\\LP_210095893_20150901T011608049", factory.GetFileReaderDataManagerInstance());
            Assert.AreEqual(dataList.Count, 384);
        }

        [TestMethod]
        public void ReadFileContentDataTest()
        {
            var dataList = this.fileReader.ReadFileContent("C:\\files\\LP_210095893_20150901T011608049", factory.GetFileReaderDataManagerInstance());
            var data = dataList[0];
            Assert.AreEqual(data.MeterPointCode, "210095893");
            Assert.AreEqual(data.DataValue, 1);
            Assert.AreEqual(data.DataType, "Import Wh Total");
        }
    }
}
