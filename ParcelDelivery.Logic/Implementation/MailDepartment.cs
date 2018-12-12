using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;

namespace ParcelDelivery.Logic.Implementation
{
    public class MailDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; }
        public double Value { get; set; }

        private readonly IParcelValidatorLogic _parcelValidatorLogic;

        public MailDepartment()
        {
            _parcelValidatorLogic = new ParcelValidatorLogic();
            WeightMin = 0;
            WeightMax = 1;
            Value = 0;
            Name = "Mail";
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