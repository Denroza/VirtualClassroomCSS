using NetEmu.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetEmu
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new GamePage();
        }

        protected override async void OnStart()
        {
              UserServices.hasUserData =  await  UserServices.LoadUserData();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static string BaseColor { get { return "#447D95"; } }
        public static string PrimaryColor { get { return "#504A30"; } }
        public static string PrimaryTextColor { get { return "#FFFFFF"; } }
        public static string SecondaryTextColor { get { return "#D7B966"; } }
        public static string PressedColor { get { return "#C8C8C8"; } }
        public static string DisableColor { get { return "#838383"; } }
        public static string CorrectTextColor { get { return "#2EC60B"; } }
        public static string WrongTextColor { get { return "#E5130C"; } }
    }
}
