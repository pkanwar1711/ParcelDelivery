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
        private readonly IParcelValidatorLogic _parcelValidatorLogic;

        public RegularDepartment()
        {
            _parcelValidatorLogic = new ParcelValidatorLogic();

            WeightMin = 1;
            WeightMax = 10;
            Value = 0;
            Name = "Regular";
        }

        public ParcelStatus Handle(Parcel parcel)
        {
            _parcelValidatorLogic.ValidateParcel(parcel);
            _parcelValidatorLogic.ValidateParcelUser(parcel.Recipient);
            _parcelValidatorLogic.ValidateParcelUser(parcel.Sender);
            return new ParcelStatus
            {
                Parcel = parcel,
                Department = Name
            };
        }
    }
}
