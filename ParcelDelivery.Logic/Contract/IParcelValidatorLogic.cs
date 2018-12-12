using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IParcelValidatorLogic
    {
        void ValidateParcel(Parcel parcel);
        void ValidateParcelUser(User parcel);
    }
}