using CocosSharp;
using NetEmu.Managers;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class ClassScene : BaseScene
    {
        public ClassScene(CCGameView gameView) : base(gameView)
        {
            var bglayer = new ClassroomBGLayer();
            this.AddLayer(bglayer,0);

            var layer = new ClassroomLayer();
            layer.Opacity = 0;
            this.AddLayer(layer,1) ;
        }

        public override SceneType GetSceneType()
        {
            return SceneType.Class;
        }
    }
}
