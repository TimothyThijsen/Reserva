namespace DomainLayer
{
    public class Address
    {
        private string street, postalcode;
        private int longitude, latitude;

        public string Street { get { return street; } }
        public string PostalCode { get { return postalcode; } }

        public Address(string street, string postalCode)
        {
            this.street = street;
            this.postalcode = postalCode;
        }
        public override string ToString()
        {
            return Street + ", " + PostalCode;
        }
    }
}
