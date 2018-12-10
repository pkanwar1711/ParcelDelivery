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

        public double Weight { get; set; }

        public double Value { get; set; }
    }
}