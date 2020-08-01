using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NetEmu.Services
{
    public class TasksToken
    {
        public static CancellationTokenSource DialougeToken { get; set; } = new CancellationTokenSource();
    }
}
