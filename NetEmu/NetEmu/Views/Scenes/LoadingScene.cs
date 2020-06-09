using CocosSharp;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class LoadingScene : BaseScene
    {
        public LoadingScene(CCGameView gameView) : base(gameView)
        {
            var layer = new LoadingLayer();
            this.AddLayer(layer) ;
        }
        public override SceneType GetSceneType()
        {
            return SceneType.Loading;
        }

    }
}
