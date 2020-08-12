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
            bg.ContentSize = new CCSize(Screen.DeviceWidth/1.02f,Screen.DeviceHeight/4.15f);
            bg.Position = new CCPoint(Screen.DeviceWidth/2, Screen.DeviceHeight/2);
           var _SIIcon = new CCSpriteButton(ResourceManager.Instance.SIButton, bg.ContentSize.Width/ 5.15f, bg.ContentSize.Width / 5.15f);
           var _SCIcon = new CCSpriteButton(ResourceManager.Instance.SCButton, bg.ContentSize.Width / 5.15f, bg.ContentSize.Width / 5.15f);
           var _NIIcon = new CCSpriteButton(ResourceManager.Instance.NIButton, bg.ContentSize.Width / 5.15f, bg.ContentSize.Width / 5.15f);
            var _QAIcon = new CCSpriteButton(ResourceManager.Instance.QAButton, bg.ContentSize.Width / 5.15f, bg.ContentSize.Width / 5.15f);
            var exitIcon = new CCSpriteButton(ResourceManager.Instance.LongButton,"EXIT",ResourceManager.Instance.Netron_Font,
                bg.ContentSize.Width/2.2f,bg.ContentSize.Height/5f,1.75f);


            _SIIcon.Position = new CCPoint(_SIIcon.ContentSize.Width, bg.ContentSize.Height - _SIIcon.ContentSize.Height / 1.5f);
            _NIIcon.Position = new CCPoint(_SIIcon.PositionX + _NIIcon.ContentSize.Width *1.1f,_SIIcon.PositionY);
          
            _SCIcon.Position = new CCPoint(_NIIcon.PositionX + _SCIcon.ContentSize.Width * 1.1f, _SIIcon.PositionY);
            _QAIcon.Position = new CCPoint(_SCIcon.PositionX + _QAIcon.ContentSize.Width*1.1f,_SIIcon.PositionY);
            exitIcon.Position = new CCPoint(bg.ContentSize.Width/2, exitIcon.ContentSize.Height/1.2f);
            bg.AddChild(_NIIcon);
            bg.AddChild(_SIIcon);
            bg.AddChild(_SCIcon);
            bg.AddChild(_QAIcon);
            bg.AddChild(exitIcon);
            layer.AddChild(bg);

            _NIIcon.Pressed=(touch, _event)=>{ 
            
            };
            _SIIcon.Pressed = (touch, _event) => {
             
            };
            _SCIcon.Pressed = (touch, _event) => {
            
            };
            _QAIcon.Pressed = (touch, _event) => {

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
           _QAIcon.Released = (touch, _event) => {
               layer.RemoveFromParent();
               scene.ResumeListeners(true);
               DialougeService.GameDialouge.GotoLab();
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
        public static StackLayout CreateTitleText(string title, string text)
        {
            var stack = new StackLayout();
            stack.Spacing = 0;
            var label = new Label() { Text = title, TextColor = Color.White, FontAttributes = FontAttributes.Bold };

            var label1 = new Label() { Text = text, TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap };
            stack.Children.Add(label);

            stack.Children.Add(label1);


            return stack;
        }

        public static Label CreateTextItem(string text,Color textColor, Color bgColor, FontAttributes font = FontAttributes.None) {
            
            var l1 = new Label()
            {
                TextColor = textColor,
                BackgroundColor = bgColor,
                LineBreakMode = LineBreakMode.WordWrap,
                Text = $"{text}",
                FontAttributes = font
                
            };
            return l1;
        }
    }
}
