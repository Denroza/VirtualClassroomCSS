using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Content;

namespace NetEmu.Droid
{
    [Activity(Label = "NetEmu", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            base.OnCreate(savedInstanceState);
            Forms.SetFlags("CollectionView_Experimental");
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
           // mScreenListener.unregisterListener();
        }

        protected override void OnResume()
        {
            //if (isPaused == true)
            //{

            //    if (SoundManagers.Instance.IsMusicMute == false)
            //    {
            //        if (SoundManagers.Instance.IsGameMusicPlaying)
            //        {
            //            SoundManagers.Instance.PlayGameMusic();
            //        }
            //        else if (SoundManagers.Instance.IsMenuMusicPlaying)
            //        {
            //            SoundManagers.Instance.PlayMenuMusic();
            //        }

            //    }


            //}
            base.OnResume();


         //   mScreenListener.begin(this);

        }
        protected override void OnPause()
        {

         //   isPaused = true;
            base.OnPause();


        }
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }

        //protected override void OnStop()
        //{
        //    base.OnStop();
        //    if (App.OpenCamera == false)
        //    {
        //        Intent main = new Intent(Intent.ActionMain);
        //        main.AddCategory(Intent.CategoryHome);
        //        StartActivity(main);
        //    }

        //}

        public void onScreenOn()
        {

            System.Diagnostics.Debug.WriteLine("onScreenOn");
            GamePage._cocosSharpView.Paused = true;
            GamePage._cocosSharpView.Paused = false;

        }

        public void onScreenOff()
        {

            System.Diagnostics.Debug.WriteLine("onScreenOff");

            //if (SoundManagers.Instance.IsMusicMute == false)
            //{

            //    SoundManagers.Instance.StopBackgroundMusic();
            //}

            GamePage._cocosSharpView.Paused = true;
            GamePage._cocosSharpView.Paused = false;


        }

        public void onUserPresent()
        {
            //Intent main = new Intent(Intent.ActionMain);
            //   main.AddCategory(Intent.);
            //   StartActivity(main);
            //   Forms.Context.StartActivity((Forms.Context as Activity).Intent);
            //onScreenOn();
            //Intent intent = new Intent(this, typeof(Bundle));
            //intent.PutExtra("currentpage", bundle.ToString());
            //StartActivity(intent);
            //GamePage._cocosSharpView.Paused = true;
            //GamePage._cocosSharpView.Paused = false;
            System.Diagnostics.Debug.WriteLine("onUserPresent");
        }

        public void onDreamingStarted()
        {
            System.Diagnostics.Debug.WriteLine("onDreamingStarted");
        }

        public void onDreamingStopped()
        {
            GamePage._cocosSharpView.Paused = false;
            System.Diagnostics.Debug.WriteLine("onDreamingStopped");
        }


        protected override void OnRestart()
        {
            base.OnRestart();
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("counter", 1);
            base.OnSaveInstanceState(outState);
        }
        static Bundle bundle;
        protected override void OnRestoreInstanceState(Bundle savedState)
        {
            base.OnRestoreInstanceState(savedState);
            bundle = savedState;

        }

    }
}