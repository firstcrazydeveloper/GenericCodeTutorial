using Common.Module.Model;
using System;
using System.Collections.Generic;

namespace Common.Module.Models
{
    public class TOUDataModel : DataModelBase
    {
        public double? Energy { get; set; }
        public double? MaximumDemad { get; set; }
        public DateTime? TimeOfMaxDemand { get; set; }
        public string Unit { get; set; }
        public string Period { get; set; }
        public int BillingResetCount { get; set; }
        public DateTime? BillingResetCountDateTime { get; set; }
        public string Rate { get; set; }
        public string DlsActive { get; set; }        
        public TOUDataModel()
        {
            this.IsValidData = true;
            this.InvalidDataList = new Dictionary<string, string>();
        }
    }
}
