using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Models
{
    public enum LessonType
    {
        Lecture, Emulation
    }
    public class LessonModel
    {
         public string LessonId { get; set; }
         
        public int LessonNumber { get; set; }

        public string LessonTitle { get; set; }

        public string LessonContent { get; set; }
       
        public LessonType LessonType { get; set; }

    }

}
