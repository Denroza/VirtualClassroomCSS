using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NetEmu.Droid.Renderers.Ads.Banners;
using NetEmu.Droid.Renderers.Ads.Interstitial;
using NetEmu.Models.Ads;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBannerRenderer))]
namespace NetEmu.Droid.Renderers.Ads.Banners
{
    public class AdBannerRenderer : ViewRenderer<AdBanner, AdView>
    {
        private MainActivity _mainActivity;
        private FrameLayout.LayoutParams _layoutParams;

        private Context _context;
        private AdView _adView;
        private AdSize _adSize;

        public AdBannerRenderer(Context context) : base(context)
        {
            this._context = context;

            _mainActivity = (MainActivity)CrossCurrentActivity.Current.Activity;

            // Position
            _layoutParams = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            _layoutParams.Gravity = GravityFlags.Bottom;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdBanner> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(_adView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var adBanner = (AdBanner)sender;
            if (adBanner != null)
            {
                if (adBanner.IsVisible == false)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            _adView.Visibility = ViewStates.Gone;
                            ((FrameLayout)_mainActivity.Window.DecorView.RootView).RemoveView(_adView);
                            _adView.RemoveAllViews();
                            _adView.Destroy();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Error on removing ads: " + ex.ToString());
                        }

                    });
                }
            }

            if (e.PropertyName == nameof(AdView.AdUnitId))
                Control.AdUnitId = Element.AdUnitId;
        }

        private AdView CreateNativeAdControl()
        {
            if (_adView != null)
                return _adView;

            _adView = new AdView(_context);
            switch ((Element as AdBanner).Size)
            {
                case AdBanner.Sizes.Standardbanner:
                    _adSize = AdSize.Banner;
                    break;
                case AdBanner.Sizes.LargeBanner:
                    _adSize = AdSize.LargeBanner;
                    break;
                case AdBanner.Sizes.MediumRectangle:
                    _adSize = AdSize.MediumRectangle;
                    break;
                case AdBanner.Sizes.FullBanner:
                    _adSize = AdSize.FullBanner;
                    break;
                case AdBanner.Sizes.Leaderboard:
                    _adSize = AdSize.Leaderboard;
                    break;
                case AdBanner.Sizes.SmartBannerPortrait:
                    _adSize = AdSize.SmartBanner;
                    break;
                default:
                    _adSize = AdSize.Banner;
                    break;
            }
            _adView.AdSize = _adSize;
            _adView.AdUnitId = Element.AdUnitId;//App.AdBannerAndroidId;

            // Listener
            var adListender = new AdMobAdListener();
            adListender.AdLoaded += () =>
            {
                if (_adView != null && _mainActivity != null)
                {
                    try
                    {
                        if (((FrameLayout)_mainActivity.Window.DecorView.RootView).ChildCount <= 1)
                        {
                            _adView.RemoveFromParent();
                            _mainActivity.AddContentView(_adView, _layoutParams);
                        }
                        else
                        {
                            _adView.RemoveFromParent();
                            _mainActivity.AddContentView(_adView, _layoutParams);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error on adbanner: " + ex.ToString());
                    }

                }
            };
            _adView.AdListener = adListender;

            // Request
            var requestBuilder = new AdRequest.Builder()
                .AddTestDevice("253DD8B545DDC577263C615CE187A856")
                .AddTestDevice("9AC63F0BB5D8E04512D0A4ED0202C018")
                .AddTestDevice("17F5056C2003A19B27CF2896B7BE699D")
                .AddTestDevice("1FFA91E56002E80EC2232FD6A6053E5B")
                .AddTestDevice("EF2FB4F833AC923EA0F252688E9D2E4F")
                .AddTestDevice("BB9BA0C2D59E75E7E43DB74D4425C0FE")
                 .AddTestDevice("20E75139BBF24DC580420774CC012DCD")
                  .AddTestDevice("20949F1881259988F94C570F5D49D8E9")
                  .AddTestDevice("2A26CA09A9309EE2CCDA1B239A1472D1")
                .Build()
            ;
            //requestBuilder.AddTestDevice("253DD8B545DDC577263C615CE187A856");
            //requestBuilder.AddTestDevice("9AC63F0BB5D8E04512D0A4ED0202C018");
            //requestBuilder.AddTestDevice("17F5056C2003A19B27CF2896B7BE699D");
            //requestBuilder.AddTestDevice("1FFA91E56002E80EC2232FD6A6053E5B");
            //requestBuilder.AddTestDevice("EF2FB4F833AC923EA0F252688E9D2E4F");
            //requestBuilder.AddTestDevice("BB9BA0C2D59E75E7E43DB74D4425C0FE");
            //            20E75139BBF24DC580420774CC012DCD
            //20949F1881259988F94C570F5D49D8E9
            //requestBuilder.AddTestDevice("1FFA91E56002E80EC2232FD6A6053E5B");
            //.addTestDevice("1FFA91E56002E80EC2232FD6A6053E5B")
            _adView.LoadAd(requestBuilder);

            return _adView;
        }
    }
}