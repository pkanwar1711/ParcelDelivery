﻿using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using System;

namespace ParcelDelivery.Logic.Implementation
{
    public class MailDepartment : IDepartments
    {
        public double WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public MailDepartment()
        {
            WeightMin = 0;
            WeightMax = 1;
            Value = 0;
            Name = "Mail";
        }

        public void Handle(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
