using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Logic.Contract;
using ParcelDelivery.Logic.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
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
            Console.WriteLine($"Parcel status:\n");

            foreach (var parcel in container.Parcels)
            {
                var department = departmentsProvider.Departments(parcel);
                var parcelStatus = department.Handle(parcel);
                Console.WriteLine($"Sender: {parcel.Sender.Name}, Receipient: {parcel.Receipient.Name}");
                Console.WriteLine(
                    $"{parcelStatus.Parcel.Weight} Kg., {parcelStatus.Parcel.Value}$ is deliver to {parcelStatus.Department}");
                Console.WriteLine($"========================================================================================");
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

            using (TextReader textReader = new StringReader(doc.OuterXml))
            {
                using (XmlTextReader reader = new XmlTextReader(textReader))
                {
                    reader.Namespaces = false;
                    XmlSerializer serializer = new XmlSerializer(typeof(Container));
                    return (Container) serializer.Deserialize(reader);
                }
            }
        }
    }
}