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

            var cap1 = UIService.CreateImageViewCaption("","c1_3_1.png");
            var cap2 = UIService.CreateImageViewCaption("Add the openSUSE-13.2-DVD-x86_64.ISO and save it to USB Flash Disk and Click Start.", "c1_3_2.png");
            var cap3 = UIService.CreateImageViewCaption("", "c1_3_3.png");
            var l1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Setup the bios to boot in usb" 
            };
            var cap4 = UIService.CreateImageViewCaption("In boot menu", "c1_3_4.png");
            var cap5 = UIService.CreateImageViewCaption("", "c1_3_5.png");
            var cap6 = UIService.CreateImageViewCaption("", "c1_3_6.png");
            var cap7 = UIService.CreateImageViewCaption("", "c1_3_7.png");
            var cap8 = UIService.CreateImageViewCaption("", "c1_3_8.png");
            var cap9 = UIService.CreateImageViewCaption("Click next", "c1_3_9.png");
            var cap10 = UIService.CreateImageViewCaption("", "c1_3_10.png");
            var cap11 = UIService.CreateImageViewCaption("In partitioning the hard disk select manual partition and make two partition 10% for SWAP files and 60% for EXT4 partition under SYSTEM FILES. Click next.", "c1_3_11.png");
            var cap12 = UIService.CreateImageViewCaption("", "c1_3_12.png");
            var cap13 = UIService.CreateImageViewCaption("", "c1_3_13.png");
            var cap14 = UIService.CreateImageViewCaption("", "c1_3_14.png");
            var cap15 = UIService.CreateImageViewCaption("", "c1_3_15.png");
            var cap16 = UIService.CreateImageViewCaption("Use KDE as Desktop", "c1_3_16.png");
            var cap17 = UIService.CreateImageViewCaption("In Installation setting Select SOFTWARE", "c1_3_17.png");
            var cap18 = UIService.CreateImageViewCaption("", "c1_3_18.png");
            var cap19 = UIService.CreateImageViewCaption("Click Install", "c1_3_19.png");
            var cap20 = UIService.CreateImageViewCaption("", "c1_3_20.png");
            var cap21 = UIService.CreateImageViewCaption("", "c1_3_21.png");
            var l2 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Installing services {Environment.NewLine} Follow the Onscreen procedures {Environment.NewLine} Use your name as user and use Css2015 as your password in “root” use and “your name”"
            };

            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(l1);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
            stack.Children.Add(cap14);
            stack.Children.Add(cap15);
            stack.Children.Add(cap16);
            stack.Children.Add(cap17);
            stack.Children.Add(cap18);
            stack.Children.Add(cap19);
            stack.Children.Add(cap20);
            stack.Children.Add(cap21);
            stack.Children.Add(l2);

            return stack;
        }


        private static List<string> DODonts { get {
                return new List<string>()
                {
                 "Do","Do","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do Not","Do","Do","Do","Do","Do Not","Do","Do","Do Not",$"Do Not{Environment.NewLine}(1 Exception)","Do",
                }; } }
        private static List<string> DODontsInfo
        {
            get
            {
                return new List<string>()
                {
                 "Run all cables in a Star Configuration so that all network links are distributed from, or homerun to, one central hub. Visualize a wagon wheel where all of the spokes start from on central point, known as the hub of the wheel.",
                    "Keep Each cable run must be kept to a maximum of 295 feet (90 meters), so that with patch cords, the entire channel is no more than 328 feet (100 meters). This is a requirement of the standard.",
                    "Maintain the twists of the pairs as close as possible to the point of termination, or no more than 0.5\"(one half inch) untwisted.",
                    "Skin off more than 1\" of jacket when terminating UTP",
                    "Make only gradual bends in the cable where necessary to maintain the minimum bend radius of 4 times the cable diameter or approximately 1\" radius (about the roundness of a half-dollar).",
                    "Allow the cable to be sharply bent, twisted, or kinked at any time. This can cause permanent damage to the geometry of the cable and cause transmission failures.",
                    "Dress the cables neatly with Velcro cable ties, using low to moderate pressure.",
                    "Over tighten cable ties or use plastic ties.",
                    "Cross-connect cables (where necessary), using appropriately rated punch blocks and components.",
                    "Splice or bridge UTP cable at any point. There should never be multiple appearances of cable.",
                    "Use low to moderate force when pulling cable. The standard calls for a maximum of 25 lbf (pounds of force).",
                    "Use excessive force when pulling cable.",
                    "Use cable pulling lubricant for cable runs that may otherwise require great force to install. (You will be amazed at what a difference the cable lubricant will make)",
                    "Use oil or any other lubricant not specifically designed for UTP network cable pulling as they can infiltrate the cable jacket, causing damage to the insulation.",
                    "Keep UTP cables as far away from potential sources of EMI (electrical cables, transformers, light fixtures, etc.) as possible. Cables should maintain a 12-inch separation from power cables.",
                    "Tie cables to electrical conduits, or lay cables on electrical fixtures.",
                    "Install proper cable supports, spaced no more than 5 feet apart.",
                    "l cable that is supported by the ceiling tiles. This is unsafe, and is a violation of the building codes.",
                    "Always label every termination point at both ends. Use a unique number for each network link. This will make moves, adds, changes, and troubleshooting as simple as possible. The TIA-606A administration standard provides guidance for properly labeling an installation.",
                    "Always test every installed segment with a cable tester. \"Toning\" alone is not an acceptable test.. \"Toning\" alone, is not an acceptable test.",
                    "Always install jacks in such a way as to prevent dust and other contaminants from settling on the contacts. The contacts (pins) of the jack should face up on flush mounted plates, or left, right, or down (never up) on surface mount boxes.",
                    "Always leave extra slack neatly coiled up in the ceiling or nearest concealed place. It is recommended that you leave at least 5 feet of slack at the work outlet end, and 10 feet of slack at the patch panel end.",
                    "Never install cables taught. A good installation should have the cables loose, but never sagging.",
                    "Always use grommets to protect cable when passing through metal studs or anything that can possibly cause damage.",
                    "Choose either 568A or 568B wiring scheme before you begin your project. Wire all jacks and patch panels for the same wiring scheme (A or B).",
                    "Mix 568A and 568B wiring on the same installation.",
                    $"Use staples on UTP cable that crimp the cable tightly. The common T-18 and T-25 cable staples are not recommended for UTP cable. However, the T-59 insulated staple gun is ideal for fastening both UTP and fiber optic cabling, as it does not put any excess pressure on the cable.",
                    "Always obey all local and national fire and building codes. Be sure to firestop all cables that penetrate a firewall. Use plenum rated cable where it is mandated.",
                };
            }
        }


        public static StackLayout Core2_1LessonView() {
            var stack = new StackLayout();
            var l1 = new Label() {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Plan for network connections-There are certain design considerations that need to be addressed based on your needs. "
            };
            var l2 = new Label() {
                TextColor = Color.Black,
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Color.White,
                Text = $"⦁	Which room(s) do I want wired?{Environment.NewLine} ⦁How many ports do I want in each location ?{Environment.NewLine}⦁What is a good location for distribution ?{Environment.NewLine}⦁What path should the cables take ? {Environment.NewLine}⦁What network speed do I need? This will mainly play a part in what kind of switch to get."
            };

            var cap1 = UIService.CreateImageViewCaption("","c2_1_1.png");
            var l3 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Step 2: Required Tools and Materials (and Costs) Your tools and materials(and costs) can vary a lot based on your needs and what you already have.I borrowed a lot of the following tools, but here's a very basic, estimated breakdown: "
            };
            var l4 = new Label()
            {
                TextColor = Color.Black,
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Color.White,
                Text = $"Tools{Environment.NewLine} ⦁	Ethernet crimping tool(only if you're putting plug on the ends). Cost: $13 on Amazon.{Environment.NewLine} ⦁	Drill(primarily for drilling through wall top plates, but makes screwing faster too).Cost: varies(I already had one).{Environment.NewLine} ⦁	Square Ruler{Environment.NewLine} ⦁	Pointed hand saw(this makes it easy to cut holes for the gang boxes / wall plates).Cost: usually around $15.{Environment.NewLine} ⦁	Strong string or a fish tape.{Environment.NewLine} ⦁	Label maker(optional).{Environment.NewLine} ⦁	Pencil.{Environment.NewLine} ⦁	Sharpie - type marker.{Environment.NewLine} ⦁	Ruler.{Environment.NewLine} ⦁	Stud finder. {Environment.NewLine} ⦁	Punchdown tool(optional). I used a small screwdriver instead.{Environment.NewLine} ⦁	Laptop or cable tester(to test each drop). "
            };
            var l5 = new Label()
            {
                TextColor = Color.Black,
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Color.White,
                Text = $"Materials:{Environment.NewLine}⦁	1000' spool Cat5e or Cat6, Cat6 recommended (more or less based on your need). {Environment.NewLine}⦁	Single Gang Retrofit Boxes(the kind that clamp to the drywall, open back).{Environment.NewLine}⦁	RJ45 Jacks and plates(get what you need, maybe an extra or two).{Environment.NewLine}⦁	RJ45 plugs(optional).{Environment.NewLine}⦁	Plastic grommet(optional, makes the cabling look professional).{Environment.NewLine}⦁	Patch panel(optional, another professional touch).{Environment.NewLine}⦁	Ethernet switch.{Environment.NewLine}⦁	Router(optional, may be required by you ISP).I already had one, and most of you probably will too.{Environment.NewLine}⦁	Velcro strips for cable management (optional). {Environment.NewLine}⦁	Short patch cables"
            };
            var cap2 = UIService.CreateImageViewCaption("", "c2_1_2.png");
            var cap3 = UIService.CreateImageViewCaption("Step 3: Mount the Wall Plates", "c2_1_3.png");
            var l6 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Once you've decided where to mount the box, you need to draw the lines on the wall to fit the new box and cut the hold with the pointed hand saw. The pointed saw should be able to push through the dry wall pretty easily without the need to drill starter holes."
            };
            var cap4 = UIService.CreateImageViewCaption("Once you have the hole cut in the wall, you can put the single gang box into the hole and screw the clamps with hold it in place by clamping to the back of the dry wall. Repeat this for each location that you want to run to.", "c2_1_4.png");
            var cap5 = UIService.CreateImageViewCaption("", "c2_1_5.png");
            var cap6 = UIService.CreateImageViewCaption("", "c2_1_6.png");
            var l7 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "At this time you'll also want to cut a hole in the wall in the distribution room. Here you want to cut a hole that the plastic grommet will fit into."
            };
            var cap7 = UIService.CreateImageViewCaption("Step 5: Connect the Wires to the Jacks and Patch Panel Now we've got the cables run we can punch down the cables to the patch panel and the to jacks. You can take the raw cable directly out of the wall, put a RJ-45 plug on it, and plug directly into the switch. But for permanent installation.", "c2_1_7.png");
            var cap8 = UIService.CreateImageViewCaption("Most patch panels and jacks have diagrams with wire color diagrams for the common T568A and T568B wiring standards. ", "c2_1_8.png");
            var cap9 = UIService.CreateImageViewCaption("", "c2_1_9.png");
            var cap10 = UIService.CreateImageViewCaption("", "c2_1_10.png");
            var l8 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "UTP Installation Do's And Don'ts."
            };
            var table1 = new Grid();
            table1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            table1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            int c = 0,c1=0;
            for (int i = 0; i < 28; i++) {
                table1.RowDefinitions.Add(new RowDefinition() { Height = new  GridLength(1, GridUnitType.Auto)});
            }
            for (int col = 0; col < 2; col++) {
                for (int row = 0; row < 28; row++) {
                    if (col == 0)
                    {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = DODonts[c]
                        };
                        if (label.Text == "DO")
                        {
                            label.TextColor = Color.Green;
                        }
                        else {
                            label.TextColor = Color.Red;
                        }
                        table1.Children.Add(label, col, row);
                        c++;
                    }
                    else {
                        var label = new Label()
                        {
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            BackgroundColor = Color.White,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = DODontsInfo[c1]
                        };
                        table1.Children.Add(label, col, row);
                        c1++;

                    }
                   

                }
            }
            var cap11 = UIService.CreateImageViewCaption("Once you have all the cables connected, you can mount the patch panel to the wall and click the jacks into their respective wall plates on the other ends. You can also screw the wall plates into the gang boxes.", "c2_1_11.png");
            var cap12 = UIService.CreateImageViewCaption($"Step 6: Test Your Connections {Environment.NewLine}Before you start connecting most of the network components, you want to test all of the connections to be sure things are working.This can be done a number of ways.If you actually have a network tester, then you probably know what you're doing.", "c2_1_12.png");
            var cap13 = UIService.CreateImageViewCaption("The next step is to take another patch cable and a laptop and plug it into each port in each room. Check the switch after each port and verify the \"link\" indicator is on. Being able to establish a link tests the physical layer (i.e. no broken wires, all tight crimps, no crossed wires), as well as the data link layer (i.e. negotiation between network card and switch port). No IP addressing or anything needed for testing.", "c2_1_13.png");
            var cap14 = UIService.CreateImageViewCaption("Pictured above: Neat and clean labels for each port actually go where they say they do. MB = Master Bedroom, SB = Second Bedroom, etc.", "c2_1_14.png");
            var cap15 = UIService.CreateImageViewCaption("", "c2_1_15.png");
            var l9 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = "Step 7: Connect to the Internet"
            };
            stack.Children.Add(l1);
            stack.Children.Add(l2);
            stack.Children.Add(cap1);
            stack.Children.Add(l3);
            stack.Children.Add(l4);
            stack.Children.Add(l5);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(l6);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(l7);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(l8);
            stack.Children.Add(table1);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
            stack.Children.Add(cap14);
            stack.Children.Add(cap15);
            stack.Children.Add(l9);
            return stack;
        }

        public static StackLayout Core2_2LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }

        public static StackLayout Core2_3LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }

        public static StackLayout Core3_1LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_2LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_3LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_4LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_5LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_6LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_7LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_8LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }
        public static StackLayout Core3_9LessonView()
        {
            var stack = new StackLayout();


            return stack;
        }



    }
}
