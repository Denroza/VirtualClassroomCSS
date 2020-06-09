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
    public partial class SubjectSelectionView : PopupPage
    {
        public SubjectSelectionView()
        {
            InitializeComponent();

            PopulateBody();
        }

        private void PopulateBody() {
            for (int i = 0; i < 10; i++) {
                var item = new LessonItem() { LessonType = "E" };

                ItemBody.Children.Add(item);
            }
        }
    }
}