using CocosSharp;
using NetEmu.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetEmu.Extensions
{
    public enum ButtonState
    {
        Released,
        Pressed,
        Moved,
        Toggled
    }

    public class CCSpriteButton : CCSprite
    {
        //===================================================================
        // Constants
        //===================================================================

        //===================================================================
        // Fields
        //===================================================================

        private Action<CCTouch, CCEvent> _pressed;
        public Action<CCTouch, CCEvent> Pressed
        {
            get { return _pressed; }
            set { _pressed = value; }
        }

        private Action<CCTouch, CCEvent> _released;
        public Action<CCTouch, CCEvent> Released
        {
            get { return _released; }
            set { _released = value; }
        }

        private Action<CCTouch, CCEvent> _moved;
        public Action<CCTouch, CCEvent> Moved
        {
            get { return _moved; }
            set { _moved = value; }
        }

        private Action<CCTouch, CCEvent> _toggled;
        public Action<CCTouch, CCEvent> Toggled
        {
            get { return _toggled; }
            set { _toggled = value; }
        }

        private CCLabel _label;
        public CCLabel ButtonLabel {
            get { return _label; }
            set { _label = value; }
        }
        //===================================================================
        // Constructors
        //===================================================================
        public CCSpriteButton(string filename, float width, float heigth) : base(filename)
        {
            this.ContentSize = new CCSize(width, heigth);
        }

        public CCSpriteButton(string filename, string textName, string fontname, float width, float heigth, float sizeControl = 1) : base(filename)
        {
            ContentSize = new CCSize(width, heigth);
           ButtonLabel= new CCLabel(textName, fontname, CustomSize.resizeFont(textName, width / sizeControl), CCLabelFormat.SystemFont);
            ButtonLabel.Position = new CCPoint(ContentSize.Width / 2, ContentSize.Height / 2);
            ButtonLabel.LineBreak = CCLabelLineBreak.Word;
            AddChild(ButtonLabel);
        }

        //===================================================================
        // Properties
        //===================================================================

        private ButtonState _state;
        public ButtonState State
        {
            get { return _state; }
        }

        private bool _isPressed;
        public bool IsPressed
        {
            get { return _isPressed; }
            set { _isPressed = value; }
        }

        private bool _isReleased;
        public bool IsReleased
        {
            get { return _isReleased; }
            set { _isReleased = value; }
        }

        private bool _isMoved;
        public bool IsMoved
        {
            get { return _isMoved; }
            set { _isMoved = value; }
        }

        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                _isToggled = value;

                if (_isToggled && _state == ButtonState.Toggled)
                {
                    ChangeState(ButtonState.Released);
                }
                else if (!_isToggled)
                {
                    ChangeState(ButtonState.Toggled);
                }
            }
        }

        //===================================================================
        // Base Class/Interface Methods
        //===================================================================

        protected override void AddedToScene()
        {
            base.AddedToScene();

            RegisterTouchListeners();
        }

        //===================================================================
        // Methods
        //===================================================================

        private void RegisterTouchListeners()
        {
            // Register for touch events
            var touchListener = new CCEventListenerTouchOneByOne();
            touchListener.OnTouchBegan = OnTouchBegan;
            touchListener.OnTouchEnded = OnTouchEnded;
            touchListener.OnTouchMoved = OnTouchMoved;
            AddEventListener(touchListener, this);
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent touchEvent)
        {
            if (!this.IsTouched(touch.Location))
                return false;

            ChangeState(ButtonState.Pressed);
            if (Pressed != null)
            {
                Pressed?.Invoke(touch, touchEvent);
                _isPressed = true;
            }
            return true;
        }

        private void OnTouchEnded(CCTouch touch, CCEvent touchEvent)
        {
            if (!this.IsTouched(touch.Location))
                return;

            ChangeState(ButtonState.Released);
            if (Released != null)
            {
                Released?.Invoke(touch, touchEvent);
                _isReleased = true;
            }
        }

        private void OnTouchMoved(CCTouch touch, CCEvent touchEvent)
        {
            if (this.IsTouched(touch.Location))
            {
                ChangeState(ButtonState.Pressed);
            }
            else
            {
                ChangeState(ButtonState.Released);
            }

            if (Moved != null)
            {
                Moved?.Invoke(touch, touchEvent);
                _isMoved = true;
            }
        }

        public void ChangeState(ButtonState state)
        {
            if (this._state == state)
                return;

            this._state = state;
            int stateValue = (int)state;
            // CurrentTileIndex = stateValue;
        }
    }
}
