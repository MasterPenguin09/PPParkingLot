using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Log4net
{
    public class Log4Net_AssemblyInfo
    {
        protected static readonly  log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
