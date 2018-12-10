using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class MailDepartment : IDepartments
    {
        public decimal WeightLimit { get; set; }
        public string Name { get; set; }

        public MailDepartment()
        {
            WeightLimit = 1;
            Name = "Mail";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
