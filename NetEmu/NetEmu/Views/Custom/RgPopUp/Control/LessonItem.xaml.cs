using NetEmu.Models;
using NetEmu.Services;
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
        private static readonly BindableProperty LessonProperty = BindableProperty.Create(nameof(Lesson), typeof(LessonModel), typeof(LessonItem),new LessonModel());


        public string LessonType {
            get => (string)GetValue(LessonTypeProperty);
            set => SetValue(LessonTypeProperty, value);
        }

        public string CoreIdentityGuid
        {
            get => (string)GetValue(CoreIdentityGuideProperty);
            set => SetValue(CoreIdentityGuideProperty, value);
        }
        public LessonModel Lesson
        {
            get => (LessonModel)GetValue(LessonProperty);
            set => SetValue(LessonProperty, value);
        }
        public LessonItem()
        {
            InitializeComponent();
            this.WidthRequest = Screen.GameWidth / 1.05f;
            this.HeightRequest = Screen.GameHeight / 4.5f;

        
        }

        private void Item_Tapped(object sender, EventArgs e)
        {
            OpenLesson(Lesson);
        }

        private async void OpenLesson(LessonModel lesson) {
            var createdLayout = new StackLayout();
            switch (lesson.LessonId) {
                case "Core1-1":
                    createdLayout = LessonService.Core1_1LessonView();
                    break;
                case "Core1-2":
                    createdLayout = LessonService.Core1_2LessonView();
                    break;
                case "Core1-3":
                    createdLayout = LessonService.Core1_3LessonView();
                    break;
                case "Core2-1":
                    createdLayout = LessonService.Core2_1LessonView();
                    break;
                case "Core2-2":
                    createdLayout = LessonService.Core2_2LessonView();
                    break;
                case "Core2-3":
                    createdLayout = LessonService.Core2_3LessonView();
                    break;
                case "Core3-1":
                    createdLayout = LessonService.Core3_1LessonView();
                    break;
                case "Core3-2":
                    createdLayout = LessonService.Core3_2LessonView();
                    break;
                case "Core3-3":
                    createdLayout = LessonService.Core3_3LessonView();
                    break;
                case "Core3-4":
                    createdLayout = LessonService.Core3_4LessonView();
                    break;
                case "Core3-5":
                    createdLayout = LessonService.Core3_5LessonView();
                    break;
                case "Core3-6":
                    createdLayout = LessonService.Core3_6LessonView();
                    break;
                case "Core3-7":
                    createdLayout = LessonService.Core3_7LessonView();
                    break;
                case "Core3-8":
                    createdLayout = LessonService.Core3_8LessonView();
                    break;
                case "Core3-9":
                    createdLayout = LessonService.Core3_9LessonView();
                    break;
            }

            await PopupNavigation.Instance.PushAsync(new LessonView(lesson.LessonTitle,createdLayout));
        }
    }
}