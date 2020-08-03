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
    public partial class ShowImageView : PopupPage
    {
        public ShowImageView(string source = "")
        {
            InitializeComponent();
            ImageToShow.Source = source;
        }
    }
}