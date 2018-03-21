using Common.Module.Interface;
using Common.Module.Models;
using Data.Module.Helper;
using FileReader.Module.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Data.Module.Test.Provider
{
    [TestClass]
    public class LPDataManagerTest
    {
        IFactory<LPDatModel> factory;
        IFileReader<LPDatModel> fileReader;
        IList<LPDatModel> dataList;
        IDataManager<LPDatModel> dataManger;
        const string fileNameAndLocation = "C:\\files\\LP_210095893_20150901T011608049";
        const string fileType = "CSV";

        public LPDataManagerTest()
        {
            factory = factory = new Factory<LPDatModel>();
            fileReader = factory.GetFileReaderInstance(fileType);
            this.dataManger = factory.GetDataManagerInstance();
            this.dataList = this.fileReader.ReadFileContent(fileNameAndLocation, factory.GetFileReaderDataManagerInstance());
        }

        [TestMethod]
        public void ReaderInstanceShouldBeCreatedTest()
        {

            var minValue = this.dataManger.GetMedianValue(this.dataList);

            Assert.AreEqual(minValue, 26.5);
        }

        [TestMethod]
        public void FindAboveGivenValueTest()
        {
            var minValue = this.dataManger.GetMedianValue(this.dataList);
            var resultList = this.dataManger.FindAboveGivenValue(this.dataList, minValue, 20);
            Assert.AreEqual(minValue, 26.5);
            Assert.AreEqual(resultList.Count, 212);
        }

        [TestMethod]
        public void FindBelowGivenValueTest()
        {
            var minValue = this.dataManger.GetMedianValue(this.dataList);
            var resultList = this.dataManger.FindBelowGivenValue(this.dataList, minValue, 20);
            Assert.AreEqual(minValue, 26.5);
            Assert.AreEqual(resultList.Count, 170);
        }

        [TestMethod]
        public void FindAboveAndBelowGivenValueTest()
        {
            var minValue = this.dataManger.GetMedianValue(this.dataList);
            var resultList = this.dataManger.FindAboveAndBelowGivenValue(this.dataList, minValue, 20);
            Assert.AreEqual(minValue, 26.5);
            Assert.AreEqual(resultList.Count, 382);
        }

        [TestMethod]
        public void FindInvalidDataTest()
        {
            var resultList = this.dataManger.FindInvalidData(this.dataList);
            Assert.AreEqual(resultList.Count, 2);
        }
    }
}
