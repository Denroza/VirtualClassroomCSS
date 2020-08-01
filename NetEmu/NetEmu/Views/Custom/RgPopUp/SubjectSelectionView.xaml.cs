using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetEmu.Views.Custom.RgPopUp.Control;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NetEmu.Services.IndentifierServices;

namespace NetEmu.Views.Custom.RgPopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectSelectionView : PopupPage
    {
       
        public SubjectSelectionView(CoreIdentity core = CoreIdentity.Default)
        {
            InitializeComponent();
         
            PopulateBody(core);
        }


        private void PopulateBody(CoreIdentity core) {

            var item = new SelectionView(core);
            ItemBody.Children.Add(item);
            //switch (core)
            //{

            //    case CoreIdentity.Core1:
            //        //for (int i = 0; i < 3; i++)
            //        //{
            //        //    var item = new LessonItem() { LessonType = "E" };

            //        //    ItemBody.Children.Add(item);
            //        //}
            //        var item = new SelectionView(core);
            //        ItemBody.Children.Add(item);
            //        break;
            //    case CoreIdentity.Core2:
            //        var item = new SelectionView(core);
            //        ItemBody.Children.Add(item);
            //        break;
            //    case CoreIdentity.Core3:
            //        var item = new SelectionView(core);
            //        ItemBody.Children.Add(item);
            //        break;


            //}

        }

        private async void ClosePage()
        {

            await PopupNavigation.Instance.RemovePageAsync(this);
        }
       
    }
}