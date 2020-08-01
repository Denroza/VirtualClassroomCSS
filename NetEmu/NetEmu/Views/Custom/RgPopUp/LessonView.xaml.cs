using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetEmu.Views.Custom.RgPopUp.Control;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetEmu.Views.Custom.RgPopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonView : PopupPage
    {
        public LessonView(string title = "", View view = null)
        {
            InitializeComponent();
            TitleLabel.Text = title;
            if(view != null)
                ItemContainer.Children.Add(view);

        }

      
    }
}