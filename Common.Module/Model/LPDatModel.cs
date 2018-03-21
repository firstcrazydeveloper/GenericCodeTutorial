using Common.Module.Model;
using System;
using System.Collections.Generic;

namespace Common.Module.Models
{
    public class LPDatModel : DataModelBase
    {
        
        public double? DataValue { get; set; }       
        public LPDatModel()
        {
            this.IsValidData = true;
            this.InvalidDataList = new Dictionary<string, string>();
        }
    }
}
