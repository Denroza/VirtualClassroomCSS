using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Managers
{
    public class ResourceManager
    {
        private static readonly ResourceManager instance = new ResourceManager();
        public static ResourceManager Instance
        {
            get { return instance; }
        }


        public CCGameView GameView { get; private set; }



        private const string FontsContentPath = "Fonts";
        private const string SoundsContentPath = "Sounds";
        private const string ImageHdContentPath = "Images/Hd";
        private const string ImageLdContentPath = "Images/Ld";
        private const string AnimationContentPath = "Animations";
        private const string ParticlesContentPath = "Particles";


        //Animations
        public string bgNoisePlist { get; private set; }
        public string bgNoice { get; private set; }
        public string loaderPlist { get; private set; }
        public string loader { get; private set; }
        public string MalePlist { get; private set; }
        public string MaleSprite { get; private set; }

        //Backgrounds
        public string ClassroomBG { get; private set; }
        public string LaboratoryBG { get; private set; }
        public string LinesBG { get; private set; }
        public string Lines2BG { get; private set; }


        //Fonts
        public string Netron_Font { get; private set; }
        public string Cosima_Font { get; private set; }
        public string FaceOffM54_Font { get; private set; }

        //Class Assets
        public string DialougeBox { get; private set; }

        //Lab Assets

        //All Around assets
        public string BlueScreen { get; private set; }
        public string CircleButton { get; private set; }
        public string LongButton { get; private set; }
        public string ProgressIcon { get; private set; }
        public string SettingsIcon { get; private set; }
       


        //Menu Assets
        public string ExitIcon { get; private set; }
        public string TerminalIcon { get; private set; }
        public string FileIcon { get; private set; }
        public string SaveIcon { get; private set; }
        public string ProfileIcon { get; private set; }
        public string SIButton { get; private set; }
        public string SCButton { get; private set; }
        public string NIButton { get; private set; }
        public string QAButton { get; private set; }
        //Sounds
        public string MenuMusic { get; private set; }
        public string GameMusic { get; private set; }
        public string LoadingMusic { get; private set; }
           public string ButtonClick { get; private set; }
        public string WrongClick { get; private set; }
        public void LoadSoundResources()
        {
            MenuMusic = $"classroomBGM.m4a";
            GameMusic = $"quizBGM.m4a";
            ButtonClick = $"click";
            WrongClick = $"wrong";
            LoadingMusic = $"loadingBGM.m4a";
            //// LoadingScreenSound = $"loading_screen.xnb";
            //ButtonClickSound = $"resetsound";
            //TileClickSound = $"tile_click";
            //LightningSmashSound = $"thunder.xnb";
            ////  CoinSound = $"coin_sound.xnb";
            //CorrectAnswerSound = $"correctsound";
            //WrongAnswerSound = $"wrongsound";
            //// GameOverSound = $"game_over.xnb";                                                                                                      
            ////   TimeMalfunctionSound = $"time_warp.xnb";
            //AlertSound = $"timeup";
        }


        public void LoadGameBackgrounds() {
            ClassroomBG = $"classroom.jpg";
            LaboratoryBG = $"Laboratory.jpg";
            LinesBG = $"lines.png";
            Lines2BG = $"lines2.png";
        }

        public void LoadGameFonts() {
            Netron_Font = $"{FontsContentPath}/Netron-Regular.ttf";
            Cosima_Font = $"{FontsContentPath}/Cosima-DemoBold.ttf";
            FaceOffM54_Font = $"{FontsContentPath}/FaceOffM54.ttf";
        }

        public void LoadClassAssets() {
            DialougeBox = $"dBox.png";
            BlueScreen = $"screen.png";
            CircleButton = $"cbBlue.png";
            LongButton = $"rbBlue.png";
            TerminalIcon = $"tWidgets.png";
            FileIcon = $"fileWidget.png";
            ProgressIcon = $"progressIcon.png";
            SettingsIcon = $"settingsIcon.png";

            NIButton = $"niButton.png";
            SCButton = $"scButton.png";
            SIButton = $"siButton.png";
            QAButton = $"qaButton.png";
        }

        public void LoadLabAssets() {
            BlueScreen = $"screen.png";
            CircleButton = $"cbBlue.png";
            LongButton = $"rbBlue.png";
            TerminalIcon = $"tWidgets.png";
            LaboratoryBG = $"Laboratory.jpg";
        }

        public void LoadMenuAssets() {
            BlueScreen = $"screen.png";
            CircleButton = $"cbBlue.png";
            LongButton = $"rbBlue.png";
            SaveIcon = $"dataWidget.png";
            ExitIcon = $"offIcon.png";
            ProfileIcon = $"profileWidget.png";
            FileIcon = $"fileWidget.png";
            TerminalIcon = $"tWidgets.png";

         
        }

        public void LoadGameAnimations() {
            bgNoisePlist = $"{AnimationContentPath}/bgNoise.plist";
            bgNoice = $"{AnimationContentPath}/bgNoise.png";
            loaderPlist = $"{AnimationContentPath}/loader.plist";
            loader = $"{AnimationContentPath}/loader.png";
            MalePlist = $"{AnimationContentPath}/Male.plist";
            MaleSprite = $"{AnimationContentPath}/Male.png";
        }

        // Setup the content search paths for fonts, music, sounds and textures 
        public void SetupContentPaths()
        {
            var contentSearchPaths = new List<string>() { FontsContentPath, SoundsContentPath };
            CCSizeI viewSize = GameView.ViewSize;
            CCSizeI designResolution = GameView.DesignResolution;

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            if (designResolution.Width < viewSize.Width)
            {
                contentSearchPaths.Add(ImageHdContentPath);
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
             //   AppSettings.ScreenResolution = ScreenResolution.HD;
            }
            else
            {
                //  contentSearchPaths.Add(ImageLdContentPath);
                contentSearchPaths.Add(ImageHdContentPath);
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
               // AppSettings.ScreenResolution = ScreenResolution.LD;
            }

            // contentSearchPaths.Add(ImageHdContentPath);
            GameView.ContentManager.SearchPaths = contentSearchPaths;
        }

        public void Ready(CCGameView gameView)
        {
            GameView = gameView;
        }
    }
}
