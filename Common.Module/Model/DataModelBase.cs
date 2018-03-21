using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Module.Model
{
    public abstract class DataModelBase
    {
        public string MeterPointCode { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime? Date { get; set; }
        public string DataType { get; set; }

        public string Status { get; set; }
        public bool IsValidData { get; set; }
        public IDictionary<string, string> InvalidDataList { get; set; }
    }
}
