using CocosSharp;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class MenuScene : BaseScene
    {
        public MenuScene(CCGameView gameView) : base(gameView) {
            var background = new MenuBackground();
            

            var menyLayer = new MenuLayer();
            menyLayer.Opacity = 0;

            Scene.AddChild(background,0);
            Scene.AddChild(menyLayer,1);
        }

        public override SceneType GetSceneType()
        {
            return SceneType.Menu ;
        }
    }
}
