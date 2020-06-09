using CocosSharp;
using NetEmu.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetEmu.Views.Layers
{
    public class MenuBackground : BaseLayer
    {
        private CCSprite bgnoice;
        private CCRepeatForever noiseani;
        private CCSprite loader;
        private CCRepeat loop;

        private CCSprite lines;
        public MenuBackground() : base() {
            var sheet = new CCSpriteSheet(ResourceManager.Instance.bgNoisePlist, ResourceManager.Instance.bgNoice);
            var shining1 = new CCAnimation(sheet, 0.07f);
            noiseani = new CCRepeatForever(new CCAnimate(shining1));

            bgnoice = new CCSprite(sheet.Frames.First());
            bgnoice.Scale = 1;
            bgnoice.ScaleX = Screen.GameWidth;
            bgnoice.ScaleY = Screen.GameHeight;
            lines = new CCSprite(ResourceManager.Instance.Lines2BG);
            lines.ContentSize = new CCSize(Screen.GameWidth, Screen.GameHeight);
            lines.Visible = false;
            lines.Opacity = 50;
            this.AddChild(lines, 1);
            var an = new CCFadeTo(.5f, 150);
            var anp = new CCFadeTo(1f, 50);
            var forever = new CCRepeatForever(an,anp);
            lines.RunAction(forever);

            this.AddChild(bgnoice, 0);
        
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            bgnoice.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);
            lines.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);

            bgnoice.RunAction(noiseani);
         
        }
    }
}
