using CocosSharp;
using NetEmu.Models;
using PdfSharp.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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


        //Core 1
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

       //COre 2
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
                        if (label.Text == "Do")
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
            var cap1 = UIService.CreateImageViewCaption("","c2_2_1.png");
            var l1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"⦁	Setup wireless router {Environment.NewLine}A wireless router broadcasts radio signals containing packets of data to computers within range.You can plug a wireless router into a broadband modem to create a wireless network capable of sharing Internet service with connected devices.While setting up the hardware itself is essentially the same from router to router, the network settings configuration for a D-Link is different from that of other brands.After connecting the router and modem to one another, log in to the D - Link router from a Web browser to set up the Wi - Fi network."
            };
            var l2 = new Label() { 
                TextColor = Color.Black,
                BackgroundColor  = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Hardware Setup{Environment.NewLine}Step 1{Environment.NewLine}Disconnect the modem from its power adapter.Connect an Ethernet cable to the modem.{ Environment.NewLine }Step 2{ Environment.NewLine }Plug the other end of the cable into the \"Internet\" port on the back of the wireless router.{ Environment.NewLine }Step 3{ Environment.NewLine }Connect the computer to a LAN port on the D - Link.Connect the modem and the router to a power outlet."
            };

            var l3 = new Label() {
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Basic Configuration{Environment.NewLine}Step 1{ Environment.NewLine }Know the default router IP address and default user name with password in a Web browser to access the setup wizard.{ Environment.NewLine }Step 2{ Environment.NewLine }Choose your connection type from the options.Most Ethernet connections use DHCP.Click \"Connect.\"{ Environment.NewLine }Step 3{ Environment.NewLine }Enter the username and password for your Internet service into the appropriate fields or fill in the IP Address, Subnet Mask, Gateway Address and Primary DNS Server fields, if applicable."
            };
           
            var cap2 = UIService.CreateImageViewCaption("", "c2_2_2.png");
            var l4 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Step 4{ Environment.NewLine }Click \"Connect\" to set up the network on the D - Link. Advanced Settings"
            };
            var cap3 = UIService.CreateImageViewCaption($"Step 5{ Environment.NewLine }Choose \"Configure\" from under Wireless Settings.Click \"Wireless Connection Setup Wizard.\" Click \"Next.\"","c2_2_3.png");
            var cap4 = UIService.CreateImageViewCaption($"", "c2_2_4.png");
            var cap5 = UIService.CreateImageViewCaption($"Step 6 { Environment.NewLine }Enter a name for the network into the Wireless Network Name(SSID) field and then choose \"Automatically Assign a Network Key\" from the options.", "c2_2_5.png");
            var cap6 = UIService.CreateImageViewCaption($"Step 7{ Environment.NewLine }Select \"Use WPA Encryption Instead of WEP,\" for the best security, and then click \"Next.\" Write down the security password shown on - screen and store the password in a secure location.", "c2_2_6.png");
            var l5 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Step 8 { Environment.NewLine }Click \"Save\" to finish configuring the router.After the router automatically reboots, disconnect the router's Ethernet connection from the computer if desired.Router Other Functions:"


            };
            var cap7 = UIService.CreateImageViewCaption($"⦁	DHCP IP Address Reservation:", "c2_2_7.png");
            var cap8 = UIService.CreateImageViewCaption($"⦁	MAC Filtering", "c2_2_8.png");
            var cap9 = UIService.CreateImageViewCaption($"⦁	QOS Quality of Service", "c2_2_9.png");
            var l6 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"⦁	Router Firewall Function"

            }; 
            var cap10 = UIService.CreateImageViewCaption($"⦁	Application rules", "c2_2_10.png");
            var cap11 = UIService.CreateImageViewCaption($"⦁	Web Filtering", "c2_2_11.png");
            var cap12 = UIService.CreateImageViewCaption($"⦁	Application Filter", "c2_2_12.png");
            var cap13 = UIService.CreateImageViewCaption($"⦁	Port Filtering", "c2_2_13.png");
            var l7 = new Label()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Other Functions of Router{ Environment.NewLine }⦁	Port Forwarding - the term port forwarding or port mapping identifies the combined techniques of:{ Environment.NewLine }⦁	translating the address or port number of a packet to a new destination possibly accepting such packet(s) in a packet filter(firewall){ Environment.NewLine }⦁	forwarding the packet according to the routing table{ Environment.NewLine }⦁	The destination may be a predetermined network port(assuming protocols like TCP and UDP, though the process is not limited to these) on a host within a NAT-masqueraded, typically private network, based on the port number on which it was received at the gateway from the originating host."
            };
            var cap14= UIService.CreateImageViewCaption($"", "c2_2_14.png");
            var l8 = new Label()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Types of port forwarding{ Environment.NewLine }⦁	Local port forwarding{ Environment.NewLine }⦁	Remote port forwarding{ Environment.NewLine }⦁	Dynamic port forwarding"
            };
            stack.Children.Add(cap1);
            stack.Children.Add(l1);
            stack.Children.Add(l2);
            stack.Children.Add(l3);
            stack.Children.Add(cap2);
            stack.Children.Add(l4);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(l5);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(l6);
            stack.Children.Add(cap10);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
            stack.Children.Add(l7);
            stack.Children.Add(cap14);
            stack.Children.Add(l8);
            return stack;
        }

        public static StackLayout Core2_3LessonView()
        {
            var stack = new StackLayout();
            var l1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"⦁NOTE: Before following any of these steps, make sure wireless is turned on, on the computers between which you are about to create the ad-hoc network."
            };

            var cap1 = UIService.CreateImageViewCaption($"Step 1: Creating the Ad Hoc Wireless Network First, open the Network and Sharing Center.Click on 'Set up a new connection or network'.","c2_3_1.png");
            var cap2 = UIService.CreateImageViewCaption($"The 'Set Up a Connection or Network' wizard will now start. With it, you can configure all types of connections, from a normal network to a VPN connection to your company network or an ad hoc (computer-to-computer) network. From the list of choices, select 'Set up a wireless ad hoc (computer-to-computer) network', and click Next.", "c2_3_2.png");
            var cap3 = UIService.CreateImageViewCaption($"You will see a new window which describes the things you can do on a wireless ad hoc network. Read the contents of the window and click Next.", "c2_3_3.png");
            var cap4 = UIService.CreateImageViewCaption($"Now it is time to set up the network. First, type the network name and then select the security type you want to use. For more security, I recommend you choose WPA2-Personal. It provides better encryption and it is much harder to crack than WEP. Then, type the password you want to use and, in case you want to use this network on other occasions, check the box that says 'Save this network'. When done, click Next.", "c2_3_4.png");
            var cap5 = UIService.CreateImageViewCaption($"The wizard will now create the network. This activity should take no more than a few seconds.", "c2_3_5.png");
            var cap6 = UIService.CreateImageViewCaption($"When finished, you will receive a notification that the network has been created and it is ready to use. Make sure you don't forget the password and then click on Close.", "c2_3_6.png");
            var cap7 = UIService.CreateImageViewCaption($"Your laptop will now broadcast this newly created network and it will wait for other computers to connect.", "c2_3_7.png");
            var cap8 = UIService.CreateImageViewCaption($"Step 2: Connecting Other Computers to the Network{Environment.NewLine}Now it is time to connect other computers to this network.On the client computer, click the network icon from the notification area and you will see the list of available networks.Select the ad hoc network which you just created and click on Connect.", "c2_3_8.png");
            var cap9 = UIService.CreateImageViewCaption($"You will be asked to type the password. When done, click on OK.", "c2_3_9.png");
            var cap10 = UIService.CreateImageViewCaption($"Windows 7 will now take a few seconds to connect to the network.", "c2_3_10.png");
            var l2 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"When done, the window shown above will be gone and you can now start using the network."
            };
            stack.Children.Add(l1);
            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(l2);
            return stack;
        }
        //COre 3
        public static StackLayout Core3_1LessonView()
        {
            var stack = new StackLayout();
            var l1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"This article provides prerequisites and steps for installing Active Directory Domain Services (AD DS) on Microsoft Windows Server 2008 R2 Enterprise 64-bit (W2K8).{ Environment.NewLine }This article does not provide instructions for adding a Domain Controller(DC) to an already existing Active Directory Forest Infrastructure."
            };
            var tt1 = UIService.CreateTitleText($"Prepare for Active Directory", $"Before you install AD DS on a Rackspace Cloud Server running Windows Server 2008 R2 Enterprise 64-bit (W2K8), you must perform the following prerequisite tasks.");
            var tt2 = UIService.CreateTitleText($"Select Domain Name and Password", $"Select your domain name and know the domain administrator password that you want to use.");
            var l2 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Note: Your domain name should be reliably unique. Do not use the same domain as your website, for example, and avoid extensions like “.local” unless you have registered that domain name in DNS. We suggest a domain name that is not used for anything else, like \"internal.example.com\".."
            };
            var tt3 = UIService.CreateTitleText($"Specify the Preferred DNS Server", $"Windows Server 2008 can properly install and configure DNS during the AD DS installation if it knows that the DNS is local. You can accomplish this by having the private network adapter’s preferred DNS server address point to the already assigned IP address of the same private network adapter, as follows:");
            var l3 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"⦁	From the Windows Start menu, open Administrative Tools > Server Manager."
            };
            var cap1 = UIService.CreateImageViewCaption($"⦁	In the Server Summary section of the Server Manager window, click View Network Connections.", "c3_1_1.png");
            var cap2 = UIService.CreateImageViewCaption($"⦁	In the Network Connections window, right-click the private adapter and select Properties.", "c3_1_2.png");
            var cap3 = UIService.CreateImageViewCaption($"⦁	Select Internet Protocol Version 4, and then click Properties.", "c3_1_3.png");
            var cap4 = UIService.CreateImageViewCaption($"⦁	Copy the IP address that is displayed in the IP address box and paste it into the Preferred DNS server box. Then, click OK.", "c3_1_4.png");
            var l4 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"⦁	Click OK in the Properties dialog box, and close the Network Connections window."
            };
            var l5 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Note: The last step for prepping W2K8 for AD is adding the proper Server Role. The “Active Directory Domain Services” Role will be added. This only installs the framework for W2K8 to become a DC and run AD. It does not promote the server to DC or install AD."
            };
            var tt4 = UIService.CreateTitleText($"Add the Active Directory Domain Services Role", $"Adding the Active Directory Domain Services role installs the framework for Windows Server 2008 to become a DC and run AD DS. It does not promote the server to a DC or install AD DS.");
            var cap5 = UIService.CreateImageViewCaption($"⦁	In the Server Manager window, open the Roles directory and in the Roles Summary section, click Add Roles.", "c3_1_5.png");
            var cap6 = UIService.CreateImageViewCaption($"⦁	On the Before You Begin page of the Add Roles Wizard, click Next.{ Environment.NewLine }⦁	On the Select Server Roles page, select the Active Directory Domain Services check box, and then click Next on this page and on the Confirmation page.", "c3_1_6.png");
            var cap7 = UIService.CreateImageViewCaption($"⦁	On the Installation Progress page, click Install. ", "c3_1_7.png");
            var cap8 = UIService.CreateImageViewCaption($"⦁	On the Results page, after the role is successfully added, click Close.", "c3_1_8.png");
            var tt5 = UIService.CreateTitleText($"Enable the Remote Registry", $"⦁	Open the Server Manager window if it is not already open. { Environment.NewLine }⦁	In the Properties area of the Local Servers page, click Remote Management.{ Environment.NewLine }⦁	Select the Enable remote management of this server from other computers check box.");
            var tt6 = UIService.CreateTitleText($"Add the Active Directory Domain Services Role", $"Now that you have prepared the server, you can install AD DS.");
            var l6 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Tip: As an alternative to performing steps 1 through 3, you can type dcpromo.exe at the command prompt. Then, skip to step 4."
            };
            var cap9 = UIService.CreateImageViewCaption($"⦁	If it is not already open, open the Server Manager window.{ Environment.NewLine }⦁	Select Roles > Active Directory Domain Services.{ Environment.NewLine }⦁	In the Summary section, click Run the Active Directory Domain Services Installation Wizard(dcpromo.exe).or Open RUN and Type DCPROMO", "c3_1_9.png");
            var cap10 = UIService.CreateImageViewCaption($"⦁	On the Welcome page of the Active Directory Domain Services Installation Wizard, ensure that the Use advanced mode installation check box is cleared, and then click Next. ", "c3_1_10.png");
            var cap11 = UIService.CreateImageViewCaption($"⦁	On the Operating System Capability page, click Next.", "c3_1_11.png");
            var cap12 = UIService.CreateImageViewCaption($"⦁	On the Choose a Deployment Configuration page, select Create a new domain in a new forest and then click Next.", "c3_1_12.png");
            var cap13 = UIService.CreateImageViewCaption($"⦁	On the Name the Forest Root Domain page, enter the domain name that you choose during preparation steps. Then, click Next.", "c3_1_13.png");
            var cap14 = UIService.CreateImageViewCaption($"⦁	After the installation verifies the NetBIOS name, on the Set Forest Functional Level page, select Windows Server 2008 R2 in the Forest function level list. Then, click Next.", "c3_1_14.png");
            var l7 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"The installation examines and verifies your DNS setting."
            };
            var cap15 = UIService.CreateImageViewCaption($"⦁	On the Additional Domain Controller Options page, ensure that the DNS server check box is selected, and then click Next. ", "c3_1_15.png");
            var cap16 = UIService.CreateImageViewCaption($"⦁	In the message dialog box that appears, click Yes.", "c3_1_16.png");
            var cap17 = UIService.CreateImageViewCaption($"⦁	On the Location for Database, Log Files, and SYSVOL page, accept the default values and then click Next. ", "c3_1_17.png");
            var cap18 = UIService.CreateImageViewCaption($"⦁	On the Directory Services Restore Mode Administrator Password page, enter the domain administrator password that you chose during the preparation steps. This is not your admin password that was emailed to you during the creation of your server, although you can use that password if you want to. Then, click Next.", "c3_1_18.png");
            var cap19 = UIService.CreateImageViewCaption($"⦁	On the Summary page, review your selections and then click Next.The installation begins.", "c3_1_19.png");
            var cap20 = UIService.CreateImageViewCaption($"⦁	If you want the server to restart automatically after the installation is completed, select the Reboot on completion check box.", "c3_1_20.png");
            var cap21 = UIService.CreateImageViewCaption($"⦁	If you did not select the Reboot on completion check box, click Finish in the wizard. Then, restart the server. ", "c3_1_21.png");
            var l8 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"The installation examines and verifies your DNS setting."
            };
            var l9 = new Label()
            {
                TextColor = Color.Black,
                LineBreakMode = LineBreakMode.WordWrap,
                BackgroundColor = Color.White,
                Text = $"⦁	To log in, perform the following steps:{ Environment.NewLine }a.Click Switch User, and then click Other User.{ Environment.NewLine }b.For the user,enter the full domain name that you chose, followed by a back slash and Administrator(for example, Example.com\\Administrator).{ Environment.NewLine }c.Enter the password that was emailed to you when you first built the server.If you changed your passwordfor the local admin account to this server before you began the installation of Active Directory Domain Services, use that password.{ Environment.NewLine }d.Click the log in button."
            };
            var l10 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"The installation of Active Directory Domain Services on your server is complete."
            };
            stack.Children.Add(l1);
            stack.Children.Add(tt1);
            stack.Children.Add(tt2);
            stack.Children.Add(l2);
            stack.Children.Add(tt3);
            stack.Children.Add(l3);
            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(l4);
            stack.Children.Add(l5);
            stack.Children.Add(tt4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(tt5);
            stack.Children.Add(tt6);
            stack.Children.Add(l6);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
            stack.Children.Add(cap14);
            stack.Children.Add(l7);
            stack.Children.Add(cap15);
            stack.Children.Add(cap16);
            stack.Children.Add(cap17);
            stack.Children.Add(cap18);
            stack.Children.Add(cap19);
            stack.Children.Add(cap20);
            stack.Children.Add(cap21);
            stack.Children.Add(l8);
            stack.Children.Add(l9);
            stack.Children.Add(l10);
            return stack;
        }
        public static StackLayout Core3_2LessonView()
        {
            var stack = new StackLayout();
            var cap1 = UIService.CreateImageViewCaption($"To start first need to log in to the server with administrator privileges. Then start the “server Manager” by clicking on “Server Manager” icon on task bar. Then go to “Roles”","c3_2_1.png");
            var cap2 = UIService.CreateImageViewCaption($"Then click on “Add Roles” option to open Add roles Wizard.", "c3_2_2.png");
            var cap3 = UIService.CreateImageViewCaption($"Then it will load the Roles Wizard and select the “DHCP Server” From the list and click next to continue.", "c3_2_3.png");
            var cap4 = UIService.CreateImageViewCaption($"Then it will give description about the role. Click next to continue.", "c3_2_4.png");
            var cap5 = UIService.CreateImageViewCaption($"Next window is asking to use which interface to serve DHCP clients. If server has multiple NIC with multiple IP you can add them also to serve DHCP clients.", "c3_2_5.png");
            var cap6 = UIService.CreateImageViewCaption($"In next window it will give opportunity to add DNS settings that should apply for DHCP clients.", "c3_2_6.png");
            var cap7 = UIService.CreateImageViewCaption($"Next window is to define the WINS server details.", "c3_2_7.png");
            var cap8 = UIService.CreateImageViewCaption($"In next window we can add the scope, the Starting IP, End IP of the DHCP range, subnet mask, default gateway, leased time etc.", "c3_2_8.png");
            var cap9 = UIService.CreateImageViewCaption($"In next Window it can configure to support IPv6 as well.", "c3_2_9.png");
            var cap10 = UIService.CreateImageViewCaption($"Then it will give the confirmation window before begin the install. Click on “Install”", "c3_2_10.png");
            var cap11 = UIService.CreateImageViewCaption($"Once installation finishes DHCP server interface can open from Start > Administrative Tools > DHCP", "c3_2_11.png");
            var l1 = new Label()
            {
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"Using the DHCP it is possible to even configure multiple Scopes configurations to the network. In a network there can be different network segments. It is waste to setup different DHCP servers for each segment. Instead of that it is possible to create different Scopes to issue DHCP for them."
            };

            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(cap11);
            stack.Children.Add(l1);
            return stack;
        }
        public static StackLayout Core3_3LessonView()
        {
            var stack = new StackLayout();
            var l1 = UIService.CreateTextItem($"You probably already know that a User Account in Active Directory is an Active Directory Object, or simply said, a record in an AD database. Most of the time we create user accounts for people, however user accounts can also be created for applications or processes.",Color.White,Color.Transparent);
            var l2 = UIService.CreateTextItem($"User accounts allow a person to access resources on a network. But we can just as easily deny access to certain resources on the network through the user account. That’s why, User Account Objects are quite important and very useful.", Color.White, Color.Transparent);
            var l3 = UIService.CreateTextItem($"User Groups and Organizational Units. Now, let’s get started with creating a user account.", Color.White, Color.Transparent);
            var l4 = UIService.CreateTextItem($"How To Create a New User Account in Active Directory", Color.White, Color.Transparent);
            var cap1 = UIService.CreateImageViewCaption($"1. To start let’s go ahead and open up Server Manager","c3_3_1.png");
            var cap2 = UIService.CreateImageViewCaption($"2. Next we will open up the Roles section, next to Active Directory Users and Computers section and finally the Active Directory Users and Computers. You should now see your domain name.", "c3_3_2.png");
            var cap3 = UIService.CreateImageViewCaption($"3. We are going to click on our Users section where we are going to create a new User Account. To do so, right-click on the blank section, point to New and select User", "c3_3_3.png");
            var cap4 = UIService.CreateImageViewCaption($"4. In this window you need to type in the user’s first name, middle initial and last name. Next you will need to create a user’s logon name.{ Environment.NewLine } In our example we are going to create a user account for Billy Miles and his logon name will be bmiles.When done, click on the Next button", "c3_3_4.png");
            var cap5 = UIService.CreateImageViewCaption($"5. In the next window you will need to create a password for your new user and select appropriate options.{ Environment.NewLine } In our example we are going to have the user change his password at his next logon.You can also prevent a user from changing his password, set the password so that it will never expire or completely disable the account.{ Environment.NewLine } When you are done making your selections, click the Next button.", "c3_3_5.png");
            var cap6 = UIService.CreateImageViewCaption($"6. And finally, click on the Finish button to complete the creation of new User Account.", "c3_3_6.png");
            var tt1 = UIService.CreateTitleText($"How To Create a User Template in Active Directory",$"A user template in Active Directory will make your life a little easier, especially if you are creating users for a specific department, with exactly the same properties, and membership to the same user groups. A user template is nothing more than a disabled user account that has all these settings already in place. The only thing you are doing is copying this account, adding a new name and a password.{Environment.NewLine } You may have multiple user templates for multiple purposes with different settings and properties.There is no limit on the number of user templates, but keep in mind that they are there to help you, not to confuse you, so keep in mind less is better.{ Environment.NewLine } To create a user template, we are going to create a regular user account just like we did above.A little note here, you may want to add an * as the first character of the name so it floats at the top in AD and is much easier to find.");
            var cap7 = UIService.CreateImageViewCaption($"1. To start out, right-click on the empty space, point to new, and select User.", "c3_3_7.png");
            var cap8 = UIService.CreateImageViewCaption($"2. Type in the user’s name (with asterisks if so desired) and click Next.", "c3_3_8.png");
            var cap9 = UIService.CreateImageViewCaption($"3. Create the template’s password and do not forget to check the box next to the Account is disabled option. When ready, click Next.", "c3_3_9.png");
            var cap10 = UIService.CreateImageViewCaption($"4. Once the account is created, you can go ahead and add all the properties you need for that template. To do so, double-click on that account and navigate to a specific tab. Once done click OK.", "c3_3_10.png");
            var l5 = UIService.CreateTextItem($"How To Use a User Template in Active Directory", Color.White, Color.Transparent);
            var cap11 = UIService.CreateImageViewCaption($"1. Now in order to use that user template, we are going to select it, copy it and add the unique information such as user name, password, etc.{Environment.NewLine } We can do that for as many users as needed.Let’s start by right - clicking on the template and selecting Copy", "c3_3_11.png");
            var cap12 = UIService.CreateImageViewCaption($"2. Next we are going to enter the user’s name, login and password information while making sure the checkbox next to Account is disabled is unchecked.", "c3_3_12.png");
            var cap13 = UIService.CreateImageViewCaption($"3. Once we finish, our new user account is created with all the properties of the template account. Now wasn’t that easy!", "c3_3_13.png");

            stack.Children.Add(l1);
            stack.Children.Add(l2);
            stack.Children.Add(l3);
            stack.Children.Add(l4);
            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(tt1);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(l5);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
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
            var cap1 = UIService.CreateImageViewCaption($"Step 1: Begin the installation{ Environment.NewLine } Launch Server Manager, and select \"roles.\" Once the roles manager screen is up, check the box for Remote Desktop Services ",$"c3_5_1.png");
            var cap2 = UIService.CreateImageViewCaption($" After clicking Next, you should see an introduction to Remote Desktop Services ", $"c3_5_2.png");
            var cap3 = UIService.CreateImageViewCaption($"Step 2: Select Remote Desktop Services roles you want to install{ Environment.NewLine }Remote Desktop Services(RDS) includes several components. These components can be on one machine or many.Let's take a look at each of them.{ Environment.NewLine }⦁	Remote Desktop Session Host: This is the new name of Terminal Server.{ Environment.NewLine }⦁	Remote Desktop Virtualization Host: This component integrates with Hyper - V.This allows for the pooling of virtual machines on Hyper-V to be used for virtual desktops.{ Environment.NewLine }⦁	Remote Desktop Connection Broker: This component is used to bridge the user with a virtual desktop, remote application or Terminal Server session.{ Environment.NewLine }⦁	Remote Desktop Licensing: This is the new name of Terminal Server licensing server that also includes licensing for Microsoft's Virtual Desktop Infrastructure (VDI).{ Environment.NewLine }⦁	Remote Desktop Gateway: This provides a single connection point for clients to connect to a specific virtual desktop, remote app or Terminal Server session.{ Environment.NewLine }⦁	Remote Desktop Web Access: This provides clients an interface to access their virtual desktop, remote app or Terminal Server sessions.", $"c3_5_3.png");
            var cap4 = UIService.CreateImageViewCaption($"Step 3: Pick the license mode{ Environment.NewLine }As with past Terminal Server licensing, there are two license options: per device and per user ", $"c3_5_4.png");
            var cap5 = UIService.CreateImageViewCaption($"Step 4: Allowing access to Terminal Server (not required){ Environment.NewLine }Select which users to give access to the local terminal services.This component is not required for RDS to work.If you choose to install \"Remote Desktop Session Host\" as I have, you will get this prompt ", $"c3_5_5.png");
            var cap6 = UIService.CreateImageViewCaption($"Step 5: Configure the client experience{ Environment.NewLine }The next screen is \"Configure Client Experience\".This is where you set the defaults for the experience the end user will have with the VDI system.", $"c3_5_6.png");
            var cap7 = UIService.CreateImageViewCaption($"Step 6: Configure license scope { Environment.NewLine }Just as with Terminal Server of the past, you can configure the scope of the license server.You have the following two options:{ Environment.NewLine }⦁	Domain: This limits the licensing to only servers in the domain.{ Environment.NewLine }⦁	Forest: This allows any Terminal Server in the forest to attain a license.", $"c3_5_7.png");
            var cap8 = UIService.CreateImageViewCaption($"Step 7: Assigning the SSL certificate for Remote Desktop Gateway (see Figure 8){ Environment.NewLine }The Remote Desktop Gateway uses Secure Sockets Layer(SSL) to tunnel and encrypt traffic from the client.This functionality requires a certificate.There are two options for certificates:{ Environment.NewLine }⦁	Specify a certificate from the certificate store.{ Environment.NewLine }⦁	Produce a self - signed certificate.{ Environment.NewLine }In either case, the client must trust the certificate", $"c3_5_8.png");
            var cap9 = UIService.CreateImageViewCaption($"Step 8: Configure network access protection (optional){ Environment.NewLine } These next few screens go beyond the scope of RDS but are related, so I will just cover the basics.{ Environment.NewLine }Create authorization policies{ Environment.NewLine }I skipped this part because it is beyond this article's scope. This is where you would configure a policy that states who is allowed to use the Remote Desktop Gateway.", $"c3_5_9.png");
            var cap10 = UIService.CreateImageViewCaption($"nstall and configure network access and protection policies { Environment.NewLine }This is used to configure and enforce network access polices such as IPsec and network access protection from the client.This feature can also be used to define different policies based on users' connectivity (dial-up or virtual private network).", $"c3_5_10.png");
            var cap11 = UIService.CreateImageViewCaption($"", $"c3_5_11.png");
            var cap12 = UIService.CreateImageViewCaption($"Step 9: Install IIS and Remote Desktop Web Access{ Environment.NewLine }Remote Desktop Web Access requires Internet Information Services(IIS), so the next two screens are for installing and configuring IIS.this image is an overview screen, while the next is the configuration screen.", $"c3_5_12.png");
            var cap13 = UIService.CreateImageViewCaption($"", $"c3_5_13.png");
            var cap14 = UIService.CreateImageViewCaption($"Step 10: The final steps{ Environment.NewLine }At this point, you're done. The last two screens just let you know what you're installing, and a final screen lets you know whether any additional steps like rebooting are required", $"c3_5_14.png");
            var cap15 = UIService.CreateImageViewCaption($"", $"c3_5_15.png");
            var l1 = UIService.CreateTextItem($"Now that you have installed and configured RDS, you can start using Terminal Services and Remote Desktop Gateway Manager. ",Color.White,Color.Transparent);
            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
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
            stack.Children.Add(l1);
            
            return stack;
        }
        public static StackLayout Core3_6LessonView()
        {
            var stack = new StackLayout();

            var cap1 = UIService.CreateImageViewCaption($"Open \"Server Manager\" and click \"Add Role\". Select \"File Services\" from the Server role list.", $"c3_6_1.png");
            var cap2 = UIService.CreateImageViewCaption($"", $"c3_6_2.png");
            var cap3 = UIService.CreateImageViewCaption($"", $"c3_6_3.png");
            var cap4 = UIService.CreateImageViewCaption($"", $"c3_6_4.png");
            var cap5 = UIService.CreateImageViewCaption($"", $"c3_6_5.png");
            var cap6 = UIService.CreateImageViewCaption($"", $"c3_6_6.png");
            var cap7 = UIService.CreateImageViewCaption($"", $"c3_6_7.png");
            var cap8 = UIService.CreateImageViewCaption($"", $"c3_6_8.png");
            var cap9 = UIService.CreateImageViewCaption($"", $"c3_6_9.png");
            var l1 = UIService.CreateTextItem($"Now create a Folder and share it with below permissions.{ Environment.NewLine } Share name: UserData$ (You can hide the share using the dollar sign($) at the end of the share name)",Color.White,Color.Transparent);
            var cap10 = UIService.CreateImageViewCaption($"Administrators: Full Control{ Environment.NewLine }System: Full Control{ Environment.NewLine }Authenticated Users: Full Control", $"c3_6_10.png");
            var cap11 = UIService.CreateImageViewCaption($"Security settings{ Environment.NewLine }Group: Authenticated Users{ Environment.NewLine }Type: Allow{ Environment.NewLine }Applies to: This folder only{ Environment.NewLine }{ Environment.NewLine }Permissions:{ Environment.NewLine }Traverse folder / execute file{ Environment.NewLine }List folder / read data{ Environment.NewLine }Read attributes{ Environment.NewLine }Read extended attributes{ Environment.NewLine }Read permissions", $"c3_6_11.png");
            var cap12 = UIService.CreateImageViewCaption($"", $"c3_6_12.png");
            var cap13 = UIService.CreateImageViewCaption($"Create a Quota Template.", $"c3_6_13.png");
            var cap14 = UIService.CreateImageViewCaption($"", $"c3_6_14.png");
            var cap15 = UIService.CreateImageViewCaption($"", $"c3_6_15.png");
            var cap16 = UIService.CreateImageViewCaption($"", $"c3_6_16.png");
            var cap17 = UIService.CreateImageViewCaption($"", $"c3_6_17.png");
            var cap18 = UIService.CreateImageViewCaption($"", $"c3_6_18.png");
            var cap19 = UIService.CreateImageViewCaption($"", $"c3_6_19.png");
            var cap20 = UIService.CreateImageViewCaption($"", $"c3_6_20.png");
            var cap21 = UIService.CreateImageViewCaption($"", $"c3_6_21.png");
            var cap22 = UIService.CreateImageViewCaption($"Attach to a User's profile.", $"c3_6_22.png");
            var cap23 = UIService.CreateImageViewCaption($"", $"c3_6_23.png");
            var cap24 = UIService.CreateImageViewCaption($"", $"c3_6_24.png");

            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(cap5);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(l1);
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
            stack.Children.Add(cap22);
            stack.Children.Add(cap23);
            stack.Children.Add(cap24);
            return stack;
        }

        private static Dictionary<string, string> C3_7T1 {
            get {
                return new Dictionary<string, string>()
                {
                    { "Option","Description" },
                    { $"Print{Environment.NewLine}Server",$"Installs the print server and Print Management console. This is a prerequisite for configuring print services on Windows Server 2008." },
                    { $"LDP{Environment.NewLine}Service",$"Installs the TCP/IP Line Printer Daemon Service (LPDSV) allowing UNIX, Linux and other Line Printer Remote (LPR0) based computers to print via the print server. This setting also opens port in the Windows Firewall." },
                    { $"Internet Printing",$"Creates an Internet Information Service (IIS) hosted web site where users can manage printers and connect and print to shared printers hosted in the server using the Internet Printing Protocol (IPP). The default URL for the web site is http://servername/Printers, where servername is the name of the server running the print services." },
                }; }
        }
        public static StackLayout Core3_7LessonView()
        {
            // var l2 = UIService.CreateTextItem($"", Color.White, Color.Transparent); template
            //var tt1 = UIService.CreateTitleText($"",  $"");
            var stack = new StackLayout();
            var l1 = UIService.CreateTextItem($"The first step in setting up a Windows Server 2008 print server is to install the Print Server role. This is achieved by launching the Server Manager, selecting Roles item from the tree in the left pane and clicking on Add Roles. In the Add Roles Wizard click next on the Welcome screen if one appears and then select the Print Services option. Click Next and read the information displayed before clicking Next once again to proceed to the Select Role Services screen. On this screen a number of different service options are available for selection and installation as outlined in the following table:",Color.White,Color.Transparent);
            var gridT = new Grid();
            #region grid init
            gridT.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Auto) });
            gridT.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

            gridT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            gridT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            gridT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            #endregion
            int ctr1 = 0,ctr2 =0;
            for(int col = 0; col <2; col++) {
                for (int row = 0; row < 3; row++) {
                    if (col == 0)
                    {
                        var op = UIService.CreateTextItem(C3_7T1.Keys.ToList()[ctr1], Color.Black, Color.White);
                        gridT.Children.Add(op,col,row);
                        ctr1++;
                    }
                    else {
                        var des = UIService.CreateTextItem(C3_7T1.Values.ToList()[ctr2], Color.Black, Color.White);
                        gridT.Children.Add(des, col, row);
                        ctr2++;
                    }

                }   
             }
            var l2 = UIService.CreateTextItem($"With the required options selected, click Next. Note that if Internet Printing was selected and the IIS role is not currently installed in the server, the wizard will prompt to add additional roles. If prompted, click on the Add Required Role Services button to proceed. Click Next on any information pages that may be displayed until the Confirmation screen appears. After reviewing the summary information provided, click Install to initiate the installation process.", Color.White, Color.Transparent);
            var l3 = UIService.CreateTextItem($"Print Services Management Tools", Color.Black, Color.Transparent,FontAttributes.Bold);
            var l4 = UIService.CreateTextItem($"Once print services are installed a number of print management tools are now available on the system. First and foremost is the Print Management snap-in which may be accessed via Start -> All Programs -> Administrative Tools -> Print Management. A useful command-line tool is also available in the form of the Print Backup Recovery Migration tool. The executable is named Printbrm.exe and is located in %SystemRoot%\\System32\\Spool\\Tools.", Color.White, Color.Transparent);
            var l5 = UIService.CreateTextItem($"A number of useful VBscript tools are also available in %SystemRoot%\\System32\\Printing_Admin_Scripts\\en-US (note that if you use a language other than en-US the path will need to be change accordingly). Scripts are available for configuring printer settings (prncfg.vbs), listing and managing printer drivers (prndrvr.vbs), managing print jobs (prnjobs.vbs), managing print queues (prnQctl.vbs), publishing printers to active directory (pubprn.vbs), installing and managing printers (prnmngr.vbs) and for managing TCP/IP printer ports (prnport.vbs).", Color.White, Color.Transparent);
            var tt1 = UIService.CreateTitleText($"The scripts are executed using the cscript.exe command and when run without any command-line options will display a list of supported options. For example:",
                $"cscript prnjobs.vbs{Environment.NewLine }{Environment.NewLine }Microsoft(R) Windows Script Host Version 5.7{Environment.NewLine }Copyright(C) Microsoft Corporation.All rights reserved.{ Environment.NewLine }{Environment.NewLine }Usage: prnjobs[-zmxl ?][-s server][-p printer][-j jobid][-u user name][-w password]{ Environment.NewLine }{Environment.NewLine }Arguments:{Environment.NewLine }-j - job id{Environment.NewLine }- l - list all jobs{Environment.NewLine }-m - resume the job{Environment.NewLine }-p - printer name{Environment.NewLine }- s - server name{Environment.NewLine }- u - user name{Environment.NewLine }- w - password{Environment.NewLine }- x - cancel the job{Environment.NewLine }-z - pause the job{Environment.NewLine }-? -display command usage { Environment.NewLine }{Environment.NewLine } Examples:{Environment.NewLine }prnjobs - z - p printer - j jobid{Environment.NewLine }prnjobs - l - p printer{Environment.NewLine }prnjobs - l");
            var l6 = UIService.CreateTextItem($"Adding Network Printers to the Print Server using Auto-detect", Color.Black, Color.Transparent, FontAttributes.Bold);
            var l7 = UIService.CreateTextItem($"Obviously, a print server without any printers isn't going to be of much use. Not surprisingly, therefore, the next step after installing Print Services is to add printers. Printers may either be network based, or locally connected to the server. In the case of network printers, these may be added either manually or using auto-detection. Under auto-detection, Print Management scans the subnet on which the server resides and searches for any devices it can identify as being printers. As printers are detected on the network they are displayed in a list here they may be selected and added to the print server.", Color.White, Color.Transparent);
            var cap1 = UIService.CreateImageViewCaption($"To add network printers using auto-detection, open the Print Management tool via Start -> All Programs -> Administrative Tools -> Print Management, unfold the Print Servers from the list in the left pane, right click the local or remote print server to which the new printer is to be added and select Add Printer.... This will display the Network Printer Installation Wizard as illustrated below:",$"c3_7_1.png");
            var cap2 = UIService.CreateImageViewCaption($"In order to have the wizard search for printers on the network, ensure that the Search for network printers is selected and click on Next. At this point the wizard will begin the process of scanning the network for printers. As each printer is detected it will be listed. In the following example, the wizard has detected an HP Deskjet 5800 printer on the network with an IP address of 192.168.2.10:", $"c3_7_2.png");
            var cap3 = UIService.CreateImageViewCaption($"If no printers are detected, ensure that the printers are connected to the network and powered on and are on the same subnet as the print server. Once the scan is complete, select the required printer from the list and click Next to proceed to the Printer Driver screen. If a driver for the printer is already installed, select it from the drop down list. Alternatively select the Install a new driver option and click Next to proceed to the Printer Installation screen where a list of printer manufacturers and models is presented. Select the make and model of the printer from the list:", $"c3_7_3.png");
            var cap4 = UIService.CreateImageViewCaption($"If the make and model of printer are not listed, check to see if the printer was supplied with a driver disk, or whether a driver can be obtained from the manufacturer's web site. Assuming this to be the case, use the Have Disk button to browse for and select the appropriate manufacturer driver. With either a printer selected from the list, or a suitable driver specified, click on Next to configure thePrinter Name and Share Settings. On this screen, enter the name by which the new printer will be shared to clients over the network. If the printer is not to be shared, ensure that the Share this printeris not selected. Also, enter a location description (for example, \"Printer in Accounts\") and comment if desired. Click Next to display the printer summary screen as illustrated below where the selected settings are presented for review:", $"c3_7_4.png");
            var l8 = UIService.CreateTextItem($"Assuming the configuration summary is correct, click Next to install the new printer. At this point the wizard will report that the driver has been successfully installed and that a test page is ready to be printed. If another printer is to be added to the print server, select the Add Another Printer option to instruct the wizard to loop back to the start of the installation process.", Color.White, Color.Transparent);
            var l9 = UIService.CreateTextItem($"Manually Adding Network Printers to a Print Server", Color.Black, Color.Transparent, FontAttributes.Bold);
            var cap5 = UIService.CreateImageViewCaption($"The preceding section discussed the use of auto-detection to locate and install and network attached printer. This section will cover the manual installation of a network printer. As with auto-detection, begin by invoking the Print Management tool (Start -> All Programs -> Administrative Tools -> Print Management), unfold the Print Servers category from the list in the left pane, right click the local or remote print server to which the new printer is to be added and select Add Printer.... This will launch the Network Printer Installation Wizard. On the initial page of the wizard select the option labeledAdd a TCP/IP or Web Services Printer by IP address or hostname and click Next to proceed to the Printer Address screen. If the type of printer is known (TCP/IP device or Web Services Printer) make the appropriate selection. Alternatively, leave the setting as Auto Detect to have the wizard identify the printer type. Enter the IP address or hostname of the printer to be added to the print server. The wizard will automatically generate a unique port name to accompany the IP address or hostname. The option is also provided to have the wizard attempt to identify the appropriate driver for the new printer. The following figure illustrates the screen as described:", $"c3_7_5.png");
            var l10 = UIService.CreateTextItem($"Click Next to install a printer driver. If a driver for the printer is already installed on the print server, select it from the drop down list. Alternatively select the Install a new driver option and click Next to proceed to the Printer Installation screen where a list of printer manufacturers and models is presented. Select the make and model of the printer from the list, or use the Have Disk to install the manufacturer supplied driver.", Color.White, Color.Transparent);
            var l11 = UIService.CreateTextItem($"With either a printer selected, click on Next to configure the Printer Name and Share Settings. On this screen, enter the name by which the new printer will be shared to clients over the network. If the printer is not to be shared, ensure that the Share this printer is not selected. Also, enter a location description (for example, \"Color Printer in Sales\") and comment if desired. Click Next to perform the installation and print an optional test page.", Color.White, Color.Transparent);
            var l12 = UIService.CreateTextItem($"Adding a Locally Connected Printer", Color.Black, Color.Transparent, FontAttributes.Bold);
            var l13 = UIService.CreateTextItem($"Since servers are generally sequestered in climate controlled server room and printers are located in proximity to the users it always seems a little odd to talk about installing printers with are locally connected to servers. That said, it is a topic which needs to covered, and cover it we will.", Color.White, Color.Transparent);
            var cap6 = UIService.CreateImageViewCaption($"Local printers will be connected to the server using a serial (COM) port, a parallel (LPT) port or a Universal Serial Bus (USB) port. Often, Windows will automatically detect a new printer as soon as it is connected and powered up. In this situation an icon will appear in the task bar indicating that the new device has been detected. Clicking on this icon presents the option to view details about the installation process, resulting in the appearance of a dialog similar to the one illustrated below, where a Brother MFC-420CN printer has been detected and is being installed:", $"c3_7_6.png");
            var cap7 = UIService.CreateImageViewCaption($"Once the printer has been installed, it will likely need to be configured for network sharing. To achieve this, launch the Print Management tool, select the print server to which the printer is physically connected and click on Printers. The center pane of the tool will display a list of printers installed on the current print server. Identify the required printer in the list, double click on it to display the properties dialog and select the Sharing tab:", $"c3_7_7.png");
            var l14 = UIService.CreateTextItem($"If the printer is to be shared with network client, set the Share this printer check box and enter a suitable share name for the printer. This page also allows Client-side Rendering(CSR) to be configured. When selected, all rendering of print jobs is performed on the client and just the RAW print data sent to the server for printing. This offloads the rendering overhead to the client computers, thereby reducing the load, and increasing the scalability of the print server.", Color.White, Color.Transparent);
            var l15 = UIService.CreateTextItem($"If Windows fails to auto-detect the printer it may be added manually from Print Management by right clicking on the print server to which the device is attached and selecting Add Printer.... On the initial screen select the Add new printer using an existing port and choose the port to which the printer is connected from the drop down list. Once selected, click Next to install a printer driver. If one is already installed, select it from the drop down next to the use an existing printer driver on the computer. Alternatively, select Install a new printer driver and either select the printer make and model from the list, or use the Have Disk to install the manufacturer supplied driver. Click Next to proceed to the Printer Name and Sharing screen. Choose whether the printer is to be shared and, if so, by what name. Proceed to the summary screen, review the information and complete the installation.{ Environment.NewLine } With a printer server configured and printers added the next step is to cover the management of printer servers on Windows Server 2008.", Color.White, Color.Transparent);
            var l16 = UIService.CreateTextItem($"INSTALL PRINTER SERVER USING DEDICATED PRINTER SERVER", Color.Black, Color.Transparent, FontAttributes.Bold);
            var cap8 = UIService.CreateImageViewCaption($"We are using TP-link TL-PS110UPrinter server the default IP is 192.168.0.10", $"c3_7_8.png");
            var cap9 = UIService.CreateImageViewCaption($"Setup the Printer Server {Environment.NewLine}Edit the Printer Server Name", $"c3_7_9.png");
            var cap10 = UIService.CreateImageViewCaption($"Setup the TCP/IP Address to your desired IP", $"c3_7_10.png");
            var tt2 = UIService.CreateTitleText($"HERE ARE THE STEPS FOR THE RESETTING THE PRINTER SERVER.", 
                $"1.      Unplug the power adapter of print server;{ Environment.NewLine}2.Press the Reset key on the print server and hold;{ Environment.NewLine}3.Plug -in the power adapter with the Reset key pressing for no less than 7 seconds;{ Environment.NewLine}4.Release the Reset key.{ Environment.NewLine}For TL-WPS510U, when the Wireless LED light flashes regularly, the TL-WPS510U has finished the resetting and you can see the WLAN-PS Ad - Hoc network in your wireless network list.");
            var l17 = UIService.CreateTextItem($"HOW TO INSTALL PRINTER USING TCP/IP PORT.", Color.Black, Color.Transparent, FontAttributes.Bold);
            var cap11 = UIService.CreateImageViewCaption($"The following steps illustrate how to install a network printer using TCP/IP in Windows 7. In order to complete the steps you will need to know details such as the printer model and IP address. Click the Start button, type print in the Search programs and files box and click Add a printer", $"c3_7_11.png");
            var cap12 = UIService.CreateImageViewCaption($"⦁	Choose Add a local printer", $"c3_7_12.png");
            var cap13 = UIService.CreateImageViewCaption($"⦁	Click the bullet which says Create a new port and use the drop down menu to choose Standard TCP/IP Port ", $"c3_7_13.png");
            var cap14 = UIService.CreateImageViewCaption($"⦁	Click Next{Environment.NewLine}⦁	In the Hostname or IP Address field enter the IP Address for the printer you are adding{Environment.NewLine}Instuctions⦁	 for looking up your IP Address(authentication required)", $"c3_7_14.png");
            var cap15 = UIService.CreateImageViewCaption($"⦁	Click Next{ Environment.NewLine}⦁	Choose the driver that corresponds to your printer model(or click the Have Disk button to search for downloaded drivers)", $"c3_7_15.png");
            var cap16 = UIService.CreateImageViewCaption($"⦁	Click Next{ Environment.NewLine}⦁	Click the bullet beside Use the driver that is currently installed (recommended)", $"c3_7_16.png");
            var l18 = UIService.CreateTextItem($"⦁	Click Next{ Environment.NewLine}⦁	Take note of the name given to the printer{ Environment.NewLine}⦁	Click Next{ Environment.NewLine}⦁	Make sure the bullet is selected beside Do not share this printer{ Environment.NewLine}⦁	Click Next{ Environment.NewLine}⦁	Click to put a check mark beside of Set as the default printer(if you do wish to make it your default printer){ Environment.NewLine}⦁	Click the Print a test page button(if you wish to do so){ Environment.NewLine}⦁	Click Finish. Your printer should now be set up and ready to use.", Color.White, Color.Transparent);


            stack.Children.Add(l1);
            stack.Children.Add(gridT);
            stack.Children.Add(l2);
            stack.Children.Add(l3);
            stack.Children.Add(l4);
            stack.Children.Add(l5);
            stack.Children.Add(tt1);
            stack.Children.Add(l6);
            stack.Children.Add(l7);
            stack.Children.Add(cap1);
            stack.Children.Add(cap2);
            stack.Children.Add(cap3);
            stack.Children.Add(cap4);
            stack.Children.Add(l8);
            stack.Children.Add(l9);
            stack.Children.Add(cap5);
            stack.Children.Add(l10);
            stack.Children.Add(l11);
            stack.Children.Add(l12);
            stack.Children.Add(l13);
            stack.Children.Add(cap6);
            stack.Children.Add(cap7);
            stack.Children.Add(l14);
            stack.Children.Add(l15);
            stack.Children.Add(l16);
            stack.Children.Add(cap8);
            stack.Children.Add(cap9);
            stack.Children.Add(cap10);
            stack.Children.Add(tt2);
            stack.Children.Add(l17);
            stack.Children.Add(cap11);
            stack.Children.Add(cap12);
            stack.Children.Add(cap13);
            stack.Children.Add(cap14);
            stack.Children.Add(cap15);
            stack.Children.Add(cap16);
            stack.Children.Add(l18);
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
