﻿using DomainLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Mapper
{
    public class MemberMapper
    {
        public static Member GetMember(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string[] name = Convert.ToString(reader["name"])!.Split(' ');
            string firstName = name[0];
            string lastName = name[1];
            string email = Convert.ToString(reader["email"])!;
            DateOnly dateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(reader["dateOfBirth"]));
            MemberType role = (MemberType)Convert.ToInt32(reader["role"]);
            int points = Convert.ToInt32(reader["points"]);
            bool verified = Convert.ToBoolean(reader["verified"]);
            string password = Convert.ToString(reader["password"]);
            return new Member(id, firstName, lastName, email, dateOfBirth, role, verified, password);
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
