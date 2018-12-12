using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IDepartments
    {
        double? WeightMin { get; set; }
        double? WeightMax { get; set; }
        string Name { get;  }
        double Value { get; set; }

        ParcelStatus Handle(Parcel parcel);
    }
}