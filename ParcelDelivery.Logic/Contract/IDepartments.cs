using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IDepartments
    {
        double WeightLimit { get; set; }
        string Name { get; set; }
        double Value { get; set; }

        void Handle(Parcel parcel);
    }
}