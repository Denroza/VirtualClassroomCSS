using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Managers.SceneManagers;

namespace NetEmu.Views.Scenes
{
    public class BaseScene : CCScene
    {
        public BaseScene(CCGameView gameView) : base(gameView)
        {
         

        }

        public virtual SceneType GetSceneType()
        {
            return SceneType.Default;
        }
    }
}
