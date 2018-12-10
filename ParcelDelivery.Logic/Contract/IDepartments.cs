using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IDepartments
    {
        decimal WeightLimit { get; set; }
        string Name { get; set; }
        void Handle(Parcel parcel);
    }
}