using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDJTP
{
    public  class Functions
    {
        public static bool isInvalidbody(string str)
        {
            if ((str[0] == '{') && (str[str.Length - 1] == '}')) return false;
            else return true;
        }


        public static bool isItUnix(string str)
        {
            return str.Length <= 10 && Functions.isDigitsOnly(str);
        }


        public static bool isDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

   
    }
}
