using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.model
{
    public class Materials
    {
        public int id { get; set; }
        public string buildingType { get; set; }
        public string materialsAmount { get; set; }
        public string typeOfMaterial { get; set; }
        public int contractId { get; set; }

        public Materials(int id, string buildingType, string materialsAmount, string typeOfMaterial, int contractId)
        {
            this.id = id;
            this.buildingType = buildingType;
            this.materialsAmount = materialsAmount;
            this.typeOfMaterial = typeOfMaterial;
            this.contractId = contractId;
        }

        public Materials(string buildingType, string materialsAmount, string typeOfMaterial, int contractId)
        {
            this.buildingType = buildingType;
            this.materialsAmount = materialsAmount;
            this.typeOfMaterial = typeOfMaterial;
            this.contractId = contractId;
        }
    }
}
