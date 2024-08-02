using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailValidation
{
    public static class Validator
    {
        public static bool EmailValidator(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
