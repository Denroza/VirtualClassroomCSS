using CocosSharp;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NetEmu.Managers
{
	public class SoundManagers
	{
		private static readonly SoundManagers instance = new SoundManagers();

		public static SoundManagers Instance
		{
			get { return instance; }
		}

		public CCGameView GameView { get; private set; }

		public bool IsMusicMute { get; set; }
		public bool IsSoundMute { get; set; }
		public bool IsGameMusicPlaying { get; set; }
		public bool IsMenuMusicPlaying { get; set; }

        #region Reference Code

        public void PlayMenuMusic()
        {

            IsMenuMusicPlaying = true;
            IsGameMusicPlaying = false;
            if (!IsMusicMute)
                CCAudioEngine.SharedEngine.PlayBackgroundMusic(ResourceManager.Instance.MenuMusic, true);
        }

        public void PlayGameMusic()
        {
            IsMenuMusicPlaying = false;
            IsGameMusicPlaying = true;
            if (!IsMusicMute)
                CCAudioEngine.SharedEngine.PlayBackgroundMusic(ResourceManager.Instance.GameMusic, true);
        }

        //public void StopBackgroundMusic()
        //{
        //	if (!IsMusicMute)
        //		CCAudioEngine.SharedEngine.StopBackgroundMusic();
        //}

        //public void PlayLoadingScreenSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.LoadingScreenSound);
        //}

        //public void PlayButtonClickSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.ButtonClickSound);
        //}

        //public void PlayTileClickSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.TileClickSound);
        //}

        //public void PlayLightningSmashSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.LightningSmashSound);
        //}

        //public void PlayCoinSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.CoinSound);
        //}

        //public void PlayCorrectAnswerSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.CorrectAnswerSound);
        //}

        //public void PlayWrongAnswerSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.WrongAnswerSound);
        //}

        //public void PlayGameOverSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.GameOverSound);
        //}

        //public void PlayAlertSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.AlertSound);
        //}

        //public void PlayTimeWarpSound()
        //{
        //	if (!IsSoundMute)
        //		CCAudioEngine.SharedEngine.PlayEffect(ResourceManager.Instance.TimeMalfunctionSound);
        //}
        #endregion

        public void PlaySoundEffect(string assetName, bool loop = false)
		{
			try
			{
				var soundEffect = GameView.ContentManager.Load<SoundEffect>(assetName);
				if (soundEffect == null)
				{
					throw new ArgumentNullException(
						"SoundEffect",
						"You cannot play a sound effect that has nothing loaded!");
				}

				var soundEffectInstance = soundEffect.CreateInstance();
				soundEffectInstance.IsLooped = loop;
				soundEffectInstance.Volume = 1.0f;
				soundEffectInstance.Play();
			}
			catch (Exception e)
			{
				Debug.WriteLine(">>> PLAY SOUND ERROR: " + e.ToString());
			}
		}

		public void PreloadSoundContents()
		{
			ResourceManager.Instance.LoadSoundResources();

			// Audio Engine Settings
			CCAudioEngine.SharedEngine.EffectsVolume = 1.0f;
			CCAudioEngine.SharedEngine.BackgroundMusicVolume = 0.75f;

			// Sound Resources
			List<string> soundBackgrounds = new List<string>
			{
                ResourceManager.Instance.MenuMusic,
                ResourceManager.Instance.GameMusic ,
            };

			List<string> soundEffects = new List<string>
			{
            
			};

			foreach (var bg in soundBackgrounds)
				CCAudioEngine.SharedEngine.PreloadBackgroundMusic(bg);

			foreach (var ef in soundEffects)
				CCAudioEngine.SharedEngine.PreloadEffect(ef);

			IsMusicMute = false;
			IsSoundMute = false;
		}

		public void Ready(CCGameView gameView)
		{
			GameView = gameView;
		}


	}
}
