using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IDepartments
    {
        double WeightMin { get; set; }
        double? WeightMax { get; set; }
        string Name { get; set; }
        double Value { get; set; }

        void Handle(Parcel parcel);
    }
}