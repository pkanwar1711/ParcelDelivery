using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Implementation;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class InsuranceDepartmentTest
    {
        private readonly InsuranceDepartment _mailDepartment;

        public InsuranceDepartmentTest()
        {
            _mailDepartment = new InsuranceDepartment();
        }

        [Fact]
        public void InsuranceDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameInsurance()
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
                Weight = 12,
                Value = 9000
            };

            var parcelStatus = _mailDepartment.Handle(parcel);
            Assert.Equal("Insurance", parcelStatus.Department);
        }
    }
}