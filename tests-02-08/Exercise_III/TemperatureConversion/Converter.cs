using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConversion
{
    public static class ConverterCToF
    {
        public static double Convert(double celsius) 
        {  
            return (celsius * 9/5)+ 32; 
        }
    }
}
