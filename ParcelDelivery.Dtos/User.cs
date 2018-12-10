namespace ParcelDelivery.Dto
{
    public class User
    {
        public User(string type)
        {
            Type = type;
            Address= new Address();
        }

        public string Type { get; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}