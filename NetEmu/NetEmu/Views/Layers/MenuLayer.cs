using CocosSharp;
using NetEmu.Extensions;
using NetEmu.Managers;
using NetEmu.Services;
using NetEmu.Utilities;
using NetEmu.Views.Custom;
using NetEmu.Views.Custom.RgPopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace NetEmu.Views.Layers
{
    public class MenuLayer : BaseLayer
    {
        private CCSpriteButton EnterButton;
        private CCSpriteButton FileIcon;
        private CCSpriteButton ProfileIcon;
        private CCSpriteButton DataIcon;
        private CCSprite ScreenBoard;
        private CCSprite ScreenLabel;

        public MenuLayer() : base() {
            ResourceManager.Instance.LoadGameFonts();
            string s = "ENTER";
            if (UserServices.hasUserData) {
                s = string.Empty;
                ScreenLabel = new CCSprite(ResourceManager.Instance.BlueScreen);
                ScreenBoard = new CCSprite(ResourceManager.Instance.BlueScreen);

                ScreenBoard.ContentSize = new CCSize(Screen.GameWidth/1.05f,Screen.GameHeight/1.5f);
                ScreenBoard.Opacity = 0;

                FileIcon = new CCSpriteButton(ResourceManager.Instance.FileIcon,ScreenBoard.ContentSize.Width/3.5f,ScreenBoard.ContentSize.Height/4.5f);
                ProfileIcon = new CCSpriteButton(ResourceManager.Instance.ProfileIcon, ScreenBoard.ContentSize.Width / 3.5f, ScreenBoard.ContentSize.Height / 4.5f);
                DataIcon = new CCSpriteButton(ResourceManager.Instance.SaveIcon, ScreenBoard.ContentSize.Width / 3.5f, ScreenBoard.ContentSize.Height / 4.5f);
                ScreenBoard.AddChild(FileIcon);
                ScreenBoard.AddChild(ProfileIcon);
                ScreenBoard.AddChild(DataIcon);

                DataIcon.Pressed = (touch, _event) => {
                    DataIcon.UpdateDisplayedColor(CCColor3B.DarkGray);
                };

                DataIcon.Released = (touch, _event) => {
                    DataIcon.UpdateDisplayedColor(CCColor3B.White);
                    Device.BeginInvokeOnMainThread( async () => {
                        await PopupNavigation.Instance.PushAsync(new SubjectSelectionView()) ;
                    });
                };
                this.AddChild(ScreenBoard);
               // this.AddChild(ScreenLabel);
            }
               

            EnterButton = new CCSpriteButton(ResourceManager.Instance.CircleButton,s,
                ResourceManager.Instance.Netron_Font,Screen.GameWidth/3,Screen.GameWidth/3);

          

            EnterButton.ButtonLabel.Color = CCColor3B.White;
            EnterButton.Pressed = (touch, _event) => {
                EnterButton.UpdateDisplayedColor(CCColor3B.DarkGray);
            };
            EnterButton.Released = (touch, _event) => {
                EnterButton.UpdateDisplayedColor(CCColor3B.White);
              
                    //CocoSharpControlUI.DisplayAlert("","No User Profile Detected");
                    AppSettings.CurrentScene = SceneManagers.SceneType.Class;
                    SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
               
            };
            this.AddChild(EnterButton);

          

        }

        protected override void AddedToScene()
        {
           
            base.AddedToScene();
            EnterButton.Position = new CCPoint(Screen.GameWidth / 2, EnterButton.ContentSize.Height / 1.5f);
            if (UserServices.hasUserData)
            {
                var sprite = new CCSprite(ResourceManager.Instance.ExitIcon);
                sprite.ContentSize = new CCSize(EnterButton.ContentSize.Width/1.5f,EnterButton.ContentSize.Height/1.5f);
                sprite.Opacity = 100;
                sprite.Position = new CCPoint(EnterButton.ContentSize.Width/2, EnterButton.ContentSize.Height/2);
                EnterButton.AddChild(sprite);
                ScreenBoard.Position = new CCPoint(Screen.GameWidth/2,Screen.GameHeight/1.75f);
                FileIcon.Position = new CCPoint(FileIcon.ContentSize.Width/1.5f,ScreenBoard.ContentSize.Height - FileIcon.ContentSize.Height/1.5f);
                ProfileIcon.Position = new CCPoint(FileIcon.PositionX + FileIcon.ContentSize.Width,FileIcon.PositionY);
                DataIcon.Position = new CCPoint(ProfileIcon.PositionX + ProfileIcon.ContentSize.Width,FileIcon.PositionY);
             }
        }

        
    }
}
