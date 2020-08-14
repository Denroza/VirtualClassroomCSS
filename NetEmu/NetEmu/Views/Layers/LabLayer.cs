using CocosSharp;
using NetEmu.Extensions;
using NetEmu.Managers;
using NetEmu.Services;
using NetEmu.Utilities;
using NetEmu.Views.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NetEmu.Views.Layers
{
    public class LabLayer  : BaseLayer
    {

        private CCSprite DialougeSection;
        private CCSprite ExamSection;
        private CCSprite QuestionScreen;
        private CCSprite AnswerScreens;
        private CCSprite MenuScreens;

        private CCSpriteButton AcceptButton;
        private CCSpriteButton DeclineButton;
        private CCSpriteButton _terminal;
        private CCSpriteButton _classicon;

        private CCLabel QuestionText;

        private List<CCSpriteButton> ListOfChoices;

        private bool GameFinished = false;
        //Exam Related Variables
        int _round = 0;
        //

        public LabLayer() : base() {
            try {
                SetUpScreens();
                SetUpCCSpriteButtonEvents();
            
                StartNewRound();
                ReturnOnceFinished();
            } catch (Exception ex) {
                Debug.WriteLine("Error on Lab: "+ex.ToString());
            }
        
        }

    
        private void SetUpScreens() {
            try
            {
                ExamSection = new CCSprite(ResourceManager.Instance.BlueScreen);
                ExamSection.ContentSize = new CCSize(Screen.DeviceWidth,Screen.DeviceHeight);
                ExamSection.Opacity = 0;
                ExamSection.Visible = true;
                QuestionScreen = new CCSprite(ResourceManager.Instance.BlueScreen);
                AnswerScreens = new CCSprite(ResourceManager.Instance.BlueScreen);
                MenuScreens = new CCSprite(ResourceManager.Instance.BlueScreen);
                AnswerScreens.Opacity = 0;

                QuestionScreen.ContentSize = new CCSize(ExamSection.ContentSize.Width / 1.05f, ExamSection.ContentSize.Height / 2);
                AnswerScreens.ContentSize = new CCSize(ExamSection.ContentSize.Width / 1.05f, ExamSection.ContentSize.Height / 2.5f);
                MenuScreens.ContentSize = new CCSize(ExamSection.ContentSize.Width, ExamSection.ContentSize.Height / 9);

                this.AddChild(ExamSection);
                ExamSection.AddChild(QuestionScreen);
                ExamSection.AddChild(AnswerScreens);
                ExamSection.AddChild(MenuScreens);

                DialougeSection = new CCSprite(ResourceManager.Instance.BlueScreen);
                DialougeSection.ContentSize = new CCSize(Screen.DeviceWidth, Screen.DeviceHeight);
                DialougeSection.Opacity = 0;
                DialougeSection.Visible = false;
                DialougeService.GameLabDialouge = new CCDialouge(ResourceManager.Instance.DialougeBox, Screen.DeviceWidth, Screen.DeviceHeight / 4.5f);


                _classicon = new CCSpriteButton(ResourceManager.Instance.CircleButton, "CLASSROOM", ResourceManager.Instance.FaceOffM54_Font,
              Screen.GameWidth / 10, Screen.GameWidth / 10);

                DialougeSection.AddChild(_classicon);

                _terminal = new CCSpriteButton(ResourceManager.Instance.TerminalIcon, Screen.GameWidth / 10, Screen.GameHeight / 12);

                DialougeSection.AddChild(_terminal);

                this.AddChild(DialougeSection);
                DialougeSection.AddChild(DialougeService.GameLabDialouge,1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occured on Screen setups");
            }
         
        }

        private void SetUpCCSpriteButtonEvents() {
         
            _terminal.Pressed = (touch, _event) => {
                _terminal.UpdateDisplayedColor(CCColor3B.Gray);
            };
            _terminal.Released = (touch, _event) => {
                _terminal.UpdateDisplayedColor(CCColor3B.White);
                AppSettings.CurrentScene = SceneManagers.SceneType.Menu;
                SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
            };

            _classicon.Pressed = (touch, _event) => {
                _classicon.UpdateDisplayedColor(CCColor3B.Gray);
            };
            _classicon.Released = (touch, _event) => {
                _classicon.UpdateDisplayedColor(CCColor3B.White);
             
                _classicon.Schedule(go =>
                {
                    if (ScheduleTriggers.GotoClassroom)
                    {
                        ScheduleTriggers.GotoClassroom = false;
                        AppSettings.CurrentScene = SceneManagers.SceneType.Class;
                        SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                    }

                });

            };
        }

        private void PositionScreens() {
            try {
                ExamSection.Position = new CCPoint(Screen.GameWidth / 2,Screen.DeviceHeight/2);
                DialougeSection.Position = new CCPoint(Screen.GameWidth / 2, Screen.DeviceHeight / 2);
                MenuScreens.Position = new CCPoint(ExamSection.ContentSize.Width / 2, MenuScreens.ContentSize.Height/2);
                AnswerScreens.Position = new CCPoint(ExamSection.ContentSize.Width / 2, MenuScreens.PositionY + AnswerScreens.ContentSize.Height/1.5f);
                QuestionScreen.Position = new CCPoint(ExamSection.ContentSize.Width / 2, ExamSection.ContentSize.Height - QuestionScreen.ContentSize.Height/2.05f) ;
                DialougeService.GameLabDialouge.Position = new CCPoint(Screen.DeviceWidth / 2, DialougeService.GameDialouge.ContentSize.Height / 1.75f);
                _terminal.Position = new CCPoint(_terminal.ContentSize.Width / 1.5f, Screen.GameHeight - _terminal.ContentSize.Height / 1.15f);
                _classicon.Position = new CCPoint(Screen.GameWidth - _classicon.ContentSize.Width / 1.15f, _terminal.PositionY);
            } catch (Exception ex) {
                 Debug.WriteLine("Error occured on Screen Positioning");
            }
        }




        private void LoadQuestionBoard() {
            
         
            QuestionText = new CCLabel(QuestionService.LoadedQuestions[_round].Question, ResourceManager.Instance.Netron_Font,
                 CustomSize.resizeFont(QuestionService.LoadedQuestions[_round].Question, QuestionScreen.ContentSize.Width / 1.1f),
                 CCLabelFormat.SystemFont);
            QuestionText.LineBreak = CCLabelLineBreak.Word;
            QuestionText.VerticalAlignment = CCVerticalTextAlignment.Center;
            QuestionText.HorizontalAlignment = CCTextAlignment.Center;
            QuestionText.Position = new CCPoint(QuestionScreen.ContentSize.Width / 2, QuestionScreen.ContentSize.Height / 2);
            QuestionText.Color = CCColor3B.White;
            QuestionText.Dimensions = new CCSize(QuestionScreen.ContentSize.Width *1.9f,QuestionScreen.ContentSize.Height*4.4f);
            QuestionScreen.AddChild(QuestionText);
            QuestionScreen.ScaleY = 0;
        
            ListOfChoices = new List<CCSpriteButton>();
        }

        private void LoadAnswers() {
            ListOfChoices = new List<CCSpriteButton>();
            var correct = QuestionService.LoadedQuestions[_round].CorrectAnswer;
            var wronganswers = QuestionService.LoadedQuestions[_round].WrongAnswer;
            var choices = wronganswers;
             choices.Add(correct);

           choices = choices.ShuffleList();
          
            for (int i = 0; i < 4; i++) {
                var selectedAnswer = choices[i];

              var  choiceButton = new CCSpriteButton(ResourceManager.Instance.LongButton,selectedAnswer,ResourceManager.Instance.Netron_Font,
                    
                    AnswerScreens.ContentSize.Width/1.05f, AnswerScreens.ContentSize.Height/5f,2.8f);
                
                if (i == 0)
                {
                    choiceButton.Position = new CCPoint(AnswerScreens.ContentSize.Width/2,AnswerScreens.ContentSize.Height - choiceButton.ContentSize.Height*1.05f); 
                }
                else {
                    choiceButton.Position = new CCPoint(AnswerScreens.ContentSize.Width / 2, ListOfChoices[i-1].PositionY - choiceButton.ContentSize.Height *1.05f);
                }

                choiceButton.Pressed = (touch, _event) => {
                    choiceButton.UpdateDisplayedColor(CCColor3B.DarkGray);
                };
                choiceButton.Released =  (touch, _event) => {
                    choiceButton.UpdateDisplayedColor(CCColor3B.White);
                    if (selectedAnswer == QuestionService.LoadedQuestions[_round].CorrectAnswer)
                    {
                        
                        _round++;
                        ClearGameScreens();
                        StartNewRound();
                    }
                    else {
                        SoundManagers.Instance.PlayWrongAnswerSound();
                        choiceButton.UpdateDisplayedColor(CCColor3B.Red);
                        choiceButton.PauseListeners(true);
                        Debug.WriteLine("Selected Wrong answer");
                    }

                    if (_round == 5) {
                        GameFinished = true;
                    }
                };
                choiceButton.ScaleX = 0;
               


                ListOfChoices.Add(choiceButton);
                AnswerScreens.AddChild(choiceButton);
            }
            PlayAnimation();
        }

        private void ClearGameScreens() {
            AnswerScreens.Children.Clear();
            AnswerScreens.RemoveAllChildren();
            QuestionScreen.Children.Clear();
            QuestionScreen.RemoveAllChildren();
            foreach (var button in ListOfChoices) {
                button.PauseListeners(true) ;
                button.RemoveFromParent();
            }
        }

        private  void PlayAnimation() {
            var scale = new CCScaleTo(0.35f, 1, 1);
            QuestionScreen.RunActionAsync(scale).ContinueWith(s => {
                ListOfChoices[0].RunActionAsync(scale).ContinueWith(a => {
                    ListOfChoices[1].RunActionAsync(scale).ContinueWith(b => {
                        ListOfChoices[2].RunActionAsync(scale).ContinueWith(c => {
                            ListOfChoices[3].RunActionAsync(scale).ContinueWith(d => {

                            });
                        });
                    });
                });
            });
         
        }

        private void StartNewRound() {
         
            LoadQuestionBoard();
            LoadAnswers();
        }


        private void ReturnOnceFinished() {
            Schedule(back=> {
                if (GameFinished)
                {
                    GameFinished = false;
                    AppSettings.CurrentScene = SceneManagers.SceneType.Class;
                    SceneManagers.Instance.NavigateToScene(SceneManagers.SceneType.Loading);
                }
            });
        }
        protected override void AddedToScene()
        {
            base.AddedToScene();
            PositionScreens();
        }
    }
}
