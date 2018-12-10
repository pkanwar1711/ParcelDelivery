namespace ParcelDelivery.Dto
{
    public class Parcel
    {
        public Parcel()
        {
            Sender = new User("sender");
            Recipient = new User("Recipient");
        }

        public User Sender { get; set; }

        public User Recipient { get; set; }

        public decimal Weight { get; set; }

        public decimal Value { get; set; }
    }
}