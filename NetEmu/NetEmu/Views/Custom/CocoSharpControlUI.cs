using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetEmu.Views.Custom
{
     public   class CocoSharpControlUI
    {
        public static void DisplayAlert(string title, string message)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var display = ((Grid)GamePage.CocosSharpView.Parent).Parent as Page;
                await display.DisplayAlert(title, message, "OK");
            });

        }

    }
}
