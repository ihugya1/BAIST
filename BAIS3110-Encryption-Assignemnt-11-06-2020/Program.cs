﻿using System;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.IO;
using Microsoft.AspNetCore.DataProtection;

namespace BAIS3110_Encryption_Assignemnt_11_06_2020
{
    class Program
    {
      

                   static void Main(string[] args)
        {
            // Get the path to %LOCALAPPDATA%\myapp-keys
            var destFolder = Path.Combine(
                System.Environment.GetEnvironmentVariable("LOCALAPPDATA"),
                "myapp-keys");

            // Instantiate the data protection system at this folder
            var dataProtectionProvider = DataProtectionProvider.Create(
                new DirectoryInfo(destFolder));

            var protector = dataProtectionProvider.CreateProtector("Program.No-DI");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();

            // Protect the payload
            var protectedPayload = protector.Protect(input);
            Console.WriteLine($"Protect returned: {protectedPayload}");

            // Unprotect the payload
            var unprotectedPayload = protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }


    }


}

