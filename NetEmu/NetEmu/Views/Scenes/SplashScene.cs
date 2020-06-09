using CocosSharp;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class SplashScene : BaseScene
    {
        public SplashScene(CCGameView gameView) : base(gameView)
        {
            var l = new SplashLayer();
            this.AddLayer(l);

        }

        public override SceneType GetSceneType()
        {
            return base.GetSceneType();
        }
    }
}
