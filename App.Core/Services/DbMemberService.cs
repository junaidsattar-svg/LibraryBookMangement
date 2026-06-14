using System.Collections.Generic;
using System.Data.SqlClient;
using App.Core.Models;
using App.Core.Interfaces;

namespace App.Core.Services
{
    public class DbMemberService : IMemberService
    {
        private readonly string _connectionString;

        public DbMemberService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Member> GetAllMembers()
        {
            var list = new List<Member>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Members", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Member
                        {
                            MemberId = (int)reader["MemberId"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            MemberStatus = reader["MemberStatus"].ToString(),
                            JoinDate = System.Convert.ToDateTime(reader["JoinDate"]),
                            ExpiryDate = System.Convert.ToDateTime(reader["ExpiryDate"])
                        });
                    }
                }
            }
            return list;
        }

        public Member GetMemberById(int memberId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Members WHERE MemberId = @id", con);
                cmd.Parameters.AddWithValue("@id", memberId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Member
                        {
                            MemberId = (int)reader["MemberId"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            MemberStatus = reader["MemberStatus"].ToString(),
                            JoinDate = System.Convert.ToDateTime(reader["JoinDate"]),
                            ExpiryDate = System.Convert.ToDateTime(reader["ExpiryDate"])
                        };
                    }
                }
            }
            return null;
        }

        public void AddMember(Member member)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"INSERT INTO Members 
                    (FullName, Email, Phone, Address, MemberStatus, JoinDate, ExpiryDate)
                    VALUES (@name, @email, @phone, @address, @status, @join, @expiry)", con);
                cmd.Parameters.AddWithValue("@name", member.FullName);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@phone", member.Phone);
                cmd.Parameters.AddWithValue("@address", member.Address);
                cmd.Parameters.AddWithValue("@status", member.MemberStatus);
                cmd.Parameters.AddWithValue("@join", member.JoinDate);
                cmd.Parameters.AddWithValue("@expiry", member.ExpiryDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMember(Member member)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"UPDATE Members SET 
                    FullName=@name, Email=@email, Phone=@phone, Address=@address,
                    MemberStatus=@status, JoinDate=@join, ExpiryDate=@expiry
                    WHERE MemberId=@id", con);
                cmd.Parameters.AddWithValue("@name", member.FullName);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@phone", member.Phone);
                cmd.Parameters.AddWithValue("@address", member.Address);
                cmd.Parameters.AddWithValue("@status", member.MemberStatus);
                cmd.Parameters.AddWithValue("@join", member.JoinDate);
                cmd.Parameters.AddWithValue("@expiry", member.ExpiryDate);
                cmd.Parameters.AddWithValue("@id", member.MemberId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMember(int memberId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Members WHERE MemberId = @id", con);
                cmd.Parameters.AddWithValue("@id", memberId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Member> SearchMembers(string keyword)
        {
            var list = new List<Member>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Members WHERE FullName LIKE @kw OR Email LIKE @kw", con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Member
                        {
                            MemberId = (int)reader["MemberId"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            MemberStatus = reader["MemberStatus"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}