using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINE.SMA.Infrastructure
{
    public class AlertException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public AlertException(string message)
            : base(message)
        {
        }

    }
}
