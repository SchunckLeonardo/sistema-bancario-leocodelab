using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.client
{
    public class CPF
    {
        public string Value { get; }
        
        public CPF(string value)
        {
            string pattern = @"^\d{11}$";

            if(!Regex.IsMatch(value, pattern))
            {
                throw new Exception("CPF is no valid");
            }

            Value = value;
        }
    }
}
