using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Member : User
    {
        int? points;
        bool verified;
        MemberType memberType;
        public int? Points { get { return points; } }
        public MemberType MemberType {  get { return memberType; } }
        public bool Verified { get { return verified; } }
        public Member(string firstName, string lastName, string email, int age,MemberType memberType) : base(firstName, lastName, email, age)
        {
            this.memberType = memberType;
            verified = false;
        }
        
        public Member(int id, string firstName, string lastName, string email, int age, MemberType memberType, bool verified) : base(id, firstName, lastName, email, age)
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
