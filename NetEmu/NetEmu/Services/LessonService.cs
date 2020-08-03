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
            var cap1 = UIService.CreateImageViewCaption("PREPARE INSTALLER USING RUFUS", "c1_1_1.png");

            var s7 = new Label() { TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, Text = $"Add the ISO files and follow the instruction. Make sure the Flash Drive is connected. All files in flash drive will be deleted." };

            stack.Children.Add(s1);
            stack.Children.Add(s2);
            stack.Children.Add(s3);
            stack.Children.Add(s4);
            stack.Children.Add(s5);
            stack.Children.Add(s6);
            stack.Children.Add(cap1);
            stack.Children.Add(s7);
            return stack;
        }

        private static List<string> C1_2T1R1 = new List<string>() {
            "Component","Processor","Memory","Available Disk Space","Drive","Display and Peripherals"
        };

        private static List<string> C1_2T2R1 = new List<string>() {
            $"If you are{Environment.NewLine} currently running:",
            $"Windows Server 2003{Environment.NewLine} Standard Edition{Environment.NewLine} (R2, Service Pack 1{Environment.NewLine} or Service Pack 2)",
            $"Windows Server 2003 {Environment.NewLine}Enterprise Edition {Environment.NewLine}(R2, Service Pack 1 {Environment.NewLine}or Service Pack 2)",
$"Windows Server 2003{Environment.NewLine} Datacenter Edition{Environment.NewLine} (R2, Service Pack 1 {Environment.NewLine}or Service Pack 2)",
        };

        private static List<string> C1_2T1R2 = new List<string>() {
            $"Requirement",
            $"• Minimum: 1GHz (x86 processor) or 1.4GHz (x64 processor) • Recommended: 2GHz or faster Note: An Intel Itanium 2 processor is required for Windows Server 2008 for Itanium-based Systems",
            $"• Minimum: 512MB RAM • Recommended: 2GB RAM or greater • Maximum (32-bit systems): 4GB (Standard) or 64GB (Enterprise and Datacenter){Environment.NewLine} • Maximum (64-bit systems): 32GB (Standard) or 2TB (Enterprise, Datacenter and Itanium-based Systems)",
            $"• Minimum: 10GB {Environment.NewLine} • Recommended: 40GB or greater Note: Computers with more than 16GB of RAM will require more disk space for paging, hibernation, and dump files",
            $"DVD-ROM drive",
            $"• Super VGA (800 x 600) or higher-resolution monitor{Environment.NewLine} • Keyboard{Environment.NewLine} • Microsoft Mouse or compatible pointing device"
        };
        private static List<string> C1_2T2R2 = new List<string>() {
            "You can upgrade to:",
            $"Full Installation of{Environment.NewLine} Windows Server 2008 Standard Edition  {Environment.NewLine}Full Installation of Windows Server 2008 Enterprise Edition",
            $"Full Installation of{Environment.NewLine} Windows Server 2008 Enterprise Edition",
            $"Full Installation of{Environment.NewLine} Windows Server 2008 Datacenter Edition",
        };

        private static List<string> Instruction { get { return new List<string>() {
        "2. Reboot the computer.",
        "3. When prompted for an installation language and other regional options, make your selection and press Next.",
        "⦁	Next, press Install Now to begin the installation process.",
        "⦁	Product activation is now also identical with that found in Windows Vista. Enter your Product ID in the next window, and if you want to automatically activate Windows the moment the installation finishes, click Next.",
        "If you do not have the Product ID available right now, you can leave the box empty, and click Next. You will need to provide the Product ID later, after the server installation is over. Press No.",
        "⦁	Because you did not provide the correct ID, the installation process cannot determine what kind of Windows Server 2008 license you own, and therefore you will be prompted to select your correct version in the next screen, assuming you are telling the truth and will provide the correct ID to prove your selection later on.",
        "⦁	If you did provide the right Product ID, select the Full version of the right Windows version you’re prompted, and click Next.",
        "⦁	Read and accept the license terms by clicking to select the checkbox and pressing Next.",
        "⦁	In the “Which type of installation do you want?” window, click the only available option –Custom (Advanced).",
        "⦁	In the “Where do you want to install Windows?”, if you’re installing the server on a regular IDE hard disk, click to select the first disk, usually Disk 0, and click Next.",
        "If you’re installing on a hard disk that’s connected to a SCSI controller, click Load Driver and insert the media provided by the controller’s manufacturer. If you’re installing in a Virtual Machine environment, make sure you read the “Installing the Virtual SCSI Controller Driver for Virtual Server 2005 on Windows Server 2008” If you must, you can also click Drive Options and manually create a partition on the destination hard disk. ⦁	The installation now begins, and you can go and have lunch. Copying the setup files from the DVD to the hard drive only takes about one minute. However, extracting and uncompressing the files takes a good deal longer. After 20 minutes, the operating system is installed. The exact time it takes to install server core depends upon your hardware specifications. Faster disks will perform much faster installs… Windows Server 2008 takes up approximately 10 GB of hard drive space.",
        "The installation process will reboot your computer, so, if in step #10 you inserted a floppy disk (either real or virtual), make sure you remove it before going to lunch, as you’ll find the server hanged without the ability to boot (you can bypass this by configuring the server to boot from a CD/DVD and then from the hard disk in the booting order on the server’s BIOS)⦁	Then the server reboots you’ll be prompted with the new Windows Server 2008 type of login screen. Press CTRL+ALT+DEL to log in.",
        "⦁	Click on Other User.",
        "14. The default Administrator is blank, so just type Administrator and press Enter.",
        "⦁	You will be prompted to change the user’s password. You have no choice but to press Ok.",
        "⦁	In the password changing dialog box, leave the default password blank (duh, read step #15…), and enter a new, complex, at-least-7-characters-long new password twice. A password like “topsecret” is not valid (it’s not complex), but one like “T0pSecreT!” sure is. Make sure you remember it.",
        "⦁	Someone thought it would be cool to nag you once more, so now you’ll be prompted to accept the fact that the password had been changed. Press Ok.",
        "18. Finally, the desktop appears and that’s it, you’re logged on and can begin working. You will be greeted by an assistant for the initial server configuration, and after performing some initial configuration tasks, you will be able to start working.",

        }; } }
        private static List<string> InstructionImage { get { return new List<string>() {
       "core1_2_1.png","core1_2_2.png","core1_2_3.png","core1_2_4.png","core1_2_5.png","core1_2_6.png","core1_2_7.png","core1_2_8.png","core1_2_9.png","core1_2_10.png","core1_2_11.png","core1_2_12.png","core1_2_13.png","core1_2_14.png","core1_2_15.png","core1_2_16.png","core1_2_17.png","core1_2_18.png"

        }; } } 
        public static StackLayout Core1_2LessonView() {
            var stack = new StackLayout();
            var s1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Note: Windows Server 2008 can also be installed as a Server Core installation, which is a cut-down version of Windows without the Windows Explorer GUI. Because you don’t have the Windows Explorer to provide the GUI interface that you are used to, you configure everything through the command line interface or remotely using a Microsoft Management Console (MMC). The Server Core can be used for dedicated machines with basic roles such as Domain controller/Active Directory Domain Services, DNS Server, DHCP Server, file server, print server, Windows Media Server, IIS 7 web server and Windows Server Virtualization virtual server. For Server Core installations please see my “Installing Windows Server 2008 Core” article."

            };
            var s2 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "To use Windows Server 2008 you need to meet the following hardware requirements:"
            };
            var gridTable1 = new Grid();
            gridTable1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Auto) });
            gridTable1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

            for (int i = 0; i < 6; i++) {
                gridTable1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            }

            //for (int row = 0; row < 2; row++) {
            //    for (int col = 0; col < 6; col++) { 

            //    }
            //}
            int t1C = 0,t1C1 =0;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    if (row == 0)
                    {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center ,
                            Text = C1_2T1R1[t1C]
                        };

                        if (col == 0)
                            label.FontAttributes = FontAttributes.Bold;
                        gridTable1.Children.Add(label, row, col);
                        t1C++;
                    }
                    else {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            Text = C1_2T1R2[t1C1]
                        };
                        if (col == 0) {
                            label.FontAttributes = FontAttributes.Bold;
                            label.VerticalTextAlignment = TextAlignment.Center;
                            label.HorizontalTextAlignment = TextAlignment.Center;
                        }
                    
                        gridTable1.Children.Add(label, row, col);

                        t1C1++;

                    }

                 

                }
            }
            var s3 = new Label() {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Upgrade notes:I will not discuss the upgrade process in this article, but for your general knowledge, the upgrade paths available for Windows Server 2008 shown in the table below:"
            };

            var gridTable2 = new Grid();
            gridTable2.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            gridTable2.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

            for (int i = 0; i < 4; i++)
            {
                gridTable2.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            }
            t1C = 0; t1C1 = 0;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (row == 0)
                    {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = C1_2T2R1[t1C]
                        };

                        if (col == 0)
                            label.FontAttributes = FontAttributes.Bold;
                        gridTable2.Children.Add(label, row, col);
                        t1C++;
                    }
                    else
                    {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            Text = C1_2T2R2[t1C1]
                        };
                        if (col == 0)
                        {
                            label.FontAttributes = FontAttributes.Bold;
                            label.VerticalTextAlignment = TextAlignment.Center;
                            label.HorizontalTextAlignment = TextAlignment.Center;
                        }

                        gridTable2.Children.Add(label, row, col);

                        t1C1++;

                    }



                }
            }

            var s4 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                Text = "Follow this procedure to install Windows Server 2008:"
            };
            var s5 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "1. Insert the appropriate Windows Server 2008 installation media into your DVD drive. If you don’t have an installation DVD for Windows Server 2008, you can download one for free from Microsoft’s Windows 2008 Server Trial website."

            };

            var s6 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Next, for the initial configuration tasks please follow my other Windows Server 2008 articles found on the Related Windows Server 2008 Articles section below."
            };

            stack.Children.Add(s1);
            stack.Children.Add(s2);
            stack.Children.Add(gridTable1);
            stack.Children.Add(s3);
            stack.Children.Add(gridTable2);
            stack.Children.Add(s4);
            stack.Children.Add(s5);
            for (int i = 0; i < 18; i++) {
                var cap = UIService.CreateImageViewCaption(Instruction[i],InstructionImage[i]);
                stack.Children.Add(cap);
            }
            stack.Children.Add(s6);

            return stack;
        }


        public static StackLayout Core1_3LessonView() {
            var stack = new StackLayout();

            return stack;
        }




    }
}
