using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TemperatureConversion.Test
{
    public class TemperatureConversionUnitTest
    {
        [Theory]
        [InlineData(0, 32)]
        [InlineData(100, 212)]
        [InlineData(-40, -40)]
        public void TestingConverterMethod(double celsius, double expectedFahrenheit)
        {

            //converter
            var result = new ConverterCToF.Convert();

            //var result = converter.Convert(celsius);

            Assert.Equal(expectedFahrenheit, result, 2);
        }
    }
}
