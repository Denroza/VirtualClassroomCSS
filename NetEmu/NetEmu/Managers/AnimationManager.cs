using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetEmu.Managers
{
   public class AnimationManager
    {
        private static readonly AnimationManager instance = new AnimationManager();

        public static AnimationManager Instance {
            get { return instance; }
        }
        public CCSprite ProffesorSprite { get; private set; }
        public CCRepeatForever ProfAnimation { get; private set; }
        public CCSprite ProffesorSpriteF { get; private set; }
        public CCRepeatForever ProfAnimationF { get; private set; }
        public void LoadProfessorAnimation() {
            var sheetprof = new CCSpriteSheet(ResourceManager.Instance.MalePlist, ResourceManager.Instance.MaleSprite);
            var animate = new CCAnimation(sheetprof,0.5f);
            ProfAnimation = new CCRepeatForever(new CCAnimate(animate));

            ProffesorSprite = new CCSprite(sheetprof.Frames.First());
            ProffesorSprite.ContentSize = new CCSize(Screen.GameWidth/1.5f,Screen.GameHeight/2f);
            ProffesorSprite.Scale = 1;
            ProffesorSprite.ScaleX = ProffesorSprite.ContentSize.Width / 125f;
            ProffesorSprite.ScaleY = ProffesorSprite.ContentSize.Height / 150f;
            ProffesorSprite.Position = new CCPoint(ProffesorSprite.ContentSize.Width / 1.25f, ProffesorSprite.ContentSize.Height / 1.05f);

            //  ProffesorSprite.Opacity = 0;
        }

        public void LoadProfessorFAnimation()
        {
            var sheetprof = new CCSpriteSheet(ResourceManager.Instance.MalePlist, ResourceManager.Instance.MaleSprite);
            var animate = new CCAnimation(sheetprof, 0.5f);
            ProfAnimationF = new CCRepeatForever(new CCAnimate(animate));

            ProffesorSpriteF = new CCSprite(sheetprof.Frames.First());
            ProffesorSpriteF.ContentSize = new CCSize(Screen.GameWidth / 1.5f, Screen.GameHeight / 2f);
            ProffesorSpriteF.Scale = 1;
            ProffesorSpriteF.ScaleX = ProffesorSpriteF.ContentSize.Width / 125f;
            ProffesorSpriteF.ScaleY = ProffesorSpriteF.ContentSize.Height / 150f;
            ProffesorSpriteF.Position = new CCPoint(ProffesorSpriteF.ContentSize.Width / 1.25f, ProffesorSpriteF.ContentSize.Height / 1.05f);

            //  ProffesorSprite.Opacity = 0;
        }
    }
}
