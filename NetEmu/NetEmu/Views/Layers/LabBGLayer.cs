using CocosSharp;
using NetEmu.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Views.Layers
{
    public class LabBGLayer  : BaseLayer
    {
        private CCSprite bg;
        public LabBGLayer() : base() {
            bg = new CCSprite(ResourceManager.Instance.LaboratoryBG);
            bg.ContentSize = new CCSize(Screen.GameWidth * 1.5f, Screen.GameHeight);
            bg.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);

            this.AddChild(bg);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
        }
    }
}
