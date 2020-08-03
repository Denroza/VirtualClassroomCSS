using CocosSharp;
using NetEmu.Extensions;
using NetEmu.Managers;
using NetEmu.Views.Custom.RgPopUp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;

namespace NetEmu.Services
{
    public class UIService
    {
        public static bool UILoadComplete { get; set; } = false;
        public static bool IsLoading { get; set; } = false;


        public static CCNode ShowCoreIcons(CCScene scene) {
            var layer = new CCLayer();
            layer.Opacity = 0;
            var bg = new CCSprite(ResourceManager.Instance.BlueScreen);
            bg.ContentSize = new CCSize(Screen.DeviceWidth/1.02f,Screen.DeviceHeight/4f);
            bg.Position = new CCPoint(Screen.DeviceWidth/2, Screen.DeviceHeight/2);
           var _SIIcon = new CCSpriteButton(ResourceManager.Instance.SIButton, bg.ContentSize.Width/ 4.5f, bg.ContentSize.Width / 4.5f);
           var _SCIcon = new CCSpriteButton(ResourceManager.Instance.SCButton, bg.ContentSize.Width / 4.5f, bg.ContentSize.Width / 4.5f);
           var _NIIcon = new CCSpriteButton(ResourceManager.Instance.NIButton, bg.ContentSize.Width / 4.5f, bg.ContentSize.Width / 4.5f);
            var exitIcon = new CCSpriteButton(ResourceManager.Instance.LongButton,"EXIT",ResourceManager.Instance.Netron_Font,
                bg.ContentSize.Width/2.2f,bg.ContentSize.Height/5f,1.75f); 

            _NIIcon.Position = new CCPoint(bg.ContentSize.Width / 2,bg .ContentSize.Height - _NIIcon.ContentSize.Height/1.5f);
            _SIIcon.Position = new CCPoint(_NIIcon.Position.X - _SIIcon.ContentSize.Width * 1.1f, _NIIcon.Position.Y);
            _SCIcon.Position = new CCPoint(_NIIcon.PositionX + _SCIcon.ContentSize.Width * 1.1f, _NIIcon.Position.Y);
            exitIcon.Position = new CCPoint(bg.ContentSize.Width/2, exitIcon.ContentSize.Height/1.2f);
            bg.AddChild(_NIIcon);
            bg.AddChild(_SIIcon);
            bg.AddChild(_SCIcon);
            bg.AddChild(exitIcon);
            layer.AddChild(bg);

            _NIIcon.Pressed=(touch, _event)=>{ 
            
            };
            _SIIcon.Pressed = (touch, _event) => {
             
            };
            _SCIcon.Pressed = (touch, _event) => {
            
            };
            exitIcon.Pressed = (touch, _event) => { 
            
            };

            _NIIcon.Released = (touch, _event) => {

                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core2));
                });
            };
            _SCIcon.Released = (touch, _event) => {

                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core3));
                });
            };
            _SIIcon.Released = (touch, _event) => {
                Device.BeginInvokeOnMainThread(async () => {
                    await PopupNavigation.Instance.PushAsync(new SubjectSelectionView(IndentifierServices.CoreIdentity.Core1));
                });
            };
            exitIcon.Released = (touch, _event) => {
                layer.RemoveFromParent();
                scene.ResumeListeners(true);
            };
            return layer;
        }


        public static StackLayout CreateImageViewCaption(string caption,string source) {
            var stack = new StackLayout();
          
            var label = new Label() { Text = caption, TextColor = Color.White  };

            Image image = new Image() { Source =source,Aspect = Aspect.AspectFit };

            var tapImage = new TapGestureRecognizer();
            tapImage.Tapped += (tapped,_event) => {
                Device.BeginInvokeOnMainThread( async() => {
                    await PopupNavigation.Instance.PushAsync(new ShowImageView(source));
                });
            };

            image.GestureRecognizers.Add(tapImage);
            stack.Children.Add(label);

            stack.Children.Add(image);
           

            return stack;
        }
    }
}
