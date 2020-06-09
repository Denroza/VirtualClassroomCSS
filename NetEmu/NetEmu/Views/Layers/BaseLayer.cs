using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static NetEmu.Views.Scenes.SelectionScene;

namespace NetEmu.Views.Layers
{
    public class BaseLayer : CCLayerColor
    {
        protected const float BUTTON_MOVE_DISTANCE = 10f;
        protected const float BUTTON_MOVE_TIME = 0.3f;
        protected const float BUTTON_ELASTIC_TIME = 0.5f;
        protected const float BANNER_TRANSITION_TIME = 0.3f;
        protected const float BANNER_ELASTIC_TIME = 0.5f;

        public BaseLayer() : base(CCColor4B.Red)
        {
            // Set background color 


        }

        public virtual SelectionType GetSelectionType()
        {
            return SelectionType.Default;
        }


    }
}
