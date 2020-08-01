using NetEmu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Services
{
    public class LessonService
    {
        public static List<LessonModel> Core1Lessons { get {
                return new List<LessonModel>()
                {
                 new LessonModel(){ LessonId="Core1-1", LessonNumber =1 , LessonType = LessonType.Lecture, LessonTitle = "Prepare USB Installer using Command Prompt" },
                     new LessonModel(){ LessonId="Core1-2", LessonNumber =2 , LessonType = LessonType.Lecture, LessonTitle = "Install Windows 2008 Server" },
                         new LessonModel(){ LessonId="Core1-3", LessonNumber =3 , LessonType = LessonType.Lecture, LessonTitle = "Make usb installer using DVD or ISO and Save it to your flashdrive using Rufus" },
    
                }; } }

        public static List<LessonModel> Core2Lessons { get { 
                
                return new List<LessonModel>() {

                      new LessonModel(){ LessonId="Core2-1", LessonNumber =1 , LessonType = LessonType.Lecture, LessonTitle = "Cabling Connection and Installation" },
                     new LessonModel(){ LessonId="Core2-2", LessonNumber =2 , LessonType = LessonType.Lecture, LessonTitle = "Setup Wireless connection using router, access point, repeater" },
                         new LessonModel(){ LessonId="Core2-3", LessonNumber =3 , LessonType = LessonType.Lecture, LessonTitle = "Set up an Ad Hoc Wireless Computer-to-Computer Network" },


                  }; } }
        public static List<LessonModel> Core3Lessons { get {
                return new List<LessonModel>()
                {
                          new LessonModel(){ LessonId="Core3-1", LessonNumber =1 , LessonType = LessonType.Lecture, LessonTitle = "Installing active directory domain services on windows server 2008 R2 Enterprise 64-bit" },
                     new LessonModel(){ LessonId="Core3-2", LessonNumber =2 , LessonType = LessonType.Lecture, LessonTitle = "Step by  step guide to install DHCP Role and Configure" },
                         new LessonModel(){ LessonId="Core3-3", LessonNumber =3 , LessonType = LessonType.Lecture, LessonTitle = "How to create Users and User Templates in Windows Server 2008 Active" },
        new LessonModel(){ LessonId="Core3-4", LessonNumber =4 , LessonType = LessonType.Lecture, LessonTitle = "Group Policy in Windows 2008 Server R2" },
                     new LessonModel(){ LessonId="Core3-5", LessonNumber =5 , LessonType = LessonType.Lecture, LessonTitle = "How to set up remote Desktop Services" },
                         new LessonModel(){ LessonId="Core3-6", LessonNumber =6 , LessonType = LessonType.Lecture, LessonTitle = "How to install and configure file server" },
        new LessonModel(){ LessonId="Core3-7", LessonNumber =7 , LessonType = LessonType.Lecture, LessonTitle = "Installing the Print Server" },
                     new LessonModel(){ LessonId="Core3-8", LessonNumber =8 , LessonType = LessonType.Lecture, LessonTitle = "Managing remote Print Servers" },
                         new LessonModel(){ LessonId="Core3-9", LessonNumber =9 , LessonType = LessonType.Lecture, LessonTitle = "Linux File Server" },

                };
            } }
    }
}
