using System;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Implementation;
using Xunit;

namespace ParcelDelivery.Logic.Tests
{
    public class ParcelValidatorLogicTest
    {
        private readonly ParcelValidatorLogic _ParcelValidatorLogic;

        public ParcelValidatorLogicTest()
        {
            _ParcelValidatorLogic = new ParcelValidatorLogic();
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcel_ShouldThrowExceptionIfParcelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _ParcelValidatorLogic.ValidateParcel(null));
        }


        [Fact]
        public void ParcelValidatorLogic_ValidateParcelRecipient_ShouldThrowExceptionIfParcelRecipientIsNull()
        {
            var parcel = new Parcel();
            parcel.Receipient = null;
            Assert.Throws<ArgumentNullException>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Receipient));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelRecipient_ShouldThrowExceptionIfParcelRecipientNameIsNull()
        {
            var parcel = new Parcel();
            parcel.Receipient.Name = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Receipient));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelRecipient_ShouldThrowExceptionIfParcelRecipientAddressIsNull()
        {
            var parcel = new Parcel();
            parcel.Receipient.Address = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Receipient));
        }

        [Fact]
        public void
            ParcelValidatorLogic_ValidateParcelRecipient_ShouldThrowExceptionIfParcelRecipientAddressHouseNumberIsNull()
        {
            var parcel = new Parcel();
            parcel.Receipient.Name = "Name";
            parcel.Receipient.Address.City = "City";
            parcel.Receipient.Address.HouseNumber = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Receipient));
        }

        [Fact]
        public void
            ParcelValidatorLogic_ValidateParcelRecipient_ShouldThrowExceptionIfParcelRecipientAddressCityIsNull()
        {
            var parcel = new Parcel();
            parcel.Receipient.Address.City = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Receipient));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelSender_ShouldThrowExceptionIfParcelSenderIsNull()
        {
            var parcel = new Parcel();
            parcel.Sender = null;
            Assert.Throws<ArgumentNullException>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Sender));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelSender_ShouldThrowExceptionIfParcelSenderNameIsNull()
        {
            var parcel = new Parcel();
            parcel.Sender.Name = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Sender));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelSender_ShouldThrowExceptionIfParcelRecipientSenderIsNull()
        {
            var parcel = new Parcel();
            parcel.Sender.Address = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Sender));
        }

        [Fact]
        public void
            ParcelValidatorLogic_ValidateParcelSender_ShouldThrowExceptionIfParcelSenderAddressHouseNumberIsNull()
        {
            var parcel = new Parcel();
            parcel.Sender.Address.HouseNumber = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Sender));
        }

        [Fact]
        public void ParcelValidatorLogic_ValidateParcelSender_ShouldThrowExceptionIfParcelSenderAddressCityIsNull()
        {
            var parcel = new Parcel();
            parcel.Sender.Address.City = null;
            Assert.Throws<Exception>(() => _ParcelValidatorLogic.ValidateParcelUser(parcel.Sender));
        }
    }
}