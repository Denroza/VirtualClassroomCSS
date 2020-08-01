using CocosSharp;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class LabScene : BaseScene
    {
        public LabScene(CCGameView gameView) : base(gameView)
        {
            var bgLayer = new LabBGLayer();
            this.AddLayer(bgLayer,0);

            var layer = new LabLayer();
            layer.Opacity = 0;
            this.AddLayer(layer,1);
        }

        public override SceneType GetSceneType()
        {
            return SceneType.Lab;
        }
    }
}
