using CocosSharp;
using NetEmu.Managers;
using NetEmu.Views.Layers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                SoundManagers.Instance.PlayLoadingMusic();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>> BGM Error>>> " + ex.ToString());
            }
        }

        public override SceneType GetSceneType()
        {
            return base.GetSceneType();
        }
    }
}
