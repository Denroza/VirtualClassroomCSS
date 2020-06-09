using CocosSharp;
using NetEmu.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetEmu.Services
{
    public class UIService
    {
        public static bool UILoadComplete { get; set; } = false;
        public static bool IsLoading { get; set; } = false;


        public static CCSprite AddDialougeBox() {
            var sprite = new CCSprite(ResourceManager.Instance.DialougeBox);
            sprite.ContentSize = new CCSize(Screen.DeviceWidth,Screen.DeviceHeight/4.5f);
   
            return sprite;
        }
    }
}
