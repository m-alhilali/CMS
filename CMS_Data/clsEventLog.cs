using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Data
{
    sealed class clsEventLog
    {
        private static string SourceName = "CMS_App";

        public static void TypeErrorInViwerLog(string ErrorMessage,EventLogEntryType type)
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ErrorMessage, type);
            }
            catch { }
        }

    }


}
