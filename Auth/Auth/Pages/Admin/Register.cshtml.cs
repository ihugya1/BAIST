using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Pages.Admin
{
    public class RegisterModel : PageModel
    {

        int count = 1;
        [BindProperty]
        public string Message { get; set; }
        [BindProperty, Required]
        public string UserName { get; set; }
        [BindProperty, Required]
        public string Email { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }
        [BindProperty, Required]
        public string Role { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {

            string saltHash;
            bool check;


            saltHash = CalculateHash(Password);
            Console.WriteLine(saltHash);
            check = CheckMatch(Password, saltHash);
            Console.WriteLine(check);
            Message = saltHash;


            string user = "ihugya1";
            string password = "SimpCord101";
            bool confirmation = true;
            string email = Email;


            SqlConnection BAIS3150 = new SqlConnection(); //instantiation + declararation
            BAIS3150.ConnectionString = @$"Persist Security Info=False;Database={user};User ID={user};Password={password};server=dev1.baist.ca;";
            BAIS3150.Open();
            SqlCommand InsertUserCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddUser"
            };
            SqlParameter UserIdParameter = new SqlParameter
            {
                ParameterName = "@UserID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = 5
            };
            InsertUserCommand.Parameters.Add(UserIdParameter);
            SqlParameter HoursParameter = new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = UserName
            };
            InsertUserCommand.Parameters.Add(HoursParameter);
            SqlParameter EmailParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = email
            };
            InsertUserCommand.Parameters.Add(EmailParameter);
            SqlParameter PasswordParameter = new SqlParameter
            {
                ParameterName = "@Password",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = saltHash
            };
            InsertUserCommand.Parameters.Add(PasswordParameter);
            SqlParameter RoleParamter = new SqlParameter
            {
                ParameterName = "@Role",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Role
            };

            InsertUserCommand.Parameters.Add(RoleParamter);
            SqlParameter CreatedParameter = new SqlParameter
            {
                ParameterName = "@Created",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = DateTime.Now
            };
            InsertUserCommand.Parameters.Add(CreatedParameter);
            Message = $"{DateTime.Now} {Role} {UserName} {Email} {UserName}";
            try
            {
                InsertUserCommand.ExecuteNonQuery();//not getting a result back 
                                                    // Message="Insert Course Sucessful";
            }
            catch (Exception e)
            {
                //  Message=$"Failure: {e}";
                confirmation = false;

            }
            BAIS3150.Close();
            count++;
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
    }
}

