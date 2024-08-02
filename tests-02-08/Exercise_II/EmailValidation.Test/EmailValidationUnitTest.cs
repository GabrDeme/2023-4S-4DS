using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmailValidation.Test
{
    public class EmailValidationUnitTest
    {
        [Theory]

        [InlineData("paulo@souza.com",true)]
        [InlineData("cristiano@com", false)]
        [InlineData("darlan.gmail", false)]
        [InlineData("darlangmail", false)]
        public void TestingEmailBody(string email, bool waitedValue)
        {
            var result = Validator.EmailValidator(email);

            Assert.Equal(waitedValue, result);
        }
    }
}
