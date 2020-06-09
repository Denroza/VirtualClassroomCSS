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
    public class SelectionScene : BaseScene
    {
        public enum SelectionType
        {
            Default
        }
        private BaseLayer _currentLayer;

        public SelectionScene(CCGameView gameView) : base(gameView)
        {
            //var backgroundLayer = new BackgroundLayer();
            //this.AddLayer(backgroundLayer, 0);

            //var layer = new SelectGameTypeLayer();
            //layer.Opacity = 0;
            //this.AddLayer(layer, 1);
            //_currentLayer = layer;

            //var hudLayer = new SelectionHudLayer();
            //hudLayer.Opacity = 0;
            //this.AddLayer(hudLayer, 2);
            //try
            //{
            //    if (!SoundManagers.Instance.IsMenuMusicPlaying)
            //        SoundManagers.Instance.PlayMenuMusic();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(">>> BGM Error>>> " + ex.ToString());
            //}

        }

        public override SceneType GetSceneType()
        {
            return SceneType.GameMode;
        }

        public void NavigateToLayer(SelectionType selectionType)
        {
            BaseLayer layer = null;

            switch (selectionType)
            {
              

            }

            if (layer != null)
            {
                this.RemoveChild(_currentLayer, false);
                layer.Opacity = 0;
                this.AddLayer(layer, 1);
                _currentLayer = layer;
            }
        }



        public void NavigateBack()
        {
            SelectionType selectionType = SelectionType.Default;

            switch (_currentLayer.GetSelectionType())
            {
             

            }

            if (selectionType != SelectionType.Default)
            {
                NavigateToLayer(selectionType);
            }
        }

    }
}
