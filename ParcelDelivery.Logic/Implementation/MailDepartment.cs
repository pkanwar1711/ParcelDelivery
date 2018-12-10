using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class MailDepartment : IDepartments
    {
        public double WeightLimit { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public MailDepartment()
        {
            WeightLimit = 1;
            Value = 0;
            Name = "Mail";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
