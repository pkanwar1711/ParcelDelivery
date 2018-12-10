using System;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using ParcelDelivery.Logic.Implementation;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class DepartmentProviderLogicTest
    {
        private readonly DepartmentsProvider _departmentsProvider;
        
        public DepartmentProviderLogicTest()
        {
            _departmentsProvider= new DepartmentsProvider();
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldThrowExceptionIsDepartmentNotFound()
        {
            var parcel = new Parcel();
            Assert.Throws<Exception>(() => _departmentsProvider.Departments(parcel));
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnMailDepartmentObjectIfWeightUp1Kg()
        {
            var parcel = new Parcel();
            var department = _departmentsProvider.Departments(parcel);
            Assert.Same(typeof(MailDepartment), department);
        }


        private void RegisterService()
        {

        }
    }
}
