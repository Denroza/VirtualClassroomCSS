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
    public class LoadingScene : BaseScene
    {
        public LoadingScene(CCGameView gameView) : base(gameView)
        {
            var layer = new LoadingLayer();
            this.AddLayer(layer) ;
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
            return SceneType.Loading;
        }

    }
}
