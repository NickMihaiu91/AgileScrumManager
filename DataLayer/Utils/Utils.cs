using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utils
{
    public static class UtilityMethods
    {
        public static string GetRandomString(int length)
        {
            return Guid.NewGuid().ToString("N").Substring(0, length);
        }
    }
}
