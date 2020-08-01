using NetEmu.Extensions;
using NetEmu.Views.Custom.RgPopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetEmu.Services
{
    public static class DialougeService
    {

        public static CCDialouge GameDialouge { get; set; }

        public static CCDialouge GameLabDialouge { get; set; }

        public static async void Introduction(this CCDialouge dialouge )
        {
            await dialouge.AddScript("Prof. Danny", "Kumusta at maligayang pagdating sa CSS Virtual Classroom, Mukhang bago kang studyante paki-lagdaan muna ang iyong impormasyon.").ContinueWith(s => {
                Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.Instance.PushAsync(new AuthenticationView()); });
            });
        }

        public static async  void Greetings(this CCDialouge dialouge) {
           await dialouge.AddScript("Prof. Danny",$"Maligayang pagbabalik {UserServices.User.Name}, ano ang nais mong matutunan sa araw na ito.");
        }

        public static async void IntroAuthScript(this CCDialouge dialouge) {
            await dialouge.AddScript("Prof. Danny",$"Ikinagagalak ko ang iyong pag dating sa CSS Virtual Classroom {UserServices.User.Name}, Sana ay marami kang matutnan dito.");
        }

        public static async void GotoLab(this CCDialouge dialouge) {
            await dialouge.AddScript("Prof. Danny", $"Galingang mo ang pag sagot, {UserServices.User.Name}.").ContinueWith(s => {
                ScheduleTriggers.GotoLab = true;
            });
        }
    }
}
