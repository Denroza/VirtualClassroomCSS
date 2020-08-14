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
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NetEmu.Views.Layers
{
    public class ClassroomLayer : BaseLayer
    {
        private CCSprite ProfMale;
        private CCRepeatForever ProfAni;                                                              
        //private CCDialouge dialouge;
        private CCSpriteButton _terminal;
        private CCSpriteButton _labIcon;
        private CCSpriteButton _progressIcon;
        private CCSpriteButton _fileIcon;
        private CCSpriteButton _settingsIcon;


        private CCSpriteButton _SIIcon;
        private CCSpriteButton _SCIcon;
        private CCSpriteButton _NIIcon;



        private bool iconsShowed = false;
        private bool animationDone = false;
        private CCPoint initialPos;
        public ClassroomLayer()   : base()
        {
         

            ProfMale = AnimationManager.Instance.ProffesorSprite;
          
            ProfMale.Opacity = 0;
            
            this.AddChild(ProfMale,0);
            var fade = new CCFadeTo(2f,255);

            //_labIcon = new CCSpriteButton(ResourceManager.Instance.CircleButton,"LABORATORY",ResourceManager.Instance.FaceOffM54_Font,
            //   Screen.GameWidth / 10, Screen.GameWidth / 10);
        
           DialougeService.GameDialouge = new CCDialouge(ResourceManager.Instance.DialougeBox, Screen.DeviceWidth, Screen.DeviceHeight / 4.5f);
            
          //  dialouge.Opacity = 0;
            this.AddChild(DialougeService.GameDialouge, 1);
            ProfMale.RunAction(fade);

            _terminal = new CCSpriteButton(ResourceManager.Instance.TerminalIcon,Screen.GameWidth/10,Screen.GameHeight/12);
            _progressIcon = new CCSpriteButton(ResourceManager.Instance.ProgressIcon, Screen.GameWidth / 12, Screen.GameWidth / 12);
             _fileIcon = new CCSpriteButton(ResourceManager.Instance.FileIcon, Screen.GameWidth / 12, Screen.GameWidth / 12);
            _settingsIcon = new CCSpriteButton(ResourceManager.Instance.SettingsIcon, Screen.GameWidth / 12, Screen.GameWidth / 12);
       


            _progressIcon.Opacity = 0;
            _fileIcon.Opacity = 0;
            _settingsIcon.Opacity = 0;



            if (!UserServices.hasUserData)
            {
                _terminal.Visible = false;
               // _labIcon.Visible = false;
                DialougeService.GameDialouge.Introduction();
                Schedule(intro=> {
                    if (ScheduleTriggers.SayAfterAuth) {
                        ScheduleTriggers.SayAfterAuth = false;

                        _terminal.Visible = true ;
                    //    _labIcon.Visible = true;
                        DialougeService.GameDialouge.IntroAuthScript();
                    }
                });
            }
            else {
                DialougeService.GameDialouge.Greetings();

                _terminal.Visible = true;
               // _labIcon.Visible = true; 
            }

            SpriteButtonEvents();

            this.AddChild(_terminal);
           // this.AddChild(_labIcon);
            this.AddChild(_settingsIcon);
            this.AddChild(_progressIcon);
            this.AddChild(_fileIcon);
            
        }

        private void SpriteButtonEvents() {


            _fileIcon.Pressed = (touch, _event) => {
                _fileIcon.UpdateDisplayedColor(CCColor3B.Gray);
            };

            _fileIcon.Released = (touch, _event) => {
                if (_fileIcon.Opacity !=0)
                {
                    SoundManagers.Instance.PlayButtonClickSound();
                    _fileIcon.UpdateDisplayedColor(CCColor3B.White);
                    iconsShowed = false;
                    this.PauseListeners(true);
                    Scene.AddChild(UIService.ShowCoreIcons(Scene), 4);
                    HideIcons();
                    _fileIcon.Schedule(go => {
                        if (ScheduleTriggers.GotoLab)
                        {
                            ScheduleTriggers.GotoLab = false;
                            QuestionService.LoadQuestions();
                            AppSettings.CurrentScene = SceneManagers.SceneType.Lab;
                            SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                        }
                    });

                }

            };

            _settingsIcon.Pressed = (touch, _event) => {
                _settingsIcon.UpdateDisplayedColor(CCColor3B.Gray);
            };
            _settingsIcon.Released = (touch, _event) => {
                if (_settingsIcon.Opacity != 0 )
                {
                    SoundManagers.Instance.PlayButtonClickSound();
                    _settingsIcon.UpdateDisplayedColor(CCColor3B.White);
                    iconsShowed = false;
                    HideIcons();
                    Device.BeginInvokeOnMainThread(async () => {
                        await PopupNavigation.Instance.PushAsync(new SettingView());
                    });
                }
            
            };


            _terminal.Pressed = (touch, _event) => {
                _terminal.UpdateDisplayedColor(CCColor3B.Gray);
            };
            _terminal.Released = (touch, _event) => {

                if (!animationDone) {
                    _terminal.UpdateDisplayedColor(CCColor3B.White);
                    //AppSettings.CurrentScene = SceneManagers.SceneType.Menu;
                    //SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                    if (!iconsShowed)
                    {
                        SoundManagers.Instance.PlayButtonClickSound();
                        iconsShowed = true;
                        ShowIcons();
                    }
                    else
                    {
                        iconsShowed = false;
                        HideIcons();
                    }
                }
              
                  
            };
            DialougeService.GameDialouge.Pressed = (touch, _event) => {


            };
            DialougeService.GameDialouge.Released = (touch, _event) => {
                TasksToken.DialougeToken.Cancel();
            };

            //_labIcon.Pressed = (touch, _event) => {
            //    _labIcon.UpdateDisplayedColor(CCColor3B.Gray);
            //};
            //_labIcon.Released = (touch, _event) => {
            //    _labIcon.UpdateDisplayedColor(CCColor3B.White);
            //    DialougeService.GameDialouge.GotoLab();
            //    _labIcon.Schedule(go =>
            //    {
            //        if (ScheduleTriggers.GotoLab)
            //        {
            //            ScheduleTriggers.GotoLab = false;
            //            QuestionService.LoadSampleQuestions();
            //            AppSettings.CurrentScene = SceneManagers.SceneType.Lab;
            //            SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
            //        }

            //    });

            //};

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            //    ProfMale.Position = new CCPoint(ProfMale.ContentSize.Width /1.25f, ProfMale.ContentSize.Height/1.05f);
            DialougeService.GameDialouge.Position = new CCPoint(Screen.DeviceWidth/2, DialougeService.GameDialouge.ContentSize.Height/1.75f);
            ProfMale.RunAction(AnimationManager.Instance.ProfAnimation);
            _terminal.Position = new CCPoint(_terminal.ContentSize.Width/1.5f,Screen.GameHeight - _terminal.ContentSize.Height/1.15f);
        //    _labIcon.Position = new CCPoint(Screen.GameWidth - _labIcon.ContentSize.Width / 1.15f, _terminal.PositionY);
       
            initialPos = _terminal.Position;
            
        }

        private void ShowIcons() {
            animationDone = true;
            _progressIcon.Position = initialPos;
            var m1 = new CCMoveTo(0.15f, new CCPoint(initialPos.X,initialPos.Y - _progressIcon.ContentSize.Height * 1.5f)) ;
            var f1 = new CCFadeTo(0.15f,255);
            _progressIcon.RunActionsAsync(m1, f1).ContinueWith(next => {
                _fileIcon.Position = _progressIcon.Position;
                var m2 = new CCMoveTo(0.15f, new CCPoint(_progressIcon.Position.X, _progressIcon.Position.Y - _fileIcon.ContentSize.Height *1.05f ));
                var f2 = new CCFadeTo(0.15f, 255);
                _fileIcon.RunActionsAsync(m2, f2).ContinueWith(last => {
                    _settingsIcon.Position = _fileIcon.Position;
                    var m3 = new CCMoveTo(0.15f, new CCPoint(_fileIcon.Position.X, _fileIcon.Position.Y - _settingsIcon.ContentSize.Height * 1.05f));
                    var f3 = new CCFadeTo(0.15f, 255);
                    _settingsIcon.RunActionsAsync(m3,f3).ContinueWith(done=> {
                        animationDone = false;
                    });
                });
            });
        }

        private void HideIcons() {
            animationDone = true;
            var m1 = new CCMoveTo(0.15f, new CCPoint(_fileIcon.Position.X, _fileIcon.Position.Y));
            var f1 = new CCFadeTo(0.15f, 0);
            _settingsIcon.RunActionsAsync(m1, f1).ContinueWith(next => {
          
                var m2 = new CCMoveTo(0.15f, new CCPoint(_progressIcon.Position.X, _progressIcon.Position.Y));
                var f2 = new CCFadeTo(0.15f, 0);
                _fileIcon.RunActionsAsync(m2, f2).ContinueWith(last => {
                   
                    var m3 = new CCMoveTo(0.15f, new CCPoint(initialPos.X, initialPos.Y));
                    var f3 = new CCFadeTo(0.15f, 0);
                    _progressIcon.RunActionsAsync(m3, f3).ContinueWith(done => {
                        animationDone = false;
                    });
                });
            });
        }

   
    }
}
