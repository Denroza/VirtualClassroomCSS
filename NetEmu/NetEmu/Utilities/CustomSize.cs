using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace NetEmu.Utilities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public static class CustomSize
    {
        /// <summary>
        /// Returns the A size that is suited for a logo
        /// </summary>
        public static CCSize SpriteLogoSize(float width = 150, float height = -150, float DivideBy = 2)
        {
            CCSize size = new CCSize((Screen.GameWidth / DivideBy) + width, (Screen.GameHeight / DivideBy) + height);
            return size;
        }

        /// <summary>
        /// Resizes a sprite, 
        /// </summary>
        public static CCSize resizeSprite(this CCSprite sprite, float width = 0, float height = 0, float DivideForWidth = 2, float DivideForHeight = 2, bool insideSprite = false, CCSprite parentSprite = null)
        {
            CCSize size = new CCSize();
            if (insideSprite)
            {
                size = new CCSize(parentSprite.ContentSize.Width / DivideForWidth + width, parentSprite.ContentSize.Height / DivideForHeight + height);
            }
            else
            {
                size = new CCSize(sprite.ContentSize.Width / DivideForWidth + width, sprite.ContentSize.Height / DivideForHeight + height);
            }

            return size;
        }

        public static CCSize resizeSpriteByDeviceResolution(float DivideForWidth = 2, float DivideForHeight = 2)
        {

            var size = new CCSize(Screen.GameWidth - Screen.GameWidth / DivideForWidth, Screen.GameHeight / DivideForHeight);

            return size;
        }
        public static CCSize resizeSpriteBy(float DivideForWidth = 2, float DivideForHeight = 2, float width = 0, float height = 0)
        {

            var size = new CCSize(Screen.GameWidth - (Screen.GameWidth / DivideForWidth + width), Screen.GameHeight - (Screen.GameHeight / DivideForHeight - height));

            return size;
        }

        public static CCSize resizeSpriteByDeviceResolutionBox(float DivideForWidth = 2, float DivideForHeight = 2)
        {

            var size = new CCSize(Screen.GameWidth / DivideForWidth, Screen.GameHeight / DivideForHeight);

            return size;
        }

        public static float resizeFont(string label, float width)
        {
            var labels = label.Split(' ');
            float sizeCounter = 1.5f;
            if (labels.Length < 5)
                sizeCounter = 2f;

            foreach (var character in label.ToCharArray())
            {
                sizeCounter += 0.1025f;
            }
            float setSize = width / sizeCounter;
            return setSize;
        }

        public static float SizeMultiplierByWords(string[] words)
        {
            float mul = .485f;
            if (words.Length <= 8)
            {
                switch (words.Length)
                {
                    case 1: mul = .485f; break;
                    case 2: mul = .48f; break;
                    case 3: mul = .475f; break;
                    case 4: mul = .47f; break;
                    case 5: mul = .465f; break;
                    case 6: mul = .46f; break;
                    case 7: mul = .455f; break;
                    case 8: mul = .45f; break;
                }
            }
            else
            {
                foreach (var count in words)
                {
                    mul -= .05f;
                }
            }
            return mul;
        }

    }
}
