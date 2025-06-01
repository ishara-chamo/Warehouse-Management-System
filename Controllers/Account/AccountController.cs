using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=Warehouse;Trusted_Connection=True;";

        // **Register User**
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = HashPassword(model.Password);

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO Users (UserName, Email, PasswordHash, Role) VALUES (@UserName, @Email, @PasswordHash, 'User')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", model.Username); // Fixed: Changed to FullName
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // **Login User**
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT UserId, UserName, Role, PasswordHash FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();
                                if (VerifyPassword(model.Password, storedHash))
                                {
                                    // Store user session
                                    HttpContext.Session.SetString("UserId", reader["UserId"].ToString());
                                    HttpContext.Session.SetString("UserName", reader["UserName"].ToString());
                                    HttpContext.Session.SetString("Role", reader["Role"].ToString());

                                    TempData["Message"] = "Login successful!";
                                    return RedirectToAction("Index", "Home");
                                }
                            }
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {
        //            await conn.OpenAsync();
        //            string query = "SELECT UserId, UserName, Role, PasswordHash FROM Users WHERE Email = @Email";
        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@Email", model.Email);
        //                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        string storedHash = reader["PasswordHash"].ToString();
        //                        if (VerifyPassword(model.Password, storedHash))
        //                        {
        //                            TempData["Message"] = "Login successful!";
        //                            return RedirectToAction("Index", "Home");
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        ModelState.AddModelError("", "Invalid login attempt.");
        //    }
        //    return View(model);
        //}

        // **Password Hashing**
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return HashPassword(inputPassword) == storedHash;
        }

        // **Logout**
        public IActionResult Logout()
        {
            TempData["Message"] = "Logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}
