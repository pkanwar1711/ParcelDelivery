using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class InsuranceDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public InsuranceDepartment()
        {
            WeightMin = null;
            WeightMax = null;
            Value = 2000;
            Name = "Insurance";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
