using ParcelDelivery.Dto;

namespace ParcelDelivery.Logic.Contract
{
    public interface IDepartmentsProvider
    {
        IDepartments Departments(Parcel parcel);
    }
}