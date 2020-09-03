using NetEmu.Extensions;
using NetEmu.Managers;
using NetEmu.Views.Custom;
using NetEmu.Views.Custom.RgPopUp;
using NetEmu.Views.Layers;
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
                //  Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.Instance.PushAsync(new AuthenticationView()); });
                CocoSharpControlUI.InputDialouge("","Enter Name:");
            });
        }

        public static async void TerminalExplanation(this CCDialouge dialouge)
        {
            await dialouge.AddScript("Prof. Danny", "Ito ang iyong terminal kung saan matatagpuan mo ang iyong \"Data\" at ang \"Settings\" ng application na ito.").ContinueWith( s => {
                ScheduleTriggers.ShowTerminl = true;
            });
        }

        public static async  void Greetings(this CCDialouge dialouge) {
           await dialouge.AddScript("Prof. Danny",$"Ano ang nais mong matutunan sa araw na ito. {UserServices.User.Name}").ContinueWith(async w=> {
               await AnimationManager.Instance.MoveDanny(AnimationManager.DannyPosition.Right, 1.5f, 0.5f).ContinueWith(async a=> {
                   ClassroomLayer.ModuleSelection(true);
               }) ;
           });
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
