using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculation.Test
{
    public class CalculationUnitTest
    {
        //AAA: Act, Arrange, Assert

        [Fact]
        public void TestingAddMethod()
        {
            //Arrange
            var x1 = 4.1;
            var x2 = 5.9;
            var waitedValue = 10;

            //Act
            var add = Calculation.Addition(x1, x2);

            //Assert
            Assert.Equal(waitedValue, add);
        }

        public void TestingMinusMethod() 
        {
            var x1 = 5.8;
            var x2 = 1.2;
            var waitedValue = 4.6;

            var minus = Calculation.Subtraction(x1, x2);

            Assert.Equal(waitedValue, minus);
        }
        public void TestingObelusMethod()
        {
            var x1 = 5;
            var x2 = 5;
            var waitedValue = 25;

            var obelus = Calculation.Multiplication(x1, x2);

            Assert.Equal(waitedValue, obelus);
        }

        public void TestingTimesMethod()
        {
            var x1 = 25;
            var x2 = 5;
            var waitedValue = 5;

            var times = Calculation.Divison(x1, x2);

            Assert.Equal(waitedValue, times);
        }
    }
}
