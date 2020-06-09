using CocosSharp;
using NetEmu.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Views.Layers
{
    public class ClassroomBGLayer : BaseLayer
    {
        private CCSprite bg;
        public ClassroomBGLayer()  :base()
        {
            bg = new CCSprite(ResourceManager.Instance.ClassroomBG);
            bg.ContentSize = new CCSize(Screen.GameWidth *1.5f,Screen.GameHeight);
            bg.Position = new CCPoint(Screen.GameWidth/2,Screen.GameHeight/2);

            this.AddChild(bg);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
        }
    }
}
