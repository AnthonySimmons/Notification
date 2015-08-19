using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notification.Diagnostics
{
    class PowerControls
    {
        public static void Shutdown()
        {
            Process.Start("shutdown", "/s");
        }

        public static void Restart()
        {
            Process.Start("shutdown", "/g");
        }

        public static void Logoff()
        {
            Process.Start("shutdown", "/l");
        }

        public static void Sleep()
        {
            Process.Start("shutdown", "/h");
        }

    }
}
