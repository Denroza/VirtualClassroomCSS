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
        private static CCSpriteButton _terminal;
        private CCSpriteButton _labIcon;
        private CCSpriteButton _progressIcon;
        private CCSpriteButton _fileIcon;
        private CCSpriteButton _settingsIcon;


        private static CCSpriteButton _SIIcon;
        private static CCSpriteButton _SCIcon;
        private static CCSpriteButton _NIIcon;

        private static CCSpriteButton _QAIcon;

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
             _SIIcon = new CCSpriteButton(ResourceManager.Instance.SIButton, Screen.GameWidth / 5, Screen.GameWidth / 5);
             _SCIcon = new CCSpriteButton(ResourceManager.Instance.SCButton, Screen.GameWidth / 5, Screen.GameWidth / 5);
             _NIIcon = new CCSpriteButton(ResourceManager.Instance.NIButton, Screen.GameWidth / 5, Screen.GameWidth / 5);
             _QAIcon = new CCSpriteButton(ResourceManager.Instance.QAButton, Screen.GameWidth / 5f, Screen.GameWidth / 5);


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
                    _terminal.Position = new CCPoint(_terminal.ContentSize.Width / 1.5f, ProfMale.PositionY);
                        _terminal.Opacity = 0;
                        _terminal.Visible = true;
                    //    _labIcon.Visible = true;
                        DialougeService.GameDialouge.TerminalExplanation();
                    }
                });
                Schedule(async show => {
                    if (ScheduleTriggers.ShowTerminl)
                    {
                        ScheduleTriggers.ShowTerminl = false;
                        //    _labIcon.Visible = true;
                        var shows = new CCFadeTo(0.8f,255);
                       await AnimationManager.Instance.MoveDanny( AnimationManager.DannyPosition.Right).ContinueWith(async s=> {
                                 
                       });
                        await _terminal.RunActionAsync(shows).ContinueWith(async b => {
                            var move = new CCMoveTo(0.5f, initialPos);
                            _terminal.RunAction(move);
                            await AnimationManager.Instance.MoveDanny(AnimationManager.DannyPosition.Middle,1,0.8f);
                        }).ContinueWith(async c=> {
                            DialougeService.GameDialouge.Greetings();
                        }); ;
                    }
                });
            }
            else {
                DialougeService.GameDialouge.Greetings();

                _terminal.Visible = true;
               // _labIcon.Visible = true; 
            }

            SpriteButtonEvents();
            MusicAndSoundSchedules();
            LayerSchedules();
            this.AddChild(_terminal);
           // this.AddChild(_labIcon);
            this.AddChild(_settingsIcon);
            this.AddChild(_progressIcon);
            this.AddChild(_fileIcon);
            this.AddChild(_SIIcon);
            this.AddChild(_SCIcon);
            this.AddChild(_NIIcon);
            this.AddChild(_QAIcon);

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
                    //this.PauseListeners(true);
                    //Scene.AddChild(UIService.ShowCoreIcons(Scene), 4);
                    //HideIcons();
                    //_fileIcon.Schedule(go => {
                    //    if (ScheduleTriggers.GotoLab)
                    //    {
                    //        ScheduleTriggers.GotoLab = false;
                    //        QuestionService.LoadQuestions();
                    //        AppSettings.CurrentScene = SceneManagers.SceneType.Lab;
                    //        SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                    //    }
                    //});

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
            ProfMale.RunAction(AnimationManager.Instance.ProfAnimation);
            ModuleEvents();
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            //    ProfMale.Position = new CCPoint(ProfMale.ContentSize.Width /1.25f, ProfMale.ContentSize.Height/1.05f);
            DialougeService.GameDialouge.Position = new CCPoint(Screen.DeviceWidth/2, DialougeService.GameDialouge.ContentSize.Height/1.75f);
   
            _terminal.Position = new CCPoint(_terminal.ContentSize.Width/1.5f,Screen.GameHeight - _terminal.ContentSize.Height/1.15f);
            _SIIcon.Position = new CCPoint(-(_SIIcon.ContentSize.Width/2), _terminal.PositionY-_terminal.ContentSize.Height * 1.45f);
            _SCIcon.Position = new CCPoint(_SIIcon.PositionX, _SIIcon.PositionY - _SCIcon.ContentSize.Height * 1.15f);
            _NIIcon.Position = new CCPoint(_SIIcon.PositionX, _SCIcon.PositionY - _NIIcon.ContentSize.Height * 1.15f);
            _QAIcon.Position = new CCPoint(_SIIcon.PositionX, _NIIcon.PositionY - _QAIcon.ContentSize.Height * 1.15f);
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

        public static void ModuleSelection(bool shown = false) {
            //_SIIcon.Position = new CCPoint(_SIIcon.ContentSize.Width * 1.25f, _terminal.PositionY - _terminal.ContentSize.Height * 1.45f);
            //_SCIcon.Position = new CCPoint(_SIIcon.PositionX, _SIIcon.PositionY - _SCIcon.ContentSize.Height * 1.15f);
            //_NIIcon.Position = new CCPoint(_SIIcon.PositionX, _SCIcon.PositionY - _NIIcon.ContentSize.Height * 1.15f);
            //_QAIcon.Position = new CCPoint(_SIIcon.PositionX, _NIIcon.PositionY - _QAIcon.ContentSize.Height * 1.15f);
           var shownSI = new CCPoint(_SIIcon.ContentSize.Width * 1.25f, _terminal.PositionY - _terminal.ContentSize.Height * 1.45f);
           var showSC = new CCPoint(_SCIcon.ContentSize.Width * 1.25f, _SIIcon.PositionY - _SCIcon.ContentSize.Height * 1.15f);
           var showNI = new CCPoint(_NIIcon.ContentSize.Width * 1.25f, _SCIcon.PositionY - _NIIcon.ContentSize.Height * 1.15f);
           var shownQA = new CCPoint(_QAIcon.ContentSize.Width * 1.25f, _NIIcon.PositionY - _QAIcon.ContentSize.Height * 1.15f);
            var hideSI = new CCPoint(-(_SIIcon.ContentSize.Width / 2), _terminal.PositionY - _terminal.ContentSize.Height * 1.45f);
            var hideSC = new CCPoint(-(_SCIcon.ContentSize.Width / 2), _SIIcon.PositionY - _SCIcon.ContentSize.Height * 1.15f);
            var hideNI = new CCPoint(-(_NIIcon.ContentSize.Width / 2), _SCIcon.PositionY - _NIIcon.ContentSize.Height * 1.15f);
            var hideQA = new CCPoint(-(_QAIcon.ContentSize.Width / 2), _NIIcon.PositionY - _QAIcon.ContentSize.Height * 1.15f);
            if (shown)                                                                                                  
            {
                 _SIIcon.RunActionAsync(new CCMoveTo(0.3f,shownSI)).ContinueWith( a=> {
                     _SCIcon.RunActionAsync(new CCMoveTo(0.3f, showSC)).ContinueWith( b => {
                         _NIIcon.RunActionAsync(new CCMoveTo(0.3f, showNI)).ContinueWith( c => {
                             _QAIcon.RunActionAsync(new CCMoveTo(0.3f, shownQA)).ContinueWith( d => {
                              //  await AnimationManager.Instance.MoveDanny( AnimationManager.DannyPosition.Middle,1.2f, 0.4f);
                            });
                        });
                    });
                });
            }
            else {
                 _SIIcon.RunActionAsync(new CCMoveTo(0.3f, hideSI)).ContinueWith( a => {
                     _SCIcon.RunActionAsync(new CCMoveTo(0.3f, hideSC)).ContinueWith( b => {
                         _NIIcon.RunActionAsync(new CCMoveTo(0.3f, hideNI)).ContinueWith( c => {
                             _QAIcon.RunActionAsync(new CCMoveTo(0.3f, hideQA)).ContinueWith(async d => {
                              await   AnimationManager.Instance.MoveDanny(AnimationManager.DannyPosition.Middle, 1.2f, 0.4f);
                            });
                        });
                    });
                });
            } 
        }
        private void MusicAndSoundSchedules() { 
        
        }

        private void ModuleEvents() {
            _NIIcon.Pressed = (touch, _event) => {

            };
            _SIIcon.Pressed = (touch, _event) => {

            };
            _SCIcon.Pressed = (touch, _event) => {

            };
            _QAIcon.Pressed = (touch, _event) => {

            };
       

            _NIIcon.Released = (touch, _event) => {
                SoundManagers.Instance.PlayButtonClickSound();

                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core2));
                });
            };
            _SCIcon.Released = (touch, _event) => {
                SoundManagers.Instance.PlayButtonClickSound();
                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core3));
                });
            };
            _SIIcon.Released = (touch, _event) => {
                SoundManagers.Instance.PlayButtonClickSound();
                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core1));
                });
            };
            _QAIcon.Released = (touch, _event) => {
                SoundManagers.Instance.PlayButtonClickSound();
                DialougeService.GameDialouge.GotoLab();
                ModuleSelection(false);
               
              
            };

        }

        private void LayerSchedules()
        {
            Schedule(go => {
                if (ScheduleTriggers.GotoLab)
                {
                    ScheduleTriggers.GotoLab = false;
                    QuestionService.LoadQuestions();
                    AppSettings.CurrentScene = SceneManagers.SceneType.Lab;
                    SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                }
            });
        }
    }


}
