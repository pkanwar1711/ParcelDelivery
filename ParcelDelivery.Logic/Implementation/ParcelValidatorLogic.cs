using System;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;

namespace ParcelDelivery.Logic.Implementation
{
    public class ParcelValidatorLogic : IParcelValidatorLogic
    {
        public void ValidateParcel(Parcel parcel)
        {
            if (parcel == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void ValidateParcelUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"Invalid request");
            }

            if (user.Name == null)
            {
                throw new Exception("Invalid  name");
            }

            if (user.Address == null)
            {
                throw new Exception("Invalid address ");
            }

            if (user.Address.City == null)
            {
                throw new Exception("Invalid  city");
            }

            if (user.Address.HouseNumber == null)
            {
                throw new Exception("Invalid  HouseNumber");
            }

            if (user.Address.PostalCode == null)
            {
                throw new Exception("Invalid  PostalCode");
            }

            if (user.Address.Street == null)
            {
                throw new Exception("Invalid  Street");
            }
        }
    }
}