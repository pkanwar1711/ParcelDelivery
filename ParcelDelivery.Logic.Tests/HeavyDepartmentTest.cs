using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Implementation;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class HeavyDepartmentTest
    {
        private readonly HeavyDepartment _mailDepartment;

        public HeavyDepartmentTest()
        {
            _mailDepartment = new HeavyDepartment();
        }

        [Fact]
        public void HeavyDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameHeavy()
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
                Weight = 12
            };

            var parcelStatus = _mailDepartment.Handle(parcel);
            Assert.Equal("Heavy", parcelStatus.Department);
        }
    }
}