using CocosSharp;
using NetEmu.Managers;
using NetEmu.Services;
using NetEmu.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEmu.Extensions
{
   public class CCDialouge  : CCSprite
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
        public CCLabel ButtonLabel
        {
            get { return _label; }
            set { _label = value; }
        }

        private CCSprite _speaker;
        public CCSprite Speaker
        {
            get { return _speaker; }
            set { _speaker = value; }
        }

        private CCLabel _textLabel;
        public CCLabel DialougeText {
            get { return _textLabel; }
            set { _textLabel = value; }
        }

        private CCLabel _speakerName;
        public CCLabel SpeakerName {
            get { return _speakerName; }
            set { _speakerName = value; }
        }

        //===================================================================
        // Constructors
        //===================================================================

        public CCDialouge(string filename,float width, float heigth) : base(filename) {
            _speaker = new CCSprite(ResourceManager.Instance.DialougeBox);
            this.ContentSize = new CCSize(width,heigth);
            _speaker.ContentSize = new CCSize(width/3,heigth/4);
            _speaker.Position = new CCPoint(_speaker.ContentSize.Width/2,heigth+ _speaker.ContentSize.Height/2.05f);
            _speakerName = new CCLabel("",ResourceManager.Instance.Cosima_Font,0,CCLabelFormat.SystemFont);
            _textLabel = new CCLabel("", ResourceManager.Instance.Cosima_Font, 0, CCLabelFormat.SystemFont);

            _speakerName.Position = new CCPoint(_speaker.ContentSize.Width/2,_speaker.ContentSize.Height/2);
            _textLabel.Position = new CCPoint(ContentSize.Width/2,ContentSize.Height/2);
            _textLabel.Dimensions = new CCSize(ContentSize.Width * 1.8f, ContentSize.Height * 1.88f);
            _textLabel.LineBreak = CCLabelLineBreak.Word;
      
            _textLabel.Color = CCColor3B.Black;
            _speakerName.Color = CCColor3B.Black;

            this.AddChild(_textLabel);
            this.AddChild(_speaker) ;
            _speaker.AddChild(_speakerName);
      
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

        public float SpeedUp { get; set; } = 0.2f;

        public async Task AddScript(string speaker, string script) {
            UnscheduleAll();

            TasksToken.DialougeToken = new System.Threading.CancellationTokenSource();
            _speakerName.Text = speaker;
            _speakerName.SystemFontSize = CustomSize.resizeFont(speaker,_speaker.ContentSize.Width/1.1f);
            _textLabel.Text = string.Empty;
          //     _textLabel.Text = script;
          var basedScript = "Kumusta at maligayang pagdating sa CSS Virtual Classroom, Mukhabg bago kang studyante paki-lagdaan muna ang iyong impormasyon.";
            _textLabel.SystemFontSize = CustomSize.resizeFont(basedScript,ContentSize.Width/1.01f);
            var c =script.ToCharArray();
            var num = 0;
            var count = 0;
            
            Schedule(i => {
                if (count < c.Length)
                {
                    _textLabel.Text += c[count].ToString();
                    count++;
                }
                else {
                    UnscheduleAll();
                    TasksToken.DialougeToken.Cancel();
                }
            },SpeedUp);
            try {
                await Task.Delay(c.Length * 100, TasksToken.DialougeToken.Token);
            } catch (Exception ex) {
                UnscheduleAll();
                _textLabel.Text = string.Empty;
                _textLabel.Text = script;
                Debug.WriteLine("Script Terminated");
            }
         
           
        }
        //public CCSprite AddDialougeBox()
        //{
        //    var sprite = new CCSprite(ResourceManager.Instance.DialougeBox);
        //    sprite.ContentSize = new CCSize(Screen.DeviceWidth, Screen.DeviceHeight / 4.5f);

        //    return sprite;
        //}
    }
}
