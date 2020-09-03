using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Models.Ads
{
    public interface IAdInterstitial
    {
        Action AdClosed { get; set; }
        Action AdReady { get; set; }
        Action<int> AdFailedToLoad { get; set; }
        void ShowAd();
        void LoadGameAd();
        void ShowGameAd();
    }
}
