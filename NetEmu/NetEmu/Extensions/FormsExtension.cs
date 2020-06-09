using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetEmu.Extensions
{
    public static class FormsExtension
    {
        public static void ButtonAnimation(this Grid grid)
        {

            foreach (var child in grid.Children)
            {
                var emu = child as View;
                Task.WhenAll(emu.ScaleTo(.9f, 250, Easing.Linear)
                   //  emu.ScaleTo(1f, 850, Easing.SpringOut)
                   ).ContinueWith(task => {
                       Task.WhenAll(emu.ScaleTo(1f, 250, Easing.Linear));
                   }); ;
            }

        }
    }
}
