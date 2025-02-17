using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
namespace InsecureBankNet.Controllers
{
    public class LoginController : Controller
    {
        private readonly string connectionString = "YourConnectionStringHere";
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection)
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return View("LoginSuccess");
                }
                else
                {
                    return View("LoginFailure");
                }
            }
        }
    }
}
