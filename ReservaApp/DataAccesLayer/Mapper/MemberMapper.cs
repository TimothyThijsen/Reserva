using DomainLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapper
{
    public class MemberMapper
    {
        public static Member GetMember(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string[] name = reader.GetString(1).Split(' ');
            string firstName = name[0];
            string lastName = name[1];
            string email = reader.GetString(2);
            int age = reader.GetInt32(3);
            MemberType role = (MemberType)reader.GetInt32(4);
            //int points = reader.GetInt32(5);
            bool verified = reader.GetBoolean(6);

            return new Member(id,firstName,lastName,email,age,role,verified);
        }

        public static List<User> GetMembers(SqlDataReader reader)
        {
            List<User> members = new List<User>();
            while (reader.Read())
            {
                members.Add(GetMember(reader));
            }
            return members;
        }
    }
}
