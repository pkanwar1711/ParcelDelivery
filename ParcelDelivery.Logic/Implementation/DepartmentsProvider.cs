using ParcelDelivery.Common;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;
using System.Linq;

namespace ParcelDelivery.Logic.Implementation
{
    public class DepartmentsProvider: IDepartmentsProvider
    {
        public IDepartments Departments(Parcel parcel)
        {
            IDepartments selectedDepartment = null;

            var departments = ObjectProvider.GetAllTypesOf<IDepartments>().ToList();

            if (!departments.Any())
            {
                throw new Exception("Department not found");
            }

            foreach (var department in departments)
            {
                if (parcel.Weight > department.WeightMin && parcel.Weight < department.WeightMax)
                {
                    selectedDepartment = department;
                    break;
                }


                if (parcel.Weight > department.WeightMin && department.WeightMax ==null)
                {
                    selectedDepartment = department;
                    break;
                }

                if (parcel.Value > department.Value && department.WeightMax ==null && department.WeightMin == null)
                {
                    selectedDepartment = department;
                    break;
                }
            }

            if (selectedDepartment == null)
            {
                throw new Exception("Department not found");
            }

            return selectedDepartment;
        }
    }
}