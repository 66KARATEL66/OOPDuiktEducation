using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task6
    {
        public delegate bool Validator(string smth);

        Validator GetValidator(int minLenght)
        {
            return (smth) => smth.Length >= minLenght;
        }

        public void Example()
        {
            Validator passwordValidator = GetValidator(8);
            Validator loginValidator = GetValidator(3);

            string[] passwordSamples = { "12345678", "1234" };
            string[] loginSamples = { "admin", "lg" };

            TestValidator(passwordValidator, passwordSamples, "Password");
            TestValidator(loginValidator, loginSamples, "Login");
        }

        public void TestValidator(Validator validator, string[] samples, string typeName)
        {
            foreach (string s in samples)
            {
                if (validator(s)) { Console.WriteLine($"{typeName} is correct"); }
                else { Console.WriteLine($"{typeName} is incorrect"); }
            }
        }
    }
}
