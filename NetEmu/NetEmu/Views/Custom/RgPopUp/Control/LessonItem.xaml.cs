using NetEmu.Utilities;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetEmu.Views.Custom.RgPopUp.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonItem : ContentView
    {

        private static readonly BindableProperty LessonTypeProperty = BindableProperty.Create(nameof(LessonType),typeof(string),typeof(LessonItem),string.Empty);
        private static readonly BindableProperty CoreIdentityGuideProperty = BindableProperty.Create(nameof(CoreIdentityGuid), typeof(string), typeof(LessonItem), string.Empty);


        public string LessonType {
            get => (string)GetValue(LessonTypeProperty);
            set => SetValue(LessonTypeProperty, value);
        }

        public string CoreIdentityGuid
        {
            get => (string)GetValue(CoreIdentityGuideProperty);
            set => SetValue(CoreIdentityGuideProperty, value);
        }
        public LessonItem()
        {
            InitializeComponent();
            this.WidthRequest = Screen.GameWidth / 1.05f;
            this.HeightRequest = Screen.GameHeight / 5.5f;

        
        }

        private void Item_Tapped(object sender, EventArgs e)
        {
            OpenLesson();
        }

        private async void OpenLesson() {
            await PopupNavigation.Instance.PushAsync(new LessonView());
        }
    }
}