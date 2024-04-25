
using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class MemberUT
    {
        private MemberManager _memberManager;
        private readonly Bogus.Faker faker = new Bogus.Faker("uk");
        [TestInitialize]
        public void Setup()
        {
            _memberManager = new MemberManager(new MockUserDAL());
        }

        [TestMethod]
        public void AddMember()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, faker.Person.Email.ToLower(), 22, MemberType.free_account, "password");
            _memberManager.AddMember(member);

            Member member2 = _memberManager.GetMember(1);
            Assert.IsTrue(member2.Email == member.Email);
            Assert.AreEqual(1, _memberManager.GetAllMembers().Count);
        }

        [TestMethod]
        public void AddMember_IncompleteMemberModel()
        {
            MemberModel member = new MemberModel();
            member.Email = faker.Person.Email;

            Assert.ThrowsException<ValidationException>(() => _memberManager.AddMember(member));
        }

        [TestMethod]
        public void AddMember_DuplicateEmail()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, "same@email.com", 22, MemberType.free_account, "password");
            _memberManager.AddMember(member);

            MemberModel duplicateMember = new MemberModel(2, faker.Person.FirstName, faker.Person.LastName, "same@email.com", 22, MemberType.free_account, "password");

            List<Member> members = _memberManager.GetAllMembers();
            Assert.AreEqual(1, members.Count);
            Assert.ThrowsException<ValidationException>(() => _memberManager.AddMember(member));
        }

        [TestMethod]
        public void RemoveMember()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, faker.Person.Email, 22, MemberType.free_account, "password");
            _memberManager.AddMember(member);

            Assert.AreEqual(1, _memberManager.GetAllMembers().Count);
            _memberManager.RemoveMember(1);

            Assert.AreEqual(0, _memberManager.GetAllMembers().Count);
        }

        [TestMethod]
        public void GetMember()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, "fake@mail.com", 22, MemberType.free_account, "password");
            _memberManager.AddMember(member);
            Member retrievedMember = _memberManager.GetMember(1);

            Assert.IsNotNull(retrievedMember);
            Assert.AreEqual(1, retrievedMember.Id);
            Assert.AreEqual("fake@mail.com", retrievedMember.Email);
        }

        [TestMethod]
        public void Login_ValidCredentials()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, "fake@mail.com", 22, MemberType.free_account, "password123");
            _memberManager.AddMember(member);
            Member loggedInMember = _memberManager.Login("fake@mail.com", "password123");

            Assert.IsNotNull(loggedInMember);
            Assert.AreEqual(member.Email, loggedInMember.Email);
        }

        [TestMethod]
        
        public void Login_IncorrectPassword()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, "fake@mail.com", 22, MemberType.free_account, "password123");
            _memberManager.AddMember(member);
            
            Assert.ThrowsException<CredentialException>(() => _memberManager.Login("fake@mail.com", "wrongpassword"));
        }

        [TestMethod]
        public void Login_NonExistingEmail()
        {
            MemberModel member = new MemberModel(1, faker.Person.FirstName, faker.Person.LastName, "fake@mail.com", 22, MemberType.free_account, "password123");
            _memberManager.AddMember(member);

            Assert.ThrowsException<CredentialException>(() => _memberManager.Login("nonexisting@example.com", "password123"));
        }

    }
}
