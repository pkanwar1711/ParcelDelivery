using ParcelDelivery.Common;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;
using System.Linq;

namespace ParcelDelivery.Logic.Implementation
{
    public class DepartmentsProvider
    {
        public IDepartments Departments(Parcel parcel)
        {
            var departments = ObjectProvider.GetAllTypesOf<IDepartments>();
            if (!departments.Any())
            {
                throw new Exception("Department not found");
            }

            var selectedDepartment =
                departments.FirstOrDefault(d => d.WeightLimit <= parcel.Weight && d.Value <= parcel.Value);
            if (selectedDepartment == null)
            {
                throw new Exception("Department not found");
            }
            return selectedDepartment;
        }
    }
}