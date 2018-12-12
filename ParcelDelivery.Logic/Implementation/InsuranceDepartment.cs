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
        private readonly IParcelValidatorLogic _parcelValidatorLogic;

        public InsuranceDepartment()
        {
            _parcelValidatorLogic = new ParcelValidatorLogic();
            WeightMin = null;
            WeightMax = null;
            Value = 2000;
            Name = "Insurance";
        }

        public ParcelStatus Handle(Parcel parcel)
        {
            _parcelValidatorLogic.ValidateParcel(parcel);
            _parcelValidatorLogic.ValidateParcelUser(parcel.Receipient);
            _parcelValidatorLogic.ValidateParcelUser(parcel.Sender);
            return new ParcelStatus
            {
                Parcel = parcel,
                Department = Name
            };
        }
    }
}
