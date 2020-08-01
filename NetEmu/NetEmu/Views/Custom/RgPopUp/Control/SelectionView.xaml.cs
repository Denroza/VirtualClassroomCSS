using NetEmu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NetEmu.Services.IndentifierServices;

namespace NetEmu.Views.Custom.RgPopUp.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionView : ContentView
    {
        public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(nameof(CardWidth), typeof(float), typeof(SelectionView), Screen.DeviceWidth / 1.15f);
        public static readonly BindableProperty CardHeightProperty = BindableProperty.Create(nameof(CardHeight), typeof(float), typeof(SelectionView), Screen.DeviceHeight / 5f);

        public float CardWidth
        {
            get => (float)GetValue(SelectionView.CardWidthProperty);
            set => SetValue(SelectionView.CardWidthProperty, value);
        }

        public float CardHeight
        {
            get => (float)GetValue(SelectionView.CardHeightProperty);
            set => SetValue(SelectionView.CardHeightProperty, value);
        }

       

        public SelectionView(CoreIdentity core)
        {
            InitializeComponent();
            switch (core) {
                case CoreIdentity.Core1:
                    this.WidthRequest = Screen.GameWidth / 1.05f;
                    this.HeightRequest = Screen.GameHeight / 1.5f;

                    foreach (var items in LessonService.Core1Lessons) {
                        var view = new LessonItem() {
                         LessonType = items.LessonTitle ,
                         CoreIdentityGuid = items.LessonId
                         
                        };
                        SubjectList.Children.Add(view);
                    }
                    break;
                case CoreIdentity.Core2:
                    this.WidthRequest = Screen.GameWidth / 1.05f;
                    this.HeightRequest = Screen.GameHeight / 1.5f;
                    foreach (var items in LessonService.Core2Lessons)
                    {
                        var view = new LessonItem()
                        {
                            LessonType = items.LessonTitle,
                            CoreIdentityGuid = items.LessonId
                        };
                        SubjectList.Children.Add(view);
                    }
                    break;
                case CoreIdentity.Core3:
                    this.WidthRequest = Screen.GameWidth / 1.05f;
                    this.HeightRequest = Screen.GameHeight / 1.05f;
                    foreach (var items in LessonService.Core3Lessons)
                    {
                        var view = new LessonItem()
                        {
                            LessonType = items.LessonTitle,
                            CoreIdentityGuid = items.LessonId
                        };
                        SubjectList.Children.Add(view);
                    }
                    break;
            }
         
        }

     
    }
}