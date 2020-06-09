using CocosSharp;
using NetEmu.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using NetEmu.Views.Custom.RgPopUp.Control;
using Rg.Plugins.Popup.Services;

namespace NetEmu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class GamePage : ContentPage
    {
        public static CocosSharpView _cocosSharpView;
        public static CocosSharpView CocosSharpView

        {
            get { return _cocosSharpView; }
        }

       
     
        public GamePage()
        {
            _cocosSharpView = new CocosSharpView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Set the game world dimensions
            _cocosSharpView.DesignResolution = new Size(App.ScreenWidth, App.ScreenHeight);
            _cocosSharpView.ResolutionPolicy = CocosSharpView.ViewResolutionPolicy.NoBorder;

            // Set the method to call once the view has been initialised

            _cocosSharpView.ViewCreated = LoadGame;
         
         

            var grid = new Grid();



            grid.Children.Add(_cocosSharpView);
            //MenuForms = new MenuForms();
            grid.Children.Add(MenuForms.Instance);

            Content = grid;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.RuntimePlatform == Device.iOS)
            {
                var safeInset = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
                safeInset.Top = 0;
                safeInset.Bottom = 0;
                this.Padding = safeInset;
            }
            if (_cocosSharpView != null)
                _cocosSharpView.Paused = false;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (_cocosSharpView != null)
                _cocosSharpView.Paused = false;

        }

        private void LoadGame(object sender, EventArgs e)
        {
            CCGameView gameView = sender as CCGameView;
            if (gameView != null)
            {
                Screen.GameView = gameView;
                Screen.GameWidth = gameView.DesignResolution.Width;
                Screen.GameHeight = gameView.DesignResolution.Height;

               GameManager.Instance.Ready(this);

                ResourceManager.Instance.Ready(gameView);
                try
                {
                    ResourceManager.Instance.SetupContentPaths();
                    ResourceManager.Instance.LoadGameBackgrounds();
                    ResourceManager.Instance.LoadGameFonts();
                    ResourceManager.Instance.LoadGameAnimations();
                    AnimationManager.Instance.LoadProfessorAnimation();
                    Debug.WriteLine($"Device Height: {App.ScreenHeight}{Environment.NewLine}Device Width: {App.ScreenWidth}{Environment.NewLine}Game Height: {Screen.GameHeight}{Environment.NewLine}Game Width: {Screen.GameWidth}");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(">>>Resources Load failed: " + ex.ToString());
                }

                try
                {
                    SoundManagers.Instance.Ready(gameView);
                    SoundManagers.Instance.PreloadSoundContents();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(">>>Error sounds>>" + ex.ToString());
                }

                SceneManagers.Instance.Ready(gameView);
                SceneManagers.Instance.LaunchGame();
                Debug.WriteLine(">>> Entered Game");
            }
        }


    }
}