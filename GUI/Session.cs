using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Session
    {
        public static USERS CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetUser(USERS u) => CurrentUser = u;
        public static void Clear() => CurrentUser = null;
    }
}
