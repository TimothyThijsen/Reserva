namespace DomainLayer
{
    public abstract class User
    {
        int id;
        string firstName, lastName, email;
        string? password;
        DateOnly dateOfBirth;

        public int Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string? Password { get { return password; } set { password = value; } }
        public DateOnly DateOfBirth { get { return dateOfBirth; } }
        public int Age { get { return DateTime.Today.Year - dateOfBirth.Year; } }
        public User(string firstName, string lastName, string email, DateOnly dateOfBirth, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.password = password;
        }
        public User(int id, string firstName, string lastName, string email, DateOnly dateOfBirth, string password) : this(firstName, lastName, email, dateOfBirth, password)
        {
            this.id = id;
        }
    }
}
