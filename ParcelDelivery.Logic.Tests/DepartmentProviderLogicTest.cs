using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Implementation;
using System;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class DepartmentProviderLogicTest
    {
        private readonly DepartmentsProvider _departmentsProvider;

        public DepartmentProviderLogicTest()
        {
            _departmentsProvider = new DepartmentsProvider();
        }


        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnMailDepartmentObjectIfWeightUp1Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 0.5;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<MailDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnRegularDepartmentObjectIfWeightUpTo10Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 5;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<RegularDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfWeightMoreThen10Kg()
        {
            var parcel = new Parcel
            {
                Recipient = new User("Recipient")
                {
                    Name = "R. Recipient",
                    Address = new Address
                    {
                        City = "New Delhi",
                        HouseNumber = "#3",
                        PostalCode = "IN0090",
                        Street = "20"
                    }
                },
                Sender = new User("Sender")
                {
                    Name = "S. serder",
                    Address = new Address
                    {
                        City = "gurgaon",
                        HouseNumber = "388",
                        PostalCode = "IN007",
                        Street = "6"
                    }
                },
            };
            parcel.Weight = 11;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfWeightIs20Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 20;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfValueIs2000()
        {
            var parcel = new Parcel()
            {
                Recipient = new User("Recipient")
                {
                    Name = "R. Recipient",
                    Address = new Address
                    {
                        City = "New Delhi",
                        HouseNumber = "#3",
                        PostalCode = "IN0090",
                        Street = "20"
                    }
                },
                Sender = new User("Sender")
                {
                    Name = "S. serder",
                    Address = new Address
                    {
                        City = "gurgaon",
                        HouseNumber = "388",
                        PostalCode = "IN007",
                        Street = "6"
                    }
                },
            };
            parcel.Weight = 20;
            parcel.Value = 2000;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }
    }
}