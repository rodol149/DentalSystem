using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalSystem
{
    public static class CurrentUser
    {
        public static int user_id { get; set; }
        public static string full_name { get; set; } = "";
        public static string username { get; set; } = "";
        public static string role { get; set; } = "";
    }
}
