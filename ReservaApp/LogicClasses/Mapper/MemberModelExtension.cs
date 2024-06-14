using Models;

namespace DomainLayer.Mapper
{
    public static class MemberModelExtension
    {
        public static Member ToLogicLayer(this MemberModel memberModel)
        {
            Member member = new Member(memberModel.FirstName, memberModel.LastName, memberModel.Email.ToLower().Trim(), DateOnly.FromDateTime(memberModel.DateOfBirth), memberModel.Role, memberModel.Password);
            return member;
        }
    }
}
