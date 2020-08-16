using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetEmu.Views.Custom.RgPopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingView : PopupPage
    {
        public SettingView()
        {
            InitializeComponent();
        }

        private void music_switch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void music_slider_DragCompleted(object sender, EventArgs e)
        {

        }

        private void sound_switch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void sound_slider_DragCompleted(object sender, EventArgs e)
        {

        }
    }
}