using Common.Module.Interface;
using FileReader.Module.Interface;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace FileReader.Module.Provider
{
    public class CSVFileReaderManager<T> : IFileReader<T>
    {
        const string fileExt = ".csv";

        public IList<T> ReadFileContent(string pathLocation, IFileReaderDataManager<T> converter)
        {
            return this.ReadCSVFile(pathLocation + fileExt, converter);
        }

        private IList<T> ReadCSVFile(string pathLocation, IFileReaderDataManager<T> converter)
        {
            IList<T> dataList;
            using (CsvReader csv =
                  new CsvReader(new StreamReader(pathLocation), true))
            {
                dataList = converter.GenerateData(csv);
            }

            return dataList;
        }
       
    }
}
