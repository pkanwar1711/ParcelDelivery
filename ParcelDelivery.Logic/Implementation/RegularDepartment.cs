using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class RegularDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public RegularDepartment()
        {
            WeightMin = 1;
            WeightMax = 10;
            Value = 0;
            Name = "Regular";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
