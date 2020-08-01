using CocosSharp;
using NetEmu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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



        public static StackLayout Core1_1LessonView() {
            var stack = new StackLayout();
            var s1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode =  LineBreakMode.WordWrap,
                Text = $"Insert the DVD Installer (windows 2008 sever or Windows 7)"
            };
            var s2 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Go to Command prompt (CMD) and input the following: {Environment.NewLine}" +
                $"DISKPART{Environment.NewLine}LIST DISK{Environment.NewLine} SELECT DISK ? (the usb letter){Environment.NewLine} CLEAN {Environment.NewLine} CREATE PARTITION PRIMARY{Environment.NewLine} SELECT PARTITION 1 {Environment.NewLine}ACTIVE{Environment.NewLine} FORMAT FS = NTFS{Environment.NewLine} ASSIGN{Environment.NewLine} EXIT"
            };
           

            var s3 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = "Go to your installer DVD and find for the folder ( BOOT)"  };

            var s4 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = $"G:\\>CD BOOT RUN {Environment.NewLine}G:BOOT\\BOOTSECT / NT60 E: (the e: is your usb letter with a: )" };
            var s5 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = $"Then it will say successfully updated NTFS filesystem boot code and so on. Complete now copy the files from you install disk to the usb."};
            var s6 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = $"XCOPY G:\\*.* E:\\ /E /H /F (G: is your source drive E: is your target drive)" };
            var s = new StackLayout();
            var s1_1 = new Label() { TextColor = Color.White, Text = "PREPARE INSTALLER USING RUFUS", FontAttributes = FontAttributes.Bold };
            s.Children.Add(s1_1);
            var image = new Image() { Source = "c1_1_1.png", Aspect = Aspect.AspectFit };
            s.Children.Add(image);
            var s7 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = $"Add the ISO files and follow the instruction. Make sure the Flash Drive is connected. All files in flash drive will be deleted." };

            stack.Children.Add(s1);
            stack.Children.Add(s2);
            stack.Children.Add(s3);
            stack.Children.Add(s4);
            stack.Children.Add(s5);
            stack.Children.Add(s6);
            stack.Children.Add(s);
            stack.Children.Add(s7);
            return stack;
        }

        
        

            
    }
}
