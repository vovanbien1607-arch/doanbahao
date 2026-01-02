using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL
{
    public class User_DAL
    {
        private readonly string ctrConn =
            @"server=(localdb)\MSSQLLocalDB;Database=QuanLyThuHocPhi;Integrated Security=true";

        public USERS Login(string username, string password)
        {
            using (SqlConnection cn = new SqlConnection(ctrConn))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 USERNAME, FULLNAME, ROLE FROM dbo.USERS WHERE USERNAME=@u AND PASSWORD=@p", cn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    return new USERS
                    {
                        USERNAME = rd["USERNAME"].ToString(),
                        FULLNAME = rd["FULLNAME"] == DBNull.Value ? "" : rd["FULLNAME"].ToString(),
                        ROLE = rd["ROLE"] == DBNull.Value ? "" : rd["ROLE"].ToString()
                    };
                }
            }
        }

        public bool Exists(string username)
        {
            using (SqlConnection cn = new SqlConnection(ctrConn))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.USERS WHERE USERNAME=@u", cn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public void Register(USERS u)
        {
            using (SqlConnection cn = new SqlConnection(ctrConn))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.USERS(USERNAME,PASSWORD,FULLNAME,ROLE) VALUES(@u,@p,@f,@r)", cn))
            {
                cmd.Parameters.AddWithValue("@u", u.USERNAME);
                cmd.Parameters.AddWithValue("@p", u.PASSWORD);
                cmd.Parameters.AddWithValue("@f", string.IsNullOrWhiteSpace(u.FULLNAME) ? (object)DBNull.Value : u.FULLNAME);
                cmd.Parameters.AddWithValue("@r", string.IsNullOrWhiteSpace(u.ROLE) ? (object)DBNull.Value : u.ROLE);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool ChangePassword(string username, string oldPass, string newPass)
        {
            using (SqlConnection cn = new SqlConnection(ctrConn))
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE dbo.USERS
                  SET PASSWORD=@newp
                  WHERE USERNAME=@u AND PASSWORD=@oldp", cn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@oldp", oldPass);
                cmd.Parameters.AddWithValue("@newp", newPass);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
