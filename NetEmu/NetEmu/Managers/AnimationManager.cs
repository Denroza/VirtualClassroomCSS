using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEmu.Managers
{
   public class AnimationManager
    {
        private static readonly AnimationManager instance = new AnimationManager();

        public static AnimationManager Instance {
            get { return instance; }
        }

        private CCPoint dannyOP;

        public enum DannyPosition {
            Left,
            Right,
            Middle
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
            dannyOP = ProffesorSprite.Position;
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

        public async Task MoveDanny(DannyPosition position,float moveby = 1.2f,float duration = 0.2f) {
            var move= new CCMoveTo(0.2f,new CCPoint(dannyOP.X ,dannyOP.Y));        
            switch (position) {
                case DannyPosition.Left: move = new CCMoveTo(duration, new CCPoint(dannyOP.X/moveby, dannyOP.Y));  break;
                case DannyPosition.Right: move = new CCMoveTo(duration, new CCPoint(dannyOP.X * moveby, dannyOP.Y)); break;
                case DannyPosition.Middle: move = new CCMoveTo(duration, new CCPoint(dannyOP.X, dannyOP.Y)); break;
            }
          await  ProffesorSprite.RunActionAsync(move);
        }

    }
}
