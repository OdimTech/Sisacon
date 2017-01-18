using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Utils
    {
        public static string gereneteRandonNumber()
        {
            var random = new Random();

            return random.Next(10000, 99999).ToString();
        }
    }
}
