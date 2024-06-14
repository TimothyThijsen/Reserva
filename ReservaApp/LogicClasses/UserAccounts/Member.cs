namespace DomainLayer
{
    public class Member : User
    {
        int? points;
        bool verified;
        MemberType memberType;
        public int? Points { get { return points; } }
        public MemberType MemberType { get { return memberType; } }
        public bool Verified { get { return verified; } }
        public Member(string firstName, string lastName, string email, DateOnly dateOfBirth, MemberType memberType, string password) : base(firstName, lastName, email, dateOfBirth, password)
        {
            this.memberType = memberType;
            verified = false;
        }

        public Member(int id, string firstName, string lastName, string email, DateOnly dateOfBirth, MemberType memberType, bool verified, string password) : base(id, firstName, lastName, email, dateOfBirth, password)
        {
            this.memberType = memberType;
            this.verified = verified;
        }

        public void VerifyAccount()
        {
            verified = true;
        }
    }
}
