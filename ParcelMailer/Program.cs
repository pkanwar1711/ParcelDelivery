using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Logic.Contract;
using ParcelDelivery.Logic.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using ParcelDelivery.Dto;

namespace ParcelMailer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDepartmentsProvider, DepartmentsProvider>()
                .BuildServiceProvider();

           
            var departmentsProvider = serviceProvider.GetService<IDepartmentsProvider>();
            var container = ReadData();

            if (!container.Parcels.Any())
            {
                Console.WriteLine("No Parcel found");
                Console.Read();
                return;
            }

            foreach (var parcel in container.Parcels)
            {
                var department = departmentsProvider.Departments(parcel);
                var parcelStatus = department.Handle(parcel);
                Console.WriteLine($"Parcel status");
                Console.WriteLine(
                    $"{parcelStatus.Parcel.Weight},{parcelStatus.Parcel.Value} is deliver to {parcelStatus.Department}");
            }

            Console.Read();
        }

        static Container ReadData()
        {
            var path = System.IO.Path.GetFullPath($"Data/Container_68465468.xml");
            if (!File.Exists(path))
            {
                throw new Exception("File not found");
            }

            var doc = new XmlDocument();
            doc.Load(path);
            var container = new Container();
            container.Id = Convert.ToInt64(doc.GetElementsByTagName("Id").Item(0)?.InnerText);
            container.ShippingDate = Convert.ToDateTime(doc.GetElementsByTagName("ShippingDate").Item(0)?.InnerText);
            var parcels = doc.GetElementsByTagName("Parcel");
            return container;
        }
    }
}