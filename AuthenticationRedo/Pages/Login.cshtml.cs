using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AuthenticationRedo.BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AuthenticationRedo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set;}
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            string uiEmail = Email;
            string uiPassword = Password;
            UCSUser ucsuser = new UCSUser();
            string user = "ihugya1";
            string password = "SimpCord101";
            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand ASampleCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetUser",
            };
            SqlParameter ASampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = uiEmail
            };
            ASampleCommand.Parameters.Add(ASampleCommandParameter);
            SqlDataReader ASampleDataReader;
            ASampleDataReader = ASampleCommand.ExecuteReader();
            if (ASampleDataReader.HasRows)
            {
                Console.WriteLine("Columns:");
                Console.WriteLine("--------");
                for (int index = 0; index < ASampleDataReader.FieldCount; index++)
                {
                    Console.WriteLine(ASampleDataReader.GetName(index));
                }
                Console.WriteLine("Values:");
                Console.WriteLine("-------");
                while (ASampleDataReader.Read())// no value no read (returns true until no rows left to return)
                {
                    for (int i = 0; i < ASampleDataReader.FieldCount; i++)
                    {
                       // Console.WriteLine(ASampleDataReader.GetValue(i));
                        ucsuser.Email = uiEmail;
                        ucsuser.UserName = ASampleDataReader.GetValue("UserName").ToString();
                        ucsuser.HashPass = ASampleDataReader.GetValue("HashPass").ToString();
                        ucsuser.SaltPass = ASampleDataReader.GetValue("SaltPass").ToString();
                        ucsuser.Role = ASampleDataReader.GetValue("Role").ToString();
                        ucsuser.Created = DateTime.Parse(ASampleDataReader.GetValue("Created").ToString());
                    }
                }
                BAIS3150.Close();
            }
            BAIS3150.Close();

            // Convert a C# string to a byte array  
       //     byte[] bytes = Encoding.ASCII.GetBytes(ucsuser.HashPass);
      //      foreach (byte b in bytes)
      //      {
      //          Console.WriteLine(b);
      //      }

            Message = $"${ucsuser.Role}{ucsuser.Email} {ucsuser.HashPass} :";
            Console.WriteLine();

            // Convert a C# string to a byte array  

            if (Email==ucsuser.Email)
            {
                if (CheckMatch(ucsuser.HashPass,uiPassword))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, ucsuser.Email),
                        new Claim(ClaimTypes.Name, ucsuser.UserName)
                       
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, ucsuser.Role));
                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {

                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Admin/Index");
                }
            }
          //  Message = "Invalid Attempt";
            return Page();
        }
        public static byte[] GetHash(string password, string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        public static bool CompareHash(string attemptedPassword, byte[] hash, string salt)
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword, salt));

            return base64Hash == base64AttemptedHash;
        }
        public bool CheckMatch(string hash, string input)
        {
            try
            {
                var parts = hash.Split(':');

                var salt = Convert.FromBase64String(parts[0]);

                var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

                return parts[1].Equals(Convert.ToBase64String(bytes));
            }
            catch
            {
                return false;
            }
        }
        public string CalculateHash(string input)
        {
            var salt = GenerateSalt(16);

            var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

            return $"{ Convert.ToBase64String(salt) }:{ Convert.ToBase64String(bytes) }";
        }
        public static byte[] GenerateSalt(int length)
        {
            var salt = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
        }
    }
}
