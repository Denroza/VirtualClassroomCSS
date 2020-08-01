using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NetEmu.Models.Enum;
using static NetEmu.Models.Enum.EnumCollection;
using NetEmu.Extensions;
using NetEmu.Services;
using NetEmu.Utilities;
using Rg.Plugins.Popup.Services;

namespace NetEmu.Views.Custom.RgPopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationView : PopupPage
    {


        public AuthenticationView()
        {
            InitializeComponent();
                this.WidthRequest = Screen.GameWidth / 1.5f;
            this.HeightRequest = Screen.GameHeight / 1.5f;

            lbl_head.FontSize = CustomSize.resizeFont("STUDENT INFORMATION",(float)this.WidthRequest/2.85f);
            this.ScaleX = 0;
            this.ScaleY = 0;
            var id = Guid.NewGuid().ToString();
            lbl_id.Text = id;
            pck_gender.ItemsSource = new List<string>() { Gender.Male.ToString(), Gender.Female.ToString() };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.ScaleXTo(1,500,Easing.Linear);
            this.ScaleYTo(1,500,Easing.Linear);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return true;
        }

        private  void ImageButton_Clicked(object sender, EventArgs e)
        {
            RegisterButton.ButtonAnimation();

            var id = lbl_id.Text;
            var name = ety_Name.Text;
            var nName = ety_NickName.Text;
            var gender = pck_gender.SelectedItem?.ToString() == Gender.Male.ToString() ? Gender.Male: Gender.Female;
            //CocoSharpControlUI.DisplayAlert("Data",$"ID: {id}{Environment.NewLine}" +
            //    $"Name: {name}{Environment.NewLine}" +
            //    $"NickName: {nName}{Environment.NewLine}" +
            //    $"Gender: {gender}");
            bool headsup = false;
            Device.BeginInvokeOnMainThread(async () => {
                headsup = await DisplayAlert("Notice!","Are you done?","Confirm","Cancel");
                if (headsup)
                {
                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(gender.ToString()))
                    {
                        try
                        {
                          await  Task.WhenAll(UserServices.SaveUserData(id, name, nName, gender)).ContinueWith(async s => {
                                CocoSharpControlUI.DisplayAlert("Notice", "Registration Complete!");

                                await PopupNavigation.Instance.PopAllAsync();
                                await UserServices.LoadUserData();
                            }).ContinueWith(intro=> {
                                ScheduleTriggers.SayAfterAuth = true;
                            });
                        }
                        catch (Exception ex)
                        {

                            CocoSharpControlUI.DisplayAlert("Warning", "Register Failed, Please try again.");
                            return;
                        }
                    }
                    else
                    {

                        CocoSharpControlUI.DisplayAlert("Warning", "Please fill up your name and gender");
                    }

                }
            });


        }
    }
}