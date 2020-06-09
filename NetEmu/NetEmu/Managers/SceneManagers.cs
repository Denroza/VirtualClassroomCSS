using CocosSharp;
using NetEmu.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Managers
{
    public class SceneManagers
    {
        public static readonly SceneManagers instance = new SceneManagers();
        public static SceneManagers Instance
        {
            get { return instance; }
        }
        public CCGameView GameView { get; private set; }


        public bool NavigatedBack { get; set; } = false;

        public enum SceneType
        {
            Splash,
            Menu,
            Class,
            Lab,
            GameMode,
            Loading,
            Game,
            Default
        }
        // Scenes
        private BaseScene _menuScene;
        public BaseScene MenuScene
        {
            get { return _menuScene; }
            set { _menuScene = value; }
        }

        private BaseScene _splashScene;
        private BaseScene _selectionScene;
        private BaseScene _loadingScene;
        private BaseScene _gameScene;

        // Variables
        private BaseScene _currentScene;
        public BaseScene CurrentScene
        {
            get { return _currentScene; }
            set { _currentScene = value; }
        }


        // Launches the game and creates the splash scene
        public void LaunchGame()
        {

            if (_splashScene == null)
            {

                //ResourceManager.Instance.LoadSplashResources();
               _splashScene = new SplashScene(GameView);
              // _menuScene = new ClassScene(GameView);
            }

            //    GameView.RunWithScene(_menuScene);
            GameView.RunWithScene(_splashScene);
            CurrentScene = _splashScene;

        }

        // Navigate to a new scene from the current scene
        public void NavigateToScene(SceneType sceneType)
        {
            BaseScene scene = null;
        
            ResourceManager.Instance.LoadGameFonts();
            switch (sceneType)
            {
                case SceneType.Menu:
                    ResourceManager.Instance.LoadMenuAssets();
                    scene = new MenuScene(GameView);

                    break;
                case SceneType.Class:
                    ResourceManager.Instance.LoadClassAssets();
                    scene = new ClassScene(GameView);
                    break;
                case SceneType.Lab:
                    ResourceManager.Instance.LoadLabAssets();
                    scene = new LabScene(GameView);
                    break;

                case SceneType.Loading:
                    scene = new LoadingScene(GameView) ;
                    break;
               
            }

            if (scene != null)
            {
             
                GameView.Director.ReplaceScene(scene);
                CurrentScene = scene;
            }
        }

   

        public void Ready(CCGameView gameView)
        {
            GameView = gameView;
        }
    }
}
