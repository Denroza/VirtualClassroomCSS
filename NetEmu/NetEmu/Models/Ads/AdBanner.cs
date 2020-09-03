using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetEmu.Models.Ads
{
    public class AdBanner : View
    {
        public enum Sizes
        {
            Standardbanner,
            LargeBanner,
            MediumRectangle,
            FullBanner,
            Leaderboard,
            SmartBannerPortrait
        }

        public Sizes Size { get; set; }

        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
                   nameof(AdUnitId),
                   typeof(string),
                   typeof(AdBanner),
                   string.Empty);

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }

        public AdBanner()
        {
            this.BackgroundColor = Color.Accent;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                   // this.AdUnitId = App.AdBanneriOSId;
                    break;
                case Device.Android:
                  //  this.AdUnitId = App.AdBannerAndroidId;
                    break;
            }
        }


    }
}
