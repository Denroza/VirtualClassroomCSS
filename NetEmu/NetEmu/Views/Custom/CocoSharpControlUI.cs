using NetEmu.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetEmu.Views.Custom
{
     public   class CocoSharpControlUI
    {
        public static void DisplayAlert(string title, string message)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var display = ((Grid)GamePage.CocosSharpView.Parent).Parent as Page;
                await display.DisplayAlert(title, message, "OK");
            });

        }

        public static void InputDialouge(string title, string message)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var display = ((Grid)GamePage.CocosSharpView.Parent).Parent as Page;
               var name =  await display.DisplayPromptAsync(title, message, "OK");
                if (!string.IsNullOrEmpty(name))
                {
                    await Task.WhenAll(UserServices.SaveUserData("", name, "", Models.Enum.EnumCollection.Gender.Default)).ContinueWith(async s => {
                        CocoSharpControlUI.DisplayAlert("Notice", "Registration Complete!");

                       
                        await UserServices.LoadUserData();
                    }).ContinueWith(intro => {
                        ScheduleTriggers.SayAfterAuth = true;
                    });
                }
                else {
                    CocoSharpControlUI.DisplayAlert("","Invalid Input. Try again!");
                    InputDialouge(title,message);
                }
            });

        }
    }
}
