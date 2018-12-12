using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;
using ParcelDelivery.Logic.Implementation;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ParcelMailer
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartmentsProvider, DepartmentsProvider>()
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
                Console.WriteLine($"========================================================================================\n");
            }

            Console.Read();
        }

        static Container ReadData()
        {
            var path = Path.GetFullPath($"Data/Container_68465468.xml");
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