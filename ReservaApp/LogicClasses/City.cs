namespace DomainLayer
{
    public class City
    {
        private int id;
        private string name;

        public int Id { get { return id; } }
        public string Name { get { return char.ToUpper(name[0]) + name.Substring(1); } }
        public City(string name)
        {
            this.name = name;
        }
        public City(int id, string name) : this(name)
        {
            this.id = id;
        }
    }
}
