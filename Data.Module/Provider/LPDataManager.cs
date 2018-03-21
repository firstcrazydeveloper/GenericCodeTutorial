using System;
using System.Collections.Generic;
using System.Linq;
using LumenWorks.Framework.IO.Csv;
using Caculation.Module.Provider;
using Caculation.Module.Interface;
using Common.Module.Interface;
using Common.Module.Models;

namespace Data.Module.Provider
{
    public class LPDataManager<T> : DataManagerBase<T>, IDataManager<T>, IFileReaderDataManager<T> where T : LPDatModel
    {
        const string DataValue = "Data Value";

        public LPDataManager()
        {
            this.calculationManager = new CalculationManager();
        }
        public IList<T> GenerateData(CsvReader csv)
        {
            List<T> fieldValue = new List<T>();
            LPDatModel dataModel;
            string[] headers = csv.GetFieldHeaders();
            int fieldCount = csv.FieldCount;
            while (csv.ReadNextRecord())
            {
                dataModel = new LPDatModel();
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
                        case DataValue:
                            double tempValue = 0;
                            if (double.TryParse(csv[i], out tempValue))
                            {
                                dataModel.DataValue = tempValue;
                            }
                            else
                            {
                                dataModel.IsValidData = false;
                                dataModel.InvalidDataList.Add(DataValue, csv[i]);
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
            var resultList = dataList.Where(d => d.IsValidData == true).Select(m => m.DataValue).ToList();
            if (resultList.Count == 0)
                throw new ArgumentNullException();
            return this.calculationManager.CaculateMedianValue(resultList);

        }

        public IList<T> FindAboveGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.IsValidData == true && d.DataValue > percentageVal).ToList();
            return resultList;
        }

        public IList<T> FindBelowGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.IsValidData == true && d.DataValue < percentageVal).ToList();
            return resultList;
        }

        public IList<T> FindAboveAndBelowGivenValue(IList<T> dataList, double minValue, int compareValue)
        {
            double percentageVal = this.calculationManager.FindPercentageValue(minValue, compareValue);
            var resultList = dataList.Where(d => d.IsValidData== true && (d.DataValue < percentageVal || d.DataValue > percentageVal)).ToList();
            return resultList;
        }

        public IList<T> FindInvalidData(IList<T> dataList)
        {
            var resultList = dataList.Where(d => d.IsValidData == false).ToList();
            return resultList;
        }
    }
}
