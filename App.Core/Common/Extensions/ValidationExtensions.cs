using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsStringLengthValid(this string str) { 
            return str.Length > 2 ? true : false;
        }
    }
}
