using CocosSharp;
using NetEmu.Managers;
using NetEmu.Services;
using NetEmu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace NetEmu.Views.Layers
{
    public class LoadingLayer : BaseLayer
    {
        private CCSprite bgnoice;
        private CCRepeatForever noiseani;
        private CCSprite loader;
        private CCRepeat loop;
        private CCSprite lines;
        public LoadingLayer() : base() {
            var sheet = new CCSpriteSheet(ResourceManager.Instance.bgNoisePlist, ResourceManager.Instance.bgNoice);
            var shining1 = new CCAnimation(sheet, 0.07f);
            noiseani = new CCRepeatForever(new CCAnimate(shining1));

            bgnoice = new CCSprite(sheet.Frames.First());
            bgnoice.Scale = 1;
            bgnoice.ScaleX = Screen.GameWidth;
            bgnoice.ScaleY = Screen.GameHeight;

            var load = new CCSpriteSheet(ResourceManager.Instance.loaderPlist, ResourceManager.Instance.loader);
            var n = new CCAnimation(load, 0.07f);
            loop = new CCRepeat(new CCAnimate(n), 1);

            lines = new CCSprite(ResourceManager.Instance.Lines2BG);
            lines.ContentSize = new CCSize(Screen.GameWidth, Screen.GameHeight);

            lines.Opacity = 50;
            var an = new CCFadeTo(.5f, 100);
            var anp = new CCFadeTo(1f, 50);
            var forever = new CCRepeatForever(an, anp);
            lines.RunAction(forever);

            this.AddChild(lines, 1);

            loader = new CCSprite(load.Frames.First());
            loader.Scale = 1;
            loader.ScaleX = loader.ScaledContentSize.Width / 20;
            loader.ScaleY = loader.ScaledContentSize.Height / 20;
            this.AddChild(bgnoice, 0);
            this.AddChild(loader, 2);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            bgnoice.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);
            loader.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);
            lines.Position = new CCPoint(Screen.GameWidth / 2, Screen.GameHeight / 2);
            OnUpdate();
            bgnoice.RunAction(noiseani);
            loader.RunAction(loop);
        }

        void OnUpdate()
        {
            Schedule(s => {
                if (loader.NumberOfRunningActions <= 0)
                {
                    ScheduleOnce(sd => {
                        if (AppSettings.CurrentScene == SceneManagers.SceneType.Class)
                            SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Class);
                        else if (AppSettings.CurrentScene == SceneManagers.SceneType.Menu)
                            SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Menu);
                    }, 0f);
                 
                }

                //if (UIService.UILoadComplete) { 


                //}
            });

        }
    }
}
