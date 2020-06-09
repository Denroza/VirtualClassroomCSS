using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Models.Enum.EnumCollection;

namespace NetEmu.Models
{
    public class UserModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Gender Gender { get; set; }
    }

   
}
