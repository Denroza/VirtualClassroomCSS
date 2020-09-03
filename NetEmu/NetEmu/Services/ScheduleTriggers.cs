using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Services
{
    public  class ScheduleTriggers
    {
        // Classroom triggers
        public static bool GotoLab { get; set; } = false;
        public static bool SayAfterAuth { get; set; } = false;

        public static bool ShowTerminl { get; set; } = false;
        //

        //LabTrigers
        public static bool GotoClassroom { get; set; } = false;
    }
}
