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
            _departmentsProvider= new DepartmentsProvider();
        }

        

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnMailDepartmentObjectIfWeightUp1Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 0.5;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.Same(typeof(MailDepartment), department);
        }




        private void RegisterService()
        {

        }
    }
}
