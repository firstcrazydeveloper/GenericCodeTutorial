using Caculation.Module.Interface;
using Caculation.Module.Provider;
using Common.Module.Interface;
using Common.Module.Models;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Module.Provider
{
    public class TOUDataManager<T> : DataManagerBase<T>, IDataManager<T>, IFileReaderDataManager<T> where T : TOUDataModel
    {
       
        const string Energy = "Energy";
       

        public TOUDataManager()
        {
            this.calculationManager = new CalculationManager();
        }
        public IList<T> GenerateData(CsvReader csv)
        {
            List<T> fieldValue = new List<T>();
            TOUDataModel dataModel;
            string[] headers = csv.GetFieldHeaders();
            int fieldCount = csv.FieldCount;
            while (csv.ReadNextRecord())
            {
                dataModel = new TOUDataModel();
                for (int i = 0; i < fieldCount; i++)
                {
                    switch (headers[i])
                    {
                        case MeterPointCode:
                            dataModel.MeterPointCode = csv[i];
                            break;
                        case SerialNumber:
                            dataModel.SerialNumber = csv[i];
                            break;
                        case PlantCode:
                            dataModel.PlantCode = csv[i];
                            break;
                        case Date:
                            DateTime dt = new DateTime();
                            if (DateTime.TryParse(csv[i], out dt))
                            {
                                dataModel.Date = dt;
                            }
                            break;
                        case DataType:
                            dataModel.DataType = csv[i];
                            break;
                        case Energy:
                            double tempValue = 0;
                            if (double.TryParse(csv[i], out tempValue))
                            {
                                dataModel.Energy = tempValue;
                            }
                            else
                            {
                                dataModel.IsValidData = false;
                                dataModel.InvalidDataList.Add(Energy, csv[i]);
                            }
                            break;
                        case Status:
                            dataModel.Status = csv[i];
                            break;
                    }
                }
                fieldValue.Add((T)dataModel);
            }
            return fieldValue;
        }

        public double GetMedianValue(IList<T> dataList)
        {
            var resultList = dataList.Where(d => d.IsValidData == true).Select(m => m.Energy).ToList();
            if (resultList.Count == 0)
                throw new ArgumentNullException();
            return this.calculationManager.CaculateMedianValue(resultList);

        }

        public IList<T> FindAboveGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.Energy > percentageVal).ToList();
            return resultList;
        }

        public IList<T> FindBelowGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.Energy < percentageVal).ToList();
            return resultList;
        }

        public IList<T> FindAboveAndBelowGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.Energy < percentageVal || d.Energy > percentageVal).ToList();
            return resultList;
        }

        public IList<T> FindInvalidData(IList<T> dataList)
        {
            var resultList = dataList.Where(d => d.IsValidData == false).ToList();
            return resultList;
        }
    }
}
