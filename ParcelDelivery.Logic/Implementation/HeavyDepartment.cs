using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class HeavyDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public HeavyDepartment()
        {
            WeightMin = 10;
            WeightMax = null;
            Value = 0;
            Name = "Heavy";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
