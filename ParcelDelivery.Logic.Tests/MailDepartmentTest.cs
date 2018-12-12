using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Implementation;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class MailDepartmentTest
    {
        private readonly MailDepartment _mailDepartment;

        public MailDepartmentTest()
        {
            _mailDepartment = new MailDepartment();
        }

        [Fact]
        public void MailDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameMail()
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
                Weight = 1
            };

            var parcelStatus = _mailDepartment.Handle(parcel);
            Assert.Equal("Mail", parcelStatus.Department);
        }
    }
}