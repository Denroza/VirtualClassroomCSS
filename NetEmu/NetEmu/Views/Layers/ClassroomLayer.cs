using CocosSharp;
using NetEmu.Extensions;
using NetEmu.Managers;
using NetEmu.Services;
using NetEmu.Utilities;
using NetEmu.Views.Custom.RgPopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NetEmu.Views.Layers
{
    public class ClassroomLayer : BaseLayer
    {
        private CCSprite ProfMale;
        private CCRepeatForever ProfAni;
        private CCDialouge dialouge;
        private CCSpriteButton _terminal;
        public ClassroomLayer()   : base()
        {
         

            ProfMale = AnimationManager.Instance.ProffesorSprite;
          
            ProfMale.Opacity = 0;
            
            this.AddChild(ProfMale,0);
            var fade = new CCFadeTo(2f,255);
            ;
            dialouge = new CCDialouge(ResourceManager.Instance.DialougeBox, Screen.DeviceWidth, Screen.DeviceHeight / 4.5f);
            
          //  dialouge.Opacity = 0;
            this.AddChild(dialouge,1);
            ProfMale.RunAction(fade);

            _terminal = new CCSpriteButton(ResourceManager.Instance.TerminalIcon,Screen.GameWidth/10,Screen.GameHeight/12);
            _terminal.Pressed = (touch, _event) => {
                _terminal.UpdateDisplayedColor(CCColor3B.Gray);
            };
            _terminal.Released = (touch, _event) => {
                _terminal.UpdateDisplayedColor(CCColor3B.White);
                AppSettings.CurrentScene = SceneManagers.SceneType.Menu;
                SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
            };
            dialouge.Pressed = (touch, _event) => { };
            dialouge.Released = (touch, _event) => {
            
            };
            if (!UserServices.hasUserData) {
                Introduction();
            }

            this.AddChild(_terminal);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
        //    ProfMale.Position = new CCPoint(ProfMale.ContentSize.Width /1.25f, ProfMale.ContentSize.Height/1.05f);
            dialouge.Position = new CCPoint(Screen.DeviceWidth/2, dialouge.ContentSize.Height/1.75f);
            ProfMale.RunAction(AnimationManager.Instance.ProfAnimation);
            _terminal.Position = new CCPoint(_terminal.ContentSize.Width/1.5f,Screen.GameHeight - _terminal.ContentSize.Height/1.15f);
        }

        private async  void Introduction() {
          await  dialouge.AddScript("Prof. Danny", "Kumusta at maligayang pagdating sa CSS Virtual Class Room, since bago kang studyante paki-lagdaan muna ang iyong impormasyon.").ContinueWith(s=> {
              Device.BeginInvokeOnMainThread(async () => { await PopupNavigation.Instance.PushAsync(new AuthenticationView()); });
          });
           
              
               
         
        }
    }
}
