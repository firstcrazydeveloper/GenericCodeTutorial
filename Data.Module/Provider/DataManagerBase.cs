using Caculation.Module.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Module.Provider
{
    public abstract class DataManagerBase<T>
    {
        protected ICalculation calculationManager;
        protected const string MeterPointCode = "MeterPoint Code";
        protected const string SerialNumber = "Serial Number";
        protected const string PlantCode = "Plant Code";
        protected const string Date = "Date";
        protected const string DataType = "Data Type";
        protected const string Status = "Status";
    }
}
