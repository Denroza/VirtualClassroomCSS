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
    public class ClassScene : BaseScene
    {
        public ClassScene(CCGameView gameView) : base(gameView)
        {
            var bglayer = new ClassroomBGLayer();
            this.AddLayer(bglayer,0);

            var layer = new ClassroomLayer();
            layer.Opacity = 0;
            this.AddLayer(layer,1) ;
            try
            {
                SoundManagers.Instance.PlayMenuMusic();
            }
            catch (Exception ex)
            {
             
                Debug.WriteLine(">>> BGM Error>>> " + ex.ToString());
            }

        }

        public override SceneType GetSceneType()
        {
            return SceneType.Class;
        }
    }
}
