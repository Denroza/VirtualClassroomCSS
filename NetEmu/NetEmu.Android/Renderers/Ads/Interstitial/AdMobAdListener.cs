using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NetEmu.Droid.Renderers.Ads.Interstitial
{
    public class AdMobAdListener : AdListener
    {
        public delegate void AdLoadedEvent();
        public delegate void AdOpenedEvent();
        public delegate void AdClosedEvent();

        public event AdLoadedEvent AdLoaded;
        public event AdOpenedEvent AdOpened;
        public event AdClosedEvent AdClosed;


        public override void OnAdLoaded()
        {
            AdLoaded?.Invoke();
            base.OnAdLoaded();
        }

        public override void OnAdOpened()
        {
            AdOpened?.Invoke();
            base.OnAdOpened();
        }

        public override void OnAdClosed()
        {
            AdClosed?.Invoke();
            base.OnAdClosed();
        }
    }
}