using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NetEmu.Models.Ads;
using Plugin.CurrentActivity;

namespace NetEmu.Droid.Renderers.Ads.Interstitial
{
    public class AdInterstitial : IAdInterstitial
    {
        public Action AdClosed { get; set; }
        public Action AdReady { get; set; }
        public Action<int> AdFailedToLoad { get; set; }

        private InterstitialAd _interstitialAd;

        public AdInterstitial()
        {
            InitAd();
            LoadAd();
        }

        public void ShowAd()
        {
            if (_interstitialAd == null)
            {
                InitAd();
                LoadAd();
            }

            do
            {
                Task.Delay(1);
            }
            while (!_interstitialAd.IsLoaded);
            _interstitialAd.Show();
        }

        public void LoadGameAd()
        {
            if (_interstitialAd == null)
            {
                InitAd();
                LoadAd();
            }
        }
        public void ShowGameAd()
        {
            _interstitialAd.Show();
        }
        public void InitAd()
        {
            _interstitialAd = new InterstitialAd(CrossCurrentActivity.Current.Activity);
     //       _interstitialAd.AdUnitId = App.InterstitialAndroidId;
            var adListener = new AdMobAdListener();
            adListener.AdClosed += () =>
            {
                AdClosed?.Invoke();

                _interstitialAd.Dispose();
                _interstitialAd = null;
            };
            adListener.AdLoaded += () =>
            {
                AdReady?.Invoke();
            };
            _interstitialAd.AdListener = adListener;
        }

        public void LoadAd()
        {
            // Request
            var requestBuilder = new AdRequest.Builder();
            //            20E75139BBF24DC580420774CC012DCD
            //20949F1881259988F94C570F5D49D8E9
            //.addTestDevice("1FFA91E56002E80EC2232FD6A6053E5B")
            requestBuilder.AddTestDevice("253DD8B545DDC577263C615CE187A856");
            requestBuilder.AddTestDevice("9AC63F0BB5D8E04512D0A4ED0202C018");
            requestBuilder.AddTestDevice("17F5056C2003A19B27CF2896B7BE699D");
            requestBuilder.AddTestDevice("20E75139BBF24DC580420774CC012DCD");
            requestBuilder.AddTestDevice("20949F1881259988F94C570F5D49D8E9");
            requestBuilder.AddTestDevice("1FFA91E56002E80EC2232FD6A6053E5B");
            requestBuilder.AddTestDevice("2A26CA09A9309EE2CCDA1B239A1472D1");
            _interstitialAd.LoadAd(requestBuilder.Build());
        }
    }
}